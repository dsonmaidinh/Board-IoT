namespace _3___MQTT
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel_footer = new System.Windows.Forms.Panel();
            this.groupBox_Sub = new System.Windows.Forms.GroupBox();
            this.richTextBox_MessageSub = new System.Windows.Forms.RichTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.richTextBox_SubTopic = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button_AddSub = new System.Windows.Forms.Button();
            this.groupBox_Pub = new System.Windows.Forms.GroupBox();
            this.checkBox_Retain = new System.Windows.Forms.CheckBox();
            this.comboBox_QoS = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button_Pub = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox_MessagePub = new System.Windows.Forms.TextBox();
            this.textBox_Topic = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox_MQTT = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.circularProgressBar_Temp = new CircularProgressBar.CircularProgressBar();
            this.label_Hum = new System.Windows.Forms.Label();
            this.circularProgressBar_Hum = new CircularProgressBar.CircularProgressBar();
            this.label_Temp = new System.Windows.Forms.Label();
            this.K2_ON = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_graph = new System.Windows.Forms.Button();
            this.K3_ON = new System.Windows.Forms.Button();
            this.K3_OFF = new System.Windows.Forms.Button();
            this.K2_OFF = new System.Windows.Forms.Button();
            this.K1_OFF = new System.Windows.Forms.Button();
            this.K1_ON = new System.Windows.Forms.Button();
            this.textBox_K1 = new System.Windows.Forms.TextBox();
            this.textBox_K3 = new System.Windows.Forms.TextBox();
            this.textBox_K2 = new System.Windows.Forms.TextBox();
            this.RUN_LAMP = new System.Windows.Forms.TextBox();
            this.STOP_LAMP = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkedListBox_ESP = new System.Windows.Forms.CheckedListBox();
            this.richTextBox_Debug = new System.Windows.Forms.RichTextBox();
            this.button_CheckSettingESP = new System.Windows.Forms.Button();
            this.button_StartSettingESP = new System.Windows.Forms.Button();
            this.button_ClearDebug = new System.Windows.Forms.Button();
            this.button_ON_OFF_Timer = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupbox_Modbus = new System.Windows.Forms.GroupBox();
            this.button_StartStopModbus = new System.Windows.Forms.Button();
            this.button_StartMQTTModbus = new System.Windows.Forms.Button();
            this.Notify_box = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Func_combo = new System.Windows.Forms.ComboBox();
            this.Tx_box = new System.Windows.Forms.TextBox();
            this.Scan_Rate_box = new System.Windows.Forms.TextBox();
            this.Rx_String_box = new System.Windows.Forms.TextBox();
            this.Num_H = new System.Windows.Forms.Label();
            this.Quan_box = new System.Windows.Forms.TextBox();
            this.S_Add_L = new System.Windows.Forms.Label();
            this.Addr_box = new System.Windows.Forms.TextBox();
            this.S_Adrr_H = new System.Windows.Forms.Label();
            this.Func = new System.Windows.Forms.Label();
            this.SI_box = new System.Windows.Forms.TextBox();
            this.slave_address = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.progressBar_PortConnect = new System.Windows.Forms.ProgressBar();
            this.comboBox_Baudrate = new System.Windows.Forms.ComboBox();
            this.comboBox_COM = new System.Windows.Forms.ComboBox();
            this.button_Open_Close_Port = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.timer_RxTx = new System.Windows.Forms.Timer(this.components);
            this.serialPort_UART2 = new System.IO.Ports.SerialPort(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.panel_footer.SuspendLayout();
            this.groupBox_Sub.SuspendLayout();
            this.groupBox_Pub.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_MQTT.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupbox_Modbus.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_footer
            // 
            this.panel_footer.BackColor = System.Drawing.Color.SteelBlue;
            this.panel_footer.Controls.Add(this.groupBox_Sub);
            this.panel_footer.Controls.Add(this.groupBox_Pub);
            this.panel_footer.Location = new System.Drawing.Point(-1, 613);
            this.panel_footer.Margin = new System.Windows.Forms.Padding(2);
            this.panel_footer.Name = "panel_footer";
            this.panel_footer.Size = new System.Drawing.Size(1032, 248);
            this.panel_footer.TabIndex = 12;
            // 
            // groupBox_Sub
            // 
            this.groupBox_Sub.Controls.Add(this.richTextBox_MessageSub);
            this.groupBox_Sub.Controls.Add(this.label16);
            this.groupBox_Sub.Controls.Add(this.richTextBox_SubTopic);
            this.groupBox_Sub.Controls.Add(this.label17);
            this.groupBox_Sub.Controls.Add(this.button_AddSub);
            this.groupBox_Sub.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Sub.ForeColor = System.Drawing.Color.Azure;
            this.groupBox_Sub.Location = new System.Drawing.Point(529, 20);
            this.groupBox_Sub.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Sub.Name = "groupBox_Sub";
            this.groupBox_Sub.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Sub.Size = new System.Drawing.Size(480, 208);
            this.groupBox_Sub.TabIndex = 9;
            this.groupBox_Sub.TabStop = false;
            this.groupBox_Sub.Text = "Subcription";
            // 
            // richTextBox_MessageSub
            // 
            this.richTextBox_MessageSub.Location = new System.Drawing.Point(14, 51);
            this.richTextBox_MessageSub.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_MessageSub.Name = "richTextBox_MessageSub";
            this.richTextBox_MessageSub.ReadOnly = true;
            this.richTextBox_MessageSub.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox_MessageSub.Size = new System.Drawing.Size(288, 142);
            this.richTextBox_MessageSub.TabIndex = 9;
            this.richTextBox_MessageSub.Text = "";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Azure;
            this.label16.Location = new System.Drawing.Point(316, 24);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 17);
            this.label16.TabIndex = 6;
            this.label16.Text = "Subcriptions";
            // 
            // richTextBox_SubTopic
            // 
            this.richTextBox_SubTopic.Location = new System.Drawing.Point(319, 135);
            this.richTextBox_SubTopic.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_SubTopic.Name = "richTextBox_SubTopic";
            this.richTextBox_SubTopic.ReadOnly = true;
            this.richTextBox_SubTopic.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox_SubTopic.Size = new System.Drawing.Size(139, 58);
            this.richTextBox_SubTopic.TabIndex = 8;
            this.richTextBox_SubTopic.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Azure;
            this.label17.Location = new System.Drawing.Point(10, 24);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(80, 17);
            this.label17.TabIndex = 6;
            this.label17.Text = "Messages";
            // 
            // button_AddSub
            // 
            this.button_AddSub.BackColor = System.Drawing.Color.SkyBlue;
            this.button_AddSub.Enabled = false;
            this.button_AddSub.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_AddSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddSub.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_AddSub.Location = new System.Drawing.Point(319, 51);
            this.button_AddSub.Margin = new System.Windows.Forms.Padding(2);
            this.button_AddSub.Name = "button_AddSub";
            this.button_AddSub.Size = new System.Drawing.Size(138, 59);
            this.button_AddSub.TabIndex = 2;
            this.button_AddSub.Text = "Add Subscription";
            this.button_AddSub.UseVisualStyleBackColor = false;
            // 
            // groupBox_Pub
            // 
            this.groupBox_Pub.Controls.Add(this.checkBox_Retain);
            this.groupBox_Pub.Controls.Add(this.comboBox_QoS);
            this.groupBox_Pub.Controls.Add(this.label18);
            this.groupBox_Pub.Controls.Add(this.label19);
            this.groupBox_Pub.Controls.Add(this.button_Pub);
            this.groupBox_Pub.Controls.Add(this.label20);
            this.groupBox_Pub.Controls.Add(this.label21);
            this.groupBox_Pub.Controls.Add(this.textBox_MessagePub);
            this.groupBox_Pub.Controls.Add(this.textBox_Topic);
            this.groupBox_Pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_Pub.ForeColor = System.Drawing.Color.Azure;
            this.groupBox_Pub.Location = new System.Drawing.Point(2, 20);
            this.groupBox_Pub.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_Pub.Name = "groupBox_Pub";
            this.groupBox_Pub.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_Pub.Size = new System.Drawing.Size(455, 208);
            this.groupBox_Pub.TabIndex = 9;
            this.groupBox_Pub.TabStop = false;
            this.groupBox_Pub.Text = "Publish";
            // 
            // checkBox_Retain
            // 
            this.checkBox_Retain.AutoSize = true;
            this.checkBox_Retain.BackColor = System.Drawing.Color.SteelBlue;
            this.checkBox_Retain.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_Retain.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Retain.Location = new System.Drawing.Point(409, 63);
            this.checkBox_Retain.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_Retain.Name = "checkBox_Retain";
            this.checkBox_Retain.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Retain.TabIndex = 8;
            this.checkBox_Retain.UseVisualStyleBackColor = false;
            // 
            // comboBox_QoS
            // 
            this.comboBox_QoS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_QoS.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_QoS.FormattingEnabled = true;
            this.comboBox_QoS.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.comboBox_QoS.Location = new System.Drawing.Point(320, 51);
            this.comboBox_QoS.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_QoS.Name = "comboBox_QoS";
            this.comboBox_QoS.Size = new System.Drawing.Size(48, 37);
            this.comboBox_QoS.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Azure;
            this.label18.Location = new System.Drawing.Point(388, 24);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 17);
            this.label18.TabIndex = 6;
            this.label18.Text = "Retain";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Azure;
            this.label19.Location = new System.Drawing.Point(323, 24);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 17);
            this.label19.TabIndex = 6;
            this.label19.Text = "QoS";
            // 
            // button_Pub
            // 
            this.button_Pub.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Pub.Enabled = false;
            this.button_Pub.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_Pub.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Pub.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Pub.Location = new System.Drawing.Point(320, 137);
            this.button_Pub.Margin = new System.Windows.Forms.Padding(2);
            this.button_Pub.Name = "button_Pub";
            this.button_Pub.Size = new System.Drawing.Size(121, 36);
            this.button_Pub.TabIndex = 2;
            this.button_Pub.Text = "Publish";
            this.button_Pub.UseVisualStyleBackColor = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Azure;
            this.label20.Location = new System.Drawing.Point(12, 104);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 17);
            this.label20.TabIndex = 6;
            this.label20.Text = "Message";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Azure;
            this.label21.Location = new System.Drawing.Point(7, 24);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 17);
            this.label21.TabIndex = 6;
            this.label21.Text = "Topic";
            // 
            // textBox_MessagePub
            // 
            this.textBox_MessagePub.Location = new System.Drawing.Point(13, 137);
            this.textBox_MessagePub.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_MessagePub.Multiline = true;
            this.textBox_MessagePub.Name = "textBox_MessagePub";
            this.textBox_MessagePub.Size = new System.Drawing.Size(285, 36);
            this.textBox_MessagePub.TabIndex = 7;
            // 
            // textBox_Topic
            // 
            this.textBox_Topic.Location = new System.Drawing.Point(13, 51);
            this.textBox_Topic.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_Topic.Multiline = true;
            this.textBox_Topic.Name = "textBox_Topic";
            this.textBox_Topic.Size = new System.Drawing.Size(285, 36);
            this.textBox_Topic.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.groupBox_MQTT);
            this.panel1.Controls.Add(this.groupbox_Modbus);
            this.panel1.Location = new System.Drawing.Point(-1, 132);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 480);
            this.panel1.TabIndex = 11;
            // 
            // groupBox_MQTT
            // 
            this.groupBox_MQTT.Controls.Add(this.tabControl1);
            this.groupBox_MQTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_MQTT.ForeColor = System.Drawing.Color.Azure;
            this.groupBox_MQTT.Location = new System.Drawing.Point(601, 20);
            this.groupBox_MQTT.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox_MQTT.Name = "groupBox_MQTT";
            this.groupBox_MQTT.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox_MQTT.Size = new System.Drawing.Size(423, 441);
            this.groupBox_MQTT.TabIndex = 7;
            this.groupBox_MQTT.TabStop = false;
            this.groupBox_MQTT.Text = "MQTT";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(423, 413);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(415, 382);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel3.Controls.Add(this.circularProgressBar_Temp);
            this.panel3.Controls.Add(this.label_Hum);
            this.panel3.Controls.Add(this.circularProgressBar_Hum);
            this.panel3.Controls.Add(this.label_Temp);
            this.panel3.Controls.Add(this.K2_ON);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.button_graph);
            this.panel3.Controls.Add(this.K3_ON);
            this.panel3.Controls.Add(this.K3_OFF);
            this.panel3.Controls.Add(this.K2_OFF);
            this.panel3.Controls.Add(this.K1_OFF);
            this.panel3.Controls.Add(this.K1_ON);
            this.panel3.Controls.Add(this.textBox_K1);
            this.panel3.Controls.Add(this.textBox_K3);
            this.panel3.Controls.Add(this.textBox_K2);
            this.panel3.Controls.Add(this.RUN_LAMP);
            this.panel3.Controls.Add(this.STOP_LAMP);
            this.panel3.Location = new System.Drawing.Point(1, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(419, 384);
            this.panel3.TabIndex = 0;
            // 
            // circularProgressBar_Temp
            // 
            this.circularProgressBar_Temp.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar_Temp.AnimationSpeed = 500;
            this.circularProgressBar_Temp.BackColor = System.Drawing.Color.MidnightBlue;
            this.circularProgressBar_Temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar_Temp.ForeColor = System.Drawing.Color.Azure;
            this.circularProgressBar_Temp.InnerColor = System.Drawing.Color.MidnightBlue;
            this.circularProgressBar_Temp.InnerMargin = 2;
            this.circularProgressBar_Temp.InnerWidth = -1;
            this.circularProgressBar_Temp.Location = new System.Drawing.Point(21, 54);
            this.circularProgressBar_Temp.Margin = new System.Windows.Forms.Padding(2);
            this.circularProgressBar_Temp.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar_Temp.Name = "circularProgressBar_Temp";
            this.circularProgressBar_Temp.OuterColor = System.Drawing.SystemColors.ButtonHighlight;
            this.circularProgressBar_Temp.OuterMargin = -25;
            this.circularProgressBar_Temp.OuterWidth = 26;
            this.circularProgressBar_Temp.ProgressColor = System.Drawing.Color.Red;
            this.circularProgressBar_Temp.ProgressWidth = 10;
            this.circularProgressBar_Temp.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar_Temp.Size = new System.Drawing.Size(127, 134);
            this.circularProgressBar_Temp.StartAngle = 270;
            this.circularProgressBar_Temp.SubscriptColor = System.Drawing.Color.MidnightBlue;
            this.circularProgressBar_Temp.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar_Temp.SubscriptText = "";
            this.circularProgressBar_Temp.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.circularProgressBar_Temp.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar_Temp.SuperscriptText = "";
            this.circularProgressBar_Temp.TabIndex = 27;
            this.circularProgressBar_Temp.Text = "...";
            this.circularProgressBar_Temp.TextMargin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.circularProgressBar_Temp.Value = 50;
            // 
            // label_Hum
            // 
            this.label_Hum.AutoSize = true;
            this.label_Hum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Hum.ForeColor = System.Drawing.Color.Azure;
            this.label_Hum.Location = new System.Drawing.Point(188, 20);
            this.label_Hum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Hum.Name = "label_Hum";
            this.label_Hum.Size = new System.Drawing.Size(87, 22);
            this.label_Hum.TabIndex = 25;
            this.label_Hum.Text = "Humidity";
            // 
            // circularProgressBar_Hum
            // 
            this.circularProgressBar_Hum.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar_Hum.AnimationSpeed = 500;
            this.circularProgressBar_Hum.BackColor = System.Drawing.Color.MidnightBlue;
            this.circularProgressBar_Hum.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.circularProgressBar_Hum.ForeColor = System.Drawing.Color.Azure;
            this.circularProgressBar_Hum.InnerColor = System.Drawing.Color.MidnightBlue;
            this.circularProgressBar_Hum.InnerMargin = 2;
            this.circularProgressBar_Hum.InnerWidth = -1;
            this.circularProgressBar_Hum.Location = new System.Drawing.Point(164, 54);
            this.circularProgressBar_Hum.Margin = new System.Windows.Forms.Padding(2);
            this.circularProgressBar_Hum.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar_Hum.Name = "circularProgressBar_Hum";
            this.circularProgressBar_Hum.OuterColor = System.Drawing.SystemColors.ButtonHighlight;
            this.circularProgressBar_Hum.OuterMargin = -25;
            this.circularProgressBar_Hum.OuterWidth = 26;
            this.circularProgressBar_Hum.ProgressColor = System.Drawing.Color.RoyalBlue;
            this.circularProgressBar_Hum.ProgressWidth = 10;
            this.circularProgressBar_Hum.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar_Hum.Size = new System.Drawing.Size(127, 134);
            this.circularProgressBar_Hum.StartAngle = 270;
            this.circularProgressBar_Hum.SubscriptColor = System.Drawing.Color.MidnightBlue;
            this.circularProgressBar_Hum.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar_Hum.SubscriptText = "";
            this.circularProgressBar_Hum.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.circularProgressBar_Hum.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar_Hum.SuperscriptText = "";
            this.circularProgressBar_Hum.TabIndex = 24;
            this.circularProgressBar_Hum.Text = "...";
            this.circularProgressBar_Hum.TextMargin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.circularProgressBar_Hum.Value = 50;
            // 
            // label_Temp
            // 
            this.label_Temp.AutoSize = true;
            this.label_Temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Temp.ForeColor = System.Drawing.Color.Azure;
            this.label_Temp.Location = new System.Drawing.Point(17, 20);
            this.label_Temp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Temp.Name = "label_Temp";
            this.label_Temp.Size = new System.Drawing.Size(124, 22);
            this.label_Temp.TabIndex = 26;
            this.label_Temp.Text = "Temperature";
            // 
            // K2_ON
            // 
            this.K2_ON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.K2_ON.ForeColor = System.Drawing.Color.MidnightBlue;
            this.K2_ON.Location = new System.Drawing.Point(120, 280);
            this.K2_ON.Margin = new System.Windows.Forms.Padding(2);
            this.K2_ON.Name = "K2_ON";
            this.K2_ON.Size = new System.Drawing.Size(73, 42);
            this.K2_ON.TabIndex = 22;
            this.K2_ON.Text = "K2_ON";
            this.K2_ON.UseVisualStyleBackColor = true;
            this.K2_ON.Click += new System.EventHandler(this.K2_ON_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Azure;
            this.label10.Location = new System.Drawing.Point(239, 215);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 22);
            this.label10.TabIndex = 17;
            this.label10.Text = "K3";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Azure;
            this.label9.Location = new System.Drawing.Point(136, 215);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 22);
            this.label9.TabIndex = 18;
            this.label9.Text = "K2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Azure;
            this.label2.Location = new System.Drawing.Point(300, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "Stop";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Azure;
            this.label8.Location = new System.Drawing.Point(39, 215);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 22);
            this.label8.TabIndex = 20;
            this.label8.Text = "K1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Azure;
            this.label1.Location = new System.Drawing.Point(300, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 22);
            this.label1.TabIndex = 21;
            this.label1.Text = "Run";
            // 
            // button_graph
            // 
            this.button_graph.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_graph.ForeColor = System.Drawing.Color.MidnightBlue;
            this.button_graph.Location = new System.Drawing.Point(313, 280);
            this.button_graph.Margin = new System.Windows.Forms.Padding(2);
            this.button_graph.Name = "button_graph";
            this.button_graph.Size = new System.Drawing.Size(73, 42);
            this.button_graph.TabIndex = 7;
            this.button_graph.Text = "GRAPH";
            this.button_graph.UseVisualStyleBackColor = true;
            this.button_graph.Click += new System.EventHandler(this.K3_ON_Click);
            // 
            // K3_ON
            // 
            this.K3_ON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.K3_ON.ForeColor = System.Drawing.Color.MidnightBlue;
            this.K3_ON.Location = new System.Drawing.Point(222, 280);
            this.K3_ON.Margin = new System.Windows.Forms.Padding(2);
            this.K3_ON.Name = "K3_ON";
            this.K3_ON.Size = new System.Drawing.Size(73, 42);
            this.K3_ON.TabIndex = 7;
            this.K3_ON.Text = "K3_ON";
            this.K3_ON.UseVisualStyleBackColor = true;
            this.K3_ON.Click += new System.EventHandler(this.K3_ON_Click);
            // 
            // K3_OFF
            // 
            this.K3_OFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.K3_OFF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.K3_OFF.Location = new System.Drawing.Point(222, 329);
            this.K3_OFF.Margin = new System.Windows.Forms.Padding(2);
            this.K3_OFF.Name = "K3_OFF";
            this.K3_OFF.Size = new System.Drawing.Size(73, 42);
            this.K3_OFF.TabIndex = 8;
            this.K3_OFF.Text = "K3_OFF";
            this.K3_OFF.UseVisualStyleBackColor = true;
            this.K3_OFF.Click += new System.EventHandler(this.K3_OFF_Click);
            // 
            // K2_OFF
            // 
            this.K2_OFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.K2_OFF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.K2_OFF.Location = new System.Drawing.Point(120, 329);
            this.K2_OFF.Margin = new System.Windows.Forms.Padding(2);
            this.K2_OFF.Name = "K2_OFF";
            this.K2_OFF.Size = new System.Drawing.Size(73, 42);
            this.K2_OFF.TabIndex = 9;
            this.K2_OFF.Text = "K2_OFF";
            this.K2_OFF.UseVisualStyleBackColor = true;
            this.K2_OFF.Click += new System.EventHandler(this.K2_OFF_Click);
            // 
            // K1_OFF
            // 
            this.K1_OFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.K1_OFF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.K1_OFF.Location = new System.Drawing.Point(22, 329);
            this.K1_OFF.Margin = new System.Windows.Forms.Padding(2);
            this.K1_OFF.Name = "K1_OFF";
            this.K1_OFF.Size = new System.Drawing.Size(73, 42);
            this.K1_OFF.TabIndex = 10;
            this.K1_OFF.Text = "K1_OFF";
            this.K1_OFF.UseVisualStyleBackColor = true;
            this.K1_OFF.Click += new System.EventHandler(this.K1_OFF_Click);
            // 
            // K1_ON
            // 
            this.K1_ON.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.K1_ON.ForeColor = System.Drawing.Color.MidnightBlue;
            this.K1_ON.Location = new System.Drawing.Point(22, 280);
            this.K1_ON.Margin = new System.Windows.Forms.Padding(2);
            this.K1_ON.Name = "K1_ON";
            this.K1_ON.Size = new System.Drawing.Size(73, 42);
            this.K1_ON.TabIndex = 11;
            this.K1_ON.Text = "K1_ON";
            this.K1_ON.UseVisualStyleBackColor = true;
            this.K1_ON.Click += new System.EventHandler(this.K1_ON_Click);
            // 
            // textBox_K1
            // 
            this.textBox_K1.BackColor = System.Drawing.Color.DimGray;
            this.textBox_K1.Location = new System.Drawing.Point(32, 247);
            this.textBox_K1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_K1.Multiline = true;
            this.textBox_K1.Name = "textBox_K1";
            this.textBox_K1.Size = new System.Drawing.Size(49, 29);
            this.textBox_K1.TabIndex = 12;
            // 
            // textBox_K3
            // 
            this.textBox_K3.BackColor = System.Drawing.Color.DimGray;
            this.textBox_K3.Location = new System.Drawing.Point(233, 246);
            this.textBox_K3.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_K3.Multiline = true;
            this.textBox_K3.Name = "textBox_K3";
            this.textBox_K3.Size = new System.Drawing.Size(50, 29);
            this.textBox_K3.TabIndex = 13;
            // 
            // textBox_K2
            // 
            this.textBox_K2.BackColor = System.Drawing.Color.DimGray;
            this.textBox_K2.Location = new System.Drawing.Point(128, 246);
            this.textBox_K2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_K2.Multiline = true;
            this.textBox_K2.Name = "textBox_K2";
            this.textBox_K2.Size = new System.Drawing.Size(50, 29);
            this.textBox_K2.TabIndex = 14;
            // 
            // RUN_LAMP
            // 
            this.RUN_LAMP.Location = new System.Drawing.Point(356, 25);
            this.RUN_LAMP.Margin = new System.Windows.Forms.Padding(2);
            this.RUN_LAMP.Multiline = true;
            this.RUN_LAMP.Name = "RUN_LAMP";
            this.RUN_LAMP.Size = new System.Drawing.Size(49, 29);
            this.RUN_LAMP.TabIndex = 15;
            // 
            // STOP_LAMP
            // 
            this.STOP_LAMP.Location = new System.Drawing.Point(356, 68);
            this.STOP_LAMP.Margin = new System.Windows.Forms.Padding(2);
            this.STOP_LAMP.Multiline = true;
            this.STOP_LAMP.Name = "STOP_LAMP";
            this.STOP_LAMP.Size = new System.Drawing.Size(50, 29);
            this.STOP_LAMP.TabIndex = 16;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.MidnightBlue;
            this.tabPage2.Controls.Add(this.checkedListBox_ESP);
            this.tabPage2.Controls.Add(this.richTextBox_Debug);
            this.tabPage2.Controls.Add(this.button_CheckSettingESP);
            this.tabPage2.Controls.Add(this.button_StartSettingESP);
            this.tabPage2.Controls.Add(this.button_ClearDebug);
            this.tabPage2.Controls.Add(this.button_ON_OFF_Timer);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(415, 382);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // checkedListBox_ESP
            // 
            this.checkedListBox_ESP.ForeColor = System.Drawing.Color.MidnightBlue;
            this.checkedListBox_ESP.FormattingEnabled = true;
            this.checkedListBox_ESP.Items.AddRange(new object[] {
            "Wifi Connect",
            "Broker Connect",
            "Sub"});
            this.checkedListBox_ESP.Location = new System.Drawing.Point(4, 230);
            this.checkedListBox_ESP.Margin = new System.Windows.Forms.Padding(2);
            this.checkedListBox_ESP.Name = "checkedListBox_ESP";
            this.checkedListBox_ESP.Size = new System.Drawing.Size(144, 80);
            this.checkedListBox_ESP.TabIndex = 10;
            // 
            // richTextBox_Debug
            // 
            this.richTextBox_Debug.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_Debug.Margin = new System.Windows.Forms.Padding(2);
            this.richTextBox_Debug.Name = "richTextBox_Debug";
            this.richTextBox_Debug.ReadOnly = true;
            this.richTextBox_Debug.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.richTextBox_Debug.Size = new System.Drawing.Size(420, 193);
            this.richTextBox_Debug.TabIndex = 9;
            this.richTextBox_Debug.Text = "";
            // 
            // button_CheckSettingESP
            // 
            this.button_CheckSettingESP.BackColor = System.Drawing.Color.SkyBlue;
            this.button_CheckSettingESP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_CheckSettingESP.ForeColor = System.Drawing.Color.Black;
            this.button_CheckSettingESP.Location = new System.Drawing.Point(151, 292);
            this.button_CheckSettingESP.Margin = new System.Windows.Forms.Padding(2);
            this.button_CheckSettingESP.Name = "button_CheckSettingESP";
            this.button_CheckSettingESP.Size = new System.Drawing.Size(121, 58);
            this.button_CheckSettingESP.TabIndex = 3;
            this.button_CheckSettingESP.Text = "Check Setting ESP";
            this.button_CheckSettingESP.UseVisualStyleBackColor = false;
            // 
            // button_StartSettingESP
            // 
            this.button_StartSettingESP.BackColor = System.Drawing.Color.SkyBlue;
            this.button_StartSettingESP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartSettingESP.ForeColor = System.Drawing.Color.Black;
            this.button_StartSettingESP.Location = new System.Drawing.Point(151, 230);
            this.button_StartSettingESP.Margin = new System.Windows.Forms.Padding(2);
            this.button_StartSettingESP.Name = "button_StartSettingESP";
            this.button_StartSettingESP.Size = new System.Drawing.Size(121, 58);
            this.button_StartSettingESP.TabIndex = 4;
            this.button_StartSettingESP.Text = "Start Setting ESP";
            this.button_StartSettingESP.UseVisualStyleBackColor = false;
            this.button_StartSettingESP.Click += new System.EventHandler(this.button_StartSettingESP_Click);
            // 
            // button_ClearDebug
            // 
            this.button_ClearDebug.BackColor = System.Drawing.Color.SkyBlue;
            this.button_ClearDebug.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_ClearDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ClearDebug.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_ClearDebug.Location = new System.Drawing.Point(284, 230);
            this.button_ClearDebug.Margin = new System.Windows.Forms.Padding(2);
            this.button_ClearDebug.Name = "button_ClearDebug";
            this.button_ClearDebug.Size = new System.Drawing.Size(121, 58);
            this.button_ClearDebug.TabIndex = 5;
            this.button_ClearDebug.Text = "Clear debug";
            this.button_ClearDebug.UseVisualStyleBackColor = false;
            this.button_ClearDebug.Click += new System.EventHandler(this.button_ClearDebug_Click);
            // 
            // button_ON_OFF_Timer
            // 
            this.button_ON_OFF_Timer.BackColor = System.Drawing.Color.SkyBlue;
            this.button_ON_OFF_Timer.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_ON_OFF_Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ON_OFF_Timer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_ON_OFF_Timer.Location = new System.Drawing.Point(284, 292);
            this.button_ON_OFF_Timer.Margin = new System.Windows.Forms.Padding(2);
            this.button_ON_OFF_Timer.Name = "button_ON_OFF_Timer";
            this.button_ON_OFF_Timer.Size = new System.Drawing.Size(121, 58);
            this.button_ON_OFF_Timer.TabIndex = 6;
            this.button_ON_OFF_Timer.Text = "Timer ON";
            this.button_ON_OFF_Timer.UseVisualStyleBackColor = false;
            this.button_ON_OFF_Timer.Click += new System.EventHandler(this.button_ON_OFF_Timer_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel4);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(415, 382);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.ForeColor = System.Drawing.Color.Azure;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(419, 382);
            this.panel4.TabIndex = 8;
            // 
            // groupbox_Modbus
            // 
            this.groupbox_Modbus.BackColor = System.Drawing.Color.MidnightBlue;
            this.groupbox_Modbus.Controls.Add(this.button_StartStopModbus);
            this.groupbox_Modbus.Controls.Add(this.button_StartMQTTModbus);
            this.groupbox_Modbus.Controls.Add(this.Notify_box);
            this.groupbox_Modbus.Controls.Add(this.label5);
            this.groupbox_Modbus.Controls.Add(this.label22);
            this.groupbox_Modbus.Controls.Add(this.label11);
            this.groupbox_Modbus.Controls.Add(this.Func_combo);
            this.groupbox_Modbus.Controls.Add(this.Tx_box);
            this.groupbox_Modbus.Controls.Add(this.Scan_Rate_box);
            this.groupbox_Modbus.Controls.Add(this.Rx_String_box);
            this.groupbox_Modbus.Controls.Add(this.Num_H);
            this.groupbox_Modbus.Controls.Add(this.Quan_box);
            this.groupbox_Modbus.Controls.Add(this.S_Add_L);
            this.groupbox_Modbus.Controls.Add(this.Addr_box);
            this.groupbox_Modbus.Controls.Add(this.S_Adrr_H);
            this.groupbox_Modbus.Controls.Add(this.Func);
            this.groupbox_Modbus.Controls.Add(this.SI_box);
            this.groupbox_Modbus.Controls.Add(this.slave_address);
            this.groupbox_Modbus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupbox_Modbus.ForeColor = System.Drawing.Color.Azure;
            this.groupbox_Modbus.Location = new System.Drawing.Point(15, 20);
            this.groupbox_Modbus.Margin = new System.Windows.Forms.Padding(2);
            this.groupbox_Modbus.Name = "groupbox_Modbus";
            this.groupbox_Modbus.Padding = new System.Windows.Forms.Padding(2);
            this.groupbox_Modbus.Size = new System.Drawing.Size(539, 441);
            this.groupbox_Modbus.TabIndex = 6;
            this.groupbox_Modbus.TabStop = false;
            this.groupbox_Modbus.Text = "Modbus";
            // 
            // button_StartStopModbus
            // 
            this.button_StartStopModbus.BackColor = System.Drawing.Color.SkyBlue;
            this.button_StartStopModbus.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_StartStopModbus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartStopModbus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_StartStopModbus.Location = new System.Drawing.Point(379, 375);
            this.button_StartStopModbus.Margin = new System.Windows.Forms.Padding(2);
            this.button_StartStopModbus.Name = "button_StartStopModbus";
            this.button_StartStopModbus.Size = new System.Drawing.Size(143, 58);
            this.button_StartStopModbus.TabIndex = 9;
            this.button_StartStopModbus.Text = "Start Debug";
            this.button_StartStopModbus.UseVisualStyleBackColor = false;
            this.button_StartStopModbus.Click += new System.EventHandler(this.button_Multitask_Click);
            // 
            // button_StartMQTTModbus
            // 
            this.button_StartMQTTModbus.BackColor = System.Drawing.Color.SkyBlue;
            this.button_StartMQTTModbus.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_StartMQTTModbus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_StartMQTTModbus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_StartMQTTModbus.Location = new System.Drawing.Point(231, 375);
            this.button_StartMQTTModbus.Margin = new System.Windows.Forms.Padding(2);
            this.button_StartMQTTModbus.Name = "button_StartMQTTModbus";
            this.button_StartMQTTModbus.Size = new System.Drawing.Size(143, 58);
            this.button_StartMQTTModbus.TabIndex = 10;
            this.button_StartMQTTModbus.Text = "Modbus Interface";
            this.button_StartMQTTModbus.UseVisualStyleBackColor = false;
            this.button_StartMQTTModbus.Click += new System.EventHandler(this.button_Multitask_Click);
            // 
            // Notify_box
            // 
            this.Notify_box.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Notify_box.Location = new System.Drawing.Point(88, 359);
            this.Notify_box.Margin = new System.Windows.Forms.Padding(2);
            this.Notify_box.Multiline = true;
            this.Notify_box.Name = "Notify_box";
            this.Notify_box.Size = new System.Drawing.Size(129, 42);
            this.Notify_box.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 369);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "Debug:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(2, 320);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(82, 22);
            this.label22.TabIndex = 3;
            this.label22.Text = "RxData:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(2, 269);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 22);
            this.label11.TabIndex = 3;
            this.label11.Text = "TxData:";
            // 
            // Func_combo
            // 
            this.Func_combo.FormattingEnabled = true;
            this.Func_combo.Items.AddRange(new object[] {
            "01 Read Coils (Ox)",
            "02 Read Discrete Inputs (lx)",
            "03 Read Holding Registers (4x)",
            "04 Read Input Registers (3x)",
            "05 Write Single Coil",
            "06 Write Single Register",
            "15 Write Multi le Coils",
            "16 Write Multiple Reqisters"});
            this.Func_combo.Location = new System.Drawing.Point(196, 74);
            this.Func_combo.Margin = new System.Windows.Forms.Padding(2);
            this.Func_combo.Name = "Func_combo";
            this.Func_combo.Size = new System.Drawing.Size(264, 33);
            this.Func_combo.TabIndex = 2;
            this.Func_combo.SelectionChangeCommitted += new System.EventHandler(this.Update_Data);
            // 
            // Tx_box
            // 
            this.Tx_box.Location = new System.Drawing.Point(88, 259);
            this.Tx_box.Margin = new System.Windows.Forms.Padding(2);
            this.Tx_box.Multiline = true;
            this.Tx_box.Name = "Tx_box";
            this.Tx_box.ReadOnly = true;
            this.Tx_box.Size = new System.Drawing.Size(429, 44);
            this.Tx_box.TabIndex = 1;
            // 
            // Scan_Rate_box
            // 
            this.Scan_Rate_box.Location = new System.Drawing.Point(196, 202);
            this.Scan_Rate_box.Margin = new System.Windows.Forms.Padding(2);
            this.Scan_Rate_box.Multiline = true;
            this.Scan_Rate_box.Name = "Scan_Rate_box";
            this.Scan_Rate_box.Size = new System.Drawing.Size(132, 29);
            this.Scan_Rate_box.TabIndex = 1;
            this.Scan_Rate_box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Scan_Rate_box_KeyDown);
            // 
            // Rx_String_box
            // 
            this.Rx_String_box.Location = new System.Drawing.Point(88, 310);
            this.Rx_String_box.Margin = new System.Windows.Forms.Padding(2);
            this.Rx_String_box.Multiline = true;
            this.Rx_String_box.Name = "Rx_String_box";
            this.Rx_String_box.ReadOnly = true;
            this.Rx_String_box.Size = new System.Drawing.Size(429, 41);
            this.Rx_String_box.TabIndex = 1;
            // 
            // Num_H
            // 
            this.Num_H.AutoSize = true;
            this.Num_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Num_H.Location = new System.Drawing.Point(4, 206);
            this.Num_H.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Num_H.Name = "Num_H";
            this.Num_H.Size = new System.Drawing.Size(109, 22);
            this.Num_H.TabIndex = 0;
            this.Num_H.Text = "Scan Rate:";
            // 
            // Quan_box
            // 
            this.Quan_box.Location = new System.Drawing.Point(196, 159);
            this.Quan_box.Margin = new System.Windows.Forms.Padding(2);
            this.Quan_box.Multiline = true;
            this.Quan_box.Name = "Quan_box";
            this.Quan_box.Size = new System.Drawing.Size(132, 29);
            this.Quan_box.TabIndex = 1;
            this.Quan_box.TextChanged += new System.EventHandler(this.Update_Data);
            // 
            // S_Add_L
            // 
            this.S_Add_L.AutoSize = true;
            this.S_Add_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S_Add_L.Location = new System.Drawing.Point(4, 164);
            this.S_Add_L.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S_Add_L.Name = "S_Add_L";
            this.S_Add_L.Size = new System.Drawing.Size(91, 22);
            this.S_Add_L.TabIndex = 0;
            this.S_Add_L.Text = "Quantity:";
            // 
            // Addr_box
            // 
            this.Addr_box.Location = new System.Drawing.Point(196, 117);
            this.Addr_box.Margin = new System.Windows.Forms.Padding(2);
            this.Addr_box.Multiline = true;
            this.Addr_box.Name = "Addr_box";
            this.Addr_box.Size = new System.Drawing.Size(132, 29);
            this.Addr_box.TabIndex = 1;
            this.Addr_box.TextChanged += new System.EventHandler(this.Update_Data);
            // 
            // S_Adrr_H
            // 
            this.S_Adrr_H.AutoSize = true;
            this.S_Adrr_H.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S_Adrr_H.Location = new System.Drawing.Point(4, 122);
            this.S_Adrr_H.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.S_Adrr_H.Name = "S_Adrr_H";
            this.S_Adrr_H.Size = new System.Drawing.Size(89, 22);
            this.S_Adrr_H.TabIndex = 0;
            this.S_Adrr_H.Text = "Address:";
            // 
            // Func
            // 
            this.Func.AutoSize = true;
            this.Func.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Func.Location = new System.Drawing.Point(4, 79);
            this.Func.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Func.Name = "Func";
            this.Func.Size = new System.Drawing.Size(93, 22);
            this.Func.TabIndex = 0;
            this.Func.Text = "Function:";
            // 
            // SI_box
            // 
            this.SI_box.Location = new System.Drawing.Point(196, 39);
            this.SI_box.Margin = new System.Windows.Forms.Padding(2);
            this.SI_box.Multiline = true;
            this.SI_box.Name = "SI_box";
            this.SI_box.Size = new System.Drawing.Size(132, 29);
            this.SI_box.TabIndex = 1;
            this.SI_box.TextChanged += new System.EventHandler(this.Update_Data);
            // 
            // slave_address
            // 
            this.slave_address.AutoSize = true;
            this.slave_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slave_address.Location = new System.Drawing.Point(4, 44);
            this.slave_address.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.slave_address.Name = "slave_address";
            this.slave_address.Size = new System.Drawing.Size(91, 22);
            this.slave_address.TabIndex = 0;
            this.slave_address.Text = "Slave ID:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.button_Refresh);
            this.panel2.Controls.Add(this.progressBar_PortConnect);
            this.panel2.Controls.Add(this.comboBox_Baudrate);
            this.panel2.Controls.Add(this.comboBox_COM);
            this.panel2.Controls.Add(this.button_Open_Close_Port);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1032, 132);
            this.panel2.TabIndex = 10;
            // 
            // button_Refresh
            // 
            this.button_Refresh.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Refresh.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Refresh.Location = new System.Drawing.Point(577, 10);
            this.button_Refresh.Margin = new System.Windows.Forms.Padding(2);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(100, 42);
            this.button_Refresh.TabIndex = 18;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = false;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // progressBar_PortConnect
            // 
            this.progressBar_PortConnect.Location = new System.Drawing.Point(463, 92);
            this.progressBar_PortConnect.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar_PortConnect.Name = "progressBar_PortConnect";
            this.progressBar_PortConnect.Size = new System.Drawing.Size(214, 28);
            this.progressBar_PortConnect.TabIndex = 17;
            // 
            // comboBox_Baudrate
            // 
            this.comboBox_Baudrate.FormattingEnabled = true;
            this.comboBox_Baudrate.Items.AddRange(new object[] {
            "115200"});
            this.comboBox_Baudrate.Location = new System.Drawing.Point(330, 60);
            this.comboBox_Baudrate.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_Baudrate.Name = "comboBox_Baudrate";
            this.comboBox_Baudrate.Size = new System.Drawing.Size(92, 21);
            this.comboBox_Baudrate.TabIndex = 16;
            // 
            // comboBox_COM
            // 
            this.comboBox_COM.FormattingEnabled = true;
            this.comboBox_COM.Location = new System.Drawing.Point(219, 60);
            this.comboBox_COM.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_COM.Name = "comboBox_COM";
            this.comboBox_COM.Size = new System.Drawing.Size(92, 21);
            this.comboBox_COM.TabIndex = 15;
            // 
            // button_Open_Close_Port
            // 
            this.button_Open_Close_Port.BackColor = System.Drawing.Color.SkyBlue;
            this.button_Open_Close_Port.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button_Open_Close_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Open_Close_Port.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Open_Close_Port.Location = new System.Drawing.Point(463, 10);
            this.button_Open_Close_Port.Margin = new System.Windows.Forms.Padding(2);
            this.button_Open_Close_Port.Name = "button_Open_Close_Port";
            this.button_Open_Close_Port.Size = new System.Drawing.Size(100, 42);
            this.button_Open_Close_Port.TabIndex = 14;
            this.button_Open_Close_Port.Text = "Open port";
            this.button_Open_Close_Port.UseVisualStyleBackColor = false;
            this.button_Open_Close_Port.Click += new System.EventHandler(this.button_Open_Close_Port_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Azure;
            this.label4.Location = new System.Drawing.Point(772, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 69);
            this.label4.TabIndex = 13;
            this.label4.Text = "IoT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Azure;
            this.label3.Location = new System.Drawing.Point(466, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Azure;
            this.label12.Location = new System.Drawing.Point(333, 29);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 22);
            this.label12.TabIndex = 11;
            this.label12.Text = "Baudrate";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Azure;
            this.label15.Location = new System.Drawing.Point(216, 29);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 22);
            this.label15.TabIndex = 10;
            this.label15.Text = "COM ports";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.ErrorImage")));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 132);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // timer_RxTx
            // 
            this.timer_RxTx.Tick += new System.EventHandler(this.timer_RxTx_Tick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.zedGraphControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(415, 382);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 0);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(415, 382);
            this.zedGraphControl1.TabIndex = 1;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 860);
            this.Controls.Add(this.panel_footer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_footer.ResumeLayout(false);
            this.groupBox_Sub.ResumeLayout(false);
            this.groupBox_Sub.PerformLayout();
            this.groupBox_Pub.ResumeLayout(false);
            this.groupBox_Pub.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox_MQTT.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupbox_Modbus.ResumeLayout(false);
            this.groupbox_Modbus.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_footer;
        private System.Windows.Forms.GroupBox groupBox_Sub;
        private System.Windows.Forms.RichTextBox richTextBox_MessageSub;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox richTextBox_SubTopic;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button_AddSub;
        private System.Windows.Forms.GroupBox groupBox_Pub;
        internal System.Windows.Forms.CheckBox checkBox_Retain;
        private System.Windows.Forms.ComboBox comboBox_QoS;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button_Pub;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox_MessagePub;
        private System.Windows.Forms.TextBox textBox_Topic;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox_MQTT;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private CircularProgressBar.CircularProgressBar circularProgressBar_Temp;
        private System.Windows.Forms.Label label_Hum;
        private CircularProgressBar.CircularProgressBar circularProgressBar_Hum;
        private System.Windows.Forms.Label label_Temp;
        private System.Windows.Forms.Button K2_ON;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button K3_ON;
        private System.Windows.Forms.Button K3_OFF;
        private System.Windows.Forms.Button K2_OFF;
        private System.Windows.Forms.Button K1_OFF;
        private System.Windows.Forms.Button K1_ON;
        private System.Windows.Forms.TextBox textBox_K1;
        private System.Windows.Forms.TextBox textBox_K3;
        private System.Windows.Forms.TextBox textBox_K2;
        private System.Windows.Forms.TextBox RUN_LAMP;
        private System.Windows.Forms.TextBox STOP_LAMP;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox checkedListBox_ESP;
        private System.Windows.Forms.RichTextBox richTextBox_Debug;
        private System.Windows.Forms.Button button_CheckSettingESP;
        private System.Windows.Forms.Button button_StartSettingESP;
        private System.Windows.Forms.Button button_ClearDebug;
        private System.Windows.Forms.Button button_ON_OFF_Timer;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupbox_Modbus;
        private System.Windows.Forms.Button button_StartStopModbus;
        private System.Windows.Forms.Button button_StartMQTTModbus;
        private System.Windows.Forms.TextBox Notify_box;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox Func_combo;
        private System.Windows.Forms.TextBox Tx_box;
        private System.Windows.Forms.TextBox Scan_Rate_box;
        private System.Windows.Forms.TextBox Rx_String_box;
        private System.Windows.Forms.Label Num_H;
        private System.Windows.Forms.TextBox Quan_box;
        private System.Windows.Forms.Label S_Add_L;
        private System.Windows.Forms.TextBox Addr_box;
        private System.Windows.Forms.Label S_Adrr_H;
        private System.Windows.Forms.Label Func;
        private System.Windows.Forms.TextBox SI_box;
        private System.Windows.Forms.Label slave_address;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.ProgressBar progressBar_PortConnect;
        private System.Windows.Forms.ComboBox comboBox_Baudrate;
        private System.Windows.Forms.ComboBox comboBox_COM;
        private System.Windows.Forms.Button button_Open_Close_Port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer_RxTx;
        private System.IO.Ports.SerialPort serialPort_UART2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button_graph;
        private System.Windows.Forms.TabPage tabPage4;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}

