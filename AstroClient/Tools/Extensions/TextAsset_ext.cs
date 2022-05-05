namespace AstroClient.Tools.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using CustomClasses;
    using UdonEditor;
    using UdonSearcher;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.Extensions;
    using static Constants.CustomLists;

    internal static class TextAsset_ext
    {
        
        internal static void SetText(this TextAsset asset, string newstr, bool Confirm = true)
        {
            TextAsset.Internal_CreateInstance(asset, newstr);
            if (asset.text.Equals(newstr))
            {
                if (Confirm)
                {
                    Log.Debug("Patched TextAsset!");
                }
            }
            else
            {
                if (Confirm)
                {
                    Log.Debug("Failed to Patch TextAsset");
                }

            }

        }
        internal static string GetText(this TextAsset asset)
        {
            return asset.text;
        }


    }
}