﻿namespace AstroClient.Tools.UdonEditor
{
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;

    internal class UdonUnpacker_Utils
    {
        internal static RawUdonBehaviour ToRawUdonBehaviour(UdonBehaviour udon)
        {
            if (udon != null)
            {
                IUdonProgram program = null;
                IUdonSymbolTable symbol_table = null;
                IUdonHeap heap = null;
                if (udon._program != null)
                {
                    program = udon._program;
                }
                if (program != null)
                {
                    symbol_table = program.SymbolTable;
                    if (symbol_table != null)
                    {
                        if (program.Heap != null)
                        {
                            heap = program.Heap;
                        }
                        else
                        {
                            ModConsole.DebugWarning($"Can't Unpack Udon Behaviour {udon.name}, IUdonHeap is Null!");
                            return null;
                        }
                        if (program != null && symbol_table != null && heap != null)
                        {
                            return new RawUdonBehaviour(udon, program, symbol_table, heap, udon.transform);
                        }
                    }
                    else
                    {
                        ModConsole.DebugWarning($"Can't Unpack Udon Behaviour {udon.name}, IUdonSymbolTable is Null!");
                        return null;
                    }
                }
                else
                {
                    ModConsole.DebugWarning($"Can't Unpack Udon Behaviour {udon.name}, IUdonProgram is Null!");

                    return null;
                }
            }
            return null;
        }
    }
}