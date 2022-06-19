using System;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.Tools.Extensions.Components_exts;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Components.Bouncer
{
    internal class BouncerSubMenu 
    {
        internal static void Init_BouncerMenu(QMNestedGridMenu main)
        {

            var mainmenu = new QMNestedGridMenu(main, "Bouncy Component", "Make it Bouncy!");
            _ = new QMSingleButton(mainmenu,  "Make It bouncy", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_Bouncer(); }), "Make It Bouncy!");
            new QMSingleButton(mainmenu,  "Make It bouncy toward player", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Add_Bouncer(true); }), "Make It bouncy toward player!");
            _ = new QMSingleButton(mainmenu,  "Remove Bouncy", new Action(() => { Tweaker_Object.GetGameObjectToEdit().Remove_Bouncer(); }), "Kill the Bouncyness!!");
        }
    }
}