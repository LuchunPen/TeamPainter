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
    public partial class CanvasForm : Form
    {
        private Canvas _canvas;
        public Canvas TPCanvas
        {
            get { return _canvas; }
        }

        public CanvasForm()
        {
            InitializeComponent();
        }

        private void ImageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Controls.Remove(_canvas);
            _canvas = null;
            this.Hide();
            e.Cancel = true;
        }

        public void SetCanvas(Canvas canvas)
        {
            if (canvas == null) { this.Close(); }

            _canvas = canvas;
            int maxWidth = Screen.PrimaryScreen.Bounds.Width;
            int maxHeight = Screen.PrimaryScreen.Bounds.Height;

            this.MaximumSize = new Size(maxWidth - 20, maxHeight - 20);
            this.Size = canvas.Size;
            pnlImage.Size = canvas.Size;

            if (canvas.IsDisposed) { MessageBox.Show("DISPOSED"); }
            pnlImage.Controls.Add(canvas);
            lblPictureSize.Text = canvas.Size.ToString();
            canvas.UpdateCanvas();
        }

        public void UpdateForm()
        {
            if (_canvas != null) { _canvas.UpdateCanvas(); }
        }
    }
}
