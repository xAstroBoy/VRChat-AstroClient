using System.Collections.Generic;
using UnhollowerRuntimeLib;
using UnityEngine;

namespace AstroClient.Unreal;

internal class ActionMenuPage
{
    internal ActionMenuPage(CustomActionMenu.BaseMenu baseMenu, string buttonText, Texture2D buttonIcon = null)
    {
        if (baseMenu == CustomActionMenu.BaseMenu.MainMenu)
        {
            this.menuEntryButton = new ActionMenuButton(CustomActionMenu.BaseMenu.MainMenu, buttonText, delegate ()
            {
                this.OpenMenu(null);
            }, buttonIcon);
        }
    }

    internal ActionMenuPage(ActionMenuPage basePage, string buttonText, Texture2D buttonIcon = null)
    {
        this.previousPage = basePage;
        this.menuEntryButton = new ActionMenuButton(this.previousPage, buttonText, delegate ()
        {
            this.OpenMenu(basePage);
        }, buttonIcon);
    }

    internal void OpenMenu(ActionMenuPage currentPage)
    {
        CustomActionMenu.GetActionMenuOpener().field_Public_ActionMenu_0.Method_Public_Page_Action_Action_Texture2D_String_0(new System.Action(() =>
        {
            foreach (var button in this.buttons)
            {
                PedalOption pedalOption = CustomActionMenu.GetActionMenuOpener().field_Public_ActionMenu_0.Method_Private_PedalOption_0();
                pedalOption.prop_String_0 = button.ButtonText;
                pedalOption.Method_Public_Void_Boolean_0(button.IsEnabled);
                if (button.ButtonIcon != null)
                {
                    pedalOption.prop_Texture2D_0 = button.ButtonIcon;
                }
                button.currentPedalOption = pedalOption;
                    //[DONT DELETE]
                    //pedalOption.field_Public_MulticastDelegateNPublicSealedBoUnique_0 = DelegateSupport.ConvertDelegate<PedalOption.MulticastDelegateNPublicSealedBoUnique>(button.ButtonAction);
                    pedalOption.field_Public_Func_1_Boolean_0 = DelegateSupport.ConvertDelegate<Il2CppSystem.Func<bool>>(button.ButtonAction);
            }
            foreach (var button in this.Toggles)
            {
                PedalOption pedalOption = CustomActionMenu.GetActionMenuOpener().field_Public_ActionMenu_0.Method_Private_PedalOption_0();
                pedalOption.prop_String_0 = button.ButtonText;
                pedalOption.Method_Public_Void_Boolean_0(button.IsEnabled);
                if (button.ToggleState)
                {
                    pedalOption.prop_Texture2D_0 = button.typeToggleOn;
                }
                else
                {
                    pedalOption.prop_Texture2D_0 = button.typeToggleOff;
                }
                button.currentPedalOption = pedalOption;
                pedalOption.field_Public_Func_1_Boolean_0 = DelegateSupport.ConvertDelegate<Il2CppSystem.Func<bool>>(button.ButtonAction);
            }

        }), null, null, null);
    }

    internal List<ActionMenuButton> buttons = new List<ActionMenuButton>();
    internal List<ActionMenuToggle> Toggles = new List<ActionMenuToggle>();

    internal ActionMenuPage previousPage;
    internal ActionMenuButton menuEntryButton;
}
