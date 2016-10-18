/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 16.07.2016 20:46:50
*/

using System;

namespace TeamPainter
{
    public class SelectorObject : DrawObject
    {
        public PictureBoxObj SourcePicture;
        public bool NeedCopy;
        public bool CutObject;

        public int LocationX;
        public int LocationY;

        public int SizeX;
        public int SizeY;
    }
}
