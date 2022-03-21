namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using AstroClient.Tools.UdonSearcher;
    using ClientAttributes;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using VRC.Udon;
    using WorldModifications.WorldHacks;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;

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
                    PlayerData = obj.RawItem;
                }
                else
                {
                    ModConsole.Error("Can't Find Player Data behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }

                if (PlayerData != null)
                {
                    var hitboxudon = UdonSearch.FindUdonEvent(obj.gameObject, "Player Hitbox", "_Damage");
                    if (hitboxudon != null)
                    {
                        HitBoxReader = hitboxudon.gameObject.GetOrAddComponent<PrisonEscape_HitboxReader>();
                    }
                }
            }
            else
            {
                Destroy(this);
            }
        }

        [HideFromIl2Cpp]
        private bool isNotPoolOrThisBehaviour(UdonBehaviour behaviour)
        {
            if (behaviour != null && behaviour != PlayerData.udonBehaviour)
            {
                if (behaviour.gameObject != PrisonEscape.Player_Object_Pool)
                {
                    return true;
                }
            }
            return false;
        }

        internal PrisonEscape_PlayerDataReader GetActualDataReader 
                {
            get
            {
                //if (!HitBoxReader.Root.active) return null; // do this to allow more accuracy and get the correct ones!

                if (isNotPoolOrThisBehaviour(__0_this_intnl_PlayerData))
                {
                    return __0_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__0_this_intnl_PlayerData))
                {
                    return __0_this_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__1_intnl_PlayerData))
                {
                    return __1_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__2_intnl_PlayerData))
                {
                    return __2_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__3_intnl_PlayerData))
                {
                    return __3_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }

                else if (isNotPoolOrThisBehaviour(__4_intnl_PlayerData))
                {
                    return __4_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__5_intnl_PlayerData))
                {
                    return __5_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__1_intnl_SystemObject))
                {
                    return __1_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__10_intnl_SystemObject))
                {
                    return __10_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__12_intnl_SystemObject))
                {
                    return __12_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__19_intnl_SystemObject))
                {
                    return __19_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }

                else if (isNotPoolOrThisBehaviour(__22_intnl_SystemObject))
                {
                    return __22_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }

                else if (isNotPoolOrThisBehaviour(__23_intnl_SystemObject))
                {
                    return __23_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__29_intnl_SystemObject))
                {
                    return __29_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }

                else if (isNotPoolOrThisBehaviour(__30_intnl_SystemObject))
                {
                    return __30_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PlayerDataReader>();
                }



                return this;
            }
        }

        



        internal bool isLocal
        {
            get

            {
                return GameInstances.CurrentPlayer.GetDisplayName().Equals(playerName);
            }
        }


        internal bool EnableHitboxDebugVisual
        {
            [HideFromIl2Cpp]
            get
            {
                return HitBoxReader.EnableDebugVisual;
            }
            [HideFromIl2Cpp]
            set
            {
                HitBoxReader.EnableDebugVisual = value;
            }
        }
        
        internal RawUdonBehaviour PlayerData {[HideFromIl2Cpp] get; [HideFromIl2Cpp] set;} =  null;


        #region  Generated Getters

        
        internal int? __18_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__18_const_intnl_SystemInt32");
                return null;
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
        }


        internal uint? __43_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__43_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __33_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__33_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __20_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__20_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __23_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__23_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject __1_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_GameObject(PlayerData, "__1_intnl_UnityEngineGameObject");
                return null;
            }
        }


        internal uint? __21_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__21_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __52_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__52_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __3_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__3_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __6_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__6_const_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __0_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__0_intnl_PlayerData");
                return null;
            }
        }


        internal uint? __3_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__3_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __26_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__26_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_const_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__0_const_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __41_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__41_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Transform __1_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Transform(PlayerData, "__1_intnl_UnityEngineTransform");
                return null;
            }
        }


        internal int? __1_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__1_const_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __0_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__0_intnl_PlayerObjectPool");
                return null;
            }
        }


        internal int? __1_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__1_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __16_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__16_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal UnityEngine.Transform __2_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Transform(PlayerData, "__2_intnl_SystemObject");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __0_const_intnl_VRCUdonCommonEnumsEventTiming With Type VRC.Udon.Common.Enums.EventTiming



        internal uint? __35_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__35_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __39_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__39_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? doublePoints
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "doublePoints");
                return null;
            }
        }


        internal string __0_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__0_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __56_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__56_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __42_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__42_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __0_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__0_const_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __29_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__29_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __1_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__1_intnl_SystemSingle");
                return null;
            }
        }


        internal int? __7_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__7_const_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __9_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__9_intnl_SystemObject");
                return null;
            }
        }


        internal bool? __5_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__5_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? tagHeightScalar
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "tagHeightScalar");
                return null;
            }
        }


        internal uint? __46_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__46_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __35_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__35_const_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour hitbox
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "hitbox");
                return null;
            }
        }


        internal uint? __10_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__10_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __11_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__11_const_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __0_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__0_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __2_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__2_intnl_PlayerObjectPool");
                return null;
            }
        }


        internal bool? __15_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__15_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __24_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__24_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __34_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__34_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __28_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__28_const_intnl_SystemString");
                return null;
            }
        }


        internal UnityEngine.Transform __2_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Transform(PlayerData, "__2_intnl_UnityEngineTransform");
                return null;
            }
        }


        internal uint? __28_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__28_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? maxHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "maxHealth");
                return null;
            }
        }


        internal string __6_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__6_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __21_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__21_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? cachedIsWanted
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "cachedIsWanted");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __5_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__5_intnl_PlayerObjectPool");
                return null;
            }
        }


        internal uint? __5_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__5_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __13_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__13_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __50_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__50_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __1_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__1_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __4_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__4_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __64_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__64_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __40_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__40_const_intnl_SystemString");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __23_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__23_intnl_SystemObject");
                return null;
            }
        }


        internal string __29_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__29_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __1_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__1_const_intnl_SystemSingle");
                return null;
            }
        }


        internal uint? __23_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__23_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal float? __5_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__5_intnl_SystemSingle");
                return null;
            }
        }


        internal int? __25_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__25_const_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __40_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__40_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __2_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__2_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __16_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__16_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? goldGuns
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "goldGuns");
                return null;
            }
        }


        internal string __14_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__14_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __1_mp_hp_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__1_mp_hp_Int32");
                return null;
            }
        }


        internal bool? __7_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__7_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __22_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__22_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __38_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__38_const_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __7_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__7_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __37_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__37_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __7_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__7_const_intnl_SystemString");
                return null;
            }
        }


        internal string __15_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__15_const_intnl_SystemString");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __4_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__4_intnl_PlayerObjectPool");
                return null;
            }
        }


        internal bool? __0_mp_playing_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__0_mp_playing_Boolean");
                return null;
            }
        }


        internal int? __5_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__5_const_intnl_SystemInt32");
                return null;
            }
        }


        internal long? __refl_const_intnl_udonTypeID
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int64(PlayerData, "__refl_const_intnl_udonTypeID");
                return null;
            }
        }


        internal bool? __4_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__4_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __16_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__16_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __19_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__19_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __refl_const_intnl_udonTypeName
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__refl_const_intnl_udonTypeName");
                return null;
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
        }


        internal float? healthRegenDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "healthRegenDelay");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __0_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__0_intnl_SystemObject");
                return null;
            }
        }


        internal bool? __1_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__1_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __38_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__38_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __12_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__12_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __34_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__34_const_intnl_SystemString");
                return null;
            }
        }


        internal string __17_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__17_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __28_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__28_const_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __17_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__17_const_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __26_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__26_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __4_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__4_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __28_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__28_intnl_SystemObject");
                return null;
            }
        }


        internal uint? __31_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__31_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __68_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__68_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __20_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__20_const_intnl_SystemString");
                return null;
            }
        }


        internal string __35_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__35_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __11_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__11_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __2_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__2_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __8_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__8_const_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __52_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__52_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __4_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__4_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __30_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__30_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_mp_wanted_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__0_mp_wanted_Boolean");
                return null;
            }
        }


        internal bool? __54_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__54_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __21_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__21_const_intnl_SystemString");
                return null;
            }
        }


        internal string __26_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__26_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __42_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__42_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __71_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__71_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __31_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__31_const_intnl_SystemInt32");
                return null;
            }
        }


        internal UnityEngine.Transform __4_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Transform(PlayerData, "__4_intnl_SystemObject");
                return null;
            }
        }


        internal uint? __9_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__9_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __60_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__60_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __37_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__37_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __20_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__20_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __37_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__37_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __2_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__2_intnl_SystemSingle");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __0_this_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__0_this_intnl_PlayerData");
                return null;
            }
        }


        internal string __5_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__5_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __3_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__3_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __12_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__12_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __10_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__10_intnl_SystemObject");
                return null;
            }
        }


        internal uint? __6_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__6_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __2_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__2_intnl_PlayerData");
                return null;
            }
        }
        internal VRC.Udon.UdonBehaviour __3_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__3_intnl_PlayerData");
                return null;
            }
        }


        internal bool? __67_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__67_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __23_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__23_const_intnl_SystemString");
                return null;
            }
        }


        internal UnityEngine.Vector3? __5_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Vector3(PlayerData, "__5_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal int? __14_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__14_const_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __9_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__9_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __44_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__44_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __29_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__29_intnl_SystemObject");
                return null;
            }
        }


        internal bool? __72_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__72_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __19_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__19_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __0_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__0_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __34_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__34_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal UnityEngine.Vector3? __4_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Vector3(PlayerData, "__4_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal float? __9_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__9_intnl_SystemSingle");
                return null;
            }
        }


        internal int? __21_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__21_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? cachedIsDead
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "cachedIsDead");
                return null;
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
        }


        internal string __12_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__12_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __38_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__38_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __1_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__1_intnl_PlayerData");
                return null;
            }
        }


        internal UnityEngine.GameObject __0_this_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_GameObject(PlayerData, "__0_this_intnl_UnityEngineGameObject");
                return null;
            }
        }


        internal float? __3_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__3_intnl_SystemObject");
                return null;
            }
        }


        internal UnityEngine.GameObject __0_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_GameObject(PlayerData, "__0_intnl_UnityEngineGameObject");
                return null;
            }
        }


        internal string __8_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__8_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __6_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__6_intnl_SystemSingle");
                return null;
            }
        }


        internal uint? __33_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__33_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __58_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__58_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __15_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__15_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __4_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__4_intnl_PlayerData");
                return null;
            }
        }


        internal int? __36_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__36_const_intnl_SystemInt32");
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


        internal VRC.Udon.UdonBehaviour __11_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__11_intnl_SystemObject");
                return null;
            }
        }


        internal uint? __19_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__19_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __12_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__12_const_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __22_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__22_intnl_SystemObject");
                return null;
            }
        }


        internal string __32_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__32_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __0_tagHeight_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__0_tagHeight_Single");
                return null;
            }
        }


        internal bool? __35_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__35_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __8_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__8_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __37_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__37_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __50_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__50_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __0_mp_hp_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__0_mp_hp_Int32");
                return null;
            }
        }


        internal uint? __55_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__55_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __22_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__22_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __24_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__24_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __9_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__9_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __13_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__13_const_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __0_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__0_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __0_intnl_returnTarget_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__0_intnl_returnTarget_UInt32");
                return null;
            }
        }


        internal bool? __48_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__48_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __59_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__59_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __45_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__45_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __65_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__65_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __0_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__0_intnl_SystemString");
                return null;
            }
        }


        internal bool? __33_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__33_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __57_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__57_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __26_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__26_const_intnl_SystemInt32");
                return null;
            }
        }


        internal UnityEngine.GameObject __3_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_GameObject(PlayerData, "__3_intnl_UnityEngineGameObject");
                return null;
            }
        }


        internal uint? __49_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__49_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __0_const_intnl_SystemUInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__0_const_intnl_SystemUInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour scorecard
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "scorecard");
                return null;
            }
        }


        internal int? cachedHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "cachedHealth");
                return null;
            }
        }


        internal bool? __9_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__9_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __36_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__36_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __63_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__63_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __36_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__36_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __0_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__0_intnl_SystemSingle");
                return null;
            }
        }


        internal int? __27_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__27_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __40_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__40_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Camera spectateCamera
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Camera(PlayerData, "spectateCamera");
                return null;
            }
        }


        internal string __18_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__18_const_intnl_SystemString");
                return null;
            }
        }


        internal float? lastDamageTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "lastDamageTime");
                return null;
            }
        }


        internal bool? killedByLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "killedByLocal");
                return null;
            }
        }


        internal bool? __66_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__66_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __0_mp_damage_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__0_mp_damage_Int32");
                return null;
            }
        }


        internal bool? isPlaying
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "isPlaying");
                return null;
            }
        }


        internal UnityEngine.Vector3? __3_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Vector3(PlayerData, "__3_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal bool? __47_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__47_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __34_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__34_const_intnl_SystemInt32");
                return null;
            }
        }


        internal UnityEngine.Transform __4_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Transform(PlayerData, "__4_intnl_UnityEngineTransform");
                return null;
            }
        }


        internal int? __10_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__10_const_intnl_SystemInt32");
                return null;
            }
        }


        internal string __19_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__19_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __17_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__17_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __30_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__30_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __39_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__39_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __28_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__28_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __6_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__6_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __4_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__4_intnl_SystemSingle");
                return null;
            }
        }



        internal VRC.Udon.UdonBehaviour __12_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__12_intnl_SystemObject");
                return null;
            }
        }

        internal VRC.Udon.UdonBehaviour __19_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__19_intnl_SystemObject");
                return null;
            }
        }

        internal string __24_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__24_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __69_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__69_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __57_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__57_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __38_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__38_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __14_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__14_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? cachedIsPlaying
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "cachedIsPlaying");
                return null;
            }
        }


        internal int? __24_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__24_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? cachedHasKeycard
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "cachedHasKeycard");
                return null;
            }
        }


        internal uint? __47_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__47_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __3_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__3_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __31_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__31_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __55_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__55_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __25_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__25_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __29_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__29_const_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __11_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__11_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __8_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__8_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __20_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__20_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Vector3? __2_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Vector3(PlayerData, "__2_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal string __39_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__39_const_intnl_SystemString");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __1_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__1_intnl_SystemObject");
                return null;
            }
        }


        internal bool? __0_mp_enabled_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__0_mp_enabled_Boolean");
                return null;
            }
        }


        internal uint? __25_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__25_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __32_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__32_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __61_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__61_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __29_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__29_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal UnityEngine.Vector3? __1_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Vector3(PlayerData, "__1_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal bool? __53_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__53_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __27_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__27_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_mp_dead_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__0_mp_dead_Boolean");
                return null;
            }
        }


        internal uint? __51_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__51_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __2_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__2_const_intnl_SystemInt32");
                return null;
            }
        }


        internal float? __3_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__3_intnl_SystemSingle");
                return null;
            }
        }


        internal int? __33_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__33_const_intnl_SystemInt32");
                return null;
            }
        }


        internal string __27_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__27_const_intnl_SystemString");
                return null;
            }
        }


        internal UnityEngine.Vector3? __0_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Vector3(PlayerData, "__0_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal string __10_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__10_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __32_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__32_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __30_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__30_intnl_SystemObject");
                return null;
            }
        }


        internal bool? __56_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__56_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __41_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__41_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __45_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__45_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __1_const_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__1_const_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __22_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__22_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __62_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__62_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __11_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__11_const_intnl_SystemString");
                return null;
            }
        }


        internal string __16_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__16_const_intnl_SystemString");
                return null;
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
        }


        internal uint? __32_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__32_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __43_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__43_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __15_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__15_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __18_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__18_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_mp_t_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__0_mp_t_Boolean");
                return null;
            }
        }


        internal bool? __2_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__2_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __10_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__10_intnl_SystemSingle");
                return null;
            }
        }


        internal int? __1_mp_damage_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__1_mp_damage_Int32");
                return null;
            }
        }


        internal uint? __14_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__14_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __23_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__23_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? joinedRound
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "joinedRound");
                return null;
            }
        }


        internal int? __3_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__3_const_intnl_SystemInt32");
                return null;
            }
        }


        internal float? __7_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__7_intnl_SystemSingle");
                return null;
            }
        }


        internal float? tagHeightMin
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "tagHeightMin");
                return null;
            }
        }


        internal VRC.Udon.Common.Interfaces.NetworkEventTarget? __0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_NetworkEventTarget(PlayerData, "__0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget");
                return null;
            }
        }


        internal bool? __59_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__59_intnl_SystemBoolean");
                return null;
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
        }


        internal uint? __18_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__18_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __46_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__46_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __30_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__30_const_intnl_SystemString");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour gameManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "gameManager");
                return null;
            }
        }


        internal string __13_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__13_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __0_mp_guard_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__0_mp_guard_Boolean");
                return null;
            }
        }


        internal UnityEngine.Vector3? deathLoc
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Vector3(PlayerData, "deathLoc");
                return null;
            }
        }


        internal int? __30_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__30_const_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __54_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__54_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __13_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__13_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal UnityEngine.GameObject __2_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_GameObject(PlayerData, "__2_intnl_UnityEngineGameObject");
                return null;
            }
        }


        internal bool? __10_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__10_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __2_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__2_const_intnl_SystemString");
                return null;
            }
        }


        internal string __31_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__31_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __27_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__27_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __36_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__36_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __58_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__58_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __44_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__44_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __5_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__5_intnl_PlayerData");
                return null;
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


        internal bool? __51_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__51_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __0_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Int32(PlayerData, "__0_const_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __1_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "__1_intnl_PlayerObjectPool");
                return null;
            }
        }


        internal uint? __1_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__1_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __25_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__25_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __48_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__48_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __22_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__22_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __8_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_single(PlayerData, "__8_intnl_SystemSingle");
                return null;
            }
        }


        internal string __0_mp_newName_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_string(PlayerData, "__0_mp_newName_String");
                return null;
            }
        }


        internal bool? __70_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__70_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour teamTag
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(PlayerData, "teamTag");
                return null;
            }
        }


        internal bool? __17_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__17_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __49_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "__49_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __53_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_UInt32(PlayerData, "__53_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? hasKeycard
        {
            [HideFromIl2Cpp]
            get
            {
                if (PlayerData != null) return UdonHeapParser.Udon_Parse_Boolean(PlayerData, "hasKeycard");
                return null;
            }
        }





        #endregion


        internal static PrisonEscape_HitboxReader HitBoxReader   { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}