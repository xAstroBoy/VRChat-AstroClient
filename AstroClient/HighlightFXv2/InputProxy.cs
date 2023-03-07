using UnityEngine;

namespace AstroClient.HighlightFXv2
{
    internal static class InputProxy
    {
        internal static void Init()
        { }

        internal static Vector3 mousePosition
        {
            get
            {
                return Input.mousePosition;
            }
        }

        internal static bool GetMouseButtonDown(int buttonIndex)
        {
            return Input.GetMouseButtonDown(buttonIndex);
        }

        internal static int touchCount
        {
            get { return Input.touchCount; }
        }

        internal static int GetFingerIdFromTouch(int touchIndex)
        {
            return Input.GetTouch(touchIndex).fingerId;
        }

        internal static bool GetKeyDown(string name)
        {
            return Input.GetKeyDown(name);
        }
    }
}