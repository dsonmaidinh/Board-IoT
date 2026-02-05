/* USER CODE BEGIN Header */
/**
  ******************************************************************************
  * @file           : main.c
  * @brief          : Main program body
  ******************************************************************************
  * @attention
  *
  * Copyright (c) 2025 STMicroelectronics.
  * All rights reserved.
  *
  * This software is licensed under terms that can be found in the LICENSE file
  * in the root directory of this software component.
  * If no LICENSE file comes with this software, it is provided AS-IS.
  *
  ******************************************************************************
  */
/* USER CODE END Header */
/* Includes ------------------------------------------------------------------*/
#include "main.h"

/* Private includes ----------------------------------------------------------*/
/* USER CODE BEGIN Includes */
#include <math.h>
#include "DHT.h"
#include "cJSON.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdint.h>
#include <stdbool.h>
#include "stdarg.h"
/* USER CODE END Includes */

/* Private typedef -----------------------------------------------------------*/
/* USER CODE BEGIN PTD */

/* USER CODE END PTD */

/* Private define ------------------------------------------------------------*/
/* USER CODE BEGIN PD */

/* USER CODE END PD */

/* Private macro -------------------------------------------------------------*/
/* USER CODE BEGIN PM */

/* USER CODE END PM */

/* Private variables ---------------------------------------------------------*/
TIM_HandleTypeDef htim4;

UART_HandleTypeDef huart1;
UART_HandleTypeDef huart3;
DMA_HandleTypeDef hdma_usart1_rx;
DMA_HandleTypeDef hdma_usart1_tx;
DMA_HandleTypeDef hdma_usart3_rx;
DMA_HandleTypeDef hdma_usart3_tx;

/* USER CODE BEGIN PV */

/* USER CODE END PV */

/* Private function prototypes -----------------------------------------------*/
void SystemClock_Config(void);
static void MX_GPIO_Init(void);
static void MX_DMA_Init(void);
static void MX_USART1_UART_Init(void);
static void MX_USART3_UART_Init(void);
static void MX_TIM4_Init(void);
/* USER CODE BEGIN PFP */
void SettingESP(void);
void CheckSettingESP(void);
void Connect_To_HiveMQ();
void Publish(char *pub , float ND , unsigned int DA, float docadc , unsigned int TB1,  unsigned int TB2, unsigned int C1, unsigned int C2);
void Sub(void);
void ChangeMode(void);
int  Send_AT_Commands_Setting(const char *AT_Commands, const char *DataResponse, uint32_t timeout_ms, uint32_t setting);
int  Send_AT_Commands_SendMessager(char *AT_Commands, char *DataResponse , uint32_t timeout);

void UART_ClearBuffer(uint8_t buffer_select);
void UART_Receive_Enable(UART_HandleTypeDef *huart, uint8_t *pData, uint16_t Size);
void UART_Receive_Disable(UART_HandleTypeDef *huart);
void UART1_Handle_MQTT_json(const char* uart_data, char *Topic);
void UART1_Handle_MQTT_json_TEST(const char* uart_data, char *Topic);
void UART2_Handle_Command(void);

void CleanJsonString(char* input);

float my_atof(const char *str);

void Send_Data(uint8_t Slave_Address, uint8_t Function, uint16_t SA, uint16_t NP);
void Read_Holding_Reg(uint8_t *Rx_Buff);
void Preset_Multiple_Reg(uint8_t *Rx_Buff);
void Preset_Single_Reg(uint8_t *Rx_Buff);
uint16_t ComputeCRC(uint8_t *pData, int length);
bool CheckCRC(uint8_t *buffer, uint16_t length);
/* USER CODE END PFP */

/* Private user code ---------------------------------------------------------*/
/* USER CODE BEGIN 0 */
/*===	DEFINE	===*/
#define Modbus_Inf					0
#define MQTT_Inf						1
#define Debug_ON						1
#define Debug_OFF					0

#define MAX_BUFFER 					512
#define MAX_DATA 						512
#define DELAY_CONFIG				1000
#define COMMAND_TIMEOUT_MS 	1000
#define MAX_RETRY_COUNT 			 5
#define CLEAR_UART1_BUFFER 	0x01
#define CLEAR_UART2_BUFFER 	0x02

#define 	STM_ID  									0x01
#define 	Read_Holding_Registers 		0x03
#define 	Preset_Single_Register 		0x06
#define 	Preset_Multiple_Register 	0x10
#define 	Run_but 									0
#define 	Stop_but 									1
#define 	Temp_Reg 									2
#define 	Hum_Reg 									3
#define 	LED_RED 									7
#define 	LED_GREEN 								8
#define 	LED_YELLOW 								9
#define 	LED_FULL 									10
#define		LED_ON										GPIO_PIN_RESET
#define		LED_OFF										GPIO_PIN_SET
#define		PRESSED										GPIO_PIN_RESET

#define		RED_GPIO_Port							GPIOA
#define		RED_Pin										GPIO_PIN_4
#define		YELLOW_GPIO_Port					GPIOA
#define		YELLOW_Pin								GPIO_PIN_3
#define		GREEN_GPIO_Port						GPIOA
#define		GREEN_Pin									GPIO_PIN_2

#define		Run_GPIO_Port							GPIOA
#define		Run_Pin										GPIO_PIN_0
#define		Stop_GPIO_Port						GPIOA
#define		Stop_Pin									GPIO_PIN_1
/*===	VARIABLES	===*/
uint8_t led_select[4] = {0};
GPIO_TypeDef* ports[] = { RED_GPIO_Port, YELLOW_GPIO_Port, GREEN_GPIO_Port, GPIOC };
uint16_t pins[]       = { RED_Pin, YELLOW_Pin, GREEN_Pin, GPIO_PIN_13 };

float 		temp 					= 0;
uint8_t 	Debug 				= Debug_OFF;
uint8_t 	Mode 					= MQTT_Inf;
volatile uint8_t 	UART2_flag 		= 0;
volatile uint8_t	UART1_flag 		= 0;
uint8_t		retry_count 	= 0;
uint8_t 	SettingOK 		= 0; 
uint8_t 	ErrorCode 		= 0;
uint16_t	hum 					= 0;
uint32_t 	last;
volatile uint8_t uart_dma_busy = 0;

