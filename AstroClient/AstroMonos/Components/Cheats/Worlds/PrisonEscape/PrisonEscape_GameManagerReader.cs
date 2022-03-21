namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscape
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class PrisonEscape_GameManagerReader : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_GameManagerReader(IntPtr ptr) : base(ptr)
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
                var obj = gameObject.FindUdonEvent("_AbortGame");
                if (obj != null)
                {
                    GameData = obj.UdonBehaviour.ToRawUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find Player Data behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }

            }
            else
            {
                Destroy(this);
            }
        }


        
        internal RawUdonBehaviour GameData {[HideFromIl2Cpp] get; [HideFromIl2Cpp] set;} =  null;

        internal int? __35_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__35_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __43_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__43_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? updatedTeams
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "updatedTeams");
                return null;
            }
        }


        internal string __33_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__33_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __0_newTimeLimit_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_newTimeLimit_Int32");
                return null;
            }
        }


        internal bool? __23_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__23_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __0_guards_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_guards_Int32");
                return null;
            }
        }


        internal bool? __155_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__155_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __32_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__32_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __180_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__180_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __77_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__77_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __48_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__48_const_intnl_SystemString");
                return null;
            }
        }


        internal long? __7_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__7_intnl_SystemInt64");
                return null;
            }
        }


        internal int? __15_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__15_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __21_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__21_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __12_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__12_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __181_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__181_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __52_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__52_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __3_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__3_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __6_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__6_const_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __3_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__3_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal UnityEngine.Transform[] guardSpawns
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Transform_Array(GameData, "guardSpawns");
                return null;
            }
        }


        internal bool? __26_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__26_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_const_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__0_const_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Quaternion? __1_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Quaternion(GameData, "__1_intnl_UnityEngineQuaternion");
                return null;
            }
        }


        internal bool? __41_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__41_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __166_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__166_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __118_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__118_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __95_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__95_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __1_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__1_const_intnl_SystemInt32");
                return null;
            }
        }


        internal string __49_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__49_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __1_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__1_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour scoreboardDisplay
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "scoreboardDisplay");
                return null;
            }
        }


        internal uint? __16_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__16_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal UnityEngine.GameObject versionErrorPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "versionErrorPanel");
                return null;
            }
        }


        internal int? __1_prisoners_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__1_prisoners_Int32");
                return null;
            }
        }


        internal string __72_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__72_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __119_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__119_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __15_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__15_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __148_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__148_intnl_SystemBoolean");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __0_const_intnl_VRCUdonCommonEnumsEventTiming With Type VRC.Udon.Common.Enums.EventTiming



        internal int? __1_i_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__1_i_Int32");
                return null;
            }
        }


        internal int? __0_i_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_i_Int32");
                return null;
            }
        }


        internal int? __2_i_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__2_i_Int32");
                return null;
            }
        }


        internal bool? __197_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__197_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __160_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__160_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __42_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__42_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour itemControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "itemControl");
                return null;
            }
        }


        internal uint? __35_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__35_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? gameStartDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "gameStartDelay");
                return null;
            }
        }


        internal bool? __93_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__93_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __149_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__149_intnl_SystemBoolean");
                return null;
            }
        }


        internal long? __8_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__8_intnl_SystemInt64");
                return null;
            }
        }


        internal bool? __161_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__161_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __39_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__39_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour desktopInteract
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "desktopInteract");
                return null;
            }
        }


        internal string __0_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__0_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __1_mp_lastAlive_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__1_mp_lastAlive_Boolean");
                return null;
            }
        }


        internal UnityEngine.GameObject prisRatioText
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "prisRatioText");
                return null;
            }
        }


        internal float? __21_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__21_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __42_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__42_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __0_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__0_const_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __29_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__29_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __1_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__1_intnl_SystemSingle");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour playerTracker
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "playerTracker");
                return null;
            }
        }


        internal bool? __174_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__174_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __96_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__96_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __7_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__7_const_intnl_SystemInt32");
                return null;
            }
        }


        internal UnityEngine.UI.Slider timeLimitSlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UnityEngine_UI_Slider(GameData, "timeLimitSlider");
                return null;
            }
        }


        internal bool? __173_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__173_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __5_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__5_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __46_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__46_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __85_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__85_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject winSubtitle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "winSubtitle");
                return null;
            }
        }


        internal bool? __156_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__156_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __175_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__175_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __10_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__10_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? updatingTimeRemaining
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "updatingTimeRemaining");
                return null;
            }
        }


        internal int? __11_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__11_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __104_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__104_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? syncedTimeRemaining
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "syncedTimeRemaining");
                return null;
            }
        }


        internal int? __5_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__5_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __0_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__0_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __103_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__103_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __15_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__15_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.SDKBase.VRCPlayerApi __1_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(GameData, "__1_intnl_VRCSDKBaseVRCPlayerApi");
                return null;
            }
        }


        internal VRC.SDKBase.VRCPlayerApi __5_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(GameData, "__5_intnl_VRCSDKBaseVRCPlayerApi");
                return null;
            }
        }


        internal uint? __24_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__24_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __182_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__182_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_mp_lastAlive_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__0_mp_lastAlive_Boolean");
                return null;
            }
        }


        internal bool? __105_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__105_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __34_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__34_intnl_SystemBoolean");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __2_const_intnl_SystemType With Type System.RuntimeType



        internal string __28_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__28_const_intnl_SystemString");
                return null;
            }
        }


        internal string __58_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__58_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __83_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__83_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __150_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__150_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __28_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__28_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __6_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__6_const_intnl_SystemString");
                return null;
            }
        }


        internal UnityEngine.GameObject joinErrorPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "joinErrorPanel");
                return null;
            }
        }


        internal bool? __21_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__21_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __138_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__138_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __201_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__201_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __0_prisCount_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_prisCount_Int32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour sceneControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "sceneControl");
                return null;
            }
        }


        internal bool? __75_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__75_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __5_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__5_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __13_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__13_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __50_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__50_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __151_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__151_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __1_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__1_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __4_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__4_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? gameStarted
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "gameStarted");
                return null;
            }
        }


        internal bool? __64_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__64_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __40_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__40_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __139_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__139_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __99_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__99_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __38_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__38_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? versionError
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "versionError");
                return null;
            }
        }


        internal bool? __86_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__86_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __29_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__29_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __23_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__23_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __59_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__59_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __5_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__5_intnl_SystemSingle");
                return null;
            }
        }


        internal string __84_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__84_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __40_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__40_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __2_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__2_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __18_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__18_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __16_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__16_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __73_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__73_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __162_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__162_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __14_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__14_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __1_guardCount_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__1_guardCount_Int32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __0_this_intnl_GameManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "__0_this_intnl_GameManager");
                return null;
            }
        }


        internal float? __19_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__19_intnl_SystemSingle");
                return null;
            }
        }


        internal string __41_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__41_const_intnl_SystemString");
                return null;
            }
        }


        internal string __46_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__46_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __7_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__7_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __20_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__20_intnl_SystemInt32");
                return null;
            }
        }


        internal long? __1_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__1_intnl_SystemInt64");
                return null;
            }
        }


        internal string __85_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__85_const_intnl_SystemString");
                return null;
            }
        }


        internal string __64_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__64_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __22_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__22_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __7_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__7_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __76_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__76_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __194_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__194_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Transform[] respawnPoints
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Transform_Array(GameData, "respawnPoints");
                return null;
            }
        }


        internal string __78_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__78_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __23_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__23_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __91_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__91_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __37_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__37_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __193_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__193_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __7_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__7_const_intnl_SystemString");
                return null;
            }
        }


        internal string __15_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__15_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __176_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__176_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __195_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__195_intnl_SystemBoolean");
                return null;
            }
        }


        internal string masterName
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "masterName");
                return null;
            }
        }


        internal bool? __89_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__89_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __5_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__5_const_intnl_SystemInt32");
                return null;
            }
        }


        internal long? __refl_const_intnl_udonTypeID
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__refl_const_intnl_udonTypeID");
                return null;
            }
        }


        internal string __65_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__65_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __4_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__4_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? playerCount
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "playerCount");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour gameJoinTrigger
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "gameJoinTrigger");
                return null;
            }
        }


        internal float? __11_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__11_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __106_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__106_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __43_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__43_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __34_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__34_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour gameEffects
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "gameEffects");
                return null;
            }
        }


        internal string __79_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__79_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __19_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__19_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? gameStartCountdown
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "gameStartCountdown");
                return null;
            }
        }


        internal string __refl_const_intnl_udonTypeName
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__refl_const_intnl_udonTypeName");
                return null;
            }
        }


        internal bool? __127_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__127_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __170_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__170_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __87_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__87_const_intnl_SystemString");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour audioControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "audioControl");
                return null;
            }
        }


        internal UnityEngine.GameObject startButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "startButton");
                return null;
            }
        }


        internal VRC.SDK3.Components.VRCObjectPool __0_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_VRC3_SDK3_VRCObjectPool(GameData, "__0_intnl_SystemObject");
                return null;
            }
        }


        internal bool? __1_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__1_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __38_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__38_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __31_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__31_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __37_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__37_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __14_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__14_intnl_SystemInt32");
                return null;
            }
        }


        internal string escapeeName
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "escapeeName");
                return null;
            }
        }


        internal TMPro.TextMeshProUGUI __2_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_TextMeshProUGUI(GameData, "__2_intnl_UnityEngineComponent");
                return null;
            }
        }


        internal bool? __152_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__152_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __12_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__12_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __34_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__34_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __171_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__171_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __17_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__17_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __100_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__100_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? timeLimit
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "timeLimit");
                return null;
            }
        }


        internal int? __11_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__11_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __79_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__79_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __92_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__92_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __17_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__17_intnl_SystemInt32");
                return null;
            }
        }


        internal long? __5_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__5_intnl_SystemInt64");
                return null;
            }
        }


        internal uint? __26_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__26_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __4_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__4_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __81_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__81_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __31_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__31_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal TMPro.TextMeshProUGUI __5_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_TextMeshProUGUI(GameData, "__5_intnl_TMProTextMeshProUGUI");
                return null;
            }
        }


        internal bool? __68_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__68_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __67_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__67_const_intnl_SystemString");
                return null;
            }
        }


        internal string __20_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__20_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __188_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__188_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __50_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__50_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __101_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__101_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject startButtonEnabled
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "startButtonEnabled");
                return null;
            }
        }


        internal string __35_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__35_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __11_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__11_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __2_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__2_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __189_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__189_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __8_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__8_const_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __52_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__52_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal uint? __4_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__4_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal float? prisRatio
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "prisRatio");
                return null;
            }
        }


        internal bool? __30_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__30_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_updated_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__0_updated_Boolean");
                return null;
            }
        }


        internal int? __26_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__26_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __54_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__54_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? winState
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "winState");
                return null;
            }
        }


        internal string __21_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__21_const_intnl_SystemString");
                return null;
            }
        }


        internal string __51_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__51_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __41_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__41_intnl_SystemInt32");
                return null;
            }
        }


        internal string __26_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__26_const_intnl_SystemString");
                return null;
            }
        }


        internal string __56_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__56_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __42_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__42_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __71_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__71_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __117_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__117_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject winTitle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "winTitle");
                return null;
            }
        }


        internal UnityEngine.GameObject countdownPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "countdownPanel");
                return null;
            }
        }


        internal int? __0_players_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_players_Int32");
                return null;
            }
        }


        internal int? timeRemaining
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "timeRemaining");
                return null;
            }
        }


        internal uint? __9_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__9_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __60_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__60_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __196_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__196_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __37_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__37_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __82_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__82_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __20_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__20_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __168_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__168_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __9_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__9_intnl_SystemInt32");
                return null;
            }
        }


        internal string __37_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__37_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __2_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__2_intnl_SystemSingle");
                return null;
            }
        }


        internal string __5_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__5_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __3_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__3_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __147_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__147_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject prisText
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "prisText");
                return null;
            }
        }


        internal bool? __0_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__0_intnl_returnValSymbol_Boolean");
                return null;
            }
        }


        internal bool? __12_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__12_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __6_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__6_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __169_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__169_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __70_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__70_const_intnl_SystemString");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour doorControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "doorControl");
                return null;
            }
        }


        internal bool? __190_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__190_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __67_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__67_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __23_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__23_const_intnl_SystemString");
                return null;
            }
        }


        internal string __53_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__53_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? hiddenSpectate
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "hiddenSpectate");
                return null;
            }
        }


        internal int? __6_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__6_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __172_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__172_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __9_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__9_const_intnl_SystemInt32");
                return null;
            }
        }


        internal int? cachedTimeLimit
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "cachedTimeLimit");
                return null;
            }
        }


        internal bool? __44_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__44_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __17_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__17_intnl_SystemSingle");
                return null;
            }
        }


        internal int? cachedWinState
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "cachedWinState");
                return null;
            }
        }


        internal bool? __191_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__191_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject[] __0_intnl_UnityEngineGameObjectArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject_Array(GameData, "__0_intnl_UnityEngineGameObjectArray");
                return null;
            }
        }


        internal string __82_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__82_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __72_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__72_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__0_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __34_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__34_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal float? __9_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__9_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __102_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__102_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __71_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__71_const_intnl_SystemString");
                return null;
            }
        }


        internal string __76_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__76_const_intnl_SystemString");
                return null;
            }
        }


        internal UnityEngine.GameObject startButtonDisabled
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "startButtonDisabled");
                return null;
            }
        }


        internal bool? __124_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__124_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool[] isGuard
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean_Array(GameData, "isGuard");
                return null;
            }
        }


        internal string __12_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__12_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __38_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__38_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __123_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__123_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject __0_this_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "__0_this_intnl_UnityEngineGameObject");
                return null;
            }
        }


        internal UnityEngine.Transform[] prisSpawns
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Transform_Array(GameData, "prisSpawns");
                return null;
            }
        }


        internal float? __23_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__23_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __125_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__125_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __62_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__62_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __158_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__158_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __8_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__8_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __6_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__6_intnl_SystemSingle");
                return null;
            }
        }


        internal uint? __33_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__33_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal UnityEngine.Quaternion? __0_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Quaternion(GameData, "__0_intnl_UnityEngineQuaternion");
                return null;
            }
        }


        internal float? __24_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__24_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __159_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__159_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __58_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__58_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __137_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__137_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.SDKBase.VRCPlayerApi onPlayerJoinedPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(GameData, "onPlayerJoinedPlayer");
                return null;
            }
        }


        internal float? gameStartTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "gameStartTime");
                return null;
            }
        }


        internal string __73_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__73_const_intnl_SystemString");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour patronControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "patronControl");
                return null;
            }
        }


        internal uint? __15_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__15_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal float? __16_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__16_intnl_SystemSingle");
                return null;
            }
        }


        internal long? __2_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__2_intnl_SystemInt64");
                return null;
            }
        }


        internal VRC.SDKBase.VRCPlayerApi __1_mp_player_VRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(GameData, "__1_mp_player_VRCPlayerApi");
                return null;
            }
        }


        internal UnityEngine.GameObject timeLimitText
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "timeLimitText");
                return null;
            }
        }


        internal uint? __19_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__19_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __12_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__12_const_intnl_SystemInt32");
                return null;
            }
        }


        internal int? timeoutSecs
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "timeoutSecs");
                return null;
            }
        }


        internal bool? __114_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__114_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __32_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__32_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __113_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__113_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __0_newPrisRatio_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__0_newPrisRatio_Single");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __0_const_intnl_SystemType With Type System.RuntimeType



        internal int? __29_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__29_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __35_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__35_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __8_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__8_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __0_rand_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_rand_Int32");
                return null;
            }
        }


        internal bool? __50_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__50_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __22_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__22_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __192_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__192_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __22_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__22_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __115_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__115_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? joinError
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "joinError");
                return null;
            }
        }


        internal bool? __24_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__24_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __9_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__9_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __13_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__13_const_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __0_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_intnl_SystemInt32");
                return null;
            }
        }


        internal long? __9_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__9_intnl_SystemInt64");
                return null;
            }
        }


        internal uint? __0_intnl_returnTarget_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__0_intnl_returnTarget_UInt32");
                return null;
            }
        }


        internal bool? __144_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__144_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? cachedGameStarted
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "cachedGameStarted");
                return null;
            }
        }


        internal bool? __48_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__48_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_mp_error_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__0_mp_error_Boolean");
                return null;
            }
        }


        internal UnityEngine.GameObject guardText
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "guardText");
                return null;
            }
        }


        internal bool? __143_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__143_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __30_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__30_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __45_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__45_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __44_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__44_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __65_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__65_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __92_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__92_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __33_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__33_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __145_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__145_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __57_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__57_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __33_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__33_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __10_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__10_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __49_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__49_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __126_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__126_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __0_const_intnl_SystemUInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__0_const_intnl_SystemUInt32");
                return null;
            }
        }


        internal long? __6_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__6_intnl_SystemInt64");
                return null;
            }
        }


        internal bool? __178_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__178_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __9_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__9_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __13_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__13_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __36_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__36_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __45_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__45_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __63_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__63_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __36_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__36_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __179_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__179_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __88_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__88_const_intnl_SystemString");
                return null;
            }
        }


        internal UnityEngine.GameObject spectatePanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "spectatePanel");
                return null;
            }
        }


        internal float? __0_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__0_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __108_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__108_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __40_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__40_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __120_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__120_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __94_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__94_intnl_SystemBoolean");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __1_const_intnl_SystemType With Type System.RuntimeType



        internal int? __25_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__25_intnl_SystemInt32");
                return null;
            }
        }


        internal string __18_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__18_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __109_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__109_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __40_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__40_intnl_SystemInt32");
                return null;
            }
        }


        internal float? __13_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__13_intnl_SystemSingle");
                return null;
            }
        }


        internal UnityEngine.UI.Slider prisRatioSlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UnityEngine_UI_Slider(GameData, "prisRatioSlider");
                return null;
            }
        }


        internal bool? __66_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__66_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __121_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__121_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __22_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__22_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __4_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__4_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __187_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__187_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __89_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__89_const_intnl_SystemString");
                return null;
            }
        }


        internal string __68_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__68_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __14_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__14_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __47_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__47_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour gateControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "gateControl");
                return null;
            }
        }


        internal bool? __134_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__134_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject masterText
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "masterText");
                return null;
            }
        }


        internal string __47_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__47_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __133_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__133_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour spectatorDisplay
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "spectatorDisplay");
                return null;
            }
        }


        internal int? __10_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__10_const_intnl_SystemInt32");
                return null;
            }
        }


        internal string __19_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__19_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __17_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__17_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __116_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__116_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject startTimeoutText
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "startTimeoutText");
                return null;
            }
        }


        internal bool? __135_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__135_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __30_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__30_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __39_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__39_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __69_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__69_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __0_prisoners_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_prisoners_Int32");
                return null;
            }
        }


        internal bool? __28_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__28_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __36_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__36_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __6_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__6_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject startPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "startPanel");
                return null;
            }
        }


        internal float? __20_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__20_intnl_SystemSingle");
                return null;
            }
        }


        internal float? __4_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__4_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __146_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__146_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.SDK3.Components.VRCObjectPool __1_intnl_VRCSDK3ComponentsVRCObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_VRC3_SDK3_VRCObjectPool(GameData, "__1_intnl_VRCSDK3ComponentsVRCObjectPool");
                return null;
            }
        }


        internal bool? __84_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__84_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __110_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__110_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __24_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__24_const_intnl_SystemString");
                return null;
            }
        }


        internal string __54_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__54_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __16_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__16_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __69_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__69_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.SDKBase.VRCPlayerApi __4_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(GameData, "__4_intnl_VRCSDKBaseVRCPlayerApi");
                return null;
            }
        }


        internal bool? __167_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__167_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __12_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__12_intnl_SystemSingle");
                return null;
            }
        }


        internal string __38_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__38_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __198_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__198_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __14_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__14_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __1_guards_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__1_guards_Int32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour lootCrateControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "lootCrateControl");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour openableControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "openableControl");
                return null;
            }
        }


        internal bool? __111_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__111_intnl_SystemBoolean");
                return null;
            }
        }


        internal long? __0_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__0_intnl_SystemInt64");
                return null;
            }
        }


        internal bool? __140_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__140_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __47_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__47_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __3_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__3_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __31_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__31_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __199_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__199_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __55_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__55_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __25_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__25_const_intnl_SystemString");
                return null;
            }
        }


        internal string __55_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__55_const_intnl_SystemString");
                return null;
            }
        }


        internal uint? __11_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__11_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __8_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__8_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __20_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__20_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Vector3? __2_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Vector3(GameData, "__2_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal bool? __141_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__141_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __39_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__39_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __74_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__74_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __122_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__122_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __0_guard_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__0_guard_Boolean");
                return null;
            }
        }


        internal uint? __25_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__25_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __61_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__61_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __98_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__98_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour afkDetector
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "afkDetector");
                return null;
            }
        }


        internal uint? __29_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__29_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal UnityEngine.Vector3? __1_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Vector3(GameData, "__1_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal bool? __53_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__53_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __80_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__80_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __27_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__27_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __51_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__51_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __2_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__2_const_intnl_SystemInt32");
                return null;
            }
        }


        internal float? __3_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__3_intnl_SystemSingle");
                return null;
            }
        }


        internal string __74_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__74_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __157_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__157_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __136_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__136_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __27_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__27_const_intnl_SystemString");
                return null;
            }
        }


        internal UnityEngine.Vector3? __0_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Vector3(GameData, "__0_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal string __57_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__57_const_intnl_SystemString");
                return null;
            }
        }


        internal string __10_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__10_const_intnl_SystemString");
                return null;
            }
        }


        internal UnityEngine.GameObject[] prisObjects
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject_Array(GameData, "prisObjects");
                return null;
            }
        }


        internal bool? __32_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__32_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __56_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__56_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __41_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__41_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __42_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__42_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __18_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__18_intnl_SystemSingle");
                return null;
            }
        }


        internal bool? __184_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__184_intnl_SystemBoolean");
                return null;
            }
        }


        internal long? __4_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__4_intnl_SystemInt64");
                return null;
            }
        }


        internal bool? __45_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__45_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __81_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__81_const_intnl_SystemString");
                return null;
            }
        }


        internal string __60_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__60_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __183_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__183_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __28_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__28_intnl_SystemInt32");
                return null;
            }
        }


        internal int? __7_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__7_intnl_SystemInt32");
                return null;
            }
        }


        internal string __86_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__86_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __1_const_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__1_const_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __90_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__90_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __75_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__75_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __130_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__130_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __185_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__185_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Color? __0_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Color(GameData, "__0_intnl_UnityEngineColor");
                return null;
            }
        }


        internal bool? __62_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__62_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __200_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__200_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __11_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__11_const_intnl_SystemString");
                return null;
            }
        }


        internal string __16_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__16_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __112_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__112_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __88_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__88_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __32_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__32_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal float? cachedPrisRatio
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "cachedPrisRatio");
                return null;
            }
        }


        internal UnityEngine.Transform afkRespawn
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Transform(GameData, "afkRespawn");
                return null;
            }
        }


        internal long? __0_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__0_const_intnl_SystemInt64");
                return null;
            }
        }


        internal bool? __131_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__131_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __43_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__43_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __61_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__61_const_intnl_SystemString");
                return null;
            }
        }


        internal string __66_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__66_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __18_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__18_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __97_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__97_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __2_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__2_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __10_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__10_intnl_SystemSingle");
                return null;
            }
        }


        internal float? __25_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__25_intnl_SystemSingle");
                return null;
            }
        }


        internal uint? __14_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__14_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __142_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__142_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __83_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__83_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __3_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__3_const_intnl_SystemInt32");
                return null;
            }
        }


        internal float? __7_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__7_intnl_SystemSingle");
                return null;
            }
        }


        internal VRC.Udon.Common.Interfaces.NetworkEventTarget? __0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_NetworkEventTarget(GameData, "__0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget");
                return null;
            }
        }


        internal bool? __164_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__164_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __59_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__59_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __163_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__163_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __18_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__18_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __46_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__46_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __39_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__39_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour playerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(GameData, "playerObjectPool");
                return null;
            }
        }


        internal string __77_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__77_const_intnl_SystemString");
                return null;
            }
        }


        internal string __30_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__30_const_intnl_SystemString");
                return null;
            }
        }


        internal string __13_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__13_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __78_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__78_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __8_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__8_intnl_SystemInt32");
                return null;
            }
        }


        internal int? guardHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "guardHealth");
                return null;
            }
        }


        internal bool? __165_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__165_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __0_randomIndex_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_randomIndex_Int32");
                return null;
            }
        }


        internal bool? __80_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__80_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __19_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__19_intnl_SystemInt32");
                return null;
            }
        }


        internal UnityEngine.GameObject winPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "winPanel");
                return null;
            }
        }


        internal int? __24_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__24_intnl_SystemInt32");
                return null;
            }
        }


        internal string __63_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__63_const_intnl_SystemString");
                return null;
            }
        }


        internal long? __3_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__3_intnl_SystemInt64");
                return null;
            }
        }


        internal uint? __13_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__13_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal UnityEngine.GameObject[] guardObjects
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject_Array(GameData, "guardObjects");
                return null;
            }
        }


        internal bool? __10_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__10_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __90_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__90_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __177_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__177_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __2_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__2_const_intnl_SystemString");
                return null;
            }
        }


        internal string __31_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__31_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __21_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__21_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __27_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__27_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal int? __27_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__27_intnl_SystemInt32");
                return null;
            }
        }


        internal string __36_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__36_const_intnl_SystemString");
                return null;
            }
        }


        internal long? __1_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int64(GameData, "__1_const_intnl_SystemInt64");
                return null;
            }
        }


        internal uint? __44_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__44_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __128_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__128_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __87_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__87_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __51_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__51_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? displayWinner
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "displayWinner");
                return null;
            }
        }


        internal int? __0_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_const_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __107_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__107_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __1_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__1_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __25_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__25_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __0_guardCount_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_guardCount_Int32");
                return null;
            }
        }


        internal uint? __48_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_UInt32(GameData, "__48_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal string __22_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__22_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __8_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_single(GameData, "__8_intnl_SystemSingle");
                return null;
            }
        }


        internal string __52_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__52_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __70_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__70_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __129_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__129_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.GameObject __0_obj_GameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_GameObject(GameData, "__0_obj_GameObject");
                return null;
            }
        }


        internal bool? __186_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__186_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __17_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__17_intnl_SystemBoolean");
                return null;
            }
        }


        internal int? __1_prisCount_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__1_prisCount_Int32");
                return null;
            }
        }


        internal bool? __49_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__49_intnl_SystemBoolean");
                return null;
            }
        }


        internal string __91_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_string(GameData, "__91_const_intnl_SystemString");
                return null;
            }
        }


        internal int? __0_intnl_returnValSymbol_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Int32(GameData, "__0_intnl_returnValSymbol_Int32");
                return null;
            }
        }


        internal bool? __154_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__154_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __153_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__153_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __132_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (GameData != null) return UdonHeapParser.Udon_Parse_Boolean(GameData, "__132_intnl_SystemBoolean");
                return null;
            }
        }





        // Use this for initialization
    }
}