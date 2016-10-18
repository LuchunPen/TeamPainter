/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 13.07.2016 23:11:20
*/

using System;
using System.Drawing;

namespace TeamPainter
{
    public class LineObject : DrawObject
    {
        public Color BrushColor;
        public int BrushSize;

        public int SizeX;
        public int SizeY;

        public int LocationX;
        public int LocationY;

        public int LinePoint1X;
        public int LinePoint1Y;
        public int LinePoint2X;
        public int LinePoint2Y;
    }
}
