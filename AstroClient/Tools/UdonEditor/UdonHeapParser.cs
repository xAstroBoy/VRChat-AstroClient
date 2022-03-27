namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using VRC.Udon.Common.Interfaces;



    // TODO: Figure how to make the Type Nullable (this way it doesn't give a fake value)

    internal static class UdonHeapParser
    {
        internal static T Udon_Parse<T>(RawUdonBehaviour UnpackedUdonBehaviour, string symbol) 
        {
            if (UnpackedUdonBehaviour != null)
            {
                return Udon_Parse<T>(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol));
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return default(T);
        }

        internal static T Udon_Parse<T>(IUdonHeap heap, uint address)
        {
            if (heap != null)
            {
                var value = heap.GetHeapVariable<T>(address);
                if (value != null)
                {
                    return value;
                }
            }
            else
            {
                ModConsole.DebugLog("Unable To Parse Udon Heap value as Heap is null!");
            }
            return default(T);
        }

    }
}