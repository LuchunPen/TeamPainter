/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 12.07.2016 20:37:47
*/

using System;
using System.Windows.Forms;
using System.Drawing;

using Nano3;

namespace TeamPainter
{
    public class PDrawLine : IPaintTool
    {
        private PictureBoxObj _picture;

        private int _startX;
        private int _startY;

        private int _brushSize;
        private Color _color;

        public PDrawLine(PictureBoxObj drawBox, Point startPoint, int brushSize, Color color)
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
            LineObject line = new LineObject();
            line.Picture = _picture;
            line.BrushColor = _color;
            line.BrushSize = _brushSize;

            line.SizeX = Math.Abs(pX - _startX); if (line.SizeX < line.BrushSize) { line.SizeX = line.BrushSize; }
            line.SizeY = Math.Abs(pY - _startY); if (line.SizeY < line.BrushSize) { line.SizeY = line.BrushSize; }
            int LocationX = pX < _startX ? pX : _startX;
            line.LocationX = line.SizeX == line.BrushSize ? LocationX - line.BrushSize / 2 : LocationX;

            int LocationY = pY < _startY ? pY : _startY;
            line.LocationY = line.SizeY == line.BrushSize ? LocationY - line.BrushSize / 2 : LocationY;

            Point p1 = _picture.PointToScreen(new Point(_startX - LocationX, _startY - LocationY));
            Point linePoint1 = _picture.PointToClient(p1);
            Point p2 = _picture.PointToScreen(new Point(pX - LocationX, pY - LocationY));
            Point linePoint2 = _picture.PointToClient(p2);

            line.LinePoint1X = linePoint1.X;
            line.LinePoint1Y = linePoint1.Y;
            line.LinePoint2X = linePoint2.X;
            line.LinePoint2Y = linePoint2.Y;

            return line;
        }

        public static void Draw(DrawObject drawObj)
        {
            LineObject line = drawObj as LineObject;
            if (line == null || line.Picture == null ) return;

            line.Picture.Width = line.SizeX;
            line.Picture.Height = line.SizeY;
            line.Picture.Location = new Point(line.LocationX, line.LocationY);

            Bitmap bm = new Bitmap(line.SizeX <= 0 ? 1 : line.SizeX, line.SizeY <= 0 ? 1 : line.SizeY);
            using (Graphics gr = Graphics.FromImage(bm)){
                gr.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(0, 0, bm.Width, bm.Height));

                if ((PictureBoxStatus.IsDrawable & line.Picture.Status) == PictureBoxStatus.IsDrawable) {
                    using (Pen pen = new Pen(new SolidBrush(line.BrushColor), line.BrushSize))
                    {
                        gr.DrawLine(pen, new Point(line.LinePoint1X, line.LinePoint1Y), new Point(line.LinePoint2X, line.LinePoint2Y));
                    }
                }
            }
            line.Picture.Image = bm;
            line.Picture.Invalidate();
        }
    }
}
