using System.Collections.Generic;
using System.Globalization;
using AstroClient.Cheetos;
using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.Menus.Quickmenu;
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
            AvatarSearch.OnPedestralDumpDone += RefreshInfo;
            MovementMenu.OnNoFallHeightLimitToggled += RefreshInfo;
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
            build.Append(GenerateText("SDK", SceneUtils.SDKType));
            build.Append(GenerateText("RespawnHeightY", SceneUtils.RespawnHeightY.ToString(CultureInfo.InvariantCulture)));
            build.Append(GenerateText("FarClipPlane", PlayerCameraEditor.PlayerCamera.farClipPlane.ToString()));
            build.Append(GenerateText("NearClipPlane", PlayerCameraEditor.PlayerCamera.nearClipPlane.ToString()));
            if (AvatarSearch.worldAvatarsids.Count != 0)
            {
                build.Append(GenerateText("Avatars", AvatarSearch.worldAvatarsids.Count.ToString()));
            }
            var Prefabs = SceneUtils.DynamicPrefabs;
            if (Prefabs != null)
            {
                if (Prefabs.Length != 0)
                {
                    build.Append(GenerateText("Prefabs", Prefabs.Length.ToString()));
                }
            }
            var pickups = WorldUtils_Old.Get_Pickups();
            if (pickups != null)
            {
                if (pickups.Count != 0)
                {
                    build.Append(GenerateText("Pickups", pickups.Count.ToString()));
                }
            }
            var UdonBehaviours = WorldUtils_Old.Get_UdonBehaviours();
            if (UdonBehaviours != null)
            {
                if (UdonBehaviours.Count != 0)
                {
                    build.Append(GenerateText("UdonBehaviours", UdonBehaviours.Count.ToString()));
                }
            }
            var Triggers = WorldUtils_Old.Get_Triggers();
            if (Triggers != null)
            {
                if (Triggers.Count != 0)
                {
                    build.Append(GenerateText("Triggers", Triggers.Count.ToString()));
                }
            }
            var Interactables = WorldUtils_Old.Get_VRCInteractables();
            if (Interactables != null)
            {
                if (Interactables.Count != 0)
                {
                    build.Append(GenerateText("Interactables", Interactables.Count.ToString()));
                }
            }
            var AudioSources = WorldUtils_Old.Get_AudioSources();
            if (AudioSources != null)
            {
                if (AudioSources.Count != 0)
                {
                    build.Append(GenerateText("AudioSources", AudioSources.Count.ToString()));
                }
            }

            var Mirrors = WorldUtils_Old.Get_Mirrors();
            if (Mirrors != null)
            {
                if (Mirrors.Count != 0)
                {
                    build.Append(GenerateText("Mirrors", Mirrors.Count.ToString()));
                }
            }



            return build.ToString();
        }

        private static string GenerateText(string title, string Content)
        {
            StringBuilder build = new StringBuilder();
            build.AppendLine($"<b>{title}:</b>");
            build.AppendLine($"<color=yellow>{Content}</color>");
            return build.ToString();
        }

    }
}
