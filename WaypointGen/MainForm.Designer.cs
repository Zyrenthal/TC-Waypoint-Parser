namespace WaypointGen
{
    partial class MainForm
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openSniffDataToolStripMenuItem = new ToolStripMenuItem();
            saveSQLToolStripMenuItem = new ToolStripMenuItem();
            exiToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            activityStatusLabel = new ToolStripStatusLabel();
            activityStatusProgress = new ToolStripProgressBar();
            waypointsGrid = new DataGridView();
            PathId = new DataGridViewTextBoxColumn();
            CreatureInfo = new DataGridViewTextBoxColumn();
            WaypointCount = new DataGridViewTextBoxColumn();
            waypointNodesDataGrid = new DataGridView();
            NodeId = new DataGridViewTextBoxColumn();
            posX = new DataGridViewTextBoxColumn();
            posY = new DataGridViewTextBoxColumn();
            posZ = new DataGridViewTextBoxColumn();
            selectedWaypointId = new Label();
            label1 = new Label();
            singleSqlInsertTextBox = new TextBox();
            label2 = new Label();
            selectedPathCreatureInfo = new Label();
            label3 = new Label();
            pathMapinfo = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)waypointsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)waypointNodesDataGrid).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1277, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openSniffDataToolStripMenuItem, saveSQLToolStripMenuItem, exiToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openSniffDataToolStripMenuItem
            // 
            openSniffDataToolStripMenuItem.Name = "openSniffDataToolStripMenuItem";
            openSniffDataToolStripMenuItem.Size = new Size(224, 26);
            openSniffDataToolStripMenuItem.Text = "Open Sniff Data";
            openSniffDataToolStripMenuItem.Click += openSniffDataToolStripMenuItem_Click;
            // 
            // saveSQLToolStripMenuItem
            // 
            saveSQLToolStripMenuItem.Name = "saveSQLToolStripMenuItem";
            saveSQLToolStripMenuItem.Size = new Size(224, 26);
            saveSQLToolStripMenuItem.Text = "Save SQL";
            saveSQLToolStripMenuItem.Click += saveSQLToolStripMenuItem_Click;
            // 
            // exiToolStripMenuItem
            // 
            exiToolStripMenuItem.Name = "exiToolStripMenuItem";
            exiToolStripMenuItem.Size = new Size(224, 26);
            exiToolStripMenuItem.Text = "Exit";
            exiToolStripMenuItem.Click += exiToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(49, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(145, 26);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { activityStatusLabel, activityStatusProgress });
            statusStrip1.Location = new Point(0, 662);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1277, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // activityStatusLabel
            // 
            activityStatusLabel.Name = "activityStatusLabel";
            activityStatusLabel.Size = new Size(43, 20);
            activityStatusLabel.Text = "Idle...";
            // 
            // activityStatusProgress
            // 
            activityStatusProgress.Name = "activityStatusProgress";
            activityStatusProgress.Size = new Size(100, 18);
            activityStatusProgress.Style = ProgressBarStyle.Marquee;
            activityStatusProgress.Visible = false;
            // 
            // waypointsGrid
            // 
            waypointsGrid.AllowUserToAddRows = false;
            waypointsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            waypointsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            waypointsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            waypointsGrid.Columns.AddRange(new DataGridViewColumn[] { PathId, CreatureInfo, WaypointCount });
            waypointsGrid.Location = new Point(12, 31);
            waypointsGrid.Name = "waypointsGrid";
            waypointsGrid.RowHeadersWidth = 51;
            waypointsGrid.Size = new Size(429, 628);
            waypointsGrid.TabIndex = 2;
            waypointsGrid.CellClick += waypointsGrid_CellContentClick;
            // 
            // PathId
            // 
            PathId.HeaderText = "PathId";
            PathId.MinimumWidth = 6;
            PathId.Name = "PathId";
            PathId.ReadOnly = true;
            // 
            // CreatureInfo
            // 
            CreatureInfo.HeaderText = "Creature";
            CreatureInfo.MinimumWidth = 6;
            CreatureInfo.Name = "CreatureInfo";
            CreatureInfo.ReadOnly = true;
            // 
            // WaypointCount
            // 
            WaypointCount.HeaderText = "Waypoints";
            WaypointCount.MinimumWidth = 6;
            WaypointCount.Name = "WaypointCount";
            WaypointCount.ReadOnly = true;
            // 
            // waypointNodesDataGrid
            // 
            waypointNodesDataGrid.AllowUserToAddRows = false;
            waypointNodesDataGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            waypointNodesDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            waypointNodesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            waypointNodesDataGrid.Columns.AddRange(new DataGridViewColumn[] { NodeId, posX, posY, posZ });
            waypointNodesDataGrid.Location = new Point(447, 89);
            waypointNodesDataGrid.Name = "waypointNodesDataGrid";
            waypointNodesDataGrid.RowHeadersWidth = 51;
            waypointNodesDataGrid.ShowEditingIcon = false;
            waypointNodesDataGrid.Size = new Size(818, 287);
            waypointNodesDataGrid.TabIndex = 3;
            // 
            // NodeId
            // 
            NodeId.HeaderText = "Node ID";
            NodeId.MinimumWidth = 6;
            NodeId.Name = "NodeId";
            NodeId.ReadOnly = true;
            // 
            // posX
            // 
            posX.HeaderText = "Position X";
            posX.MinimumWidth = 6;
            posX.Name = "posX";
            posX.ReadOnly = true;
            // 
            // posY
            // 
            posY.HeaderText = "Position Y";
            posY.MinimumWidth = 6;
            posY.Name = "posY";
            posY.ReadOnly = true;
            // 
            // posZ
            // 
            posZ.HeaderText = "Position Z";
            posZ.MinimumWidth = 6;
            posZ.Name = "posZ";
            posZ.ReadOnly = true;
            // 
            // selectedWaypointId
            // 
            selectedWaypointId.AutoSize = true;
            selectedWaypointId.Location = new Point(505, 55);
            selectedWaypointId.Name = "selectedWaypointId";
            selectedWaypointId.Size = new Size(57, 20);
            selectedWaypointId.TabIndex = 4;
            selectedWaypointId.Text = "000000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(447, 55);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 5;
            label1.Text = "Path ID: ";
            // 
            // singleSqlInsertTextBox
            // 
            singleSqlInsertTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            singleSqlInsertTextBox.Location = new Point(447, 382);
            singleSqlInsertTextBox.Multiline = true;
            singleSqlInsertTextBox.Name = "singleSqlInsertTextBox";
            singleSqlInsertTextBox.ScrollBars = ScrollBars.Both;
            singleSqlInsertTextBox.Size = new Size(818, 277);
            singleSqlInsertTextBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(579, 55);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 7;
            label2.Text = "Creature: ";
            // 
            // selectedPathCreatureInfo
            // 
            selectedPathCreatureInfo.AutoSize = true;
            selectedPathCreatureInfo.Location = new Point(649, 55);
            selectedPathCreatureInfo.Name = "selectedPathCreatureInfo";
            selectedPathCreatureInfo.Size = new Size(36, 20);
            selectedPathCreatureInfo.TabIndex = 8;
            selectedPathCreatureInfo.Text = "N/A";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(995, 55);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 9;
            label3.Text = "Map: ";
            // 
            // pathMapinfo
            // 
            pathMapinfo.AutoSize = true;
            pathMapinfo.Location = new Point(1039, 55);
            pathMapinfo.Name = "pathMapinfo";
            pathMapinfo.Size = new Size(36, 20);
            pathMapinfo.TabIndex = 10;
            pathMapinfo.Text = "N/A";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1277, 688);
            Controls.Add(pathMapinfo);
            Controls.Add(label3);
            Controls.Add(selectedPathCreatureInfo);
            Controls.Add(label2);
            Controls.Add(singleSqlInsertTextBox);
            Controls.Add(label1);
            Controls.Add(selectedWaypointId);
            Controls.Add(waypointNodesDataGrid);
            Controls.Add(waypointsGrid);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1169, 735);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TC Waypoint Parser";
            FormClosed += Form1_FormClosed;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)waypointsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)waypointNodesDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openSniffDataToolStripMenuItem;
        private ToolStripMenuItem saveSQLToolStripMenuItem;
        private ToolStripMenuItem exiToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel activityStatusLabel;
        private ToolStripProgressBar activityStatusProgress;
        private DataGridView waypointsGrid;
        private DataGridViewTextBoxColumn PathId;
        private DataGridViewTextBoxColumn CreatureInfo;
        private DataGridViewTextBoxColumn WaypointCount;
        private DataGridView waypointNodesDataGrid;
        private Label selectedWaypointId;
        private Label label1;
        private TextBox singleSqlInsertTextBox;
        private Label label2;
        private Label selectedPathCreatureInfo;
        private DataGridViewTextBoxColumn NodeId;
        private DataGridViewTextBoxColumn posX;
        private DataGridViewTextBoxColumn posY;
        private DataGridViewTextBoxColumn posZ;
        private Label label3;
        private Label pathMapinfo;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
    }
}
