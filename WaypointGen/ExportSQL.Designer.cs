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
            checkboxExportUnknownGuid = new CheckBox();
            SuspendLayout();
            // 
            // exportBtn
            // 
            exportBtn.Dock = DockStyle.Bottom;
            exportBtn.Location = new Point(0, 83);
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
            exportProgressBar.Location = new Point(0, 54);
            exportProgressBar.Name = "exportProgressBar";
            exportProgressBar.Size = new Size(257, 29);
            exportProgressBar.TabIndex = 2;
            // 
            // checkboxExportUnknownGuid
            // 
            checkboxExportUnknownGuid.AutoSize = true;
            checkboxExportUnknownGuid.Location = new Point(12, 12);
            checkboxExportUnknownGuid.Name = "checkboxExportUnknownGuid";
            checkboxExportUnknownGuid.Size = new Size(178, 24);
            checkboxExportUnknownGuid.TabIndex = 5;
            checkboxExportUnknownGuid.Text = "Export Unknown GUID";
            checkboxExportUnknownGuid.UseVisualStyleBackColor = true;
            // 
            // ExportSQL
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(257, 128);
            Controls.Add(checkboxExportUnknownGuid);
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
        private CheckBox checkboxExportUnknownGuid;
    }
}