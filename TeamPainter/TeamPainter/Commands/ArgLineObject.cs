/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 13.07.2016 23:58:59
*/

using System;
using System.Drawing;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class ArgLineObject : ICommandArg
    {
        public long CommandID
        {
            get { return NComDrawByLine.uniqueID; }
        }

        public long CliendID;
        public long PictureBoxID;

        public LineObject Line;

        public ArgLineObject() { }
        public ArgLineObject(long clientID, long pictureID, LineObject line)
        {
            if (line == null) { throw new ArgumentNullException("line is null"); }

            CliendID = clientID;
            PictureBoxID = pictureID;

            Line = line;
        }

        public byte[] Pack(int headerOffset)
        {
            BytePacketWriter bp = new BytePacketWriter(headerOffset + 64);

            bp.CurrentPosition = headerOffset;
            bp.Write(CommandID);
            bp.Write(CliendID);
            bp.Write(PictureBoxID);

            bp.Write(Line.BrushColor.R);
            bp.Write(Line.BrushColor.G);
            bp.Write(Line.BrushColor.B);
            bp.Write(Line.BrushColor.A);
            bp.Write(Line.BrushSize);
            bp.Write(Line.SizeX);
            bp.Write(Line.SizeY);

            bp.Write(Line.LocationX);
            bp.Write(Line.LocationY);
            bp.Write(Line.LinePoint1X);
            bp.Write(Line.LinePoint1Y);

            bp.Write(Line.LinePoint2X);
            bp.Write(Line.LinePoint2Y);

            return bp.GetPacket();
        }

        public bool UnPack(byte[] pack)
        {
            if (pack == null || pack.Length < 64) return false;
            int ptr = 8;
            CliendID = BytePacketReader.ReadLong(pack, ref ptr);
            PictureBoxID = BytePacketReader.ReadLong(pack, ref ptr);

            Line = new LineObject();

            byte cR = BytePacketReader.ReadByte(pack, ref ptr);
            byte cG = BytePacketReader.ReadByte(pack, ref ptr);
            byte cB = BytePacketReader.ReadByte(pack, ref ptr);
            byte cA = BytePacketReader.ReadByte(pack, ref ptr);
            Line.BrushColor = Color.FromArgb(cA, cR, cG, cB);

            Line.BrushSize = BytePacketReader.ReadInt(pack, ref ptr);
            Line.SizeX = BytePacketReader.ReadInt(pack, ref ptr);
            Line.SizeY = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LocationX = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LocationY = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LinePoint1X = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LinePoint1Y = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LinePoint2X = BytePacketReader.ReadInt(pack, ref ptr);
            Line.LinePoint2Y = BytePacketReader.ReadInt(pack, ref ptr);

            return true;
        }
    }
}
