namespace AstroClient.Startup
{
    using AstroLibrary.Utility;
    using Components;

    internal class UiModifier : GameEvents
    {
        internal override void VRChat_OnUiManagerInit()
        {
            if (UserInterfaceObjects.ScreenFade != null)
            {
                UserInterfaceObjects.ScreenFade.GetOrAddComponent<GameObjectDisabler>();
            }
        }
    }
}
