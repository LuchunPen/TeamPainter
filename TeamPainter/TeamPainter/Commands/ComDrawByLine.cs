/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 13.07.2016 23:55:35
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComDrawByLine : Command<ArgLineObject>
    {
        private static readonly string stringUID = "CD5E7510A1EBD102";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComDrawByLine).Name;

        public NComDrawByLine(Action<IConnector, ArgLineObject> executor) 
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
