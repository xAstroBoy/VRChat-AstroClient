namespace AstroClient.Cheetos
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Diagnostics;
    using System.Text;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC;

    public class NamePlates : GameEventsBehaviour
    {
        private PlayerNameplate nameplate;

        private Player player;

        private Player self;

        private bool initialized;

        public float maxUpdateDistance = 10f;

        public NamePlates(IntPtr obj0) : base(obj0)
        {
        }

        private static float RefreshTime;

        public void Start()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            self = PlayerUtils.GetPlayer();
            player = GetComponent<Player>();
            if (!initialized && player != null && player.GetVRCPlayer() != null)
            {
                nameplate = player.GetVRCPlayer().field_Public_PlayerNameplate_0;
                HighRefresh();
                LowRefresh();

                initialized = true;
            }

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 0)
            {
                ModConsole.Log($"Warning: Namplate creation took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        private void LowRefresh()
        {
            if (nameplate == null) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var stringBuilder = new StringBuilder();
            if (player.IsInstanceMaster())
            {
                stringBuilder.Append($"(Owner) ");
            }
            stringBuilder.Append($"{player.GetPlatformColored()} ");
            if (player.IsFriend())
            {
                stringBuilder.Append($"[F] ");
            }
            stringBuilder.Append($"F:{player.GetFramesColored()}|P:{player.GetPingColored()}");
            nameplate.SetBackgroundColor(player.GetAPIUser().GetRankColor());
            nameplate.GetTrustText().text = stringBuilder.ToString();
            nameplate.GetTrustText().color = Color.white;

            if (player.GetPlatform().Equals("Quest"))
            {
                nameplate.GetQuest().gameObject.SetActive(true);
            }

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 3)
            {
                ModConsole.Log($"Warning: Namplate LowRefresh took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        private GameObject quickStats;
        private GameObject subTextObject;
        private GameObject performanceTextObject;
        private GameObject performanceIconObject;
        private GameObject trustIconObject;
        private void HighRefresh()
        {
            if (nameplate == null) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            if (quickStats != null)
            {
                if (!quickStats.active) quickStats.SetActive(true);
            }
            else
            {
                quickStats = nameplate.GetQuickStats();
            }

            if (subTextObject != null)
            {
                if (!subTextObject.active) subTextObject.SetActive(true);
            }
            else
            {
                subTextObject = nameplate.GetSubTextObject();
            }

            if (performanceTextObject != null)
            {
                if (!performanceTextObject.active) performanceTextObject.SetActive(false);
            }
            else
            {
                performanceTextObject = nameplate.GetPerformanceText().gameObject;
            }

            if (performanceIconObject != null)
            {
                if (!performanceIconObject.active) performanceIconObject.SetActive(false);
            }
            else
            {
                performanceIconObject = nameplate.GetPerformanceIcon().gameObject;
            }

            if (trustIconObject != null)
            {
                if (!trustIconObject.active) trustIconObject.SetActive(false);
            }
            else
            {
                trustIconObject = nameplate.GetTrustIcon().gameObject;
            }

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 3)
            {
                ModConsole.Log($"Warning: Namplate HighRefresh took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        public void Update()
        {
            if (RefreshTime >= 1f)
            {
                if (CalculateDistance() > maxUpdateDistance) return;

                HighRefresh();
                LowRefresh();
                RefreshTime = 0;
            }
            else
            {
                RefreshTime += 1f * Time.deltaTime;
            }
        }

        internal void AddTag(Player player, string text, Color yellow)
        {
            ModConsole.Log($"Server wanted to add a tag for '{player.DisplayName()}' which was '{text}' however this isn't implemented yet");
        }

        public float CalculateDistance()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var pos1 = self.gameObject.transform.position;
            var pos2 = player.gameObject.transform.position;

            var distance = Vector3.Distance(pos1, pos2);

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 25)
            {
                ModConsole.Log($"Warning: Namplate CalculateDistance took {stopwatch.ElapsedMilliseconds}ms!");
            }
            return distance;
        }
    }

    public static class NamePlateExtensions
    {
        public static GameObject GetContents(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_GameObject_0;
        }

        public static GameObject GetSubTextObject(this PlayerNameplate nameplate)
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

        public static TextMeshProUGUI GetSubText(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_TextMeshProUGUI_1;
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
