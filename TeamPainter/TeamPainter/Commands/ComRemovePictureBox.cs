/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 14.07.2016 14:17:06
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComRemovePictureBox : Command<ArgPictureBoxID>
    {
        private static readonly string stringUID = "AD5F3F0095322602";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComRemovePictureBox).Name;

        public NComRemovePictureBox(Action<IConnector, ArgPictureBoxID> executor) 
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
