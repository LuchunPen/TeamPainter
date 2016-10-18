/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 15.07.2016 21:31:14
*/

using System;
using System.Collections.Generic;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{ 
    public class ArgUniqueID : ICommandArg
    {
        private long _commandID;
        public long CommandID
        {
            get { return _commandID; }
        }

        public long UniqueID;

        public ArgUniqueID() { }
        public ArgUniqueID(long commandID) { _commandID = commandID; }

        public byte[] Pack(int headerOffset)
        {
            BytePacketWriter bp = new BytePacketWriter(headerOffset + 16);
            bp.Write(_commandID);
            bp.Write(UniqueID);
            return bp.GetPacket();
        }

        public bool UnPack(byte[] pack)
        {
            if (pack == null || pack.Length < 16) return false;

            int ptr = 0;
            _commandID = BytePacketReader.ReadLong(pack, ref ptr);
            UniqueID = BytePacketReader.ReadLong(pack, ref ptr);

            return true;
        }
    }

}
