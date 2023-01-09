using AstroClient.xAstroBoy.Extensions;
using System;
using System.Linq;
using FakeUdon;
using VRC.Udon.Common;
using VRC.Udon.Common.Interfaces;
using Enumerable = Il2CppSystem.Linq.Enumerable;

namespace AstroClient.Tools.UdonEditor
{
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib;
    using VRC.Udon;

    internal static class UdonAPIExtensions
    {
        /// <summary>
        /// This verifies and avoids TypeUnitializedException by doing 2 steps
        /// First it asks the heap if the Variable is initalized, if not inits it, then tries to read it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="heap"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        internal static bool isHeapVariableValid<T>(this UdonHeap heap, uint address)
        {
            if (heap == null) return false;
            try
            {
                // Check if Heap is initialized, if not inits it.
                if (!heap.IsHeapVariableInitialized(address))
                {
                    heap.InitializeHeapVariable<T>(address);
                }
            }
            catch {}

            try
            {
                // Try to read heap address, if it throws the exception, try again.
                _ = heap.GetHeapVariable<T>(address);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(TypeInitializationException))
                {
                    try
                    {
                        // init again.
                        heap.InitializeHeapVariable<T>(address);
                    }
                    catch { }
                    try
                    {
                        // try for the second time, if it fails, we can't do aything.
                        _ = heap.GetHeapVariable<T>(address);
                    }
                    catch (Exception e3)
                    {
                        if (e3.GetType() == typeof(TypeInitializationException))
                        {
                            //TODO: Figure how to Get a valid result.
                            return false; // no need to proceed as udon won't give us anything.
                        }
                    }
                }
            }

            return true;
        }
        /// <summary>
        /// This verifies and avoids TypeUnitializedException by doing 2 steps
        /// First it asks the heap if the Variable is initalized, if not inits it, then tries to read it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="heap"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        internal static bool isHeapVariableValid<T>(this FakeUdonHeap heap, uint address)
        {
            if (heap == null) return false;
            try
            {
                // Check if Heap is initialized, if not inits it.
                if (!heap.IsHeapVariableInitialized(address))
                {
                    heap.InitializeHeapVariable<T>(address);
                }
            }
            catch { }

            try
            {
                // Try to read heap address, if it throws the exception, try again.
                _ = heap.GetHeapVariable<T>(address);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(TypeInitializationException))
                {
                    try
                    {
                        // init again.
                        heap.InitializeHeapVariable<T>(address);
                    }
                    catch { }
                    try
                    {
                        // try for the second time, if it fails, we can't do aything.
                        _ = heap.GetHeapVariable<T>(address);
                    }
                    catch (Exception e3)
                    {
                        if (e3.GetType() == typeof(TypeInitializationException))
                        {
                            //TODO: Figure how to Get a valid result.
                            return false; // no need to proceed as udon won't give us anything.
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// This verifies and avoids TypeUnitializedException by doing 2 steps
        /// First it asks the heap if the Variable is initalized, if not inits it, then tries to read it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="heap"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        internal static bool isHeapVariableValid<T>(this RawUdonBehaviour udon, string symbolName)
        {
            if (udon == null) return false;
            try
            {
                var address = udon.UdonSymbolTable.GetAddressFromSymbol(symbolName);
                if (address != null)
                {
                    if (!udon.isFakeUdon)
                    {
                        return udon.UdonHeap.isHeapVariableValid<T>(address);
                    }
                    else
                    {
                        return udon.FakeUdonHeap.isHeapVariableValid<T>(address);
                    }
                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// This verifies and avoids TypeUnitializedException by doing 2 steps
        /// First it asks the heap if the Variable is initalized, if not inits it, then tries to read it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="heap"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool isHeapVariableValid<T>(this RawUdonBehaviour udon, uint address)
        {
            if (udon == null) return false;
            try
            {
                if (udon.UdonSymbolTable.HasSymbolForAddress(address))
                {
                    if (!udon.isFakeUdon)
                    {
                        return udon.UdonHeap.isHeapVariableValid<T>(address);
                    }
                    else
                    {
                        return udon.FakeUdonHeap.isHeapVariableValid<T>(address);
                    }

                }
            }
            catch { }

            return false;
        }

        /// <summary>
        /// This Extracts and filters invalid eventkeys such as
        /// "",
        /// Empty,
        /// and others invalid udon keys
        /// This will return null if extraction count is 0.
        /// </summary>
        /// <param name="behaviour"></param>
        /// <returns></returns>
        internal static string[] Get_EventKeys(this UdonBehaviour behaviour)
        {
            if (behaviour != null)
            {
                var keys = new System.Collections.Generic.List<string>();
                var table = behaviour.Get_EventTable();
                if (table != null)
                {
                    //var entries = table.entries;
                    //if (entries != null)
                    //{
                    //    for (var index = 0; index < entries.Count; index++)
                    //    {
                    //        var Event = entries[index];
                    //        if (Event != null)
                    //        {
                    //            if (Event.key.IsNotNullOrEmptyOrWhiteSpace())
                    //            {
                    //                if (!keys.Contains(Event.key))
                    //                {
                    //                    keys.Add(Event.key);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    foreach(var item in table.Keys)
                    {
                        if (item.IsNotNullOrEmptyOrWhiteSpace())
                        {
                            if (!keys.Contains(item))
                            {
                                keys.Add(item);
                            }
                        }

                    }
                }
                if (keys.Count() != 0)
                {
                    return keys.ToArray();
                }

            }
            return null;
        }

        /// <summary>
        /// Sends a event to a UdonBehaviour.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="key"></param>
        /// <param name="target"></param>
        internal static void SendUdonEvent(this UdonBehaviour action, string key, NetworkEventTarget target = NetworkEventTarget.All)
        {
            if (key.IsNullOrEmptyOrWhiteSpace()) return;
            if (key.StartsWith("_"))
            {
                action.SendCustomEvent(key);
            }
            else
            {
                action.SendCustomNetworkEvent(target, key);
            }
        }

        /// <summary>
        /// Shortcut to access Udon EventTable
        /// </summary>
        /// <param name="behaviour"></param>
        /// <returns></returns>
        internal static Dictionary<string, List<uint>> Get_EventTable(this UdonBehaviour behaviour)
        {
            return behaviour._eventTable;
        }


        /// <summary>
        /// Shortcut to access Udon Entries
        /// </summary>
        /// <param name="behaviour"></param>
        /// <returns></returns>
        internal static Il2CppReferenceArray<Dictionary<string, List<uint>>.Entry> Get_Entries(this UdonBehaviour behaviour)
        {
            return behaviour.Get_EventTable().entries;
        }
    }
}