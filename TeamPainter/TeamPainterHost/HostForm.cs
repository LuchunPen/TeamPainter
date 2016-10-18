using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Nano3;
using Nano3.Net;
using Nano3.Collection;

namespace TeamPainter
{
    public partial class HostForm : Form
    {
        private TeamPainterHostConfig _config;

        private TextLogger _logger;
        private TPHostAutorizator _autorizator;
        private TPWorkHost _worker;

        private CanvasForm _canvasForm;
        private Canvas _canvas = new Canvas();

        private ArgNewPictureBox _incomingCanvas;
        private FastDictionaryM2<long, long> _clientServerPictureBoxID = new FastDictionaryM2<long, long>();
        private FastQueueDictionaryM2<long, ArgNewPictureBox> _newPB = new FastQueueDictionaryM2<long, ArgNewPictureBox>();
        private object _npbSync = new object();

        private List<ICommandArg> _argsSendToAllClients = new List<ICommandArg>();
        private object _astSync = new object();

        public HostForm()
        {
            InitializeComponent();
            _config = TeamPainterHostConfig.FromIni();
            ToolDrawer.Initialize(new TPDrawer());

            InitializeNetwork();
            InitializeAutorizeCommands();
            InitializeWorkCommands();
        }

        private void InitializeNetwork()
        {
            _logger = new TextLogger(rtbLog);
            AppLogger.Initialize(_logger);
            NetLogger.Initialize(_logger);
            NetProtocol.Initialize(new Protocol_12());

            tbIP.Text = _config.TCPListenAddress.Address.ToString();
            tbPort.Text = _config.TCPListenAddress.Port.ToString();

            _autorizator = new TPHostAutorizator(_config.MaxClients);
            _worker = new TPWorkHost(_config.MaxClients);

            _autorizator.Listener.StartEvent += OnStartListener;
            _autorizator.Listener.StopEvent += OnStopListener;

            _autorizator.DisconnectEvent += OnDisconnectEventHandler;
            _autorizator.NewConnectionEvent += OnNewTCPConnectionEventHandler;
            _worker.DisconnectEvent += OnDisconnectEventHandler;
        }

        private void InitializeAutorizeCommands()
        {
            _autorizator.Commands.Add(new NComAutorize(NCAutorizeNewClient));
        }

        private void InitializeWorkCommands()
        {
            _worker.Commands.Add(new NComCreateNewCanvas(NCCreateNewCanvas));
            _worker.Commands.Add(new NComCreateNewPictureBox(NCCreateNewPictureBox));
            _worker.Commands.Add(new NComApplyPictureBox(NCApplyPictureBox));
            _worker.Commands.Add(new NComRemovePictureBox(NCRemovePictureBox));
            _worker.Commands.Add(new NComMovePictureBox(NCMovePictureBox));
            _worker.Commands.Add(new NComDrawByBrush(NCDrawByBrush));
            _worker.Commands.Add(new NComDrawByLine(NCDrawByLine));
            _worker.Commands.Add(new NComDrawRect(NCDrawByRect));
            _worker.Commands.Add(new NComDrawEllipse(NCDrawByEllipse));
            _worker.Commands.Add(new NComSelectorCopy(NCSelectCopyRect));
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (!_autorizator.Listener.IsActive)
            {
                _autorizator.Listener.Start(NetHelper.GetIPEndPoint(tbIP.Text, tbPort.Text));
                tmrUpdate.Interval = _config.PictureUpdateInterval;
                tmrUpdate.Start();
            }
            else
            {
                _autorizator.Listener.Stop(null);
                tmrUpdate.Stop();
            }
        }

        private void miLogClear_Click(object sender, EventArgs e)
        {
            rtbLog.Invoke((MethodInvoker)delegate { rtbLog.Clear(); });
        }

        private void miDisconnect_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = null;
            lvClients.Invoke((MethodInvoker)delegate
            {
                if (lvClients.SelectedItems != null)
                {
                    if (lvClients.SelectedItems != null && lvClients.SelectedItems.Count > 0)
                    {
                        lvi = lvClients.SelectedItems[0];
                    }
                }
            });

