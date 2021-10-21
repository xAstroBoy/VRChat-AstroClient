namespace CheetoLibrary.ButtonAPI
{
    using VRC.UI.Elements;

    internal static class WingUtils
    {
        private static MenuStateController _wingMenuControllerLeft;
        private static MenuStateController _wingMenuControllerRight;
        private static Wing _wingLeft;
        private static Wing _wingRight;

        internal static MenuStateController WingMenuStateControllerLeft
        {
            get
            {
                if (_wingMenuControllerLeft == null)
                {
                    var Buttons = QMUtils.QuickMenuInstance.GetComponentsInChildren<MenuStateController>(true);
                    foreach (var button in Buttons)
                    {
                        if (button.name == "Wing_Left")
                        {
                            _wingMenuControllerLeft = button;
                            break;
                        }
                    };
                }
                return _wingMenuControllerLeft;
            }
        }

        internal static MenuStateController WingMenuStateControllerRight
        {
            get
            {
                if (_wingMenuControllerRight == null)
                {
                    var Buttons = QMUtils.QuickMenuInstance.GetComponentsInChildren<MenuStateController>(true);
                    foreach (var button in Buttons)
                    {
                        if (button.name == "Wing_Right")
                        {
                            _wingMenuControllerRight = button;
                            break;
                        }
                    };
                }
                return _wingMenuControllerRight;
            }
        }

        internal static Wing WingLeft
        {
            get
            {
                if (_wingLeft == null)
                {
                    var Buttons = QMUtils.QuickMenuInstance.GetComponentsInChildren<Wing>(true);
                    foreach (var button in Buttons)
                    {
                        if (button.name == "Wing_Left")
                        {
                            _wingLeft = button;
                            break;
                        }
                    };
                }
                return _wingLeft;
            }
        }

        internal static Wing WingRight
        {
            get
            {
                if (_wingRight == null)
                {
                    var Buttons = QMUtils.QuickMenuInstance.GetComponentsInChildren<Wing>(true);
                    foreach (var button in Buttons)
                    {
                        if (button.name == "Wing_Right")
                        {
                            _wingRight = button;
                            break;
                        }
                    };
                }
                return _wingRight;
            }
        }
    }
}
