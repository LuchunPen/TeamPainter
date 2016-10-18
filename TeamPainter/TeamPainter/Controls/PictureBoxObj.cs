/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 11.07.2016 21:06:18
*/

using System;
using System.Windows.Forms;

using Nano3;

namespace TeamPainter
{
    public class PictureBoxObj : PictureBox, IUniq
    {
        private long _uniqueID;
        public long UniqueID
        {
            get { return _uniqueID; }
        }

        private long _clientID;
        public long ClientID { get { return _clientID; } }

        private PictureBoxStatus _status;
        public PictureBoxStatus Status { get { return _status; } }

        public PictureBoxObj(long clientID, long pictubeBoxID, PictureBoxStatus status)
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw | ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            _uniqueID = pictubeBoxID;
            _clientID = clientID;

            _status = status;
        }
    }

    [Flags]
    public enum PictureBoxStatus
    {
        Canvas = 0,
        IsMovable = 1,
        IsDrawable = 2,
    }
}
