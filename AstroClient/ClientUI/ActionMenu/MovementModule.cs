namespace AstroClient.ClientUI.ActionMenu
{
    using System.Drawing;
    using Gompoc.ActionMenuAPI.Api;
    using Spawnables.Enderpearl;
    using Tools.Player.Movement.Exploit;

    internal class MovementModule : AstroEvents
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