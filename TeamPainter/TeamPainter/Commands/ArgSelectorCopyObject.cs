/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 17.07.2016 0:25:07
*/

using System;
using System.Collections.Generic;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class ArgSelectorCopyObject : ICommandArg
    {
        public long CommandID
        {
            get { return NComSelectorCopy.uniqueID; }
        }

        private long _clientID;
        public long ClientID { get { return _clientID; } }

        public long PictureBoxID;

        public SelectorObject Selector;

        public ArgSelectorCopyObject() { }
        public ArgSelectorCopyObject(long clientID, long pictureID, SelectorObject selectorObj)
        {
            if (selectorObj == null) { throw new ArgumentNullException("Selector object is null"); }
            _clientID = clientID;
            Selector = selectorObj;
            PictureBoxID = pictureID;
        }

        public byte[] Pack(int headerOffset)
        {
            BytePacketWriter bp = new BytePacketWriter(headerOffset + 42);

            bp.CurrentPosition = headerOffset;
            bp.Write(CommandID);
            bp.Write(ClientID);
            bp.Write(PictureBoxID);

            bp.Write(Selector.LocationX);
            bp.Write(Selector.LocationY);
            bp.Write(Selector.SizeX);
            bp.Write(Selector.SizeY);
            bp.Write(Selector.CutObject);
            bp.Write(Selector.NeedCopy);

            return bp.GetPacket();
        }

        public bool UnPack(byte[] pack)
        {
            if (pack == null || pack.Length < 42) return false;
            int ptr = 8;
            _clientID = BytePacketReader.ReadLong(pack, ref ptr);
            PictureBoxID = BytePacketReader.ReadLong(pack, ref ptr);

            Selector = new SelectorObject();
            Selector.LocationX = BytePacketReader.ReadInt(pack, ref ptr);
            Selector.LocationY = BytePacketReader.ReadInt(pack, ref ptr);
            Selector.SizeX = BytePacketReader.ReadInt(pack, ref ptr);
            Selector.SizeY = BytePacketReader.ReadInt(pack, ref ptr);
            Selector.CutObject = BytePacketReader.ReadBoolean(pack, ref ptr);
            Selector.NeedCopy = BytePacketReader.ReadBoolean(pack, ref ptr);

            return true;
        }
    }
}
