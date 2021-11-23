namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using AstroMonos.Components.UI.SingleTag;
    using CheetoLibrary;
    using VRC;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    internal static class SingleTag_ext
    {
        internal static bool HasTagWithText(this Player player, string searchtext)
        {
            var entry = SingleTagsUtils.GetEntry(player);
            if (entry == null) return false;
            foreach (var tag in entry.AssignedTags)
            {
                ModConsole.DebugLog($"Found Singletag with text : {tag.Text} , With Search {searchtext}");
                if (tag.Text.Equals(searchtext, System.StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        internal static void DestroyTagsWithText(this Player player, string searchtext)
        {
            var entry = SingleTagsUtils.GetEntry(player);
            if (entry == null) return;
            foreach (var tag in entry.AssignedTags)
            {
                ModConsole.DebugLog($"Found Singletag with text : {tag.Text} , With Search {searchtext}");
                if (tag.Text.Equals(searchtext, System.StringComparison.OrdinalIgnoreCase))
                {
                    ModConsole.DebugLog($"Destroying...");

                    UnityEngine.Object.Destroy(tag);
                }
            }
        }

        internal static List<SingleTag> SearchTags(this Player player, string searchtext)
        {
            List<SingleTag> FoundTags = new List<SingleTag>();
            var entry = SingleTagsUtils.GetEntry(player);
            if (entry == null) return null;
            foreach (var tag in entry.AssignedTags)
            {
                ModConsole.DebugLog($"Found Singletag with text : {tag.Text} , With Search {searchtext}");
                if (tag.Text.Equals(searchtext, System.StringComparison.OrdinalIgnoreCase))
                {
                    FoundTags.Add(tag);
                }
            }

            return FoundTags;
        }

        internal static SingleTag FindTag(this Player player, string TagText)
        {
            var entry = SingleTagsUtils.GetEntry(player);
            if (entry == null) return null;
            foreach (var tag in entry.AssignedTags)
            {
                if (tag.Text.isMatch(TagText))
                {
                    return tag;
                }
            }

            return null;
        }



        internal static SingleTag AddSingleTag(this Player player, System.Drawing.Color BackGround,  string Text)
        {
            if (player == null) return null;
            var tag = player.AddComponent<SingleTag>();
            if (tag != null)
            {
                tag.Text = Text;
                tag.BackGroundColor = BackGround.ToUnityEngineColor();
            }
            return tag;
        }

        internal static SingleTag AddSingleTag(this Player player, UnityEngine.Color BackGround, string Text)
        {
            if (player == null) return null;
            var tag = player.AddComponent<SingleTag>();
            if (tag != null)
            {
                tag.Text = Text;
                tag.BackGroundColor = BackGround;
            }
            return tag;
        }

    }
}