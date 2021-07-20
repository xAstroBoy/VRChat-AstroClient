namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using System;
	using VRC.Udon.Common.Interfaces;

	public static class UdonHeapEditor
	{
		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, bool value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, Single value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, string value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, string[] value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UInt32 value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, Int32 value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, Int64 value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, char value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, char[] value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.Color value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.Material value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.MeshRenderer value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.ParticleSystem value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.Transform value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.GameObject value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.GameObject[] value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.Vector3 value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.Quaternion value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.AudioSource value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.AudioClip[] value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.UI.Text value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, UnityEngine.HumanBodyBones value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, VRC.SDKBase.VRCPlayerApi value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, VRC.SDKBase.VRCPlayerApi[] value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, VRC.Udon.UdonBehaviour value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, VRC.Udon.Common.Interfaces.NetworkEventTarget value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, TMPro.TextMeshPro value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonSymbolTable symbols, IUdonHeap heap, string symbol, TMPro.TextMeshProUGUI value, bool verify = false)
		{
			if (heap != null)
			{
				PatchHeap(heap, symbols.GetAddressFromSymbol(symbol), value, verify);
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, TMPro.TextMeshProUGUI value, bool verify = false)
		{
			if (heap != null && address != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_TextMeshProUGUI(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Boolean();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}



		public static void PatchHeap(IUdonHeap heap, uint address, bool value, bool verify = false)
		{
			if (heap != null && address != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Boolean(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Boolean();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, Single value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Single(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Single();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, string value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_string(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_String();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, string[] value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Array_string(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Array_String();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UInt32 value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UInt32(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_UInt32();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, Int32 value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Int32(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Int32();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, Int64 value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Int64(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Int64();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, char value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Char(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Char();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, char[] value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Array_char(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Array_Char();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Color value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_color(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Color();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Material value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_Material(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Material();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.MeshRenderer value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_MeshRenderer(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_MeshRenderer();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.ParticleSystem value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_ParticleSystem(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_ParticleSystem();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Transform value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_Transform(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Transform();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.GameObject value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_GameObject(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_GameObject();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.GameObject[] value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Array_UnityEngine_GameObjects(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Array_GameObject();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Vector3 value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_Vector3(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Vector3();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.Quaternion value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_Quaternion(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Quaternion();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AudioSource value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_AudioSource(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_AudioSource();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.AudioClip[] value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Array_UnityEngine_AudioClips(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Array_AudioClip();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.UI.Text value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_Text(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Text();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, UnityEngine.HumanBodyBones value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_HumanBodyBones(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_HumanBodyBones();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, VRC.SDKBase.VRCPlayerApi value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_VRCPlayerApi(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_VRCPlayerApi();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, VRC.SDKBase.VRCPlayerApi[] value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_Array_VRCPlayerApi(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_Array_VRCPlayerApi();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, VRC.Udon.UdonBehaviour value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UdonBehaviour(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_UdonBehaviour();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, VRC.Udon.Common.Interfaces.NetworkEventTarget value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_UnityEngine_NetworkEventTarget(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_NetworkEventTarget();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}

		public static void PatchHeap(IUdonHeap heap, uint address, TMPro.TextMeshPro value, bool verify = false)
		{
			if (heap != null)
			{
				var converted = UdonConverter.Generate_Il2CPPObject_TextMeshPro(value);
				heap.SetHeapVariable(address, converted, converted.GetIl2CppType());
				if (verify)
				{
					var result = heap.GetHeapVariable(address).Unpack_TextMeshPro();
					if (result == value)
					{
						ModConsole.DebugLog($"Heap Patch Applied.");
					}
					else
					{
						ModConsole.DebugLog($"Heap Patch Failed.");
					}
				}
			}
			else
			{
				ModConsole.DebugLog("Unable To Patch Udon Heap as is null!");
			}
		}
	}
}