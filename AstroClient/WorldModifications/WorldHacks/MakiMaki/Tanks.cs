using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Cheats.Worlds.MakiMaki;
using AstroClient.ClientActions;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.WorldModifications.WorldHacks.MakiMaki
{
    internal class Tanks : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private void PatchPatronSystem()
        {
                CustomizationManager = Finder.Find("Customization");
            if(CustomizationManager != null)
            {
                _ = CustomizerManagerReader;
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.Maki_Tanks))
            {
                isSupportedWorld = true;
                PatchPatronSystem();
            }
            else
            {
                isSupportedWorld = false;
            }
        }

        private static GameObject CustomizationManager = null;

        private static MakiMaki_CustomizationReader _CustomizerManagerReader;

        public static MakiMaki_CustomizationReader CustomizerManagerReader
        {
            get
            {
                if (!isSupportedWorld) return null;

                if (_CustomizerManagerReader == null)
                {
                    if (CustomizationManager != null)
                    {
                        return _CustomizerManagerReader = CustomizationManager.GetOrAddComponent<MakiMaki_CustomizationReader>();
                    }
                }
                return _CustomizerManagerReader;

            }
        }

        private static bool isSupportedWorld = false;
    }
}