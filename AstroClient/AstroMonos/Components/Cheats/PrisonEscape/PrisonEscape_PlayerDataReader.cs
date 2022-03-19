namespace AstroClient.AstroMonos.Components.Cheats.Worlds.UdonTycoon
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using AstroClient.Tools.UdonSearcher;
    using ClientAttributes;
    using CustomClasses;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using Spoofer;
    using UnhollowerBaseLib.Attributes;
    using VRC;
    using VRC.SDKBase;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;

    [RegisterComponent]
    public class PrisonEscape_PlayerDataReader : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_PlayerDataReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PrisonEscape))
            {
                var obj = gameObject.FindUdonEvent("_SetWantedSynced");
                if (obj != null)
                {
                    PlayerData = obj.UdonBehaviour.ToRawUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find Player Data behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }

                if (PlayerData != null)
                {
                    DataHitBox = UdonSearch.FindUdonEvent(obj.gameObject, "Player Hitbox", "_Damage")?.RawItem;
                    if (DataHitBox == null)
                    {
                        ModConsole.Error("Can't Find Player Hitbox behaviour, Unable to Add Reader Component, did the author update the world?");
                        Destroy(this);
                    }
                }
            }
            else
            {
                Destroy(this);
            }
        }

        internal bool? isWanted
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "isWanted");

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if(value.HasValue)
                if (PlayerData != null) UdonHeapEditor.PatchHeap(PlayerData, "isWanted", value.Value);
            }
        }


        internal int? health
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "health");

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                    if (PlayerData != null) UdonHeapEditor.PatchHeap(PlayerData, "health", value.Value);
            }
        }
        internal float? healthRegenDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "healthRegenDelay");

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                    if (PlayerData != null) UdonHeapEditor.PatchHeap(PlayerData, "healthRegenDelay", value.Value);
            }
        }
        internal int? healthRegenAmt
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "healthRegenAmt");

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                    if (PlayerData != null) UdonHeapEditor.PatchHeap(PlayerData, "healthRegenAmt", value.Value);
            }
        }

        internal bool? isDead
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "isDead");

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                    if (PlayerData != null) UdonHeapEditor.PatchHeap(PlayerData, "isDead", value.Value);
            }
        }

        internal bool? isGuard
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "isGuard");

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                    if (PlayerData != null) UdonHeapEditor.PatchHeap(PlayerData, "isGuard", value.Value);
            }
        }


        internal string playerName
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "playerName");

                return null;
            }
        }

        internal string cachedPlayerName
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "cachedPlayerName");

                return null;
            }
        }


        internal VRCPlayerApi RemotePlayer
        {
            get
            {
                if (DataHitBox != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(DataHitBox, "__1_intnl_VRCSDKBaseVRCPlayerApi");
                return null;
            }
        }
        internal VRCPlayerApi LocalPlayer
        {
            get
            {
                if (DataHitBox != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(DataHitBox, "__0_intnl_VRCSDKBaseVRCPlayerApi");
                return null;
            }
        }

        internal string Assigned_PlayerName
        {
            get
            {
                if (RemotePlayer != null)
                {
                    return RemotePlayer.displayName;
                }
                else
                {
                    return LocalPlayer.displayName;
                }
                return null;
            }
        }


        internal bool isLocal
        {
            get
            {

                if (RemotePlayer == null && LocalPlayer != null)
                {
                    return LocalPlayer.isLocal;
                }
                return false;
            }
        }




        internal static RawUdonBehaviour PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal static RawUdonBehaviour DataHitBox { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
    }
}