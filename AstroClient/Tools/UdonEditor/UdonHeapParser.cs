#nullable enable
using FakeUdon;
using VRC.Udon.Common;

namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using Extensions;
    using VRC.Udon.Common.Interfaces;



    // TODO: Figure how to make the Type Nullable (this way it doesn't give a fake value)

    internal static class UdonHeapParser
    {
        internal static T? Udon_Parse<T>(RawUdonBehaviour UnpackedUdonBehaviour, string symbol)
        {
            if (UnpackedUdonBehaviour != null)
            {
                if (!UnpackedUdonBehaviour.isFakeUdon)
                {
                    return Udon_Parse<T>(UnpackedUdonBehaviour.UdonHeap, UnpackedUdonBehaviour.UdonSymbolTable.GetAddressFromSymbol(symbol));
                }
                else
                {
                    return Udon_Parse<T>(UnpackedUdonBehaviour.FakeUdonHeap, UnpackedUdonBehaviour.UdonSymbolTable.GetAddressFromSymbol(symbol));
                }
            }
            else
            {
                Log.Debug("Unable To Parse Udon Heap value as Heap is null!");
            }
            return default(T); ;
        }

        internal static T? Udon_Parse<T>(UdonHeap heap, uint address)
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
                Log.Debug("Unable To Parse Udon Heap value as Heap is null!");
            }
            return default(T);
        }
        internal static T? Udon_Parse<T>(FakeUdonHeap heap, uint address)
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
                Log.Debug("Unable To Parse Udon Heap value as Heap is null!");
            }
            return default(T);

        }
    }
}