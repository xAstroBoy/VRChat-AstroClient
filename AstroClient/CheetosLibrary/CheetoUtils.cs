namespace CheetosLibrary
{
    using MelonLoader;
    using System;
    using UnityEngine;
    using VRC.UI.Elements;

    public class CheetoUtils
    {
        public static void TryRun(Action[] actions)
        {
            foreach (var action in actions)
            {
                try
                {
                    action();
                }
                catch (Exception e)
                {
                    MelonLogger.Error(e);
                }
            }
        }

        public static MenuStateController GetMenuStateController()
        {
            return GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)").GetComponent<MenuStateController>();
        }
    }
}