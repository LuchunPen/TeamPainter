using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeamPainter
{
    public partial class CreateNewForm : Form
    {
        private int _width;
        private int _height;

        public int ImgWidth { get { return _width; } }
        public int ImgHeight { get { return _height; } }

        public CreateNewForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int px; int.TryParse(tbWidth.Text, out px);

            bool ok = true;
            if (px < 1 || px > 2048) { ok = false; }

            int py; int.TryParse(tbHeight.Text, out py);
            if (py < 1 || py > 2048) { ok = false; }

            _width = px;
            _height = py;

            if (ok) { this.DialogResult = DialogResult.OK; }
            else { this.DialogResult = DialogResult.Cancel; }
        }
    }
}
