/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 14.07.2016 18:05:42
*/

using System;
using System.Collections.Generic;

namespace TeamPainter
{
    public class DrawObjectList
    {
        private long _pictureBoxID;
        public long PictureBoxID { get { return _pictureBoxID; } }

        private List<DrawObject> _drawActions;
        private object _daSync;

        public DrawObjectList(long pictureBoxID)
        {
            _pictureBoxID = pictureBoxID;
            _drawActions = new List<DrawObject>();
            _daSync = new object();
        }

        public void AddDrawObject(DrawObject drObj)
        {
            if (drObj == null) return;
            lock (_daSync) { _drawActions.Add(drObj); }
        }

        public List<DrawObject> GetAllDrawObjects()
        {
            lock (_daSync)
            {
                List<DrawObject> result = _drawActions;
                _drawActions = new List<DrawObject>();

                return result;
            }
        }

        public void Clear()
        {
            lock (_daSync) { _drawActions.Clear(); }
        }
    }
}
