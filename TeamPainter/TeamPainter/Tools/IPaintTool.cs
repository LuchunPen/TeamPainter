/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 12.07.2016 15:51:01
*/

using System;

namespace TeamPainter
{
    public interface IPaintTool
    {
        DrawObject Draw(int pX, int pY);
        DrawObject GetDrawObject(int pX, int pY);
    }
}
