/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 15.07.2016 21:17:58
*/

using System;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class NComAutorize : Command<ArgComAutorize>
    {
        private static readonly string stringUID = "AD60F348642B1403";
        public static readonly long uniqueID = Uid64.LoadFromString(stringUID).Data;
        public static readonly string name = typeof(NComAutorize).Name;

        public NComAutorize(Action<IConnector, ArgComAutorize> executor)
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

    public class ArgComAutorize : ICommandArg
    {
        public long CommandID
        {
            get { return NComAutorize.uniqueID; }
        }

        public string Login;
        public string Password;

        public byte[] Pack(int headerOffset)
        {
            BytePacketWriter bp = new BytePacketWriter(headerOffset + 8);
            bp.CurrentPosition = headerOffset;

            bp.Write(CommandID);
            bp.Write(Login);
            bp.Write(Password);

            return bp.GetPacket();
        }

        public bool UnPack(byte[] pack)
        {
            if (pack == null || pack.Length < 16) return false;
            int ptr = 8;
            if (pack.Length - ptr >= 8)
            {
                Login = BytePacketReader.ReadString(pack, ref ptr);
                Password = BytePacketReader.ReadString(pack, ref ptr);
            }
            return true;
        }
    }
}
