namespace AstroClient.Cheetos
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using TMPro;
    using UnityEngine;
    using VRC;

    [RegisterComponent]
    public class NamePlates : GameEventsBehaviour
    {
        private PlayerNameplate nameplate;

        private bool isDeveloper;

        private bool isBetaTester;

        private Player player;

        private Player self;

        private bool initialized;

        public float maxUpdateDistance = 10f;

        private GameObject statsTag;
        private TextMeshProUGUI statsText;

        private GameObject questTag;

        private List<GameObject> tags = new List<GameObject>();

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
                statsTag = GameObject.Instantiate(nameplate.GetQuickStats(), nameplate.GetQuickStats().transform.parent);
                statsTag.SetActive(true);
                statsTag.transform.Find("Performance Icon").DestroyMeLocal();
                statsTag.transform.Find("Performance Text").DestroyMeLocal();
                statsTag.transform.Find("Trust Icon").DestroyMeLocal();
                statsText = statsTag.transform.Find("Trust Text").GetComponent<TextMeshProUGUI>();

                questTag = GameObject.Instantiate(nameplate.GetQuest(), nameplate.GetQuest().transform.parent);
                questTag.SetActive(player.GetPlatform().Equals("Quest"));

                InitNamepateStuff();
                SetBackgroundColor(player.GetAPIUser().GetRankColor());

                initialized = true;
            }

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 0)
            {
                ModConsole.Log($"Warning: Namplate creation took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        private void SetBackgroundColor(Color color)
        {
            nameplate.SetBackgroundColor(color);
            statsTag.GetComponent<ImageThreeSlice>().color = color;
        }

        private void Refresh()
        {
            if (nameplate == null) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var stringBuilder = new StringBuilder();
            if (player.IsInstanceMaster())
            {
                _ = stringBuilder.Append($"(Owner) ");
            }
            _ = stringBuilder.Append($"{player.GetPlatformColored()} ");
            if (player.IsFriend())
            {
                _ = stringBuilder.Append($"[F] ");
            }
            _ = stringBuilder.Append($"F:{player.GetFramesColored()}|P:{player.GetPingColored()}");
            statsText.text = stringBuilder.ToString();
            statsText.color = Color.white;

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 3)
            {
                ModConsole.Log($"Warning: Namplate LowRefresh took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        private void InitNamepateStuff()
        {
            if (nameplate == null) return;

            var quickStats = nameplate.GetQuickStats();
            if (quickStats != null)
            {
                quickStats.SetActiveRecursively(false);
            }

            var questTag = nameplate.GetQuest();
            if (questTag != null)
            {
                questTag.SetActiveRecursively(false);
            }
        }

        public void Update()
        {
            if (RefreshTime >= 2f)
            {
                Refresh();
                RefreshTime = 0;
            }
            else
            {
                RefreshTime += 1f * Time.deltaTime;
            }
        }

        internal void AddTag(string text, Color bgColor)
        {
            var newTag = GameObject.Instantiate(nameplate.GetQuickStats(), nameplate.GetQuickStats().transform.parent);
            var tagText = newTag.transform.Find("Trust Text").GetComponent<TextMeshProUGUI>();
            DeleteChildren(newTag);
            if (text.Equals("AstroClient Developer"))
            {
                newTag.GetComponent<ImageThreeSlice>().color = Color.black;
                tagText.color = Color.yellow;
            }
            else
            {
                newTag.GetComponent<ImageThreeSlice>().color = bgColor;
            }
            tagText.text = text;
            newTag.SetActiveRecursively(true);
            SetLocation(newTag, tags.Count);
            tags.Add(newTag);
        }

        internal void SetDeveloper(bool value)
        {
            isDeveloper = value;
            if (value)
            {
                SetBackgroundColor(Color.black);
            }
        }

        internal void SetBetaTester(bool value)
        {
            isBetaTester = value;
        }

        private void SetLocation(GameObject tag, int count)
        {
            tag.transform.localPosition = new Vector3(0f, (30 * (count + 2)), 0f);
        }

        private void DeleteChildren(GameObject tag)
        {
            for (int i = tag.transform.childCount; i > 0; i--)
            {
                Transform child = tag.transform.GetChild(i - 1);
                if (!child.name.Equals("Trust Text"))
                {
                    UnityEngine.Object.Destroy(child.gameObject);
                }
            }
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

        public static TextMeshProUGUI GetSubText(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_TextMeshProUGUI_1;
        }

        public static TextMeshProUGUI GetPerformanceText(this PlayerNameplate nameplate)
        {
            return nameplate.field_Public_TextMeshProUGUI_4;
        }
    }
}
