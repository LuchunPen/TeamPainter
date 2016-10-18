using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

using Nano3;
using Nano3.Net;
using Nano3.Collection;

namespace TeamPainter
{
    public partial class ClientForm : Form
    {
        private enum SelectedTool
        {
            None,
            SelectorRect,
            Brush,
            Line,
            Rect,
            Ellipse
        }

        private TeamPainterClientConfig _config;

        private Canvas _canvas;
        private PictureBoxObj _movedControl;

        private SelectedTool _toolType;
        private IPaintTool _paintTool;
        private int _toolSize;
        private Color _toolColor;

        private TeamPainterNetClient _netClient;
        private TextLogger _logger;

        private TrafficCounter _traffic;
        private NetTrafficForm _trafficForm;

        private ArgNewPictureBox _incomingCanvas = null;
        private FastQueueDictionaryM2<long, ArgNewPictureBox> _incomingPictureBoxes = new FastQueueDictionaryM2<long, ArgNewPictureBox>();
        private object _npbSync = new object();

        public ClientForm()
        {
            InitializeComponent();
            InitializeCanvas();
            InitializeNetwork();

            _config = TeamPainterClientConfig.FromIni();
        }

        private void InitializeCanvas()
        {
            ToolDrawer.Initialize(new TPDrawer());

            _canvas = new Canvas();
            _canvas.CanvasClearEvent += OnClearCanvasHandler;
            _canvas.Width = 512;
            _canvas.Height = 512;

            pnlImage.Controls.Add(_canvas);

            cbSize.SelectedItem = "5";
            btnColor.BackColor = Color.Black;
            _toolSize = 5;
            _toolColor = Color.Black;

            pnlFile.Enabled = false;
            pnlTools.Enabled = false;
        }

        private void InitializeNetwork()
        {
            _logger = new TextLogger(rtbLog);
            AppLogger.Initialize(_logger);
            NetLogger.Initialize(_logger);
            NetProtocol.Initialize(new Protocol_12());

            _netClient = new TeamPainterNetClient();

            _netClient.ConnectEvent += OnClientConnectHandler;
            _netClient.DisconnectEvent += OnClientDisconnectHandler;
            _traffic = new TrafficCounter(100, 0);

            InitializeCommands();
        }

        private void InitializeCommands()
        {
            _netClient.Commands.Add(new NComSendClientID(NCReceiveClientID));
            _netClient.Commands.Add(new NComCreateNewCanvas(NCCreateNewCanvas));
            _netClient.Commands.Add(new NComCreateNewPictureBox(NCCreateNewPictureBox));
            _netClient.Commands.Add(new NComDrawByBrush(NCDrawByBrush));
            _netClient.Commands.Add(new NComDrawByLine(NCDrawByLine));
            _netClient.Commands.Add(new NComDrawRect(NCDrawByRect));
            _netClient.Commands.Add(new NComDrawEllipse(NCDrawByEllipse));
            _netClient.Commands.Add(new NComMovePictureBox(NCMovePictureBox));
            _netClient.Commands.Add(new NComSelectorCopy(NCSelectedRect));
            _netClient.Commands.Add(new NComApplyPictureBox(NCApplyPictureBox));
            _netClient.Commands.Add(new NComRemovePictureBox(NCRemovePictureBox));
        }