            if (lvi == null) { return; }
            long id = 0; long.TryParse(lvi.Name, out id);
            if (id != 0)
            {
                string s = lvi.SubItems[1].Text;
                if (s == "No autorized")
                {
                    IConnector con = _autorizator.GetConnector(id);
                    if (con != null) { con.Disconnect(); }
                }
                else
                {
                    TeamPainterTCPClient client = _worker.GetClient(id);
                    if (client != null) { client.Disconnect(); }
                }
            }
        }

        private void btnShowPicture_Click(object sender, EventArgs e)
        {
            if (_canvasForm == null)
            {
                _canvasForm = new CanvasForm();
                _canvasForm.FormClosing += canvasForms_Closed;
                _canvasForm.Show();
                _canvasForm.SetCanvas(_canvas);
            }
            else { _canvasForm.Close(); }
        }

        private void miInfo_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = null;
            lvClients.Invoke((MethodInvoker)delegate
            {
                if (lvClients.SelectedItems != null)
                {
                    if (lvClients.SelectedItems != null && lvClients.SelectedItems.Count > 0)
                    {
                        lvi = lvClients.SelectedItems[0];
                    }
                }
            });

            if (lvi == null) { return; }
            long id = 0; long.TryParse(lvi.Name, out id);
            if (id != 0)
            {
                string s = lvi.SubItems[1].Text;
                if (string.IsNullOrEmpty(s) || s == "No autorized") { return; }
                TeamPainterTCPClient client = _worker.GetClient(id);
                if (client != null) { client.ShowInfo(); }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm options = new SettingsForm(_config);
            options.ShowDialog();
            if (options.DialogResult == DialogResult.OK)
            {
                AppLogger.Log("Apply team painter settings");
            }
        }

        private void canvasForms_Closed(object sender, EventArgs e)
        {
            _canvasForm.FormClosed -= canvasForms_Closed;
            _canvasForm = null;
        }

        private void OnStartListener(object sender, EventArgs arg)
        {
            NetLogger.Log("TCP host start listening at" + _autorizator.Listener.ListenAddress);
            tbPort.Invoke((MethodInvoker)delegate { tbPort.ReadOnly = true; });
            tbIP.Invoke((MethodInvoker)delegate { tbIP.ReadOnly = true; });
            btnStartStop.Invoke((MethodInvoker)delegate { btnStartStop.Text = "Stop"; });
            pnlIndicator.Invoke((MethodInvoker)delegate { pnlIndicator.BackColor = Color.LimeGreen; });
            btnSettings.Invoke((MethodInvoker)delegate { btnSettings.Enabled = false; });
        }

        private void OnStopListener(object sender, object stopState)
        {
            _autorizator.Stop();
            _worker.Stop();

            NetLogger.Log("TCP host stop listening");
            tbPort.Invoke((MethodInvoker)delegate { tbPort.ReadOnly = false; });
            tbIP.Invoke((MethodInvoker)delegate { tbIP.ReadOnly = false; });
            btnStartStop.Invoke((MethodInvoker)delegate { btnStartStop.Text = "Start"; });
            pnlIndicator.Invoke((MethodInvoker)delegate { pnlIndicator.BackColor = Color.Red; });
            btnSettings.Invoke((MethodInvoker)delegate { btnSettings.Enabled = true; });
        }

        private void OnNewTCPConnectionEventHandler(object sender, IConnector connector)
        {
            if (connector == null) { return; }

            lvClients.Invoke((MethodInvoker)delegate
            {
                ListViewItem lvi = new ListViewItem(connector.UniqueID.ToString());
                lvi.Name = connector.UniqueID.ToString();
                lvi.SubItems.Add("No autorized");
                lvi.BackColor = Color.DarkGray;
                lvi.ForeColor = Color.WhiteSmoke;

                lvClients.Items.Add(lvi);
            });
            NetLogger.Log(connector.UniqueID + " is connected");
        }

        private void OnDisconnectEventHandler(object sender, object disconnectState)
        {
            long id = 0;
            if (sender is IConnector)
            {
                id = ((IConnector)sender).UniqueID;
            }
            else if (sender is TeamPainterTCPClient)
            {
                id = ((TeamPainterTCPClient)sender).UniqueID;
            }

            if (id == 0) { return; }
            RemoveDisconnectedClientRec(id);
            lvClients.Invoke((MethodInvoker)delegate
            {
                lvClients.Items.RemoveByKey(id.ToString());
            });
        }

