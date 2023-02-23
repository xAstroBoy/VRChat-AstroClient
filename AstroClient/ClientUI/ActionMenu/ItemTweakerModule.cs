using AstroClient.ClientActions;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Submenus.Physic;
using AstroClient.Spawnables;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.ObjectEditor;

namespace AstroClient.ClientUI.ActionMenu
{
    using System.Drawing;
    using AstroMonos.Components.Spoofer;
    using AstroMonos.Components.Tools;
    using CheetoLibrary.Utility;
    using ClientResources.Loaders;
    using Gompoc.ActionMenuAPI.Api;
    using Tools.Extensions.Components_exts;
    using Tools.Player.Movement.Exploit;
    using Tools.UdonSearcher;
    using xAstroBoy.Utility;

    internal class ItemTweakerModule : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }

        private void OnApplicationStart()
        {
            AMUtils.AddToModsFolder("Item Tweaker ", () =>
            {
                CustomSubMenu.AddButton("Spawn Item Tweaker Object Selector Sphere", () => { TweakerSphere.Spawn(); }, null);
                CustomSubMenu.AddButton("Get Held Item", () => { Tweaker_Object.GetGameObjectToEdit(); }, null);
                CustomSubMenu.AddButton("Teleport To Item", () => { GameObjectMenu.TeleportPlayerToPickup(Tweaker_Object.GetGameObjectToEdit()); }, null);

                CustomSubMenu.AddToggle("Lock Item", Tweaker_Object.LockItem, (toggle) => { Tweaker_Object.LockItem = toggle; }, null);
                CustomSubMenu.AddToggle("AntiTheft", Tweaker_Object.GetGameObjectToEdit().Pickup_Get_AntiTheft(), (toggle) => { Tweaker_Object.GetGameObjectToEdit().Pickup_Set_AntiTheft(toggle); }, null);

                CustomSubMenu.AddSubMenu("Physic Editor", () =>
                {
                    CustomSubMenu.AddToggle("Smart Kinematic Remover", PhysicsSubmenu.SmartKinematicEnabled, (toggle) => { PhysicsSubmenu.SmartKinematicEnabled = toggle; }, null);
                    CustomSubMenu.AddToggle("Use Gravity", Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<RigidBodyController>().useGravity, (toggle) => { PhysicsSubmenu.Modified_SetGravity(toggle); }, null);
                    CustomSubMenu.AddToggle("is Kinematic", Tweaker_Object.GetGameObjectToEdit().GetOrAddComponent<RigidBodyController>().isKinematic, (toggle) => { Tweaker_Object.GetGameObjectToEdit().RigidBody_Set_isKinematic(toggle); }, null);
                });
            }, Icons.box);

            Log.Write("Item Tweaker Module is ready!", Color.Green);
        }
    }
}