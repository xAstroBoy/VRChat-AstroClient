using Il2CppSystem.Reflection;
using Il2CppSystem.Runtime.CompilerServices;
using UnhollowerRuntimeLib;
using VRC.Udon;
using VRC.Udon.Common;

namespace AstroClient.Tools.UdonEditor
{
    using System.Threading.Tasks;
    using VRC.Udon.Common.Interfaces;
    using System.IO;
    using VRC.Udon.VM.Common;
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;

        // This is a modified version of `VRC.Udon.Compiler.dll`

        internal class DisassemblerV2
    {
        static System.Random rnd = new System.Random();

        private static void DisectUdonBehaviour(UdonBehaviour target) {
        var builder = new StringBuilder();
        try {
            var entries = new System.Collections.Generic.Dictionary<uint, string>();
                var asset = target.serializedProgramAsset;
            var program = target._program.TryCast<UdonProgram>();

            builder.AppendLine("Entry Points:");
            var entrypoints = program.EntryPoints.TryCast<UdonSymbolTable>();
            foreach (var entry in target.GetPrograms())
                entries[program.EntryPoints.GetAddressFromSymbol(entry)] = entry;
            foreach (var s in entries) {
                builder.AppendLine($"0x{s.Key:X8}: {s.Value}");
            }
            var syncMetadataTable = target.SyncMetadataTable;

            builder.AppendLine("\nVariables:");
            var FillList = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.ValueTuple<uint, IStrongBox, Il2CppSystem.Type>>();
            program.Heap.DumpHeapObjects(FillList);
                var vl = new List<Il2CppSystem.ValueTuple<uint, IStrongBox, Il2CppSystem.Type>>();
                foreach (var entry in FillList)
                {
                    vl.Add(entry);
                }

                var dictvl = vl.ToDictionary(x => x.Item1, y => (y.Item2, y.Item3));
            foreach (var v in vl) {
                    var address = v.Item1;

                string symbol = null;
                var syncString = "";
                try {
                    var hasSymbol = program.SymbolTable.TryGetSymbolFromAddress(v.Item1, out symbol);
                    if (!hasSymbol) {
                        symbol = $"_@0x{v.Item1:X}";
                    } else if (syncMetadataTable.GetSyncMetadataFromSymbol(symbol) != null)
                        syncString = " (synced)";
                } catch {}
                try {
                    var arr = (Il2CppSystem.Object[])v.Item2.Value;
                    builder.AppendLine($"0x{v.Item1:X8}: {symbol} ({v.Item3?.Name}){syncString}: {arr.ToString()}[{arr.Length}] {{ {string.Join(", ", arr)} }}");
                    continue;
                }catch {}
                if (v.Item2.Value as System.String[] != null) {
                    var arr = v.Item2.Value as System.Array;
                    // foreach (var k in arr)
                    builder.AppendLine($"0x{v.Item1:X8}: {symbol} ({v.Item3?.Name}){syncString}: {string.Join(", ", arr)}");
                } else {
                    builder.AppendLine($"0x{v.Item1:X8}: {symbol} ({v.Item3?.Name}){syncString}: {v.Item2?.Value?.ToString()}");
                }
            }
            
            builder.AppendLine("\nCode:");
            foreach (var p in DisassembleProgram(program, dictvl)) {
                builder.AppendLine(p);
            }
            
            var scene_name = UnityEngine.SceneManagement.SceneManager.GetSceneAt(0).name;
            var script_name = (vl.Count >= 2 && vl[1].Item3 == Il2CppType.Of<string>() && program.SymbolTable.GetSymbolFromAddress(1) == "__refl_const_intnl_udonTypeName") ? asset.name + " " + vl[1].Item2.Value as string : asset.name;
            string FixPath(string file_name) {
                foreach (char c in System.IO.Path.GetInvalidFileNameChars())
                    file_name = file_name.Replace(c, '_');
                return file_name;
            }
            var path = $"{Application.streamingAssetsPath}/{FixPath(scene_name)}/{FixPath(target.name)} ({script_name}) ({rnd.Next()})";
            Log.Write($"Writing disassembly to {path}");
            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
            System.IO.File.WriteAllText(path + ".txt", builder.ToString());
        } catch (Exception e) {Log.Exception(e);}
    }

    private static IEnumerable<string> DisassembleProgram(IUdonProgram program, Dictionary<uint, (IStrongBox strongBoxedObject, Type objectType)> varData) {
        byte[] byteCode = program.ByteCode;
        uint offset = 0u;
        while (offset < byteCode.Length) {
            if (program.EntryPoints.TryGetSymbolFromAddress(offset, out var symbol))
                yield return $"\n\t{symbol}:\n";

            var disassembly = DisassembleInstruction(program, varData, ref offset);
            yield return disassembly;
        }
        yield break;
    }

