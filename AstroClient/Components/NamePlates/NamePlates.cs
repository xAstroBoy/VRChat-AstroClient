namespace AstroClient.Cheetos
{
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC;

    public class NamePlates : GameEventsBehaviour
    {
        private PlayerNameplate nameplate;

        private Player player;

        public NamePlates(IntPtr obj0) : base(obj0)
        {
        }

        private static float RefreshTime;

        private void Refresh()
        {
            var text = $"";
            if (player.IsInstanceMaster())
            {
                text += $"(Owner) ";
            }
            if (player.IsInVR())
            {
                text += $"[VR] ";
            }
            if (player.IsFriend())
            {
                text += $"[F] ";
            }
            text += $"F:{player.GetFramesColored()}|P:{player.GetPingColored()}";
            nameplate.SetBackgroundColor(player.GetAPIUser().GetRankColor());
            nameplate.GetTrustText().text = text;
            nameplate.GetTrustText().color = Color.white;
            nameplate.GetQuickStats().SetActive(true);
            nameplate.GetSubText().SetActive(true);
            nameplate.GetFriendIcon().gameObject.SetActive(player.IsFriend());
            nameplate.GetPerformanceText().gameObject.SetActive(false);
            nameplate.GetPerformanceIcon().gameObject.SetActive(false);
            nameplate.GetTrustIcon().gameObject.SetActive(false);
        }

        public void Update()
        {
            if (RefreshTime >= 1f)
            {
                Refresh();
                RefreshTime = 0;
            }
            else
            {
                RefreshTime += 1f * Time.deltaTime;
            }
        }

        public void Start()
        {
            player = GetComponent<Player>();
            if (player != null)
            {
                nameplate = player.GetVRCPlayer().field_Public_PlayerNameplate_0;
            }
        }
    }

    public static class NamePlateExtensions
    {
        public static GameObject GetContents(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_GameObject_0;
        }

        public static GameObject GetSubText(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_GameObject_1;
        }

        public static GameObject GetQuickStats(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_GameObject_5;
        }

        public static GameObject GetQuest(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_GameObject_6;
        }

        public static GameObject GetFriendIcon(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_GameObject_15;
        }

        public static void SetBackgroundColor(this PlayerNameplate nameplate, Color color)
        {
            nameplate.field_Public_Graphic_1.color = color;
            nameplate.field_Public_Graphic_2.color = color;
            nameplate.field_Public_Graphic_3.color = Color.black;
        }

        public static Image GetTrustIcon(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_Image_0;
        }

        public static Image GetPerformanceIcon(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_Image_1;
        }

        public static TextMeshProUGUI GetPerformanceText(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_TextMeshProUGUI_4;
        }

        public static TextMeshProUGUI GetTrustText(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_TextMeshProUGUI_3;
        }
    }
}
