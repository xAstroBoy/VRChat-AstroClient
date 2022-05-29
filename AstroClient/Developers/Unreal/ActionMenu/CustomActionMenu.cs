using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AstroClient.Cheetos;
using AstroClient.ClientResources.Loaders;
using Harmony;
using UnhollowerRuntimeLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;

namespace AstroClient.Unreal
{
    internal static class CustomActionMenu 
    {
        internal static bool isOpen(this ActionMenuOpener actionMenuOpener)
        {
            return actionMenuOpener.field_Private_Boolean_0;
        }

        internal static ActionMenuOpener GetActionMenuOpener()
        {
            if (!ActionMenuDriver.field_Public_Static_ActionMenuDriver_0.field_Public_ActionMenuOpener_0.isOpen() && ActionMenuDriver.field_Public_Static_ActionMenuDriver_0.field_Public_ActionMenuOpener_1.isOpen())
            {
                return ActionMenuDriver.field_Public_Static_ActionMenuDriver_0.field_Public_ActionMenuOpener_1;
            }
            if (ActionMenuDriver.field_Public_Static_ActionMenuDriver_0.field_Public_ActionMenuOpener_0.isOpen() && !ActionMenuDriver.field_Public_Static_ActionMenuDriver_0.field_Public_ActionMenuOpener_1.isOpen())
            {
                return ActionMenuDriver.field_Public_Static_ActionMenuDriver_0.field_Public_ActionMenuOpener_0;
            }
            return null;
        }

        
        //[DONT DELETE]
        //pedalOption.field_Public_MulticastDelegateNPublicSealedBoUnique_0 = DelegateSupport.ConvertDelegate<PedalOption.MulticastDelegateNPublicSealedBoUnique>(button.ButtonAction);


        internal static void OpenMainPage(ActionMenu __instance)
        {
            CustomActionMenu.activeActionMenu = __instance;
            if (true)
            {
                foreach (var button in SingleButtons)
                {
                    PedalOption pedalOption = activeActionMenu.Method_Private_PedalOption_0();
                    pedalOption.prop_String_0 = button.ButtonText;
                    if (button.ButtonIcon != null)
                    {
                        pedalOption.prop_Texture2D_0 = button.ButtonIcon;
                    }
                    button.currentPedalOption = pedalOption;
                    pedalOption.field_Public_Func_1_Boolean_0 = DelegateSupport.ConvertDelegate<Il2CppSystem.Func<bool>>(button.ButtonAction);
                }
                foreach (var button in ToggleButtons)
                {
                    PedalOption pedalOption = activeActionMenu.Method_Private_PedalOption_0();
                    pedalOption.prop_String_0 = button.ButtonText;
                    if (button.ButtonIcon != null)
                    {
                        pedalOption.prop_Texture2D_0 = button.ButtonIcon;
                    }
                    button.currentPedalOption = pedalOption;
                    pedalOption.field_Public_Func_1_Boolean_0 = DelegateSupport.ConvertDelegate<Il2CppSystem.Func<bool>>(button.ButtonAction);
                }

            }
        }

       // internal static List<ActionMenuPage> customPages = new List<ActionMenuPage>();
        internal static List<ActionMenuButton> SingleButtons = new List<ActionMenuButton>();
        internal static List<ActionMenuToggle> ToggleButtons = new List<ActionMenuToggle>();
        internal static bool Initialized = false;
        internal static ActionMenu activeActionMenu;
        public enum BaseMenu
        {
            MainMenu = 1
        }


    }
}