    private static string DisassembleInstruction(IUdonProgram program, Dictionary<uint, (IStrongBox strongBoxedObject, Type objectType)> varData, ref uint offset)
    {
        StringBuilder stringBuilder = new StringBuilder();
        OpCode opCode = (OpCode)UIntFromBytes(program.ByteCode, offset);
        switch (opCode)
        {
        case OpCode.NOP:
            stringBuilder.Append(SimpleInstruction("NOP", ref offset));
            break;
        case OpCode.PUSH:
            stringBuilder.Append(DirectInstructionSourceHeap("PUSH", program, varData, ref offset));
            break;
        case OpCode.POP:
            stringBuilder.Append(SimpleInstruction("POP", ref offset));
            break;
        case OpCode.JUMP_IF_FALSE:
            stringBuilder.Append(DirectInstruction("JUMP_IF_FALSE", program, ref offset));
            break;
        case OpCode.JUMP:
            stringBuilder.Append(DirectInstruction("JUMP", program, ref offset));
            break;
        case OpCode.EXTERN:
            stringBuilder.Append(ExternInstruction("EXTERN", program, ref offset));
            break;
        case OpCode.ANNOTATION:
            stringBuilder.Append(AnnotationInstruction("ANNOTATION", program, ref offset));
            break;
        case OpCode.JUMP_INDIRECT:
            stringBuilder.Append(JumpIndirectInstruction("JUMP_INDIRECT", program, ref offset));
            break;
        case OpCode.COPY:
            stringBuilder.Append(SimpleInstruction("COPY", ref offset));
            break;
        default:
            stringBuilder.Append($"0x{offset:X8}: Unknown OpCode (0x{(uint)opCode:X8})");
            offset += 4u;
            break;
        }
        return stringBuilder.ToString();
    }

    private static string SimpleInstruction(string name, ref uint offset)
    {
        string result = $"0x{offset:X8}: {name}";
        offset += 4u;
        return result;
    }

    private static string DirectInstruction(string name, IUdonProgram program, ref uint offset)
    {
        var address = UIntFromBytes(program.ByteCode, offset + 4);
        string text = "0x" + Convert.ToString(address, 16).PadLeft(8, '0').ToUpper();
        string result = $"0x{offset:X8}: {name}, {text}";
        offset += 8u;
        return result;
    }
    private static string DirectInstructionSourceHeap(string name, IUdonProgram program, Dictionary<uint, (IStrongBox strongBoxedObject, Type objectType)> varData, ref uint offset)
    {
        var address = UIntFromBytes(program.ByteCode, offset + 4);
        var hasValue = varData.ContainsKey(address);
        string text = "[Empty]";
        if(hasValue)
        {
            var objz = varData[address].strongBoxedObject.Value;
            bool success = true;
            try {
                var arr = (System.Object[])objz;
                text = string.Join(", ", arr);
            }
            catch {
                success = false;

            }
            if(!success)
            {
                if (objz as System.String[] != null) {
                    var arr = objz as System.Array;
                    // foreach (var k in arr)
                    text = string.Join(", ", arr);
                } else {
                    text = varData[address].strongBoxedObject?.Value?.ToString();
                }
            }
        }
        else
        {
            text = ("0x" + Convert.ToString(address, 16).PadLeft(8, '0').ToUpper());
        }
        var hasSymbol = program.SymbolTable.TryGetSymbolFromAddress(address, out var symbol);
        if (!hasSymbol) symbol = $"_@0x{address:X}";
        string result = $"0x{offset:X8}: {name}, {text} ({symbol})";
        offset += 8u;
        return result;
    }

    private static string AnnotationInstruction(string name, IUdonProgram program, ref uint offset)
    {
        uint address = UIntFromBytes(program.ByteCode, offset + 4);
        string heapVariable = (program.Heap.GetHeapVariableType(address) == typeof(string)) ?
                                program.Heap.GetHeapVariable<string>(address) :
                                program.Heap.GetHeapVariable(address).ToString();
        string result = $"0x{offset:X8}: {name}, \"{heapVariable}\"";
        offset += 8u;
        return result;
    }

    private static string ExternInstruction(string name, IUdonProgram program, ref uint offset)
    {
        uint address = UIntFromBytes(program.ByteCode, offset + 4);
        string heapVariable = (program.Heap.GetHeapVariableType(address) == typeof(string)) ?
                                program.Heap.GetHeapVariable<string>(address) :
                                program.Heap.GetHeapVariable(address).ToString();
        string result = $"0x{offset:X8}: {name}, \"{heapVariable}\"";
        offset += 8u;
        return result;
    }

    private static string JumpIndirectInstruction(string name, IUdonProgram program, ref uint offset)
    {
        uint num = UIntFromBytes(program.ByteCode, offset + 4);
        string text = Convert.ToString(num, 16).PadLeft(8, '0');
        string result = ((!program.SymbolTable.HasSymbolForAddress(num)) ? $"0x{offset:X8}: {name}, 0x{text.ToUpper()}" : $"0x{offset:X8}: {name}, {program.SymbolTable.GetSymbolFromAddress(num)}");
        offset += 8u;
        return result;
    }

    private static uint UIntFromBytes(byte[] bytes, uint startIndex)
    {
        return (uint)((bytes[startIndex] << 24) + (bytes[startIndex + 1] << 16) + (bytes[startIndex + 2] << 8) + bytes[startIndex + 3]);
    }
    }

}


}