DHT_DataTypedef DHT11_Data;
float Temperature, Humidity;

char Rx_buffer_1[MAX_BUFFER];      
char Rx_buffer_2[MAX_BUFFER];      
char DataSendAT[MAX_DATA];
char CheckConfig[MAX_DATA];
char TxData_MQTT[MAX_DATA];
char SubTopic[MAX_DATA] = "son_Rx";
char PubTopic[MAX_DATA] = "son_Tx";

typedef struct {
    char *command;
    char *expected_response;
    uint32_t timeout_ms;
} AT_Command;
typedef struct {
    const char *command;
    void (*handler)(void);
} CommandEntry;
const CommandEntry LAP_CMD[] = {
    { "Setting ESP" , SettingESP },
		{ "Check Setting ESP", CheckSettingESP },
		{ "MQTT", 	ChangeMode },
		{ "Modbus", ChangeMode },
		{ "Start Debug", ChangeMode },
		{ "Stop Debug", ChangeMode },
		
		{ "Sub", Sub },
    { NULL, NULL } // Terminator
		//{"Start measuring", StartSend},
};
typedef struct {
    float ND;
    uint16_t DA;
		float docadc;
    uint16_t TB1;
    uint16_t TB2;
    uint16_t C1;
    uint16_t C2;
} STM32_Data;
STM32_Data DataToTx_Data;

uint8_t 	buffer;
uint8_t 	index = 0;

uint8_t 	rx_Data[MAX_BUFFER] 	= {0};
uint8_t 	tx_Data[MAX_BUFFER] 	= {0};
char 			debug_Data[MAX_BUFFER] 	= {0};	
uint16_t 	STM32_Reg[MAX_BUFFER] = {0};

uint8_t		check = 0, cnt = 0;
uint16_t 	pre_Size = 0;
unsigned int 	TB2_val		= 0;

// update
volatile uint8_t uart2_tx_done = 1;

/*===	FUNCTION	===*/
struct  _FILE{
  int handle;
  
};

FILE __stdout;
static uint8_t dma_busy = 0;

int fputc(int ch, FILE *f) {
    static uint8_t tx_byte;  // Bi?n tinh gi? byte c?n truy?n
    tx_byte = (uint8_t)ch;

    // �?i n?u UART dang b?n truy?n DMA tru?c d�
    while (HAL_UART_GetState(&huart3) == HAL_UART_STATE_BUSY_TX) {}

    // G?i byte qua UART b?ng DMA
    HAL_UART_Transmit_DMA(&huart3, &tx_byte, 1);

    // �?i DMA truy?n xong byte n�y (n?u b?n mu?n d?ng b? ho�n to�n)
    while (HAL_UART_GetState(&huart3) == HAL_UART_STATE_BUSY_TX) {}

    return ch;
}




void ChangeMode(void){
	if(strstr(Rx_buffer_2, "MQTT")) 				Mode = MQTT_Inf;
	else if(strstr(Rx_buffer_2, "Modbus")) 	Mode = Modbus_Inf;
	else if(strstr(Rx_buffer_2, "Start Debug")) 	Debug = Debug_ON;
	else if(strstr(Rx_buffer_2, "Stop Debug")) 		Debug = Debug_OFF;
	UART_ClearBuffer(CLEAR_UART2_BUFFER);
}
int Send_AT_Commands_Setting(const char *AT_Commands, const char *DataResponse, uint32_t timeout_ms, uint32_t setting) {
    uint32_t ConfigAT = setting;
    retry_count = 0;

    snprintf(DataSendAT, sizeof(DataSendAT), "%s\r\n", AT_Commands);          

    while (retry_count < MAX_RETRY_COUNT) {
        HAL_UART_Transmit(&huart1, (uint8_t *)DataSendAT, strlen(DataSendAT), COMMAND_TIMEOUT_MS);

        snprintf(debug_Data, sizeof(debug_Data), "Send AT Command (%d/%d): %s", 
                 retry_count + 1, MAX_RETRY_COUNT, DataSendAT);
        HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));

        uint32_t wait_start = HAL_GetTick();
        while ((HAL_GetTick() - wait_start) < timeout_ms) {
            if (strstr(Rx_buffer_1, DataResponse) != NULL) {
                snprintf(debug_Data, sizeof(debug_Data), "Received response: %s\r\n", DataResponse);
                HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));

                UART_ClearBuffer(CLEAR_UART1_BUFFER);
                return 1;
            }
            HAL_Delay(10);
        }

        snprintf(debug_Data, sizeof(debug_Data), "Received response: %s\r\n", Rx_buffer_1);
        HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));

        retry_count++;
    }

    snprintf(debug_Data, sizeof(debug_Data), "Failed to apply settings after %d retries\r\n", MAX_RETRY_COUNT);
    HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));

    return 0;
}

int Send_AT_Commands_SendMessager(char *AT_Commands, char *DataResponse , uint32_t timeout){
    retry_count = 0;
    char DataHTTP[MAX_BUFFER];
		memset(DataHTTP, 0, sizeof(DataHTTP));
		snprintf(DataHTTP, sizeof(DataHTTP),"%s\r\n", AT_Commands);
    while (retry_count < MAX_RETRY_COUNT) {
        HAL_UART_Transmit_DMA(&huart1, (uint8_t *)DataHTTP, strlen(DataHTTP));
				
        if(Debug) {
						snprintf(debug_Data, sizeof(debug_Data), "Send AT Command (%d/%d): %s", retry_count + 1, MAX_RETRY_COUNT, DataHTTP);
						HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));
				}
        uint32_t wait_start = HAL_GetTick();
        while ((HAL_GetTick() - wait_start) < timeout) {
            if (strstr(Rx_buffer_1, DataResponse) != NULL) {
								if(Debug) {
										snprintf(debug_Data, sizeof(debug_Data), "Received response: %s\r\n", DataResponse);
										HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));
								}
                UART_ClearBuffer(CLEAR_UART1_BUFFER);
                return 1;
            }
            HAL_Delay(10); // Gi?m CPU usage	
        }
        if(Debug) {
						snprintf(debug_Data, sizeof(debug_Data), "Received response: %s\r\n", Rx_buffer_1);
						HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));
				}
        retry_count++;
    }
    if(Debug) {
				snprintf(debug_Data, sizeof(debug_Data), "Failed to send MQTT message after %d retries!!!\n", MAX_RETRY_COUNT);
				HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));
		}
		return 0;
}

