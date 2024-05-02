using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WaypointGen
{
    public partial class MainForm : Form
    {
        public ConfigurationSettings? configSettings;
        List<WaypointPath> waypoints = [];
        WaypointPath? selectedWaypointPath = null;
        Database database = Database.Instance();
        Thread dataThread;

        public MainForm()
        {
            if (File.Exists("config.json"))
            {
                var data = File.ReadAllText("config.json");
                configSettings = JsonConvert.DeserializeObject<ConfigurationSettings>(data);
            }

            if (configSettings == null)
            {
                configSettings = new ConfigurationSettings();
            }

            if (configSettings.MySQLEnabled)
            {
                database.UserName = configSettings.MySQLUser;
                database.Password = configSettings.MySQLPass;
                database.Server = configSettings.MySQLHost;
                database.Port = configSettings.MySQLPort;
                if (!database.IsConnect())
                {
                    MessageBox.Show("Something is wrong with the MySQL Connection, please check your settings");
                }
            }

            InitializeComponent();
        }

        private void openSniffDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Parsed Sniff Data (*.txt)|*.txt";
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                activityStatusLabel.Text = "Loading " + openFileDialog.FileName + "...";
                Stream ifStream = openFileDialog.OpenFile();
                dataThread = new Thread(parseSniffedData);
                dataThread.Start(ifStream);
            }
        }

        private void saveSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void parseSniffedData(object data)
        {
            Stream? ifStream = data as Stream;
            if (ifStream == null)
            {
                return;
            }

            Regex positionRe = new Regex(@"^Position: X: (.+?) Y: (.+?) Z: (.+?)( O:.+)?$");
            Regex pointsRe = new Regex(@"(Points|Waypoints): X: (.+?) Y: (.+?) Z: (.+?)$");
            //Regex waypointsRe = new Regex(@"^Waypoints: X: (.+?) Y: (.+?) Z: (.+?)$");
            Regex pathIdRe = new Regex(@"^\(MovementMonsterSpline\)\sId:\s(\d+)$");
            Regex creatureIdRe = new Regex(@"Map:\s(\d+)\s\((.+?)\)\sEntry:\s(\d+)\s\((.+?)\)\s");
            Regex moveTypeRe = new Regex(@"Mode:\s(\d)$");

            // Regex 
            using (var streamReader = new StreamReader(ifStream, Encoding.UTF8, true, 256))
            {
                String? line;
                bool inWaypoint = false;
                WaypointPath? waypointPath = null;
                Action safeClear = delegate
                {
                    waypointsGrid.Rows.Clear();
                };
                waypointsGrid.Invoke(safeClear);
                while ((line = streamReader.ReadLine()) != null)
                {
                    line.ReplaceLineEndings();
                    if (line.StartsWith("ServerToClient: SMSG_ON_MONSTER_MOVE"))
                    {
                        inWaypoint = true;
                        waypointPath = new WaypointPath();
                        continue;
                    }
                    else if (line.Length == 0)
                    {
                        inWaypoint = false;
                        if (waypointPath != null)
                        {
                            Console.WriteLine("Path: " + waypointPath.PathId + " for " + waypointPath.creatureId + " (" + waypointPath.creatureName + ") Length: " + waypointPath.nodes.Count);
                            if (configSettings!.MySQLEnabled)
                            {
                                int mobGuid = Database.Instance().FindBestMatchMob(waypointPath.creatureId, waypointPath.mapId, waypointPath.x, waypointPath.y);
                                waypointPath.bestMatchGuid = mobGuid;
                            }

                            DataGridViewRow row = (DataGridViewRow)waypointsGrid.RowTemplate.Clone();
                            row.CreateCells(waypointsGrid, waypointPath.PathId, waypointPath.creatureName + " (" + waypointPath.creatureId + ")", waypointPath.nodes.Count);

                            Action safeAddRow = delegate
                            {
                                waypointsGrid.Rows.Add(row);
                            };
                            waypointsGrid.Invoke(safeAddRow);

                            waypoints.Add(waypointPath);
                        }
                        waypointPath = null;
                        continue;
                    }

                    if (inWaypoint && waypointPath != null)
                    {
                        if (positionRe.IsMatch(line))
                        {
                            Match match = positionRe.Match(line);
                            GroupCollection matchData = match.Groups;
                            double x = double.Parse(matchData[1].Value);
                            double y = double.Parse(matchData[2].Value);
                            double z = double.Parse(matchData[3].Value);

                            waypointPath.x = x; waypointPath.y = y; waypointPath.z = z;
                        }
                        else if (creatureIdRe.IsMatch(line))
                        {
                            Match match = creatureIdRe.Match(line);
                            GroupCollection matchData = match.Groups;
                            waypointPath.mapId = int.Parse(matchData[1].Value);
                            waypointPath.mapName = matchData[2].Value;
                            waypointPath.creatureId = int.Parse(matchData[3].Value);
                            waypointPath.creatureName = matchData[4].Value;
                        }
                        else if (pathIdRe.IsMatch(line))
                        {
                            Match match = pathIdRe.Match(line);
                            GroupCollection matchData = match.Groups;
                            waypointPath.PathId = int.Parse(matchData[1].Value);
                        }
                        else if (pointsRe.IsMatch(line))
                        {
                            Match match = pointsRe.Match(line);
                            GroupCollection matchData = match.Groups;
                            waypointPath.nodes.Add(new WaypointNode(waypointPath.nodes.Count + 1, double.Parse(matchData[2].Value), double.Parse(matchData[3].Value), double.Parse(matchData[4].Value)));
                        }
                        else if (moveTypeRe.IsMatch(line))
                        {
                            Match match = moveTypeRe.Match(line);
                            GroupCollection matchData = match.Groups;
                            waypointPath.MoveType = int.Parse(matchData[1].Value);
                        }
                    }
                }
            }

            /*Action safeClear = delegate
            {
                waypointsGrid.Rows.Clear();
            };
            waypointsGrid.Invoke(safeClear);
            foreach (WaypointPath path in waypoints)
            {
                DataGridViewRow row = (DataGridViewRow)waypointsGrid.RowTemplate.Clone();
                row.CreateCells(waypointsGrid, path.PathId, path.creatureName + " (" + path.creatureId + ")", path.nodes.Count);

                Action safeAddRow = delegate
                {
                    waypointsGrid.Rows.Add(row);
                };
                waypointsGrid.Invoke(safeAddRow);

                // int idx = 
            }*/


            activityStatusLabel.Text = "Done!  Loaded " + waypoints.Count + " paths!";
        }

        private void waypointsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedWaypointPath = waypoints[e.RowIndex];

            if (selectedWaypointPath != null)
            {
                Action safeClear = delegate
                {
                    waypointNodesDataGrid.Rows.Clear();
                };
                waypointNodesDataGrid.Invoke(safeClear);

                selectedPathCreatureInfo.Text = selectedWaypointPath.creatureName + " (" + selectedWaypointPath.creatureId + ")";
                if (selectedWaypointPath.bestMatchGuid > 0)
                {
                    selectedPathCreatureInfo.Text += " Best Match: " + selectedWaypointPath.bestMatchGuid;
                }
                pathMapinfo.Text = selectedWaypointPath.mapName + " (" + selectedWaypointPath.mapId + ")";
                selectedWaypointId.Text = selectedWaypointPath.PathId + "";

                for (int i = 0; i < selectedWaypointPath.nodes.Count; i++)
                {
                    WaypointNode node = selectedWaypointPath.nodes[i];
                    DataGridViewRow row = (DataGridViewRow)waypointNodesDataGrid.RowTemplate.Clone();
                    row.CreateCells(waypointNodesDataGrid, node.NodeId, node.x, node.y, node.z);

                    Action safeAddRow = delegate
                    {
                        waypointNodesDataGrid.Rows.Add(row);
                    };
                    waypointNodesDataGrid.Invoke(safeAddRow);
                }

                

                singleSqlInsertTextBox.Text = selectedWaypointPath.GenerateSQL();
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsFrm = new Settings(this.configSettings!);
            if (settingsFrm.ShowDialog() == DialogResult.OK)
            {
                this.configSettings = settingsFrm.configSettings;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dataThread != null)
            {
                // dataThread.Abort();
            }
        }
    }

    public class WaypointPath
    {
        public int PathId;
        public int MoveType;
        public int Flags;

        public String creatureName;
        public String mapName;

        public int creatureId;
        public int mapId;
        public List<WaypointNode> nodes;
        public double x, y, z;
        public int bestMatchGuid = -1;

        public WaypointPath()
        {
            this.nodes = new List<WaypointNode>();
            this.creatureId = -1;
            this.x = 0;
            this.y = 0;
            this.z = 0;
            this.MoveType = -1;
            this.creatureName = "Unknown";
            this.mapName = "Unknown";
        }

        public String GenerateSQL()
        {
            String sqlStatement = "-- Pathing for " + this.creatureName + " Entry: " + this.creatureId + Environment.NewLine;
            if (this.bestMatchGuid > 0)
            {
                sqlStatement += "SET @NPC := " + this.bestMatchGuid + ";" + Environment.NewLine;
            }
            else
            {
                sqlStatement += "SET @NPC := XXXXXX;" + Environment.NewLine;
            }
            // sqlStatement += "SET @PATH := @NPC * 10;" + Environment.NewLine;

            sqlStatement += string.Format("INSERT INTO `creature_addon` (`guid`, `PathId`) VALUES (@NPC, {0}) ON DUPLICATE KEY UPDATE `PathId` = {0};", this.PathId) + Environment.NewLine;

            sqlStatement += this.GenerateSQLRemove();
            sqlStatement += Environment.NewLine;
            sqlStatement += this.GenerateSQLInsert();
            sqlStatement += Environment.NewLine;
            sqlStatement += this.GenerateSQLInsertValue();
            sqlStatement += ";";
            sqlStatement += Environment.NewLine + Environment.NewLine;
            sqlStatement += this.GenerateNodeSQLRemove();
            sqlStatement += Environment.NewLine;
            sqlStatement += WaypointNode.GenerateSQLInsert();
            sqlStatement += Environment.NewLine;
            for (int idx = 0; idx < this.nodes.Count; idx++)
            {
                WaypointNode node = this.nodes[idx];
                sqlStatement += node.GenerateSQLInsertValue(this.PathId);
                if (idx == this.nodes.Count - 1)
                {
                    sqlStatement += ";";
                    sqlStatement += Environment.NewLine;
                }
                else
                {
                    sqlStatement += ",";
                    sqlStatement += Environment.NewLine;
                }
            }

            sqlStatement += string.Format("-- .go {0} {1} {2}", this.x, this.y, this.z);
            return sqlStatement;
        }

        public String GenerateSQLInsertValue()
        {
            return string.Format("({0}, {1}, {2}, NULL, '{3}')",
                    this.PathId, this.MoveType, 0, string.Format("{0} ({1}) in {2} ({3})", this.creatureName, this.creatureId, this.mapName, this.mapId));

        }

        public string GenerateSQLInsert()
        {
            return "INSERT INTO waypoint_path(`PathId`, `MoveType`, `Flags`, `Velocity`, `Comment`) VALUES";
        }

        public String GenerateSQLRemove()
        {
            return string.Format("DELETE FROM `waypoint_path` WHERE `PathId`={0};", this.PathId);
        }

        public String GenerateNodeSQLRemove()
        {
            return string.Format("DELETE FROM `waypoint_path_node` WHERE `PathId`={0};", this.PathId);
        }
    }

    public class WaypointNode
    {
        public int NodeId;
        public double x, y, z;

        public WaypointNode(int NodeId,  double x, double y, double z)
        {
            this.NodeId = NodeId;
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static string GenerateSQLInsert()
        {
            return "INSERT INTO `waypoint_path_node` (`PathId`, `NodeId`, `PositionX`, `PositionY`, `PositionZ`, `Orientation`, `Delay`) VALUES";
        }

        public string GenerateSQLInsertValue(int PathId)
        {
            return string.Format("({0}, {1}, {2}, {3}, {4}, NULL, 0)", PathId, this.NodeId, this.x, this.y, this.z);
        }
    }
}
