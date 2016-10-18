/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 12.07.2016 18:09:45
*/

using System;
using System.Windows.Forms;
using System.Drawing;

namespace TeamPainter
{
    public class PDrawEllipse : IPaintTool
    {
        private PictureBoxObj _picture;

        private int _startX;
        private int _startY;

        private int _brushSize;
        private Color _color;

        public PDrawEllipse(PictureBoxObj drawBox, Point startPoint, int brushSize, Color color)
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
            EllipseObject ellipse = new EllipseObject();
            ellipse.Picture = _picture;
            ellipse.BrushColor = _color;
            ellipse.BrushSize = _brushSize;

            ellipse.SizeX = Math.Abs(pX - _startX);
            ellipse.SizeY = Math.Abs(pY - _startY);

            ellipse.LocationX = pX < _startX ? pX : _startX;
            ellipse.LocationY = pY < _startY ? pY : _startY;
            return ellipse;
        }

        public static void Draw(DrawObject drawObj)
        {
            EllipseObject ellipse = drawObj as EllipseObject;
            if (ellipse == null || ellipse.Picture == null) return;

            ellipse.Picture.Width = ellipse.SizeX;
            ellipse.Picture.Height = ellipse.SizeY;
            ellipse.Picture.Location = new Point(ellipse.LocationX, ellipse.LocationY);

            Bitmap bm = new Bitmap(ellipse.SizeX <= 0 ? 1 : ellipse.SizeX, ellipse.SizeY <= 0 ? 1 : ellipse.SizeY);
            using (Graphics gr = Graphics.FromImage(bm)){
                gr.FillRectangle(new SolidBrush(Color.Transparent), new Rectangle(0, 0, bm.Width, bm.Height));

                if ((PictureBoxStatus.IsDrawable & ellipse.Picture.Status) == PictureBoxStatus.IsDrawable){
                    using (Pen pen = new Pen(new SolidBrush(ellipse.BrushColor), ellipse.BrushSize))
                    {
                        gr.DrawEllipse(pen, new Rectangle(ellipse.BrushSize / 2, ellipse.BrushSize / 2, ellipse.SizeX - ellipse.BrushSize, ellipse.SizeY - ellipse.BrushSize));
                    }
                }
            }
            ellipse.Picture.Image = bm;
        }
    }
}
