
namespace AstroClient.PlayerList.Utilities
{
    using PickupBlockerSystem;
    using Entries;
    using xAstroBoy.Utility;
    using Photon.Pun;
    using System;

    internal class PlayerList_PickupOwnershipUpdater : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientActions.ClientEventActions.OnOwnerShipTranferred += OnOwnerShipTransferred;
        }


        private void OnOwnerShipTransferred(PhotonView instance, int PhotonID)
        {
            try
            {
                if (GameInstances.CurrentRoom == null) return;
                if (!instance.isPickup()) return;
                    string oldOwner = null;
                string newOwner = null;

                var dict = GameInstances.CurrentRoom.field_Private_Dictionary_2_Int32_Player_0;
                if (dict == null) return;
                
                
                // something is up with the  photon player constructor that makes me have to not use trygetvalue
                if (dict.ContainsKey(instance.field_Private_Int32_0))
                    oldOwner = dict[instance.field_Private_Int32_0].field_Public_Player_0?.prop_APIUser_0?.id;
                if (dict.ContainsKey(PhotonID))
                    newOwner = dict[PhotonID].field_Public_Player_0?.prop_APIUser_0?.id;
                for (var index = 0; index < EntryManager.playerLeftPairsEntries.Count; index++)
                {
                    PlayerLeftPairEntry entry = EntryManager.playerLeftPairsEntries[index];
                    if (entry == null) continue;
                    if (entry.playerEntry == null) continue;
                    if (entry.playerEntry.userId == oldOwner)
                    {
                        if (entry.playerEntry.OwnedObjects > 0)
                        {
                            entry.playerEntry.OwnedObjects -= 1;
                        }
                    }
                    else if (entry.playerEntry.userId == newOwner)
                    {
                        if (entry.playerEntry.OwnedObjects > 0)
                        {
                            entry.playerEntry.OwnedObjects += 1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }
    }
}