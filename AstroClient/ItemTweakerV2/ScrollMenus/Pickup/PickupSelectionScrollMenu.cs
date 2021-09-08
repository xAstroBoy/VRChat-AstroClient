namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using RubyButtonAPI;
    using System;
    using UnityEngine;
    using VRC;

    public class PickupSelectionScrollMenu : Tweaker_Events
    {
        public static void Init_PickupSelectionQMScroll(QMTabMenu main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Select Pickup", "Select World Pickup to edit", null, null, null, null, btnHalf);
            var PickupQMScroll = new QMScrollMenu(menu);
            _ = new QMSingleButton(menu, 0, -1, "Refresh", delegate
              {
                  PickupQMScroll.Refresh();
              }, "", null, null, true);

            Pickup_IsHeldStatus = new QMSingleButton(menu, -1, -1f, "Held : No", null, "See if Pickup is held or not.", null, null, true);

            Pickup_CurrentObjectHolder = new QMSingleButton(menu, -1, -0.5f, "Current holder : null", null, "Who is the current object Holder.", null, null, false);
            Pickup_CurrentObjectHolder.SetResizeTextForBestFit(true);

            Pickup_CurrentObjectOwner = new QMSingleButton(menu, -1, 0.5f, "Current Owner : null", null, "Who is the current object owner.", null, null, false);
            Pickup_CurrentObjectOwner.SetResizeTextForBestFit(true);

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

            PickupQMScroll.SetAction(delegate
            {
                foreach (var pickup in WorldUtils_Old.Get_Pickups())
                {
                    var btn = new QMSingleButton(PickupQMScroll.BaseMenu, 0, 0, $"Select {pickup.name}", delegate
                    {
                        Tweaker_Object.SetObjectToEdit(pickup);
                    }, $"Select {pickup.name}", null, pickup.Get_GameObject_Active_ToColor());
                    var listener = pickup.GetOrAddComponent<ScrollMenuListener>();
                    if (listener != null)
                    {
                        listener.assignedbtn = btn;
                    }

                    PickupQMScroll.Add(btn);
                }
            });
        }

        public override void OnPickupController_OnUpdate(PickupController control)
        {
            if (control != null)
            {
                if (Pickup_IsHeldStatus != null)
                {
                    Pickup_IsHeldStatus.SetButtonText(control.Get_IsHeld_ButtonText());
                    Pickup_IsHeldStatus.SetTextColor(control.Get_IsHeld_ButtonColor());
                }
                if (Pickup_CurrentObjectOwner != null)
                {
                    Pickup_CurrentObjectOwner.SetButtonText(control.Get_PickupOwner_ButtonText());
                }
                if (Pickup_CurrentObjectHolder != null)
                {
                    Pickup_CurrentObjectHolder.SetButtonText(control.Get_IsHeldBy_ButtonText());
                }
            }
        }

        private static QMSingleButton Pickup_IsHeldStatus { get; set; }
        private static QMSingleButton Pickup_CurrentObjectHolder { get; set; }
        private static QMSingleButton Pickup_CurrentObjectOwner { get; set; }

        public override void On_New_GameObject_Selected(GameObject obj)
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

        public override void OnTargetSet(Player player)
        {
            if (TeleportToTarget != null)
            {
                TeleportToTarget.SetButtonText(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
                TeleportToTarget.SetToolTip(ButtonStringExtensions.Generate_TeleportToTarget_ButtonText(Tweaker_Selector.SelectedObject, player));
            }
        }

        public static QMSingleButton TeleportToMe;
        public static QMSingleButton TeleportToTarget;
    }
}