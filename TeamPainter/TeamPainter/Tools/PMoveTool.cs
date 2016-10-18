/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 12.07.2016 16:39:14
*/

using System;
using System.Windows.Forms;
using System.Drawing;

namespace TeamPainter
{
    public class PMoveTool : IPaintTool
    {
        private PictureBoxObj _picture;

        private int _offsetX;
        private int _offsetY;

        public PMoveTool(PictureBoxObj moveBox, Point mousePoint)
        {
            if(moveBox == null) { throw (new ArgumentNullException("Move box is null")); }

            _picture = moveBox;
            _offsetX = mousePoint.X - moveBox.Location.X;
            _offsetY = mousePoint.Y - moveBox.Location.Y;
        }

        public DrawObject Draw(int pX, int pY)
        {
            DrawObject drOBj = GetDrawObject(pX, pY);
            Draw(drOBj);

            return drOBj;
        }

        public DrawObject GetDrawObject(int pX, int pY)
        {
            MoveObject move = new MoveObject();
            move.Picture = _picture;

            move.OffsetX = _offsetX;
            move.OffsetY = _offsetY;

            move.LocationX = pX;
            move.LocationY = pY;

            return move;
        }

        public static void Draw(DrawObject drawObj)
        {
            MoveObject move = drawObj as MoveObject;
            if (move == null || move.Picture == null) return;

            if ((PictureBoxStatus.IsMovable & move.Picture.Status) == PictureBoxStatus.IsMovable){
                move.Picture.Location = new Point(move.LocationX - move.OffsetX, move.LocationY - move.OffsetY);
            }
        }
    }
}
