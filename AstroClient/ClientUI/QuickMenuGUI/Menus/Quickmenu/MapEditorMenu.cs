using AstroClient.ClientUI.Menu.RandomSubmenus;
using AstroClient.Tools.UdonEditor;
using MelonLoader;

namespace AstroClient.ClientUI.Menu.Menus.Quickmenu
{
    using System;
    using CheetosUI;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using UnityEngine;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal static class MapEditorMenu
    {
        internal static void InitButtons(QMGridTab main)
        {
            var menu = new QMNestedGridMenu(main, "Map Editor Utils", "Map Editor");
            _ = new QMSingleButton(menu,  "Spawn Empty Button", new Action(() =>
              {
                  Vector3? buttonPosition = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
                  Quaternion? buttonRotation = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
                  if (buttonPosition.HasValue && buttonRotation.HasValue)
                  {
                      var btn = new WorldButton(buttonPosition.Value, buttonRotation.Value, "Template Test", null);
                      btn.MakePickupable();
                      btn.RegisterToWorldMenu();
                  }
              }), "Spawn Preset Button");
            _ = new QMSingleButton(menu,  "Toggles all Map Items Active", () => { EnableAllObjects(); }, "Sets Map objects active, will Break Instance Locally..", Color.red);
            new QMSingleButton(menu, "Dumps All udon Events", () => { UdonDumper.Dump_All_UdonBehaviours(false); }, "Dumps all Udon Events in Console & File..");
            new QMSingleButton(menu, "Dumps all Udon Events in Console & File..", () => { UdonDumper.Dump_All_UdonBehaviours(true); }, "Dumps All udon Events & Internals");
            new QMSingleButton(menu, "Extract all UdonBehaviour programs..", () => { UdonDumper.Dump_All_UdonBehaviours_Programs(); }, "Dumps All udon Program Codes!");
            new QMSingleButton(menu, "Dumps All duplicate Udon Custom EventsKeys", () => { UdonDumper.Dump_AllCustomEventKeysDuplicates(); }, "Dumps all Udon Events in Console & File..");

        }

        internal static void EnableAllObjects()
        {
            System.Collections.Generic.List<GameObject> list1 = GameObjectFinder.RootSceneObjects_WithoutAvatars;
            for (int i1 = 0; i1 < list1.Count; i1++)
            {
                GameObject item = list1[i1];
                System.Collections.Generic.List<Transform> list = item.transform.Get_All_Childs();
                for (int i = 0; i < list.Count; i++)
                {
                    Transform child = list[i];
                    if (!child.gameObject.active)
                    {
                        if (!child.isMirror()) // Check and ignore mirrors.
                        {
                            child.gameObject.SetActiveRecursively(true);
                        }
                    }
                }
            }
        }


        
    }
}