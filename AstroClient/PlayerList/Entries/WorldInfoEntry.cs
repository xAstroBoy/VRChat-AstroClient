using System.Collections.Generic;
using System.Globalization;
using AstroClient.Cheetos;
using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.Menus.Quickmenu;
using AstroClient.ClientUI.QuickMenuGUI.SettingsMenu;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.World;
using AstroClient.xAstroBoy.UIPaths;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Text;

namespace AstroClient.PlayerList.Entries
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class WorldInfoEntry : EntryBase
    {
        public WorldInfoEntry(IntPtr obj0) : base(obj0) { }

        [HideFromIl2Cpp]
        public override string Name => "World Info Entry";
        [HideFromIl2Cpp]
        public override void Init(object[] parameters = null)
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            //AvatarSearch.OnPedestralDumpDone += RefreshInfo;
            SceneUtils.OnNoFallHeightLimitToggled += RefreshInfo;
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            Settings_Camera.OnCameraPropertyChanged += RefreshInfo;
        }

        private void OnRoomLeft()
        {
            _SDKType = 1;
            _Avatars = 0;
            _Prefabs = 0;
            _Pickups = 0;
            _UdonBehaviours = 0;
            _Triggers = 0;
            _VRCInteractables = 0;
            _AudioSources = 0;
            _Mirror = 0;

            Update_SDKType = true;
            Update_Avatars = true;
            Update_Prefabs = true;
            Update_Pickups = true;
            Update_UdonBehaviours = true;
            Update_Triggers = true;
            Update_VRCInteractables = true;
            Update_AudioSources = true;
            Update_Mirror = true;

        }

        private void RefreshInfo()
        {
            textComponent.text = MiscWorldInfo();
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            RefreshInfo();
        }

        [HideFromIl2Cpp]
        private static string MiscWorldInfo()
        {
            StringBuilder build = new StringBuilder();
            build.Append(GenerateText("SDK", SDKType.ToString()));
            build.Append(GenerateText("RespawnHeightY", SceneUtils.RespawnHeightY.ToString("R")));
            build.Append(GenerateText("FarClipPlane", PlayerCameraEditor.PlayerCamera.farClipPlane.ToString("R")));
            build.Append(GenerateText("NearClipPlane", PlayerCameraEditor.PlayerCamera.nearClipPlane.ToString("R")));

            if (Avatars != 0)
            {
                build.Append(GenerateText("Avatars", Avatars.ToString()));
            }
            if (Prefabs != 0)
            {
                build.Append(GenerateText("Prefabs", Prefabs.ToString()));
            }


            if (Pickups != 0)
            {
                build.Append(GenerateText("Pickups", Pickups.ToString()));
            }

            if (UdonBehaviours != 0)
            {
                build.Append(GenerateText("UdonBehaviours", UdonBehaviours.ToString()));
            }


            if (Triggers != 0)
            {
                build.Append(GenerateText("Triggers", Triggers.ToString()));
            }

            if (VRCInteractables != 0)
            {
                build.Append(GenerateText("Interactables", VRCInteractables.ToString()));
            }
            if (AudioSources != 0)
            {
                build.Append(GenerateText("AudioSources", AudioSources.ToString()));
            }

            if (Mirrors != 0)
            {
                build.Append(GenerateText("Mirrors", Mirrors.ToString()));
            }



            return build.ToString();
        }



        #region  SDKType
        internal static bool Update_SDKType { get; set; } = true;

        private static int _SDKType;
        internal static int SDKType
        {
            get
            {
                if (Update_SDKType)
                {
                    _SDKType = SceneUtils.SDKVersion;
                    Update_SDKType = false;
                }
                return _SDKType;
            }
        }



        #endregion

        #region  Avatars
        internal static bool Update_Avatars { get; set; } = true;

        private static int _Avatars = 0;
        internal static int Avatars
        {
            get
            {
                if (Update_Avatars)
                {
                    _Avatars = 0; //AvatarSearch.worldAvatarsids.Count;
                    Update_Avatars = false;
                }
                return _Avatars;
            }
        }



        #endregion

        #region  Prefabs
        internal static bool Update_Prefabs { get; set; } = true;

        private static int _Prefabs = 0;
        internal static int Prefabs
        {
            get
            {
                if (Update_Prefabs)
                {
                    _Prefabs = SceneUtils.DynamicPrefabs.Count;
                    Update_Prefabs = false;
                }
                return _Prefabs;
            }
        }



        #endregion



        #region  Pickups
        internal static bool Update_Pickups { get; set; } = true;

        private static int _Pickups = 0;
        internal static int Pickups
        {
            get
            {
                if (Update_Pickups)
                {
                    _Pickups = WorldUtils_Old.Get_Pickups().Count;
                    Update_Pickups = false;
                }
                return _Pickups;
            }
        }



        #endregion

        #region  UdonBehaviours
        internal static bool Update_UdonBehaviours { get; set; } = true;

        private static int _UdonBehaviours = 0;
        internal static int UdonBehaviours
        {
            get
            {
                if (Update_UdonBehaviours)
                {
                    _UdonBehaviours = WorldUtils_Old.Get_UdonBehaviours().Count;
                    Update_UdonBehaviours = false;
                }
                return _UdonBehaviours;
            }
        }



        #endregion

        #region  Triggers
        internal static bool Update_Triggers { get; set; } = true;

        private static int _Triggers = 0;
        internal static int Triggers
        {
            get
            {
                if (Update_Triggers)
                {
                    _Triggers = WorldUtils_Old.Get_Triggers().Count;
                    Update_Triggers = false;
                }
                return _Triggers;
            }
        }



        #endregion

        #region  VRCInteractables
        internal static bool Update_VRCInteractables { get; set; } = true;

        private static int _VRCInteractables = 0;
        internal static int VRCInteractables
        {
            get
            {
                if (Update_VRCInteractables)
                {
                    _VRCInteractables = WorldUtils_Old.Get_VRCInteractables().Count;
                    Update_VRCInteractables = false;
                }
                return _VRCInteractables;
            }
        }



        #endregion

        #region  AudioSources
        internal static bool Update_AudioSources { get; set; } = true;

        private static int _AudioSources = 0;
        internal static int AudioSources
        {
            get
            {
                if (Update_AudioSources)
                {
                    _AudioSources = WorldUtils_Old.Get_AudioSources().Count;
                    Update_AudioSources = false;
                }
                return _AudioSources;
            }
        }



        #endregion

        #region  Mirrors
        internal static bool Update_Mirror { get; set; } = true;

        private static int _Mirror = 0;
        internal static int Mirrors
        {
            get
            {
                if (Update_Mirror)
                {
                    _Mirror = WorldUtils_Old.Get_Mirrors().Count;
                    Update_Mirror = false;
                }
                return _Mirror;
            }
        }



        #endregion

        private static string GenerateText(string title, string Content)
        {
            StringBuilder build = new StringBuilder();
            build.AppendLine($"<b>{title}:</b>");
            build.AppendLine($"<color=yellow>{Content}</color>");
            return build.ToString();
        }

    }
}
