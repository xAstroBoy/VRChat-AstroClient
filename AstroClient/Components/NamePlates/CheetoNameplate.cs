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
    using UnityEngine.UI;
    using VRC;

    [RegisterComponent]
    public class CheetoNameplate : GameEventsBehaviour
    {
        private PlayerNameplate nameplate;

        private bool isDeveloper;
        private bool isBetaTester;

        private Player player;
        private Player self;

        private GameObject contents;
        private GameObject main;
        private GameObject background;
        private GameObject glow;
        private Image glow_Image;
        private GameObject textContainer;
        private GameObject subText;

        private GameObject quickStats;
        private GameObject trustIcon;
        private GameObject trustText;
        private TextMeshProUGUI trustText_Text;
        private GameObject performanceIcon;
        private GameObject performanceText;

        private GameObject quest;

        private List<GameObject> tags = new List<GameObject>();

        private TextMeshProUGUI trustTextComp;

        public CheetoNameplate(IntPtr obj0) : base(obj0)
        {
        }

        public void Start()
        {
            if (!ConfigManager.UI.NamePlates) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            self = PlayerUtils.GetPlayer();
            player = GetComponent<Player>();
            if (player != null && player.GetVRCPlayer() != null)
            {
                nameplate = player.GetVRCPlayer().field_Public_PlayerNameplate_0;
                if (nameplate == null) { ModConsole.Error("[Nameplate] Nameplate was null!"); return; };

                if (nameplate != null)
                {
                    contents = nameplate.transform.Find("Contents").gameObject;

                    if (contents != null)
                    {
                        main = contents.transform.Find("Main").gameObject;
                        quickStats = contents.transform.Find("Quick Stats").gameObject;
                        quest = contents.transform.Find("Quest").gameObject;

                        if (main != null)
                        {
                            background = main.transform.Find("Background").gameObject;
                            glow = main.transform.Find("Glow").gameObject;
                            glow_Image = glow.GetComponent<Image>();
                            textContainer = main.transform.Find("Text Container").gameObject;

                            if (textContainer != null)
                            {
                                subText = textContainer.transform.Find("Sub Text").gameObject;
                            }
                            else
                            {
                                ModConsole.Error("[Nameplate] TextContainer was null");
                            }
                        }
                        else
                        {
                            ModConsole.Error("[Nameplate] Main was null");
                        }

                        if (quickStats != null)
                        {
                            trustIcon = quickStats.transform.Find("Trust Icon").gameObject;
                            trustText = quickStats.transform.Find("Trust Text").gameObject;
                            trustText_Text = trustText.GetComponent<TextMeshProUGUI>();
                            performanceIcon = quickStats.transform.Find("Performance Icon").gameObject;
                            performanceText = quickStats.transform.Find("Performance Text").gameObject;
                        }
                        else
                        {
                            ModConsole.Error("[Nameplate] QuickStats was null");
                        }
                    }
                    else
                    {
                        ModConsole.Error("[Nameplate] Contents was null");
                    }
                }
                else
                {
                    ModConsole.Error("[Nameplate] Nameplate was null");
                }
                //    //InitNamepateStuff();
                //    SetBackgroundColor(player.GetAPIUser().GetRankColor());

                _ = MelonCoroutines.Start(FastUpdateLoop());
                _ = MelonCoroutines.Start(UpdateLoop());
            }
            else
            {
                ModConsole.Error("Player was null!");
            }

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 0)
            {
                ModConsole.Log($"[Nameplate] creation took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        private IEnumerator UpdateLoop()
        {
            for (; ; )
            {
                if (nameplate==null) { yield return null; }
                Refresh();
                yield return new WaitForSeconds(2f);
            }
        }

        private IEnumerator FastUpdateLoop()
        {
            for (; ; )
            {
                if (nameplate == null) { yield return null; }
                FastRefresh();
                yield return new WaitForSeconds(0.1f);
            }
        }

        private void SetBackgroundColor(Color color)
        {
            //nameplate.SetBackgroundColor(color);
            //quickStats.GetComponent<ImageThreeSlice>().color = color;
        }


        private void FastRefresh()
        {
            if (nameplate == null || !ConfigManager.UI.NamePlates) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            quickStats.SetActive(true);
            trustIcon.SetActiveRecursively(false);
            performanceIcon.SetActiveRecursively(false);
            performanceText.SetActiveRecursively(false);

            subText.SetActiveRecursively(true);
            trustText.SetActiveRecursively(true);

            if (player.GetPlatform().Equals("Quest"))
            {
                quest.SetActiveRecursively(true);
            }

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 1)
            {
                ModConsole.Log($"Namplate FastRefresh took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        private void Refresh()
        {
            if (nameplate == null || !ConfigManager.UI.NamePlates) return;
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

            trustText_Text.text = stringBuilder.ToString();
            trustText_Text.color = Color.white;

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 1)
            {
                ModConsole.Log($"Namplate Refresh took {stopwatch.ElapsedMilliseconds}ms!");
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