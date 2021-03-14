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
using AstroClient.UdonExploits;
using AstroClient.ButtonShortcut;
using AstroClient.Variables;
#endregion AstroClient Imports

namespace AstroClient
{
    public static class AmongUSCheats
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
            if (WorldUtils.GetWorldID() == WorldIds.AmongUS)
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
            AmongUSUdonExploits.Init_GameController_Menu(AmongUsCheatsPage, 2, 0, true);

            AmongUSUdonExploits.Init_FilteredNodes_Menu(AmongUsCheatsPage, 2f, 0.5f, true);
            AmongUSUdonExploits.InitUnfilteredNodesMenu(AmongUsCheatsPage, 2f, 1f, true);

            AmongUSUdonExploits.Init_SabotageAndRepair_Menu(AmongUsCheatsPage, 3f, 0f, true);
            AmongUSUdonExploits.Init_KillPlayers_Menu(AmongUsCheatsPage, 3f, 0.5f, true);

            AmongUSUdonExploits.Init_ForceVotePlayer_menu(AmongUsCheatsPage, 4f, 0f, true);
            AmongUSUdonExploits.Init_ForcePlayerEject_Menu(AmongUsCheatsPage, 4f, 0.5f, true);

        }









        public static QMNestedButton AmongUsCheatsPage;

        public static bool HasAmongUsWorldLoaded = false;


    }
}