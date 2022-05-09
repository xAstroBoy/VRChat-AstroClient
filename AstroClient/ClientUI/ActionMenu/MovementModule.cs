
using AstroClient.ClientUI.Menu.Menus.Quickmenu;
using AstroClient.Tools.Extensions;

namespace AstroClient.ClientUI.ActionMenu
{
    using System.Drawing;
    using Gompoc.ActionMenuAPI.Api;
    using Menu.RandomSubmenus;
    using Spawnables.Enderpearl;
    using Tools.Player.Movement.Exploit;
    using ClientActions;
    using xAstroBoy.Utility;

    internal class MovementModule : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }


        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Movement Options", () =>
            {
                // TODO: Add Textures!
                CustomSubMenu.AddToggle("Disable Falling Height Limit", MovementMenu.NoFallHeightLimit, ToggleValue => { MovementMenu.NoFallHeightLimit = ToggleValue; }, null, false);
                CustomSubMenu.AddToggle("Toggle Ghost", MovementSerializer.SerializerActivated, ToggleValue => { MovementSerializer.SerializerActivated = ToggleValue; }, null, false);
                CustomSubMenu.AddToggle("Toggle Disappear Ghost", TrollDefenseSubMenu.DisappearGhost, ToggleValue => { TrollDefenseSubMenu.DisappearGhost = ToggleValue; }, null, false);
                CustomSubMenu.AddButton("Spawn EnderPearl", () => { AstroEnderPearl.SpawnEnderPearl(); }, null, false);
                CustomSubMenu.AddSubMenu("Enderpearl skins", () =>
                {
                    CustomSubMenu.AddToggle("Crystal Skin", AstroEnderPearl.isCrystalMatOn, (value) => { AstroEnderPearl.isCrystalMatOn = value; });
                    CustomSubMenu.AddToggle("Coral Skin", AstroEnderPearl.isCoralMatOn, (value) => { AstroEnderPearl.isCoralMatOn = value; });
                    CustomSubMenu.AddToggle("Strawberry Skin", AstroEnderPearl.isStrawberryMatOn, (value) => { AstroEnderPearl.isStrawberryMatOn = value; });
                    CustomSubMenu.AddToggle("Strawberry Milkshake foam Skin", AstroEnderPearl.isStrawberryMilshakeFoamMatOn, (value) => { AstroEnderPearl.isStrawberryMilshakeFoamMatOn = value; });
                    CustomSubMenu.AddToggle("Chocolate Skin", AstroEnderPearl.isChocolateMatOn, (value) => { AstroEnderPearl.isChocolateMatOn = value; });
                    CustomSubMenu.AddToggle("Coffee Skin", AstroEnderPearl.isCoffeeMatOn, (value) => { AstroEnderPearl.isCoffeeMatOn = value; });
                    CustomSubMenu.AddToggle("Waffle Skin", AstroEnderPearl.isWaffleMatOn, (value) => { AstroEnderPearl.isWaffleMatOn = value; });

                });
            });

            Log.Write("Movement Module is ready!", Color.Green);
        }


    }
}