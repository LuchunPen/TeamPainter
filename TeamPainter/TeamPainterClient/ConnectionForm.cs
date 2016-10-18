using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using Nano3.Net;
namespace TeamPainter
{
    public partial class ConnectionForm : Form
    {
        private IPEndPoint _TCP;
        public IPEndPoint TCPHostAddress { get { return _TCP; } }

        public ConnectionForm(IPEndPoint endPoint)
        {
            InitializeComponent();
            if (endPoint != null)
            {
                tbIP_TCP.Text = endPoint.Address.ToString();
                tbport_TCP.Text = endPoint.Port.ToString();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                _TCP = NetHelper.GetIPEndPoint(tbIP_TCP.Text, tbport_TCP.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.DialogResult = DialogResult.Cancel;
                return;
            }
        }
    }
}
