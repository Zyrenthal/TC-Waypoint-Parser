namespace WaypointGen
{
    partial class ExportSQL
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
            exportBtn = new Button();
            exportProgressBar = new ProgressBar();
            radioExportWithMatch = new RadioButton();
            radioExportWithoutMatch = new RadioButton();
            radioExportAll = new RadioButton();
            SuspendLayout();
            // 
            // exportBtn
            // 
            exportBtn.Dock = DockStyle.Bottom;
            exportBtn.Location = new Point(0, 162);
            exportBtn.Name = "exportBtn";
            exportBtn.Size = new Size(257, 45);
            exportBtn.TabIndex = 4;
            exportBtn.Text = "Export SQL";
            exportBtn.UseVisualStyleBackColor = true;
            exportBtn.Click += exportBtn_Click;
            // 
            // exportProgressBar
            // 
            exportProgressBar.Dock = DockStyle.Bottom;
            exportProgressBar.Location = new Point(0, 133);
            exportProgressBar.Name = "exportProgressBar";
            exportProgressBar.Size = new Size(257, 29);
            exportProgressBar.TabIndex = 2;
            // 
            // radioExportWithMatch
            // 
            radioExportWithMatch.AutoSize = true;
            radioExportWithMatch.Location = new Point(12, 12);
            radioExportWithMatch.Name = "radioExportWithMatch";
            radioExportWithMatch.Size = new Size(187, 24);
            radioExportWithMatch.TabIndex = 1;
            radioExportWithMatch.TabStop = true;
            radioExportWithMatch.Text = "Export With Match Only";
            radioExportWithMatch.UseVisualStyleBackColor = true;
            // 
            // radioExportWithoutMatch
            // 
            radioExportWithoutMatch.AutoSize = true;
            radioExportWithoutMatch.Location = new Point(12, 42);
            radioExportWithoutMatch.Name = "radioExportWithoutMatch";
            radioExportWithoutMatch.Size = new Size(209, 24);
            radioExportWithoutMatch.TabIndex = 2;
            radioExportWithoutMatch.TabStop = true;
            radioExportWithoutMatch.Text = "Export Without Match Only";
            radioExportWithoutMatch.UseVisualStyleBackColor = true;
            // 
            // radioExportAll
            // 
            radioExportAll.AutoSize = true;
            radioExportAll.Location = new Point(12, 72);
            radioExportAll.Name = "radioExportAll";
            radioExportAll.Size = new Size(95, 24);
            radioExportAll.TabIndex = 3;
            radioExportAll.TabStop = true;
            radioExportAll.Text = "Export All";
            radioExportAll.UseVisualStyleBackColor = true;
            // 
            // ExportSQL
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(257, 207);
            Controls.Add(radioExportAll);
            Controls.Add(radioExportWithoutMatch);
            Controls.Add(radioExportWithMatch);
            Controls.Add(exportProgressBar);
            Controls.Add(exportBtn);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ExportSQL";
            Text = "Export Pathing SQL";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button exportBtn;
        private ProgressBar exportProgressBar;
        private RadioButton radioExportWithMatch;
        private RadioButton radioExportWithoutMatch;
        private RadioButton radioExportAll;
    }
}