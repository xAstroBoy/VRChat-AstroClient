﻿namespace AstroNetworkingLibrary
{
    using AstroNetworkingLibrary.Serializable;
    using System;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class HandleClient
    {
        public TcpClient ClientSocket { get; private set; }

        public event EventHandler<EventArgs> Connected;

        public event EventHandler<EventArgs> Disconnected;

        public event EventHandler<ReceivedPacketEventArgs> ReceivedPacket;

        public int ClientID { get; private set; }

        public bool IsClient = true;

        public bool IsConnected;

        public bool ShouldReconnect = true;

        private NetworkStream clientStream;

        private const int SecretKeyClient = 2454;
        private const int SecretKeyLoader = 2353;

        private const int PacketSize = 1024;

        public void StartClient(TcpClient clientSocket, int clientId)
        {
            ClientID = clientId;
            ClientSocket = clientSocket;
            ClientSocket.SendTimeout = 2000;
            clientStream = ClientSocket.GetStream();
            Task task = new Task(StartThread);
            task.Start();
        }

        public void Disconnect(bool reconnect = false)
        {
            IsConnected = false;
            ShouldReconnect = reconnect;

            try
            {
                ClientSocket.Client.Close();
            }
            catch { }
        }

        private void SendSecret()
        {
            byte[] secretHeader = IsClient ? BitConverter.GetBytes(SecretKeyClient) : BitConverter.GetBytes(SecretKeyLoader);

            try
            {
                clientStream.Write(secretHeader, 0, secretHeader.Length);
            }
            catch
            {
                Disconnect();
            }
        }

        internal void SendHeaderLength(byte[] msg)
        {
            byte[] headerLength = BitConverter.GetBytes(msg.Length);
            try
            {
                clientStream.Write(headerLength, 0, headerLength.Length);
            }
            catch
            {
                Disconnect();
            }
        }

        public void Send(PacketData packetData) // 0 = text, 1 = data
        {
            var bson = BSonWriter.ToBson(packetData);
            var bytes = bson.ConvertToBytes();

            SendSecret();
            SendHeaderLength(bytes);

            if (bytes != null && bytes.Length > 0)
            {
                try
                {
                    clientStream.Write(bytes, 0, bytes.Length);
                }
                catch
                {
                    Disconnect();
                }
            }
        }

        private void StartThread()
        {
            Connected?.Invoke(this, new EventArgs());

            IsConnected = true;
            for (; IsConnected;)
            {
                Receive();
            }

            Disconnected?.Invoke(this, new EventArgs());
        }

        private int ReceiveSecret()
        {
            try
            {
                byte[] received = new byte[4];
                _ = clientStream.Read(received, 0, received.Length);
                return BitConverter.ToInt32(received, 0);
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }

        private int ReceiveHeaderLength()
        {
            try
            {
                byte[] received = new byte[4];
                _ = clientStream.Read(received, 0, received.Length);
                return BitConverter.ToInt32(received, 0);
            }
            catch
            {
                Disconnect();
                return 0;
            }
        }

        private void Receive()
        {
            int secret = ReceiveSecret();

            if (secret != SecretKeyClient && IsClient)
            {
                Disconnect();
            }
            else if (secret != SecretKeyLoader && !IsClient)
            {
                Disconnect();
            }

            int len = ReceiveHeaderLength();

            if (len > 0)
            {
                int remaining = len;
                int totalRead = 0;
                byte[] data = new byte[len];

                int toRead = PacketSize;
                for (; remaining > 0;)
                {
                    toRead = remaining >= PacketSize ? PacketSize : remaining;

                    try
                    {
                        byte[] received = new byte[toRead];
                        int read = clientStream.Read(received, 0, received.Length);

                        totalRead += read;
                        remaining -= read;

                        received.CopyTo(data, totalRead - read);
                    }
                    catch
                    {
                        Disconnect();
                    }
                }

                string base64 = data.ConvertToString();
                var packetData = BSonWriter.FromBson<PacketData>(base64);
                ReceivedPacket?.Invoke(this, new ReceivedPacketEventArgs(ClientID, packetData));
            }
        }
    }
}