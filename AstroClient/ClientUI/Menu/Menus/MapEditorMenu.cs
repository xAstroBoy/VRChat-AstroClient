namespace AstroClient.ClientUI.Menu.Menus
{
    using System;
    using CheetosUI;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using UnityEngine;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    internal static class MapEditorMenu
    {
        internal static void InitButtons(QMGridTab main)
        {
            var menu = new QMNestedGridMenu(main, "Map Editor Utils", "Map Editor");
            _ = new QMSingleButton(menu, 1, 0, "Spawn Empty Button", new Action(() =>
              {
                  Vector3? buttonPosition = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
                  Quaternion? buttonRotation = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
                  if (buttonPosition.HasValue && buttonRotation.HasValue)
                  {
                      var btn = new WorldButton(buttonPosition.Value, buttonRotation.Value, "Template Test", null);
                      btn.gameObject.Pickup_Set_ForceComponent();
                      btn.gameObject.Pickup_Set_Pickupable(true);
                      btn.gameObject.RigidBody_Set_isKinematic(true);
                      btn.gameObject.Set_As_Object_To_Edit();
                      btn.gameObject.AddToWorldUtilsMenu();
                  }
              }), "Spawn Preset Button", null, null, true);
            _ = new QMSingleButton(menu, 2, 0, "Toggles all Map Items Active", () => { EnableAllObjects(); }, "Sets Map objects active, will Break Instance Locally..", null, Color.red, true);
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