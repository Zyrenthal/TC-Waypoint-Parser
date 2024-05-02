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
            checkboxExportUnknownGuid.Checked = true;
            exportProgressBar.Maximum = this.waypoints.Count;
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            exportThread = new Thread(ExportThread);
            exportThread.Start();
        }

        private void ExportThread()
        {
            List<String> creatureAddons = new List<string>();
            List<String> waypointPaths = new List<string>();
            List<String> waypointNodes = new List<string>();

            List<WaypointPath> unknownGuids = new List<WaypointPath>();

            DateTime now = DateTime.Now;
            int idx = 0;
            string OutputFileName = "";
            while (idx <= 99)
            {
                OutputFileName = string.Format("{0}_{1}_{2}_{3}_world_pathing.sql", now.Year, now.Month, now.Day, idx.ToString("D2"));

                if (!File.Exists(OutputFileName))
                {
                    break;
                }
                idx++;
            }

            foreach (WaypointPath path in waypoints)
            {
                if (path.bestMatchGuid == -1)
                {
                    unknownGuids.Add(path);
                    continue;
                }

                waypointPaths.Add(path.GenerateSQLInsertValue());

                foreach(WaypointNode node in path.nodes)
                {
                    waypointNodes.Add(node.GenerateSQLInsertValue(path.PathId));
                }

                creatureAddons.Add(string.Format("({0}, {1})", path.bestMatchGuid, path.PathId));
            }
            SafeSetProgressMax(waypointNodes.Count + waypointPaths.Count + creatureAddons.Count);
            SafeSetProgress(0);
            

            FileStream outputFileStream = File.Create(OutputFileName);
            StreamWriter outputStreamWriter = new StreamWriter(outputFileStream);

            List<int> pathIds = waypoints.FindAll(x => x.bestMatchGuid > 0).Select(item => item.PathId).ToList();

            outputStreamWriter.WriteLine(string.Format("DELETE FROM `waypoint_path` WHERE `PathId` IN ({0});", string.Join(",", pathIds)));
            outputStreamWriter.WriteLine("INSERT INTO `waypoint_path` (`PathId`, `MoveType`, `Flags`, `Velocity`, `Comment`) VALUES");
            for (int i = 0; i < waypointPaths.Count; i++)
            {
                outputStreamWriter.Write(waypointPaths[i]);

                if (((i + 1) % 250) == 0)
                {
                    outputStreamWriter.WriteLine(";" + Environment.NewLine + Environment.NewLine);
                    outputStreamWriter.WriteLine("INSERT INTO `waypoint_path` (`PathId`, `MoveType`, `Flags`, `Velocity`, `Comment`) VALUES");
                } else if(i == waypointPaths.Count - 1)
                {
                    outputStreamWriter.WriteLine(";" + Environment.NewLine);
                } else
                {
                    outputStreamWriter.WriteLine(",");
                }
                IncreaseProgress();
            }

            outputStreamWriter.WriteLine(string.Format("DELETE FROM `waypoint_path_node` WHERE `PathId` IN ({0});", string.Join(",", pathIds)));
            outputStreamWriter.WriteLine("INSERT INTO `waypoint_path_node` (`PathId`, `NodeId`, `PositionX`, `PositionY`, `PositionZ`, `Orientation`, `Delay`) VALUES");
            for (int i = 0; i < waypointNodes.Count; i++)
            {
                outputStreamWriter.Write(waypointNodes[i]);

                if (((i + 1) % 250) == 0)
                {
                    outputStreamWriter.WriteLine(";", Environment.NewLine + Environment.NewLine);
                    outputStreamWriter.WriteLine("INSERT INTO `waypoint_path_node` (`PathId`, `NodeId`, `PositionX`, `PositionY`, `PositionZ`, `Orientation`, `Delay`) VALUES");
                }
                else if (i == waypointNodes.Count - 1)
                {
                    outputStreamWriter.WriteLine(";" + Environment.NewLine);
                } else
                {
                    outputStreamWriter.WriteLine(",");
                }
                IncreaseProgress();
            }

            outputStreamWriter.WriteLine("INSERT INTO `creature_addon` (`guid`, `PathId`) VALUES");
            for (int i =0; i < creatureAddons.Count; i++)
            {
                outputStreamWriter.Write(creatureAddons[i]);

                if (((i+1) % 250) == 0)
                {
                    outputStreamWriter.WriteLine(Environment.NewLine + "AS new ON DUPLICATE KEY UPDATE `PathId` = new.PathId;" + Environment.NewLine + Environment.NewLine);
                    outputStreamWriter.WriteLine("INSERT INTO `creature_addon` (`guid`, `PathId`) VALUES");
                } else if (i == creatureAddons.Count - 1)
                {
                    outputStreamWriter.WriteLine(Environment.NewLine + "AS new ON DUPLICATE KEY UPDATE `PathId` = new.PathId;" + Environment.NewLine);
                } else
                {
                    outputStreamWriter.WriteLine(",");
                }
                IncreaseProgress();
            }

            outputStreamWriter.Flush();
            outputStreamWriter.Close();
            MessageBox.Show("Export finished!");
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

        private void IncreaseProgress()
        {
            if (exportProgressBar.InvokeRequired)
            {
                Action safeIncrease = delegate
                {
                    exportProgressBar.Value++;
                };
                exportProgressBar.Invoke(safeIncrease);
            } else
            {
                exportProgressBar.Value++;
            }
        }

        private void SafeSetProgressMax(int max)
        {
            if (exportProgressBar.InvokeRequired)
            {
                Action safeSet = delegate
                {
                    exportProgressBar.Maximum = max;
                };
                exportProgressBar.Invoke(safeSet);
            } else
            {
                exportProgressBar.Maximum = max;
            }
        }
    }
}