void UART1_Handle_MQTT_json(const char* uart_data, char *Topic) {
		if (strstr(uart_data, Topic) == NULL) return;
		const char* json_start = strchr(uart_data, '{');
    char* json_end = strrchr(uart_data, '}');
    if (!json_start || !json_end || json_end <= json_start) {
				strcpy(debug_Data, "[Failed] Data doesn't have JSON!\n");
				HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));
        return;
    }
    int json_len = json_end - json_start + 1;
    if (json_len >= MAX_DATA) {
				strcpy(debug_Data, "[Failed] JSON too long!\n");
				HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));
        return;
    }
    char json_buffer[MAX_DATA];
    strncpy(json_buffer, json_start, json_len);
    json_buffer[json_len] = '\0';
    CleanJsonString(json_buffer);
    cJSON* root = cJSON_Parse(json_buffer);
    if (!root) {
				strcpy(debug_Data, "[Failed] Parse JSON Failed\n");
				HAL_UART_Transmit_DMA(&huart3, (uint8_t *)debug_Data, strlen(debug_Data));
				cJSON_Delete(root);
        return;
    }
		const char* keys[]  = { "TB2"};
		HAL_GPIO_WritePin(GPIOB, GPIO_PIN_1, GPIO_PIN_SET);
		GPIO_TypeDef* ports[] = { RED_GPIO_Port, YELLOW_GPIO_Port, GREEN_GPIO_Port, GPIOC };
		uint16_t pins[]     = { RED_Pin, YELLOW_Pin, GREEN_Pin, GPIO_PIN_13 };
		size_t num_leds = sizeof(pins) / sizeof(pins[0]);
		cJSON* item = cJSON_GetObjectItemCaseSensitive(root, keys[0]);
		if (item && cJSON_IsString(item) && item->valuestring != NULL) {
			TB2_val = (unsigned int)atoi(item->valuestring);
			for (size_t i = 0; i < num_leds; i++) {
				if (TB2_val & (1 << i)) {
					HAL_GPIO_WritePin(ports[i], pins[i], LED_ON);
				}
				else {
					HAL_GPIO_WritePin(ports[i], pins[i], LED_OFF);
				}
			}
		} 
		else {
			// optional: x? l� l?i, v� d? b?t LED d? c?nh b�o
		}
		cJSON_Delete(root);
		return;
//		if (strstr(uart_data, Topic) == NULL) return;

//		const char* json_start = strchr(uart_data, '{');
//    char* json_end = strrchr(uart_data, '}');
//    if (!json_start || !json_end || json_end <= json_start) {
//        printf("[Failed] Data doesn't have JSON!\n");
//        return;
//    }

//    int json_len = json_end - json_start + 1;
//    if (json_len >= MAX_DATA) {
//        printf("[Failed] JSON too long!\n");
//        return;
//    }

//    char json_buffer[MAX_DATA];
//    strncpy(json_buffer, json_start, json_len);
//    json_buffer[json_len] = '\0';

//    CleanJsonString(json_buffer);
//    cJSON* root = cJSON_Parse(json_buffer);
//    if (!root) {
//        printf("[Failed] Parse JSON Failed: %s\n", cJSON_GetErrorPtr());
//				cJSON_Delete(root);
//        return;
//    }
////		char* json_str = cJSON_Print(root);  // ho?c cJSON_PrintUnformatted(root);
////		if (json_str) {
////				HAL_UART_Transmit_DMA(&huart3, (uint8_t *)json_str, strlen(json_str));
////				free(json_str);  // nh? free sau khi d�ng xong
////		}

//		const char* keys[]  = { "L1", "L2", "L3", "L4" ,"LED1", "LED2", "LED3", "LED4"};
//		GPIO_TypeDef* ports[] = { RED_GPIO_Port, YELLOW_GPIO_Port, GREEN_GPIO_Port, GPIOC };
//		uint16_t pins[]     = { RED_Pin, YELLOW_Pin, GREEN_Pin, GPIO_PIN_13 };

//		for (int i = 0; i < sizeof(keys) / sizeof(keys[0]); i++) {
//				cJSON* item = cJSON_GetObjectItemCaseSensitive(root, keys[i]);
//				if (item && cJSON_IsString(item)) {
//						if (strcmp(item->valuestring, "ON") == 0) {
//								HAL_GPIO_WritePin(ports[i], pins[i], LED_ON);
//						} else {
//								HAL_GPIO_WritePin(ports[i], pins[i], LED_OFF);
//						}
//				}
//		}
//		cJSON_Delete(root);
//		return;
		
//    const char* keys[] = { "ND", "DA", "docadc", "TB1", "TB2", "C1", "C2" };

