/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 21.07.2016 18:06:06
*/

using System;

using Nano3;
using Nano3.Net;
using Nano3.Collection;

namespace TeamPainter
{
    public class TPHostAutorizator
    {
        private ATCPListenModule _listener;
        public ATCPListenModule Listener { get { return _listener; } }

        public event EventHandlerArg<IConnector> NewConnectionEvent;
        public event EventHandlerArg<object> DisconnectEvent;

        private CommandStorage _commands = new CommandStorage();
        public CommandStorage Commands { get { return _commands; } }

        private FastDictionaryM2<long, IConnector> _connectors = new FastDictionaryM2<long, IConnector>();
        private object _cSync = new object();

        private int _maxCount;
        public int MaxCount { get { return _maxCount; } }

        public TPHostAutorizator(int maxCount)
        {
            _maxCount = maxCount;
            _listener = new ATCPListenModule(Uid64.CreateNew().Data, NetHelper.READ_BUFFER_BIG);
            _listener.NewConnectionEvent += OnNewConnectionHandler;
        }

        public void Stop()
        {
            if (_listener.IsActive) { _listener.Stop(null); }
            DisconnectAll();
        }

        public IConnector GetConnector(long connectionID)
        {
            lock (_cSync)
            {
                IConnector con = null;
                _connectors.TryGetValue(connectionID, out con);
                return con;
            }
        }
        public IConnector[] GetAllConnector()
        {
            lock (_cSync) {
                return _connectors.GetValues();
            }
        }
        public IConnector RemoveConnector(long connectionID)
        {
            IConnector con = null;
            lock (_cSync){
                _connectors.TryGetAndRemove(connectionID, out con);
            }
            if (con != null)
            {
                con.DisconnectEvent -= OnConnectorDisconnectHandler;
                con.ReceiveAction -= OnReceveDataHandler;
                con.ReceiveComAction -= OnReceiveCommandHandler;
                return con;
            }

            return null;
        }

        private void DisconnectAll()
        {
            IConnector[] cons = null;
            lock (_cSync) { cons = _connectors.GetValues(); }
            if(cons != null){
                for (int i = 0; i < cons.Length; i++)
                {
                    if (cons[i] != null){
                        cons[i].Disconnect();
                    }
                }
            }
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

        public void OnNewConnectionHandler(object sender, IConnector connector)
        {
            if (connector == null) return;
            lock (_cSync){
                if (_connectors.Count > _maxCount) { connector.Disconnect(); return; }
                _connectors.Add(connector.UniqueID, connector);
            }
            connector.DisconnectEvent += OnConnectorDisconnectHandler;
            connector.ReceiveAction += OnReceveDataHandler;
            connector.ReceiveComAction += OnReceiveCommandHandler;

            NewConnectionEvent?.Invoke(this, connector);
        }
        public void OnConnectorDisconnectHandler(object sender, object disconnectionState)
        {
            IConnector connector = sender as IConnector;
            if (connector == null) return;

            connector.DisconnectEvent -= OnConnectorDisconnectHandler;
            connector.ReceiveAction -= OnReceveDataHandler;
            connector.ReceiveComAction -= OnReceiveCommandHandler;

            lock (_cSync) {
                _connectors.Remove(connector.UniqueID);
            }

            NetLogger.Log(connector.UniqueID + " disconneted. " + 
                (disconnectionState == null ? "" : disconnectionState.ToString()));

            DisconnectEvent?.Invoke(connector, disconnectionState);
        }
    }
}
