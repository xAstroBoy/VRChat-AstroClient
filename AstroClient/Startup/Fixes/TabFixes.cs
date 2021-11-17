namespace AstroClient.Startup.Fixes
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    internal class TabFixes : AstroEvents
    {
        internal static bool HasFixed { get; private set; }
        internal static bool HasFixed2 { get; private set; }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            isInWorld = true;
        }

        internal override void OnRoomLeft()
        {
            isInWorld = false;
        }

        private static bool isInWorld;

        internal override void OnQuickMenuOpen()
        {
            if (!isInWorld) return;
            if (!HasFixed)
            {
                try
                {
                    Transform layoutGroup = QuickMenuTools.TabMenu.Find("HorizontalLayoutGroup");
                    if (layoutGroup != null)
                    {
                        var destroy1 = layoutGroup.GetComponent<UnityEngine.UI.HorizontalLayoutGroup>(); // Destroying inferior HorizontalLayoutGroup
                        var destroy2 = layoutGroup.GetComponent<UnityEngine.UI.ContentSizeFitter>(); // Destroying inferior HorizontalLayoutGroup

                        if (destroy2 != null && destroy1 != null)
                        {
                            UnityEngine.Object.DestroyImmediate(destroy1);
                            UnityEngine.Object.DestroyImmediate(destroy2);
                         ModConsole.DebugLog("1");
                            GridLayoutGroup gridLayoutGroup = layoutGroup.GetOrAddComponent<GridLayoutGroup>(); //Adding superior GridLayoutGroup
                            int maxwidth = 960; // Sets Max Width of Tab buttons
                            int minwidth = 120; //Sets Icon Size
                            int activeChildren = 0;
                            int rows = 1;
                            for (int i = 0; i < layoutGroup.childCount; i++)
                            {
                                if (layoutGroup.GetChild(i).gameObject)
                                    activeChildren++;
                            }

                            ModConsole.DebugLog("2");

                            while (maxwidth / Math.Ceiling((float)activeChildren / (float)rows) < minwidth)
                            {
                                rows++;
                            }
                            ModConsole.DebugLog("3");

                            gridLayoutGroup.cellSize = new Vector2((float)(maxwidth / Math.Ceiling((float)activeChildren / (float)rows)), 100f);
                            ModConsole.DebugLog("4");
                            gridLayoutGroup.childAlignment = TextAnchor.UpperCenter;
                            layoutGroup.GetComponent<RectTransform>().sizeDelta = new Vector2(maxwidth, 100);
                            ModConsole.DebugLog("5");
                            Transform tooltip = QuickMenuTools.ToolTipPanel.Find("Panel");
                            ModConsole.DebugLog("6");
                            if (tooltip != null)
                            {
                                ModConsole.DebugLog("7");
                                tooltip.localPosition = new Vector3(tooltip.localPosition.x, 220, tooltip.localPosition.z); //Changes the Tooltip Position so it dosent cover the buttons
                            }
                        }
                        else
                        {
                            HasFixed = true;
                            ModConsole.DebugLog("Menu seems fixed already!");
                        }
                    }
                }
                catch (Exception e)
                {
                    HasFixed = false;
                    ModConsole.ErrorExc(e);
                }
            }

            if (!HasFixed2)
            {
                var boxCollider = QuickMenuTools.TabMenu.gameObject.GetComponentsInChildren<UnityEngine.BoxCollider>(true);
                foreach (var box in boxCollider)
                {
                    if (box != null)
                    {
                        ModConsole.DebugLog("8");
                        box.center = new Vector3(0, -150, 0); //Centers the Collider to the 2nd Row
                        ModConsole.DebugLog("9");
                        box.size = new Vector3(1200, 300, 1); //Increases the Size of the Collider to cover all Buttons
                        ModConsole.DebugLog("10");

                        ModConsole.DebugLog("Fixed Tabs! Enjoy!");
                        HasFixed2 = true;
                        break;
                    }
                }
            }

        }
    }
}