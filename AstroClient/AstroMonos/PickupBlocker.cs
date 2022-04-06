using System.Collections.Concurrent;
using AstroClient.AstroEventArgs;
using Il2CppSystem.Xml;
using Photon.Pun;
using Photon.Realtime;
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
                foreach (var item in WorldUtils.Pickups)
                {
                    item.GetOrAddComponent<PickupController>();
                }

                HasPickupControllerBeenAdded = true;
            }

        }

        internal static void RegisterPlayer(Player player)
        {
            // TODO : Get Rid of PickupController dependency for PickupBlocker System

            // We might not need that anymore as We are testing the Owner detection system from PlayerList Hook.

            StartPickupBlockerSystem(); // Add everything only if we need to prevent trolls from accessing pickup interaction
            
            // For now let's leave it temporarily 

            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (blockeduserids.ContainsKey(id))
                {
                    if (blockeduserids.ContainsKey(id))
                    {
                        if (!blockeduserids[id].Blocked)
                        {
                            Log.Debug($"Added Block for Player {player.GetDisplayName()}  from using Pickups.");
                            blockeduserids[id].Blocked = true;
                        }
                    }
                }
            }
        }

        internal static void RemovePlayer(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (blockeduserids.ContainsKey(id))
                {
                    if (blockeduserids.ContainsKey(id))
                    {
                        if (blockeduserids[id].Blocked)
                        {
                            Log.Debug($"Removed Block for Player {player.GetDisplayName()}  from using Pickups.");
                            blockeduserids[id].Blocked = false;
                        }
                    }
                }
            }
        }

        internal override void OnRoomLeft()
        {
            HasPickupControllerBeenAdded = false;
            blockeduserids.Clear();
        }

        internal static bool IsPickupBlockedUser(string UserID)
        {
            if(blockeduserids != null)
            {
                if(blockeduserids.ContainsKey(UserID))
                {
                    return blockeduserids[UserID].Blocked;
                }
            }
            return false;
        }

        internal override void OnPlayerJoined(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (!blockeduserids.ContainsKey(id))
                {
                    blockeduserids.TryAdd(id, new PickupBlockerData(player));
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

        internal override void OnPlayerLeft(Player player)
        {
            var id = player.GetAPIUser().GetUserID();
            if (id != null)
            {
                if (blockeduserids.ContainsKey(id))
                {
                    blockeduserids[id].player = null;
                }
            }
        }

        internal bool isPickup(PhotonView instance)
        {
            if(instance != null)
            {
                return instance.GetComponent<VRC_Pickup>() != null || instance.GetComponent<VRCSDK2.VRC_Pickup>() != null || instance.GetComponent<VRC.SDK3.Components.VRCPickup>() != null;
            }
            return false;
        }



        internal override void OnOwnerShipTransferred(PhotonView instance, int value)
        {
            if (isPickup(instance))
            {
                Room room = Player.prop_Player_0?.prop_PlayerNet_0?.field_Private_PhotonView_0?.prop_Player_0?.field_Private_Room_0;
                if (room == null)
                    return;

                if (PickupBlocker.blockeduserids != null)
                {
                    if (PickupBlocker.blockeduserids.Count != 0)
                    {
                        if (room.field_Private_Dictionary_2_Int32_Player_0 != null)
                        {
                            if (room.field_Private_Dictionary_2_Int32_Player_0.ContainsKey(value))
                            {
                                var photonplayer = room.field_Private_Dictionary_2_Int32_Player_0[value];
                                if (photonplayer != null)
                                {
                                    var player = photonplayer.field_Public_Player_0;
                                    if (player != null)
                                    {
                                        var apiuser = player.GetAPIUser();
                                        if (apiuser != null)
                                        {
                                            if (PickupBlocker.IsPickupBlockedUser(apiuser.id))
                                            {
                                                instance.gameObject.TakeOwnership();
                                                Log.Debug($"Blocked User {apiuser.displayName} from Using Pickup {instance.gameObject.name}");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static ConcurrentDictionary<string, PickupBlockerData> blockeduserids = new ConcurrentDictionary<string, PickupBlockerData>();

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