namespace PIHelperSample
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelServer = new System.Windows.Forms.Label();
            this.labelTag = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxTag = new System.Windows.Forms.TextBox();
            this.labelTimeStamp = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnTagSearch = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteValues = new System.Windows.Forms.Button();
            this.btWriteValues = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.isDefaultConnection = new System.Windows.Forms.CheckBox();
            this.panelAuth = new System.Windows.Forms.Panel();
            this.lbLogin = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.inputUserName = new System.Windows.Forms.TextBox();
            this.inputPassword = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelServer.Location = new System.Drawing.Point(44, 23);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(70, 24);
            this.labelServer.TabIndex = 1;
            this.labelServer.Text = "Server:";
            // 
            // labelTag
            // 
            this.labelTag.AutoSize = true;
            this.labelTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTag.Location = new System.Drawing.Point(70, 25);
            this.labelTag.Name = "labelTag";
            this.labelTag.Size = new System.Drawing.Size(48, 24);
            this.labelTag.TabIndex = 2;
            this.labelTag.Text = "Tag:";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.textBoxServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxServer.Location = new System.Drawing.Point(124, 26);
            this.textBoxServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.ReadOnly = true;
            this.textBoxServer.Size = new System.Drawing.Size(213, 26);
            this.textBoxServer.TabIndex = 3;
            // 
            // textBoxTag
            // 
            this.textBoxTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxTag.Location = new System.Drawing.Point(124, 22);
            this.textBoxTag.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTag.Name = "textBoxTag";
            this.textBoxTag.Size = new System.Drawing.Size(213, 26);
            this.textBoxTag.TabIndex = 4;
            // 
            // labelTimeStamp
            // 
            this.labelTimeStamp.AutoSize = true;
            this.labelTimeStamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTimeStamp.Location = new System.Drawing.Point(3, 29);
            this.labelTimeStamp.Name = "labelTimeStamp";
            this.labelTimeStamp.Size = new System.Drawing.Size(111, 24);
            this.labelTimeStamp.TabIndex = 5;
            this.labelTimeStamp.Text = "TimeStamp:";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelValue.Location = new System.Drawing.Point(52, 65);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(64, 24);
            this.labelValue.TabIndex = 7;
            this.labelValue.Text = "Value:";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxValue.Location = new System.Drawing.Point(126, 63);
            this.textBoxValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(213, 26);
            this.textBoxValue.TabIndex = 8;
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(208, 99);
            this.buttonWrite.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(129, 28);
            this.buttonWrite.TabIndex = 9;
            this.buttonWrite.Text = "WriteValue";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(126, 26);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(213, 26);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // btnTagSearch
            // 
            this.btnTagSearch.Location = new System.Drawing.Point(217, 54);
            this.btnTagSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTagSearch.Name = "btnTagSearch";
            this.btnTagSearch.Size = new System.Drawing.Size(122, 28);
            this.btnTagSearch.TabIndex = 11;
            this.btnTagSearch.Text = "Tag Search";
            this.btnTagSearch.UseVisualStyleBackColor = true;
            this.btnTagSearch.Click += new System.EventHandler(this.btnTagSearch_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(215, 58);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(122, 28);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnImport);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 472);
            this.panel2.TabIndex = 3;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(606, 356);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(139, 28);
            this.btnImport.TabIndex = 5;
            this.btnImport.Text = "Import From Csv";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_ClickAsync);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.lbMessage);
            this.groupBox3.Location = new System.Drawing.Point(5, 388);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(741, 32);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(567, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 15);
            this.label12.TabIndex = 15;
            this.label12.Text = "Aleksandr Bushuev © 2021";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Message:";
            // 
            // lbMessage
            // 
            this.lbMessage.AutoSize = true;
            this.lbMessage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbMessage.Location = new System.Drawing.Point(89, 13);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(0, 17);
            this.lbMessage.TabIndex = 13;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonWrite);
            this.groupBox6.Controls.Add(this.labelValue);
            this.groupBox6.Controls.Add(this.textBoxValue);
            this.groupBox6.Controls.Add(this.labelTimeStamp);
            this.groupBox6.Controls.Add(this.dateTimePicker1);
            this.groupBox6.Location = new System.Drawing.Point(4, 252);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(356, 135);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Value";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.textBox6);
            this.groupBox5.Controls.Add(this.btnStop);
            this.groupBox5.Controls.Add(this.btnStart);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(364, 212);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(381, 135);
            this.groupBox5.TabIndex = 16;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Simulator";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Window;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(318, 26);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(1, 6, 0, 0);
            this.label11.Size = new System.Drawing.Size(42, 28);
            this.label11.TabIndex = 26;
            this.label11.Text = "sec.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(89, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 24);
            this.label10.TabIndex = 25;
            this.label10.Text = "Step Time:";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox6.Location = new System.Drawing.Point(207, 26);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(114, 26);
            this.textBox6.TabIndex = 25;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(268, 92);
            this.btnStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(65, 28);
            this.btnStop.TabIndex = 29;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(207, 92);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(65, 28);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox4.Location = new System.Drawing.Point(74, 62);
            this.textBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(117, 26);
            this.textBox4.TabIndex = 28;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Random",
            "Sinusoid"});
            this.comboBox1.Location = new System.Drawing.Point(207, 63);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 24);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.Text = "Select Type";
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox5.Location = new System.Drawing.Point(74, 98);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(117, 26);
            this.textBox5.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(16, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 24);
            this.label8.TabIndex = 26;
            this.label8.Text = "Max:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(20, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 24);
            this.label9.TabIndex = 25;
            this.label9.Text = "Min:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDeleteValues);
            this.groupBox4.Controls.Add(this.btWriteValues);
            this.groupBox4.Controls.Add(this.textBox3);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.dateTimePickerEnd);
            this.groupBox4.Controls.Add(this.dateTimePickerStart);
            this.groupBox4.Location = new System.Drawing.Point(364, 4);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(382, 204);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Range";
            // 
            // btnDeleteValues
            // 
            this.btnDeleteValues.Location = new System.Drawing.Point(20, 167);
            this.btnDeleteValues.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteValues.Name = "btnDeleteValues";
            this.btnDeleteValues.Size = new System.Drawing.Size(119, 29);
            this.btnDeleteValues.TabIndex = 18;
            this.btnDeleteValues.Text = "DeleteValues";
            this.btnDeleteValues.UseVisualStyleBackColor = true;
            this.btnDeleteValues.Click += new System.EventHandler(this.btnDeleteValues_Click);
            // 
            // btWriteValues
            // 
            this.btWriteValues.Location = new System.Drawing.Point(19, 135);
            this.btWriteValues.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btWriteValues.Name = "btWriteValues";
            this.btWriteValues.Size = new System.Drawing.Size(120, 28);
            this.btWriteValues.TabIndex = 20;
            this.btWriteValues.Text = "WriteValues";
            this.btWriteValues.UseVisualStyleBackColor = true;
            this.btWriteValues.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox3.Location = new System.Drawing.Point(244, 134);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(117, 26);
            this.textBox3.TabIndex = 24;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox2.Location = new System.Drawing.Point(244, 171);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(117, 26);
            this.textBox2.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(184, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 24);
            this.label7.TabIndex = 22;
            this.label7.Text = "Max:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(189, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 24);
            this.label6.TabIndex = 21;
            this.label6.Text = "Min:";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Window;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(318, 98);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(1, 6, 0, 0);
            this.label5.Size = new System.Drawing.Size(42, 28);
            this.label5.TabIndex = 20;
            this.label5.Text = "sec.";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Location = new System.Drawing.Point(148, 98);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 26);
            this.textBox1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(36, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 24);
            this.label4.TabIndex = 19;
            this.label4.Text = "Step Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(41, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 24);
            this.label3.TabIndex = 18;
            this.label3.Text = "End Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(35, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Start Time:";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(148, 60);
            this.dateTimePickerEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(213, 26);
            this.dateTimePickerEnd.TabIndex = 17;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(148, 20);
            this.dateTimePickerStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(213, 26);
            this.dateTimePickerStart.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelTag);
            this.groupBox2.Controls.Add(this.textBoxTag);
            this.groupBox2.Controls.Add(this.btnTagSearch);
            this.groupBox2.Location = new System.Drawing.Point(4, 165);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(356, 88);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tag Search";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelAuth);
            this.groupBox1.Controls.Add(this.isDefaultConnection);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.labelServer);
            this.groupBox1.Controls.Add(this.textBoxServer);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(356, 157);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Connection";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // isDefaultConnection
            // 
            this.isDefaultConnection.AutoSize = true;
            this.isDefaultConnection.Checked = true;
            this.isDefaultConnection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isDefaultConnection.Location = new System.Drawing.Point(48, 59);
            this.isDefaultConnection.Name = "isDefaultConnection";
            this.isDefaultConnection.Size = new System.Drawing.Size(146, 21);
            this.isDefaultConnection.TabIndex = 5;
            this.isDefaultConnection.Text = "DefaultConnection";
            this.isDefaultConnection.UseVisualStyleBackColor = true;
            this.isDefaultConnection.CheckedChanged += new System.EventHandler(this.isDefaultConnection_CheckedChanged);
            // 
            // panelAuth
            // 
            this.panelAuth.Controls.Add(this.inputPassword);
            this.panelAuth.Controls.Add(this.inputUserName);
            this.panelAuth.Controls.Add(this.label13);
            this.panelAuth.Controls.Add(this.lbLogin);
            this.panelAuth.Location = new System.Drawing.Point(39, 86);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(311, 70);
            this.panelAuth.TabIndex = 6;
            this.panelAuth.Visible = false;
            // 
            // lbLogin
            // 
            this.lbLogin.AutoSize = true;
            this.lbLogin.Location = new System.Drawing.Point(5, 7);
            this.lbLogin.Name = "lbLogin";
            this.lbLogin.Size = new System.Drawing.Size(75, 17);
            this.lbLogin.TabIndex = 0;
            this.lbLogin.Text = "UserName";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 17);
            this.label13.TabIndex = 1;
            this.label13.Text = "Password";
            // 
            // inputUserName
            // 
            this.inputUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
            this.inputUserName.Location = new System.Drawing.Point(85, 4);
            this.inputUserName.Name = "inputUserName";
            this.inputUserName.Size = new System.Drawing.Size(213, 27);
            this.inputUserName.TabIndex = 2;
            // 
            // inputPassword
            // 
            this.inputPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.1F);
            this.inputPassword.Location = new System.Drawing.Point(84, 37);
            this.inputPassword.Name = "inputPassword";
            this.inputPassword.PasswordChar = '*';
            this.inputPassword.Size = new System.Drawing.Size(213, 27);
            this.inputPassword.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 428);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "PIHelper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelAuth.ResumeLayout(false);
            this.panelAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelTag;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxTag;
        private System.Windows.Forms.Label labelTimeStamp;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnTagSearch;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btWriteValues;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDeleteValues;
        private System.Windows.Forms.CheckBox isDefaultConnection;
        private System.Windows.Forms.Panel panelAuth;
        private System.Windows.Forms.TextBox inputPassword;
        private System.Windows.Forms.TextBox inputUserName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbLogin;
    }
}

