/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 21.07.2016 15:14:52
*/

using System;
using System.Windows.Forms;

using Nano3;
using Nano3.Net;
namespace TeamPainter
{
    public class TeamPainterTCPClient : IUniq
    {
        private TrafficCounter _traffic;
        public TrafficCounter Traffic
        {
            get { return _traffic; }
        }

        private NetTrafficForm _ntf;
        public NetTrafficForm TrafficForm
        {
            get { return _ntf; }
        }

        private ATCPConnector _connector;
        public IConnector Connector { get { return _connector; } }

        private long _clientID;
        public long UniqueID { get { return _clientID; } }

        private bool _syncronized;
        public bool Syncronized
        {
            get { return _syncronized; }
            set { _syncronized = value; }
        }

        private string _name;
        public string Name { get { return _name; } }

        private int _ping;
        public int Ping
        {
            get { return _ping; }
            set { if (value > 0) _ping = (int)value; }
        }

        public int ConnectorSendBufferSize
        {
            get { return _connector.SendPacketSize; }
            set { _connector.SendPacketSize = value; }
        }
        public double ConnectorSendInterval
        {
            get { return _connector.SendInterval; }
            set { _connector.SendInterval = value; }
        }

        public TeamPainterTCPClient(ATCPConnector connector, long clientID, string name)
        {
            if (connector == null) { throw new ArgumentNullException("Connector is null"); }
            if (clientID == 0) { throw new ArgumentException("Incorrent uniqueID [0]"); }

            _clientID = clientID;
            _name = name;
            _syncronized = false;
            _connector = connector;
            _connector.DisconnectEvent += OnDisconnectEventHandler;
            _traffic = new TrafficCounter(100, 30);
            _traffic.Subscribe(connector);
        }

        public void Disconnect()
        {
            _traffic.UnSubscribe(_connector);
            _connector.Disconnect();
        }

        public void ShowInfo()
        {
            if (_ntf != null) { return; }
            _ntf = new NetTrafficForm();
            _ntf.Text = "Host: " +UniqueID.ToString();
            _ntf.Show();
            _ntf.FormClosing += OnNetTrafficFormClosing;
            _traffic.TrafficDataChanged += _ntf.OnTrafficChangeHandler;
        }

        private void OnDisconnectEventHandler(object sender, object disconnectStatus)
        {
            ATCPConnector connector = sender as ATCPConnector;
            if (connector != null)
            {
                _traffic.UnSubscribe(_connector);
                if (_ntf != null){
                    _ntf.Invoke((MethodInvoker)delegate { _ntf.Close(); });
                }
                connector.DisconnectEvent -= OnDisconnectEventHandler;
            }
        }

        private void OnNetTrafficFormClosing(object sender, EventArgs arg)
        {
            NetTrafficForm ntf = sender as NetTrafficForm;
            if (ntf != null){
                ntf.FormClosing -= OnNetTrafficFormClosing;
                _traffic.TrafficDataChanged -= ntf.OnTrafficChangeHandler;
            }
            _ntf = null;
        }
    }
}
