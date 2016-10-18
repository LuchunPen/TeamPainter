/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 14.07.2016 13:59:43
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class ArgPictureBoxID : ICommandArg
    {
        private long _commandID;
        public long CommandID
        {
            get { return _commandID; }
        }

        private long _cliendID;
        public long ClientID { get { return _cliendID; } }

        public long PictureBoxID;

        public ArgPictureBoxID() { }
        public ArgPictureBoxID(long commandID, long clientID)
        {
            _commandID = commandID;
            _cliendID = clientID;
        }

        public byte[] Pack(int headerOffset)
        {
            BytePacketWriter bp = new BytePacketWriter(headerOffset + 24);
            bp.CurrentPosition = headerOffset;
            bp.Write(_commandID);
            bp.Write(_cliendID);
            bp.Write(PictureBoxID);

            return bp.GetPacket();
        }

        public bool UnPack(byte[] pack)
        {
            if (pack == null || pack.Length < 24) return false;
            int ptr = 0;
            _commandID = BytePacketReader.ReadLong(pack, ref ptr);
            _cliendID = BytePacketReader.ReadLong(pack, ref ptr);
            PictureBoxID = BytePacketReader.ReadLong(pack, ref ptr);
            return true;
        }
    }
}
