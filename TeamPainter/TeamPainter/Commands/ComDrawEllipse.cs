/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 15.07.2016 10:53:10
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComDrawEllipse :Command<ArgEllipseObject>
    {
        private static readonly string stringUID = "AD6060ABAD1E4102";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComDrawEllipse).Name;

        public NComDrawEllipse(Action<IConnector, ArgEllipseObject> executor) 
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