//    for (int i = 0; i < sizeof(keys) / sizeof(keys[0]); i++) {
//        cJSON* item = cJSON_GetObjectItemCaseSensitive(root, keys[i]);
//        if (item != NULL) {
//            if (cJSON_IsString(item)) {
//                printf("%s = %s\n", keys[i], item->valuestring);
//                if      (strcmp(keys[i], "ND") == 0)      DataToTx_Data.ND     = atof(item->valuestring);
//                else if (strcmp(keys[i], "DA") == 0)      DataToTx_Data.DA     = (uint16_t)atoi(item->valuestring);
//                else if (strcmp(keys[i], "docadc") == 0)  DataToTx_Data.docadc = atof(item->valuestring);
//                else if (strcmp(keys[i], "TB1") == 0)     DataToTx_Data.TB1    = (uint16_t)atoi(item->valuestring);
//                else if (strcmp(keys[i], "TB2") == 0)     DataToTx_Data.TB2    = (uint16_t)atoi(item->valuestring);
//                else if (strcmp(keys[i], "C1") == 0)      DataToTx_Data.C1     = (uint16_t)atoi(item->valuestring);
//                else if (strcmp(keys[i], "C2") == 0)      DataToTx_Data.C2     = (uint16_t)atoi(item->valuestring);
//            } 
//						else if (cJSON_IsNumber(item)) {
//                printf("%s = %f\n", keys[i], item->valuedouble);
//                if      (strcmp(keys[i], "ND") == 0)      DataToTx_Data.ND     = (float)item->valuedouble;
//                else if (strcmp(keys[i], "DA") == 0)      DataToTx_Data.DA     = (uint16_t)item->valuedouble;
//                else if (strcmp(keys[i], "docadc") == 0)  DataToTx_Data.docadc = (float)item->valuedouble;
//                else if (strcmp(keys[i], "TB1") == 0)     DataToTx_Data.TB1    = (uint16_t)item->valuedouble;
//                else if (strcmp(keys[i], "TB2") == 0)     DataToTx_Data.TB2    = (uint16_t)item->valuedouble;
//                else if (strcmp(keys[i], "C1") == 0)      DataToTx_Data.C1     = (uint16_t)item->valuedouble;
//                else if (strcmp(keys[i], "C2") == 0)      DataToTx_Data.C2     = (uint16_t)item->valuedouble;
//            }
//        } 
//				else {
//            printf("Key %s not found in JSON\n", keys[i]);
//        }
//    }
//		printf("ND: %.2f, DA: %d, docadc: %.2f, TB1: %d, TB2: %d, C1: %d, C2: %d\n",
//           DataToTx_Data.ND, DataToTx_Data.DA, DataToTx_Data.docadc,
//           DataToTx_Data.TB1, DataToTx_Data.TB2, DataToTx_Data.C1, DataToTx_Data.C2);		
}
char mode_start[] = "OK";
void UART2_Handle_Command(void) {
    char *trimmed = strtok((char *)Rx_buffer_2, "\r\n");
    for (const CommandEntry *cmd = LAP_CMD; cmd->command != NULL; cmd++) {
        if (trimmed && strcmp(trimmed, cmd->command) == 0) {
            if (cmd->handler) {
                cmd->handler();
            }
            break;
        }
    }
    UART_ClearBuffer(CLEAR_UART2_BUFFER);
}
void UART_ClearBuffer(uint8_t buffer_select){
    if(buffer_select & CLEAR_UART1_BUFFER) {
        memset(Rx_buffer_1, 0, sizeof(Rx_buffer_1));
        __HAL_UART_FLUSH_DRREGISTER(&huart1);
    }
    
    if(buffer_select & CLEAR_UART2_BUFFER) {
        memset(Rx_buffer_2, 0, sizeof(Rx_buffer_2));
        __HAL_UART_FLUSH_DRREGISTER(&huart3);
    }
}
void UART_Receive_Enable(UART_HandleTypeDef *huart, uint8_t *pData, uint16_t Size){
    HAL_UARTEx_ReceiveToIdle_DMA(huart, pData, Size);
    __HAL_DMA_DISABLE_IT(huart->hdmarx, DMA_IT_HT | DMA_IT_TC);
}
//void UART_Receive_Disable(UART_HandleTypeDef *huart){
//    // D?ng DMA nh?n
//    HAL_UART_DMAStop(huart);
//    
//    // T?t t?t c? ng?t DMA
//    __HAL_DMA_DISABLE_IT(huart->hdmarx, DMA_IT_HT | DMA_IT_TC | DMA_IT_TE | DMA_IT_FE | DMA_IT_DME);
//    
//    // Reset c? ng?t
//    __HAL_DMA_CLEAR_FLAG(huart->hdmarx, __HAL_DMA_GET_HT_FLAG_INDEX(huart->hdmarx));
//    __HAL_DMA_CLEAR_FLAG(huart->hdmarx, __HAL_DMA_GET_TC_FLAG_INDEX(huart->hdmarx));
//    
////    printf("UART%d RX DMA interrupts disabled\n", (huart->Instance == USART1) ? 1 : 2);
//}
void HAL_UARTEx_RxEventCallback(UART_HandleTypeDef *huart, uint16_t Size){
    if (huart->Instance == USART1)
    {
        UART_Receive_Enable(&huart1, (uint8_t *)Rx_buffer_1, MAX_BUFFER);
				if(SettingOK == 1 && ErrorCode == 1) {
					if(strstr(Rx_buffer_1, "+MQTTSUBRECV")){
						UART1_flag = 1;
						UART2_flag = 0;		
					}	
				}
    }
    else if (huart->Instance == USART3)
    {
				
				if(Mode == MQTT_Inf){
						UART_Receive_Enable(&huart3, (uint8_t *)Rx_buffer_2, MAX_BUFFER);	
						UART1_flag = 0;			
						UART2_flag = 1;
						return;
				}
				UART_Receive_Enable(&huart3, (uint8_t *)rx_Data, MAX_BUFFER);	
				pre_Size = Size;
				uint8_t func = rx_Data[1];
				switch(func){
						case Read_Holding_Registers:
								if (Size == 8) Read_Holding_Reg(rx_Data);
								break;

						case Preset_Single_Register:
								if (Size == 8){
										uint16_t reg_add = (rx_Data[2] << 8) | rx_Data[3];
										STM32_Reg[reg_add] = (rx_Data[4] << 8) | rx_Data[5];

										// Update LEDs from LED_FULL register
										uint8_t led = STM32_Reg[LED_FULL];
										HAL_GPIO_WritePin(RED_GPIO_Port, RED_Pin,     (led & 0x04) ? LED_ON : LED_OFF);
										HAL_GPIO_WritePin(YELLOW_GPIO_Port, YELLOW_Pin, (led & 0x02) ? LED_ON : LED_OFF);
										HAL_GPIO_WritePin(GREEN_GPIO_Port, GREEN_Pin, (led & 0x01) ? LED_ON : LED_OFF);


										Preset_Single_Reg(rx_Data);
								}
								break;

						case Preset_Multiple_Register: {
								uint16_t start_add = (rx_Data[2] << 8) | rx_Data[3];
								uint16_t quantity  = (rx_Data[4] << 8) | rx_Data[5];

								if ((start_add + quantity) <= MAX_BUFFER){
										for (uint16_t i = 0; i < quantity; i++){
												STM32_Reg[start_add + i] = (rx_Data[7 + i*2] << 8) | rx_Data[7 + i*2 + 1];
										}

										// Update individual LEDs
										HAL_GPIO_WritePin(RED_GPIO_Port, RED_Pin,     STM32_Reg[LED_RED] ? LED_ON : LED_OFF);
										HAL_GPIO_WritePin(GREEN_GPIO_Port, GREEN_Pin, STM32_Reg[LED_GREEN] ? LED_ON : LED_OFF);
										HAL_GPIO_WritePin(YELLOW_GPIO_Port, YELLOW_Pin, STM32_Reg[LED_YELLOW] ? LED_ON : LED_OFF);

										Preset_Multiple_Reg(rx_Data);
								}
								break;
						}

						default:
								ChangeMode();
								break;
				}
    }
		
}
void SettingESP(void){
	HAL_TIM_Base_Stop_IT(&htim4);
	const AT_Command commands[] = {
				// Reset & Connect Wifi
        {"AT+RST", "OK", 10000},
        {"AT", "OK", 2000},
        {"ATE0", "OK", 2000},
        {"AT+CWMODE=1", "OK", 2000},
        {"AT+CWJAP=\"DONG SON\",\"05041901\"", "WIFI CONNECTED", 10000},
        {"AT+CIPMUX=0", "OK", 2000},
				// Connect Broker
//				{"AT+MQTTCONNCFG=0,60,0,\"son_Tx\",\"Disconnected\",0,0", "OK", 3000}, 
				{"AT+MQTTUSERCFG=0,2,\"ESP32\",\"dongson\",\"Son12345\",0,0,\"\"", "OK", 3000}, 
				{"AT+MQTTCONN=0,\"584e8806f87e44a8971effe122bc6789.s1.eu.hivemq.cloud\",8883,0", "MQTTCONNECTED", 3000},
				// Sub Topic son_Tx
				{"AT+MQTTSUB=0,\"son_Rx\",0", "OK", 2000},
        {NULL, NULL, 0}
    };
    ErrorCode = 0;
		SettingOK = 0;
		
    for (int i = 0; commands[i].command != NULL; i++) {
        if (!Send_AT_Commands_Setting(commands[i].command, commands[i].expected_response, commands[i].timeout_ms, 0)) return;
        HAL_Delay(DELAY_CONFIG);
    }
		ErrorCode = 1;
		SettingOK = 1;
		HAL_TIM_Base_Start_IT(&htim4);
}
void CheckSettingESP(void){
		HAL_TIM_Base_Stop_IT(&htim4);
		const AT_Command commands[] = {
				// Connect Wifi?
        {"AT+CWJAP?", "OK", 10000},
				// Connect Broker?
				{"AT+MQTTCONN?", "OK", 3000}, 
				// Sub Topic son_Tx
				{"AT+MQTTSUB?", "OK", 2000},
        {NULL, NULL, 0} // K?t th�c danh s�ch
    };
    ErrorCode = 0;
		SettingOK = 0;
    for (int i = 0; commands[i].command != NULL; i++) {
        if (!Send_AT_Commands_Setting(commands[i].command, commands[i].expected_response, commands[i].timeout_ms, 0)) {
						return; // D?ng n?u c� l?i
        }
        HAL_Delay(DELAY_CONFIG);
    }
		ErrorCode = 1;
		SettingOK = 1;
		UART_ClearBuffer(CLEAR_UART1_BUFFER);
		UART_ClearBuffer(CLEAR_UART2_BUFFER);
		HAL_TIM_Base_Start_IT(&htim4);
}
void Connect_To_HiveMQ(){
	const AT_Command commands[] = {
		{"AT+MQTTCLEAN=0", "OK", 10000},
    // L?nh c?u h�nh MQTT (d� s?a tham s? t? 5 th�nh 2 v� th�m c�c tham s? cu?i)
    {"AT+MQTTUSERCFG=0,2,\"ESP32\",\"dongson\",\"Son12345\",0,0,\"\"", "OK", 3000}, 
    
    // L?nh k?t n?i MQTT v?i broker (HiveMQ) - gi? nguy�n
    {"AT+MQTTCONN=0,\"584e8806f87e44a8971effe122bc6789.s1.eu.hivemq.cloud\",8883,0", "OK", 3000},
    
    {NULL, NULL, 0} // K?t th�c danh s�ch  
};
    
    for (int i = 0; commands[i].command != NULL; i++) {
        if (!Send_AT_Commands_Setting(commands[i].command, commands[i].expected_response, commands[i].timeout_ms, 0)) {
						return; // D?ng n?u c� l?i
        }
        HAL_Delay(DELAY_CONFIG);
    }
		return;
}

