namespace AstroButtonAPI
{
    using System.Collections.Generic;
    using MelonLoader;
    using UnityEngine;

    public static class QMButtonAPI
    {
        //REPLACE THIS STRING SO YOUR MENU DOESNT COLLIDE WITH OTHER MENUS
        public static string identifier = BuildInfo.Name;

        public static Color mBackground = Color.red;
        public static Color mForeground = Color.white;
        public static Color bBackground = Color.red;
        public static Color bForeground = Color.yellow;
        public static List<QMSingleButton> allSingleButtons = new List<QMSingleButton>();
        public static List<QMToggleButton> allToggleButtons = new List<QMToggleButton>();
        public static List<QMQuadToggleButton> allQuadToggleButtons = new List<QMQuadToggleButton>();
        public static List<QMNestedButton> allNestedButtons = new List<QMNestedButton>();
        public static List<QMSingleToggleButton> allSingleToggleButtons = new List<QMSingleToggleButton>();
        public static List<QMInfo> AllInfos = new List<QMInfo>();
    }
}