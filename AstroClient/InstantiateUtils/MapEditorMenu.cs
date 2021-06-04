namespace AstroClient
{
	using AstroClient.Extensions;
	using RubyButtonAPI;
	using System;

	public static class MapEditorMenu
    {
        public static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            var menu = new QMNestedButton(main, x, y, "Map Editor Utils", "Map Editor", null, null, null, null, btnHalf);
            new QMSingleButton(menu, 1, 0, "Spawn Empty Button", new Action(() =>
            {
                var buttonPosition = LocalPlayerUtils.CenterOfPlayer();
                var buttonRotation = LocalPlayerUtils.GetSelfPlayer().gameObject.transform.rotation;
                var btn = ButtonCreator.Create("Template", buttonPosition, buttonRotation, null);
                btn.TeleportToMe();
                btn.ForcePickupComponent();
                btn.SetPickupable(true);
                btn.SetObjectToEdit();
                btn.AddToWorldUtilsMenu();
            }), "Spawn Preset Button", null, null, true);
        }
    }
}