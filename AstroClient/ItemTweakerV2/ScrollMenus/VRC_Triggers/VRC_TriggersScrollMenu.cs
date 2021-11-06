namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using Selector;

    internal class VRC_TriggersScrollMenu
    {
        internal static void Init_VRC_TriggersScrollMenu(QMTabMenu main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Interact Triggers", "Interact with Selected Pickup Triggers", null, null, null, null, btnHalf);
            var scroll = new QMScrollMenu(menu);
            scroll.SetAction(delegate
            {
                foreach (var trigger in Tweaker_Object.GetGameObjectToEdit().Get_Triggers())
                {
                    var btn = new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {trigger.name}", delegate
                    {
                        trigger.TriggerClick();
                    }, $"Click {trigger.name}", null, trigger.Get_GameObject_Active_ToColor());
                    var listener = trigger.GetOrAddComponent<ScrollMenuListener>();
                    if (listener != null)
                    {
                        listener.assignedbtn = btn;
                    }
                    scroll.Add(btn);
                }
            });
        }
    }
}