using System.Collections.Generic;
using System.Globalization;
using AstroClient.Cheetos;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Menu.Menus.Quickmenu;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.World;
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
            build.Append(GenerateText("Avatars", AvatarSearch.worldAvatarsids.Count.ToString()));
            build.Append(GenerateText("SDK", WorldUtils.SDKType));
            build.Append(GenerateText("RespawnHeightY", SceneUtils.RespawnHeightY.ToString(CultureInfo.InvariantCulture)));
            if (WorldUtils.DynamicPrefabs != null)
            {
                build.Append(GenerateText("Prefabs", WorldUtils.DynamicPrefabs.Length.ToString()));
            }
            build.Append(GenerateText("Pickups", WorldUtils_Old.Get_Pickups().Count.ToString()));
            build.Append(GenerateText("UdonBehaviours", WorldUtils_Old.Get_UdonBehaviours().Count.ToString()));
            build.Append(GenerateText("Triggers", WorldUtils_Old.Get_Triggers().Count.ToString()));
            build.Append(GenerateText("Interactables", WorldUtils_Old.Get_VRCInteractables().Count.ToString()));
            build.Append(GenerateText("AudioSources", WorldUtils_Old.Get_AudioSources().Count.ToString()));
           // build.Append(GenerateText("Mirrors", WorldUtils_Old.Get_AudioSources().Count.ToString()));


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
