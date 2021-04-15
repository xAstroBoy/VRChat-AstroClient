namespace AstroLibrary.Networking
{
    using System;
    using System.IO;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class HandleClient
    {
        public TcpClient ClientSocket { get; private set; }

        public event EventHandler<EventArgs> Connected;
        public event EventHandler<EventArgs> Disconnected;
        public event EventHandler<ReceivedTextEventArgs> ReceivedText;
        public event EventHandler<ReceivedDataEventArgs> ReceivedData;

        public bool IsConnected { get; private set; }

        public int ClientID { get; private set; }

        public bool IsClient = true;

        private NetworkStream _clientStream;

        private const int SecretKeyClient = 6354;
        private const int SecretKeyLoader = 2353;

        private const int PacketSize = 1024 * 4;

        public void StartClient(TcpClient clientSocket, int clientId)
        {
            ClientID = clientId;
            ClientSocket = clientSocket;
            _clientStream = ClientSocket.GetStream();
            Task task = new Task(StartThread);
            task.Start();
        }

        public void Disconnect()
        {
            IsConnected = false;
        }

        private void SendHeaderType(int headerType = 1000) // 1000 is plain text
        {
            byte[] header = BitConverter.GetBytes(headerType);
            //Console.WriteLine($"Sending HeaderType: {BitConverter.ToUInt32(header, 0)}");
            try
            {
                _clientStream.Write(header, 0, header.Length);
                _clientStream.Flush();
            }
            catch
            {
                IsConnected = false;
            }
        }

        private void SendSecret()
        {
            byte[] secretHeader;

            if (IsClient)
            {
                secretHeader = BitConverter.GetBytes(SecretKeyClient);
                //Console.WriteLine($"Sending Client Secret: {BitConverter.ToUInt32(secretHeader, 0)}");
            } else
            {
                secretHeader = BitConverter.GetBytes(SecretKeyLoader);
                //Console.WriteLine($"Sending Loader Secret: {BitConverter.ToUInt32(secretHeader, 0)}");
            }

            try
            {
                _clientStream.Write(secretHeader, 0, secretHeader.Length);
                _clientStream.Flush();
            }
            catch
            {
                IsConnected = false;
            }
        }

        public void SendHeaderLength(byte[] msg)
        {
            byte[] headerLength = BitConverter.GetBytes(msg.Length);
            //Console.WriteLine($"Sending Header Length: {BitConverter.ToUInt32(headerLength, 0)}");
            try
            {
                _clientStream.Write(headerLength, 0, headerLength.Length);
                _clientStream.Flush();
            }
            catch
            {
                IsConnected = false;
            }
        }

        public void Send(string msg)
        {
            Send(msg.ConvertToBytes());
        }

        public void Send(byte[] msg, int headerType = 1000) // 0 = client, 1 = loader
        {
            SendSecret();
            SendHeaderType(headerType);
            SendHeaderLength(msg);

            if (msg != null && msg.Length > 0)
            {
                try
                {
                    _clientStream.Write(msg, 0, msg.Length);
                    _clientStream.Flush();
                }
                catch
                {
                    IsConnected = false;
                }
            }
        }

        private void StartThread()
        {
            Connected?.Invoke(this, new EventArgs());

            IsConnected = true;
            while (IsConnected)
            {
                Receive();
            }

            Disconnected?.Invoke(this, new EventArgs());
        }

        private int RecieveHeaderType()
        {
            try
            {
                byte[] received = new byte[4];
                _clientStream.Read(received, 0, received.Length);
                return BitConverter.ToInt32(received, 0);
            }
            catch
            {
                IsConnected = false;
                return 0;
            }
        }

        private int ReceiveSecret()
        {
            try
            {
                byte[] received = new byte[4];
                _clientStream.Read(received, 0, received.Length);
                return BitConverter.ToInt32(received, 0);
            }
            catch
            {
                IsConnected = false;
                return 0;
            }
        }

        private int ReceiveHeaderLength()
        {
            try
            {
                byte[] received = new byte[4];
                _clientStream.Read(received, 0, received.Length);
                return BitConverter.ToInt32(received, 0);;
            }
            catch
            {
                IsConnected = false;
                return 0;
            }
        }

        private void Receive()
        {
            int secret = ReceiveSecret();

            if (secret != SecretKeyClient && IsClient)
            {
                IsConnected = false;
                Console.WriteLine("Failed to provide client secret key");
            }
            else if (secret != SecretKeyLoader && !IsClient)
            {
                IsConnected = false;
                Console.WriteLine("Failed to provide loader secret key");
            }
            else
            {
                //var cl = IsClient ? "client" : "loader";
                //Console.WriteLine($"Correct secret key received: {cl}");
            }

            int headerType = RecieveHeaderType();
            //Console.WriteLine($"Received Header Type {headerType}");

            int len = ReceiveHeaderLength();
            if (len > 0)
            {
                //Console.WriteLine($"Received Header Length {len}");

                int remaining = len;
                int totalRead = 0;
                MemoryStream memoryStream = new MemoryStream();
                while (remaining > 0)
                {
                    try
                    {
                        byte[] received = new byte[PacketSize];
                        int read = _clientStream.Read(received, 0, received.Length);

                        totalRead += read;
                        remaining -= read;

                        byte[] a = new byte[read];

                        for (int i = 0; i < read; i++)
                        {
                            a[i] = received[i];
                        }

                        memoryStream.Write(a, 0, a.Length);
                    }
                    catch
                    {
                        IsConnected = false;
                    }
                    finally
                    {
                        //Console.WriteLine($"Read: {totalRead} / {remaining} / {len}");
                    }
                }

                byte[] data = memoryStream.GetBuffer();

                if (headerType == 1000) // Text
                {
                    //Console.WriteLine("Read Text Finished");
                    string message = data.ConvertToString();
                    ReceivedText?.Invoke(this, new ReceivedTextEventArgs(ClientID, message));
                }
                else if (headerType == 1001) // Data
                {
                    //Console.WriteLine("Read Data Finished");
                    ReceivedData?.Invoke(this, new ReceivedDataEventArgs(ClientID, data));
                } else
                {
                    Console.WriteLine($"Something Went Wrong.. {headerType}");
                }
            }
        }
    }
}