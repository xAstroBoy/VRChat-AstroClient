namespace AstroClient.Udon.UdonEditor
{
    using AstroClient.Components;
    using AstroLibrary.Finder;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VRC.Udon;

    internal class UdonParser
    {

        internal static List<UdonBehaviour> FilteredUdonBehaviours()
        {
            var result = new List<UdonBehaviour>();
            var currentlist = GameObjectFinder.GetRootGameObjectsComponents<UdonBehaviour>();
            foreach (var item in currentlist)
            {
                if (item.serializedProgramAsset.Equals(UdonPrograms.InteractProgram) || item.serializedProgramAsset.Equals(UdonPrograms.PickupProgram))
                {
                    continue;
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
