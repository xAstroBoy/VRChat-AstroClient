using AstroClient.xAstroBoy.Extensions;
using System;
using System.Linq;
using VRC.Udon.Common.Interfaces;

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
        internal static bool isHeapVariableValid<T>(this IUdonHeap heap, uint address)
        {
            if (heap == null) return false;
            try
            {
                if (!heap.IsHeapVariableInitialized(address))
                {
                    heap.InitializeHeapVariable<T>(address);
                }
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }

            try
            {
                _ = heap.GetHeapVariable<T>(address);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(TypeInitializationException))
                {
                    try
                    {
                        heap.InitializeHeapVariable<T>(address);
                    }
                    catch { }
                    try
                    {
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
                var address = udon.IUdonSymbolTable.GetAddressFromSymbol(symbolName);
                if (address != null)
                {
                    return udon.IUdonHeap.isHeapVariableValid<T>(address);
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
                if (udon.IUdonSymbolTable.HasSymbolForAddress(address))
                {
                    return udon.IUdonHeap.isHeapVariableValid<T>(address);
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
                    var entries = table.Get_Entries();
                    if (entries != null)
                    {
                        for (var index = 0; index < entries.Count; index++)
                        {
                            var entry = entries[index];
                            if (entry != null)
                            {
                                var key = entry.key;
                                if (key.IsNotNullOrEmptyOrWhiteSpace())
                                {
                                    if (!keys.Contains(entry.key))
                                    {
                                        keys.Add(entry.key);
                                    }
                                }
                            }
                        }
                        if (keys.Count() != 0)
                        {
                            return keys.ToArray();
                        }
                    }
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
        /// Shortcut to access Udon EventTable
        /// </summary>
        /// <param name="eventtable"></param>
        /// <returns></returns>
        internal static Il2CppReferenceArray<Dictionary<string, List<uint>>.Entry> Get_Entries(this Dictionary<string, List<uint>> eventtable)
        {
            return eventtable.entries;
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