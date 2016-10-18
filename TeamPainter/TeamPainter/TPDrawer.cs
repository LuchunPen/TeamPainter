/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 15.07.2016 13:26:38
*/

using System;

namespace TeamPainter
{
    public class TPDrawer : IToolDrawer
    {
        public bool Draw(DrawObject drawObj)
        {
            if (drawObj == null) return false;

            if (drawObj is BrushLineObject) { PBrushTool.Draw(drawObj); return true; }
            else if (drawObj is LineObject) { PDrawLine.Draw(drawObj); return true; }
            else if (drawObj is RectObject) { PDrawRect.Draw(drawObj); return true; }
            else if (drawObj is EllipseObject) { PDrawEllipse.Draw(drawObj); return true; }
            else if (drawObj is MoveObject) { PMoveTool.Draw(drawObj); return true; }
            else if (drawObj is SelectorObject) { PSelectorRect.Draw(drawObj); return true; }

            return false;
        }
    }
}
