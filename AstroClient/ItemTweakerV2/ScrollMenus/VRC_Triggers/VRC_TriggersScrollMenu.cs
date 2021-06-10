namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
	using AstroClient.Components;
	using AstroClient.ItemTweakerV2.Selector;
	using AstroLibrary.Extensions;
	using RubyButtonAPI;

	internal class VRC_TriggersScrollMenu
    {
        public static void Init_VRC_TriggersScrollMenu(QMTabMenu main, float x, float y, bool btnHalf)
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