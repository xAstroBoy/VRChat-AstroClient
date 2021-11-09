using UnityEngine;

namespace QuickMenuAPI.RinAPI
{
    internal static class ExtendedQuickMenu
    {
        private static VRC.UI.Elements.QuickMenu _quickMenuInstance;

        public static VRC.UI.Elements.QuickMenu Instance
        {
            get
            {
                if (_quickMenuInstance == null)
                {
                    _quickMenuInstance = QMStuff.GetQuickMenuInstance();
                }
                return _quickMenuInstance;
            }
        }

        public static VRC.UI.Elements.MenuStateController MenuStateCtrl => Instance.prop_MenuStateController_0;
    }
}
