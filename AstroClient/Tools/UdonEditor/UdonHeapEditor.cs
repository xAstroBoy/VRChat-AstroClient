namespace AstroClient.Tools.UdonEditor
{
    using System;
    using Extensions;
    using VRC.Udon.Common.Interfaces;


    internal static class UdonHeapEditor
    {



        internal static void PatchHeap<T>(RawUdonBehaviour UnpackedUdonBehaviour, string symbol, T value, Action OnSuccess = null, Action onFailure = null, bool ShowSuccessMessages = false, bool ShowFailedMessages = false)
        {
            if (UnpackedUdonBehaviour != null)
            {
                PatchHeap(UnpackedUdonBehaviour.IUdonHeap, UnpackedUdonBehaviour.IUdonSymbolTable.GetAddressFromSymbol(symbol), value, OnSuccess, onFailure, ShowSuccessMessages, ShowFailedMessages);
            }
            else
            {
                Log.Debug("Unable To Patch Udon Heap as is null!");
            }
        }


        internal static void PatchHeap<T>(IUdonHeap heap, uint address, T value, Action OnSuccess = null, Action onFailure = null, bool ShowSuccessMessages = false, bool ShowFailedMessages = false)
        {
            if (heap != null && value != null && address != null)
            {
                try
                {
                    heap.SetHeapVariable<T>(address, value);
                    var result = heap.GetHeapVariable<T>(address);
                    if (result.Equals(value))
                    {
                        if (ShowSuccessMessages)
                        {
                            Log.Debug($"Heap Patch Applied.");
                        }
                        if (OnSuccess != null) OnSuccess();
                    }
                    else
                    {
                        if (ShowFailedMessages)
                        {
                            Log.Debug($"Heap Patch Failed : {typeof(T).FullName}");
                        }
                        if (onFailure != null) onFailure();
                    }
                }
                catch
                {
                    if (ShowFailedMessages)
                    {
                        Log.Debug($"Exception Heap Patch Failed : {typeof(T).FullName}");
                    }
                    if (onFailure != null) onFailure();
                }
            }
            else
            {
                Log.Debug("Unable To Patch Udon Heap as is null!");
                if (onFailure != null) onFailure();
            }

        }

    }
}