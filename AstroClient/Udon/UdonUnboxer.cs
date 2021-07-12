namespace AstroClient.Udon
{
	using AstroLibrary.Console;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnhollowerBaseLib;
	using VRC.Udon;
	using VRC.Udon.Common.Interfaces;

	public static class UdonUnboxer
	{

		public static void UnboxUdon(UdonBehaviour udonnode)
		{
			if(udonnode != null)
			{
				IUdonProgram program = null;
				IUdonSymbolTable symbol_table = null;
				if (udonnode._program != null)
				{
					program = udonnode._program;
				}
				if (program != null)
				{
					symbol_table = program.SymbolTable;
				}
				else
				{
					ModConsole.Log($"[Udon Unboxer] : {udonnode.name} Program is Empty! Can't unbox!", System.Drawing.Color.Red);
					return;
				}

				ModConsole.Log($"[Udon Unboxer] : Dumping {udonnode.name} Symbols and types..", System.Drawing.Color.Orange);
				foreach(var symbol in symbol_table.GetSymbols())
				{
					if(symbol != null)
					{
						var symboltype = symbol_table.GetSymbolType(symbol);
						ModConsole.Log($"[Udon Unboxer] : Found Symbol : {symbol}, Type : {symboltype.FullName} with value : {UnboxTypeToString(symboltype)}", System.Drawing.Color.Gold);
					}
				}




			}
			

		}



		private static string UnboxTypeToString(Il2CppSystem.Type il2cpptype)
		{
			if(il2cpptype != null)
			{
				if(il2cpptype.FullName.Equals("System.String"))
				{
					return IL2CPP.Il2CppStringToManaged(il2cpptype.Pointer); // TODO: Figure it out.
				}




				else if(il2cpptype.FullName.Equals("System.UInt32"))
				{
					return il2cpptype.Unbox<System.UInt32>().ToString();
				}
				else if (il2cpptype.FullName.Equals("System.Int32"))
				{
					return il2cpptype.Unbox<System.Int32>().ToString();
				}
				else if (il2cpptype.FullName.Equals("System.Int64"))
				{
					return il2cpptype.Unbox<System.Int64>().ToString();
				}
				else if (il2cpptype.FullName.Equals("System.Char"))
				{
					return il2cpptype.Unbox<System.Char>().ToString();
				}
				else if (il2cpptype.FullName.Equals("System.Boolean"))
				{
					return il2cpptype.Unbox<System.Boolean>().ToString();
				}
				else if (il2cpptype.FullName.Equals("System.Boolean"))
				{
					return il2cpptype.Unbox<System.Boolean>().ToString();
				}
				else if (il2cpptype.FullName.Equals("UnityEngine.Color"))
				{
					return il2cpptype.Unbox<UnityEngine.Color>().ToString();
				}
				
			}
			return "Not Supported Yet";
		}
	}
}
