/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 15.07.2016 10:55:51
*/

using System;
using System.Drawing;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class ArgEllipseObject : ICommandArg
    {
        public long CommandID
        {
            get { return NComDrawEllipse.uniqueID; }
        }

        public long CliendID;
        public long PictureBoxID;

        public EllipseObject Rect;

        public ArgEllipseObject() { }
        public ArgEllipseObject(long clientID, long pictureID, EllipseObject rect)
        {
            if (rect == null) { throw new ArgumentNullException("ellipse is null"); }

            CliendID = clientID;
            PictureBoxID = pictureID;

            Rect = rect;
        }

        public byte[] Pack(int headerOffset)
        {
            BytePacketWriter bp = new BytePacketWriter(headerOffset + 48);

            bp.CurrentPosition = headerOffset;
            bp.Write(CommandID);
            bp.Write(CliendID);
            bp.Write(PictureBoxID);

            bp.Write(Rect.BrushColor.R);
            bp.Write(Rect.BrushColor.G);
            bp.Write(Rect.BrushColor.B);
            bp.Write(Rect.BrushColor.A);
            bp.Write(Rect.BrushSize);

            bp.Write(Rect.LocationX);
            bp.Write(Rect.LocationY);
            bp.Write(Rect.SizeX);
            bp.Write(Rect.SizeY);

            return bp.GetPacket();
        }

        public bool UnPack(byte[] pack)
        {
            if (pack == null || pack.Length < 48) return false;
            int ptr = 8;
            CliendID = BytePacketReader.ReadLong(pack, ref ptr);
            PictureBoxID = BytePacketReader.ReadLong(pack, ref ptr);

            Rect = new EllipseObject();
            byte cR = BytePacketReader.ReadByte(pack, ref ptr);
            byte cG = BytePacketReader.ReadByte(pack, ref ptr);
            byte cB = BytePacketReader.ReadByte(pack, ref ptr);
            byte cA = BytePacketReader.ReadByte(pack, ref ptr);
            Rect.BrushColor = Color.FromArgb(cA, cR, cG, cB);

            Rect.BrushSize = BytePacketReader.ReadInt(pack, ref ptr);
            Rect.LocationX = BytePacketReader.ReadInt(pack, ref ptr);
            Rect.LocationY = BytePacketReader.ReadInt(pack, ref ptr);
            Rect.SizeX = BytePacketReader.ReadInt(pack, ref ptr);
            Rect.SizeY = BytePacketReader.ReadInt(pack, ref ptr);
            return true;
        }
    }
}
