﻿namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using AstroMonos.Components.UI.SingleTag;
    using VRC;
    using xAstroBoy.Utility;

    internal static class SingleTag_ext
    {
        internal static bool HasTagWithText(this Player player, string searchtext)
        {
            var tags = player.transform.root.GetComponentsInChildren<SingleTag>(true);

            foreach (var tag in tags)
            {
                ModConsole.DebugLog($"Found Singletag with text : {tag.Label_Text} , With Search {searchtext}");
                if (tag.Label_Text.Equals(searchtext, System.StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        internal static void DestroyTagsWithText(this Player player, string searchtext)
        {
            var tags = player.transform.root.GetComponentsInChildren<SingleTag>(true);
            foreach (var tag in tags)
            {
                ModConsole.DebugLog($"Found Singletag with text : {tag.Label_Text} , With Search {searchtext}");
                if (tag.Label_Text.Equals(searchtext, System.StringComparison.OrdinalIgnoreCase))
                {
                    ModConsole.DebugLog($"Destroying...");

                    UnityEngine.Object.Destroy(tag);
                }
            }
        }

        internal static List<SingleTag> SearchTags(this Player player, string searchtext)
        {
            List<SingleTag> FoundTags = new List<SingleTag>();
            var tags = player.transform.root.GetComponentsInChildren<SingleTag>(true);
            foreach (var tag in tags)
            {
                ModConsole.DebugLog($"Found Singletag with text : {tag.Label_Text} , With Search {searchtext}");
                if (tag.Label_Text.Equals(searchtext, System.StringComparison.OrdinalIgnoreCase))
                {
                    FoundTags.Add(tag);
                }
            }

            return FoundTags;
        }

        internal static SingleTag AddSingleTag(this Player player)
        {
            return SingleTagsUtils.AddSingleTag(player);
        }


        internal static SingleTag AddSingleTag(this Player player, UnityEngine.Color Tag_Color)
        {


            return AddSingleTag(player, Tag_Color, UnityEngine.Color.white, "TAG NOT SET");
        }

        internal static SingleTag AddSingleTag(this Player player, UnityEngine.Color Tag_Color, UnityEngine.Color Label_TextColor)
        {
            return AddSingleTag(player, Tag_Color, Label_TextColor, "TAG NOT SET");
        }


        internal static SingleTag AddSingleTag(this Player player, System.Drawing.Color Tag_Color, System.Drawing.Color Label_TextColor)
        {
            return AddSingleTag(player, Tag_Color.ToUnityEngineColor(), Label_TextColor.ToUnityEngineColor(), "TAG NOT SET");
        }

        internal static SingleTag AddSingleTag(this Player player, System.Drawing.Color Tag_Color, System.Drawing.Color Label_TextColor, string Label_Text)
        {
            return AddSingleTag(player, Tag_Color.ToUnityEngineColor(), Label_TextColor.ToUnityEngineColor(), Label_Text);

        }
        internal static SingleTag AddSingleTag(this Player player, UnityEngine.Color Tag_Color, System.Drawing.Color Label_TextColor, string Label_Text)
        {
            return AddSingleTag(player, Tag_Color, Label_TextColor.ToUnityEngineColor(), Label_Text);

        }

        internal static SingleTag AddSingleTag(this Player player, System.Drawing.Color Tag_Color, UnityEngine.Color Label_TextColor, string Label_Text)
        {
            return AddSingleTag(player, Tag_Color.ToUnityEngineColor(), Label_TextColor, Label_Text);

        }

        internal static SingleTag AddSingleTag(this Player player, UnityEngine.Color Tag_Color, UnityEngine.Color Label_TextColor, string Label_Text)
        {

            var tag = player.AddSingleTag();
            if(tag != null)
            {
                MiscUtils.DelayFunction(0.5f, () => 
                {
                    tag.Tag_Color = Tag_Color;
                    tag.Label_TextColor = Label_TextColor;
                    tag.Label_Text = Label_Text;
                
                });
                return tag;
            }
            return null;

        }

    }
}