/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 15.07.2016 13:19:49
*/

using System;

namespace TeamPainter
{
    public interface IToolDrawer
    {
        bool Draw(DrawObject drawObj);
    }

    public static class ToolDrawer
    {
        private static IToolDrawer _drawer;
        public static IToolDrawer Drawer { get { return _drawer; } }

        public static void Initialize(IToolDrawer drawer)
        {
            if (_drawer != null) return;
            if (drawer == null) { throw new ArgumentNullException("Drawer is null"); }
            _drawer = drawer;
        }

        public static bool Draw(DrawObject drawObj)
        {
            if (_drawer != null){
                return _drawer.Draw(drawObj);
            }
            return false;
        }
    }
}
