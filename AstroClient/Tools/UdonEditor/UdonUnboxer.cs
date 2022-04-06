namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
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
                    Console.Clear();
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
                                var unpackedsymbol = UdonHeapUnboxerUtils.UnboxAsString(unpackedudon.IUdonHeap, address, UnboxVariable);
                                builder.AppendLine($"[Udon Unboxer] : ACTION {udonnode.name} : HEAP Address : {address} Found Symbol : {symbol}, Type : {Il2CppType.FullName} with value : {unpackedsymbol}");
                            }
                        }
                    }
                    var resultString = Regex.Replace(builder.ToString(), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline); // This will fix and remove Useless empty lines. (but from file it can be kept)
                    ModConsole.Log(resultString, System.Drawing.Color.Gold);
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
                                var unpackedsymbol = UdonHeapUnboxerUtils.UnboxAsString(unpackedudon.IUdonHeap, address, UnboxVariable);
                                _ = builder.AppendLine($"[Udon Unboxer] : ACTION {udonnode.name} : HEAP Address : {address} Found Symbol : {symbol}, Type : {Il2CppType.FullName} with value : {unpackedsymbol}");
                            }
                        }
                    }
                }
                return builder.ToString();
            }
            return null;
        }

        internal static void GenerateGettersReaders(UdonBehaviour node)
        {
            UdonVariableGenerator.HeapGetterGenerator(node.ToRawUdonBehaviour());
        }
    }
}