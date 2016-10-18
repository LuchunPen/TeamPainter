/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 13.07.2016 18:26:00
*/

using System;
using System.Drawing;
using System.IO;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class ArgNewPictureBox : ICommandArg
    {
        private long _commandID;
        public long CommandID
        {
            get { return _commandID; }
        }

        private long _clientID;
        public long ClientID { get { return _clientID; } }

        public long PictureBoxID;

        public int LocationX;
        public int LocationY;

        public int PBSizeX;
        public int PBSizeY;

        public Image PBImage;

        public ArgNewPictureBox() { }
        public ArgNewPictureBox(long commandID, long clientID)
        {
            _clientID = clientID;
            _commandID = commandID;
        }

        public byte[] Pack(int headerOffset)
        {
            BytePacketWriter bp = new BytePacketWriter(headerOffset + 32);
            bp.CurrentPosition = headerOffset;
            bp.Write(CommandID);
            bp.Write(_clientID);
            bp.Write(PictureBoxID);

            bp.Write(LocationX);
            bp.Write(LocationY);

            bp.Write(PBSizeX);
            bp.Write(PBSizeY);

            if (PBImage != null)
            {
                using (MemoryStream str = new MemoryStream())
                {
                    PBImage.Save(str, System.Drawing.Imaging.ImageFormat.Png);
                    str.Close();
                    bp.Write(str.ToArray());
                }
            }

            return bp.GetPacket();
        }

        public bool UnPack(byte[] pack)
        {
            if (pack == null || pack.Length < 32) return false;
            int ptr = 0;

            _commandID = BytePacketReader.ReadLong(pack, ref ptr);
            _clientID = BytePacketReader.ReadLong(pack, ref ptr);
            PictureBoxID = BytePacketReader.ReadLong(pack, ref ptr);

            LocationX = BytePacketReader.ReadInt(pack, ref ptr);
            LocationY = BytePacketReader.ReadInt(pack, ref ptr);

            PBSizeX = BytePacketReader.ReadInt(pack, ref ptr);
            PBSizeY = BytePacketReader.ReadInt(pack, ref ptr);

            if (pack.Length == ptr) { return true; }

            byte[] imageBP = BytePacketReader.ReadPacket(pack, ref ptr);
            using (MemoryStream str = new MemoryStream(imageBP))
            {
                PBImage = Image.FromStream(str);
            }
            return true;
        }
    }
}
