/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 13.07.2016 17:41:07
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComCreateNewPictureBox : Command<ArgNewPictureBox>
    {
        private static readonly string stringUID = "AD5E1D4C1731FC02";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComCreateNewPictureBox).Name;

        public NComCreateNewPictureBox(Action<IConnector, ArgNewPictureBox> executor) 
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
