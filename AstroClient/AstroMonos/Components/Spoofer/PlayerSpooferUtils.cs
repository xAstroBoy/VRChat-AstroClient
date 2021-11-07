﻿namespace AstroClient.AstroMonos.Components.Spoofer
{
    using System.Drawing;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using ClientUI.QuickMenuButtons;
    using UnhollowerBaseLib.Attributes;
    using Variables;

    internal class PlayerSpooferUtils : GameEvents
    {
        internal override void OnUpdate()
        {
            TryMakeInstance();
        }

        internal static void TryMakeInstance()
        {
            if (Instance == null)
            {
                string name = "PlayerSpoofer";
                var gameobj = InstanceBuilder.GetInstanceHolder(name);
                Instance = gameobj.AddComponent<PlayerSpoofer>();
                UnityEngine.Object.DontDestroyOnLoad(gameobj);
                if (Instance != null) ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                else ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
            }
        }

        private static PlayerSpoofer Instance;

        internal static PlayerSpoofer SpooferInstance
        {
            get => Instance;
        }

        internal static bool IsSpooferActive
        {
            get => Instance.IsSpooferActive;
            set => Instance.IsSpooferActive = value;
        }

        internal static string SpoofedName
        {
            get => Instance.SpoofedName;
            set => Instance.SpoofedName = value;
        }

        private static bool _SpoofASWorldAuthor;
        internal static bool SpoofAsWorldAuthor
        {
            get => _SpoofASWorldAuthor;
            set
            {
                _SpoofASWorldAuthor = value;
                if (value)
                {
                    SpoofAsInstanceMaster = false;
                    IsSpooferActive = true;
                    SpoofedName = WorldUtils.AuthorName;
                }
                else
                {
                    SpooferInstance.IsSpooferActive = false;
                }
                ExploitsMenu.ToggleWorldAuthorSpoofer?.SetToggleState(value);
            }
        }

        private static bool _SpoofAsInstanceMaster;
        internal static bool SpoofAsInstanceMaster
        {
            [HideFromIl2Cpp]
            get => _SpoofAsInstanceMaster;
            [HideFromIl2Cpp]
            set
            {
                _SpoofAsInstanceMaster = value;
                if (value)
                {
                    SpoofAsWorldAuthor = false;
                    IsSpooferActive = true;
                    SpoofedName = WorldUtils.InstanceMaster.GetAPIUser().displayName;
                }
                else SpooferInstance.IsSpooferActive = false;

                if (ExploitsMenu.ToggleInstanceMasterSpoofer != null) ExploitsMenu.ToggleInstanceMasterSpoofer.SetToggleState(value);
            }
        }
    }
}