        #region REG_BUTTONS
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_netClient.Active) { Disconnect(); }
            else { Connect(); }
        }

        private void Connect()
        {
            ConnectionForm cForm = new ConnectionForm(_config.RemoteEndPoint);
            cForm.StartPosition = FormStartPosition.CenterParent;
            cForm.ShowDialog();

            if (cForm.DialogResult == DialogResult.OK){
                timerClient.Interval = _config.PictureUpdateInterval;
                timerClient.Start();
                _netClient.Connect(cForm.TCPHostAddress);
            }
        }
        private void Disconnect()
        {
            _netClient.Disconnect();
        }
        private void OnClientConnectHandler(object sender, IConnector connector)
        {
            btnConnect.Invoke((MethodInvoker)delegate{ btnConnect.BackgroundImage = Properties.Resources.Connect; });
            btnOptions.Invoke((MethodInvoker)delegate{ btnOptions.Enabled = false; });
            ATCPConnector atcp = connector as ATCPConnector;
            if (atcp != null)
            {
                _traffic.Subscribe(atcp);
                atcp.SendPacketSize = _config.SendPacketSize;
                atcp.SendInterval = _config.SendPacketInterval;
            }
            SendComLogin();
        }
        private void OnClientDisconnectHandler(object sender, object disconnectState)
        {
            SocketConnector sc = sender as SocketConnector;
            if (sc != null) { _traffic.UnSubscribe(sc); }

            timerClient.Stop();

            btnConnect.Invoke((MethodInvoker)delegate{ btnConnect.BackgroundImage = Properties.Resources.NotConnect1; });
            pnlFile.Invoke((MethodInvoker)delegate { pnlFile.Enabled = false; });
            pnlTools.Invoke((MethodInvoker)delegate { pnlTools.Enabled = false; });
            btnOptions.Invoke((MethodInvoker)delegate { btnOptions.Enabled = true; });
        }

        private void SendComLogin()
        {
            ArgComAutorize arg = new ArgComAutorize();
            arg.Login = "Login";
            arg.Password = "Password";
            if (_netClient.Connector != null) { _netClient.Connector.SendCommand(arg, true); }
        }
        private void NCReceiveClientID(IConnector connector, ArgUniqueID arg)
        {
            if (arg == null) return;
            _netClient.ClientID = arg.UniqueID;
            NetLogger.Log("Login success, received client ID: " + arg.UniqueID);

            pnlFile.Invoke((MethodInvoker)delegate { pnlFile.Enabled = true; });
            pnlTools.Invoke((MethodInvoker)delegate { pnlTools.Enabled = true; });
            rbtnBrush.Invoke((MethodInvoker)delegate { rbtnBrush.Checked = true; });

            if (_trafficForm != null){
                _trafficForm.Invoke((MethodInvoker)delegate { _trafficForm.Text = "Client: " +_netClient.ClientID.ToString(); });
            }
        }

        private void btnNew_Click(object sender, EventArgs e) { CreateNewCanvas(); }
        private void CreateNewCanvas()
        {
            CreateNewForm cForm = new CreateNewForm();
            cForm.StartPosition = FormStartPosition.CenterParent;
            cForm.ShowDialog();
            if (cForm.DialogResult == DialogResult.OK)
            {
                SendComNewCanvas(cForm.ImgWidth, cForm.ImgHeight, null);
            }
            else
            {
                string message = "";
                if (cForm.ImgWidth == 0)
                {
                    message += "Width size is incorrect ";
                }
                if (cForm.ImgHeight == 0)
                {
                    if (message != "") { message += ", "; }
                    message += "Height size is incorrect";
                }
                MessageBox.Show(message);
            }
        }
        private void SendComNewCanvas(int canvasSizeX, int canvasSizeY, Image canvasImage)
        {
            ArgNewPictureBox arg = new ArgNewPictureBox(NComCreateNewCanvas.uniqueID, _netClient.ClientID);
            arg.PBImage = canvasImage;
            arg.PBSizeX = canvasSizeX;
            arg.PBSizeY = canvasSizeY;

            if (_netClient.Connector != null) { _netClient.Connector.SendCommand(arg, true); }
        }
        private void NCCreateNewCanvas(IConnector connector, ArgNewPictureBox arg)
        {
            if (arg == null) return;
            if (arg.CommandID != NComCreateNewCanvas.uniqueID) return;

            if (arg.PBImage == null)
            {
                if (arg.PBSizeX < 1 || arg.PBSizeY < 1) { return; }
                Image img = new Bitmap(arg.PBSizeX, arg.PBSizeY);
                using (Graphics grp = Graphics.FromImage(img)){
                    grp.FillRectangle(Brushes.White, 0, 0, img.Width, img.Height);
                }
                arg.PBImage = img;
            }
            lock (_npbSync) { _incomingCanvas = arg; }
        }

        private void SendComNewPictureBox(PictureBoxObj picOBj)
        {
            ArgNewPictureBox arg = new ArgNewPictureBox(NComCreateNewPictureBox.uniqueID, _netClient.ClientID);

            arg.PictureBoxID = picOBj.UniqueID;
            arg.PBImage = picOBj.Image;
            arg.PBSizeX = picOBj.Width;
            arg.PBSizeY = picOBj.Height;
            arg.LocationX = picOBj.Location.X;
            arg.LocationY = picOBj.Location.Y;

            if (_netClient.Connector!= null)
            {
                AppLogger.Log(arg.PictureBoxID + " sended to create");
                _netClient.Connector.SendCommand(arg);
            }
        }
        private void NCCreateNewPictureBox(IConnector connection, ArgNewPictureBox arg)
        {
            if (arg == null) return;
            if (arg.CommandID != NComCreateNewPictureBox.uniqueID) return;

            lock (_npbSync) { _incomingPictureBoxes.Enqueue(arg.PictureBoxID, arg); }
        }

        private void btnLoad_Click(object sender, EventArgs e) { LoadPicture(); }
        private void LoadPicture()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load image";
            openFileDialog.Filter = "Bitmap File(*.bmp)|*.bmp|" + "JPEG File(*.jpg)|*.jpg|" + "PNG File(*.png)|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Bitmap.FromFile(openFileDialog.FileName);
                if (img == null) return;

                SendComNewCanvas(img.Width, img.Height, img);
            }
            openFileDialog.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e) { SavePicture(); }
        private void SavePicture()
        {
            if (_canvas == null || _canvas.BackPicture == null || _canvas.BackPicture.Image == null) return;
            try
            {
                Bitmap saveImg = new Bitmap(_canvas.BackPicture.Image);
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Save as";
                savedialog.Filter = "Bitmap File(*.bmp)|*.bmp|" + "JPEG File(*.jpg)|*.jpg|" + "PNG File(*.png)|*.png";
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the user-selected file name
                    string fileName = savedialog.FileName;
                    // Get the extension
                    string strFilExtn = fileName.Remove(0, fileName.Length - 3);
                    // Save file
                    switch (strFilExtn)
                    {
                        case "bmp": saveImg.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp); break;
                        case "jpg": saveImg.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                        case "png": saveImg.Save(fileName, System.Drawing.Imaging.ImageFormat.Png); break;
                        default: break;
                    }
                    AppLogger.Log("Picture is saved");
                }
            }
            catch (Exception ex){
                AppLogger.Log("Save error" + ex.ToString());
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = cd.Color;
                _toolColor = btnColor.BackColor;
            }
        }

        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(cbSize.SelectedItem.ToString(), out _toolSize);
            if (_toolSize == 0) { _toolSize = 1; }
        }

        private void rbtnSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSelect.Checked){
                _toolType = SelectedTool.SelectorRect;
                ApplyMovedControl();
            }
        }
        private void rbtnBrush_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBrush.Checked){
                _toolType = SelectedTool.Brush;
                ApplyMovedControl();
            }
        }
        private void rbtnLine_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnLine.Checked){
                _toolType = SelectedTool.Line;
                ApplyMovedControl();
            }
        }
        private void rbtnRect_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnRect.Checked){
                _toolType = SelectedTool.Rect;
                ApplyMovedControl();
            }
        }
        private void rbtnEllipce_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEllipce.Checked){
                _toolType = SelectedTool.Ellipse;
                ApplyMovedControl();
            }
        }
        private void ApplyMovedControl()
        {
            _paintTool = null;
            if (_movedControl != null)
            {
                _canvas.ApplyPictureObj(_movedControl.UniqueID);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbLog.Invoke((MethodInvoker)delegate
            {
                rtbLog.Clear();
            });
        }
        #endregion REG_BUTTONS

        #region REG_MOUSEEVENT
        private void pnlImage_DragDrop(object sender, DragEventArgs e)
        {
            string[] drops = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (drops != null && drops.Length > 0)
            {
                string fileName = Path.GetFileName(drops[0]);
                Image img = Bitmap.FromFile(drops[0]);
                if (img == null) return;

                if (_canvas.IsCleared){ SendComNewCanvas(img.Width, img.Height, img); }
                else
                {
                    Point cp = _canvas.PointToClient(new Point(e.X, e.Y));
                    if (_movedControl != null){
                        SendApplyPictureBox(_movedControl.UniqueID);
                        _movedControl.Dispose();
                        _movedControl = null;
                    }
                    _movedControl = CreateNewPictureBox(img, cp);
                }
            }
        }

        private void pnlImage_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            PictureBoxObj picObj = sender as PictureBoxObj;
            if (e.Button == MouseButtons.Right || picObj != _movedControl){
                if (_movedControl != null){
                    SendApplyPictureBox(_movedControl.UniqueID);
                    _movedControl.Dispose();
                    _movedControl = null;
                }
            }
            else
            {
                Point canvasPos = GetCanvasPoint(sender as Control, e.X, e.Y);
                _paintTool = new PMoveTool(_movedControl, canvasPos);
                return;
            }

            if (_toolType == SelectedTool.None) { return; }

            if (_toolType == SelectedTool.Brush){
                _paintTool = new PBrushTool(sender as PictureBoxObj, _toolSize, _toolColor);
            }
            else
            {
                Point canvasPos = GetCanvasPoint(sender as Control, e.X, e.Y);
                _movedControl = CreateNewPictureBox(null, canvasPos);
                if (_toolType == SelectedTool.Line){
                    _paintTool = new PDrawLine(_movedControl, canvasPos, _toolSize, _toolColor);
                }
                else if (_toolType == SelectedTool.Rect){
                    _paintTool = new PDrawRect(_movedControl, canvasPos, _toolSize, _toolColor);
                }
                else if (_toolType == SelectedTool.Ellipse){
                    _paintTool = new PDrawEllipse(_movedControl, canvasPos, _toolSize, _toolColor);
                }
                else if (_toolType == SelectedTool.SelectorRect){
                    _paintTool = new PSelectorRect(_movedControl, canvasPos, _canvas.BackPicture, false);
                }
                else if (_toolType == SelectedTool.SelectorRect){
                    _paintTool = new PSelectorRect(_movedControl, canvasPos, _canvas.BackPicture, true);
                }
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            Point canvasPos = GetCanvasPoint(sender as Control, e.X, e.Y);
            lblPos.Invoke((MethodInvoker)delegate{
                lblPos.Text = canvasPos.ToString();
            });

            if (_paintTool != null){
                DrawObject drObj = _paintTool.Draw(canvasPos.X, canvasPos.Y);
                SendDrawObject(drObj);
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (_paintTool != null)
            {
                Point canvasPos = GetCanvasPoint(sender as Control, e.X, e.Y);
                DrawObject drObj = _paintTool.Draw(canvasPos.X, canvasPos.Y);

                if (drObj is SelectorObject){
                    SelectorObject selector = drObj as SelectorObject;
                    selector.NeedCopy = true;
                }

                SendDrawObject(drObj);
                _paintTool = null;
            }
        }

        private PictureBoxObj CreateNewPictureBox(Image img, Point location)
        {
            //Create facepictureBox
            PictureBoxObj pic = new PictureBoxObj(_netClient.ClientID, Uid64.CreateNew().Data, PictureBoxStatus.IsMovable);
            if (img != null)
            {
                pic.Image = img;
                pic.Width = img.Width;
                pic.Height = img.Height;
            }
            SubscribeControl(pic);
            pic.BorderStyle = BorderStyle.FixedSingle;
            pic.BringToFront();
            pic.Parent = _canvas.FrontPicture;
            pic.Location = location;

            //Send it to serever
            SendComNewPictureBox(pic);
            return pic;
        }

        private void SendDrawObject(DrawObject drObj)
        {
            if (drObj == null || drObj.Picture == null) return;

            long picBoxID = drObj.Picture.UniqueID; //canvas
            ICommandArg arg = null;

            if (drObj is BrushLineObject)
            {
                BrushLineObject line = drObj as BrushLineObject;
                arg = new ArgBrushObject(_netClient.ClientID, picBoxID, line);
            }
            else if (drObj is LineObject)
            {
                LineObject line = drObj as LineObject;
                arg = new ArgLineObject(_netClient.ClientID, picBoxID, line);
            }
            else if (drObj is RectObject)
            {
                RectObject rect = drObj as RectObject;
                arg = new ArgRectObject(_netClient.ClientID, picBoxID, rect);
            }
            else if (drObj is EllipseObject)
            {
                EllipseObject ellipse = drObj as EllipseObject;
                arg = new ArgEllipseObject(_netClient.ClientID, picBoxID, ellipse);
            }
            else if (drObj is MoveObject)
            {
                MoveObject move = drObj as MoveObject;
                arg = new ArgMoveObject(_netClient.ClientID, picBoxID, move);
            }
            else if (drObj is SelectorObject)
            {
                SelectorObject selector = drObj as SelectorObject;
                arg = new ArgSelectorCopyObject(_netClient.ClientID, picBoxID, selector);
            }

            if (arg != null && _netClient.Connector != null) { _netClient.Connector.SendCommand(arg); }
        }

        private void NCDrawByBrush(IConnector connection, ArgBrushObject arg)
        {
            if (arg == null) return;

            BrushLineObject line = arg.Line;
            if (arg.PictureBoxID == 0) { line.Picture = _canvas.BackPicture; }
            _canvas.AddDrawObject(arg.PictureBoxID, line);
        }
        private void NCDrawByLine(IConnector connection, ArgLineObject arg)
        {
            if (arg == null || arg.PictureBoxID == 0) return;
            LineObject line = arg.Line;
            line.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            _canvas.AddDrawObject(arg.PictureBoxID, line);
        }
        private void NCDrawByRect(IConnector connection, ArgRectObject arg)
        {
            if (arg == null || arg.PictureBoxID == 0) return;
            RectObject rect = arg.Rect;
            rect.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            _canvas.AddDrawObject(arg.PictureBoxID, rect);
        }
        private void NCDrawByEllipse(IConnector connection, ArgEllipseObject arg)
        {
            if (arg == null || arg.PictureBoxID == 0) return;
            EllipseObject ellipse = arg.Rect;
            ellipse.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            _canvas.AddDrawObject(arg.PictureBoxID, ellipse);
        }
        private void NCSelectedRect(IConnector connector, ArgSelectorCopyObject arg)
        {
            if (arg == null || arg.PictureBoxID == 0) return;

            SelectorObject selector = arg.Selector;
            selector.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            selector.SourcePicture = _canvas.BackPicture;
            _canvas.AddDrawObject(arg.PictureBoxID, selector);
        }
        private void NCMovePictureBox(IConnector connection, ArgMoveObject arg)
        {
            if (arg == null || arg.PictureBoxID == 0) return;
            MoveObject move = arg.MoveObj;

            move.Picture = _canvas.GetEditablePictureBox(arg.PictureBoxID);
            _canvas.AddDrawObject(arg.PictureBoxID, move);
        }
        #endregion REG_MOUSEEVENT

        #region REG_TICKABLE

        private void timerClient_Tick(object sender, EventArgs e)
        {
            if (_netClient.Connector != null) { _netClient.Connector.Send(null, null); }

            TickCreateNewCanvas();
            TickCreateNewPictureBoxes();

            _canvas.RemoveAllNeededPictureObjects();
            _canvas.DrawPictureBoxesByDrawObjects();
            _canvas.ApplyAllNeededPictureObjects();

            _canvas.UpdateCanvas();
            if (_traffic != null){ _traffic.Update(AppTime.Time); }
        }
        private void TickCreateNewCanvas()
        {
            ArgNewPictureBox arg = null;
            lock (_npbSync)
            {
                if (_incomingCanvas != null)
                {
                    arg = _incomingCanvas;
                    _incomingCanvas = null;
                }
                else { return; }
            }

            if (_movedControl != null) { _movedControl.Dispose(); _movedControl = null; }

            PictureBoxObj pb = new PictureBoxObj(arg.ClientID, 0, PictureBoxStatus.Canvas);
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.Width = arg.PBImage.Width;
            pb.Height = arg.PBImage.Height;
            pb.Image = arg.PBImage;

            UnSubscribeControl(_canvas.FrontPicture);
            _canvas.Clear();
            _canvas.SetCanvas(pb);
            SubscribeControl(_canvas.FrontPicture);
            _canvas.UpdateCanvas();

            AppLogger.Log("New canvas created by " + arg.ClientID);

            lblPictureSize.Invoke((MethodInvoker)delegate{
                lblPictureSize.Text = pb.Size.Width + " x " + pb.Size.Height + " px";
            });
        }
        private void TickCreateNewPictureBoxes()
        {
            ArgNewPictureBox[] pbs = null;
            lock (_npbSync) { pbs = _incomingPictureBoxes.DequeueAll(); }
            if (pbs != null)
            {
                for (int i = 0; i < pbs.Length; i++)
                {
                    ArgNewPictureBox arg = pbs[i];
                    PictureBoxObj pic = new PictureBoxObj(arg.ClientID, arg.PictureBoxID,
                    PictureBoxStatus.IsMovable | PictureBoxStatus.IsDrawable);

                    if (arg.PBImage != null){
                        pic.Image = arg.PBImage;
                        pic.Width = arg.PBImage.Width;
                        pic.Height = arg.PBImage.Height;
                    }
                    else { pic.BackColor = Color.Transparent; }
                    _canvas.AddPictureObj(pic, new Point(arg.LocationX, arg.LocationY));
                }
            }
        }

        #endregion REG_TICKABLE

        private void SendApplyPictureBox(long pictureBoxID)
        {
            ArgPictureBoxID arg = new ArgPictureBoxID(NComApplyPictureBox.uniqueID, _netClient.ClientID);
            arg.PictureBoxID = pictureBoxID;
            if (_netClient.Connector != null) { _netClient.Connector.SendCommand(arg); }
        }
        private void NCApplyPictureBox(IConnector connector, ArgPictureBoxID arg)
        {
            if (arg == null) return;
            _canvas.AddAppliedPBIndex(arg.PictureBoxID);
        }

        private void SendRemovePictureBox(long pictureBoxID)
        {
            ArgPictureBoxID arg = new ArgPictureBoxID(NComRemovePictureBox.uniqueID, _netClient.ClientID);
            arg.PictureBoxID = pictureBoxID;
            if (_netClient.Connector != null) { _netClient.Connector.SendCommand(arg); }
        }
        private void NCRemovePictureBox(IConnector connector, ArgPictureBoxID arg)
        {
            if (arg == null) return;
            _canvas.AddRemovePBIndex(arg.PictureBoxID);
        }

        private void SubscribeControl(Control control)
        {
            if (control == null) return;
            control.MouseDown += OnMouseDown;
            control.MouseUp += OnMouseUp;
            control.MouseMove += OnMouseMove;
        }
        private void UnSubscribeControl(Control control)
        {
            if (control == null) return;
            control.MouseDown -= OnMouseDown;
            control.MouseUp -= OnMouseUp;
            control.MouseMove -= OnMouseMove;
        }

        private Point GetCanvasPoint(Control mouseEventSender, int pX, int pY)
        {
            if (mouseEventSender == null || mouseEventSender.IsDisposed) return new Point(pX, pY);
            if (mouseEventSender == _canvas || mouseEventSender == _canvas.BackPicture) { return new Point(pX, pY); }

            Point p = mouseEventSender.PointToScreen(new Point(pX, pY));
            Point canvasPoint = _canvas.PointToClient(p);
            return canvasPoint;
        }

        private void OnClearCanvasHandler(object sender, EventArgs arg)
        {
            if (_canvas != null && _canvas.FrontPicture != null){
                UnSubscribeControl(_canvas.FrontPicture);
            }
        }

        private void btnNetStatistic_Click(object sender, EventArgs e)
        {
            if (_trafficForm != null){
                _trafficForm.Close();
            }
            else
            {
                _trafficForm = new NetTrafficForm();
                if (_netClient.ClientID != 0){ _trafficForm.Text = "Client: " +_netClient.ClientID.ToString(); }
                _trafficForm.Show();
                _trafficForm.FormClosing += OnNetTrafficFormClosing;
                _traffic.TrafficDataChanged += _trafficForm.OnTrafficChangeHandler;
            }
        }
        private void OnNetTrafficFormClosing(object sender, EventArgs arg)
        {
            NetTrafficForm ntf = sender as NetTrafficForm;
            if (ntf != null)
            {
                ntf.FormClosing -= OnNetTrafficFormClosing;
                _traffic.TrafficDataChanged -= ntf.OnTrafficChangeHandler;
                _trafficForm = null;
            }
        }
        private void btnOptions_Click(object sender, EventArgs e)
        {
            SettingsForm options = new SettingsForm(_config);
            options.ShowDialog();
            if (options.DialogResult == DialogResult.OK){
                AppLogger.Log("Apply team painter settings");
            }
        }
    }
}
