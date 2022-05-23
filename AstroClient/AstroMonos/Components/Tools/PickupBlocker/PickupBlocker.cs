
using System.Collections.Concurrent;
using System.Collections.Generic;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Menu.SettingsMenu;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.ObjectEditor.Online;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using Photon.Pun;
using VRC;
using VRC.Core;

namespace AstroClient.PickupBlockerSystem
{
    internal class PickupBlocker : AstroEvents
    {
        private static bool HasPickupControllerBeenAdded { get; set; } = false;

        private static void StartPickupBlockerSystem()
        {
            if (!HasPickupControllerBeenAdded)
            {
                for (int i = 0; i < WorldUtils.Pickups.Count; i++)
                {
                    var pickup = WorldUtils.Pickups[i].GetOrAddComponent<PickupController>();
                    // instead or relying in OnUpdate, let's just use the isHeld event that PickupController listens to
                    pickup.OnPickupHeld += () =>
                    {
                        if (pickup.CurrentHolder != null)
                        {
                            var player = pickup.CurrentHolder.GetPlayer();
                            if (player != null)
                            {
                                if(IsPickupBlockedUser(player.GetUserID()))
                                {
                                    Log.Debug($"Prevented {pickup.gameObject.name} from being used from Blacklisted user {pickup.CurrentHolder.GetDisplayName()}");
                                    DenyPickupOwnership(pickup);
                                }
                            }
                        }
                    };
                }
                HasPickupControllerBeenAdded = true;
                
            }

        }

        internal static void DenyPickupOwnership(PickupController pickup)
        {
            if (pickup != null)
            {
                OnlineEditor.TakeObjectOwnership(pickup.gameObject);
                if (!Settings_PickupProtector.RespawnPickupToDefaultPos)
                {
                    pickup.gameObject.SetPosition(pickup.gameObject.transform.position);
                    pickup.gameObject.SetRotation(pickup.gameObject.transform.rotation);
                }
                else
                {
                    if (pickup.RigidBodyController != null)
                    {
                        pickup.gameObject.RespawnPickup(false);
                    }
                }
            }
        }

        private static bool _HasSubscribed = false;
        private static bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnPlayerJoin += OnPlayerJoined;
                        //ClientEventActions.OnPlayerLeft += OnPlayerLeft;
                        ClientEventActions.OnOwnerShipTranferred += OnOwnerShipTransferred;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnPlayerJoin -= OnPlayerJoined;
                       // ClientEventActions.OnPlayerLeft -= OnPlayerLeft;
                        ClientEventActions.OnOwnerShipTranferred -= OnOwnerShipTransferred;
                    }
                }
                _HasSubscribed = value;
            }
        }

        internal static void RegisterPlayer(APIUser user)
        {
            if (user != null)
            {
                var entry = user.id;
                if (entry.IsNotNullOrEmptyOrWhiteSpace())
                {
                    try
                    {
                        if (!HasPickupControllerBeenAdded)
                        {
                            StartPickupBlockerSystem(); // Add everything only if we need to prevent trolls from accessing pickup interaction
                        }
                        if (!HasSubscribed)
                        {
                            HasSubscribed = true;
                        }
                    }
                    catch{}

                    user.GetPlayer().GetOrAddComponent<PickupBlockerTag>();
                    DeniedPickupUsersIds.Add(entry);

                }
            }
        }

        internal static void RemovePlayer(APIUser player)
        {
            var entry = player.id;
            if (entry.IsNotNullOrEmptyOrWhiteSpace())
            {
                if(DeniedPickupUsersIds.Contains(entry))
                {
                    player.GetPlayer()?.RemoveComponent<PickupBlockerTag>();
                    DeniedPickupUsersIds.Remove(entry);
                }
            }
        }

        private static void OnRoomLeft()
        {
            HasPickupControllerBeenAdded = false;
            DeniedPickupUsersIds.Clear();
            HasSubscribed = false;
        }

        internal static bool IsPickupBlockedUser(string id)
        {
            return DeniedPickupUsersIds.Contains(id);
        }


        private static void OnPlayerJoined(Player player)
        {
            var id = player.GetAPIUser().id;
            if (id != null)
            {
                if (IsPickupBlockedUser(id))
                {
                    player.GetOrAddComponent<PickupBlockerTag>();
                }
            }
        }



        private static void OnOwnerShipTransferred(PhotonView instance, int value)
        {
            if (GameInstances.CurrentRoom == null)
                return;
            var dict = GameInstances.CurrentRoom.field_Private_Dictionary_2_Int32_Player_0;
            if (instance.isPickup())
            {
                if (DeniedPickupUsersIds != null)
                {
                    if (DeniedPickupUsersIds.Count != 0)
                    {
                        if (dict != null)
                        {
                            if (dict.ContainsKey(value))
                            {
                                var newOwner = dict[value].field_Public_Player_0?.prop_APIUser_0;

                                if (newOwner != null)
                                {
                                    if (IsPickupBlockedUser(newOwner.id))
                                    {
                                        DenyPickupOwnership(instance.gameObject.GetOrAddComponent<PickupController>());

                                        Log.Debug($"Blocked User {newOwner.displayName} from Using Pickup {instance.gameObject.name}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static List<string> DeniedPickupUsersIds { get; set; } = new();


    }
}