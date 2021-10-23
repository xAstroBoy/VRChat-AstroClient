namespace AstroNetworkingLibrary
{
    using AstroNetworkingLibrary.Serializable;
    using System;
    using System.Net.Sockets;
    using System.Threading;
    using System.Threading.Tasks;

    internal class HandleClient
    {
        internal TcpClient ClientSocket { get; private set; }

        internal event EventHandler<EventArgs> Connected;

        internal event EventHandler<EventArgs> Disconnected;

        internal event EventHandler<ReceivedPacketEventArgs> ReceivedPacket;

        internal int ClientID { get; private set; }

        internal bool IsClient = true;

        internal bool IsConnected;

        internal bool ShouldReconnect = true;

        private NetworkStream clientStream;

        private const int SecretKeyClient = 2454;
        private const int SecretKeyLoader = 2353;

        private const int PacketSize = 1024;

        internal void StartClient(TcpClient clientSocket, int clientId)
        {
            ClientID = clientId;
            ClientSocket = clientSocket;
            ClientSocket.SendTimeout = 2000;
            clientStream = ClientSocket.GetStream();
            Task task = new Task(StartThread);
            task.Start();
        }

        internal void Disconnect(bool reconnect = false)
        {
            IsConnected = false;
            ShouldReconnect = reconnect;
            try
            {
                clientStream.Close();
            }
            catch { }

            try
            {
                ClientSocket.Close();
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

        internal void Send(PacketData packetData)
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
            Console.WriteLine($"len: {len}");
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
                        if (read > 0)
                        {
                            totalRead += read;
                            remaining -= read;

                            if (read != toRead)
                            {
                                //Console.WriteLine($"WARNING: Possible internet issue? Read {read} excpected to read {toRead}..");
                            }
                            Console.WriteLine($"Downloading: {totalRead} / {remaining} / {len} - {read}/{toRead}");
                            //Console.WriteLine($"----------" +
                            //    $"\r\n read: {read}" +
                            //    $"\r\n toRead: {toRead}" +
                            //    $"\r\n remaining: {remaining}" +
                            //    $"\r\n totalRead: {totalRead}");
                            received.CopyTo(data, totalRead - read);
                        }
                        else
                        {
                            //remaining = 0;
                            Console.WriteLine($"ERROR: 0x000001A");
                            Console.WriteLine($"{totalRead}/{len}");
                            Thread.Sleep(1000);
                        }
                    } 
                    catch
                    {
                        Disconnect();
                    }
                }

                string base64 = data.ConvertToString();
                var packetData = BSonWriter.FromBson<PacketData>(base64);
                Console.WriteLine($"Received ({packetData.NetworkEventID}): {data.Length}/{len}");
                ReceivedPacket?.Invoke(this, new ReceivedPacketEventArgs(ClientID, packetData));
            }
        }
    }
}