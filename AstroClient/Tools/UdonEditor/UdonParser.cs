﻿namespace AstroClient.Tools.UdonEditor
{
    using System.Collections.Generic;
    using AstroMonos.AstroUdons.Programs;
    using UnityEngine;
    using VRC.Udon;
    using xAstroBoy;

    internal class UdonParser
    {
        // CRITICAL : OPTIMIZE.
        internal static List<UdonBehaviour> FilteredUdonBehaviours()
        {
            var result = new List<UdonBehaviour>();
            var currentlist = GameObjectFinder.GetRootGameObjectsComponents<UdonBehaviour>();
            foreach (var item in currentlist)
            {
                if (item.serializedProgramAsset != null)
                {
                    if (item.serializedProgramAsset.Equals(UdonPrograms.InteractProgram) ||
                        item.serializedProgramAsset.Equals(UdonPrograms.PickupProgram))
                    {
                        continue;
                    }
                }
                result.Add(item);
            }
            return result;
        }


        internal static UdonBehaviour[] WorldBehaviours
        {
            get => Resources.FindObjectsOfTypeAll<UdonBehaviour>();
        }
    }
}