void Publish(char *pub, float ND, unsigned int DA, float docadc, unsigned int TB1, unsigned int TB2, unsigned int C1, unsigned int C2) {
    char JSON_Data[MAX_DATA];
    memset(JSON_Data, 0, sizeof(JSON_Data));
    snprintf(JSON_Data, sizeof(JSON_Data),
             "{\"ND\":\"%.2f\",\"DA\":\"%u\",\"docadc\":\"%.2f\",\"TB1\":\"%u\",\"TB2\":\"%u\",\"C1\":\"%u\",\"C2\":\"%u\"}",
             ND, DA, docadc, TB1, TB2, C1, C2);

    snprintf(TxData_MQTT, sizeof(TxData_MQTT),
             "AT+MQTTPUBRAW=0,\"%s\",%lu,0,0", pub, (unsigned long)strlen(JSON_Data));

    
    if(Send_AT_Commands_SendMessager(TxData_MQTT, "OK", 5000))Send_AT_Commands_SendMessager(JSON_Data, "+MQTTPUB:OK", 5000);
}

void Sub(void){
		const AT_Command commands[] = {  
				// L?nh publish MQTT v?i payload JSON (d� s?a)
				{"AT+MQTTSUB=0,\"son_Rx\",0", "OK", 1000},
				
				// C�c l?nh kh�c gi? nguy�n...
				{NULL, NULL, 0} // K?t th�c danh s�ch
		};
    
    for (int i = 0; commands[i].command != NULL; i++) {
        if (!Send_AT_Commands_Setting(commands[i].command, commands[i].expected_response, commands[i].timeout_ms, 0)) {
						return; // D?ng n?u c� l?i
        }
        HAL_Delay(DELAY_CONFIG);
    }
		return;
}
void CleanJsonString(char* input){
    char* src = input;
    char* dst = input;

    while (*src)
    {
        if (*src >= 32 && *src <= 126)  // Gi? k� t? ASCII in du?c
        {
            *dst++ = *src;
        }
        src++;
    }
    *dst = '\0'; // k?t th�c chu?i
}