        private void NCAutorizeNewClient(IConnector connector, ArgComAutorize arg)
        {
            if (arg == null || connector == null) return;

            ATCPConnector atcpcon = connector as ATCPConnector;
            if (atcpcon == null) return;

            if (!string.IsNullOrEmpty(arg.Login) && arg.Password == "Password")
            {
                _autorizator.RemoveConnector(connector.UniqueID);

                ArgUniqueID argClientID = new ArgUniqueID(NComSendClientID.uniqueID);
                argClientID.UniqueID = Uid64.CreateNewSync().Data;
                TeamPainterTCPClient client = new TeamPainterTCPClient(atcpcon, argClientID.UniqueID, arg.Login);

                bool added = _worker.AddClient(client);
                if (!added) { client.Disconnect(); return; }

                lvClients.Invoke((MethodInvoker)delegate
                {
                    ListViewItem lvi = lvClients.Items[client.Connector.UniqueID.ToString()];
                    if (lvi != null)
                    {
                        lvi.Name = client.UniqueID.ToString();
                        lvi.SubItems[0].Text = client.UniqueID.ToString();
                        lvi.SubItems[1].Text = arg.Login;

                        lvi.BackColor = Color.WhiteSmoke;
                        lvi.ForeColor = Color.Black;

                        lvClients.Invalidate();
                    }
                });

                connector.SendCommand(argClientID);
            }
        }

        private void NCCreateNewCanvas(IConnector connection, ArgNewPictureBox arg)
        {
            if (arg == null) return;
            if (arg.CommandID != NComCreateNewCanvas.uniqueID) return;

            if (arg.PBImage == null)
            {
                if (arg.PBSizeX < 1 || arg.PBSizeY < 1) { return; }
                Image img = new Bitmap(arg.PBSizeX, arg.PBSizeY);
                using (Graphics grp = Graphics.FromImage(img))
                {
                    grp.FillRectangle(Brushes.White, 0, 0, img.Width, img.Height);
                }
                arg.PBImage = img;
            }
            TeamPainterTCPClient[] clients = _worker.GetAllClients();
            for (int i = 0; i < clients.Length; i++)
            {
                if (clients[i] == null) continue; //remove this
                clients[i].Connector.SendCommand(arg);
                clients[i].Syncronized = true;
            }

            lock (_npbSync) { _incomingCanvas = arg; }
        }

        private void NCCreateNewPictureBox(IConnector connection, ArgNewPictureBox arg)
        {
            long clientFakePBID = arg.PictureBoxID;
            long realEditablePBID = Uid64.CreateNew().Data;
            arg.PictureBoxID = realEditablePBID;
            lock (_npbSync)
            {
                _newPB.Enqueue(arg.PictureBoxID, arg);
                _clientServerPictureBoxID[clientFakePBID] = realEditablePBID;
            }
            lock (_astSync) { _argsSendToAllClients.Add(arg); }

            NetLogger.Log("CreatePB from: " + clientFakePBID + " to " + realEditablePBID);
        }

        private void NCMovePictureBox(IConnector connection, ArgMoveObject arg)
        {
            if (arg.PictureBoxID == 0) { return; }
            long assocID = GetPictureBoxAssociationID(arg.PictureBoxID);
            if (assocID == 0) return;

            arg.PictureBoxID = assocID;
            MoveObject move = arg.MoveObj;
            move.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            _canvas.AddDrawObject(arg.PictureBoxID, move);
            AddCommandToSendClients(arg);
        }

        private void NCApplyPictureBox(IConnector connection, ArgPictureBoxID arg)
        {
            if (arg.PictureBoxID == 0) { return; }
            long assocID = GetPictureBoxAssociationID(arg.PictureBoxID);
            if (assocID == 0) return;

            arg.PictureBoxID = assocID;
            _canvas.AddAppliedPBIndex(arg.PictureBoxID);
            AddCommandToSendClients(arg);
        }

        private void NCRemovePictureBox(IConnector connection, ArgPictureBoxID arg)
        {
            if (arg.PictureBoxID == 0) { return; }
            long assocID = GetPictureBoxAssociationID(arg.PictureBoxID);
            if (assocID == 0) return;

            arg.PictureBoxID = assocID;
            _canvas.AddRemovePBIndex(arg.PictureBoxID);
            AddCommandToSendClients(arg);
        }

