namespace AstroClient.Startup
{
    using AstroMonos.Components.Tools;
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
        }
    }
}