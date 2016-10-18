/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 26.07.2016 3:17:10
*/

using System;
using System.IO;
using System.Net;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class TeamPainterHostConfig
    {
        private static string _iniName = "config";
        private static string _configSection = "TeamPainterHost";

        private static string _ipIni = "Remote_IP";
        private static string _portIni = "Remote_port";
        private static string _updIntervalIni = "Update_picture_interval";
        private static string _maxClientIni = "Max_clients";
        private static string _clPingIni = "Client_ping_interval";

        private IPEndPoint _TCPListenAddress = NetHelper.GetIPEndPoint("127.0.0.1", "22000");
        public IPEndPoint TCPListenAddress
        {
            get { return _TCPListenAddress; }
            set
            {
                if (value == null) { return; }
                else { _TCPListenAddress = value; }
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

        private int _maxClients = 10;
        public int MaxClients
        {
            get { return _maxClients; }
            set
            {
                if (value < 1) { return; }
                else { _maxClients = value; }
            }
        }

        private int _pingInterval = 5000;
        public int PingInterval
        {
            get { return _pingInterval; }
            set
            {
                if (value < 1000) { return; }
                else { _pingInterval = value; }
            }
        }

        public static TeamPainterHostConfig FromIni()
        {
            TeamPainterHostConfig cfg = new TeamPainterHostConfig();
            IniFile ini = IniFile.Load(Environment.CurrentDirectory, _iniName);
            ini.DefaultSection = _configSection;

            string ip = ini.ReadValue(_ipIni);
            string port = ini.ReadValue(_portIni);
            string updatePI_s = ini.ReadValue(_updIntervalIni);
            string maxCl_s = ini.ReadValue(_maxClientIni);
            string ping_s = ini.ReadValue(_clPingIni);

            try
            {
                IPEndPoint endPoint = NetHelper.GetIPEndPoint(ip, port);
                if (endPoint != null) { cfg.TCPListenAddress = endPoint; }
            }
            catch (Exception ex) { }

            int val = 0;
            bool ok = int.TryParse(updatePI_s, out val);
            if (ok) { cfg.PictureUpdateInterval = val; }

            ok = int.TryParse(maxCl_s, out val);
            if (ok) { cfg.MaxClients = val; }

            ok = int.TryParse(ping_s, out val);
            if (ok) { cfg.PingInterval = val; }

            return cfg;
        }

        public bool Save()
        {
            string ip = _TCPListenAddress.Address.ToString();
            string port = _TCPListenAddress.Port.ToString();
            string updatePI_s = _pictureUpdateInterval.ToString();
            string maxCl_s = _maxClients.ToString();
            string ping_s = _pingInterval.ToString();

            try
            {
                IniFile ini = new IniFile(_iniName);
                ini.DefaultSection = _configSection;

                ini.Write(_ipIni, ip);
                ini.Write(_portIni, port);
                ini.Write(_updIntervalIni, updatePI_s);
                ini.Write(_maxClientIni, maxCl_s);
                ini.Write(_clPingIni, ping_s);

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
