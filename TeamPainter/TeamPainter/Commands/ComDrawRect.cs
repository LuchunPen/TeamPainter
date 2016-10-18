/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 15.07.2016 10:44:13
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComDrawRect : Command<ArgRectObject>
    {
        private static readonly string stringUID = "BD605EC47932CA01";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComDrawRect).Name;

        public NComDrawRect(Action<IConnector, ArgRectObject> executor) 
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