//=======================================================================
/*=== SLAVE	===*/
void Read_Holding_Reg(uint8_t *Rx_Buff){
	tx_Data[0] = STM_ID;
	tx_Data[1] = Read_Holding_Registers;
	tx_Data[2] = Rx_Buff[5] * 2;
	uint8_t index_tx = 3;
	for(uint16_t i = 0; i < Rx_Buff[5]; i++){
		tx_Data[index_tx++] 			= (STM32_Reg[i] >> 8) & 0xFF;
		tx_Data[index_tx++] 			= (STM32_Reg[i] >> 0) & 0xFF;
	}
	
	uint8_t len 		= 3 + Rx_Buff[5]*2;
	uint16_t crc 		= ComputeCRC(tx_Data, len);
	tx_Data[len]   	= crc & 0xFF;
	tx_Data[len+1] 	= (crc >> 8) & 0xFF;

	HAL_UART_Transmit(&huart3, tx_Data, len+2, 1000);
//	HAL_UART_Transmit_DMA(&huart3, Send, 8);
}
void Preset_Multiple_Reg(uint8_t *Rx_Buff){
	for (uint8_t i = 0; i < 6; i++)
        tx_Data[i] = Rx_Buff[i];
	uint16_t crc = ComputeCRC(tx_Data, 6);
	tx_Data[6]   = crc & 0xFF;         // CRC Low byte
	tx_Data[6+1] = (crc >> 8) & 0xFF;  // CRC High byte
	HAL_UART_Transmit(&huart3, tx_Data, 8, 1000);
//	HAL_UART_Transmit_DMA(&huart3, Send, 8);
}
void Preset_Single_Reg(uint8_t *Rx_Buff){
	for (uint8_t i = 0; i < 4; i++)
        tx_Data[i] = Rx_Buff[i];
	uint16_t reg_add = (Rx_Buff[2] << 8) | Rx_Buff[3];  // Modbus: b?t d?u t? 1
	tx_Data[4] 		= (STM32_Reg[reg_add]>>8)&0xFF;
	tx_Data[5] 		= (STM32_Reg[reg_add]>>0)&0xFF;
	uint16_t crc 	= ComputeCRC(tx_Data, 6);
	tx_Data[6]   	= crc & 0xFF;         // CRC Low byte
	tx_Data[7] 		= (crc >> 8) & 0xFF;  // CRC High byte
	HAL_UART_Transmit(&huart3, tx_Data, 8, 1000);
//	HAL_UART_Transmit_DMA(&huart3, Send, 8);
}
uint16_t ComputeCRC(uint8_t *pData, int length){
    uint16_t crc = 0xFFFF;
    for (int pos = 0; pos < length; pos++)
    {
        crc ^= pData[pos];
        for (int i = 0; i < 8; i++)
        {
            if (crc & 0x0001)
                crc = (crc >> 1) ^ 0xA001;
            else
                crc >>= 1;
        }
    }
    return crc;
}

bool CheckCRC(uint8_t *buffer, uint16_t length){
    if (buffer == NULL || length < 3)
        return false; // Kh?ng d? d? li?u d? c? CRC

    // CRC nh?n du?c (2 byte cu?i)
    uint16_t crc_rx = buffer[length - 2] | (buffer[length - 1] << 8);

    // CRC t?nh l?i tr?n to?n b? ph?n data tr? 2 byte CRC cu?i
    uint16_t crc_calc = ComputeCRC(buffer, length - 2);

    return crc_rx == crc_calc;
}
float button = 0;
void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin){
		static unsigned long last_INT = 0;
    if (HAL_GetTick() - last_INT < 200) return;
		if(GPIO_Pin == Run_Pin) {
				if(HAL_GPIO_ReadPin(Run_GPIO_Port, GPIO_Pin) == PRESSED){
						STM32_Reg[Run_but] = 1;
						button++;
						DataToTx_Data.TB1 = button;
				}
				else {
						STM32_Reg[Run_but] = 0;
						if(button > 0) button--;
						DataToTx_Data.TB1 = button;
				}
		}
		else if(GPIO_Pin == Stop_Pin) {
				if(HAL_GPIO_ReadPin(Stop_GPIO_Port, GPIO_Pin) == PRESSED){
						STM32_Reg[Stop_but] = 1;
						button += 2;
						DataToTx_Data.TB1 = button;
				}
				else {
						STM32_Reg[Stop_but] = 0;
						if(button > 1) button -= 2;
						DataToTx_Data.TB1 = button;
				}
		}
		last_INT = HAL_GetTick();
}
void Measure_Temp(float *STM_Temp) {
    uint16_t temp_raw = rand() % 100;               
    uint16_t divisor = (rand() % 9) + 1;            
    *STM_Temp = (float)temp_raw / divisor;
		STM32_Reg[Temp_Reg] = 	*STM_Temp;
}
void Measure_Hum(uint16_t *STM_Hum) {
    uint16_t hum = rand() % 50;                        
    *STM_Hum = hum;  
		STM32_Reg[Hum_Reg] = 	*STM_Hum;	
}

