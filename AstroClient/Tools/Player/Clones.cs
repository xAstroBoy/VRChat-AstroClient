
using AstroClient.ClientActions;

namespace AstroClient.Tools.Player
{
    using System.Collections.Generic;
    using Extensions;
    using UnityEngine;

    internal class Clones : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
        }


        private void OnRoomLeft() => ClonesCapsules.Clear();

        internal static void SpawnClone() => ClonesCapsules.Add(PlayerCloner.CloneLocalPlayerAvatar());

        internal static void RemoveClones()
        {
            try
            {
                for (int i = 0; i < ClonesCapsules.Count; i++)
                {
                    GameObject clone = ClonesCapsules[i];
                    if (clone != null)
                    {
                        clone.DestroyMeLocal();
                    }
                }
                ClonesCapsules.Clear();
            }
            catch { }
        }

        private static List<GameObject> ClonesCapsules = new List<GameObject>();
    }
}