namespace AstroClient.ItemTweakerV2.Submenus
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroButtonAPI;
    using System;

    internal class FunBehavioursSubMenu : Tweaker_Events
    {

        internal static void Init_FunMenu(QMNestedButton menu, float x, float y, bool btnHalf)
        {
            var submenu = new QMNestedButton(menu, x, y, "Fun Stuff", "Weird Behaviours that are fun and random.!", null, null, null, null, btnHalf);

            new QMSingleButton(submenu, 1, 0f, "Make Stretchy Cheese", () => { ItemTweakerV2.Selector.Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<StretchyCheeseBehaviour>(); }, "Make sure is a Fork with Behaviour Extend", null, null, true);
            new QMSingleButton(submenu, 1, 0.5f, "Remove Stretchy Cheese", () => { DestroyStretchyCheese(); }, "Make sure is a Fork with Behaviour Extend", null, null, true);
            new QMSingleButton(submenu, 1, 1f, "Reveal Current Object Keycode ", () => { ItemTweakerV2.Selector.Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<KeypadRevealer>(); }, "(works only with keycodes Objects.)", null, null, true);

        }

        internal static void DestroyStretchyCheese()
        {
            var beh = ItemTweakerV2.Selector.Tweaker_Object.GetGameObjectToEdit().GetComponent<StretchyCheeseBehaviour>();
            if (beh != null)
            {
                beh.DestroyMeLocal();
            }
        }
    }
}