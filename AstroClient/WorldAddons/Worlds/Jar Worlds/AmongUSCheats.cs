using RubyButtonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#region AstroClient Imports

using AstroClient.Finder;
using AstroClient.variables;
using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using System.Collections;
using UnityEngine.UI;
using VRC;
using MelonLoader;
using AstroClient.components;
using System.Threading.Tasks;
using System.Threading;
#endregion AstroClient Imports

namespace AstroClient
{
    public class AmongUSCheats
    {
  

        public static void FindAmongUsObjects()
        {
            ModConsole.Log("Removing Anti-Peek Protection...");
            var occlusion = GameObjectFinder.Find("Environment/skeld occ");
            if (occlusion != null)
            {
                occlusion.DestroyMeLocal();
            }
            ModConsole.Log("Removing Invisible Walls");
            var invisiblewall = GameObjectFinder.Find("Environment/Invisible wall");
            var invisiblewall_1 = GameObjectFinder.Find("Environment/Invisible wall (1)");
            if(invisiblewall != null)
            {
                invisiblewall.DestroyMeLocal();
            }
            if (invisiblewall_1 != null)
            {
                invisiblewall_1.DestroyMeLocal();
            }
        }


        public static void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == "wrld_dd036610-a246-4f52-bf01-9d7cea3405d7")
            {
                HasAmongUsWorldLoaded = true;
                if (AmongUsCheatsPage != null)
                {
                    ModConsole.Log("Recognized Among US world, Unlocking Among US cheats menu!", ConsoleColor.Green);
                    AmongUsCheatsPage.getMainButton().setIntractable(true);
                    AmongUsCheatsPage.getMainButton().setTextColor(Color.green);
                }
                FindAmongUsObjects();
            }
            else
            {
                HasAmongUsWorldLoaded = false;
                if (AmongUsCheatsPage != null)
                {
                    AmongUsCheatsPage.getMainButton().setIntractable(false);
                    AmongUsCheatsPage.getMainButton().setTextColor(Color.red);
                }
            }
        }


        public static void AmongUSCheatsButtons(QMNestedButton submenu, float BtnXLocation, float BtnYLocation, bool btnHalf)
        {
            AmongUsCheatsPage = new QMNestedButton(submenu, BtnXLocation, BtnYLocation, "Among US Cheats", "Manage Among US Cheats", null, null, null, null, btnHalf);
            JarRoleController.AmongUSRolesRevealerToggle = new QMToggleButton(AmongUsCheatsPage, 1, 0, "Reveal Roles On", new Action(() => { JarRoleController.ViewRoles = true; }), "Reveals Roles Off", new Action(() => { JarRoleController.ViewRoles = false; }), "Reveals Current Players Roles In nameplates.", null, null, null, false);
            UdonExploitsMenu.InitAmongUsGameControllerExploits(AmongUsCheatsPage, 2, 0, true);
            UdonExploitsMenu.InitAmongUSNodeExploitBtn(AmongUsCheatsPage, 2.5f, 0, true);
            JarRoleController.AmongUSShowHiddenNodesToggle = new QMToggleButton(AmongUsCheatsPage, 3, 0, "Reveal Hidden Nodes On", new Action(() => { JarRoleController.ShowHiddenNodes = true; }), "Reveal Hidden Nodes Off", new Action(() => { JarRoleController.ShowHiddenNodes = false; }), "Reveals Current Players Roles In nameplates.", null, null, null, false);

        }









        public static QMNestedButton AmongUsCheatsPage;

        public static bool HasAmongUsWorldLoaded = false;


    }
}