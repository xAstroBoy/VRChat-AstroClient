namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    using AstroClient.xAstroBoy;
    #region Imports

    using AstroNetworkingLibrary;
    using AstroNetworkingLibrary.Serializable;
    using CheetoLibrary.Utility;
    using ClientResources;
    using ClientResources.Loaders;
    using Constants;
    using UnityEngine;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    #endregion Imports

    internal class CheetosMenu : AstroEvents
    {
        internal static QMTabMenu SubMenu { get; private set; }

        internal static void InitButtons(int index)
        {
            if (!Bools.IsDeveloper) { return; }
            SubMenu = new QMTabMenu(index, "Cheetos Menu", null, null, null, Icons.cheetos_sprite);

            var testP = "UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_AudioSettings/Content/Audio/VolumeSlider_Master";
            var test = GameObjectFinder.InactiveFind(testP);

            if (test != null)
            {
                Object.Instantiate(test, SubMenu.page.gameObject.transform, true);
            }
            else
            {
                Log.Error("Could not find testP");
            }
        }
    }
}