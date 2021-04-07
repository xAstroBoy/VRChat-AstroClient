namespace AstroClient
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;

    public class HandleClient
    {
        public TcpClient ClientSocket { get; private set; }

        public event EventHandler<EventArgs> Connected;
        public event EventHandler<EventArgs> Disconnected;
        public event EventHandler<ReceivedDataEventArgs> Received;

        public bool IsConnected { get; private set; }

        public int ClientID { get; private set; }

        private NetworkStream _clientStream;

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

        private void SendHeader(byte[] msg)
        {
            byte[] header = new byte[4];
            header = BitConverter.GetBytes(msg.Length);
            Console.WriteLine($"Sending length of: {header}"); // Here also

            if (msg != null && msg.Length > 0)
            {
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
        }

        public void Send(string msg)
        {
            SendHeader(msg.ConvertToBytes());
            Send(msg.ConvertToBytes());
        }

        private void Send(byte[] msg)
        {
            Console.WriteLine($"Sending Data");
            Console.WriteLine(msg.ConvertToString());
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

        private void Receive()
        {
            Console.WriteLine("Waiting for a Packet Header..");

            len = ReceiveHeaderLength();

            if (len > 0)
            {
                Console.WriteLine("Waiting for Packet Data..");
                ReceiveData();
            }
        }

        private int ReceiveHeaderLength()
        {
            try
            {
                byte[] received = new byte[4];
                _clientStream.Read(received, 0, received.Length);
                int length = BitConverter.ToInt32(received, 0); // this is the problem on Linux
                Console.WriteLine($"Receiving packet of length: {length}");
                return length;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                IsConnected = false;
                return 0;
            }
        }

        private int len = 0;

        private int read = 0;

        private static readonly int chunkSize = 1024 * 999999;

        private void ReceiveData()
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                int chunk = 0;
                int chunks = len / chunkSize;
                Console.WriteLine($"Chunk Count: {chunks}");

                int toRead = 0;
                while (read < len)
                {
                    if (chunk < chunks)
                    {
                        toRead = chunkSize;
                    }
                    else
                    {
                        Console.WriteLine($"Last Chunk! {chunk}");
                        toRead = len - read;
                    }

                    byte[] received = new byte[toRead];
                    read += _clientStream.Read(received, 0, received.Length);
                    Console.WriteLine($"Read: {toRead} / {read} Chunk: {chunk}");
                    stringBuilder.Append(received.ConvertToString());
                    chunk++;
                }

                string msg = stringBuilder.ToString();
                Console.WriteLine(msg + Environment.NewLine);

                Console.WriteLine($"Chunk Size: {chunkSize}");
                Console.WriteLine($"Total Bytes Read: {read} out of {chunks} chunks");
                Console.WriteLine($"Msg Received Length: {msg.Length}");
                read = 0;
                Received?.Invoke(this, new ReceivedDataEventArgs(ClientID, msg));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                IsConnected = false;
            }
        }
    }
}
