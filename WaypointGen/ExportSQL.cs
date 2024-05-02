using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaypointGen
{
    public partial class ExportSQL : Form
    {
        List<WaypointPath> waypoints;
        Thread? exportThread;

        public ExportSQL(List<WaypointPath> waypoints)
        {
            this.waypoints = waypoints;
            InitializeComponent();
            radioExportWithMatch.Checked = true;
            exportProgressBar.Maximum = this.waypoints.Count;
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            exportThread = new Thread(ExportThread);
            exportThread.Start();
        }

        private void ExportThread()
        {

        }

        private void SafeSetProgress(int progress)
        {
            if (exportProgressBar.InvokeRequired)
            {
                Action safeSet = delegate
                {
                    exportProgressBar.Value = progress;
                };
                exportProgressBar.Invoke(safeSet);
            } else
            {
                exportProgressBar.Value = progress;
            }
        }
    }
}
