﻿using System.Collections.Concurrent;
using AstroClient.ClientActions;
using Il2CppSystem.Xml;
using Photon.Pun;
using Photon.Realtime;
using UnhollowerBaseLib.Attributes;
using VRC.SDKBase;

namespace AstroClient.AstroMonos
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using Components.Tools;
    using Components.UI.SingleTag;
    using Tools.Extensions;
    using VRC;
    using xAstroBoy.Utility;

    internal class PickupBlocker : AstroEvents
    {
        private static bool HasPickupControllerBeenAdded = false;

        private static void StartPickupBlockerSystem()
        {
            if (!HasPickupControllerBeenAdded)
            {
                for (int i = 0; i < WorldUtils.Pickups.Count; i++)
                {
                    WorldUtils.Pickups[i].GetOrAddComponent<PickupController>();
                }
                HasPickupControllerBeenAdded = true;
                
            }
            HasSubscribed = true;

        }
        private static bool _HasSubscribed = false;
        private static bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnPlayerJoin += OnPlayerJoined;
                        ClientEventActions.OnPlayerLeft += OnPlayerLeft;
                        ClientEventActions.OnOwnerShipTranferred += OnOwnerShipTransferred;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnPlayerJoin -= OnPlayerJoined;
                        ClientEventActions.OnPlayerLeft -= OnPlayerLeft;
                        ClientEventActions.OnOwnerShipTranferred -= OnOwnerShipTransferred;
                    }
                }
                _HasSubscribed = value;
            }
        }

        internal static void RegisterPlayer(Player player)
        {
            // TODO : Get Rid of PickupController dependency for PickupBlocker System

            // We might not need that anymore as We are testing the Owner detection system from PlayerList Hook.

            StartPickupBlockerSystem(); // Add everything only if we need to prevent trolls from accessing pickup interaction
            
            // For now let's leave it temporarily 

            var id = player.GetAPIUser().GetUserID();
            if (id != null && blockeduserids.ContainsKey(id) && !blockeduserids[id].Blocked)
            {
                Log.Debug($"Added Block for Player {player.GetDisplayName()}  from using Pickups.");
                blockeduserids[id].Blocked = true;
            }
        }

        internal static void RemovePlayer(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null && blockeduserids.ContainsKey(id) && blockeduserids[id].Blocked)
            {
                Log.Debug($"Removed Block for Player {player.GetDisplayName()}  from using Pickups.");
                blockeduserids[id].Blocked = false;
            }
        }

        private static void OnRoomLeft()
        {
            HasPickupControllerBeenAdded = false;
            blockeduserids.Clear();
            HasSubscribed = false;
        }

        internal static bool IsPickupBlockedUser(string UserID)
        {
            if (blockeduserids != null && blockeduserids.ContainsKey(UserID))
            {
                return blockeduserids[UserID].Blocked;
            }
            return false;
        }
        private static void OnPlayerJoined(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (!blockeduserids.ContainsKey(id))
                {
                    blockeduserids.Add(id, new PickupBlockerData(player));
                }
                else
                {
                    if (blockeduserids.ContainsKey(id))
                    {
                        blockeduserids[id].player = player;
                        if(blockeduserids[id].Blocked)
                        {
                            blockeduserids[id].SpawnTag();
                        }
                    }
                }
            }
        }

        private static void OnPlayerLeft(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null && blockeduserids.ContainsKey(id))
            {
                blockeduserids[id].player = null;
            }
        }

        internal static bool isPickup(PhotonView instance)
        {
            if(instance != null)
            {
                return instance.GetComponent<VRC_Pickup>() != null || instance.GetComponent<VRCSDK2.VRC_Pickup>() != null || instance.GetComponent<VRC.SDK3.Components.VRCPickup>() != null;
            }
            return false;
        }



        private static void OnOwnerShipTransferred(PhotonView instance, int value)
        {
            if (isPickup(instance))
            {
                if (GameInstances.CurrentRoom == null)
                    return;

                if (PickupBlocker.blockeduserids != null)
                {
                    if (PickupBlocker.blockeduserids.Count != 0)
                    {
                        if (GameInstances.CurrentRoom.field_Private_Dictionary_2_Int32_Player_0 != null)
                        {
                            if (GameInstances.CurrentRoom.field_Private_Dictionary_2_Int32_Player_0.ContainsKey(value))
                            {
                                var newOwner = GameInstances.CurrentRoom.field_Private_Dictionary_2_Int32_Player_0[value].field_Public_Player_0?.prop_APIUser_0;

                                if (newOwner != null)
                                {
                                    if (PickupBlocker.IsPickupBlockedUser(newOwner.id))
                                    {
                                        instance.gameObject.TakeOwnership();
                                        Log.Debug($"Blocked User {newOwner.displayName} from Using Pickup {instance.gameObject.name}");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static Dictionary<string, PickupBlockerData> blockeduserids = new Dictionary<string, PickupBlockerData>();

        internal class PickupBlockerData
        {
            
            internal Player player { get; set; }
            private SingleTag BlockedTag { get; set; }
            private bool _Blocked { get; set; }
            internal bool Blocked
            {
                get => _Blocked;
                set
                {
                    _Blocked = value;
                    if (value)
                    {
                        SpawnTag();
                    }
                    else
                    {
                        DestroyTag();
                    }
                }
            }

            internal void SpawnTag()
            {
                if (player != null)
                {
                    if (BlockedTag == null)
                    {
                        BlockedTag = player.AddSingleTag(Color.Orange, "Pickup Blocked");
                    }

                }
            }

            internal void DestroyTag()
            {
                if (BlockedTag != null)
                {
                    BlockedTag.DestroyMeLocal(true);
                }
            }

            internal PickupBlockerData(Player player, bool Blocked = false)
            {
                this.player = player;
                this.Blocked = Blocked;
            }
        }
    }
}