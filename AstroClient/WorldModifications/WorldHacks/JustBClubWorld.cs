namespace AstroClient.WorldModifications.Modifications
{
    #region Imports

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.AstroUdons;
    using AstroMonos.Components.Cheats.Worlds.JustBClub;
    using AstroMonos.Components.Spoofer;
    using AstroMonos.Components.Tools;
    using AstroMonos.Components.Tools.Listeners;
    using CheetosUI;
    using Constants;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.UdonEditor;
    using Tools.UdonSearcher;
    using UnityEngine;
    using VRC.Udon;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Utility;
    using static Constants.CustomLists;

    #endregion Imports

    internal class JustBClubWorld : AstroEvents
    {

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.JustBClub)
            {
                isJustBClubWorld = true;
                InitEverything();
            }
            else
            {
                isJustBClubWorld = false;
            }
        }

        private static void InitEverything()
        {
            if (Patreon != null)
            {
                if (PatronEditor == null)
                {
                    PatronEditor = Patreon.GetOrAddComponent<JustBClub_PatronControlEditor>();
                }
            }
        }

        private static bool _IsPatron;

        internal static bool isPatron
        {
            get
            {
                return _IsPatron;
            }
            set
            {
                _IsPatron = value;
                PatronEditor.SetAsPatron(value);
            }
        }

        private static GameObject _Udon;
        internal static GameObject Udon
        {
            get
            {
                if (!isJustBClubWorld) return null;
                if (_Udon == null)
                {
                    return _Udon = GameObjectFinder.FindRootSceneObject("Udon");
                }

                return _Udon;
            }
        }
        private static GameObject _Patreon;
        internal static GameObject Patreon
        {
            get
            {
                if (!isJustBClubWorld) return null;
                if (Udon == null) return null;
                if (_Patreon == null)
                {
                    return _Patreon = Udon.transform.FindObject("Patreon").gameObject;
                }

                return _Patreon;
            }
        }

        internal override void OnRoomLeft()
        {
            isJustBClubWorld = false;
            PatronEditor = null;
        }

        private static JustBClub_PatronControlEditor PatronEditor { get; set; }
        private static bool isJustBClubWorld { get; set; } = false;
    }
}