/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 12.07.2016 21:53:59
*/

using System;
using System.Windows.Forms;
using System.Drawing;

namespace TeamPainter
{
    public class PSelectorRect : IPaintTool
    {
        private PictureBox _picture;
        private PictureBox _source;

        private int _startX;
        private int _startY;

        public PSelectorRect(PictureBox drawBox, Point startPoint, PictureBox sourceBox)
        {
            _picture = drawBox;
            _source = sourceBox;
            _picture.BackColor = Color.Transparent;

            _startX = startPoint.X;
            _startY = startPoint.Y;
            _picture.BringToFront();
        }

        public void Draw(int pX, int pY)
        {
            int sizeX = Math.Abs(pX - _startX);
            int sizeY = Math.Abs(pY - _startY);

            int locationX = pX < _startX ? pX : _startX;
            int locationY = pY < _startY ? pY : _startY;

            _picture.Width = sizeX;
            _picture.Height = sizeY;
            _picture.Location = new Point(locationX, locationY);

            Bitmap bm = new Bitmap(sizeX <= 0 ? 1 : sizeX, sizeY <= 0 ? 1 : sizeY);
            Graphics gr = Graphics.FromImage(bm);

            Rectangle dest = new Rectangle(0, 0, bm.Width, bm.Height);
            Rectangle src = new Rectangle(locationX, locationY, sizeX, sizeY);
            gr.FillRectangle(new SolidBrush(Color.Transparent), dest);

            GraphicsUnit units = GraphicsUnit.Pixel;
            gr.DrawImage(_source.Image, dest, src, units);
            _picture.Image = bm;

            gr = Graphics.FromImage(_source.Image);
            gr.FillRectangle(new SolidBrush(Color.White), src);
        }
    }
}
