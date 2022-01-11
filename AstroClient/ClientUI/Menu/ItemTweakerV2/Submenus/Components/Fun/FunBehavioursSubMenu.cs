namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Submenus.Components.Fun
{
    using AstroMonos.Components.Custom.Items;
    using Selector;
    using Tools.Extensions;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class FunBehavioursSubMenu : Tweaker_Events
    {
        internal static void Init_FunMenu(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedGridMenu(menu, "Fun Stuff", "Weird Behaviours that are fun and random.!");

            new QMSingleButton(submenu, "Make Stretchy Cheese", () => { Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<StretchyCheeseBehaviour>(); }, "Make sure is a Fork with Behaviour Extend");
            new QMSingleButton(submenu, "Remove Stretchy Cheese", () => { DestroyStretchyCheese(); }, "Make sure is a Fork with Behaviour Extend");
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