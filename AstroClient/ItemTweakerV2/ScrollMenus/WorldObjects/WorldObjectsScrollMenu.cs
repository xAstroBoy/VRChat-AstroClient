namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
    using AstroClient.ItemTweakerV2.Selector;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroButtonAPI;
    using System;
    using System.Collections.Generic;
    using AstroMonos.Components.Tools.Listeners;
    using UnityEngine;
    using VRC;

    internal class WorldObjectsScrollMenu : Tweaker_Events
    {
        internal static void Init_WorldObjectScrollMenu(QMTabMenu main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Select W.Objects", "Select World Objects to edit", null, null, null, null, btnHalf);
            var scroll = new QMScrollMenu(menu);
            _ = new QMSingleButton(menu, 0, -1, "Refresh", delegate
              {
                  scroll.Refresh();
              }, "", null, null, true);

            TeleportToMe = new QMSingleButton(menu, 0, -0.5f, Tweaker_Selector.SelectedObject.Generate_TeleportToMe_ButtonText(), delegate
           {
               Tweaker_Object.GetGameObjectToEdit().TeleportToMe();
           }, Tweaker_Selector.SelectedObject.Generate_TeleportToMe_ButtonText());
            TeleportToMe.SetResizeTextForBestFit(true);

            TeleportToTarget = new QMSingleButton(menu, 0, 0.5f, ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget), delegate
            {
                Tweaker_Object.GetGameObjectToEdit().TeleportToTarget();
            }, ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, TargetSelector.CurrentTarget));
            TeleportToTarget.SetResizeTextForBestFit(true);

            _ = new QMSingleButton(menu, 0, 1.5f, "Spawn Clone", new Action(() => { Cloner.ObjectCloner.CloneGameObject(Tweaker_Object.GetGameObjectToEdit()); }), "Instantiates a copy of The selected object.", null, null, true);

            scroll.SetAction(delegate
            {
                foreach (var item in WorldObjects)
                {
                    var btn = new QMSingleButton(scroll.BaseMenu, 0, 0, $"Select {item.name}", delegate
                    {
                        item.Set_As_Object_To_Edit();
                    }, $"Select {item.name}", null, item.Get_GameObject_Active_ToColor());
                    var listener = item.GetOrAddComponent<ScrollMenuListener>();
                    if (listener != null)
                    {
                        listener.assignedbtn = btn;
                    }
                    scroll.Add(btn);
                }
            });
        }

        internal static void AddToWorldUtilsMenu(GameObject obj)
        {
            if (obj != null)
            {
                if (!WorldObjects.Contains(obj))
                {
                    WorldObjects.Add(obj);
                }
            }
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            WorldObjects.Clear();
        }

        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
                TeleportToTarget.SetToolTip(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(obj, TargetSelector.CurrentTarget));
            }
            if (TeleportToMe != null)
            {
                TeleportToMe.SetButtonText(obj.Generate_TeleportToMe_ButtonText());
                TeleportToMe.SetToolTip(obj.Generate_TeleportToMe_ButtonText());
            }
        }

        internal override void OnTargetSet(Player player)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
                TeleportToTarget.SetToolTip(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
            }
        }

        internal static QMSingleButton TeleportToMe;
        internal static QMSingleButton TeleportToTarget;

        internal static List<GameObject> WorldObjects = new List<GameObject>();
    }
}