namespace AstroClient.Features.Player.Clones
{
    using AstroLibrary.Extensions;
    using System.Collections.Generic;
    using UnityEngine;

    internal class Clones : GameEvents
    {
        internal static void OnLevelLoad() => ClonesCapsules.Clear();

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