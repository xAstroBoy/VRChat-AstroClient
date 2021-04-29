namespace AstroNetworkingLibrary
{
	using System;
	using System.Net.Sockets;
	using System.Threading.Tasks;

	public class HandleClient
	{
		public TcpClient ClientSocket { get; private set; }

		public event EventHandler<EventArgs> Connected;

		public event EventHandler<EventArgs> Disconnected;

		public event EventHandler<ReceivedTextEventArgs> ReceivedText;

		public event EventHandler<ReceivedDataEventArgs> ReceivedData;

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
				clientStream.Close();
				ClientSocket.Close();
			}
			catch
			{

			}
		}

		private void SendHeaderType(int headerType = 1000) // 1000 is plain text
		{
			byte[] header = BitConverter.GetBytes(headerType);
			try
			{
				clientStream.Write(header, 0, header.Length);
				clientStream.Flush();
			}
			catch
			{
				Disconnect();
			}
		}

		private void SendSecret()
		{
			byte[] secretHeader;

			if (IsClient)
			{
				secretHeader = BitConverter.GetBytes(SecretKeyClient);
			}
			else
			{
				secretHeader = BitConverter.GetBytes(SecretKeyLoader);
			}

			try
			{
				clientStream.Write(secretHeader, 0, secretHeader.Length);
				clientStream.Flush();
			}
			catch
			{
				Disconnect();
			}
		}

		public void SendHeaderLength(byte[] msg)
		{
			byte[] headerLength = BitConverter.GetBytes(msg.Length);
			try
			{
				clientStream.Write(headerLength, 0, headerLength.Length);
				clientStream.Flush();
			}
			catch
			{
				Disconnect();
			}
		}

		public void Send(string msg)
		{
			if (IsConnected)
			{
				Send(msg.ConvertToBytes());
			}
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
					clientStream.Write(msg, 0, msg.Length);
					clientStream.Flush();
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
				clientStream.Read(received, 0, received.Length);
				return BitConverter.ToInt32(received, 0);
			}
			catch
			{
				Disconnect();
				return 0;
			}
		}

		private int ReceiveSecret()
		{
			try
			{
				byte[] received = new byte[4];
				clientStream.Read(received, 0, received.Length);
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
				clientStream.Read(received, 0, received.Length);
				return BitConverter.ToInt32(received, 0); ;
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

			int headerType = RecieveHeaderType();
			int len = ReceiveHeaderLength();

			if (len > 0)
			{
				int remaining = len;
				int totalRead = 0;
				byte[] data = new byte[len];

				int toRead = PacketSize;
				while (remaining > 0)
				{
					if (remaining >= PacketSize)
					{
						toRead = PacketSize;
					}
					else
					{
						toRead = remaining;
					}
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

				if (headerType == 1000) // Text
				{
					string message = data.ConvertToString();
					ReceivedText?.Invoke(this, new ReceivedTextEventArgs(ClientID, message));
				}
				else if (headerType == 1001) // Data
				{
					ReceivedData?.Invoke(this, new ReceivedDataEventArgs(ClientID, data));
				}
				else
				{
					Console.WriteLine($"Something Went Wrong.. {headerType}");
				}
			}
		}
	}
}