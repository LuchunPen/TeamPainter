/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 12.07.2016 15:53:48
*/

using System;
using System.Windows.Forms;
using System.Drawing;


namespace TeamPainter
{
    public class PBrushTool : IPaintTool
    {
        private PictureBoxObj _picture;

        private int? _startX = null;
        private int? _startY = null;

        private int _brushSize;
        private Color _color;

        public PBrushTool(PictureBoxObj drawBox, int brushSize, Color color)
        {
            _brushSize = brushSize < 1 ? 1 : brushSize;
            _color = color;
            _picture = drawBox;
        }

        public DrawObject Draw(int pX, int pY)
        {
            DrawObject drOBj = GetDrawObject(pX, pY);
            //Draw(drOBj);

            return drOBj;
        }

        public DrawObject GetDrawObject(int pX, int pY)
        {
            BrushLineObject line = new BrushLineObject();
            line.Picture = _picture;
            line.BrushColor = _color;
            line.BrushSize = _brushSize;

            if (_startX == null) _startX = pX;
            if (_startY == null) _startY = pY;

            int endX = pX; int endY = pY;

            line.LineStartX = _startX ?? endX;
            line.LineStartY = _startY ?? endY;
            line.LineEndX = endX;
            line.LineEndY = endY;

            _startX = endX; _startY = endY;

            return line;
        }

        public static void Draw(DrawObject drawObj)
        {
            BrushLineObject line = drawObj as BrushLineObject;
            if (line == null || line.Picture == null || line.Picture.Image == null) return;
            if (line.Picture.Status != PictureBoxStatus.Canvas) return;
            using (Graphics gr = Graphics.FromImage(line.Picture.Image))
            {
                using (Pen pen = new Pen(new SolidBrush(line.BrushColor), line.BrushSize)){
                    gr.DrawLine(pen, new Point(line.LineStartX, line.LineStartY), new Point(line.LineEndX, line.LineEndY));
                }
                //чтобы не было разрывов между линиями
                using (Brush br = new SolidBrush(line.BrushColor)){
                    gr.FillEllipse(br, line.LineEndX - line.BrushSize / 2, line.LineEndY - line.BrushSize / 2, line.BrushSize, line.BrushSize);
                }
            }
            line.Picture.Invalidate();
        }
    }
}