uint8_t TimeToReadDHT11 = 0;
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim){
	if(htim == &htim4){
		TimeToReadDHT11++;
		if(TimeToReadDHT11 == 3){
//			DHT_GetData(&DHT11_Data);
//			Temperature = DHT11_Data.Temperature;
//			Humidity = DHT11_Data.Humidity;
//			STM32_Reg[Hum_Reg] = Humidity;
//			STM32_Reg[Temp_Reg] = Temperature;
//			DataToTx_Data.ND = Temperature;
//			DataToTx_Data.DA = Humidity;
			TimeToReadDHT11 = 0;
			float 	  temp = 0;
			uint16_t	hum = 0;
			Measure_Temp(&temp);
			Measure_Hum(&hum);
			STM32_Reg[Hum_Reg] = hum;
			STM32_Reg[Temp_Reg] = (uint16_t)temp;
			DataToTx_Data.ND = temp;
			DataToTx_Data.DA = hum;
		}
	}
}
/* USER CODE END 0 */

/**
  * @brief  The application entry point.
  * @retval int
  */
int main(void)
{

  /* USER CODE BEGIN 1 */

  /* USER CODE END 1 */

  /* MCU Configuration--------------------------------------------------------*/

  /* Reset of all peripherals, Initializes the Flash interface and the Systick. */
  HAL_Init();

  /* USER CODE BEGIN Init */

  /* USER CODE END Init */

  /* Configure the system clock */
  SystemClock_Config();

  /* USER CODE BEGIN SysInit */

  /* USER CODE END SysInit */

  /* Initialize all configured peripherals */
  MX_GPIO_Init();
  MX_DMA_Init();
  MX_USART1_UART_Init();
  MX_USART3_UART_Init();
  MX_TIM4_Init();
  /* USER CODE BEGIN 2 */

  /* USER CODE END 2 */

  /* Infinite loop */
  /* USER CODE BEGIN WHILE */
	UART_Receive_Enable(&huart1, (uint8_t *)Rx_buffer_1, MAX_BUFFER);
	UART_Receive_Enable(&huart3, (uint8_t *)Rx_buffer_2, MAX_BUFFER);
	uint32_t Local_Time = HAL_GetTick();
	DataToTx_Data.TB1 = 1;
	//HAL_Delay(5000);
	//SettingESP();
  while (1)
  {
		#if 1
		HAL_Delay(1);
		if(HAL_GetTick() - Local_Time > 500){
				//DataToTx_Data.TB1 = rand()%8;
				if(SettingOK && ErrorCode)Publish(PubTopic, DataToTx_Data.ND, DataToTx_Data.DA, DataToTx_Data.docadc, DataToTx_Data.TB1, DataToTx_Data.TB2, DataToTx_Data.C1, DataToTx_Data.C2);
				Local_Time = HAL_GetTick();
		}
		else{
				#if 1
				if(UART2_flag == 1){					
						UART2_Handle_Command();
						UART2_flag = 0;					
				}
				else if(UART1_flag == 1){
						UART1_Handle_MQTT_json(Rx_buffer_1, SubTopic);
						UART1_flag = 0;
				}
				#endif	
		}
		#endif
    /* USER CODE END WHILE */

    /* USER CODE BEGIN 3 */
  }
  /* USER CODE END 3 */
}

/**
  * @brief System Clock Configuration
  * @retval None
  */
void SystemClock_Config(void)
{
  RCC_OscInitTypeDef RCC_OscInitStruct = {0};
  RCC_ClkInitTypeDef RCC_ClkInitStruct = {0};

  /** Initializes the RCC Oscillators according to the specified parameters
  * in the RCC_OscInitTypeDef structure.
  */
  RCC_OscInitStruct.OscillatorType = RCC_OSCILLATORTYPE_HSI;
  RCC_OscInitStruct.HSIState = RCC_HSI_ON;
  RCC_OscInitStruct.HSICalibrationValue = RCC_HSICALIBRATION_DEFAULT;
  RCC_OscInitStruct.PLL.PLLState = RCC_PLL_ON;
  RCC_OscInitStruct.PLL.PLLSource = RCC_PLLSOURCE_HSI_DIV2;
  RCC_OscInitStruct.PLL.PLLMUL = RCC_PLL_MUL4;
  if (HAL_RCC_OscConfig(&RCC_OscInitStruct) != HAL_OK)
  {
    Error_Handler();
  }

  /** Initializes the CPU, AHB and APB buses clocks
  */
  RCC_ClkInitStruct.ClockType = RCC_CLOCKTYPE_HCLK|RCC_CLOCKTYPE_SYSCLK
                              |RCC_CLOCKTYPE_PCLK1|RCC_CLOCKTYPE_PCLK2;
  RCC_ClkInitStruct.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
  RCC_ClkInitStruct.AHBCLKDivider = RCC_SYSCLK_DIV1;
  RCC_ClkInitStruct.APB1CLKDivider = RCC_HCLK_DIV1;
  RCC_ClkInitStruct.APB2CLKDivider = RCC_HCLK_DIV1;

  if (HAL_RCC_ClockConfig(&RCC_ClkInitStruct, FLASH_LATENCY_0) != HAL_OK)
  {
    Error_Handler();
  }
}

/**
  * @brief TIM4 Initialization Function
  * @param None
  * @retval None
  */
