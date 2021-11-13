namespace AstroClient.ClientUI.ActionMenuButtons
{
    using System.Drawing;
    using AstroActionMenu.Api;
    using AstroLibrary.Console;
    using Features.Player.Movement.Exploit;

    internal class MovementModule : GameEvents
    {
        internal override void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Movement Options", () =>
            {
                // TODO: Add Textures!
                CustomSubMenu.AddToggle("Toggle Ghost", MovementSerializer.SerializerActivated, ToggleValue => { MovementSerializer.SerializerActivated = ToggleValue; }, null, false);
                CustomSubMenu.AddButton("Spawn EnderPearl", () => { AstroEnderPearl.SpawnEnderPearl(); }, null, false);
            });

            ModConsole.Log("Movement Module is ready!", Color.Green);
        }
    }
}