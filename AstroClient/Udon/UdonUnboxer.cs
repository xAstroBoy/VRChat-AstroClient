namespace AstroClient.Udon
{
	using AstroLibrary.Console;
	using System;
	using UnhollowerBaseLib;
	using VRC.Udon;
	using VRC.Udon.Common.Interfaces;

	public static class UdonUnboxer
	{
		public static void UnboxUdon(UdonBehaviour udonnode)
		{
			if (udonnode != null)
			{
				IUdonProgram program = null;
				IUdonSymbolTable symbol_table = null;
				IUdonHeap heap = null;
				if (udonnode._program != null)
				{
					program = udonnode._program;
				}
				if (program != null)
				{
					symbol_table = program.SymbolTable;
					if(program.Heap != null)
					{
						heap = program.Heap;
					}
				}
				else
				{
					ModConsole.Log($"[Udon Unboxer] : {udonnode.name} Program is Empty! Can't unbox!", System.Drawing.Color.Red);
					return;
				}

				ModConsole.Log($"[Udon Unboxer] : Dumping {udonnode.name} Symbols and types..", System.Drawing.Color.Orange);
				foreach (var symbol in symbol_table.GetSymbols())
				{
					if (symbol != null)
					{
						var symboltype = symbol_table.GetSymbolType(symbol);
						var address = symbol_table.GetAddressFromSymbol(symbol);

						try
						{
							string unpackedsymbol = UnboxUdonHeap(heap.GetHeapVariable(address), symboltype);

							ModConsole.Log($"[Udon Unboxer] : Found Symbol : {symbol}, Type : {symboltype.FullName} with value : {unpackedsymbol}", System.Drawing.Color.Gold);
						}
						catch (Exception e)
						{
							ModConsole.DebugErrorExc(e);
							ModConsole.Log($"[Udon Unboxer] : Found Symbol : {symbol}, Type : {symboltype.FullName} (Error unpacking it.)", System.Drawing.Color.Gold);
						}
					}
				}
			}
		}

		private static string UnboxUdonHeap(Il2CppSystem.Object unboxobj, Il2CppSystem.Type il2cpptype)
		{
			if (il2cpptype != null)
			{
				if (il2cpptype.FullName == "System.String")
				{
					ModConsole.DebugLog("Unpacking it as : System.String");

					return IL2CPP.Il2CppStringToManaged(unboxobj.Pointer);
				}
				else if (il2cpptype.FullName == "System.UInt32")
				{
					ModConsole.DebugLog("Unpacking it as : System.Int32");

					return unboxobj.Unbox<System.UInt32>().ToString();
				}
				else if (il2cpptype.FullName == "System.Int32")
				{
					ModConsole.DebugLog("Unpacking it as : System.Int32");

					return unboxobj.Unbox<System.Int32>().ToString();
				}
				else if (il2cpptype.FullName == "System.Int64")
				{
					ModConsole.DebugLog("Unpacking it as : System.Int64");

					return unboxobj.Unbox<System.Int64>().ToString();
				}
				else if (il2cpptype.FullName == "System.Char")
				{
					ModConsole.DebugLog("Unpacking it as : System.Char");

					return unboxobj.Unbox<System.Char>().ToString();
				}
				else if (il2cpptype.FullName == "System.Boolean")
				{
					ModConsole.DebugLog("Unpacking it as : System.Boolean");

					return unboxobj.Unbox<System.Boolean>().ToString();
				}
				else if (il2cpptype.FullName == "System.String[]")
				{
					ModConsole.DebugLog("Unpacking it as : System.String[]");

					string translated = "";
					var il2cpplist = new Il2CppStringArray(unboxobj.Pointer);
					foreach (var item in il2cpplist)
					{
						translated += item + " ";
					}
					return translated;
				}
				else if (il2cpptype.FullName == "UnityEngine.Color")
				{
					ModConsole.DebugLog("Unpacking it as : UnityEngine.Color");
					return unboxobj.Unbox<UnityEngine.Color>().ToString();
				}
				else if (il2cpptype.FullName == "UnityEngine.Transform")
				{
					return unboxobj.Cast<UnityEngine.Transform>().name;
				}
				else if(il2cpptype.FullName == "UnityEngine.GameObject")
				{
					return unboxobj.Cast<UnityEngine.GameObject>().name.ToString();
				}
				else if (il2cpptype.FullName == "VRC.SDKBase.VRCPlayerApi")
				{
					return unboxobj.Cast<VRC.SDKBase.VRCPlayerApi>().displayName.ToString();
				}
				else if (il2cpptype.FullName == "VRC.Udon.UdonBehaviour")
				{
					return unboxobj.Cast<VRC.Udon.UdonBehaviour>().name.ToString();
				}
				else if (il2cpptype.FullName == "UnityEngine.Material")
				{
					return unboxobj.Cast<UnityEngine.Material>().name.ToString();
				}
				else if (il2cpptype.FullName == "VRC.Udon.Common.Interfaces.NetworkEventTarget")
				{
					return unboxobj.Unbox<VRC.Udon.Common.Interfaces.NetworkEventTarget>().ToString();
				}
				else if (il2cpptype.FullName == "UnityEngine.HumanBodyBones")
				{
					return unboxobj.Unbox<UnityEngine.HumanBodyBones>().ToString();
				}
				else if (il2cpptype.FullName == "System.Object")
				{
					return "Not Supported Yet (i Have to figure this out)";
				}
				else if (il2cpptype.FullName == "UnityEngine.Vector3")
				{
					return unboxobj.Unbox<UnityEngine.Vector3>().ToString();
				}
				else if (il2cpptype.FullName == "UnityEngine.Quaternion")
				{
					return unboxobj.Unbox<UnityEngine.Quaternion>().ToString();
				}
			}
			return "Not Supported Yet";
		}
	}
}