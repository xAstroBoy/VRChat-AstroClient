using Cinemachine;

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
        ///  this kills The blue effect of vrchat GUI by Destroying StyleElement if present
        /// </summary>
        /// <param name="image"></param>
        public static void MakeBackgroundMoreSolid(this Image image)
        {
            var StyleElement = image.GetComponent<VRC.UI.Core.Styles.StyleElement>();
            if (StyleElement != null)
            {
                UnityEngine.Object.DestroyImmediate(StyleElement);
            }

            // White
            image.color = new Color(1, 1, 1, 1);
        }


    }
}
