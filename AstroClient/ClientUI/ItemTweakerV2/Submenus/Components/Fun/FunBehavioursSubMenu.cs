namespace AstroClient.ClientUI.ItemTweakerV2.Submenus.Components.Fun
{
    using AstroMonos.Components.Custom.Items;
    using AstroMonos.Components.Tools.KeycodeRevealer;
    using Selector;
    using Tools.Extensions;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    internal class FunBehavioursSubMenu : Tweaker_Events
    {
        internal static void Init_FunMenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var submenu = new QMNestedGridMenu(menu, x, y, "Fun Stuff", "Weird Behaviours that are fun and random.!", null, null, null, null, btnHalf);

            new QMSingleButton(submenu, 1, 0f, "Make Stretchy Cheese", () => { Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<StretchyCheeseBehaviour>(); }, "Make sure is a Fork with Behaviour Extend", null, null, true);
            new QMSingleButton(submenu, 1, 0.5f, "Remove Stretchy Cheese", () => { DestroyStretchyCheese(); }, "Make sure is a Fork with Behaviour Extend", null, null, true);
            new QMSingleButton(submenu, 1, 1f, "Reveal Current Object Keycode ", () => { Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<KeypadRevealer>(); }, "(works only with keycodes Objects.)", null, null, true);
        }

        internal static void DestroyStretchyCheese()
        {
            var beh = Tweaker_Object.GetGameObjectToEdit().GetComponent<StretchyCheeseBehaviour>();
            if (beh != null)
            {
                beh.DestroyMeLocal();
            }
        }
    }
}