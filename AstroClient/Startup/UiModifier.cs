﻿namespace AstroClient.Startup
{
    using AstroMonos.Components.Tools;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.UIPaths;
    using xAstroBoy.Utility;

    internal class UiModifier : AstroEvents
    {
        internal override void VRChat_OnQuickMenuInit()
        {
            if (UserInterfaceObjects.ScreenFade != null)
            {
                UserInterfaceObjects.ScreenFade.GetOrAddComponent<Disabler>();
            }

            if (UserInterfaceObjects.VoiceDotDisabled != null)
            {
                var annoyingblink = UserInterfaceObjects.VoiceDotDisabled.GetComponent<FadeCycleEffect>();
                if (annoyingblink != null)
                {
                    annoyingblink.DestroyMeLocal();
                }
            }
        }
    }
}