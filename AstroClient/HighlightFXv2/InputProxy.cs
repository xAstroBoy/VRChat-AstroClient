using UnityEngine;

namespace HighlightPlus
{
    public static class InputProxy
    {
        public static void Init()
        { }

        public static Vector3 mousePosition
        {
            get
            {
                return Input.mousePosition;
            }
        }

        public static bool GetMouseButtonDown(int buttonIndex)
        {
            return Input.GetMouseButtonDown(buttonIndex);
        }

        public static int touchCount
        {
            get { return Input.touchCount; }
        }

        public static int GetFingerIdFromTouch(int touchIndex)
        {
            return Input.GetTouch(touchIndex).fingerId;
        }

        public static bool GetKeyDown(string name)
        {
            return Input.GetKeyDown(name);
        }
    }
}