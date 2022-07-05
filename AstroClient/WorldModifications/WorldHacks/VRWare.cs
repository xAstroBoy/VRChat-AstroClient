using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonSearcher;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class VRWare : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        internal static QMNestedGridMenu VoidClubMenu;

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id.Equals(WorldIds.VRWare) || id.Equals(WorldIds.VRWare_Test_CrossPlatform))
            {
                ToggleConsole = UdonSearch.FindUdonEvent("ToggleConsole", "_interact");
                ToggleMusic = UdonSearch.FindUdonEvent("Dev_NoMusic", "_interact");
                Trigger_Devouring_Level = UdonSearch.FindUdonEvent("DevRareGameOverride_Devouring", "SendToOwnerForceGame");
                Trigger_BreakTheTargets_Level = UdonSearch.FindUdonEvent("DevRareGameOverride_BreakTheTargets", "SendToOwnerForceGame");
                Trigger_JapanWorld_Level = UdonSearch.FindUdonEvent("DevRareGameOverride_Surprise", "SendToOwnerForceGame");
                Trigger_ExitVRChat_Level = UdonSearch.FindUdonEvent("DevRareGameOverride_Exit", "SendToOwnerForceGame");
                Trigger_Race_Level = UdonSearch.FindUdonEvent("DevRareGameOverride_Dodge", "SendToOwnerForceGame");
                if (ToggleConsole != null)
                {
                    ToggleConsole.gameObject.SetActive(true);
                    ToggleConsole.DisableInteractive = false;

                }

                if (ToggleMusic != null)
                {
                    ToggleMusic.gameObject.SetActive(true);
                    ToggleMusic.DisableInteractive = false;
                }

                if (Trigger_Devouring_Level != null)
                {
                    Trigger_Devouring_Level.gameObject.SetActive(true);
                    Trigger_Devouring_Level.DisableInteractive = false;
                }

                if (Trigger_BreakTheTargets_Level != null)
                {
                    Trigger_BreakTheTargets_Level.gameObject.SetActive(true);
                    Trigger_BreakTheTargets_Level.DisableInteractive = false;

                }

                if (Trigger_JapanWorld_Level != null)
                {
                    Trigger_JapanWorld_Level.gameObject.SetActive(true);
                    Trigger_JapanWorld_Level.DisableInteractive = false;

                }

                if (Trigger_ExitVRChat_Level != null)
                {
                    Trigger_ExitVRChat_Level.gameObject.SetActive(true);
                    Trigger_ExitVRChat_Level.DisableInteractive = false;

                }

                if (Trigger_Race_Level != null)
                {
                    Trigger_Race_Level.gameObject.SetActive(true);
                    Trigger_Race_Level.DisableInteractive = false;

                }


            }
        }


        internal static UdonBehaviour_Cached ToggleConsole { get; set; }
        internal static UdonBehaviour_Cached ToggleMusic { get; set; }

        internal static UdonBehaviour_Cached Trigger_Devouring_Level { get; set; }
        internal static UdonBehaviour_Cached Trigger_BreakTheTargets_Level { get; set; }
        internal static UdonBehaviour_Cached Trigger_JapanWorld_Level { get; set; }
        internal static UdonBehaviour_Cached Trigger_Race_Level { get; set; }
        internal static UdonBehaviour_Cached Trigger_ExitVRChat_Level { get; set; }

    }
}