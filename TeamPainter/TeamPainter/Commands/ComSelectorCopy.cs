/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 17.07.2016 0:10:03
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComSelectorCopy : Command<ArgSelectorCopyObject>
    {
        private static readonly string stringUID = "DD626D243C628301";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComSelectorCopy).Name;

        public NComSelectorCopy(Action<IConnector, ArgSelectorCopyObject> executor) 
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
