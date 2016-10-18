﻿using System;
using System.Windows.Forms;

using Nano3;
using Nano3.Net;
namespace TeamPainter
{
    public partial class SettingsForm : Form
    {
        private TeamPainterClientConfig _config;

        public SettingsForm(TeamPainterClientConfig config)
        {
            InitializeComponent();
            if (config == null) { this.DialogResult = DialogResult.Cancel; }

            _config = config;

            tbIP.Text = _config.RemoteEndPoint.Address.ToString();
            tbPort.Text = _config.RemoteEndPoint.Port.ToString();
            tbUpdInterval.Text = _config.PictureUpdateInterval.ToString();
            tbPacketInterval.Text = _config.SendPacketInterval.ToString();
            tbPacketSize.Text = _config.SendPacketSize.ToString();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                _config.RemoteEndPoint = NetHelper.GetIPEndPoint(tbIP.Text, tbPort.Text);

                int val = 0;
                bool ok = int.TryParse(tbUpdInterval.Text, out val);
                if (ok) { _config.PictureUpdateInterval = val; }

                ok = int.TryParse(tbPacketInterval.Text, out val);
                if (ok) { _config.SendPacketInterval = val; }

                ok = int.TryParse(tbPacketSize.Text, out val);
                if (ok) { _config.SendPacketSize = val; }

                if (_config.Save()) { this.DialogResult = DialogResult.OK; }
                else { this.DialogResult = DialogResult.Cancel; }
            }
            catch(Exception ex)
            {
                AppLogger.Log(ex);
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
