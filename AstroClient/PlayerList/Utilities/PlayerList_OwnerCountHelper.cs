using System;
using AstroClient.ClientActions;
using AstroClient.PickupBlockerSystem;
using AstroClient.Tools.ObjectEditor.Online;
using AstroClient.Tools.World;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using Photon.Pun;
using UnhollowerBaseLib.Attributes;
using VRC;
using VRC.Core;
using VRC.SDKBase;

namespace AstroClient.PlayerList.Utilities
{
    using ClientResources.Loaders;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using xAstroBoy;

    internal class PlayerList_OwnerCountHelper : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnOwnerShipTranferred += OnOwnerShipTransferred;
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnPlayerJoin += OnPlayerJoin;
            ClientEventActions.OnPlayerLeft += OnPlayerLeft;
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        private void OnWorldReveal(string id, string Name, System.Collections.Generic.List<string> tags, string AssetURL, string AuthorName)
        {
            // This will focus maily on self player, as there's a bug in the API that doesn't return the owner of the various pickups.
            // bugs happens if dict says 1 , but pickups photonviews are set to 0.
            CorrectOwnedPickupsForSelf();
        }

        private static void CorrectOwnedPickupsForSelf()
        {
            if (GameInstances.CurrentRoom == null)
                return;
            var dict = GameInstances.CurrentRoom.field_Private_Dictionary_2_Int32_Player_0;
            bool isPlayerAlone = dict.count == 1;
            if (isPlayerAlone)
            {
                SetValueForUser(GameInstances.CurrentPlayer.GetUserID(), WorldUtils_Old.Get_Pickups().Count);
                return;
            }
            
            //int currentowned = 0;
            //var pickups = WorldUtils.Pickups;
            //for (var index = 0; index < pickups.Count; index++)
            //{
            //    var item = pickups[index];
            //    var photonview = item.GetComponent<PhotonView>();
            //    if (photonview != null)
            //    {
            //        var AssignedPhotonID = photonview.field_Private_Int32_0;
            //        if (AssignedPhotonID == 0)
            //        {

            //            currentowned++;
            //        }
            //        else
            //        {
            //            if (dict.ContainsKey(AssignedPhotonID))
            //            {
            //                var CurrentOwner = dict[AssignedPhotonID].GetVRCPlayer()?.GetAPIUser();
            //                if (CurrentOwner != null)
            //                {
            //                    if (CurrentOwner.IsSelf)
            //                    {

            //                    }
            //                }
            //            }

            //        }
            //    }
            //}

            //SetValueForUser(GameInstances.CurrentPlayer.GetUserID(), currentowned);

        }

        private void OnPlayerLeft(Player player)
        {
            if (OwnedObjectCounts.ContainsKey(player.GetUserID()))
            {
                OwnedObjectCounts.Remove(player.GetUserID());
            }
        }

        private void OnPlayerJoin(Player player)
        {
            if (!OwnedObjectCounts.ContainsKey(player.GetUserID()))
            {
                OwnedObjectCounts.Add(player.GetUserID(), 0);
            }
        }


        
        private void OnRoomLeft()
        {
            OwnedObjectCounts.Clear(); 
        }

        internal static string GetOwnedObjectCount(APIUser user)
        {
            if(user != null)
            {
                if (OwnedObjectCounts.ContainsKey(user.GetUserID()))
                {
                    return OwnedObjectCounts[user.GetUserID()].ToString();
                }
            }
            return "Unknown";
        }


        private static void SetValueForUser(string userid, int amount)
        {
            if (!userid.IsNullOrEmptyOrWhiteSpace())
            {
                if (OwnedObjectCounts.ContainsKey(userid))
                {
                    OwnedObjectCounts[userid] = Mathf.Clamp(amount, 0, int.MaxValue);
                }
                else
                {
                    OwnedObjectCounts.Add(userid, Mathf.Clamp(amount, 0, int.MaxValue));
                }
            }
        }


        private static void IncreaseForUser(string userid)
        {
            if (!userid.IsNullOrEmptyOrWhiteSpace())
            {
                if (OwnedObjectCounts.ContainsKey(userid))
                {
                    OwnedObjectCounts[userid]++;
                }
                else
                {
                    OwnedObjectCounts.Add(userid, 1);
                }
            }
        }

        private static void DecreaseForUser(string userid)
        {
            if (!userid.IsNullOrEmptyOrWhiteSpace())
            {
                if (OwnedObjectCounts.ContainsKey(userid))
                {
                    var currentvalue = OwnedObjectCounts[userid];
                    OwnedObjectCounts[userid] = Mathf.Clamp(currentvalue - 1, 0, int.MaxValue);;
                }
                else
                {
                    OwnedObjectCounts.Add(userid, Mathf.Clamp(0, 0, int.MaxValue));
                }
            }
        }

        private void OnOwnerShipTransferred(PhotonView instance, int PhotonID)
        {
            try
            {
                if (GameInstances.CurrentRoom == null)
                    return;

                if (!instance.isPickup()) return;

                // something is up with the  photon player constructor that makes me have to not use trygetvalue
                var dict = GameInstances.CurrentRoom.field_Private_Dictionary_2_Int32_Player_0;
                var oldownerid = instance.field_Private_Int32_0;
                if (dict.ContainsKey(oldownerid))
                {
                    var oldOwner = dict[oldownerid].GetVRCPlayer()?.GetAPIUser()?.GetUserID();
                    if (!oldOwner.IsNullOrEmptyOrWhiteSpace())
                    {
                        DecreaseForUser(oldOwner);
                    }
                }
                if (dict.ContainsKey(PhotonID))
                {
                    var newOwner = dict[PhotonID].GetVRCPlayer()?.GetAPIUser()?.GetUserID();
                    if (!newOwner.IsNullOrEmptyOrWhiteSpace())
                    {
                        IncreaseForUser(newOwner);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }
        
        

        private static Dictionary<string, int> OwnedObjectCounts { get; set; } = new();
    }
}
