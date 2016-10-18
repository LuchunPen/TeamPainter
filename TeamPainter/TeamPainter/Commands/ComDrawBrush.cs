/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 13.07.2016 23:01:31
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComDrawByBrush : Command<ArgBrushObject>
    {
        private static readonly string stringUID = "CD5E68948E584501";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComDrawByBrush).Name;

        public NComDrawByBrush(Action<IConnector, ArgBrushObject> executor) 
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
