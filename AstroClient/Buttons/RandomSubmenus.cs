namespace AstroClient
{
	using AstroClient.AstroUtils.ItemTweaker;
	using AstroClient.Extensions;
	using RubyButtonAPI;

	internal class RandomSubmenus
    {
        public static void VRC_InteractableSubMenu(QMTabMenu main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Interact VRC_Interactable", "Interact with VRC_Interactable Triggers", null, null, null, null, btnHalf);
            var scroll = new QMScrollMenu(menu);
            new QMSingleButton(menu, 0, -1, "Refresh", delegate
            {
                scroll.Refresh();
            }, "", null, null, true);
            scroll.SetAction(delegate
            {
                foreach (var obj in WorldUtils.Get_VRCInteractables())
                {
                    scroll.Add(
                    new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {obj.name}", delegate
                    {
                        obj.VRC_Interactable_Click();
                    }, $"Click {obj.name}", null, obj.Get_GameObject_Active_ToColor()));
                }
            });
        }

        public static void TriggerSubMenu(QMTabMenu main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Interact Triggers", "Interact with Level Triggers", null, null, null, null, btnHalf);
            var scroll = new QMScrollMenu(menu);
            new QMSingleButton(menu, 0, -1, "Refresh", delegate
            {
                scroll.Refresh();
            }, "", null, null, true);
            scroll.SetAction(delegate
            {
                foreach (var trigger in WorldUtils.Get_Triggers())
                {
                    scroll.Add(
                    new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {trigger.name}", delegate
                    {
                        trigger.TriggerClick();
                    }, $"Click {trigger.name}", null, trigger.Get_GameObject_Active_ToColor()));
                }
            });
        }
    }
}