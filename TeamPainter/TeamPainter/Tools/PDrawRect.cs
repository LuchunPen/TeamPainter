/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 12.07.2016 17:24:22
*/

using System;
using System.Windows.Forms;
using System.Drawing;

using Nano3;

namespace TeamPainter
{
    public class PDrawRect : IPaintTool
    {
        private PictureBoxObj _picture;

        private int _startX;
        private int _startY;

        private int _brushSize;
        private Color _color;

        public PDrawRect(PictureBoxObj drawBox, Point startPoint, int brushSize, Color color)
        {
            _picture = drawBox;
            _picture.BackColor = Color.Transparent;

            _brushSize = brushSize < 1 ? 1 : brushSize;
            _color = color;

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
            RectObject rect = new RectObject();
            rect.Picture = _picture;
            rect.BrushColor = _color;
            rect.BrushSize = _brushSize;

            rect.SizeX = Math.Abs(pX - _startX);
            rect.SizeY = Math.Abs(pY - _startY);

            rect.LocationX = pX < _startX ? pX : _startX;
            rect.LocationY = pY < _startY ? pY : _startY;
            return rect;
        }

        public static void Draw(DrawObject drawObj)
        {
            RectObject rect = drawObj as RectObject;
            if (rect == null || rect.Picture == null) return;

            rect.Picture.Width = rect.SizeX;
            rect.Picture.Height = rect.SizeY;
            rect.Picture.Location = new Point(rect.LocationX, rect.LocationY);

            Bitmap bm = new Bitmap(rect.SizeX <= 0 ? 1 : rect.SizeX, rect.SizeY <= 0 ? 1 : rect.SizeY);
            using (Graphics gr = Graphics.FromImage(bm)){
                gr.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(0, 0, bm.Width, bm.Height));

                if ((PictureBoxStatus.IsDrawable & rect.Picture.Status) == PictureBoxStatus.IsDrawable){
                    using (Pen pen = new Pen(new SolidBrush(rect.BrushColor), rect.BrushSize))
                    {
                        gr.DrawRectangle(pen, new Rectangle(rect.BrushSize / 2, rect.BrushSize / 2, rect.SizeX - rect.BrushSize, rect.SizeY - rect.BrushSize));
                    }
                }
            }
            rect.Picture.Image = bm;
        }
    }
}
