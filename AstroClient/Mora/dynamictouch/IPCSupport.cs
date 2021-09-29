namespace ExternalDynamicBoneEditor
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.IO.Pipes;
	using System.Runtime.InteropServices;
	using System.IO;

	namespace IPCSupport
	{
		internal enum Message
		{
			SetBoneDamping,
			SetBoneElasticity,
			SetBoneStiffness,
			SetBoneInert,
			SetBoneRadius,
			SetBoneEndLength,
			SetBoneEndOffset,
			SetBoneGravity,
			SetBoneForce,
			SetBoneData
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct Float3
		{
			internal float x, y, z;

			internal Float3(float x, float y, float z)
			{
				this.x = x;
				this.y = y;
				this.z = z;
			}
		}

		internal struct AvatarBones
		{
			internal string name;
			internal int boneCount;
			internal SerializedBoneData[] bones;

			internal byte[] ToByteArray()
			{
				using (MemoryStream ms = new MemoryStream())
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(ms))
					{
						binaryWriter.Write(name);
						binaryWriter.Write(boneCount);
						List<byte[]> bonesBytes = new List<byte[]>(bones.Select((b) => b.ToByteArray()));
						foreach (byte[] boneByteData in bonesBytes)
						{
							binaryWriter.Write(boneByteData.Length);
							binaryWriter.Write(boneByteData);
						}
						return ms.ToArray();
					}
				}
			}

			internal static AvatarBones FromByteArray(byte[] array)
			{
				using (MemoryStream memoryStream = new MemoryStream(array))
				{
					using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
					{
						AvatarBones boneList = new AvatarBones();
						boneList.name = binaryReader.ReadString();
						boneList.boneCount = binaryReader.ReadInt32();
						boneList.bones = new SerializedBoneData[boneList.boneCount];
						for (int i = 0; i < boneList.boneCount; i++)
						{
							boneList.bones[i] = SerializedBoneData.FromByteArray(binaryReader.ReadBytes(binaryReader.ReadInt32()));
						}
						return boneList;
					}
				}
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		internal struct SerializedBoneData
		{
			internal string name;
			internal float damping;
			internal float elasticity;
			internal float stiffness;
			internal float inert;
			internal float radius;
			internal float endLength;
			internal Float3 endOffset;
			internal Float3 gravity;
			internal Float3 force;

			internal static SerializedBoneData FromByteArray(byte[] array)
			{
				using (MemoryStream memoryStream = new MemoryStream(array))
				{
					using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
					{
						SerializedBoneData boneData = new SerializedBoneData();
						boneData.name = binaryReader.ReadString();
						boneData.damping = binaryReader.ReadSingle();
						boneData.elasticity = binaryReader.ReadSingle();
						boneData.stiffness = binaryReader.ReadSingle();
						boneData.inert = binaryReader.ReadSingle();
						boneData.radius = binaryReader.ReadSingle();
						boneData.endLength = binaryReader.ReadSingle();
						boneData.endOffset = new Float3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
						boneData.gravity = new Float3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
						boneData.force = new Float3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
						return boneData;

					}
				}
			}

			internal unsafe byte[] ToByteArray()
			{
				using (MemoryStream ms = new MemoryStream())
				{
					using (BinaryWriter binaryWriter = new BinaryWriter(ms))
					{
						binaryWriter.Write(name);
						binaryWriter.Write(damping);
						binaryWriter.Write(elasticity);
						binaryWriter.Write(stiffness);
						binaryWriter.Write(inert);
						binaryWriter.Write(radius);
						binaryWriter.Write(endLength);
						binaryWriter.Write(endOffset.x);
						binaryWriter.Write(endOffset.y);
						binaryWriter.Write(endOffset.z);
						binaryWriter.Write(gravity.x);
						binaryWriter.Write(gravity.y);
						binaryWriter.Write(gravity.z);
						binaryWriter.Write(force.x);
						binaryWriter.Write(force.y);
						binaryWriter.Write(force.z);
						return ms.ToArray();
					}
				}
			}
		}

		internal class IPCHandler
		{
			private PipeStream pipe;
			private BinaryWriter pipeWriter;
			private BinaryReader pipeReader;

			internal bool IsConnected
			{
				get
				{
					return pipe != null && pipe.IsConnected;
				}
			}

			internal bool IsServer
			{
				get
				{
					return pipe != null && pipe is NamedPipeServerStream;
				}
			}

			internal IPCHandler(PipeStream pipeResource)
			{
				pipe = pipeResource;
				pipeReader = new BinaryReader(pipe, Encoding.UTF8);
				pipeWriter = new BinaryWriter(pipe, Encoding.UTF8);
			}

			internal Message Receive(out byte[] data)
			{
				if (!IsConnected) throw new InvalidOperationException("Tried to receive a message but the pipe is disconnected.");
				Message message = (Message)pipeReader.ReadInt32();
				data = pipeReader.ReadBytes(pipeReader.ReadInt32());
				return message;
			}

			internal void Send(Message messageType, string boneName, object data)
			{
				if (!IsConnected) throw new InvalidOperationException("Tried to send a message but the pipe is disconnected.");
				switch (messageType)
				{
					case Message.SetBoneData:
						{
							if (!IsServer) throw new InvalidOperationException("GetBoneData can only be called from the server.");
							pipeWriter.Write((int)Message.SetBoneData);
							pipeWriter.Write((byte[])data);
							break;
						}
					case Message.SetBoneDamping:
						{
							if (IsServer) throw new InvalidOperationException("SetBoneDamping can only be called from the client.");
							pipeWriter.Write((int)Message.SetBoneDamping);
							pipeWriter.Write(boneName);
							pipeWriter.Write((float)data);
							break;
						}
					case Message.SetBoneElasticity:
						{
							if (IsServer) throw new InvalidOperationException("SetBoneElasticity can only be called from the client.");
							pipeWriter.Write((int)Message.SetBoneElasticity);
							pipeWriter.Write(boneName);
							pipeWriter.Write((float)data);
							break;
						}
					case Message.SetBoneStiffness:
						{
							if (IsServer) throw new InvalidOperationException("SetBoneStiffness can only be called from the client.");
							pipeWriter.Write((int)Message.SetBoneStiffness);
							pipeWriter.Write(boneName);
							pipeWriter.Write((float)data);
							break;
						}
					case Message.SetBoneInert:
						{
							if (IsServer) throw new InvalidOperationException("SetBoneInert can only be called from the client.");
							pipeWriter.Write((int)Message.SetBoneInert);
							pipeWriter.Write(boneName);
							pipeWriter.Write((float)data);
							break;
						}
					case Message.SetBoneRadius:
						{
							if (IsServer) throw new InvalidOperationException("SetBoneRadius can only be called from the client.");
							pipeWriter.Write((int)Message.SetBoneRadius);
							pipeWriter.Write(boneName);
							pipeWriter.Write((float)data);
							break;
						}
					case Message.SetBoneEndLength:
						{
							if (IsServer) throw new InvalidOperationException("SetBoneEndLength can only be called from the client.");
							pipeWriter.Write((int)Message.SetBoneEndLength);
							pipeWriter.Write(boneName);
							pipeWriter.Write((float)data);
							break;
						}
					case Message.SetBoneEndOffset:
						{
							if (IsServer) throw new InvalidOperationException("SetBoneEndOffset can only be called from the client.");
							pipeWriter.Write((int)Message.SetBoneInert);
							pipeWriter.Write(boneName);
							pipeWriter.Write(((Float3)data).x);
							pipeWriter.Write(((Float3)data).y);
							pipeWriter.Write(((Float3)data).z);
							break;
						}
					case Message.SetBoneGravity:
						{
							if (IsServer) throw new InvalidOperationException("SetBoneGravity can only be called from the client.");
							pipeWriter.Write((int)Message.SetBoneGravity);
							pipeWriter.Write(boneName);
							pipeWriter.Write(((Float3)data).x);
							pipeWriter.Write(((Float3)data).y);
							pipeWriter.Write(((Float3)data).z);
							break;
						}
					case Message.SetBoneForce:
						{
							if (IsServer) throw new InvalidOperationException("SetBoneForce can only be called from the client.");
							pipeWriter.Write((int)Message.SetBoneInert);
							pipeWriter.Write(boneName);
							pipeWriter.Write(((Float3)data).x);
							pipeWriter.Write(((Float3)data).y);
							pipeWriter.Write(((Float3)data).z);
							break;
						}
				}

			}
		}
	}
}