/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 19.07.2016 15:05:58
*/

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace TeamPainter
{
    public class FlatRadioButton : RadioButton
    {
        private Image _disableImage;

        private Image _backImageActive;
        [Category("Внешний вид")]
        public Image BackgroundImageActive
        {
            get { return _backImageActive;}
            set { _backImageActive = value; }
        }

        private Image _backImageNoActive;
        [Category("Внешний вид")]
        public Image BackgroundImageNoActive
        {
            get { return _backImageNoActive; }
            set { _backImageNoActive = value; }
        }

        private Color _borderMouseOverColor;
        [Category("Внешний вид")]
        public Color BorderMouseOverColor
        {
            get { return _borderMouseOverColor; }
            set { _borderMouseOverColor = value; }
        }

        public FlatRadioButton()
        {
            Appearance = Appearance.Button;
            FlatStyle = FlatStyle.Flat;
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.Center;
            AutoSize = false;
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if (Checked)
            {
                BackgroundImage = _backImageActive;
                FlatAppearance.MouseOverBackColor = FlatAppearance.CheckedBackColor;
            }
            else
            {
                BackgroundImage = _backImageNoActive;
                FlatAppearance.MouseOverBackColor = Color.Transparent;
            }
            FlatAppearance.BorderColor = BackColor;
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

            if (this.Enabled == true) { BackgroundImage = _backImageNoActive; }
            else
            {
                if (_disableImage == null){ _disableImage = ControlHelper.CreateImage(_backImageNoActive); }
                BackgroundImage = _disableImage;
            }
            Checked = false;
        }
    }
}
