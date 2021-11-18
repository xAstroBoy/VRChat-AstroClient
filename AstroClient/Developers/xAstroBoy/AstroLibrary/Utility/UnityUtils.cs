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

        public static void MakeBackgroundMoreSolid(this Image image)
        {
            var color = image.color;
            color.a = 1;
            image.color = color;
        }


    }
}
