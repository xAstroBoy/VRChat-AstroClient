namespace AstroClient
{
    using System;
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using UnityEngine;

    internal static class MapEditorMenu
    {
        internal static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Map Editor Utils", "Map Editor", null, null, null, null, btnHalf);
            _ = new QMSingleButton(menu, 1, 0, "Spawn Empty Button", new Action(() =>
              {
                  Vector3? buttonPosition = Utils.LocalPlayer.GetPlayer().Get_Center_Of_Player();
                  Quaternion? buttonRotation = Utils.LocalPlayer.GetPlayer().gameObject.transform.rotation;
                  if (buttonRotation != null && buttonRotation != null)
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