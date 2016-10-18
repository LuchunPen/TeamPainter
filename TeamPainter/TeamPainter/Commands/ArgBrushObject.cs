/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 13.07.2016 23:50:51
*/

using System;
using System.Drawing;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class ArgBrushObject : ICommandArg
    {
        public long CommandID
        {
            get { return NComDrawByBrush.uniqueID; }
        }

        public long CliendID;
        public long PictureBoxID;

        public BrushLineObject Line;

        public ArgBrushObject() { }
        public ArgBrushObject(long clientID, long pictureBoxID, BrushLineObject line)
        {
            if (line == null) { throw new ArgumentNullException("line is null"); }

            CliendID = clientID;
            PictureBoxID = pictureBoxID;
            Line = line;
        }

        public byte[] Pack(int headerOffset)
        {
            BytePacketWriter bp = new BytePacketWriter(headerOffset + 48);

            bp.CurrentPosition = headerOffset;
            bp.Write(CommandID);
            bp.Write(CliendID);
            bp.Write(PictureBoxID);
            bp.Write(Line.BrushColor.R);
            bp.Write(Line.BrushColor.G);
            bp.Write(Line.BrushColor.B);
            bp.Write(Line.BrushColor.A);
            bp.Write(Line.BrushSize);
            bp.Write(Line.LineStartX);
            bp.Write(Line.LineStartY);
            bp.Write(Line.LineEndX);
            bp.Write(Line.LineEndY);
            bp.Write(new byte[1000]);

            return bp.GetPacket();
        }
        public bool UnPack(byte[] pack)
        {
            if (pack == null || pack.Length < 48) return false;
            int ptr = 8;
            CliendID = BytePacketReader.ReadLong(pack, ref ptr);
            PictureBoxID = BytePacketReader.ReadLong(pack, ref ptr);

            Line = new BrushLineObject();

            byte cR = BytePacketReader.ReadByte(pack, ref ptr);
            byte cG = BytePacketReader.ReadByte(pack, ref ptr);
            byte cB = BytePacketReader.ReadByte(pack, ref ptr);
            byte cA = BytePacketReader.ReadByte(pack, ref ptr);
            Line.BrushColor = Color.FromArgb(cA, cR, cG, cB);

            Line.BrushSize = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LineStartX = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LineStartY = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LineEndX = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LineEndY = BytePacketReader.ReadInt(pack, ref ptr);

            return true;
        }
    }
}
