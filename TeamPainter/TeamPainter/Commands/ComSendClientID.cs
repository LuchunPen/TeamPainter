/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 15.07.2016 21:26:03
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComSendClientID : Command<ArgUniqueID>
    {
        private static readonly string stringUID = "AD60F4FD9DFC8104";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComSendClientID).Name;

        public NComSendClientID(Action<IConnector, ArgUniqueID> executor) 
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
