namespace AstroClient.Cheetos
{
    #region Imports

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

    #endregion

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
        private ImageThreeSlice background_Image;
        private GameObject glow;
        private Image glow_Image;
        private GameObject textContainer;
        private GameObject subText;

        private GameObject quickStats;
        private ImageThreeSlice quickStats_Image;
        private GameObject trustIcon;
        private GameObject trustText;
        private TextMeshProUGUI trustText_Text;
        private GameObject performanceIcon;
        private GameObject performanceText;

        private GameObject quest;
        private GameObject friendMarker;

        private List<GameObject> tags = new List<GameObject>();

        private TextMeshProUGUI trustTextComp;

        public CheetoNameplate(IntPtr obj0) : base(obj0)
        {
        }

        internal void Start()
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

                contents = nameplate.transform.Find("Contents").gameObject;

                if (contents != null)
                {
                    main = contents.transform.Find("Main").gameObject;
                    quickStats = contents.transform.Find("Quick Stats").gameObject;
                    quickStats_Image = quickStats.GetComponent<ImageThreeSlice>();
                    quest = contents.transform.Find("Quest").gameObject;
                    friendMarker = contents.transform.Find("Friend Marker").gameObject;

                    if (main != null)
                    {
                        background = main.transform.Find("Background").gameObject;
                        background_Image = background.GetComponent<ImageThreeSlice>();
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
                        trustIcon.SetActiveRecursively(false);
                        trustText = quickStats.transform.Find("Trust Text").gameObject;
                        trustText_Text = trustText.GetComponent<TextMeshProUGUI>();
                        performanceIcon = quickStats.transform.Find("Performance Icon").gameObject;
                        performanceIcon.SetActiveRecursively(false);
                        performanceText = quickStats.transform.Find("Performance Text").gameObject;
                        performanceText.SetActiveRecursively(false);
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

                _ = MelonCoroutines.Start(FastUpdateLoop());
                _ = MelonCoroutines.Start(UpdateLoop());
            }
            else
            {
                ModConsole.Error("[Nameplate] Player was null!");
            }

            //AddTag(player.GetAPIUser().GetRank(), player.GetAPIUser().GetRankColor());

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 1)
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
                yield return new WaitForSeconds(0.25f);
            }
        }

        private void SetBackgroundColor(Color color)
        {
            if (isDeveloper)
            {
                background_Image.color = Color.black;
                quickStats_Image.color = Color.black;
            }
            else
            {
                background_Image.color = color;
                quickStats_Image.color = color;
            }
        }


        private void FastRefresh()
        {
            if (nameplate == null || !ConfigManager.UI.NamePlates) return;

            quickStats.SetActive(true);
            trustIcon.SetActiveRecursively(false);
            performanceIcon.SetActiveRecursively(false);
            performanceText.SetActiveRecursively(false);
            textContainer.SetActiveRecursively(true);
            subText.SetActiveRecursively(true);
            trustText.SetActiveRecursively(true);

            if (player.IsFriend()) { friendMarker.SetActiveRecursively(true); }
            if (player.GetPlatform().Equals("Quest") && !quest.active) quest.SetActiveRecursively(true);
        }

        private void Refresh()
        {
            if (nameplate == null || !ConfigManager.UI.NamePlates) return;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            SetBackgroundColor(player.GetAPIUser().GetRankColor());

            var stringBuilder = new StringBuilder();
            if (player.IsInstanceMaster())
            {
                _ = stringBuilder.Append($"(Owner) ");
            }
            if (player.IsFriend())
            {
                _ = stringBuilder.Append($"<color=green>[F]</color> ");
            }
            _ = stringBuilder.Append($"{player.GetPlatformColored()} ");
            _ = stringBuilder.Append($"F:{player.GetFramesColored()}|P:{player.GetPingColored()}");

            trustText_Text.text = stringBuilder.ToString();
            trustText_Text.color = Color.white;

            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 1)
            {
                ModConsole.Log($"Namplate Refresh took {stopwatch.ElapsedMilliseconds}ms!");
            }
        }

        internal void AddTag(string text, Color bgColor)
        {
            var newTag = GameObject.Instantiate(quickStats, contents.transform);
            newTag.name = $"AstroTag-{text}";
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
}