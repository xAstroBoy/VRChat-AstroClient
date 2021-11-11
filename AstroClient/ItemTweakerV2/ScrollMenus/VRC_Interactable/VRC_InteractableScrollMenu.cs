namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using Selector;

    internal class VRC_InteractableScrollMenu
    {
        internal static void Init_VRC_InteractableScrollMenu(QMTabMenu main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Internal VRC_Interactable ", "Interact with Internal VRC_Interactable Triggers", null, null, null, null, btnHalf);
            menu.GetMainButton();
            var scroll = new QMScrollMenu(menu);
            _ = new QMSingleButton(menu, 0, -1, "Refresh", delegate
              {
                  scroll.Refresh();
              }, "", null, null, true);
            scroll.SetAction(delegate
            {
                foreach (var obj in Tweaker_Object.GetGameObjectToEdit().Get_VRCInteractables())
                {
                    var btn = new QMSingleButton(scroll.BaseMenu, 0, 0, $"Click {obj.name}", delegate
                    {
                        obj.VRC_Interactable_Click();
                    }, $"Click {obj.name}", null, obj.Get_GameObject_Active_ToColor());
                    var listener = obj.GetOrAddComponent<ScrollMenuListener>();
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