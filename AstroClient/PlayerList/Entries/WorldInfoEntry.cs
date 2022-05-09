using System.Collections.Generic;
using System.Globalization;
using AstroClient.Cheetos;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Menu.Menus.Quickmenu;
using AstroClient.Tools.Extensions;
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
            build.Append(GenerateText("SDK", WorldUtils.SDKType));
            if (GameInstances.CurrentUser != null)
            {
                build.Append(GenerateText("User RespawnHeightY", GameInstances.CurrentUser.Get_RespawnHeightY().ToString(CultureInfo.InvariantCulture)));
            }
            build.Append(GenerateText("Scene RespawnHeightY", SceneUtils.RespawnHeightY.ToString(CultureInfo.InvariantCulture)));
            build.Append(GenerateText("Prefabs", WorldUtils.Prefabs.Count.ToString()));
            build.Append(GenerateText("Pickups", WorldUtils.Pickups.Count.ToString()));
            build.Append(GenerateText("UdonBehaviours", WorldUtils.UdonScripts.Length.ToString()));
            build.Append(GenerateText("Triggers", WorldUtils.SDK1Triggers.Count.ToString()));
            build.Append(GenerateText("Interactables", WorldUtils.Interactables.Length.ToString()));
            build.Append(GenerateText("Avatars", AvatarSearch.worldAvatarsids.Count.ToString()));

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
