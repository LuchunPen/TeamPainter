﻿/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 19.07.2016 22:13:50
*/

using System;

using System.Net;
using System.Net.Sockets;

using Nano3;
using Nano3.Net;

namespace TeamPainter
{
    public class TeamPainterNetClient
    {
        public event EventHandlerArg<IConnector> ConnectEvent;
        public event EventHandlerArg<object> DisconnectEvent;

        private bool _isActive;
        public bool Active { get { return _isActive; } }

        private CommandStorage _commands;
        public CommandStorage Commands { get { return _commands; } }

        private ATCPConnector _TCP;
        public IConnector Connector { get { return _TCP; } }

        private long _clientID;
        public long ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }

        public TeamPainterNetClient()
        {
            _commands = new CommandStorage();
            _isActive = false;
        }

        public void Connect(object connectParam)
        {
            if (_isActive){
                NetLogger.Log("TCP client is already connected");
                return;
            }
            IPEndPoint endPoint = connectParam as IPEndPoint;
            if (endPoint == null){ throw new ArgumentNullException("Incorrect connect param"); }

            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.BeginConnect(endPoint, OnConnectCallback, sock);
        }

        private void OnConnectCallback(IAsyncResult ar)
        {
            Socket sock = (Socket)ar.AsyncState;
            if (sock == null) return;

            IPEndPoint ep = null;
            try
            {
                sock.EndConnect(ar);
                ep = sock.RemoteEndPoint as IPEndPoint;

                _TCP = new ATCPConnector(sock, Uid64.CreateNewSync().Data, NetHelper.READ_BUFFER_BIG);
                _TCP.DisconnectEvent += OnDisconnectEventHandler;
                _TCP.ReceiveAction += OnReceveDataHandler;
                _TCP.ReceiveComAction += OnReceiveCommandHandler;
            }
            catch (SocketException ex){
                sock.Close();
                sock = null;
                NetLogger.Log(ex);
                return;
            }

            _isActive = true;
            if (ep != null) { NetLogger.Log("Connected to " + sock.RemoteEndPoint); }
            ConnectEvent?.Invoke(this, _TCP);
        }

        private void OnReceveDataHandler(IConnector connector, byte[] data)
        {
            try
            {
                if (connector != null) { _commands.Execute(connector, data); }
            }
            catch (Exception ex) { NetLogger.Log(ex.ToString(), LogType.Exception); }
        }
        private void OnReceiveCommandHandler(IConnector connector, ICommandArg arg)
        {
            try
            {
                if (connector != null) { _commands.Execute(connector, arg); }
            }
            catch (Exception ex) { NetLogger.Log(ex, LogType.Exception); }
        }

        public void Disconnect()
        {
            if (_TCP == null){
                NetLogger.Log("TCP connection module is not connected");
                return;
            }
            _TCP.Disconnect();
            
        }

        private void OnDisconnectEventHandler(object sender, object disconnectState)
        {
            _TCP.DisconnectEvent -= OnDisconnectEventHandler;
            _TCP.ReceiveAction -= OnReceveDataHandler;
            _TCP.ReceiveComAction -= OnReceiveCommandHandler;

            _clientID = 0;
            _isActive = false;

            string s = "Disconnected ";
            if (disconnectState != null) { s += disconnectState.ToString(); }
            NetLogger.Log(s);

            DisconnectEvent?.Invoke(_TCP, disconnectState);
            _TCP = null;
        }
    }
}
