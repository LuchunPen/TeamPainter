namespace TeamPainter
{
    partial class ClientForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOptions = new TeamPainter.FlatButton();
            this.btnNetStatistic = new TeamPainter.FlatButton();
            this.btnConnect = new TeamPainter.FlatButton();
            this.pnlFile = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new TeamPainter.FlatButton();
            this.btnLoad = new TeamPainter.FlatButton();
            this.btnSave = new TeamPainter.FlatButton();
            this.panelIndicator = new System.Windows.Forms.Panel();
            this.pnlTools = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnColor = new System.Windows.Forms.Button();
            this.cbSize = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbtnSelect = new TeamPainter.FlatRadioButton();
            this.rbtnBrush = new TeamPainter.FlatRadioButton();
            this.rbtnLine = new TeamPainter.FlatRadioButton();
            this.rbtnRect = new TeamPainter.FlatRadioButton();
            this.rbtnEllipce = new TeamPainter.FlatRadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPictureSize = new System.Windows.Forms.Label();
            this.lblPos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.timerClient = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.pnlFile.SuspendLayout();
            this.pnlTools.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.Controls.Add(this.flowLayoutPanel2);
            this.pnlTop.Controls.Add(this.pnlFile);
            this.pnlTop.Controls.Add(this.panelIndicator);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(496, 42);
            this.pnlTop.TabIndex = 2;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnOptions);
            this.flowLayoutPanel2.Controls.Add(this.btnNetStatistic);
            this.flowLayoutPanel2.Controls.Add(this.btnConnect);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(367, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(129, 42);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // btnOptions
            // 
            this.btnOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptions.BackgroundImage = global::TeamPainter.Properties.Resources.options_32_white;
            this.btnOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOptions.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.btnOptions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.Location = new System.Drawing.Point(90, 3);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(36, 36);
            this.btnOptions.SourceBackGroundImage = global::TeamPainter.Properties.Resources.options_32_white;
            this.btnOptions.TabIndex = 1;
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnNetStatistic
            // 
            this.btnNetStatistic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNetStatistic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNetStatistic.BackgroundImage")));
            this.btnNetStatistic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNetStatistic.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.btnNetStatistic.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNetStatistic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNetStatistic.Location = new System.Drawing.Point(48, 3);
            this.btnNetStatistic.Name = "btnNetStatistic";
            this.btnNetStatistic.Size = new System.Drawing.Size(36, 36);
            this.btnNetStatistic.SourceBackGroundImage = null;
            this.btnNetStatistic.TabIndex = 0;
            this.btnNetStatistic.UseVisualStyleBackColor = false;
            this.btnNetStatistic.Click += new System.EventHandler(this.btnNetStatistic_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConnect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConnect.BackgroundImage")));
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConnect.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Location = new System.Drawing.Point(6, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(36, 36);
            this.btnConnect.SourceBackGroundImage = null;
            this.btnConnect.TabIndex = 0;
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pnlFile
            // 
            this.pnlFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFile.Controls.Add(this.btnNew);
            this.pnlFile.Controls.Add(this.btnLoad);
            this.pnlFile.Controls.Add(this.btnSave);
            this.pnlFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFile.Location = new System.Drawing.Point(43, 0);
            this.pnlFile.Name = "pnlFile";
            this.pnlFile.Size = new System.Drawing.Size(176, 42);
            this.pnlFile.TabIndex = 2;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNew.BackgroundImage = global::TeamPainter.Properties.Resources.add_32_white;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNew.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(36, 36);
            this.btnNew.SourceBackGroundImage = global::TeamPainter.Properties.Resources.add_32_white;
            this.btnNew.TabIndex = 0;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoad.BackgroundImage = global::TeamPainter.Properties.Resources.open_32_white;
            this.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLoad.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(45, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(36, 36);
            this.btnLoad.SourceBackGroundImage = global::TeamPainter.Properties.Resources.open_32_white;
            this.btnLoad.TabIndex = 1;
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.BackgroundImage = global::TeamPainter.Properties.Resources.Save_32_white;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(87, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 36);
            this.btnSave.SourceBackGroundImage = global::TeamPainter.Properties.Resources.Save_32_white;
            this.btnSave.TabIndex = 2;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelIndicator
            // 
            this.panelIndicator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIndicator.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIndicator.Location = new System.Drawing.Point(0, 0);
            this.panelIndicator.Name = "panelIndicator";
            this.panelIndicator.Size = new System.Drawing.Size(43, 42);
            this.panelIndicator.TabIndex = 3;
            // 
            // pnlTools
            // 
            this.pnlTools.BackColor = System.Drawing.Color.Transparent;
            this.pnlTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTools.Controls.Add(this.flowLayoutPanel3);
            this.pnlTools.Controls.Add(this.flowLayoutPanel1);
            this.pnlTools.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTools.Location = new System.Drawing.Point(0, 42);
            this.pnlTools.MinimumSize = new System.Drawing.Size(42, 200);
            this.pnlTools.Name = "pnlTools";
            this.pnlTools.Size = new System.Drawing.Size(43, 377);
            this.pnlTools.TabIndex = 3;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel3.Controls.Add(this.panel2);
            this.flowLayoutPanel3.Controls.Add(this.cbSize);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 175);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel3.MinimumSize = new System.Drawing.Size(2, 200);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(41, 200);
            this.flowLayoutPanel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnColor);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(34, 34);
            this.panel2.TabIndex = 4;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnColor.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnColor.Location = new System.Drawing.Point(5, 5);
            this.btnColor.Margin = new System.Windows.Forms.Padding(5);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(24, 24);
            this.btnColor.TabIndex = 0;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // cbSize
            // 
            this.cbSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSize.ForeColor = System.Drawing.SystemColors.Window;
            this.cbSize.FormattingEnabled = true;
            this.cbSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cbSize.Location = new System.Drawing.Point(1, 41);
            this.cbSize.Margin = new System.Windows.Forms.Padding(1);
            this.cbSize.Name = "cbSize";
            this.cbSize.Size = new System.Drawing.Size(36, 20);
            this.cbSize.TabIndex = 5;
            this.cbSize.SelectedIndexChanged += new System.EventHandler(this.cbSize_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.rbtnSelect);
            this.flowLayoutPanel1.Controls.Add(this.rbtnBrush);
            this.flowLayoutPanel1.Controls.Add(this.rbtnLine);
            this.flowLayoutPanel1.Controls.Add(this.rbtnRect);
            this.flowLayoutPanel1.Controls.Add(this.rbtnEllipce);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(2, 175);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(41, 175);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // rbtnSelect
            // 
            this.rbtnSelect.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnSelect.BackgroundImage = global::TeamPainter.Properties.Resources.Select_24_white;
            this.rbtnSelect.BackgroundImageActive = global::TeamPainter.Properties.Resources.Select_24_black;
            this.rbtnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnSelect.BackgroundImageNoActive = global::TeamPainter.Properties.Resources.Select_24_white;
            this.rbtnSelect.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.rbtnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnSelect.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnSelect.Location = new System.Drawing.Point(3, 0);
            this.rbtnSelect.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.rbtnSelect.Name = "rbtnSelect";
            this.rbtnSelect.Size = new System.Drawing.Size(34, 34);
            this.rbtnSelect.TabIndex = 4;
            this.rbtnSelect.TabStop = true;
            this.rbtnSelect.UseVisualStyleBackColor = false;
            this.rbtnSelect.CheckedChanged += new System.EventHandler(this.rbtnSelect_CheckedChanged);
            // 
            // rbtnBrush
            // 
            this.rbtnBrush.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnBrush.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnBrush.BackgroundImage = global::TeamPainter.Properties.Resources.Brush_24_white;
            this.rbtnBrush.BackgroundImageActive = global::TeamPainter.Properties.Resources.Brush_24_black;
            this.rbtnBrush.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnBrush.BackgroundImageNoActive = global::TeamPainter.Properties.Resources.Brush_24_white;
            this.rbtnBrush.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.rbtnBrush.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnBrush.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbtnBrush.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnBrush.Location = new System.Drawing.Point(3, 34);
            this.rbtnBrush.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.rbtnBrush.Name = "rbtnBrush";
            this.rbtnBrush.Size = new System.Drawing.Size(34, 34);
            this.rbtnBrush.TabIndex = 0;
            this.rbtnBrush.TabStop = true;
            this.rbtnBrush.UseVisualStyleBackColor = false;
            this.rbtnBrush.CheckedChanged += new System.EventHandler(this.rbtnBrush_CheckedChanged);
            // 
            // rbtnLine
            // 
            this.rbtnLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnLine.BackgroundImage = global::TeamPainter.Properties.Resources.Line_24_white;
            this.rbtnLine.BackgroundImageActive = global::TeamPainter.Properties.Resources.Line_24_black;
            this.rbtnLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnLine.BackgroundImageNoActive = global::TeamPainter.Properties.Resources.Line_24_white;
            this.rbtnLine.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.rbtnLine.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnLine.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbtnLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnLine.Location = new System.Drawing.Point(3, 68);
            this.rbtnLine.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.rbtnLine.Name = "rbtnLine";
            this.rbtnLine.Size = new System.Drawing.Size(34, 34);
            this.rbtnLine.TabIndex = 3;
            this.rbtnLine.TabStop = true;
            this.rbtnLine.UseVisualStyleBackColor = false;
            this.rbtnLine.CheckedChanged += new System.EventHandler(this.rbtnLine_CheckedChanged);
            // 
            // rbtnRect
            // 
            this.rbtnRect.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnRect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnRect.BackgroundImage = global::TeamPainter.Properties.Resources.Rect_24_white;
            this.rbtnRect.BackgroundImageActive = global::TeamPainter.Properties.Resources.Rect_24_black;
            this.rbtnRect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnRect.BackgroundImageNoActive = global::TeamPainter.Properties.Resources.Rect_24_white;
            this.rbtnRect.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.rbtnRect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnRect.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbtnRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnRect.Location = new System.Drawing.Point(3, 102);
            this.rbtnRect.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.rbtnRect.Name = "rbtnRect";
            this.rbtnRect.Size = new System.Drawing.Size(34, 34);
            this.rbtnRect.TabIndex = 1;
            this.rbtnRect.TabStop = true;
            this.rbtnRect.UseVisualStyleBackColor = false;
            this.rbtnRect.CheckedChanged += new System.EventHandler(this.rbtnRect_CheckedChanged);
            // 
            // rbtnEllipce
            // 
            this.rbtnEllipce.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnEllipce.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnEllipce.BackgroundImage = global::TeamPainter.Properties.Resources.Ellipse_24_white;
            this.rbtnEllipce.BackgroundImageActive = global::TeamPainter.Properties.Resources.Ellipse_24_black;
            this.rbtnEllipce.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.rbtnEllipce.BackgroundImageNoActive = global::TeamPainter.Properties.Resources.Ellipse_24_white;
            this.rbtnEllipce.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.rbtnEllipce.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rbtnEllipce.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rbtnEllipce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnEllipce.Location = new System.Drawing.Point(3, 136);
            this.rbtnEllipce.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.rbtnEllipce.Name = "rbtnEllipce";
            this.rbtnEllipce.Size = new System.Drawing.Size(34, 34);
            this.rbtnEllipce.TabIndex = 2;
            this.rbtnEllipce.TabStop = true;
            this.rbtnEllipce.UseVisualStyleBackColor = false;
            this.rbtnEllipce.CheckedChanged += new System.EventHandler(this.rbtnEllipce_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.rtbLog);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 55);
            this.panel1.TabIndex = 4;
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbLog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.rtbLog.Location = new System.Drawing.Point(42, 0);
            this.rtbLog.Margin = new System.Windows.Forms.Padding(0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.ShortcutsEnabled = false;
            this.rtbLog.Size = new System.Drawing.Size(271, 53);
            this.rtbLog.TabIndex = 2;
            this.rtbLog.TabStop = false;
            this.rtbLog.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblPictureSize);
            this.panel3.Controls.Add(this.lblPos);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(313, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 53);
            this.panel3.TabIndex = 0;
            // 
            // lblPictureSize
            // 
            this.lblPictureSize.AutoSize = true;
            this.lblPictureSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPictureSize.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPictureSize.Location = new System.Drawing.Point(93, 4);
            this.lblPictureSize.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblPictureSize.Name = "lblPictureSize";
            this.lblPictureSize.Size = new System.Drawing.Size(24, 12);
            this.lblPictureSize.TabIndex = 3;
            this.lblPictureSize.Text = "0, 0";
            // 
            // lblPos
            // 
            this.lblPos.AutoSize = true;
            this.lblPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPos.Location = new System.Drawing.Point(93, 20);
            this.lblPos.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.lblPos.Name = "lblPos";
            this.lblPos.Size = new System.Drawing.Size(24, 12);
            this.lblPos.TabIndex = 2;
            this.lblPos.Text = "0, 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mouse position:\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(7, 5);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Picture size:";
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(0, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(42, 53);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear log";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pnlImage
            // 
            this.pnlImage.AllowDrop = true;
            this.pnlImage.AutoScroll = true;
            this.pnlImage.BackColor = System.Drawing.Color.DimGray;
            this.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlImage.Location = new System.Drawing.Point(43, 42);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(453, 377);
            this.pnlImage.TabIndex = 5;
            this.pnlImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlImage_DragDrop);
            this.pnlImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlImage_DragEnter);
            // 
            // timerClient
            // 
            this.timerClient.Interval = 45;
            this.timerClient.Tick += new System.EventHandler(this.timerClient_Tick);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(496, 474);
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.pnlTools);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(512, 512);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.pnlTop.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.pnlFile.ResumeLayout(false);
            this.pnlTools.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlTools;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel pnlFile;
        private FlatRadioButton rbtnBrush;
        private System.Windows.Forms.Panel panelIndicator;
        private FlatRadioButton rbtnRect;
        private FlatRadioButton rbtnEllipce;
        private FlatRadioButton rbtnLine;
        private FlatButton btnNew;
        private FlatButton btnLoad;
        private FlatButton btnSave;
        private System.Windows.Forms.Panel panel1;
        private FlatButton btnConnect;
        private System.Windows.Forms.Panel pnlImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.ComboBox cbSize;
        private FlatRadioButton rbtnSelect;
        private System.Windows.Forms.ColorDialog colorDlg;
        private System.Windows.Forms.Timer timerClient;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPictureSize;
        private System.Windows.Forms.Label lblPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private FlatButton btnNetStatistic;
        private FlatButton btnOptions;
    }
}