/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 19.07.2016 16:39:57
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace TeamPainter
{
    public class FlatButton : Button
    {
        private Image _sourceBackGroundImage;
        [Category("Внешний вид")]
        public Image SourceBackGroundImage
        {
            get { return _sourceBackGroundImage; }
            set { _sourceBackGroundImage = value; }
        }
        private Image _disableImage;

        private Color _borderMouseOverColor;
        [Category("Внешний вид")]
        public Color BorderMouseOverColor
        {
            get { return _borderMouseOverColor; }
            set { _borderMouseOverColor = value; }
        }

        public FlatButton()
        {
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.Center;
            AutoSize = false;
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            FlatAppearance.BorderColor = _borderMouseOverColor;
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            FlatAppearance.BorderColor = BackColor;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            if (this.Enabled == true) { BackgroundImage = _sourceBackGroundImage; }
            else
            {
                if (_disableImage == null) {
                    _disableImage = ControlHelper.CreateImage(_sourceBackGroundImage);
                }
                BackgroundImage = _disableImage;
            }
        }
    }
}
