/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 12.07.2016 21:20:30
*/

using System;
using System.Drawing;

using Nano3;

namespace TeamPainter
{
    public class PSelectorRect : IPaintTool
    {
        private bool _needCopy;
        public bool NeedCopy { get { return _needCopy; } set { _needCopy = value; } }

        private bool _isCutted;
        public bool IsCutted { get { return _isCutted; } }

        private PictureBoxObj _picture;
        private PictureBoxObj _source;

        private int _startX;
        private int _startY;

        public PSelectorRect(PictureBoxObj drawBox, Point startPoint, PictureBoxObj sourceBox, bool isCutted)
        {
            _picture = drawBox;
            _source = sourceBox;
            _picture.BackColor = Color.Transparent;

            _needCopy = false;
            _isCutted = isCutted;

            _startX = startPoint.X;
            _startY = startPoint.Y;
            _picture.BringToFront();
        }

        public DrawObject Draw(int pX, int pY)
        {
            DrawObject drOBj = GetDrawObject(pX, pY);
            Draw(drOBj);

            return drOBj;
        }

        public DrawObject GetDrawObject(int pX, int pY)
        {
            SelectorObject selector = new SelectorObject();
            selector.Picture = _picture;
            selector.SourcePicture = _source;
            selector.NeedCopy = _needCopy;
            selector.CutObject = _isCutted;

            selector.SizeX = Math.Abs(pX - _startX);
            selector.SizeY = Math.Abs(pY - _startY);

            selector.LocationX = pX < _startX ? pX : _startX;
            selector.LocationY = pY < _startY ? pY : _startY;

            return selector;
        }
        public static void Draw(DrawObject drObj)
        {
            SelectorObject selector = drObj as SelectorObject;
            if (selector == null || selector.Picture == null ||
                selector.SourcePicture == null || selector.SourcePicture.Image == null) return;

            selector.Picture.Width = selector.SizeX;
            selector.Picture.Height = selector.SizeY;
            selector.Picture.Location = new Point(selector.LocationX, selector.LocationY);

            Bitmap bm = new Bitmap(selector.SizeX <= 0 ? 1 : selector.SizeX, selector.SizeY <= 0 ? 1 : selector.SizeY);

            using (Graphics gr = Graphics.FromImage(bm))
            {
                Rectangle rDest = new Rectangle(0, 0, bm.Width, bm.Height);
                Rectangle rSource = new Rectangle(selector.LocationX, selector.LocationY, selector.SizeX, selector.SizeY);
                gr.FillRectangle(new SolidBrush(Color.Transparent), rDest);

                if (selector.NeedCopy)
                {
                    if ((PictureBoxStatus.IsDrawable & selector.Picture.Status) == PictureBoxStatus.IsDrawable)
                    {
                        GraphicsUnit units = GraphicsUnit.Pixel;
                        gr.DrawImage(selector.SourcePicture.Image, rDest, rSource, units);
                        selector.Picture.Image = bm;
                    }
                    if (selector.CutObject)
                    {
                        Graphics grSource = Graphics.FromImage(selector.SourcePicture.Image);
                        grSource.FillRectangle(new SolidBrush(Color.White), rSource);
                        selector.SourcePicture.Invalidate();
                    }
                }
            }
        }
    }
}
