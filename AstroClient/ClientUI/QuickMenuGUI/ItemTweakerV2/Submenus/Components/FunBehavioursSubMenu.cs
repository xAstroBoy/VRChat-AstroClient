using AstroClient.AstroMonos.Components.Custom.Items;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components
{
    internal class FunBehavioursSubMenu 
    {
        internal static void Init_FunMenu(QMNestedGridMenu menu)
        {
            var submenu = new QMNestedGridMenu(menu, "Fun Stuff", "Weird Behaviours that are fun and random.!");

            new QMSingleButton(submenu, "Make Stretchy Cheese", () => { ComponentUtils.GetOrAddComponent<StretchyCheeseBehaviour>(Tweaker_Object.GetGameObjectToEdit()); }, "Make sure is a Fork with Behaviour Extend");
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