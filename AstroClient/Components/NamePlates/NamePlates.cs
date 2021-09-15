namespace AstroClient.Cheetos
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using System;
    using System.Collections;
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

        private TMP_Text statsText;

        private GameObject contents;
        private GameObject main;
        private GameObject background;
        private GameObject glow;
        private GameObject textContainer;
        private GameObject subText;

        private GameObject quickStats;
        private GameObject trustIcon;
        private GameObject trustText;
        private GameObject performanceIcon;
        private GameObject performanceText;

        private GameObject quest;

        private List<GameObject> tags = new List<GameObject>();

        private TextMeshProUGUI trustTextComp;

        public NamePlates(IntPtr obj0) : base(obj0)
        {
        }

        public void Start()
        {
            if (!ConfigManager.UI.NamePlates) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            self = PlayerUtils.GetPlayer();
            player = GetComponent<Player>();
            if (!initialized && player != null && player.GetVRCPlayer() != null)
            {
                nameplate = player.GetVRCPlayer().field_Public_PlayerNameplate_0;

                contents = nameplate.transform.Find("Content").gameObject;
                main = contents.transform.Find("Main").gameObject;
                background = contents.transform.Find("Glow").gameObject;
                textContainer = main.transform.Find("Text Container").gameObject;
                subText = textContainer.transform.Find("Sub Text").gameObject;

                quickStats = contents.transform.Find("Quick Stats").gameObject;
                trustIcon = quickStats.transform.Find("Trust Icon").gameObject;
                trustText = quickStats.transform.Find("Trust Text").gameObject;
                performanceIcon = quickStats.transform.Find("Performance Icon").gameObject;
                performanceText = quickStats.transform.Find("Performance Text").gameObject;

                quest = contents.transform.Find("Quest").gameObject;

                //InitNamepateStuff();
                SetBackgroundColor(player.GetAPIUser().GetRankColor());

                initialized = true;
            }

            _ = MelonCoroutines.Start(UpdateLoop());

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 0)
            {
                ModConsole.Log($"Warning: Namplate creation took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        private IEnumerator UpdateLoop()
        {
            for (; ; )
            {
                Refresh();
                yield return new WaitForSeconds(1f);
            }
        }

        private void SetBackgroundColor(Color color)
        {
            //nameplate.SetBackgroundColor(color);
            //quickStats.GetComponent<ImageThreeSlice>().color = color;
        }

        private void Refresh()
        {
            if (nameplate == null || !ConfigManager.UI.NamePlates) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            trustIcon.SetActiveRecursively(false);
            performanceIcon.SetActiveRecursively(false);
            performanceText.SetActiveRecursively(false);

            if (player.GetPlatform().Equals("Quest"))
            {
                quest.SetActiveRecursively(true);
            }
            //nameplate.GetSubText().SetActiveRecursively(true);
            //nameplate.GetQuest().SetActiveRecursively(true);

            //var stringBuilder = new StringBuilder();
            //if (player.IsInstanceMaster())
            //{
            //    _ = stringBuilder.Append($"(Owner) ");
            //}
            //_ = stringBuilder.Append($"{player.GetPlatformColored()} ");
            //if (player.IsFriend())
            //{
            //    _ = stringBuilder.Append($"[F] ");
            //}
            //_ = stringBuilder.Append($"F:{player.GetFramesColored()}|P:{player.GetPingColored()}");
            //statsText.text = stringBuilder.ToString();
            //statsText.color = Color.white;

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 0)
            {
                ModConsole.Log($"Warning: Namplate LowRefresh took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        private void InitNamepateStuff()
        {
            if (nameplate == null) return;

            //var quickStats = nameplate.GetQuickStats();
            //if (quickStats != null)
            //{
            //    quickStats.SetActiveRecursively(false);
            //}

            //var questTag = nameplate.GetQuest();
            //if (questTag != null)
            //{
            //    questTag.SetActiveRecursively(false);
            //}
        }

        internal void AddTag(string text, Color bgColor)
        {
            //var newTag = GameObject.Instantiate(nameplate.GetQuickStats(), nameplate.GetQuickStats().transform.parent);
            //var tagText = newTag.transform.Find("Trust Text").GetComponent<TextMeshProUGUI>();
            //DeleteChildren(newTag);
            //if (text.Equals("AstroClient Developer"))
            //{
            //    newTag.GetComponent<ImageThreeSlice>().color = Color.black;
            //    tagText.color = Color.yellow;
            //}
            //else
            //{
            //    newTag.GetComponent<ImageThreeSlice>().color = bgColor;
            //}
            //tagText.text = text;
            //newTag.SetActiveRecursively(true);
            //SetLocation(newTag, tags.Count);
            //tags.Add(newTag);
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
}