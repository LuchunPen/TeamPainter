/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 26.07.2016 1:23:55
*/

using System;
using System.Net;
using System.IO;

using Nano3;
using Nano3.Net;
namespace TeamPainter
{
    public class TeamPainterClientConfig
    {
        private static string _iniName = "config";
        private static string _configSection = "TeamPainter";
        private static string _ipIni = "Remote_IP";
        private static string _portIni = "Remote_port";
        private static string _updIntervalIni = "Update_picture_interval";
        private static string _mspIntervalIni = "Min_send_packet_interval";
        private static string _mspSizeIni = "Min_send_packet_size";

        private IPEndPoint _remoteEndPoint = NetHelper.GetIPEndPoint("127.0.0.1", "22000");
        public IPEndPoint RemoteEndPoint
        {
            get { return _remoteEndPoint; }
            set
            {
                if (value == null) { return; }
                else { _remoteEndPoint = value; }
            }
        }
        private int _pictureUpdateInterval = 30;
        public int PictureUpdateInterval
        {
            get { return _pictureUpdateInterval; }
            set
            {
                if (_pictureUpdateInterval < 1) { return; }
                else { _pictureUpdateInterval = value; }
            }
        }
        private int _sendPacketInterval = 30;
        public int SendPacketInterval
        {
            get { return _sendPacketInterval; }
            set
            {
                if (value < 1) { return; }
                _sendPacketInterval = value;
            }
        }
        private int _sendPacketSize = 1024;
        public int SendPacketSize
        {
            get { return _sendPacketSize; }
            set
            {
                if (value < 16) { return; }
                else { _sendPacketSize = value; }
            }
        }

        public static TeamPainterClientConfig FromIni()
        {
            TeamPainterClientConfig cfg = new TeamPainterClientConfig();
            IniFile ini = IniFile.Load(Environment.CurrentDirectory, _iniName);
            ini.DefaultSection = _configSection;

            string ip = ini.ReadValue(_ipIni);
            string port = ini.ReadValue(_portIni);
            string updatePI_s = ini.ReadValue(_updIntervalIni);
            string packSize_s = ini.ReadValue(_mspSizeIni);
            string packInterval_s = ini.ReadValue(_mspIntervalIni);

            try
            {
                IPEndPoint endPoint = NetHelper.GetIPEndPoint(ip, port);
                if (endPoint != null) { cfg.RemoteEndPoint = endPoint; }
            }
            catch (Exception ex) {  }

            int updateinterval = 0;
            bool upi = int.TryParse(updatePI_s, out updateinterval);
            if (upi) { cfg.PictureUpdateInterval = updateinterval; }

            int packInt = 0;
            bool pi = int.TryParse(packInterval_s, out packInt);
            if (pi) { cfg.SendPacketInterval = packInt; }

            int packSize = 0;
            bool ps = int.TryParse(packSize_s, out packSize);
            if (ps) { cfg.SendPacketSize = packSize; }

            return cfg;
        }

        public bool Save()
        {
            string ip = _remoteEndPoint.Address.ToString();
            string port = _remoteEndPoint.Port.ToString();
            string updatePI_s = _pictureUpdateInterval.ToString();
            string packSize_s = _sendPacketSize.ToString();
            string packInterval_s = _sendPacketInterval.ToString();

            try
            {
                IniFile ini = new IniFile(_iniName);
                ini.DefaultSection = _configSection;

                ini.Write(_ipIni, ip);
                ini.Write(_portIni, port);
                ini.Write(_updIntervalIni, updatePI_s);
                ini.Write(_mspIntervalIni, packInterval_s);
                ini.Write(_mspSizeIni, packSize_s);

                ini.Save(Environment.CurrentDirectory);

                return true;
            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
                return false;
            }
        }
    }
}
