using System;
using System.Collections.Generic;
using FakeUdon;
using VRC.Udon.Common;

namespace AstroClient.Tools.UdonEditor
{
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;

    internal class UdonUnpacker_Utils
    {

        internal static RawUdonBehaviour ToRawUdonBehaviour(UdonBehaviour udon, bool IgnoreProgramNull = false)
        {
            if (udon != null)
            {
                if (udon._program != null)
                {
                    var RealProgram = udon._program.TryCast<UdonProgram>();
                    if (RealProgram != null)
                    {
                        var symbol_table = RealProgram.SymbolTable.TryCast<UdonSymbolTable>();
                        if (symbol_table != null)
                        {
                            if (RealProgram.Heap != null)
                            {
                                var heap = RealProgram.Heap.TryCast<UdonHeap>();
                                if (heap != null)
                                {
                                    return new RawUdonBehaviour(udon, RealProgram, symbol_table, heap, udon.transform);
                                }
                            }
                            else
                            {
                                Log.Warn($"Can't Unpack Udon Behaviour {udon.name}, UdonHeap is Null!");
                                return null;
                            }

                        }
                        else
                        {
                            Log.Warn($"Can't Unpack Udon Behaviour {udon.name}, UdonSymbolTable is Null!");
                            return null;
                        }
                    }
                    else
                    {
                        var FakeUdonProgram = udon._program.TryCast<FakeUdonProgram>();
                        if (FakeUdonProgram != null)
                        {
                            var symbol_table = FakeUdonProgram.SymbolTable.TryCast<UdonSymbolTable>();
                            if (symbol_table != null)
                            {
                                if (FakeUdonProgram.Heap != null)
                                {
                                    var FakeHeap = FakeUdonProgram.Heap.TryCast<FakeUdonHeap>();
                                    if (FakeHeap != null)
                                    {
                                        return new RawUdonBehaviour(udon, FakeUdonProgram, symbol_table, FakeHeap, udon.transform);
                                    }
                                }
                                else
                                {
                                    Log.Warn($"Can't Unpack Udon Behaviour {udon.name}, UdonHeap is Null!");
                                    return null;
                                }

                            }
                            else
                            {
                                Log.Warn($"Can't Unpack Udon Behaviour {udon.name}, UdonSymbolTable is Null!");
                                return null;
                            }

                        }
                        else
                        {
                            Log.Warn($"Can't Unpack Udon Behaviour {udon.name}, UdonProgram is Null!");
                        }

                        return null;
                    }
                }
            }
            return null;
        }
    }
}