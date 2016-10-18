using System;
using System.Windows.Forms;

using Nano3;
using Nano3.Net;
namespace TeamPainter
{
    public partial class SettingsForm : Form
    {
        private TeamPainterHostConfig _config;

        public SettingsForm(TeamPainterHostConfig config)
        {
            InitializeComponent();
            if (config == null){
                this.DialogResult = DialogResult.Cancel;
            }

            _config = config;

            tbIP.Text = _config.TCPListenAddress.Address.ToString();
            tbPort.Text = _config.TCPListenAddress.Port.ToString();
            tbUpdInterval.Text = _config.PictureUpdateInterval.ToString();
            tbMaxClients.Text = _config.MaxClients.ToString();
            tbPing.Text = _config.PingInterval.ToString();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            try
            {
                _config.TCPListenAddress = NetHelper.GetIPEndPoint(tbIP.Text, tbPort.Text);

                int val = 0;
                bool ok = int.TryParse(tbUpdInterval.Text, out val);
                if (ok) { _config.PictureUpdateInterval = val; }

                ok = int.TryParse(tbMaxClients.Text, out val);
                if (ok) { _config.MaxClients = val; }

                ok = int.TryParse(tbPing.Text, out val);
                if (ok) { _config.PingInterval = val; }

                if (_config.Save()) { this.DialogResult = DialogResult.OK; }
                else { this.DialogResult = DialogResult.Cancel; }
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