        private void NCDrawByBrush(IConnector connection, ArgBrushObject arg)
        {
            BrushLineObject line = arg.Line;
            if (arg.PictureBoxID == 0) { line.Picture = _canvas.BackPicture; }
            _canvas.AddDrawObject(arg.PictureBoxID, line);
            AddCommandToSendClients(arg);
        }

        private void NCDrawByLine(IConnector connection, ArgLineObject arg)
        {
            if (arg.PictureBoxID == 0) { return; }
            long assocID = GetPictureBoxAssociationID(arg.PictureBoxID);
            if (assocID == 0) return;

            arg.PictureBoxID = assocID;
            LineObject line = arg.Line;
            line.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            _canvas.AddDrawObject(arg.PictureBoxID, line);
            AddCommandToSendClients(arg);
        }

        private void NCDrawByRect(IConnector connection, ArgRectObject arg)
        {
            if (arg.PictureBoxID == 0) { return; }
            long assocID = GetPictureBoxAssociationID(arg.PictureBoxID);
            if (assocID == 0) return;

            arg.PictureBoxID = assocID;
            RectObject rect = arg.Rect;
            rect.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            _canvas.AddDrawObject(arg.PictureBoxID, rect);
            AddCommandToSendClients(arg);
        }

        private void NCDrawByEllipse(IConnector connection, ArgEllipseObject arg)
        {
            if (arg.PictureBoxID == 0) { return; }
            long assocID = GetPictureBoxAssociationID(arg.PictureBoxID);
            if (assocID == 0) return;

            arg.PictureBoxID = assocID;
            EllipseObject ellipse = arg.Rect;
            ellipse.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            _canvas.AddDrawObject(arg.PictureBoxID, ellipse);
            AddCommandToSendClients(arg);
        }

        private void NCSelectCopyRect(IConnector connection, ArgSelectorCopyObject arg)
        {
            if (arg.PictureBoxID == 0) { return; }
            long assocID = GetPictureBoxAssociationID(arg.PictureBoxID);
            if (assocID == 0) return;

            arg.PictureBoxID = assocID;
            SelectorObject selector = arg.Selector;
            selector.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            selector.SourcePicture = _canvas.BackPicture;
            _canvas.AddDrawObject(arg.PictureBoxID, selector);
            AddCommandToSendClients(arg);
        }

        #region REG_TIMERUPDATE
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            if (TickCreateNewCanvas()) return;
            TickCreatNewPictureBoxes();

            _canvas.RemoveAllNeededPictureObjects();
            _canvas.DrawPictureBoxesByDrawObjects();
            _canvas.ApplyAllNeededPictureObjects();

            TickSendCommandsToAllClients();
            TickNewClientsSyncronized();

