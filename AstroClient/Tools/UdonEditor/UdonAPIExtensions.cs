


using System.Linq;
using AstroClient.xAstroBoy.Extensions;
using VRC.Udon.Common.Interfaces;

namespace AstroClient.Tools.UdonEditor
{
    using VRC.Udon;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib;

    internal static class UdonAPIExtensions
    {
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
                            var key = entry.key;
                            if (key.IsNotNullOrEmptyOrWhiteSpace())
                            {
                                if (!keys.Contains(entry.key))
                                {
                                    keys.Add(entry.key);
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
        /// <param name="behaviour"></param>
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