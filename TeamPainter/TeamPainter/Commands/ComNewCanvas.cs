﻿/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 13.07.2016 14:21:10
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComCreateNewCanvas : Command<ArgNewPictureBox>
    {
        private static readonly string stringUID = "DD5DEEE2C5AF1101";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComCreateNewCanvas).Name;

        public NComCreateNewCanvas(Action<IConnector, ArgNewPictureBox> executor) 
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
