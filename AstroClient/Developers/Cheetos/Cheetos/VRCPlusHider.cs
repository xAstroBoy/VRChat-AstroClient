using AstroClient.ClientActions;

namespace AstroClient.Cheetos
{
    #region Imports

    using System.Collections.Generic;
    using Config;
    using xAstroBoy;

    #endregion Imports

    internal class VRCPlusHider : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (ConfigManager.UI.RemoveVRCPlusMenu)
            {
                var found = Finder.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/VRC+PageTab");
                if (found != null)
                {
                    found.SetActive(false);
                }
            }

            if (ConfigManager.UI.RemoveReportButton)
            {
                var found = Finder.Find("UserInterface/QuickMenu/ShortcutMenu/ReportWorldButton");
                if (found != null)
                {
                    found.SetActive(false);
                }
            }

            if (ConfigManager.UI.RemoveUserIconButton)
            {
                var found = Finder.Find("UserInterface/QuickMenu/ShortcutMenu/UserIconButton");
                if (found != null)
                {
                    found.SetActive(false);
                }
            }

            if (ConfigManager.UI.RemoveVRCPlusMiniBanner)
            {
                var found = Finder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusMiniBanner");
                var found_2 = Finder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusMiniBanner/Image");
                if (found != null)
                {
                    found.SetActive(false);
                }

                if (found_2 != null)
                {
                    found_2.SetActive(false);
                }
            }

            if (ConfigManager.UI.RemoveVRCPlusBanner)
            {
                var found = Finder.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner");
                if (found != null)
                {
                    found.SetActive(false);
                }
            }

            if (ConfigManager.UI.RemoveUserIconCameraButton)
            {
                var found = Finder.Find("UserInterface/QuickMenu/ShortcutMenu/UserIconCameraButton");
                if (found != null)
                {
                    found.SetActive(false);
                }
            }

            if (ConfigManager.UI.RemoveVRCPlusThankYou)
            {
                var found = Finder.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou");
                if (found != null)
                {
                    found.SetActive(false);
                }
            }

            if (ConfigManager.UI.RemoveGalleryButton)
            {
                var found = Finder.Find("UserInterface/QuickMenu/ShortcutMenu/GalleryButton");
                if (found != null)
                {
                    found.SetActive(false);
                }
            }
        }
    }
}