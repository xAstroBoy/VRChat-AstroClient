﻿namespace AstroClient.Udon.UdonEditor
{
    using AstroLibrary.Finder;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AstroMonos.AstroUdons.Programs;
    using VRC.Udon;

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


        internal static UdonBehaviour[] CleanedWorldBehaviours
        {
            get => FilteredUdonBehaviours().ToArray();
        }
    }
}
