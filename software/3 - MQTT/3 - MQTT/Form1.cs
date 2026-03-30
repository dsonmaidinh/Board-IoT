using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using ZedGraph;

namespace _3___MQTT
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, Action> commandActions;
        string functionCode;
        private DataGridView modbusGrid;
        bool SettingOK = true, AT_command = true;
        byte[] modbusRequest = new byte[8];
        byte RUN_REG = 4, STOP_REG = 6, TEMP_REG = 7, HUM_REG = 9;
        string last_string = null;
        string last_topic = null;
        public Form1()
        {
            InitializeComponent();
            GetAvailablePorts();

            SetDefaultVIew(false, 0);
            SetDefaultModbusValues();

            commandActions = new Dictionary<string, Action>
            {
                { "MQTT Interface", StartMQTTInterface },
                { "Modbus Interface", StartModbusInterface },
                { "Start Debug", StartStopDebug },
                { "Stop Debug", StartStopDebug },
            };

            Graph_Init();
        }
        //=== ADDITION
        void SetDefaultVIew(bool isEnabled, byte value_pgbar)
        {
            progressBar_PortConnect.Value = value_pgbar;
            // Group box
            groupbox_Modbus.Visible = isEnabled;
            groupBox_MQTT.Visible = isEnabled;
            groupBox_Pub.Visible = false;
            groupBox_Sub.Visible = false;
            // Combo box
            comboBox_Baudrate.SelectedIndex = 0;
            comboBox_QoS.SelectedIndex = 0;
            // Circular progressBar_Hum
            circularProgressBar_Hum.Value = 0;
            circularProgressBar_Temp.Value = 0;
            circularProgressBar_Hum.Text = "...";
            circularProgressBar_Temp.Text = "...";
            // Timer
            timer_RxTx.Enabled = false;
            // Pub
            checkBox_Retain.Checked = false;
            button_Pub.Enabled = false;
            // Sub
            button_AddSub.Enabled = false;
            // Button
            button_ON_OFF_Timer.Text = "Timer ON";
            // Tab page
            tabPage1.Text = "STM";
            tabPage2.Text = "ESP";
            tabPage3.Text = "Modbus MultiReg";
            tabPage4.Text = "Graph";
            tabPage1.BackColor = Color.MidnightBlue;
            tabPage2.BackColor = Color.MidnightBlue;
            tabPage2.BackColor = Color.MidnightBlue;
            tabPage3.BackColor = Color.MidnightBlue;
            // Check list
            checkedListBox_ESP.BackColor = Color.SkyBlue;
            checkedListBox_ESP.ForeColor = Color.Black;
            // Rich text box
            richTextBox_Debug.Clear();
            richTextBox_MessageSub.Clear();
        }
        private void SetDefaultModbusValues()
        {
            // Thiết lập giá trị mặc định
            Func_combo.SelectedIndex = 2; // Chọn "01 Read Coils (0x)"
            SI_box.Text = "1";
            Addr_box.Text = "0";
            Quan_box.Text = "10";
            Scan_Rate_box.Text = "500";
        }
        private void GetAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox_COM.Items.Clear();
            comboBox_COM.Items.AddRange(ports);

            if (serialPort_UART2.IsOpen)
            {
                SetDefaultVIew(true, 0);
                serialPort_UART2.Close();
                button_Open_Close_Port.Text = "Open port";
            }
        }
        private void ShowErrorAndReset(System.Windows.Forms.TextBox box, string message, string defaultValue)
        {
            System.Windows.Forms.ToolTip tooltip = new System.Windows.Forms.ToolTip();
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.IsBalloon = true;
            tooltip.Show(message, box, box.Width / 2, box.Height - 90, 3000); // hiện 3s
            box.Text = defaultValue;
            box.SelectionStart = box.Text.Length; // đưa con trỏ về cuối
        }
        private void InitModbusGrid(ushort soluong)
        {
            // Nếu đã có grid và số dòng KHÔNG đổi thì giữ nguyên
            if (modbusGrid != null && modbusGrid.RowCount == soluong)
                return;

            // Nếu có grid cũ thì xóa đi để tạo lại
            if (modbusGrid != null)
            {
                this.Controls.Remove(modbusGrid);
                modbusGrid.Dispose();
                modbusGrid = null;
            }

            // Tạo mới
            modbusGrid = new DataGridView();
            modbusGrid.Name = "modbusGrid";
            modbusGrid.Location = new Point(20, 20);
            modbusGrid.Size = new Size(210, 280); // Điều chỉnh kích thước nếu cần

            // Cấu hình bảng
            modbusGrid.Columns.Add("addrCol", "Name");
            modbusGrid.Columns[0].ReadOnly = true;

            modbusGrid.Columns.Add("valueCol", "00000"); // tên mặc định ban đầu
            modbusGrid.Columns[1].HeaderText = Addr_box.Text; // ✅ đổi tên cột theo Addr_box.Text

            for (int i = 0; i < soluong; i++)
            {
                modbusGrid.Rows.Add(i.ToString(), "0");
            }

            modbusGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            modbusGrid.AllowUserToAddRows = false;
            modbusGrid.RowHeadersVisible = false;

            // 🔁 Khi ô nào đó trong bảng thay đổi giá trị, thì gọi lại Update_Data
            modbusGrid.CellValueChanged += (s, e) => Update_Data(null, null);

            // 🛠️ Ngoài ra, để giá trị thay đổi thực sự được ghi nhận,
            // ta cần xử lý sự kiện khi ô mất focus
            modbusGrid.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (modbusGrid.IsCurrentCellDirty)
                {
                    modbusGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };

            // Thêm vào form
            tabPage3.Controls.Add(modbusGrid);
        }
        private void modbusGrid_theme()
        {
            if (modbusGrid == null) return;
            // Căn chỉnh chiều cao dòng đầu tiên để không bị che bởi header
            modbusGrid.ColumnHeadersHeight = 30;
            // Font và chữ
            modbusGrid.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            modbusGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // Màu nền và viền
            modbusGrid.BackgroundColor = Color.LightSkyBlue;
            modbusGrid.GridColor = Color.SteelBlue;

            // Màu ô
            modbusGrid.DefaultCellStyle.BackColor = Color.AliceBlue;
            modbusGrid.DefaultCellStyle.ForeColor = Color.DarkSlateBlue;
            modbusGrid.DefaultCellStyle.SelectionBackColor = Color.DeepSkyBlue;
            modbusGrid.DefaultCellStyle.SelectionForeColor = Color.White;

            // Màu header
            modbusGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.DodgerBlue;
            modbusGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            modbusGrid.EnableHeadersVisualStyles = false;  // Cho phép custom header

            // Kẻ viền mảnh
            modbusGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            modbusGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // Bo tròn góc (giả lập bằng padding & không dùng border nặng)
            modbusGrid.RowTemplate.Height = 28;
            modbusGrid.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);

            // Khác
            modbusGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
            modbusGrid.MultiSelect = false;
        }
        //=== BUTTON
        private void button_Open_Close_Port_Click(object sender, EventArgs e)
        {
            try
            {
                if (button_Open_Close_Port.Text == "Open port")
                {
                    /*--- PORT CONNECTION ---*/
                    if (comboBox_COM.Text == "" || comboBox_Baudrate.Text == "")
                    {
                        MessageBox.Show("PLease choose COM!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        serialPort_UART2.PortName = comboBox_COM.Text;
                        serialPort_UART2.BaudRate = Convert.ToInt32(comboBox_Baudrate.Text);
                        serialPort_UART2.Open();
                        /*--- COMPONENT ---*/
                        SetDefaultVIew(true, 100);
                        /*--- BUTTON ---*/
                        button_Open_Close_Port.Text = "Close port";
                        /*--- EXPAND ---*/
                        serialPort_UART2.DiscardInBuffer();
                        serialPort_UART2.ReadTimeout = 2000;
                    }
                }
                else if (button_Open_Close_Port.Text == "Close port")
                {
                    /*--- COMPONENT ---*/
                    serialPort_UART2.Close();
                    SetDefaultVIew(false, 0);
                    /*--- BUTTON ---*/
                    button_Open_Close_Port.Text = "Open port";
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Cannot connect to COM !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            GetAvailablePorts();
        }
        private void button_Multitask_Click(object sender, EventArgs e)
        {
            if (serialPort_UART2.IsOpen)
            {
                string commandKey = ((System.Windows.Forms.Button)sender).Text.Trim();

                if (commandActions.TryGetValue(commandKey, out Action action))
                {
                    action.Invoke();
                }
                else
                {
                    MessageBox.Show("Invalid command!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("COM DISCONNECTED!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void K1_ON_Click(object sender, EventArgs e)
        {
            if (functionCode == "06")
            {
                textBox_K1.BackColor = Color.Green;
                int value = Convert.ToInt32(Quan_box.Text);
                value |= 0x01;  // Bit OR với 0x01
                Quan_box.Text = value.ToString();
            }
            else if (functionCode == "16")
            {
                textBox_K1.BackColor = Color.Green;
                modbusGrid.Rows[0].Cells[1].Value = "1";
            }
        }
        private void K1_OFF_Click(object sender, EventArgs e)
        {
            if (functionCode == "06")
            {
                textBox_K1.BackColor = Color.DimGray;
                int value = Convert.ToInt32(Quan_box.Text);
                value -= 0x01;  // Bit OR với 0x01
                Quan_box.Text = value.ToString();
            }
            else if (functionCode == "16")
            {
                textBox_K1.BackColor = Color.DimGray;
                modbusGrid.Rows[0].Cells[1].Value = "0";
            }
        }
        private void K2_ON_Click(object sender, EventArgs e)
        {
            if (functionCode == "06")
            {
                textBox_K2.BackColor = Color.Yellow;
                int value = Convert.ToInt32(Quan_box.Text);
                value += 2;  // Bit OR với 0x02
                Quan_box.Text = value.ToString();
            }
            else if (functionCode == "16")
            {
                textBox_K2.BackColor = Color.Yellow;
                modbusGrid.Rows[1].Cells[1].Value = "1";
            }
        }
        private void K2_OFF_Click(object sender, EventArgs e)
        {
            if (functionCode == "06")
            {
                textBox_K2.BackColor = Color.DimGray;
                int value = Convert.ToInt32(Quan_box.Text);
                value -= 0x02;  // Bit OR với 0x01
                Quan_box.Text = value.ToString();
            }
            else if (functionCode == "16")
            {
                textBox_K2.BackColor = Color.DimGray;
                modbusGrid.Rows[1].Cells[1].Value = "0";
            }
        }
        private void K3_ON_Click(object sender, EventArgs e)
        {
            if (functionCode == "06")
            {
                textBox_K3.BackColor = Color.Red;
                int value = Convert.ToInt32(Quan_box.Text);
                value |= 0x04;  // Bit OR với 0x02
                Quan_box.Text = value.ToString();
            }
            else if (functionCode == "16")
            {
                textBox_K3.BackColor = Color.Red;
                modbusGrid.Rows[2].Cells[1].Value = "1";
            }
        }
        private void K3_OFF_Click(object sender, EventArgs e)
        {
            if (functionCode == "06")
            {
                textBox_K3.BackColor = Color.DimGray;
                int value = Convert.ToInt32(Quan_box.Text);
                value -= 0x04;  // Bit OR với 0x01
                Quan_box.Text = value.ToString();
            }
            else if (functionCode == "16")
            {
                textBox_K3.BackColor = Color.DimGray;
                modbusGrid.Rows[2].Cells[1].Value = "0";
            }
        }
        private void button_StartSettingESP_Click(object sender, EventArgs e)
        {
            if (serialPort_UART2.IsOpen) serialPort_UART2.Write("Setting ESP");
        }
        private void button_ClearDebug_Click(object sender, EventArgs e)
        {
            richTextBox_Debug.Clear();
        }
        private void button_ON_OFF_Timer_Click(object sender, EventArgs e)
        {
            if (button_ON_OFF_Timer.Text == "Timer ON")
            {
                timer_RxTx.Start();
                button_ON_OFF_Timer.Text = "Timer OFF";
            }
            else if (button_ON_OFF_Timer.Text == "Timer OFF")
            {
                timer_RxTx.Stop();
                button_ON_OFF_Timer.Text = "Timer ON";
            }
        }
        private void StartMQTTInterface()
        {
            if (!serialPort_UART2.IsOpen) return;
            serialPort_UART2.Write("MQTT");
            button_StartMQTTModbus.Text = "Modbus Interface";
            AT_command = true;
        }
        private void StartModbusInterface()
        {
            if (!serialPort_UART2.IsOpen) return;
            serialPort_UART2.Write("Modbus");
            button_StartMQTTModbus.Text = "MQTT Interface";
            AT_command = false;
        }
        private void StartStopDebug()
        {
            if (!serialPort_UART2.IsOpen) return;
            if (button_StartStopModbus.Text == "Start Debug")
            {
                serialPort_UART2.Write("Start Debug");
                button_StartStopModbus.Text = "Stop Debug";
            }
            else
            {
                serialPort_UART2.Write("Stop Debug");
                button_StartStopModbus.Text = "Start Debug";
            }
        }
        //=== TEXTBOX, COMBOBOX, CHECKBOX
        private void Scan_Rate_box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Gọi lại chính hàm TextChanged cũ
                Scan_Rate_box_TextChanged(sender, EventArgs.Empty);

                // Chặn tiếng "beep"
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void Scan_Rate_box_TextChanged(object sender, EventArgs e)
        {
            timer_RxTx.Enabled = false;
            serialPort_UART2.DiscardInBuffer();
            serialPort_UART2.DiscardOutBuffer();
            Update_Data(SI_box, EventArgs.Empty);
            timer_RxTx.Interval = Convert.ToInt32(Scan_Rate_box.Text);
            timer_RxTx.Enabled = true;
        }
        private void Update_Data(object sender, EventArgs e)
        {
            // --- SI_box ---
            if (!byte.TryParse(SI_box.Text, out byte ID))
            {
                ShowErrorAndReset(SI_box, "You can only type a number here.", "1");
                return;
            }

            // --- Function ---
            if (Func_combo.SelectedItem == null)
                return;

            string selected = Func_combo.SelectedItem.ToString();
            functionCode = selected.Split(' ')[0];
            if (!byte.TryParse(functionCode, out byte Function))
                return;

            // --- Addr_box ---
            if (!ushort.TryParse(Addr_box.Text, out ushort Address))
            {
                ShowErrorAndReset(Addr_box, "You can only type a number here.", "0");
                return;
            }

            // --- Quan_box ---
            ushort Number_Points = 0;
            if (!ushort.TryParse(Quan_box.Text, out Number_Points) || (Function == 3 && Number_Points == 0))
            {
                if (Function == 3)
                {
                    ShowErrorAndReset(Quan_box, "Quantity must be a number greater than 0.", "1");
                    Number_Points = 1;
                }
            }

            // Dùng chung cho Function 6 và 16
            ushort Number_Registers = Number_Points;
            ushort Data = Number_Points;

            // === BẮT ĐẦU XỬ LÝ THEO CHỨC NĂNG ===

            if (Function == 3)
            {
                //tabControl1.SelectedTab = tabPage1;
                S_Adrr_H.Text = "Starting Address:";
                S_Add_L.Text = "Number of Points:";

                if (modbusGrid != null)
                {
                    this.Controls.Remove(modbusGrid);
                    modbusGrid.Dispose();
                    modbusGrid = null;
                }

                modbusRequest = new byte[8];
                modbusRequest[0] = ID;
                modbusRequest[1] = Function;
                modbusRequest[2] = (byte)(Address >> 8);
                modbusRequest[3] = (byte)(Address & 0xFF);
                modbusRequest[4] = (byte)(Number_Points >> 8);
                modbusRequest[5] = (byte)(Number_Points & 0xFF);
                ushort crc = ComputeCRC(modbusRequest, 6);
                modbusRequest[6] = (byte)(crc & 0xFF);
                modbusRequest[7] = (byte)((crc >> 8) & 0xFF);
            }
            else if (Function == 6)
            {
                //tabControl1.SelectedTab = tabPage1;
                S_Adrr_H.Text = "Reg Address:";
                S_Add_L.Text = "Preset Data:";

                modbusRequest = new byte[8];
                modbusRequest[0] = ID;
                modbusRequest[1] = Function;
                modbusRequest[2] = (byte)(Address >> 8);
                modbusRequest[3] = (byte)(Address & 0xFF);
                modbusRequest[4] = (byte)(Data >> 8);
                modbusRequest[5] = (byte)(Data & 0xFF);
                ushort crc = ComputeCRC(modbusRequest, 6);
                modbusRequest[6] = (byte)(crc & 0xFF);
                modbusRequest[7] = (byte)((crc >> 8) & 0xFF);
            }
            else if (Function == 16)
            {
                //tabControl1.SelectedTab = tabPage3;
                S_Adrr_H.Text = "Starting Address:";
                S_Add_L.Text = "Number of Registers:";
                InitModbusGrid(Number_Registers);
                modbusGrid_theme();
                tabPage3.Controls.Add(modbusGrid);

                int byteCount = Number_Registers * 2;
                modbusRequest = new byte[7 + byteCount + 2];

                modbusRequest[0] = ID;
                modbusRequest[1] = Function;
                modbusRequest[2] = (byte)((Address >> 8) & 0xFF);
                modbusRequest[3] = (byte)(Address & 0xFF);
                modbusRequest[4] = (byte)((Number_Registers >> 8) & 0xFF);
                modbusRequest[5] = (byte)(Number_Registers & 0xFF);
                modbusRequest[6] = (byte)byteCount;

                byte[] Multiple_Data = new byte[byteCount];

                for (int i = 0; i < Number_Registers; i++)
                {
                    ushort value = 0;
                    ushort.TryParse(modbusGrid.Rows[i].Cells[1].Value?.ToString(), out value);
                    Multiple_Data[i * 2] = (byte)(value >> 8);
                    Multiple_Data[i * 2 + 1] = (byte)(value & 0xFF);
                }

                Array.Copy(Multiple_Data, 0, modbusRequest, 7, byteCount);
                ushort crc = ComputeCRC(modbusRequest, 7 + byteCount);
                modbusRequest[7 + byteCount] = (byte)(crc & 0xFF);
                modbusRequest[8 + byteCount] = (byte)((crc >> 8) & 0xFF);
            }

            // Cập nhật chuỗi gửi
            Tx_box.Text = BytesToHexString(modbusRequest);
        }
        string BytesToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data)
                sb.AppendFormat("{0:X2} ", b);
            return sb.ToString().Trim();
        }
        void AppendColoredText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
        void CheckItemByName(string name, bool check)
        {
            for (int i = 0; i < checkedListBox_ESP.Items.Count; i++)
            {
                if (checkedListBox_ESP.Items[i].ToString().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    checkedListBox_ESP.SetItemChecked(i, check);
                    break;
                }
            }
            UpdateAddSubButtonState(); // Cập nhật lại trạng thái nút
        }
        private void UpdateAddSubButtonState()
        {
            bool isWifiChecked = false;
            bool isBrokerChecked = false;

            for (int i = 0; i < checkedListBox_ESP.Items.Count; i++)
            {
                string item = checkedListBox_ESP.Items[i].ToString().ToUpper();

                if (item == "WIFI CONNECT")
                    isWifiChecked = checkedListBox_ESP.GetItemChecked(i);
                else if (item == "BROKER CONNECT")
                    isBrokerChecked = checkedListBox_ESP.GetItemChecked(i);
            }

            // Nếu chưa check đủ cả 2 thì disable nút AddSub
            button_AddSub.Enabled = isWifiChecked && isBrokerChecked;
            button_Pub.Enabled = isWifiChecked && isBrokerChecked;
            SettingOK = true;
        }
        //=== CRC
        public static ushort ComputeCRC(byte[] data, int length)
        {
            ushort crc = 0xFFFF;

            for (int pos = 0; pos < length; pos++)
            {
                crc ^= data[pos];

                for (int i = 0; i < 8; i++)
                {
                    bool lsb = (crc & 0x0001) != 0;
                    crc >>= 1;
                    if (lsb)
                        crc ^= 0xA001;
                }
            }

            return crc;
        }
        bool CheckCRC(byte[] buffer)
        {
            if (buffer == null || buffer.Length < 3)
                return false; // Không đủ dữ liệu để có CRC

            // 1. CRC nhận được (2 byte cuối: Low + High)
            ushort crc_rx = (ushort)(buffer[buffer.Length - 2] | (buffer[buffer.Length - 1] << 8));

            // 2. CRC tính lại từ data nhận được (bỏ 2 byte CRC)
            ushort crc_calc = ComputeCRC(buffer, buffer.Length - 2);

            // 3. So sánh
            return crc_rx == crc_calc;
        }
        //=== TIMER
        private void timer_RxTx_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort_UART2.IsOpen || serialPort_UART2.BytesToRead <= 0)
                {
                    Update_Data(null, null);
                    if (SettingOK == true && AT_command == false) serialPort_UART2.Write(modbusRequest, 0, modbusRequest.Length);
                    return;
                }
                try
                {
                    if (AT_command)
                    {
                        byte[] buffer = new byte[serialPort_UART2.BytesToRead];
                        serialPort_UART2.Read(buffer, 0, buffer.Length);
                        string received = Encoding.ASCII.GetString(buffer);
                        string[] lines = received.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                        foreach (string line in lines)
                        {
                            if (string.IsNullOrWhiteSpace(line)) continue;

                            if (line.StartsWith("Send AT Command"))
                            {
                                if (line.Contains("AT+MQTTPUB") && line.Contains("TEMP") || line.Contains("AT+MQTTPUB") && line.Contains("HUM"))
                                {
                                    HandleMqttPubCommand(line);
                                }
                                else AppendColoredText(richTextBox_Debug, line + "\r\n", Color.Blue);
                                last_string = line;
                            }
                            else if (line.StartsWith("Received response"))
                            {
                                HandleExpectedResponse(line);
                            }
                            else if (line.Contains("WIFI CONNECTED"))
                            {
                                AppendColoredText(richTextBox_Debug, "[Wifi] WiFi connected\r\n", Color.Teal);
                                CheckItemByName("Wifi Connect", true);
                            }
                            else if (line.Contains("WIFI DISCONNECT"))
                            {
                                AppendColoredText(richTextBox_Debug, "[Wifi] No WiFi connected.\r\n", Color.OrangeRed);
                                CheckItemByName("Wifi Connect", false);
                            }
                            else if (line.Contains("+MQTTDISCONNECTED"))
                            {
                                AppendColoredText(richTextBox_Debug, "[Broker] Not connected to broker.\r\n", Color.OrangeRed);
                                CheckItemByName("Broker Connect", false);
                            }
                            else if (line.Contains("+MQTTSUBRECV:"))
                            {
                                HandleIncomingMqttMessage(line);
                            }
                            else
                            {
                                AppendColoredText(richTextBox_Debug, line + "\r\n", Color.Black);
                            }
                        }

                        richTextBox_Debug.ScrollToCaret();
                    }
                    else
                    {
                        byte[] buffer = new byte[serialPort_UART2.BytesToRead]; // tao mot mang buffer co kich thuoc la so luong byte nhan
                        serialPort_UART2.Read(buffer, 0, buffer.Length);        // nhan du lieu va luu vao mang buffer
                        Rx_String_box.Text = BytesToHexString(buffer);
                        // Check CRC
                        if (CheckCRC(buffer))
                        {
                            Notify_box.Text = "CRC OK!!!";
                            Notify_box.ForeColor = Color.White;
                            Notify_box.BackColor = Color.Green;
                            if (functionCode == "03")
                            {
                                RUN_LAMP.BackColor = (buffer[RUN_REG] == 0x01) ? Color.Green : Color.White;
                                STOP_LAMP.BackColor = (buffer[STOP_REG] == 0x01) ? Color.Red : Color.White;
                                ushort hum = (ushort)(buffer[HUM_REG] << 8 | buffer[HUM_REG + 1]);
                                circularProgressBar_Hum.Value = hum;
                                circularProgressBar_Hum.Text = hum.ToString() + " %RH";

                                ushort temp = (ushort)(buffer[TEMP_REG] << 8 | buffer[TEMP_REG + 1]);
                                circularProgressBar_Temp.Value = (ushort)temp;
                                circularProgressBar_Temp.Text = temp.ToString("0.00") + " °C";
                            
                                Draw_graph(temp, hum);
                            }
                            else if (functionCode == "06")
                            {

                            }
                        }
                        else
                        {
                            Notify_box.Text = "CRC ERROR!!!";
                            Notify_box.ForeColor = Color.White;
                            Notify_box.BackColor = Color.Red;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Notify_box.Text = ex.ToString();
                    Notify_box.ForeColor = Color.White;
                    Notify_box.BackColor = Color.Red;
                }
            }
            catch (TimeoutException ex)
            {
                // Nếu quá timeout, hiển thị vào TextBox chứ không đơ app
                Notify_box.ForeColor = Color.White;
                Notify_box.BackColor = Color.Red;
                Notify_box.Text = ex.ToString();
                timer_RxTx.Enabled = false;
            }
        }
        //=== MQTT
        private void HandleExpectedResponse(string line)
        {
            string content = line.Substring("Received response:".Length).Trim();

            if (content.StartsWith("+")) // Trả về do gửi lệnh kiểm tra setting
            {
                if (content.Contains("+CWJAP:"))
                {
                    string ssid = ExtractStringBetweenQuotes(content);
                    if (!string.IsNullOrEmpty(ssid))
                    {
                        AppendColoredText(richTextBox_Debug, $"[Wifi] WiFi connected to: {ssid}\r\n", Color.Teal);
                        CheckItemByName("Wifi Connect", true);
                    }
                }
                else if (content.Contains("+MQTTCONN:"))
                {
                    string broker = ExtractStringBetweenQuotes(content);
                    bool connected = !string.IsNullOrEmpty(broker);
                    AppendColoredText(richTextBox_Debug, connected ? "[Broker] Broker connected.\r\n" : "[Broker] Not connected to broker.\r\n",
                                      connected ? Color.Teal : Color.OrangeRed);
                    CheckItemByName("Broker Connect", connected);
                }
                else if (content.Contains("+MQTTSUB:"))
                {
                    string topic = ExtractStringBetweenQuotes(content);
                    bool subscribed = !string.IsNullOrWhiteSpace(topic);

                    AppendColoredText(richTextBox_Debug,
                        subscribed ? $"[Sub] Subscribed to topic: {topic}\r\n" : "[Sub] No topic subscribed.\r\n",
                        subscribed ? Color.Teal : Color.OrangeRed);

                    if (subscribed && last_topic != topic)
                    {
                        AppendColoredText(richTextBox_SubTopic, topic + "\n", Color.Red);
                        last_topic = topic;
                    }
                    CheckItemByName("Sub", subscribed);
                }
            }
            else // Trả về sau lệnh set (ví dụ AT+CWJAP="ssid","pass")
            {
                if (string.IsNullOrWhiteSpace(content))
                {
                    AppendColoredText(richTextBox_Debug, "[Wifi] No WiFi connected.\r\n", Color.OrangeRed);
                    CheckItemByName("Wifi Connect", false);
                }
                else if (content.Contains("WIFI CONNECTED"))
                {
                    CheckItemByName("Wifi Connect", true);
                }
                else if (content.Contains("MQTTCONNECTED"))
                {
                    CheckItemByName("Broker Connect", true);
                }
                else if (last_string.Contains("AT+MQTTSUB"))
                {
                    CheckItemByName("Sub", true);
                    if (last_topic != content)
                    {
                        AppendColoredText(richTextBox_SubTopic, content + "\n", Color.Red);
                        last_topic = content;
                    }
                }
            }

            AppendColoredText(richTextBox_Debug, line + "\r\n", Color.Green);
            richTextBox_Debug.AppendText("\r\n");
        }
        private string ExtractStringBetweenQuotes(string input)
        {
            int firstQuote = input.IndexOf('"');
            int secondQuote = input.IndexOf('"', firstQuote + 1);
            return (firstQuote != -1 && secondQuote != -1 && secondQuote > firstQuote + 1)
                ? input.Substring(firstQuote + 1, secondQuote - firstQuote - 1)
                : string.Empty;
        }
        private void HandleIncomingMqttMessage(string line)
        {
            AppendColoredText(richTextBox_MessageSub, line + "\r\n", Color.Black);
            richTextBox_MessageSub.ScrollToCaret();

            try
            {
                if (line.Contains("\"son_Rx\""))
                {
                    int jsonStart = line.IndexOf('{');
                    if (jsonStart != -1)
                    {
                        string json = line.Substring(jsonStart);

                        if (json.Contains("\"L1\"") && json.Contains("\"ON\"")) textBox_K1.BackColor = Color.Green;
                        else if (json.Contains("\"L1\"") && json.Contains("\"OFF\"")) textBox_K1.BackColor = Color.DimGray;
                        else if (json.Contains("\"L2\"") && json.Contains("\"ON\"")) textBox_K2.BackColor = Color.Yellow;
                        else if (json.Contains("\"L2\"") && json.Contains("\"OFF\"")) textBox_K2.BackColor = Color.DimGray;
                        else if (json.Contains("\"L3\"") && json.Contains("\"ON\"")) textBox_K3.BackColor = Color.Red;
                        else if (json.Contains("\"L3\"") && json.Contains("\"OFF\"")) textBox_K3.BackColor = Color.DimGray;
                    }
                }
            }
            catch (Exception ex)
            {
                AppendColoredText(richTextBox_Debug, "[Error parsing MQTT]: " + ex.Message + "\r\n", Color.OrangeRed);
            }
        }
        private void HandleMqttPubCommand(string line)
        {
            try
            {
                // Tìm vị trí đầu và cuối của chuỗi JSON trong dấu nháy kép
                int firstQuoteIndex = line.IndexOf("\",\"") + 3; // sau "son_Tx",
                int lastQuoteIndex = line.LastIndexOf("\",0,0");

                if (firstQuoteIndex == -1 || lastQuoteIndex == -1 || lastQuoteIndex <= firstQuoteIndex)
                    return;

                string escapedJson = line.Substring(firstQuoteIndex, lastQuoteIndex - firstQuoteIndex);

                // Giải mã chuỗi JSON bị escape (ví dụ: \"TEMP\":\"20\" → "TEMP":"20")
                string json = System.Text.RegularExpressions.Regex.Unescape(escapedJson);

                // Parse JSON
                JObject jsonObj = JObject.Parse(json);

                string tempStr = jsonObj["TEMP"]?.ToString();
                string humStr = jsonObj["HUM"]?.ToString();

                if (int.TryParse(tempStr, out int temp))
                {
                    circularProgressBar_Temp.Value = temp;
                    circularProgressBar_Temp.Text = temp + "°C";
                }

                if (int.TryParse(humStr, out int hum))
                {
                    circularProgressBar_Hum.Value = hum;
                    circularProgressBar_Hum.Text = hum + "%";
                }

                AppendColoredText(richTextBox_Debug, $"[Sensor] TEMP={tempStr}°C, HUM={humStr}%\r\n", Color.DarkCyan);
            }
            catch (Exception ex)
            {
                AppendColoredText(richTextBox_Debug, "[Error parsing AT+MQTTPUB JSON]: " + ex.Message + "\r\n", Color.OrangeRed);
            }

        }
        //=== GRAPH
        GraphPane myPane;
        RollingPointPairList tempList = new RollingPointPairList(10000);
        RollingPointPairList humList = new RollingPointPairList(10000);
        private void Graph_Init() 
        {
            myPane = zedGraphControl1.GraphPane;
            myPane.Title.Text = "Temperature and Humidity";
            myPane.XAxis.Title.Text = "Time";
            myPane.YAxis.Title.Text = "Value";

            LineItem tempCurve = myPane.AddCurve("Temperature", tempList, Color.Red, SymbolType.None);
            LineItem humCurve = myPane.AddCurve("Humidity", humList, Color.Blue, SymbolType.None);
            
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 100; // Giới hạn trục X từ 0 đến 100
            myPane.XAxis.Scale.MinorStep = 1;  // Bước chính là 10
            myPane.XAxis.Scale.MajorStep = 5; // Bước chính là 10

            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 100; // Giới hạn trục X từ 0 đến 100
            myPane.YAxis.Scale.MinorStep = 1;  // Bước chính là 10
            myPane.YAxis.Scale.MajorStep = 5;
        
            zedGraphControl1.AxisChange();
        }
        int tong = 0; // Biến toàn cục để đếm số lần vẽ đồ thị
        public void Draw_graph(double tempLine, double humLine) 
        {
            if (tempList.Count > 10000) tempList.RemoveAt(0); // Giới hạn số điểm trong danh sách
            if (humList.Count > 10000) humList.RemoveAt(0); // Giới hạn số điểm trong danh sách
            double x = tempList.Count; // Sử dụng số lượng điểm hiện tại làm trục X
            tempList.Add(x, tempLine);
            humList.Add(x, humLine);
            myPane.XAxis.Scale.Max = x + 10; // Mở rộng trục X để hiển thị thêm điểm mới
            myPane.XAxis.Scale.Min = x - 90; // Giữ lại 100 điểm gần nhất
            
            LineItem tempCurve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            LineItem humCurve  = zedGraphControl1.GraphPane.CurveList[1] as LineItem;

            if(tempCurve == null || humCurve == null) return;

            IPointListEdit tempPoints = tempCurve.Points as IPointListEdit;
            IPointListEdit humPoints  = humCurve.Points as IPointListEdit;

            if (tempPoints == null || humPoints == null) return;

            tempPoints.Add(tong, tempLine);
            humPoints.Add(tong, humLine);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate(); // Cập nhật đồ thị
            tong+=2; // Tăng biến đếm mỗi lần vẽ đồ thị
        }    
    }
}
