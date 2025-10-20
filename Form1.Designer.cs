namespace GeniSerialTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxSerialSettings = new System.Windows.Forms.GroupBox();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.comboBoxStopBits = new System.Windows.Forms.ComboBox();
            this.comboBoxDataBits = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxPortName = new System.Windows.Forms.ComboBox();
            this.labelParity = new System.Windows.Forms.Label();
            this.labelStopBits = new System.Windows.Forms.Label();
            this.labelDataBits = new System.Windows.Forms.Label();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.labelPortName = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.groupBoxCommunication = new System.Windows.Forms.GroupBox();
            this.textBoxReceived = new System.Windows.Forms.TextBox();
            this.textBoxSent = new System.Windows.Forms.TextBox();
            this.labelReceived = new System.Windows.Forms.Label();
            this.labelSent = new System.Windows.Forms.Label();
            this.buttonClearReceived = new System.Windows.Forms.Button();
            this.buttonClearSent = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBoxSerialSettings.SuspendLayout();
            this.groupBoxCommunication.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSerialSettings
            // 
            this.groupBoxSerialSettings.Controls.Add(this.comboBoxParity);
            this.groupBoxSerialSettings.Controls.Add(this.comboBoxStopBits);
            this.groupBoxSerialSettings.Controls.Add(this.comboBoxDataBits);
            this.groupBoxSerialSettings.Controls.Add(this.comboBoxBaudRate);
            this.groupBoxSerialSettings.Controls.Add(this.comboBoxPortName);
            this.groupBoxSerialSettings.Controls.Add(this.labelParity);
            this.groupBoxSerialSettings.Controls.Add(this.labelStopBits);
            this.groupBoxSerialSettings.Controls.Add(this.labelDataBits);
            this.groupBoxSerialSettings.Controls.Add(this.labelBaudRate);
            this.groupBoxSerialSettings.Controls.Add(this.labelPortName);
            this.groupBoxSerialSettings.Controls.Add(this.buttonConnect);
            this.groupBoxSerialSettings.Controls.Add(this.buttonDisconnect);
            this.groupBoxSerialSettings.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSerialSettings.Name = "groupBoxSerialSettings";
            this.groupBoxSerialSettings.Size = new System.Drawing.Size(776, 120);
            this.groupBoxSerialSettings.TabIndex = 0;
            this.groupBoxSerialSettings.TabStop = false;
            this.groupBoxSerialSettings.Text = "시리얼 포트 설정";
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.comboBoxParity.Location = new System.Drawing.Point(470, 45);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(80, 23);
            this.comboBoxParity.TabIndex = 12;
            // 
            // comboBoxStopBits
            // 
            this.comboBoxStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBits.FormattingEnabled = true;
            this.comboBoxStopBits.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.comboBoxStopBits.Location = new System.Drawing.Point(360, 45);
            this.comboBoxStopBits.Name = "comboBoxStopBits";
            this.comboBoxStopBits.Size = new System.Drawing.Size(90, 23);
            this.comboBoxStopBits.TabIndex = 11;
            // 
            // comboBoxDataBits
            // 
            this.comboBoxDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBits.FormattingEnabled = true;
            this.comboBoxDataBits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.comboBoxDataBits.Location = new System.Drawing.Point(280, 45);
            this.comboBoxDataBits.Name = "comboBoxDataBits";
            this.comboBoxDataBits.Size = new System.Drawing.Size(60, 23);
            this.comboBoxDataBits.TabIndex = 10;
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(160, 45);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(100, 23);
            this.comboBoxBaudRate.TabIndex = 9;
            // 
            // comboBoxPortName
            // 
            this.comboBoxPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPortName.FormattingEnabled = true;
            this.comboBoxPortName.Location = new System.Drawing.Point(20, 45);
            this.comboBoxPortName.Name = "comboBoxPortName";
            this.comboBoxPortName.Size = new System.Drawing.Size(120, 23);
            this.comboBoxPortName.TabIndex = 8;
            // 
            // labelParity
            // 
            this.labelParity.AutoSize = true;
            this.labelParity.Location = new System.Drawing.Point(470, 25);
            this.labelParity.Name = "labelParity";
            this.labelParity.Size = new System.Drawing.Size(43, 15);
            this.labelParity.TabIndex = 7;
            this.labelParity.Text = "패리티";
            // 
            // labelStopBits
            // 
            this.labelStopBits.AutoSize = true;
            this.labelStopBits.Location = new System.Drawing.Point(360, 25);
            this.labelStopBits.Name = "labelStopBits";
            this.labelStopBits.Size = new System.Drawing.Size(55, 15);
            this.labelStopBits.TabIndex = 6;
            this.labelStopBits.Text = "정지비트";
            // 
            // labelDataBits
            // 
            this.labelDataBits.AutoSize = true;
            this.labelDataBits.Location = new System.Drawing.Point(280, 25);
            this.labelDataBits.Name = "labelDataBits";
            this.labelDataBits.Size = new System.Drawing.Size(67, 15);
            this.labelDataBits.TabIndex = 5;
            this.labelDataBits.Text = "데이터비트";
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(160, 25);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(55, 15);
            this.labelBaudRate.TabIndex = 4;
            this.labelBaudRate.Text = "통신속도";
            // 
            // labelPortName
            // 
            this.labelPortName.AutoSize = true;
            this.labelPortName.Location = new System.Drawing.Point(20, 25);
            this.labelPortName.Name = "labelPortName";
            this.labelPortName.Size = new System.Drawing.Size(55, 15);
            this.labelPortName.TabIndex = 3;
            this.labelPortName.Text = "포트이름";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(580, 35);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(80, 40);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "연결";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(680, 35);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(80, 40);
            this.buttonDisconnect.TabIndex = 2;
            this.buttonDisconnect.Text = "연결해제";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // groupBoxCommunication
            // 
            this.groupBoxCommunication.Controls.Add(this.textBoxReceived);
            this.groupBoxCommunication.Controls.Add(this.textBoxSent);
            this.groupBoxCommunication.Controls.Add(this.labelReceived);
            this.groupBoxCommunication.Controls.Add(this.labelSent);
            this.groupBoxCommunication.Controls.Add(this.buttonClearReceived);
            this.groupBoxCommunication.Controls.Add(this.buttonClearSent);
            this.groupBoxCommunication.Location = new System.Drawing.Point(12, 150);
            this.groupBoxCommunication.Name = "groupBoxCommunication";
            this.groupBoxCommunication.Size = new System.Drawing.Size(776, 250);
            this.groupBoxCommunication.TabIndex = 1;
            this.groupBoxCommunication.TabStop = false;
            this.groupBoxCommunication.Text = "통신 로그";
            // 
            // textBoxReceived
            // 
            this.textBoxReceived.Location = new System.Drawing.Point(20, 45);
            this.textBoxReceived.Multiline = true;
            this.textBoxReceived.Name = "textBoxReceived";
            this.textBoxReceived.ReadOnly = true;
            this.textBoxReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReceived.Size = new System.Drawing.Size(350, 170);
            this.textBoxReceived.TabIndex = 0;
            // 
            // textBoxSent
            // 
            this.textBoxSent.Location = new System.Drawing.Point(400, 45);
            this.textBoxSent.Multiline = true;
            this.textBoxSent.Name = "textBoxSent";
            this.textBoxSent.ReadOnly = true;
            this.textBoxSent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSent.Size = new System.Drawing.Size(350, 170);
            this.textBoxSent.TabIndex = 1;
            // 
            // labelReceived
            // 
            this.labelReceived.AutoSize = true;
            this.labelReceived.Location = new System.Drawing.Point(20, 25);
            this.labelReceived.Name = "labelReceived";
            this.labelReceived.Size = new System.Drawing.Size(55, 15);
            this.labelReceived.TabIndex = 2;
            this.labelReceived.Text = "수신데이터";
            // 
            // labelSent
            // 
            this.labelSent.AutoSize = true;
            this.labelSent.Location = new System.Drawing.Point(400, 25);
            this.labelSent.Name = "labelSent";
            this.labelSent.Size = new System.Drawing.Size(55, 15);
            this.labelSent.TabIndex = 3;
            this.labelSent.Text = "송신데이터";
            // 
            // buttonClearReceived
            // 
            this.buttonClearReceived.Location = new System.Drawing.Point(290, 221);
            this.buttonClearReceived.Name = "buttonClearReceived";
            this.buttonClearReceived.Size = new System.Drawing.Size(80, 23);
            this.buttonClearReceived.TabIndex = 4;
            this.buttonClearReceived.Text = "수신 지우기";
            this.buttonClearReceived.UseVisualStyleBackColor = true;
            this.buttonClearReceived.Click += new System.EventHandler(this.buttonClearReceived_Click);
            // 
            // buttonClearSent
            // 
            this.buttonClearSent.Location = new System.Drawing.Point(670, 221);
            this.buttonClearSent.Name = "buttonClearSent";
            this.buttonClearSent.Size = new System.Drawing.Size(80, 23);
            this.buttonClearSent.TabIndex = 5;
            this.buttonClearSent.Text = "송신 지우기";
            this.buttonClearSent.UseVisualStyleBackColor = true;
            this.buttonClearSent.Click += new System.EventHandler(this.buttonClearSent_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 420);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(76, 15);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "상태: 연결안됨";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.groupBoxCommunication);
            this.Controls.Add(this.groupBoxSerialSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "시리얼 테스트 프로그램 (바이트 데이터)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxSerialSettings.ResumeLayout(false);
            this.groupBoxSerialSettings.PerformLayout();
            this.groupBoxCommunication.ResumeLayout(false);
            this.groupBoxCommunication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSerialSettings;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.ComboBox comboBoxStopBits;
        private System.Windows.Forms.ComboBox comboBoxDataBits;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.ComboBox comboBoxPortName;
        private System.Windows.Forms.Label labelParity;
        private System.Windows.Forms.Label labelStopBits;
        private System.Windows.Forms.Label labelDataBits;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.Label labelPortName;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.GroupBox groupBoxCommunication;
        private System.Windows.Forms.TextBox textBoxReceived;
        private System.Windows.Forms.TextBox textBoxSent;
        private System.Windows.Forms.Label labelReceived;
        private System.Windows.Forms.Label labelSent;
        private System.Windows.Forms.Button buttonClearReceived;
        private System.Windows.Forms.Button buttonClearSent;
        private System.Windows.Forms.Label labelStatus;
    }
}
