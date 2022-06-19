using AstroClient.ClientUI.QuickMenuGUI.Menus.Quickmenu;
using AstroClient.ClientUI.QuickMenuGUI.RandomSubmenus;
using AstroClient.Config;
using AstroClient.Tools.Extensions;

namespace AstroClient.ClientUI.ActionMenu
{
    using System.Drawing;
    using Gompoc.ActionMenuAPI.Api;
    using Spawnables.Enderpearl;
    using Tools.Player.Movement.Exploit;
    using ClientActions;
    using xAstroBoy.Utility;

    internal class PlayerModule : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }


        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Player Options", () =>
            {
                CustomSubMenu.AddSubMenu("Movement Options", () =>
                {
                    CustomSubMenu.AddToggle("Disable Falling Height Limit", MovementMenu.NoFallHeightLimit, ToggleValue => { MovementMenu.NoFallHeightLimit = ToggleValue; }, null);
                    CustomSubMenu.AddToggle("Toggle Ghost", MovementSerializer.SerializerActivated, ToggleValue => { MovementSerializer.SerializerActivated = ToggleValue; }, null);
                    CustomSubMenu.AddToggle("Toggle Disappear Ghost", TrollDefenseSubMenu.DisappearGhost, ToggleValue => { TrollDefenseSubMenu.DisappearGhost = ToggleValue; }, null);
                    CustomSubMenu.AddButton("Spawn EnderPearl", () => { AstroEnderPearl.SpawnEnderPearl(); }, null);
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
                CustomSubMenu.AddSubMenu("Avatar Options", () =>
                {
                    CustomSubMenu.AddToggle("Enable avatar scaling support", ConfigManager.AvatarOptions.ScalingAvatarSupportEnabled, ToggleValue => { ConfigManager.AvatarOptions.ScalingAvatarSupportEnabled = ToggleValue; }, null);
                    CustomSubMenu.AddToggle("Fix avatar root flying off", ConfigManager.AvatarOptions.FixAvatarFlyingOffOnScale, ToggleValue => { ConfigManager.AvatarOptions.FixAvatarFlyingOffOnScale = ToggleValue; }, null);
                    CustomSubMenu.AddToggle("Scale towards avatar root (not playspace center)", ConfigManager.AvatarOptions.FixPlayspaceCenterBias, ToggleValue => { ConfigManager.AvatarOptions.FixPlayspaceCenterBias = ToggleValue; }, null);
                    
                    CustomSubMenu.AddToggle("Adjust Player Collider (Avatar scale & Avatar change)", ConfigManager.AvatarOptions.AdjustColliderOnScaleChange, ToggleValue => { ConfigManager.AvatarOptions.AdjustColliderOnScaleChange = ToggleValue; }, null);
                    CustomSubMenu.AddToggle("Adjust Player Collider on Scale change", ConfigManager.AvatarOptions.AdjustAvatarCollider, ToggleValue => { ConfigManager.AvatarOptions.AdjustAvatarCollider = ToggleValue; }, null);

                    CustomSubMenu.AddToggle("Use Pose Height", ConfigManager.AvatarOptions.UsePoseHeight, ToggleValue => { ConfigManager.AvatarOptions.UsePoseHeight = ToggleValue; }, null);




                });

            });

            Log.Write("Player Module is ready!", Color.Green);
        }


    }
}