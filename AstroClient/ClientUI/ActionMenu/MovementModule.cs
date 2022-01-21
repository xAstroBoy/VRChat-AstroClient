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
                CustomSubMenu.AddSubMenu("Enderpearl skins", () =>
                {
                    CustomSubMenu.AddToggle("Crystal Skin", AstroEnderPearl.isCrystalMatOn, (value) => { AstroEnderPearl.isCrystalMatOn = value; });
                    CustomSubMenu.AddToggle("Coral Skin", AstroEnderPearl.isCoralMatOn, (value) => { AstroEnderPearl.isCoralMatOn = value; });
                    CustomSubMenu.AddToggle("Strawberry Skin", AstroEnderPearl.isStrawberryMatOn, (value) => { AstroEnderPearl.isStrawberryMatOn = value; });
                    CustomSubMenu.AddToggle("Strawberry Milkshake foam Skin", AstroEnderPearl.isStrawberryMilshakeFoamMatOn, (value) => { AstroEnderPearl.isStrawberryMilshakeFoamMatOn = value; });
                    CustomSubMenu.AddToggle("Chocolate Skin", AstroEnderPearl.isChocolateMatOn, (value) => { AstroEnderPearl.isChocolateMatOn = value; });
                    CustomSubMenu.AddToggle("Coffee Skin", AstroEnderPearl.isCoffeeMatOn, (value) => { AstroEnderPearl.isCoffeeMatOn = value; });

                });
            });

            ModConsole.Log("Movement Module is ready!", Color.Green);
        }
    }
}