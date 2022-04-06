namespace AstroClient.ClientUI.ActionMenu
{
    using System.Drawing;
    using AstroMonos.Components.Spoofer;
    using AstroMonos.Components.Tools;
    using CheetoLibrary.Utility;
    using ClientResources.Loaders;
    using Gompoc.ActionMenuAPI.Api;
    using Menu.ESP;
    using Menu.ItemTweakerV2.Selector;
    using Menu.ItemTweakerV2.Submenus.Physic;
    using Menu.Menus.Quickmenu;
    using Spawnables.ColliderSuppresserCube;
    using Spawnables.Enderpearl;
    using Tools.Extensions.Components_exts;
    using Tools.Player.Movement.Exploit;
    using Tools.UdonSearcher;
    using xAstroBoy.Utility;

    internal class ItemTweakerModule : AstroEvents
    {
        internal override void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Item Tweaker ", () =>
            {
                CustomSubMenu.AddButton("Spawn Item Tweaker Object Selector Sphere", () => { TweakerSphere.SpawnSphere(); }, null, false);
                CustomSubMenu.AddButton("Get Held Item", () => { Tweaker_Object.GetGameObjectToEdit(); }, null, false);

                CustomSubMenu.AddToggle("Lock Item", Tweaker_Object.LockItem, (toggle) => { Tweaker_Object.LockItem = toggle; }, null, false);

                CustomSubMenu.AddSubMenu("Physic Editor", () =>
                {
                    CustomSubMenu.AddToggle("Smart Kinematic Remover", PhysicsSubmenu.SmartKinematicEnabled, (toggle) => { PhysicsSubmenu.SmartKinematicEnabled = toggle; }, null, false);
                    CustomSubMenu.AddToggle("Use Gravity", Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<RigidBodyController>().useGravity, (toggle) => { PhysicsSubmenu.Modified_SetGravity(toggle); }, null, false);
                    CustomSubMenu.AddToggle("is Kinematic", Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<RigidBodyController>().isKinematic, (toggle) => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_isKinematic(toggle); }, null, false);
                });

                // TODO: Add Textures!
            }, Icons.box);

            Log.Write("Item Tweaker Module is ready!", Color.Green);
        }
    }
}