namespace AstroClient.PlayerList.Entries
{
    using System;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class PlayerLeftPairEntry : EntryBase
    {
        public PlayerLeftPairEntry(IntPtr obj0) : base(obj0) { }

        [HideFromIl2Cpp]
        public override string Name => "PlayerLeftPairEntry";

        private PlayerEntry _playerEntry;
        [HideFromIl2Cpp]
        public PlayerEntry playerEntry
        {
            get => _playerEntry;
            set
            {
                EntryManager.idToEntryTable[value.userId] = this;
                _playerEntry = value;
                _playerEntry.transform.SetParent(transform);
                value.transform.localPosition.SetZ(0);
                value.playerLeftPairEntry = this;
                
            }
        }

        private LeftSidePlayerEntry _leftSidePlayerEntry;
        [HideFromIl2Cpp]
        public LeftSidePlayerEntry leftSidePlayerEntry
        {
            get => _leftSidePlayerEntry;
            set
            {
                _leftSidePlayerEntry = value;
                _leftSidePlayerEntry.transform.SetParent(transform);
            }
        }

        [HideFromIl2Cpp]
        public override void Init(object[] parameters = null)
        {
            leftSidePlayerEntry = (LeftSidePlayerEntry)parameters[0];
            playerEntry = (PlayerEntry)parameters[1];
        }

        public static void SwapPlayerEntries(PlayerLeftPairEntry lEntry, PlayerLeftPairEntry rEntry)
        {
            
            
            PlayerEntry temp = lEntry._playerEntry;
            lEntry.playerEntry = rEntry._playerEntry;

            rEntry.playerEntry = temp;
            

            
        }

        public override void Remove()
        {
            //Log.Debug("PLPE: Removing " + _playerEntry.apiUser.displayName);
            /*try
            {
                if (_playerEntry.player != null)
                {
                    Log.Debug("PLAYER MAY STILL EXIST! Aborting.");
                    //return;
                }
                else
                {
                    Log.Debug("Player is probably gone. Removing.");
                }
            }
            catch
            {
                Log.Debug("Player is probably gone. Removing.");
            }*/
            EntryManager.playerLeftPairsEntries.Remove(this);
            EntryManager.idToEntryTable.Remove(playerEntry.userId);
            EntryManager.playerEntries.Remove(_playerEntry);
            EntryManager.entries.Remove(_playerEntry);
            EntryManager.entries.Remove(_leftSidePlayerEntry);
            base.Remove();
        }
    }
}
