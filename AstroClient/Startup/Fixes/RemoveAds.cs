using AstroClient.ClientActions;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using UnityEngine;

namespace AstroClient.Startup.Fixes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class RemoveAds : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnBigMenuOpen += PurgeBigMenu;
            ClientEventActions.OnQuickMenuOpen += PurgeQuickMenu;

        }

        #region MainMenu Ads Remover

        private void PurgeBigMenu()
        {
            KillCarouselBigMenu();
            ClientEventActions.OnBigMenuOpen -= PurgeBigMenu;
        }

        private static Transform _BigMenuAds;
        internal static Transform BigMenuAds
        {
            get
            {
                if (_BigMenuAds == null) _BigMenuAds = QuickMenuTools.Canvas_MainMenu.FindObject("Container/MMParent/Menu_Dashboard/ScrollRect_MM/Viewport/Content/Panel");
                return _BigMenuAds;
            }
        }


        internal void KillCarouselBigMenu()
        {
            // Fuck off VRChat
            if(BigMenuAds != null)
            {
                // Move this where the stupid Ads are
                var UserInfoDataGrid = BigMenuAds.FindObject("CellGrid_MM_4Column");
                if (UserInfoDataGrid != null)
                {
                    UserInfoDataGrid.localPosition = new Vector3(-801.6901f, 138.54f, -0.0572f);
                }
                // No thank you VRChat
                var Ads = BigMenuAds.FindObject("Carousel_Banners");
                if (Ads != null)
                {
                    Ads.DestroyMeLocal(true);
                }
            }

        }


        #endregion


        #region QuickMenu Ads Remover

        private void PurgeQuickMenu()
        {
            KillCarouselQuickMenu();
            ClientEventActions.OnQuickMenuOpen -= PurgeQuickMenu;
        }

        private static Transform _QuickMenuAds;
        internal static Transform QuickMenuAds
        {
            get
            {
                if (_QuickMenuAds == null) _QuickMenuAds = QuickMenuTools.Canvas_QuickMenu.FindObject("CanvasGroup/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Carousel_Banners");
                return _QuickMenuAds;
            }
        }


        internal void KillCarouselQuickMenu()
        {
            // Fuck off VRChat
            if (QuickMenuAds != null)
            {
                QuickMenuAds.DestroyMeLocal(true);
            }

        }


        #endregion



    }
}
