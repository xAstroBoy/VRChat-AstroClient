using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using Cinemachine;
using VRC.UI.Core.Styles;

namespace AstroClient.xAstroBoy.Utility
{
    using UnityEngine;
    using UnityEngine.UI;

    internal static class UnityUtils
    {

        internal static Transform FindInactiveObjectInActiveRoot(string path)
        {
            var split = path.Split(new char[] { '/' }, 2);
            var rootObject = GameObject.Find($"/{split[0]}")?.transform;
            if (rootObject == null) return null;
            return Transform.FindRelativeTransformWithPath(rootObject, split[1], false);
        }

        /// <summary>
        ///  this kills The blue effect of vrchat GUI by Deactivating StyleElement if present
        /// </summary>
        /// <param name="image"></param>
        public static void MakeBackgroundMoreSolid(this Image image)
        {
            var white = new Color(1, 1, 1, 1); ;
            //var parentcomps = image.transform.GetComponents<StyleElement>();
            //if (parentcomps != null)
            //{
            //    foreach (var comp in parentcomps)
            //    {
            //        comp.DisableStyleElement();
            //    }
            //}
            //var Childs = image.transform.GetComponentsInChildren<StyleElement>(true);
            //if (Childs != null)
            //{
            //    foreach (var comp in Childs)
            //    {
            //        comp.DisableStyleElement();
            //    }
            //}
            image.color = white;
            MiscUtils.DelayFunction(1f, () =>
            {
                image.color = white;
            });
        }

        /// <summary>
        ///  this kills The blue effect of vrchat GUI by Deactivating StyleElement if present
        /// </summary>
        /// <param name="image"></param>
        public static void MakeBackgroundMoreSolid(this UIWidgets.ImageAdvanced image)
        {
            var white = new Color(1, 1, 1, 1); ;
            //var parentcomps = image.transform.GetComponents<StyleElement>();
            //if (parentcomps != null)
            //{
            //    foreach (var comp in parentcomps)
            //    {
            //        comp.DisableStyleElement();
            //    }
            //}
            //var Childs = image.transform.GetComponentsInChildren<StyleElement>(true);
            //if (Childs != null)
            //{
            //    foreach (var comp in Childs)
            //    {
            //        comp.DisableStyleElement();
            //    }
            //}
            image.color = white;
            MiscUtils.DelayFunction(1f, () =>
            {
                image.color = white;
            });
        }

    }
}
