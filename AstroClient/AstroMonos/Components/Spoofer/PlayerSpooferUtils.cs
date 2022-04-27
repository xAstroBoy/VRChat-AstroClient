using AstroClient.ClientActions;

namespace AstroClient.AstroMonos.Components.Spoofer
{
    using System.Drawing;
    using ClientUI.Menu.Menus.Quickmenu;
    using Constants;
    using UnhollowerBaseLib.Attributes;
    using xAstroBoy.Utility;

    internal class PlayerSpooferUtils : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomJoined += OnRoomJoined;
            ClientEventActions.Delayed_Event_VRChat_OnUiManagerInit += VRChat_OnUiManagerInit;

        }

        private void OnRoomJoined()
        {
            TryMakeInstance();
        }

        private void VRChat_OnUiManagerInit()
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
                if (Instance != null) Log.Debug("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
                else Log.Debug("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
            }
        }

        internal static void SpoofAs(string name)
        {
            IsSpooferActive = true;
            SpoofedName = name;
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
        internal static bool KeepNameActivatedOnWorldChange
        {
            get => Instance.KeepSpoofingOnWorldChange;
            set => Instance.KeepSpoofingOnWorldChange = value;
        }

        internal static string Original_DisplayName
        {
            get => Instance.Original_DisplayName;
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
                    if (WorldUtils.IsInWorld)
                    {
                        SpoofedName = WorldUtils.AuthorName;
                    }
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