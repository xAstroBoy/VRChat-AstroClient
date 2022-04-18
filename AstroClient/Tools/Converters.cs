namespace AstroClient.Tools
{
    using UnityEngine;

    internal class Converters
    {
        public static Vector3 ConvertToUnityUnits(Vector3 emmPosition)
        {
            emmPosition.y *= -1f;
            return new Vector3(-1050f, 1470f) + emmPosition * 420f;
        }

        public static Vector3 ConvertToEmmUnits(Vector3 unityPosition)
        {
            Vector3 emmUnits = (unityPosition - new Vector3(-1050f, 1470f)) / 420f;
            emmUnits.y *= -1f;
            return emmUnits;
        }


    }
}
