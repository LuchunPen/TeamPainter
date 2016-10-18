/*
Copyright (c) Luchunpen (bwolf88).  All rights reserved.
Date: 21.07.2016 16:02:02
*/

using System;

using Nano3;
using Nano3.Net;
using Nano3.Collection;

namespace TeamPainter
{
    public class TPWorkHost
    {
        public event EventHandlerArg<object> DisconnectEvent;

        private CommandStorage _commands = new CommandStorage();
        public CommandStorage Commands { get { return _commands; } }

        private FastDictionaryM2<long, TeamPainterTCPClient> _clients = new FastDictionaryM2<long, TeamPainterTCPClient>();
        private FastDictionaryM2<long, long> _clientConnectionAssociation = new FastDictionaryM2<long, long>();
        private object _cSync = new object();

        private int _maxClients;
        public int MaxClients;

        public TPWorkHost(int maxClients)
        {
            _maxClients = maxClients < 1 ? 1 : maxClients;
        }
        
        public void Stop()
        {
            DisconnectAll();
        }

        public bool AddClient(TeamPainterTCPClient client)
        {
            if (client == null || client.Connector == null) return false;
            long connectionID = client.Connector.UniqueID;

            lock (_cSync)
            {
                TeamPainterTCPClient regcl;
                _clients.TryGetValue(client.UniqueID, out regcl);

                if (regcl != null){
                    NetLogger.Log("This client is already exist");
                    return false;
                }

                if (_clients.Count >= _maxClients)
                {
                    NetLogger.Log("Max connection");
                    return false;
                }
                
                _clientConnectionAssociation[connectionID] = client.UniqueID;
                _clients[client.UniqueID] = client;

                client.Connector.DisconnectEvent += OnConnectorDisconnectHandler;

                client.Connector.ReceiveAction = null;
                client.Connector.ReceiveAction += OnReceveDataHandler;
                client.Connector.ReceiveComAction = null;
                client.Connector.ReceiveComAction += OnReceiveCommandHandler;
                return true;
            }
        }
        public TeamPainterTCPClient GetClient(long clientID)
        {
            lock (_cSync)
            {
                TeamPainterTCPClient tp;
                _clients.TryGetValue(clientID, out tp);
                return tp;
            }
        }
        public TeamPainterTCPClient GetClientByConnectionID(long connectionID)
        {
            long clientID = 0;
            lock (_cSync)
            {
                _clientConnectionAssociation.TryGetValue(connectionID, out clientID);
                TeamPainterTCPClient tp;
                _clients.TryGetValue(clientID, out tp);
                return tp;
            }
        }
        public TeamPainterTCPClient[] GetAllClients()
        {
            lock (_cSync) { return _clients.GetValues(); }
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
        
        public void OnConnectorDisconnectHandler(object sender, object disconnectionState)
        {
            IConnector connector = sender as IConnector;
            if (connector == null) return;

            connector.DisconnectEvent -= OnConnectorDisconnectHandler;

            TeamPainterTCPClient client = null;
            lock (_cSync)
            {
                long clientID;
                _clientConnectionAssociation.TryGetAndRemove(connector.UniqueID, out clientID);
                _clients.TryGetAndRemove(clientID, out client);
            }
            if (client != null)
            {
                client.Connector.DisconnectEvent -= OnConnectorDisconnectHandler;
                client.Connector.ReceiveAction -= OnReceveDataHandler;
                client.Connector.ReceiveComAction -= OnReceiveCommandHandler;
            }
            NetLogger.Log(connector.UniqueID + " is disconnected");

            DisconnectEvent?.Invoke(client, disconnectionState);
        }
        private void DisconnectAll()
        {
            TeamPainterTCPClient[] cls = null;
            lock (_cSync) { cls = _clients.GetValues(); }
            if (cls != null)
            {
                for (int i = 0; i < cls.Length; i++)
                {
                    cls[i].Disconnect();
                }
            }
        }
    }
}