            if (_canvasForm != null) { _canvasForm.UpdateForm(); }
        }

        private bool TickCreateNewCanvas()
        {
            if (_incomingCanvas != null)
            {
                ArgNewPictureBox arg = _incomingCanvas;
                _incomingCanvas = null;

                _canvas.Clear();

                lock (_npbSync){
                    _newPB.Clear();
                    _clientServerPictureBoxID.Clear();
                }

                lock (_astSync){
                    _argsSendToAllClients.Clear();
                    _argsSendToAllClients = null;
                }

                PictureBoxObj pb = new PictureBoxObj(arg.ClientID, 0, PictureBoxStatus.Canvas);
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Width = arg.PBImage.Width;
                pb.Height = arg.PBImage.Height;
                pb.Image = arg.PBImage;
                _canvas.SetCanvas(pb);
                AppLogger.Log("New canvas created by " + arg.ClientID);

                lock (_astSync) { _argsSendToAllClients = new List<ICommandArg>(); }
                return true;
            }
            return false;
        }

        private void TickCreatNewPictureBoxes()
        {
            ArgNewPictureBox[] pbs = null;
            lock (_npbSync) { pbs = _newPB.DequeueAll(); }
            if (pbs != null)
            {
                for (int i = 0; i < pbs.Length; i++)
                {
                    ArgNewPictureBox arg = pbs[i];
                    PictureBoxObj pic = new PictureBoxObj(arg.ClientID, arg.PictureBoxID,
                    PictureBoxStatus.IsMovable | PictureBoxStatus.IsDrawable);

                    if (arg.PBImage != null)
                    {
                        pic.Image = arg.PBImage;
                        pic.Width = arg.PBImage.Width;
                        pic.Height = arg.PBImage.Height;
                    }
                    else { pic.BackColor = Color.Transparent; }
                    _canvas.AddPictureObj(pic, new Point(arg.LocationX, arg.LocationY));
                }
            }
        }

        private void TickSendCommandsToAllClients()
        {
            List<ICommandArg> args = null;
            lock (_astSync)
            {
                args = _argsSendToAllClients;
                _argsSendToAllClients = new List<ICommandArg>();
            }

            if (args != null)
            {
                TeamPainterTCPClient[] clients = _worker.GetAllClients();
                if (clients == null || clients.Length == 0) return;

                for (int i = 0; i < clients.Length; i++)
                {
                    TeamPainterTCPClient cl = clients[i];
                    cl.Traffic.Update(AppTime.Time);
                    if (cl == null || !cl.Syncronized) continue; //remove this

                    if (args.Count == 0) { cl.Connector.Send(null, null); continue; }
                    for (int c = 0; c < args.Count; c++){
                        cl.Connector.SendCommand(args[c]);
                    }
                }
            }
        }

        private void TickNewClientsSyncronized()
        {
            TeamPainterTCPClient[] clients = _worker.GetAllClients();
            if (clients == null || clients.Length == 0) return;

            List<TeamPainterTCPClient> unsync = new List<TeamPainterTCPClient>();
            for (int i = 0; i < clients.Length; i++){
                if (!clients[i].Syncronized) { unsync.Add(clients[i]); }
            }
            if (unsync.Count == 0) return;

            if (_canvas.IsCleared){
                for (int c = 0; c < unsync.Count; c++){
                    if (unsync[c].Syncronized) continue;
                    unsync[c].Syncronized = true;
                }
                return;
            }

            ArgNewPictureBox canvasArg = new ArgNewPictureBox(NComCreateNewCanvas.uniqueID, 0);
            canvasArg.PBImage = _canvas.GetBackPicture();
            canvasArg.LocationX = 0;
            canvasArg.LocationY = 0;
            canvasArg.PBSizeX = canvasArg.PBImage == null ? 0 : _canvas.Width;
            canvasArg.PBSizeY = canvasArg.PBImage == null ? 0 : _canvas.Height;
            canvasArg.PictureBoxID = 0;

            for (int c = 0; c < unsync.Count; c++)
            {
                unsync[c].Connector.SendCommand(canvasArg);
                unsync[c].Syncronized = true;
            }

            PictureBoxObj[] pbs = _canvas.GetAllPictureBoxes();
            for (int i = 0; i < pbs.Length; i++)
            {
                PictureBoxObj pic = pbs[i];
                ArgNewPictureBox picArg = new ArgNewPictureBox(NComCreateNewPictureBox.uniqueID, pic.ClientID);
                picArg.PBImage = pic.Image;
                picArg.LocationX = pic.Location.X;
                picArg.LocationY = pic.Location.Y;
                picArg.PBSizeX = pic.Width;
                picArg.PBSizeY = pic.Height;
                picArg.PictureBoxID = pic.UniqueID;

                for (int c = 0; c < unsync.Count; c++){
                    unsync[c].Connector.SendCommand(picArg);
                }
            }
        }
        #endregion REG_TIMERUPDATE

        private void AddCommandToSendClients(ICommandArg comarg)
        {
            lock (_astSync)
            {
                if (_argsSendToAllClients != null)
                {
                    _argsSendToAllClients.Add(comarg);
                }
            }
        }

        private void RemoveDisconnectedClientRec(long clientID)
        {
            PictureBoxObj[] pics = _canvas.GetAllPictureBoxes();
            for (int i = 0; i < pics.Length; i++)
            {
                if (pics[i].ClientID == clientID)
                {
                    ArgPictureBoxID arg = new ArgPictureBoxID(NComRemovePictureBox.uniqueID, clientID);
                    arg.PictureBoxID = pics[i].UniqueID;
                    _canvas.AddRemovePBIndex(arg.PictureBoxID);
                    AddCommandToSendClients(arg);
                }
            }
        }

        private long GetPictureBoxAssociationID(long picID)
        {
            lock (_npbSync)
            {
                long serverID = 0;
                _clientServerPictureBoxID.TryGetValue(picID, out serverID);
                return serverID;
            }
        }
    }
}