static void MX_TIM4_Init(void)
{

  /* USER CODE BEGIN TIM4_Init 0 */

  /* USER CODE END TIM4_Init 0 */

  TIM_ClockConfigTypeDef sClockSourceConfig = {0};
  TIM_MasterConfigTypeDef sMasterConfig = {0};

  /* USER CODE BEGIN TIM4_Init 1 */

  /* USER CODE END TIM4_Init 1 */
  htim4.Instance = TIM4;
  htim4.Init.Prescaler = 3999;
  htim4.Init.CounterMode = TIM_COUNTERMODE_UP;
  htim4.Init.Period = 65535;
  htim4.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
  htim4.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_DISABLE;
  if (HAL_TIM_Base_Init(&htim4) != HAL_OK)
  {
    Error_Handler();
  }
  sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
  if (HAL_TIM_ConfigClockSource(&htim4, &sClockSourceConfig) != HAL_OK)
  {
    Error_Handler();
  }
  sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
  sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
  if (HAL_TIMEx_MasterConfigSynchronization(&htim4, &sMasterConfig) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN TIM4_Init 2 */

  /* USER CODE END TIM4_Init 2 */

}

/**
  * @brief USART1 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART1_UART_Init(void)
{

  /* USER CODE BEGIN USART1_Init 0 */

  /* USER CODE END USART1_Init 0 */

  /* USER CODE BEGIN USART1_Init 1 */

  /* USER CODE END USART1_Init 1 */
  huart1.Instance = USART1;
  huart1.Init.BaudRate = 115200;
  huart1.Init.WordLength = UART_WORDLENGTH_8B;
  huart1.Init.StopBits = UART_STOPBITS_1;
  huart1.Init.Parity = UART_PARITY_NONE;
  huart1.Init.Mode = UART_MODE_TX_RX;
  huart1.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart1.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart1) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART1_Init 2 */

  /* USER CODE END USART1_Init 2 */

}

/**
  * @brief USART3 Initialization Function
  * @param None
  * @retval None
  */
static void MX_USART3_UART_Init(void)
{

  /* USER CODE BEGIN USART3_Init 0 */

  /* USER CODE END USART3_Init 0 */

  /* USER CODE BEGIN USART3_Init 1 */

  /* USER CODE END USART3_Init 1 */
  huart3.Instance = USART3;
  huart3.Init.BaudRate = 115200;
  huart3.Init.WordLength = UART_WORDLENGTH_8B;
  huart3.Init.StopBits = UART_STOPBITS_1;
  huart3.Init.Parity = UART_PARITY_NONE;
  huart3.Init.Mode = UART_MODE_TX_RX;
  huart3.Init.HwFlowCtl = UART_HWCONTROL_NONE;
  huart3.Init.OverSampling = UART_OVERSAMPLING_16;
  if (HAL_UART_Init(&huart3) != HAL_OK)
  {
    Error_Handler();
  }
  /* USER CODE BEGIN USART3_Init 2 */

  /* USER CODE END USART3_Init 2 */

}

/**
  * Enable DMA controller clock
  */
static void MX_DMA_Init(void)
{

  /* DMA controller clock enable */
  __HAL_RCC_DMA1_CLK_ENABLE();

  /* DMA interrupt init */
  /* DMA1_Channel2_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(DMA1_Channel2_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(DMA1_Channel2_IRQn);
  /* DMA1_Channel3_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(DMA1_Channel3_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(DMA1_Channel3_IRQn);
  /* DMA1_Channel4_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(DMA1_Channel4_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(DMA1_Channel4_IRQn);
  /* DMA1_Channel5_IRQn interrupt configuration */
  HAL_NVIC_SetPriority(DMA1_Channel5_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(DMA1_Channel5_IRQn);

}

/**
  * @brief GPIO Initialization Function
  * @param None
  * @retval None
  */
static void MX_GPIO_Init(void)
{
  GPIO_InitTypeDef GPIO_InitStruct = {0};
  /* USER CODE BEGIN MX_GPIO_Init_1 */

  /* USER CODE END MX_GPIO_Init_1 */

  /* GPIO Ports Clock Enable */
  __HAL_RCC_GPIOA_CLK_ENABLE();
  __HAL_RCC_GPIOB_CLK_ENABLE();

  /*Configure GPIO pin Output Level */
  HAL_GPIO_WritePin(GPIOA, GPIO_PIN_2|GPIO_PIN_3|GPIO_PIN_4, GPIO_PIN_RESET);

  /*Configure GPIO pins : PA0 PA1 */
  GPIO_InitStruct.Pin = GPIO_PIN_0|GPIO_PIN_1;
  GPIO_InitStruct.Mode = GPIO_MODE_IT_RISING_FALLING;
  GPIO_InitStruct.Pull = GPIO_PULLUP;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pins : PA2 PA3 PA4 */
  GPIO_InitStruct.Pin = GPIO_PIN_2|GPIO_PIN_3|GPIO_PIN_4;
  GPIO_InitStruct.Mode = GPIO_MODE_OUTPUT_PP;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /*Configure GPIO pin : PA5 */
  GPIO_InitStruct.Pin = GPIO_PIN_5;
  GPIO_InitStruct.Mode = GPIO_MODE_INPUT;
  GPIO_InitStruct.Pull = GPIO_NOPULL;
  HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

  /* EXTI interrupt init*/
  HAL_NVIC_SetPriority(EXTI0_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(EXTI0_IRQn);

  HAL_NVIC_SetPriority(EXTI1_IRQn, 0, 0);
  HAL_NVIC_EnableIRQ(EXTI1_IRQn);

  /* USER CODE BEGIN MX_GPIO_Init_2 */

  /* USER CODE END MX_GPIO_Init_2 */
}

/* USER CODE BEGIN 4 */

/* USER CODE END 4 */

/**
  * @brief  This function is executed in case of error occurrence.
  * @retval None
  */
void Error_Handler(void)
{
  /* USER CODE BEGIN Error_Handler_Debug */
  /* User can add his own implementation to report the HAL error return state */
  __disable_irq();
  while (1)
  {
  }
  /* USER CODE END Error_Handler_Debug */
}

#ifdef  USE_FULL_ASSERT
/**
  * @brief  Reports the name of the source file and the source line number
  *         where the assert_param error has occurred.
  * @param  file: pointer to the source file name
  * @param  line: assert_param error line source number
  * @retval None
  */
void assert_failed(uint8_t *file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
  /* User can add his own implementation to report the file name and line number,
     ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */
}
#endif /* USE_FULL_ASSERT */
