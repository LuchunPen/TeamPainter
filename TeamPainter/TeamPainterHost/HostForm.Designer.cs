namespace TeamPainter
{
    partial class HostForm
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
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSettings = new TeamPainter.FlatButton();
            this.btnShowPicture = new TeamPainter.FlatButton();
            this.pnlIndicator = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvClients = new System.Windows.Forms.ListView();
            this.chID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clientMI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.miDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.logMI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miLogClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.clientMI.SuspendLayout();
            this.logMI.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbIP
            // 
            this.tbIP.BackColor = System.Drawing.Color.DimGray;
            this.tbIP.ForeColor = System.Drawing.SystemColors.Window;
            this.tbIP.Location = new System.Drawing.Point(3, 27);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(86, 20);
            this.tbIP.TabIndex = 1;
            this.tbIP.Text = "127.0.0.1";
            this.tbIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPort
            // 
            this.tbPort.BackColor = System.Drawing.Color.DimGray;
            this.tbPort.ForeColor = System.Drawing.SystemColors.Window;
            this.tbPort.Location = new System.Drawing.Point(95, 27);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(50, 20);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "22000";
            this.tbPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 62);
            this.panel1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSettings);
            this.panel3.Controls.Add(this.btnShowPicture);
            this.panel3.Controls.Add(this.pnlIndicator);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(409, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(84, 62);
            this.panel3.TabIndex = 7;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.BackgroundImage = global::TeamPainter.Properties.Resources.options_32_white;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSettings.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.btnSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(3, 22);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(36, 36);
            this.btnSettings.SourceBackGroundImage = global::TeamPainter.Properties.Resources.options_32_white;
            this.btnSettings.TabIndex = 11;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnShowPicture
            // 
            this.btnShowPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowPicture.BackgroundImage = global::TeamPainter.Properties.Resources.Image_white;
            this.btnShowPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnShowPicture.BorderMouseOverColor = System.Drawing.Color.SteelBlue;
            this.btnShowPicture.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPicture.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnShowPicture.Location = new System.Drawing.Point(45, 22);
            this.btnShowPicture.Name = "btnShowPicture";
            this.btnShowPicture.Size = new System.Drawing.Size(36, 36);
            this.btnShowPicture.SourceBackGroundImage = null;
            this.btnShowPicture.TabIndex = 8;
            this.btnShowPicture.UseVisualStyleBackColor = false;
            this.btnShowPicture.Click += new System.EventHandler(this.btnShowPicture_Click);
            // 
            // pnlIndicator
            // 
            this.pnlIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlIndicator.Location = new System.Drawing.Point(65, 3);
            this.pnlIndicator.Name = "pnlIndicator";
            this.pnlIndicator.Size = new System.Drawing.Size(16, 16);
            this.pnlIndicator.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbIP);
            this.panel2.Controls.Add(this.btnStartStop);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbPort);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 62);
            this.panel2.TabIndex = 7;
            // 
            // btnStartStop
            // 
            this.btnStartStop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnStartStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartStop.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnStartStop.Location = new System.Drawing.Point(151, 25);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(75, 23);
            this.btnStartStop.TabIndex = 9;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(40, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(106, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // lvClients
            // 
            this.lvClients.BackColor = System.Drawing.Color.DimGray;
            this.lvClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chID,
            this.chName});
            this.lvClients.ContextMenuStrip = this.clientMI;
            this.lvClients.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvClients.ForeColor = System.Drawing.SystemColors.Window;
            this.lvClients.FullRowSelect = true;
            this.lvClients.Location = new System.Drawing.Point(0, 62);
            this.lvClients.MultiSelect = false;
            this.lvClients.Name = "lvClients";
            this.lvClients.Size = new System.Drawing.Size(226, 262);
            this.lvClients.TabIndex = 5;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.View = System.Windows.Forms.View.Details;
            // 
            // chID
            // 
            this.chID.Text = "ID";
            this.chID.Width = 125;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chName.Width = 100;
            // 
            // clientMI
            // 
            this.clientMI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miInfo,
            this.miDisconnect});
            this.clientMI.Name = "clientMI";
            this.clientMI.Size = new System.Drawing.Size(134, 48);
            // 
            // miInfo
            // 
            this.miInfo.BackColor = System.Drawing.Color.DimGray;
            this.miInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.miInfo.Name = "miInfo";
            this.miInfo.Size = new System.Drawing.Size(133, 22);
            this.miInfo.Text = "Info";
            this.miInfo.Click += new System.EventHandler(this.miInfo_Click);
            // 
            // miDisconnect
            // 
            this.miDisconnect.BackColor = System.Drawing.Color.DimGray;
            this.miDisconnect.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.miDisconnect.Name = "miDisconnect";
            this.miDisconnect.Size = new System.Drawing.Size(133, 22);
            this.miDisconnect.Text = "Disconnect";
            this.miDisconnect.Click += new System.EventHandler(this.miDisconnect_Click);
            // 
            // rtbLog
            // 
            this.rtbLog.ContextMenuStrip = this.logMI;
            this.rtbLog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(226, 62);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(267, 262);
            this.rtbLog.TabIndex = 6;
            this.rtbLog.Text = "";
            // 
            // logMI
            // 
            this.logMI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miLogClear});
            this.logMI.Name = "miLog";
            this.logMI.Size = new System.Drawing.Size(122, 26);
            // 
            // miLogClear
            // 
            this.miLogClear.BackColor = System.Drawing.Color.DimGray;
            this.miLogClear.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.miLogClear.Name = "miLogClear";
            this.miLogClear.Size = new System.Drawing.Size(121, 22);
            this.miLogClear.Text = "Clear log";
            this.miLogClear.Click += new System.EventHandler(this.miLogClear_Click);
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Interval = 33;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // HostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(493, 324);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.lvClients);
            this.Controls.Add(this.panel1);
            this.Name = "HostForm";
            this.Text = "HostForm";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.clientMI.ResumeLayout(false);
            this.logMI.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvClients;
        private System.Windows.Forms.ColumnHeader chID;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip logMI;
        private System.Windows.Forms.ToolStripMenuItem miLogClear;
        private FlatButton btnShowPicture;
        private System.Windows.Forms.ContextMenuStrip clientMI;
        private System.Windows.Forms.ToolStripMenuItem miInfo;
        private System.Windows.Forms.ToolStripMenuItem miDisconnect;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Panel pnlIndicator;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private FlatButton btnSettings;
    }
}