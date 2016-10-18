/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 13.07.2016 23:10:43
*/

using System;
using System.Drawing;

namespace TeamPainter
{ 
    public class BrushLineObject : DrawObject
    {
        public Color BrushColor;
        public int BrushSize;

        public int LineStartX;
        public int LineStartY;

        public int LineEndX;
        public int LineEndY;
    }
}
