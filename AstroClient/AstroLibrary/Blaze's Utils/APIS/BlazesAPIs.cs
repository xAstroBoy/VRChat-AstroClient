namespace Blaze.API
{
    using System.Collections.Generic;
    using AstroButtonAPI;
    using UnityEngine;
    using VRC;

    internal static class BlazesAPIs
    {
        internal static string Identifier = "AstroClient";

        //Tags Settings
        internal static Dictionary<Player, int> PlayersTopTagsCount = new Dictionary<Player, int>();
        internal static Dictionary<Player, int> PlayersBottomTagsCount = new Dictionary<Player, int>();
        internal static bool GlowingTags = true;

        //QuickMenu Settings
        internal static Color mBackground = Color.red;
        internal static Color mForeground = Color.white;
        internal static Color bBackground = Color.red;
        internal static Color bForeground = Color.yellow;
        internal static List<QMSingleButton> allSingleButtons = new List<QMSingleButton>();
        internal static List<QMToggleButton> allToggleButtons = new List<QMToggleButton>();
        internal static List<QMNestedButton> allNestedButtons = new List<QMNestedButton>();
        //internal static List<QMImage> allImages = new List<QMImage>();
        internal static List<QMSlider> allSliders = new List<QMSlider>();

        //SocialMenu Settings
        //internal static List<SMButton> allSMButtons = new List<SMButton>();
        //internal static List<SMText> allSMTexts = new List<SMText>();
    }
}
