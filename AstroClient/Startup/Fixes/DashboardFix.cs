namespace AstroClient.Startup.Fixes
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.Utility;

    internal class DashboardFix : AstroEvents
    {
        internal override void VRChat_OnQuickMenuInit()
        {
            if (QuickMenuTools.MenuDashboard != null)
            {
                QuickMenuTools.MenuDashboard.gameObject.ToggleScrollRectOnExistingMenu(true);
                ModConsole.DebugLog("Activated Dashboard Scrollbar!");
            }
        }
    }
}