namespace WaypointGen
{
    partial class Settings
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
            groupBox1 = new GroupBox();
            testMysqlConnectionBtn = new Button();
            label4 = new Label();
            mysqlPassTxt = new TextBox();
            label3 = new Label();
            mysqlPortTxt = new TextBox();
            label2 = new Label();
            mysqlUserTxt = new TextBox();
            label1 = new Label();
            mysqlHostTxt = new TextBox();
            checkBox1 = new CheckBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(testMysqlConnectionBtn);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(mysqlPassTxt);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(mysqlPortTxt);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(mysqlUserTxt);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(mysqlHostTxt);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(387, 158);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "MySQL Settings";
            // 
            // button1
            // 
            testMysqlConnectionBtn.Location = new Point(96, 115);
            testMysqlConnectionBtn.Name = "button1";
            testMysqlConnectionBtn.Size = new Size(177, 29);
            testMysqlConnectionBtn.TabIndex = 9;
            testMysqlConnectionBtn.Text = "Test Connection";
            testMysqlConnectionBtn.UseVisualStyleBackColor = true;
            testMysqlConnectionBtn.Click += testMysqlConnection_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(189, 85);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 8;
            label4.Text = "Pass";
            // 
            // mysqlPassTxt
            // 
            mysqlPassTxt.Location = new Point(235, 82);
            mysqlPassTxt.Name = "mysqlPassTxt";
            mysqlPassTxt.Size = new Size(131, 27);
            mysqlPassTxt.TabIndex = 7;
            mysqlPassTxt.Text = "127.0.0.1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(189, 52);
            label3.Name = "label3";
            label3.Size = new Size(35, 20);
            label3.TabIndex = 6;
            label3.Text = "Port";
            // 
            // mysqlPortTxt
            // 
            mysqlPortTxt.Location = new Point(235, 49);
            mysqlPortTxt.Name = "mysqlPortTxt";
            mysqlPortTxt.Size = new Size(131, 27);
            mysqlPortTxt.TabIndex = 5;
            mysqlPortTxt.Text = "3306";
            mysqlPortTxt.TextChanged += mysqlPortTxt_TextChanged;
            mysqlPortTxt.KeyPress += mysqlPortTxt_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 85);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 4;
            label2.Text = "User";
            // 
            // mysqlUserTxt
            // 
            mysqlUserTxt.Location = new Point(52, 82);
            mysqlUserTxt.Name = "mysqlUserTxt";
            mysqlUserTxt.Size = new Size(131, 27);
            mysqlUserTxt.TabIndex = 3;
            mysqlUserTxt.Text = "127.0.0.1";
            mysqlUserTxt.TextChanged += mysqlUserTxt_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 52);
            label1.Name = "label1";
            label1.Size = new Size(40, 20);
            label1.TabIndex = 2;
            label1.Text = "Host";
            // 
            // mysqlHostTxt
            // 
            mysqlHostTxt.Location = new Point(52, 49);
            mysqlHostTxt.Name = "mysqlHostTxt";
            mysqlHostTxt.Size = new Size(131, 27);
            mysqlHostTxt.TabIndex = 1;
            mysqlHostTxt.Text = "127.0.0.1";
            mysqlHostTxt.TextChanged += mysqlHostTxt_TextChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 26);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(76, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Enable";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 182);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            FormClosed += Settings_FormClosed;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label4;
        private TextBox mysqlPassTxt;
        private Label label3;
        private TextBox mysqlPortTxt;
        private Label label2;
        private TextBox mysqlUserTxt;
        private Label label1;
        private TextBox mysqlHostTxt;
        private CheckBox checkBox1;
        private Button testMysqlConnectionBtn;
    }
}