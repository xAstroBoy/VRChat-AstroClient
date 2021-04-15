using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace AstroLibrary.Networking
{
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

        private const int SecretKeyClient = 2454;
        private const int SecretKeyLoader = 2353;

        private const int PacketSize = 1024;

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
            } else
            {
                secretHeader = BitConverter.GetBytes(SecretKeyLoader);
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

        public void Send(byte[] msg, int headerType = 1000) // 0 = text, 1 = data
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

            //Console.WriteLine($"Secret key: {secret}");

            if (secret != SecretKeyClient && IsClient)
            {
                IsConnected = false;
                //Console.WriteLine($"Failed to provide client secret key: {SecretKeyClient}");
            }
            else if (secret != SecretKeyLoader && !IsClient)
            {
                IsConnected = false;
                //Console.WriteLine($"Failed to provide loader secret key: {SecretKeyLoader}");
            }

            int headerType = RecieveHeaderType();
            int len = ReceiveHeaderLength();

            //Console.WriteLine($"Header type: {headerType}");
            //Console.WriteLine($"Header lenghh: {len}");

            if (len > 0)
            {
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
                }

                byte[] data = memoryStream.GetBuffer();

                if (headerType == 1000) // Text
                {
                    string message = data.ConvertToString();
                    ReceivedText?.Invoke(this, new ReceivedTextEventArgs(ClientID, message));
                }
                else if (headerType == 1001) // Data
                {
                    ReceivedData?.Invoke(this, new ReceivedDataEventArgs(ClientID, data));
                } else
                {
                    Console.WriteLine($"Something Went Wrong.. {headerType}");
                }
            }
        }
    }
}