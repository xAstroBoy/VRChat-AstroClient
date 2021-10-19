namespace CheetoLibrary.ButtonAPI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;
    using VRC.UI.Elements;

    internal static class QMStuff
    {
        private static QuickMenu _quickMenuInstance;
        private static MenuStateController _quickMenuController;

        internal static QuickMenu QuickMenuInstance
        {
            get
            {
                if (_quickMenuInstance == null) _quickMenuInstance = Resources.FindObjectsOfTypeAll<QuickMenu>()[0];
                return _quickMenuInstance;
            }
        }

        internal static MenuStateController QuickMenuController
        {
            get
            {
                if (_quickMenuController == null)
                {
                    var Buttons = QuickMenuInstance.GetComponentsInChildren<MenuStateController>(true);
                    foreach (var button in Buttons)
                    {
                        if (button.name == "Canvas_QuickMenu(Clone)")
                        {
                            _quickMenuController = button;
                            break;
                        }
                    };
                }
                return _quickMenuController;
            }
        }
    }
}
