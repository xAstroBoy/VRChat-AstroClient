using AstroClient.ClientActions;

namespace AstroClient.Startup
{
    using AstroMonos.Components.Tools;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.UIPaths;
    using xAstroBoy.Utility;

    internal class UiModifier : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.VRChat_OnQuickMenuInit += VRChat_OnQuickMenuInit;
        }

        private void VRChat_OnQuickMenuInit()
        {
            //if (UserInterfaceObjects.ScreenFade != null)
            //{
            //    UserInterfaceObjects.ScreenFade.GetOrAddComponent<Disabler>();
            //}
        }
    }
}