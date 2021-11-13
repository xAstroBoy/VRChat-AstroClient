﻿namespace AstroClient.Startup
{
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools;

    internal class UiModifier : GameEvents
    {
        internal override void VRChat_OnQuickMenuInit()
        {
            if (UserInterfaceObjects.ScreenFade != null)
            {
                UserInterfaceObjects.ScreenFade.GetOrAddComponent<Disabler>();
            }
        }
    }
}