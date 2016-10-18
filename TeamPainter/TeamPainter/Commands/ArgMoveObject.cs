/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 14.07.2016 15:58:44
*/

using System;
using System.Collections.Generic;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class ArgMoveObject : ICommandArg
    {
        public long CommandID
        {
            get { return NComMovePictureBox.uniqueID; }
        }
        private long _clientID;
        public long ClientID { get { return _clientID; } }

        public ArgMoveObject() { }
        public ArgMoveObject(long clientID, long pictureBoxID, MoveObject moveObj)
        {
            if (moveObj == null) { throw new ArgumentNullException("move object is null"); }
            _clientID = clientID;
            MoveObj = moveObj;
            PictureBoxID = pictureBoxID;
        }
        public long PictureBoxID;

        public MoveObject MoveObj;

        public byte[] Pack(int headerOffset)
        {
            BytePacketWriter bp = new BytePacketWriter(headerOffset + 40);
            bp.CurrentPosition = headerOffset;
            bp.Write(CommandID);
            bp.Write(_clientID);
            bp.Write(PictureBoxID);
            bp.Write(MoveObj.OffsetX);
            bp.Write(MoveObj.OffsetY);
            bp.Write(MoveObj.LocationX);
            bp.Write(MoveObj.LocationY);

            return bp.GetPacket();
        }

        public bool UnPack(byte[] pack)
        {
            if (pack == null || pack.Length < 40) return false;

            int ptr = 8;
            _clientID = BytePacketReader.ReadLong(pack, ref ptr);
            PictureBoxID = BytePacketReader.ReadLong(pack, ref ptr);

            MoveObj = new MoveObject();
            MoveObj.OffsetX = BytePacketReader.ReadInt(pack, ref ptr);
            MoveObj.OffsetY = BytePacketReader.ReadInt(pack, ref ptr);
            MoveObj.LocationX = BytePacketReader.ReadInt(pack, ref ptr);
            MoveObj.LocationY = BytePacketReader.ReadInt(pack, ref ptr);

            return true;
        }
    }
}
