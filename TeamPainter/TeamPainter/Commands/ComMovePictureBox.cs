/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 14.07.2016 15:58:09
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComMovePictureBox : Command<ArgMoveObject>
    {
        private static readonly string stringUID = "DD5F56FEC03B1204";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComMovePictureBox).Name;

        public NComMovePictureBox(Action<IConnector, ArgMoveObject> executor) 
            : base(executor) { }

        public override long UniqueID
        {
            get { return uniqueID; }
        }
        public override string Description
        {
            get { return null; }
        }
        public override string Name
        {
            get { return name; }
        }
    }
}
