namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using VRC.Udon;

    internal static class UdonUnboxer
    {

        internal static void UnboxUdonToConsole(UdonBehaviour udonnode)
        {
            if (udonnode != null)
            {
                StringBuilder builder = new StringBuilder();

                var unpackedudon = udonnode.ToRawUdonBehaviour();
                if (unpackedudon != null)
                {
                    System.Console.Clear();
                    builder.AppendLine($"[Udon Unboxer] : Dumping {udonnode.name} Symbols and types..");
                    builder.AppendLine();
                    foreach (var symbol in unpackedudon.IUdonSymbolTable.GetSymbols())
                    {
                        if (symbol != null)
                        {
                            var address = unpackedudon.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                            var UnboxVariable = unpackedudon.IUdonHeap.GetHeapVariable(address);
                            if (UnboxVariable != null)
                            {
                                var Il2CppType = UnboxVariable.GetIl2CppType();
                                var unpackedsymbol = UdonHeapUnboxerUtils.UnboxUdonHeap(UnboxVariable);
                                builder.AppendLine($"[Udon Unboxer] : ACTION {udonnode.name} : HEAP Address : {address} Found Symbol : {symbol}, Type : {Il2CppType.FullName} with value : {unpackedsymbol}");
                            }
                        }
                    }
                    ModConsole.Log(builder.ToString(), System.Drawing.Color.Gold);
                    builder.Clear();
                }
            }
        }

        internal static void DumpUdonUnsupportedTypes()
        {
            if (UdonHeapUnboxerUtils.UnsupportedTypes.Count() != 0)
            {
                ModConsole.Warning($"[Udon Unboxer] : Found {UdonHeapUnboxerUtils.UnsupportedTypes.Count} Unsupported Types. \n Please send the Generated File Unsupported_UdonTypes.txt to the developer for further Udon Unpacking support!");
                StringBuilder builder = new StringBuilder();

                foreach (var value in UdonHeapUnboxerUtils.UnsupportedTypes)
                {
                    builder.AppendLine(value);
                }
                File.WriteAllText(Path.Combine(Environment.CurrentDirectory, @"AstroClient\Dumper\Unsupported_UdonTypes.txt"), builder.ToString());

            }
        }

        internal static string UnboxUdonToString(UdonBehaviour udonnode)
        {
            if (udonnode != null)
            {
                StringBuilder builder = new StringBuilder();
                var unpackedudon = udonnode.ToRawUdonBehaviour();
                if (unpackedudon != null)
                {
                    _ = builder.AppendLine($"[Udon Unboxer] : Dumping {udonnode.name} Symbols and types..");
                    foreach (var symbol in unpackedudon.IUdonSymbolTable.GetSymbols())
                    {
                        if (symbol != null)
                        {
                            var address = unpackedudon.IUdonSymbolTable.GetAddressFromSymbol(symbol);
                            var UnboxVariable = unpackedudon.IUdonHeap.GetHeapVariable(address);
                            if (UnboxVariable != null)
                            {
                                var Il2CppType = UnboxVariable.GetIl2CppType();
                                var unpackedsymbol = UdonHeapUnboxerUtils.UnboxUdonHeap(UnboxVariable);
                                _ = builder.AppendLine($"[Udon Unboxer] : ACTION {udonnode.name} : HEAP Address : {address} Found Symbol : {symbol}, Type : {Il2CppType.FullName} with value : {unpackedsymbol}");
                            }
                        }
                    }
                }
                return builder.ToString();
            }
            return null;
        }

    }
}