namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
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
                    Initialize_GameData();
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

        #region Getter / Setters UdonVariables  of GameData

        internal string __3_intnl_interpolatedStr_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_interpolatedStr_String != null)
                {
                    return Private___3_intnl_interpolatedStr_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_interpolatedStr_String != null)
                {
                    Private___3_intnl_interpolatedStr_String.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __6_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_UnityEngineTransform != null)
                {
                    return Private___6_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___6_intnl_UnityEngineTransform != null)
                {
                    Private___6_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        internal int? __35_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_intnl_SystemInt32 != null)
                {
                    return Private___35_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_intnl_SystemInt32 != null)
                    {
                        Private___35_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __43_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___43_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___43_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___43_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___43_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? updatedTeams
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_updatedTeams != null)
                {
                    return Private_updatedTeams.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_updatedTeams != null)
                    {
                        Private_updatedTeams.Value = value.Value;
                    }
                }
            }
        }

        internal string __33_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_const_intnl_SystemString != null)
                {
                    return Private___33_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___33_const_intnl_SystemString != null)
                {
                    Private___33_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __0_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___0_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___0_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal int? __0_newTimeLimit_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newTimeLimit_Int32 != null)
                {
                    return Private___0_newTimeLimit_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newTimeLimit_Int32 != null)
                    {
                        Private___0_newTimeLimit_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __23_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_intnl_SystemBoolean != null)
                {
                    return Private___23_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___23_intnl_SystemBoolean != null)
                    {
                        Private___23_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __10_pData_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_pData_PlayerData != null)
                {
                    return Private___10_pData_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___10_pData_PlayerData != null)
                {
                    Private___10_pData_PlayerData.Value = value;
                }
            }
        }

        internal int? __0_guards_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_guards_Int32 != null)
                {
                    return Private___0_guards_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_guards_Int32 != null)
                    {
                        Private___0_guards_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __155_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___155_intnl_SystemBoolean != null)
                {
                    return Private___155_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___155_intnl_SystemBoolean != null)
                    {
                        Private___155_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __0_playerDataObj_GameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_playerDataObj_GameObject != null)
                {
                    return Private___0_playerDataObj_GameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_playerDataObj_GameObject != null)
                {
                    Private___0_playerDataObj_GameObject.Value = value;
                }
            }
        }

        internal int? __32_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_intnl_SystemInt32 != null)
                {
                    return Private___32_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___32_intnl_SystemInt32 != null)
                    {
                        Private___32_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __180_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___180_intnl_SystemBoolean != null)
                {
                    return Private___180_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___180_intnl_SystemBoolean != null)
                    {
                        Private___180_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __77_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___77_intnl_SystemBoolean != null)
                {
                    return Private___77_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___77_intnl_SystemBoolean != null)
                    {
                        Private___77_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __8_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_PlayerData != null)
                {
                    return Private___8_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_intnl_PlayerData != null)
                {
                    Private___8_intnl_PlayerData.Value = value;
                }
            }
        }

        internal string __48_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___48_const_intnl_SystemString != null)
                {
                    return Private___48_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___48_const_intnl_SystemString != null)
                {
                    Private___48_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal long? __7_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemInt64 != null)
                {
                    return Private___7_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_SystemInt64 != null)
                    {
                        Private___7_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal int? __15_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_SystemInt32 != null)
                {
                    return Private___15_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_intnl_SystemInt32 != null)
                    {
                        Private___15_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __1_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineGameObject != null)
                {
                    return Private___1_intnl_UnityEngineGameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineGameObject != null)
                {
                    Private___1_intnl_UnityEngineGameObject.Value = value;
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __3_mp_player_VRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_mp_player_VRCPlayerApi != null)
                {
                    return Private___3_mp_player_VRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_mp_player_VRCPlayerApi != null)
                {
                    Private___3_mp_player_VRCPlayerApi.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __5_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_UnityEngineComponent != null)
                {
                    return Private___5_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_UnityEngineComponent != null)
                {
                    Private___5_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        internal uint? __21_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___21_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___21_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___21_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __12_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_SystemInt32 != null)
                {
                    return Private___12_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_intnl_SystemInt32 != null)
                    {
                        Private___12_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __181_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___181_intnl_SystemBoolean != null)
                {
                    return Private___181_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___181_intnl_SystemBoolean != null)
                    {
                        Private___181_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __52_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___52_intnl_SystemBoolean != null)
                {
                    return Private___52_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___52_intnl_SystemBoolean != null)
                    {
                        Private___52_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __3_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_const_intnl_SystemString != null)
                {
                    return Private___3_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_const_intnl_SystemString != null)
                {
                    Private___3_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __6_intnl_interpolatedStr_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_interpolatedStr_String != null)
                {
                    return Private___6_intnl_interpolatedStr_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___6_intnl_interpolatedStr_String != null)
                {
                    Private___6_intnl_interpolatedStr_String.Value = value;
                }
            }
        }

        internal int? __6_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_const_intnl_SystemInt32 != null)
                {
                    return Private___6_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_const_intnl_SystemInt32 != null)
                    {
                        Private___6_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_PlayerData != null)
                {
                    return Private___0_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_PlayerData != null)
                {
                    Private___0_intnl_PlayerData.Value = value;
                }
            }
        }

        internal uint? __3_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___3_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___3_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform[] guardSpawns
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_guardSpawns != null)
                {
                    return Private_guardSpawns.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_guardSpawns != null)
                {
                    Private_guardSpawns.Value = value;
                }
            }
        }

        internal bool? __26_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___26_intnl_SystemBoolean != null)
                {
                    return Private___26_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___26_intnl_SystemBoolean != null)
                    {
                        Private___26_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_const_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemBoolean != null)
                {
                    return Private___0_const_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemBoolean != null)
                    {
                        Private___0_const_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Quaternion? __1_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineQuaternion != null)
                {
                    return Private___1_intnl_UnityEngineQuaternion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_UnityEngineQuaternion != null)
                    {
                        Private___1_intnl_UnityEngineQuaternion.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __41_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___41_intnl_SystemBoolean != null)
                {
                    return Private___41_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___41_intnl_SystemBoolean != null)
                    {
                        Private___41_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __1_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineTransform != null)
                {
                    return Private___1_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineTransform != null)
                {
                    Private___1_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        internal bool? __166_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___166_intnl_SystemBoolean != null)
                {
                    return Private___166_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___166_intnl_SystemBoolean != null)
                    {
                        Private___166_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __118_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___118_intnl_SystemBoolean != null)
                {
                    return Private___118_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___118_intnl_SystemBoolean != null)
                    {
                        Private___118_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __95_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___95_intnl_SystemBoolean != null)
                {
                    return Private___95_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___95_intnl_SystemBoolean != null)
                    {
                        Private___95_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_SystemInt32 != null)
                {
                    return Private___1_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_SystemInt32 != null)
                    {
                        Private___1_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __49_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___49_const_intnl_SystemString != null)
                {
                    return Private___49_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___49_const_intnl_SystemString != null)
                {
                    Private___49_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __1_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemInt32 != null)
                {
                    return Private___1_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemInt32 != null)
                    {
                        Private___1_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour scoreboardDisplay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scoreboardDisplay != null)
                {
                    return Private_scoreboardDisplay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_scoreboardDisplay != null)
                {
                    Private_scoreboardDisplay.Value = value;
                }
            }
        }

        internal uint? __16_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___16_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___16_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___16_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject versionErrorPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_versionErrorPanel != null)
                {
                    return Private_versionErrorPanel.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_versionErrorPanel != null)
                {
                    Private_versionErrorPanel.Value = value;
                }
            }
        }

        internal int? __1_prisoners_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_prisoners_Int32 != null)
                {
                    return Private___1_prisoners_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_prisoners_Int32 != null)
                    {
                        Private___1_prisoners_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal string __72_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___72_const_intnl_SystemString != null)
                {
                    return Private___72_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___72_const_intnl_SystemString != null)
                {
                    Private___72_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __119_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___119_intnl_SystemBoolean != null)
                {
                    return Private___119_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___119_intnl_SystemBoolean != null)
                    {
                        Private___119_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __15_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_SystemSingle != null)
                {
                    return Private___15_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_intnl_SystemSingle != null)
                    {
                        Private___15_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __35_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_intnl_SystemObject != null)
                {
                    return Private___35_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_intnl_SystemObject != null)
                    {
                        Private___35_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __2_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemObject != null)
                {
                    return Private___2_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemObject != null)
                    {
                        Private___2_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __8_pData_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_pData_PlayerData != null)
                {
                    return Private___8_pData_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_pData_PlayerData != null)
                {
                    Private___8_pData_PlayerData.Value = value;
                }
            }
        }

        internal bool? __148_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___148_intnl_SystemBoolean != null)
                {
                    return Private___148_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___148_intnl_SystemBoolean != null)
                    {
                        Private___148_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.Common.Enums.EventTiming? __0_const_intnl_VRCUdonCommonEnumsEventTiming
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_VRCUdonCommonEnumsEventTiming != null)
                {
                    return Private___0_const_intnl_VRCUdonCommonEnumsEventTiming.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_VRCUdonCommonEnumsEventTiming != null)
                    {
                        Private___0_const_intnl_VRCUdonCommonEnumsEventTiming.Value = value.Value;
                    }
                }

            }
        }

        internal string __15_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_SystemString != null)
                {
                    return Private___15_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___15_intnl_SystemString != null)
                {
                    Private___15_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __1_i_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_i_Int32 != null)
                {
                    return Private___1_i_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_i_Int32 != null)
                    {
                        Private___1_i_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_i_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_i_Int32 != null)
                {
                    return Private___0_i_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_i_Int32 != null)
                    {
                        Private___0_i_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __2_i_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_i_Int32 != null)
                {
                    return Private___2_i_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_i_Int32 != null)
                    {
                        Private___2_i_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __197_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___197_intnl_SystemBoolean != null)
                {
                    return Private___197_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___197_intnl_SystemBoolean != null)
                    {
                        Private___197_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __160_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___160_intnl_SystemBoolean != null)
                {
                    return Private___160_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___160_intnl_SystemBoolean != null)
                    {
                        Private___160_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __42_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___42_intnl_SystemInt32 != null)
                {
                    return Private___42_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___42_intnl_SystemInt32 != null)
                    {
                        Private___42_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour itemControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemControl != null)
                {
                    return Private_itemControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemControl != null)
                {
                    Private_itemControl.Value = value;
                }
            }
        }

        internal uint? __35_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___35_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___35_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? gameStartDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameStartDelay != null)
                {
                    return Private_gameStartDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameStartDelay != null)
                    {
                        Private_gameStartDelay.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __3_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_UnityEngineComponent != null)
                {
                    return Private___3_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_UnityEngineComponent != null)
                {
                    Private___3_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        internal bool? __93_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___93_intnl_SystemBoolean != null)
                {
                    return Private___93_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___93_intnl_SystemBoolean != null)
                    {
                        Private___93_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __149_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___149_intnl_SystemBoolean != null)
                {
                    return Private___149_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___149_intnl_SystemBoolean != null)
                    {
                        Private___149_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal long? __8_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemInt64 != null)
                {
                    return Private___8_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_SystemInt64 != null)
                    {
                        Private___8_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __161_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___161_intnl_SystemBoolean != null)
                {
                    return Private___161_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___161_intnl_SystemBoolean != null)
                    {
                        Private___161_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __39_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___39_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___39_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___39_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___39_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __2_pData_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_pData_PlayerData != null)
                {
                    return Private___2_pData_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_pData_PlayerData != null)
                {
                    Private___2_pData_PlayerData.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour desktopInteract
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_desktopInteract != null)
                {
                    return Private_desktopInteract.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_desktopInteract != null)
                {
                    Private_desktopInteract.Value = value;
                }
            }
        }

        internal string __0_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemString != null)
                {
                    return Private___0_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_const_intnl_SystemString != null)
                {
                    Private___0_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __1_mp_lastAlive_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_lastAlive_Boolean != null)
                {
                    return Private___1_mp_lastAlive_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_lastAlive_Boolean != null)
                    {
                        Private___1_mp_lastAlive_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject prisRatioText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_prisRatioText != null)
                {
                    return Private_prisRatioText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_prisRatioText != null)
                {
                    Private_prisRatioText.Value = value;
                }
            }
        }

        internal float? __21_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_intnl_SystemSingle != null)
                {
                    return Private___21_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___21_intnl_SystemSingle != null)
                    {
                        Private___21_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __42_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___42_intnl_SystemBoolean != null)
                {
                    return Private___42_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___42_intnl_SystemBoolean != null)
                    {
                        Private___42_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemSingle != null)
                {
                    return Private___0_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemSingle != null)
                    {
                        Private___0_const_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __29_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_intnl_SystemBoolean != null)
                {
                    return Private___29_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___29_intnl_SystemBoolean != null)
                    {
                        Private___29_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __1_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemSingle != null)
                {
                    return Private___1_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemSingle != null)
                    {
                        Private___1_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour playerTracker
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerTracker != null)
                {
                    return Private_playerTracker.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerTracker != null)
                {
                    Private_playerTracker.Value = value;
                }
            }
        }

        internal bool? __174_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___174_intnl_SystemBoolean != null)
                {
                    return Private___174_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___174_intnl_SystemBoolean != null)
                    {
                        Private___174_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __96_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___96_intnl_SystemBoolean != null)
                {
                    return Private___96_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___96_intnl_SystemBoolean != null)
                    {
                        Private___96_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __7_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_const_intnl_SystemInt32 != null)
                {
                    return Private___7_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_const_intnl_SystemInt32 != null)
                    {
                        Private___7_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Slider timeLimitSlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timeLimitSlider != null)
                {
                    return Private_timeLimitSlider.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_timeLimitSlider != null)
                {
                    Private_timeLimitSlider.Value = value;
                }
            }
        }

        internal bool? __173_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___173_intnl_SystemBoolean != null)
                {
                    return Private___173_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___173_intnl_SystemBoolean != null)
                    {
                        Private___173_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __9_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemObject != null)
                {
                    return Private___9_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_intnl_SystemObject != null)
                {
                    Private___9_intnl_SystemObject.Value = value;
                }
            }
        }

        internal bool? __5_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemBoolean != null)
                {
                    return Private___5_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_SystemBoolean != null)
                    {
                        Private___5_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __46_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___46_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___46_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___46_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___46_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __85_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___85_intnl_SystemBoolean != null)
                {
                    return Private___85_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___85_intnl_SystemBoolean != null)
                    {
                        Private___85_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject winSubtitle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_winSubtitle != null)
                {
                    return Private_winSubtitle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_winSubtitle != null)
                {
                    Private_winSubtitle.Value = value;
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __9_intnl_VRCSDK3ComponentsVRCObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    return Private___9_intnl_VRCSDK3ComponentsVRCObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    Private___9_intnl_VRCSDK3ComponentsVRCObjectPool.Value = value;
                }
            }
        }

        internal bool? __156_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___156_intnl_SystemBoolean != null)
                {
                    return Private___156_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___156_intnl_SystemBoolean != null)
                    {
                        Private___156_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __175_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___175_intnl_SystemBoolean != null)
                {
                    return Private___175_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___175_intnl_SystemBoolean != null)
                    {
                        Private___175_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __32_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_intnl_SystemObject != null)
                {
                    return Private___32_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___32_intnl_SystemObject != null)
                    {
                        Private___32_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __10_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___10_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___10_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? updatingTimeRemaining
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_updatingTimeRemaining != null)
                {
                    return Private_updatingTimeRemaining.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_updatingTimeRemaining != null)
                    {
                        Private_updatingTimeRemaining.Value = value.Value;
                    }
                }
            }
        }

        internal int? __11_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_const_intnl_SystemInt32 != null)
                {
                    return Private___11_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_const_intnl_SystemInt32 != null)
                    {
                        Private___11_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __104_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___104_intnl_SystemBoolean != null)
                {
                    return Private___104_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___104_intnl_SystemBoolean != null)
                    {
                        Private___104_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? syncedTimeRemaining
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_syncedTimeRemaining != null)
                {
                    return Private_syncedTimeRemaining.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_syncedTimeRemaining != null)
                    {
                        Private_syncedTimeRemaining.Value = value.Value;
                    }
                }
            }
        }

        internal int? __5_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemInt32 != null)
                {
                    return Private___5_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_SystemInt32 != null)
                    {
                        Private___5_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___0_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___0_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __103_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___103_intnl_SystemBoolean != null)
                {
                    return Private___103_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___103_intnl_SystemBoolean != null)
                    {
                        Private___103_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __15_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_SystemBoolean != null)
                {
                    return Private___15_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_intnl_SystemBoolean != null)
                    {
                        Private___15_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __24_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___24_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___24_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___24_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __182_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___182_intnl_SystemBoolean != null)
                {
                    return Private___182_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___182_intnl_SystemBoolean != null)
                    {
                        Private___182_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __20_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_intnl_SystemString != null)
                {
                    return Private___20_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___20_intnl_SystemString != null)
                {
                    Private___20_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __6_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemObject != null)
                {
                    return Private___6_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___6_intnl_SystemObject != null)
                {
                    Private___6_intnl_SystemObject.Value = value;
                }
            }
        }

        internal bool? __0_mp_lastAlive_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_lastAlive_Boolean != null)
                {
                    return Private___0_mp_lastAlive_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_lastAlive_Boolean != null)
                    {
                        Private___0_mp_lastAlive_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __5_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemString != null)
                {
                    return Private___5_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_SystemString != null)
                {
                    Private___5_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __105_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___105_intnl_SystemBoolean != null)
                {
                    return Private___105_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___105_intnl_SystemBoolean != null)
                    {
                        Private___105_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __34_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_intnl_SystemBoolean != null)
                {
                    return Private___34_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_intnl_SystemBoolean != null)
                    {
                        Private___34_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }


        internal string __28_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___28_const_intnl_SystemString != null)
                {
                    return Private___28_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___28_const_intnl_SystemString != null)
                {
                    Private___28_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __2_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineTransform != null)
                {
                    return Private___2_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineTransform != null)
                {
                    Private___2_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        internal string __58_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___58_const_intnl_SystemString != null)
                {
                    return Private___58_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___58_const_intnl_SystemString != null)
                {
                    Private___58_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __83_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___83_intnl_SystemBoolean != null)
                {
                    return Private___83_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___83_intnl_SystemBoolean != null)
                    {
                        Private___83_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __150_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___150_intnl_SystemBoolean != null)
                {
                    return Private___150_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___150_intnl_SystemBoolean != null)
                    {
                        Private___150_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __28_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___28_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___28_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___28_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___28_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __6_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_const_intnl_SystemString != null)
                {
                    return Private___6_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___6_const_intnl_SystemString != null)
                {
                    Private___6_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject joinErrorPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_joinErrorPanel != null)
                {
                    return Private_joinErrorPanel.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_joinErrorPanel != null)
                {
                    Private_joinErrorPanel.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject[] __7_intnl_UnityEngineGameObjectArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_UnityEngineGameObjectArray != null)
                {
                    return Private___7_intnl_UnityEngineGameObjectArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_UnityEngineGameObjectArray != null)
                {
                    Private___7_intnl_UnityEngineGameObjectArray.Value = value;
                }
            }
        }

        internal bool? __21_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_intnl_SystemBoolean != null)
                {
                    return Private___21_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___21_intnl_SystemBoolean != null)
                    {
                        Private___21_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __138_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___138_intnl_SystemBoolean != null)
                {
                    return Private___138_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___138_intnl_SystemBoolean != null)
                    {
                        Private___138_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __201_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___201_intnl_SystemBoolean != null)
                {
                    return Private___201_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___201_intnl_SystemBoolean != null)
                    {
                        Private___201_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_prisCount_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_prisCount_Int32 != null)
                {
                    return Private___0_prisCount_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_prisCount_Int32 != null)
                    {
                        Private___0_prisCount_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour sceneControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_sceneControl != null)
                {
                    return Private_sceneControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_sceneControl != null)
                {
                    Private_sceneControl.Value = value;
                }
            }
        }

        internal bool? __75_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___75_intnl_SystemBoolean != null)
                {
                    return Private___75_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___75_intnl_SystemBoolean != null)
                    {
                        Private___75_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __5_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___5_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___5_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __13_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_SystemBoolean != null)
                {
                    return Private___13_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_intnl_SystemBoolean != null)
                    {
                        Private___13_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __50_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___50_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___50_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___50_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___50_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __151_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___151_intnl_SystemBoolean != null)
                {
                    return Private___151_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___151_intnl_SystemBoolean != null)
                    {
                        Private___151_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __1_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_SystemString != null)
                {
                    return Private___1_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_const_intnl_SystemString != null)
                {
                    Private___1_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __4_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_const_intnl_SystemInt32 != null)
                {
                    return Private___4_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_const_intnl_SystemInt32 != null)
                    {
                        Private___4_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? gameStarted
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameStarted != null)
                {
                    return Private_gameStarted.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameStarted != null)
                    {
                        Private_gameStarted.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __64_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___64_intnl_SystemBoolean != null)
                {
                    return Private___64_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___64_intnl_SystemBoolean != null)
                    {
                        Private___64_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __40_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___40_const_intnl_SystemString != null)
                {
                    return Private___40_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___40_const_intnl_SystemString != null)
                {
                    Private___40_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __139_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___139_intnl_SystemBoolean != null)
                {
                    return Private___139_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___139_intnl_SystemBoolean != null)
                    {
                        Private___139_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __99_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___99_intnl_SystemBoolean != null)
                {
                    return Private___99_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___99_intnl_SystemBoolean != null)
                    {
                        Private___99_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __38_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___38_intnl_SystemInt32 != null)
                {
                    return Private___38_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___38_intnl_SystemInt32 != null)
                    {
                        Private___38_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? versionError
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_versionError != null)
                {
                    return Private_versionError.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_versionError != null)
                    {
                        Private_versionError.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __86_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___86_intnl_SystemBoolean != null)
                {
                    return Private___86_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___86_intnl_SystemBoolean != null)
                    {
                        Private___86_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __29_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_const_intnl_SystemString != null)
                {
                    return Private___29_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___29_const_intnl_SystemString != null)
                {
                    Private___29_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal uint? __23_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___23_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___23_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___23_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __59_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___59_const_intnl_SystemString != null)
                {
                    return Private___59_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___59_const_intnl_SystemString != null)
                {
                    Private___59_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal float? __5_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemSingle != null)
                {
                    return Private___5_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_SystemSingle != null)
                    {
                        Private___5_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal string __84_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___84_const_intnl_SystemString != null)
                {
                    return Private___84_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___84_const_intnl_SystemString != null)
                {
                    Private___84_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal uint? __40_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___40_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___40_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___40_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___40_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __3_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___3_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___3_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal uint? __2_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___2_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___2_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __18_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_intnl_SystemInt32 != null)
                {
                    return Private___18_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_intnl_SystemInt32 != null)
                    {
                        Private___18_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __16_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_SystemBoolean != null)
                {
                    return Private___16_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___16_intnl_SystemBoolean != null)
                    {
                        Private___16_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __73_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___73_intnl_SystemBoolean != null)
                {
                    return Private___73_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___73_intnl_SystemBoolean != null)
                    {
                        Private___73_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __162_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___162_intnl_SystemBoolean != null)
                {
                    return Private___162_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___162_intnl_SystemBoolean != null)
                    {
                        Private___162_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __14_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_const_intnl_SystemString != null)
                {
                    return Private___14_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___14_const_intnl_SystemString != null)
                {
                    Private___14_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __1_obj_GameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_obj_GameObject != null)
                {
                    return Private___1_obj_GameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_obj_GameObject != null)
                {
                    Private___1_obj_GameObject.Value = value;
                }
            }
        }

        internal int? __1_guardCount_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_guardCount_Int32 != null)
                {
                    return Private___1_guardCount_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_guardCount_Int32 != null)
                    {
                        Private___1_guardCount_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_this_intnl_GameManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_GameManager != null)
                {
                    return Private___0_this_intnl_GameManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_GameManager != null)
                {
                    Private___0_this_intnl_GameManager.Value = value;
                }
            }
        }

        internal float? __19_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_intnl_SystemSingle != null)
                {
                    return Private___19_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_intnl_SystemSingle != null)
                    {
                        Private___19_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal string __41_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___41_const_intnl_SystemString != null)
                {
                    return Private___41_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___41_const_intnl_SystemString != null)
                {
                    Private___41_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __46_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___46_const_intnl_SystemString != null)
                {
                    return Private___46_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___46_const_intnl_SystemString != null)
                {
                    Private___46_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __7_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemBoolean != null)
                {
                    return Private___7_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_SystemBoolean != null)
                    {
                        Private___7_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __20_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_intnl_SystemInt32 != null)
                {
                    return Private___20_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___20_intnl_SystemInt32 != null)
                    {
                        Private___20_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal long? __1_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemInt64 != null)
                {
                    return Private___1_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemInt64 != null)
                    {
                        Private___1_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal string __85_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___85_const_intnl_SystemString != null)
                {
                    return Private___85_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___85_const_intnl_SystemString != null)
                {
                    Private___85_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __64_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___64_const_intnl_SystemString != null)
                {
                    return Private___64_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___64_const_intnl_SystemString != null)
                {
                    Private___64_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __22_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_intnl_SystemBoolean != null)
                {
                    return Private___22_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___22_intnl_SystemBoolean != null)
                    {
                        Private___22_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __20_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_intnl_SystemObject != null)
                {
                    return Private___20_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___20_intnl_SystemObject != null)
                {
                    Private___20_intnl_SystemObject.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __0_intnl_UnityEngineComponentArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineComponentArray != null)
                {
                    return Private___0_intnl_UnityEngineComponentArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineComponentArray != null)
                {
                    Private___0_intnl_UnityEngineComponentArray.Value = value;
                }
            }
        }

        internal uint? __7_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___7_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___7_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __76_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___76_intnl_SystemBoolean != null)
                {
                    return Private___76_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___76_intnl_SystemBoolean != null)
                    {
                        Private___76_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __194_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___194_intnl_SystemBoolean != null)
                {
                    return Private___194_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___194_intnl_SystemBoolean != null)
                    {
                        Private___194_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform[] respawnPoints
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_respawnPoints != null)
                {
                    return Private_respawnPoints.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_respawnPoints != null)
                {
                    Private_respawnPoints.Value = value;
                }
            }
        }

        internal string __78_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___78_const_intnl_SystemString != null)
                {
                    return Private___78_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___78_const_intnl_SystemString != null)
                {
                    Private___78_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __2_intnl_interpolatedStr_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_interpolatedStr_String != null)
                {
                    return Private___2_intnl_interpolatedStr_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_interpolatedStr_String != null)
                {
                    Private___2_intnl_interpolatedStr_String.Value = value;
                }
            }
        }

        internal int? __23_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_intnl_SystemInt32 != null)
                {
                    return Private___23_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___23_intnl_SystemInt32 != null)
                    {
                        Private___23_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __91_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___91_intnl_SystemBoolean != null)
                {
                    return Private___91_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___91_intnl_SystemBoolean != null)
                    {
                        Private___91_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __37_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___37_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___37_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___37_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __193_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___193_intnl_SystemBoolean != null)
                {
                    return Private___193_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___193_intnl_SystemBoolean != null)
                    {
                        Private___193_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __36_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_intnl_SystemObject != null)
                {
                    return Private___36_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___36_intnl_SystemObject != null)
                {
                    Private___36_intnl_SystemObject.Value = value;
                }
            }
        }

        internal string __7_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_const_intnl_SystemString != null)
                {
                    return Private___7_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_const_intnl_SystemString != null)
                {
                    Private___7_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __15_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_const_intnl_SystemString != null)
                {
                    return Private___15_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___15_const_intnl_SystemString != null)
                {
                    Private___15_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __176_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___176_intnl_SystemBoolean != null)
                {
                    return Private___176_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___176_intnl_SystemBoolean != null)
                    {
                        Private___176_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __195_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___195_intnl_SystemBoolean != null)
                {
                    return Private___195_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___195_intnl_SystemBoolean != null)
                    {
                        Private___195_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string masterName
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_masterName != null)
                {
                    return Private_masterName.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_masterName != null)
                {
                    Private_masterName.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __2_intnl_UnityEngineComponentArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineComponentArray != null)
                {
                    return Private___2_intnl_UnityEngineComponentArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineComponentArray != null)
                {
                    Private___2_intnl_UnityEngineComponentArray.Value = value;
                }
            }
        }

        internal UnityEngine.Transform __0_spawn_Transform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_spawn_Transform != null)
                {
                    return Private___0_spawn_Transform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_spawn_Transform != null)
                {
                    Private___0_spawn_Transform.Value = value;
                }
            }
        }

        internal bool? __89_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___89_intnl_SystemBoolean != null)
                {
                    return Private___89_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___89_intnl_SystemBoolean != null)
                    {
                        Private___89_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __5_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_const_intnl_SystemInt32 != null)
                {
                    return Private___5_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_const_intnl_SystemInt32 != null)
                    {
                        Private___5_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal long? __refl_const_intnl_udonTypeID
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___refl_const_intnl_udonTypeID != null)
                {
                    return Private___refl_const_intnl_udonTypeID.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___refl_const_intnl_udonTypeID != null)
                    {
                        Private___refl_const_intnl_udonTypeID.Value = value.Value;
                    }
                }
            }
        }

        internal string __65_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___65_const_intnl_SystemString != null)
                {
                    return Private___65_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___65_const_intnl_SystemString != null)
                {
                    Private___65_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __4_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemBoolean != null)
                {
                    return Private___4_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_SystemBoolean != null)
                    {
                        Private___4_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? playerCount
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerCount != null)
                {
                    return Private_playerCount.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_playerCount != null)
                    {
                        Private_playerCount.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour gameJoinTrigger
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameJoinTrigger != null)
                {
                    return Private_gameJoinTrigger.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_gameJoinTrigger != null)
                {
                    Private_gameJoinTrigger.Value = value;
                }
            }
        }

        internal float? __11_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_SystemSingle != null)
                {
                    return Private___11_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_SystemSingle != null)
                    {
                        Private___11_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __106_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___106_intnl_SystemBoolean != null)
                {
                    return Private___106_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___106_intnl_SystemBoolean != null)
                    {
                        Private___106_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __43_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___43_const_intnl_SystemString != null)
                {
                    return Private___43_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___43_const_intnl_SystemString != null)
                {
                    Private___43_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __34_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_intnl_SystemInt32 != null)
                {
                    return Private___34_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_intnl_SystemInt32 != null)
                    {
                        Private___34_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour gameEffects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameEffects != null)
                {
                    return Private_gameEffects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_gameEffects != null)
                {
                    Private_gameEffects.Value = value;
                }
            }
        }

        internal string __79_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___79_const_intnl_SystemString != null)
                {
                    return Private___79_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___79_const_intnl_SystemString != null)
                {
                    Private___79_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __19_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_intnl_SystemBoolean != null)
                {
                    return Private___19_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_intnl_SystemBoolean != null)
                    {
                        Private___19_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? gameStartCountdown
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameStartCountdown != null)
                {
                    return Private_gameStartCountdown.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameStartCountdown != null)
                    {
                        Private_gameStartCountdown.Value = value.Value;
                    }
                }
            }
        }

        internal string __refl_const_intnl_udonTypeName
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___refl_const_intnl_udonTypeName != null)
                {
                    return Private___refl_const_intnl_udonTypeName.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___refl_const_intnl_udonTypeName != null)
                {
                    Private___refl_const_intnl_udonTypeName.Value = value;
                }
            }
        }

        internal bool? __127_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___127_intnl_SystemBoolean != null)
                {
                    return Private___127_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___127_intnl_SystemBoolean != null)
                    {
                        Private___127_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __170_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___170_intnl_SystemBoolean != null)
                {
                    return Private___170_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___170_intnl_SystemBoolean != null)
                    {
                        Private___170_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __87_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___87_const_intnl_SystemString != null)
                {
                    return Private___87_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___87_const_intnl_SystemString != null)
                {
                    Private___87_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour audioControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_audioControl != null)
                {
                    return Private_audioControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_audioControl != null)
                {
                    Private_audioControl.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject startButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_startButton != null)
                {
                    return Private_startButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_startButton != null)
                {
                    Private_startButton.Value = value;
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __0_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemObject != null)
                {
                    return Private___0_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_SystemObject != null)
                {
                    Private___0_intnl_SystemObject.Value = value;
                }
            }
        }

        internal bool? __1_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemBoolean != null)
                {
                    return Private___1_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemBoolean != null)
                    {
                        Private___1_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __38_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___38_intnl_SystemBoolean != null)
                {
                    return Private___38_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___38_intnl_SystemBoolean != null)
                    {
                        Private___38_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __31_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_intnl_SystemInt32 != null)
                {
                    return Private___31_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___31_intnl_SystemInt32 != null)
                    {
                        Private___31_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __37_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_intnl_SystemInt32 != null)
                {
                    return Private___37_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___37_intnl_SystemInt32 != null)
                    {
                        Private___37_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __14_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_SystemInt32 != null)
                {
                    return Private___14_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_intnl_SystemInt32 != null)
                    {
                        Private___14_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string escapeeName
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_escapeeName != null)
                {
                    return Private_escapeeName.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_escapeeName != null)
                {
                    Private_escapeeName.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __2_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineComponent != null)
                {
                    return Private___2_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineComponent != null)
                {
                    Private___2_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        internal bool? __152_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___152_intnl_SystemBoolean != null)
                {
                    return Private___152_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___152_intnl_SystemBoolean != null)
                    {
                        Private___152_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __12_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___12_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___12_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __34_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_const_intnl_SystemString != null)
                {
                    return Private___34_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___34_const_intnl_SystemString != null)
                {
                    Private___34_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __171_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___171_intnl_SystemBoolean != null)
                {
                    return Private___171_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___171_intnl_SystemBoolean != null)
                    {
                        Private___171_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __14_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_PlayerData != null)
                {
                    return Private___14_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___14_intnl_PlayerData != null)
                {
                    Private___14_intnl_PlayerData.Value = value;
                }
            }
        }

        internal string __17_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_const_intnl_SystemString != null)
                {
                    return Private___17_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___17_const_intnl_SystemString != null)
                {
                    Private___17_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __100_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___100_intnl_SystemBoolean != null)
                {
                    return Private___100_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___100_intnl_SystemBoolean != null)
                    {
                        Private___100_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? timeLimit
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timeLimit != null)
                {
                    return Private_timeLimit.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timeLimit != null)
                    {
                        Private_timeLimit.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __6_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___6_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___6_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___6_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal int? __11_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_SystemInt32 != null)
                {
                    return Private___11_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_SystemInt32 != null)
                    {
                        Private___11_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __79_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___79_intnl_SystemBoolean != null)
                {
                    return Private___79_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___79_intnl_SystemBoolean != null)
                    {
                        Private___79_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __92_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___92_intnl_SystemBoolean != null)
                {
                    return Private___92_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___92_intnl_SystemBoolean != null)
                    {
                        Private___92_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __17_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_SystemInt32 != null)
                {
                    return Private___17_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_intnl_SystemInt32 != null)
                    {
                        Private___17_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal long? __5_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemInt64 != null)
                {
                    return Private___5_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_SystemInt64 != null)
                    {
                        Private___5_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __26_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___26_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___26_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___26_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___26_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __4_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_const_intnl_SystemString != null)
                {
                    return Private___4_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_const_intnl_SystemString != null)
                {
                    Private___4_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __28_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___28_intnl_SystemObject != null)
                {
                    return Private___28_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___28_intnl_SystemObject != null)
                {
                    Private___28_intnl_SystemObject.Value = value;
                }
            }
        }

        internal bool? __81_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___81_intnl_SystemBoolean != null)
                {
                    return Private___81_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___81_intnl_SystemBoolean != null)
                    {
                        Private___81_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __31_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___31_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___31_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___31_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __5_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___5_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___5_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal string __10_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_SystemString != null)
                {
                    return Private___10_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___10_intnl_SystemString != null)
                {
                    Private___10_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __68_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___68_intnl_SystemBoolean != null)
                {
                    return Private___68_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___68_intnl_SystemBoolean != null)
                    {
                        Private___68_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __67_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___67_const_intnl_SystemString != null)
                {
                    return Private___67_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___67_const_intnl_SystemString != null)
                {
                    Private___67_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __20_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_const_intnl_SystemString != null)
                {
                    return Private___20_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___20_const_intnl_SystemString != null)
                {
                    Private___20_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __188_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___188_intnl_SystemBoolean != null)
                {
                    return Private___188_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___188_intnl_SystemBoolean != null)
                    {
                        Private___188_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __50_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___50_const_intnl_SystemString != null)
                {
                    return Private___50_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___50_const_intnl_SystemString != null)
                {
                    Private___50_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __101_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___101_intnl_SystemBoolean != null)
                {
                    return Private___101_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___101_intnl_SystemBoolean != null)
                    {
                        Private___101_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject startButtonEnabled
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_startButtonEnabled != null)
                {
                    return Private_startButtonEnabled.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_startButtonEnabled != null)
                {
                    Private_startButtonEnabled.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __7_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_UnityEngineGameObject != null)
                {
                    return Private___7_intnl_UnityEngineGameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_UnityEngineGameObject != null)
                {
                    Private___7_intnl_UnityEngineGameObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __7_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_PlayerData != null)
                {
                    return Private___7_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_PlayerData != null)
                {
                    Private___7_intnl_PlayerData.Value = value;
                }
            }
        }

        internal string __35_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_const_intnl_SystemString != null)
                {
                    return Private___35_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___35_const_intnl_SystemString != null)
                {
                    Private___35_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __11_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_SystemBoolean != null)
                {
                    return Private___11_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_intnl_SystemBoolean != null)
                    {
                        Private___11_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __2_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemInt32 != null)
                {
                    return Private___2_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemInt32 != null)
                    {
                        Private___2_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __17_intnl_VRCSDK3ComponentsVRCObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    return Private___17_intnl_VRCSDK3ComponentsVRCObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___17_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    Private___17_intnl_VRCSDK3ComponentsVRCObjectPool.Value = value;
                }
            }
        }

        internal bool? __189_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___189_intnl_SystemBoolean != null)
                {
                    return Private___189_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___189_intnl_SystemBoolean != null)
                    {
                        Private___189_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __8_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_const_intnl_SystemInt32 != null)
                {
                    return Private___8_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_const_intnl_SystemInt32 != null)
                    {
                        Private___8_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform[] __1_intnl_UnityEngineTransformArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineTransformArray != null)
                {
                    return Private___1_intnl_UnityEngineTransformArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineTransformArray != null)
                {
                    Private___1_intnl_UnityEngineTransformArray.Value = value;
                }
            }
        }

        internal uint? __52_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___52_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___52_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___52_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___52_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __4_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___4_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___4_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal float? prisRatio
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_prisRatio != null)
                {
                    return Private_prisRatio.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_prisRatio != null)
                    {
                        Private_prisRatio.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __30_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___30_intnl_SystemBoolean != null)
                {
                    return Private___30_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___30_intnl_SystemBoolean != null)
                    {
                        Private___30_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_updated_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_updated_Boolean != null)
                {
                    return Private___0_updated_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_updated_Boolean != null)
                    {
                        Private___0_updated_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __26_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___26_intnl_SystemInt32 != null)
                {
                    return Private___26_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___26_intnl_SystemInt32 != null)
                    {
                        Private___26_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __54_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___54_intnl_SystemBoolean != null)
                {
                    return Private___54_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___54_intnl_SystemBoolean != null)
                    {
                        Private___54_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __2_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemString != null)
                {
                    return Private___2_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_SystemString != null)
                {
                    Private___2_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? winState
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_winState != null)
                {
                    return Private_winState.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_winState != null)
                    {
                        Private_winState.Value = value.Value;
                    }
                }
            }
        }

        internal string __21_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_const_intnl_SystemString != null)
                {
                    return Private___21_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___21_const_intnl_SystemString != null)
                {
                    Private___21_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __51_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___51_const_intnl_SystemString != null)
                {
                    return Private___51_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___51_const_intnl_SystemString != null)
                {
                    Private___51_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __41_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___41_intnl_SystemInt32 != null)
                {
                    return Private___41_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___41_intnl_SystemInt32 != null)
                    {
                        Private___41_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __26_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___26_const_intnl_SystemString != null)
                {
                    return Private___26_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___26_const_intnl_SystemString != null)
                {
                    Private___26_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __56_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___56_const_intnl_SystemString != null)
                {
                    return Private___56_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___56_const_intnl_SystemString != null)
                {
                    Private___56_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal uint? __42_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___42_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___42_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___42_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___42_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __71_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___71_intnl_SystemBoolean != null)
                {
                    return Private___71_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___71_intnl_SystemBoolean != null)
                    {
                        Private___71_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __23_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_intnl_SystemString != null)
                {
                    return Private___23_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___23_intnl_SystemString != null)
                {
                    Private___23_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __117_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___117_intnl_SystemBoolean != null)
                {
                    return Private___117_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___117_intnl_SystemBoolean != null)
                    {
                        Private___117_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject winTitle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_winTitle != null)
                {
                    return Private_winTitle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_winTitle != null)
                {
                    Private_winTitle.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __9_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___9_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___9_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject countdownPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_countdownPanel != null)
                {
                    return Private_countdownPanel.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_countdownPanel != null)
                {
                    Private_countdownPanel.Value = value;
                }
            }
        }

        internal int? __0_players_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_players_Int32 != null)
                {
                    return Private___0_players_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_players_Int32 != null)
                    {
                        Private___0_players_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? timeRemaining
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timeRemaining != null)
                {
                    return Private_timeRemaining.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timeRemaining != null)
                    {
                        Private_timeRemaining.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __9_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___9_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___9_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __60_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___60_intnl_SystemBoolean != null)
                {
                    return Private___60_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___60_intnl_SystemBoolean != null)
                    {
                        Private___60_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __196_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___196_intnl_SystemBoolean != null)
                {
                    return Private___196_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___196_intnl_SystemBoolean != null)
                    {
                        Private___196_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __37_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_intnl_SystemBoolean != null)
                {
                    return Private___37_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___37_intnl_SystemBoolean != null)
                    {
                        Private___37_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __82_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___82_intnl_SystemBoolean != null)
                {
                    return Private___82_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___82_intnl_SystemBoolean != null)
                    {
                        Private___82_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __20_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___20_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___20_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___20_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __168_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___168_intnl_SystemBoolean != null)
                {
                    return Private___168_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___168_intnl_SystemBoolean != null)
                    {
                        Private___168_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject[] __1_intnl_UnityEngineGameObjectArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineGameObjectArray != null)
                {
                    return Private___1_intnl_UnityEngineGameObjectArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineGameObjectArray != null)
                {
                    Private___1_intnl_UnityEngineGameObjectArray.Value = value;
                }
            }
        }

        internal int? __9_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemInt32 != null)
                {
                    return Private___9_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_SystemInt32 != null)
                    {
                        Private___9_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __37_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_const_intnl_SystemString != null)
                {
                    return Private___37_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___37_const_intnl_SystemString != null)
                {
                    Private___37_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal float? __2_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemSingle != null)
                {
                    return Private___2_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemSingle != null)
                    {
                        Private___2_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal string __5_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_const_intnl_SystemString != null)
                {
                    return Private___5_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_const_intnl_SystemString != null)
                {
                    Private___5_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __3_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemBoolean != null)
                {
                    return Private___3_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemBoolean != null)
                    {
                        Private___3_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __147_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___147_intnl_SystemBoolean != null)
                {
                    return Private___147_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___147_intnl_SystemBoolean != null)
                    {
                        Private___147_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject prisText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_prisText != null)
                {
                    return Private_prisText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_prisText != null)
                {
                    Private_prisText.Value = value;
                }
            }
        }

        internal bool? __0_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___0_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___0_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __12_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_SystemBoolean != null)
                {
                    return Private___12_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_intnl_SystemBoolean != null)
                    {
                        Private___12_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __9_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemString != null)
                {
                    return Private___9_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_intnl_SystemString != null)
                {
                    Private___9_intnl_SystemString.Value = value;
                }
            }
        }

        internal long? __10_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_SystemObject != null)
                {
                    return Private___10_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_SystemObject != null)
                    {
                        Private___10_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __6_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___6_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___6_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __169_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___169_intnl_SystemBoolean != null)
                {
                    return Private___169_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___169_intnl_SystemBoolean != null)
                    {
                        Private___169_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __2_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_PlayerData != null)
                {
                    return Private___2_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_PlayerData != null)
                {
                    Private___2_intnl_PlayerData.Value = value;
                }
            }
        }

        internal string __18_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_intnl_SystemString != null)
                {
                    return Private___18_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___18_intnl_SystemString != null)
                {
                    Private___18_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __70_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___70_const_intnl_SystemString != null)
                {
                    return Private___70_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___70_const_intnl_SystemString != null)
                {
                    Private___70_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour doorControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_doorControl != null)
                {
                    return Private_doorControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_doorControl != null)
                {
                    Private_doorControl.Value = value;
                }
            }
        }

        internal bool? __190_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___190_intnl_SystemBoolean != null)
                {
                    return Private___190_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___190_intnl_SystemBoolean != null)
                    {
                        Private___190_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __67_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___67_intnl_SystemBoolean != null)
                {
                    return Private___67_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___67_intnl_SystemBoolean != null)
                    {
                        Private___67_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __23_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_const_intnl_SystemString != null)
                {
                    return Private___23_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___23_const_intnl_SystemString != null)
                {
                    Private___23_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __53_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___53_const_intnl_SystemString != null)
                {
                    return Private___53_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___53_const_intnl_SystemString != null)
                {
                    Private___53_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? hiddenSpectate
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hiddenSpectate != null)
                {
                    return Private_hiddenSpectate.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hiddenSpectate != null)
                    {
                        Private_hiddenSpectate.Value = value.Value;
                    }
                }
            }
        }

        internal int? __6_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemInt32 != null)
                {
                    return Private___6_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemInt32 != null)
                    {
                        Private___6_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __172_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___172_intnl_SystemBoolean != null)
                {
                    return Private___172_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___172_intnl_SystemBoolean != null)
                    {
                        Private___172_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __9_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_const_intnl_SystemInt32 != null)
                {
                    return Private___9_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_const_intnl_SystemInt32 != null)
                    {
                        Private___9_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? cachedTimeLimit
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedTimeLimit != null)
                {
                    return Private_cachedTimeLimit.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedTimeLimit != null)
                    {
                        Private_cachedTimeLimit.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __44_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___44_intnl_SystemBoolean != null)
                {
                    return Private___44_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___44_intnl_SystemBoolean != null)
                    {
                        Private___44_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __17_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_SystemSingle != null)
                {
                    return Private___17_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_intnl_SystemSingle != null)
                    {
                        Private___17_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal int? cachedWinState
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedWinState != null)
                {
                    return Private_cachedWinState.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedWinState != null)
                    {
                        Private_cachedWinState.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __191_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___191_intnl_SystemBoolean != null)
                {
                    return Private___191_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___191_intnl_SystemBoolean != null)
                    {
                        Private___191_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __29_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_intnl_SystemObject != null)
                {
                    return Private___29_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___29_intnl_SystemObject != null)
                {
                    Private___29_intnl_SystemObject.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject[] __0_intnl_UnityEngineGameObjectArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineGameObjectArray != null)
                {
                    return Private___0_intnl_UnityEngineGameObjectArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineGameObjectArray != null)
                {
                    Private___0_intnl_UnityEngineGameObjectArray.Value = value;
                }
            }
        }

        internal string __82_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___82_const_intnl_SystemString != null)
                {
                    return Private___82_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___82_const_intnl_SystemString != null)
                {
                    Private___82_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __72_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___72_intnl_SystemBoolean != null)
                {
                    return Private___72_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___72_intnl_SystemBoolean != null)
                    {
                        Private___72_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __6_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemString != null)
                {
                    return Private___6_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___6_intnl_SystemString != null)
                {
                    Private___6_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __0_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemBoolean != null)
                {
                    return Private___0_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemBoolean != null)
                    {
                        Private___0_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __9_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_PlayerData != null)
                {
                    return Private___9_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_intnl_PlayerData != null)
                {
                    Private___9_intnl_PlayerData.Value = value;
                }
            }
        }

        internal uint? __34_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___34_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___34_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal float? __9_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemSingle != null)
                {
                    return Private___9_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_SystemSingle != null)
                    {
                        Private___9_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __102_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___102_intnl_SystemBoolean != null)
                {
                    return Private___102_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___102_intnl_SystemBoolean != null)
                    {
                        Private___102_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __71_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___71_const_intnl_SystemString != null)
                {
                    return Private___71_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___71_const_intnl_SystemString != null)
                {
                    Private___71_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __76_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___76_const_intnl_SystemString != null)
                {
                    return Private___76_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___76_const_intnl_SystemString != null)
                {
                    Private___76_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject startButtonDisabled
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_startButtonDisabled != null)
                {
                    return Private_startButtonDisabled.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_startButtonDisabled != null)
                {
                    Private_startButtonDisabled.Value = value;
                }
            }
        }

        internal string __22_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_intnl_SystemString != null)
                {
                    return Private___22_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___22_intnl_SystemString != null)
                {
                    Private___22_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __124_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___124_intnl_SystemBoolean != null)
                {
                    return Private___124_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___124_intnl_SystemBoolean != null)
                    {
                        Private___124_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool[] isGuard
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isGuard != null)
                {
                    return Private_isGuard.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_isGuard != null)
                {
                    Private_isGuard.Value = value;
                }
            }
        }

        internal string __12_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_const_intnl_SystemString != null)
                {
                    return Private___12_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___12_const_intnl_SystemString != null)
                {
                    Private___12_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal uint? __38_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___38_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___38_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___38_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___38_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __123_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___123_intnl_SystemBoolean != null)
                {
                    return Private___123_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___123_intnl_SystemBoolean != null)
                    {
                        Private___123_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __0_this_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_UnityEngineGameObject != null)
                {
                    return Private___0_this_intnl_UnityEngineGameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_UnityEngineGameObject != null)
                {
                    Private___0_this_intnl_UnityEngineGameObject.Value = value;
                }
            }
        }

        internal UnityEngine.Transform[] prisSpawns
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_prisSpawns != null)
                {
                    return Private_prisSpawns.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_prisSpawns != null)
                {
                    Private_prisSpawns.Value = value;
                }
            }
        }

        internal bool? __3_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemObject != null)
                {
                    return Private___3_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemObject != null)
                    {
                        Private___3_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal float? __23_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_intnl_SystemSingle != null)
                {
                    return Private___23_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___23_intnl_SystemSingle != null)
                    {
                        Private___23_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __0_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineGameObject != null)
                {
                    return Private___0_intnl_UnityEngineGameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineGameObject != null)
                {
                    Private___0_intnl_UnityEngineGameObject.Value = value;
                }
            }
        }

        internal bool? __125_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___125_intnl_SystemBoolean != null)
                {
                    return Private___125_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___125_intnl_SystemBoolean != null)
                    {
                        Private___125_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __62_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___62_const_intnl_SystemString != null)
                {
                    return Private___62_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___62_const_intnl_SystemString != null)
                {
                    Private___62_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __17_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_SystemObject != null)
                {
                    return Private___17_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_intnl_SystemObject != null)
                    {
                        Private___17_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __158_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___158_intnl_SystemBoolean != null)
                {
                    return Private___158_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___158_intnl_SystemBoolean != null)
                    {
                        Private___158_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __8_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_const_intnl_SystemString != null)
                {
                    return Private___8_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_const_intnl_SystemString != null)
                {
                    Private___8_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal float? __6_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemSingle != null)
                {
                    return Private___6_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemSingle != null)
                    {
                        Private___6_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __4_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___4_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___4_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal uint? __33_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___33_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___33_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___33_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __18_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_intnl_SystemObject != null)
                {
                    return Private___18_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___18_intnl_SystemObject != null)
                {
                    Private___18_intnl_SystemObject.Value = value;
                }
            }
        }

        internal UnityEngine.Quaternion? __0_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineQuaternion != null)
                {
                    return Private___0_intnl_UnityEngineQuaternion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_UnityEngineQuaternion != null)
                    {
                        Private___0_intnl_UnityEngineQuaternion.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __9_pData_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_pData_PlayerData != null)
                {
                    return Private___9_pData_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_pData_PlayerData != null)
                {
                    Private___9_pData_PlayerData.Value = value;
                }
            }
        }

        internal float? __24_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_intnl_SystemSingle != null)
                {
                    return Private___24_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___24_intnl_SystemSingle != null)
                    {
                        Private___24_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __159_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___159_intnl_SystemBoolean != null)
                {
                    return Private___159_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___159_intnl_SystemBoolean != null)
                    {
                        Private___159_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __58_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___58_intnl_SystemBoolean != null)
                {
                    return Private___58_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___58_intnl_SystemBoolean != null)
                    {
                        Private___58_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __15_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_PlayerData != null)
                {
                    return Private___15_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___15_intnl_PlayerData != null)
                {
                    Private___15_intnl_PlayerData.Value = value;
                }
            }
        }

        internal bool? __137_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___137_intnl_SystemBoolean != null)
                {
                    return Private___137_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___137_intnl_SystemBoolean != null)
                    {
                        Private___137_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi onPlayerJoinedPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_onPlayerJoinedPlayer != null)
                {
                    return Private_onPlayerJoinedPlayer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_onPlayerJoinedPlayer != null)
                {
                    Private_onPlayerJoinedPlayer.Value = value;
                }
            }
        }

        internal string __24_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_intnl_SystemString != null)
                {
                    return Private___24_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___24_intnl_SystemString != null)
                {
                    Private___24_intnl_SystemString.Value = value;
                }
            }
        }

        internal float? gameStartTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameStartTime != null)
                {
                    return Private_gameStartTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameStartTime != null)
                    {
                        Private_gameStartTime.Value = value.Value;
                    }
                }
            }
        }

        internal string __73_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___73_const_intnl_SystemString != null)
                {
                    return Private___73_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___73_const_intnl_SystemString != null)
                {
                    Private___73_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour patronControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_patronControl != null)
                {
                    return Private_patronControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_patronControl != null)
                {
                    Private_patronControl.Value = value;
                }
            }
        }

        internal uint? __15_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___15_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___15_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __4_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_PlayerData != null)
                {
                    return Private___4_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_PlayerData != null)
                {
                    Private___4_intnl_PlayerData.Value = value;
                }
            }
        }

        internal float? __16_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_SystemSingle != null)
                {
                    return Private___16_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___16_intnl_SystemSingle != null)
                    {
                        Private___16_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __3_intnl_VRCSDK3ComponentsVRCObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    return Private___3_intnl_VRCSDK3ComponentsVRCObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    Private___3_intnl_VRCSDK3ComponentsVRCObjectPool.Value = value;
                }
            }
        }

        internal long? __2_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemInt64 != null)
                {
                    return Private___2_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemInt64 != null)
                    {
                        Private___2_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __1_mp_player_VRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_player_VRCPlayerApi != null)
                {
                    return Private___1_mp_player_VRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_mp_player_VRCPlayerApi != null)
                {
                    Private___1_mp_player_VRCPlayerApi.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __4_pData_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_pData_PlayerData != null)
                {
                    return Private___4_pData_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_pData_PlayerData != null)
                {
                    Private___4_pData_PlayerData.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject timeLimitText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timeLimitText != null)
                {
                    return Private_timeLimitText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_timeLimitText != null)
                {
                    Private_timeLimitText.Value = value;
                }
            }
        }

        internal uint? __19_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___19_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___19_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __12_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_const_intnl_SystemInt32 != null)
                {
                    return Private___12_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_const_intnl_SystemInt32 != null)
                    {
                        Private___12_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __8_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___8_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___8_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal string __21_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_intnl_SystemString != null)
                {
                    return Private___21_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___21_intnl_SystemString != null)
                {
                    Private___21_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? timeoutSecs
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timeoutSecs != null)
                {
                    return Private_timeoutSecs.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timeoutSecs != null)
                    {
                        Private_timeoutSecs.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __114_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___114_intnl_SystemBoolean != null)
                {
                    return Private___114_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___114_intnl_SystemBoolean != null)
                    {
                        Private___114_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __13_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_SystemString != null)
                {
                    return Private___13_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___13_intnl_SystemString != null)
                {
                    Private___13_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __32_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_const_intnl_SystemString != null)
                {
                    return Private___32_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___32_const_intnl_SystemString != null)
                {
                    Private___32_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __5_intnl_interpolatedStr_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_interpolatedStr_String != null)
                {
                    return Private___5_intnl_interpolatedStr_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_interpolatedStr_String != null)
                {
                    Private___5_intnl_interpolatedStr_String.Value = value;
                }
            }
        }

        internal bool? __113_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___113_intnl_SystemBoolean != null)
                {
                    return Private___113_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___113_intnl_SystemBoolean != null)
                    {
                        Private___113_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_newPrisRatio_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newPrisRatio_Single != null)
                {
                    return Private___0_newPrisRatio_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newPrisRatio_Single != null)
                    {
                        Private___0_newPrisRatio_Single.Value = value.Value;
                    }
                }
            }
        }

        internal int? __29_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_intnl_SystemInt32 != null)
                {
                    return Private___29_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___29_intnl_SystemInt32 != null)
                    {
                        Private___29_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __35_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_intnl_SystemBoolean != null)
                {
                    return Private___35_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_intnl_SystemBoolean != null)
                    {
                        Private___35_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __8_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___8_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___8_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_rand_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_rand_Int32 != null)
                {
                    return Private___0_rand_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_rand_Int32 != null)
                    {
                        Private___0_rand_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __50_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___50_intnl_SystemBoolean != null)
                {
                    return Private___50_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___50_intnl_SystemBoolean != null)
                    {
                        Private___50_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __22_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_intnl_SystemSingle != null)
                {
                    return Private___22_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___22_intnl_SystemSingle != null)
                    {
                        Private___22_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __192_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___192_intnl_SystemBoolean != null)
                {
                    return Private___192_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___192_intnl_SystemBoolean != null)
                    {
                        Private___192_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __7_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemObject != null)
                {
                    return Private___7_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_SystemObject != null)
                    {
                        Private___7_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __22_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___22_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___22_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___22_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __115_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___115_intnl_SystemBoolean != null)
                {
                    return Private___115_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___115_intnl_SystemBoolean != null)
                    {
                        Private___115_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? joinError
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_joinError != null)
                {
                    return Private_joinError.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_joinError != null)
                    {
                        Private_joinError.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __24_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_intnl_SystemBoolean != null)
                {
                    return Private___24_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___24_intnl_SystemBoolean != null)
                    {
                        Private___24_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __9_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_const_intnl_SystemString != null)
                {
                    return Private___9_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_const_intnl_SystemString != null)
                {
                    Private___9_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __13_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_PlayerData != null)
                {
                    return Private___13_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___13_intnl_PlayerData != null)
                {
                    Private___13_intnl_PlayerData.Value = value;
                }
            }
        }

        internal int? __13_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_const_intnl_SystemInt32 != null)
                {
                    return Private___13_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_const_intnl_SystemInt32 != null)
                    {
                        Private___13_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemInt32 != null)
                {
                    return Private___0_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemInt32 != null)
                    {
                        Private___0_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal long? __9_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemInt64 != null)
                {
                    return Private___9_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_SystemInt64 != null)
                    {
                        Private___9_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_intnl_returnTarget_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnTarget_UInt32 != null)
                {
                    return Private___0_intnl_returnTarget_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnTarget_UInt32 != null)
                    {
                        Private___0_intnl_returnTarget_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __144_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___144_intnl_SystemBoolean != null)
                {
                    return Private___144_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___144_intnl_SystemBoolean != null)
                    {
                        Private___144_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? cachedGameStarted
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedGameStarted != null)
                {
                    return Private_cachedGameStarted.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedGameStarted != null)
                    {
                        Private_cachedGameStarted.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __48_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___48_intnl_SystemBoolean != null)
                {
                    return Private___48_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___48_intnl_SystemBoolean != null)
                    {
                        Private___48_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_mp_error_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_error_Boolean != null)
                {
                    return Private___0_mp_error_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_error_Boolean != null)
                    {
                        Private___0_mp_error_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject guardText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_guardText != null)
                {
                    return Private_guardText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_guardText != null)
                {
                    Private_guardText.Value = value;
                }
            }
        }

        internal bool? __143_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___143_intnl_SystemBoolean != null)
                {
                    return Private___143_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___143_intnl_SystemBoolean != null)
                    {
                        Private___143_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __30_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___30_intnl_SystemInt32 != null)
                {
                    return Private___30_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___30_intnl_SystemInt32 != null)
                    {
                        Private___30_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __45_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___45_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___45_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___45_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___45_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __44_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___44_const_intnl_SystemString != null)
                {
                    return Private___44_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___44_const_intnl_SystemString != null)
                {
                    Private___44_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __65_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___65_intnl_SystemBoolean != null)
                {
                    return Private___65_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___65_intnl_SystemBoolean != null)
                    {
                        Private___65_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __92_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___92_const_intnl_SystemString != null)
                {
                    return Private___92_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___92_const_intnl_SystemString != null)
                {
                    Private___92_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __0_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemString != null)
                {
                    return Private___0_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_SystemString != null)
                {
                    Private___0_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __33_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_intnl_SystemBoolean != null)
                {
                    return Private___33_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___33_intnl_SystemBoolean != null)
                    {
                        Private___33_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __145_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___145_intnl_SystemBoolean != null)
                {
                    return Private___145_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___145_intnl_SystemBoolean != null)
                    {
                        Private___145_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __57_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___57_intnl_SystemBoolean != null)
                {
                    return Private___57_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___57_intnl_SystemBoolean != null)
                    {
                        Private___57_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __33_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_intnl_SystemInt32 != null)
                {
                    return Private___33_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___33_intnl_SystemInt32 != null)
                    {
                        Private___33_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __10_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_SystemInt32 != null)
                {
                    return Private___10_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_SystemInt32 != null)
                    {
                        Private___10_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __49_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___49_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___49_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___49_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___49_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __126_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___126_intnl_SystemBoolean != null)
                {
                    return Private___126_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___126_intnl_SystemBoolean != null)
                    {
                        Private___126_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_const_intnl_SystemUInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemUInt32 != null)
                {
                    return Private___0_const_intnl_SystemUInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemUInt32 != null)
                    {
                        Private___0_const_intnl_SystemUInt32.Value = value.Value;
                    }
                }
            }
        }

        internal long? __6_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemInt64 != null)
                {
                    return Private___6_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemInt64 != null)
                    {
                        Private___6_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __178_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___178_intnl_SystemBoolean != null)
                {
                    return Private___178_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___178_intnl_SystemBoolean != null)
                    {
                        Private___178_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject[] __8_intnl_UnityEngineGameObjectArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_UnityEngineGameObjectArray != null)
                {
                    return Private___8_intnl_UnityEngineGameObjectArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_intnl_UnityEngineGameObjectArray != null)
                {
                    Private___8_intnl_UnityEngineGameObjectArray.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __16_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_PlayerData != null)
                {
                    return Private___16_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___16_intnl_PlayerData != null)
                {
                    Private___16_intnl_PlayerData.Value = value;
                }
            }
        }

        internal bool? __9_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_SystemBoolean != null)
                {
                    return Private___9_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___9_intnl_SystemBoolean != null)
                    {
                        Private___9_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __19_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_intnl_SystemObject != null)
                {
                    return Private___19_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_intnl_SystemObject != null)
                    {
                        Private___19_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal int? __13_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_SystemInt32 != null)
                {
                    return Private___13_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_intnl_SystemInt32 != null)
                    {
                        Private___13_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __36_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___36_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___36_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___36_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __45_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___45_const_intnl_SystemString != null)
                {
                    return Private___45_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___45_const_intnl_SystemString != null)
                {
                    Private___45_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __63_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___63_intnl_SystemBoolean != null)
                {
                    return Private___63_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___63_intnl_SystemBoolean != null)
                    {
                        Private___63_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __36_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_intnl_SystemBoolean != null)
                {
                    return Private___36_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___36_intnl_SystemBoolean != null)
                    {
                        Private___36_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __179_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___179_intnl_SystemBoolean != null)
                {
                    return Private___179_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___179_intnl_SystemBoolean != null)
                    {
                        Private___179_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __88_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___88_const_intnl_SystemString != null)
                {
                    return Private___88_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___88_const_intnl_SystemString != null)
                {
                    Private___88_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject spectatePanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_spectatePanel != null)
                {
                    return Private_spectatePanel.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_spectatePanel != null)
                {
                    Private_spectatePanel.Value = value;
                }
            }
        }

        internal float? __0_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemSingle != null)
                {
                    return Private___0_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemSingle != null)
                    {
                        Private___0_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __108_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___108_intnl_SystemBoolean != null)
                {
                    return Private___108_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___108_intnl_SystemBoolean != null)
                    {
                        Private___108_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __12_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_SystemString != null)
                {
                    return Private___12_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___12_intnl_SystemString != null)
                {
                    Private___12_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __40_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___40_intnl_SystemBoolean != null)
                {
                    return Private___40_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___40_intnl_SystemBoolean != null)
                    {
                        Private___40_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __120_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___120_intnl_SystemBoolean != null)
                {
                    return Private___120_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___120_intnl_SystemBoolean != null)
                    {
                        Private___120_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __94_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___94_intnl_SystemBoolean != null)
                {
                    return Private___94_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___94_intnl_SystemBoolean != null)
                    {
                        Private___94_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __25_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___25_intnl_SystemInt32 != null)
                {
                    return Private___25_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___25_intnl_SystemInt32 != null)
                    {
                        Private___25_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __18_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_const_intnl_SystemString != null)
                {
                    return Private___18_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___18_const_intnl_SystemString != null)
                {
                    Private___18_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __109_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___109_intnl_SystemBoolean != null)
                {
                    return Private___109_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___109_intnl_SystemBoolean != null)
                    {
                        Private___109_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __40_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___40_intnl_SystemInt32 != null)
                {
                    return Private___40_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___40_intnl_SystemInt32 != null)
                    {
                        Private___40_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal float? __13_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_SystemSingle != null)
                {
                    return Private___13_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_intnl_SystemSingle != null)
                    {
                        Private___13_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Slider prisRatioSlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_prisRatioSlider != null)
                {
                    return Private_prisRatioSlider.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_prisRatioSlider != null)
                {
                    Private_prisRatioSlider.Value = value;
                }
            }
        }

        internal bool? __66_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___66_intnl_SystemBoolean != null)
                {
                    return Private___66_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___66_intnl_SystemBoolean != null)
                    {
                        Private___66_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __121_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___121_intnl_SystemBoolean != null)
                {
                    return Private___121_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___121_intnl_SystemBoolean != null)
                    {
                        Private___121_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __22_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_intnl_SystemInt32 != null)
                {
                    return Private___22_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___22_intnl_SystemInt32 != null)
                    {
                        Private___22_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __4_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemInt32 != null)
                {
                    return Private___4_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_SystemInt32 != null)
                    {
                        Private___4_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __187_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___187_intnl_SystemBoolean != null)
                {
                    return Private___187_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___187_intnl_SystemBoolean != null)
                    {
                        Private___187_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __89_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___89_const_intnl_SystemString != null)
                {
                    return Private___89_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___89_const_intnl_SystemString != null)
                {
                    Private___89_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __68_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___68_const_intnl_SystemString != null)
                {
                    return Private___68_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___68_const_intnl_SystemString != null)
                {
                    Private___68_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal float? __14_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_SystemSingle != null)
                {
                    return Private___14_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_intnl_SystemSingle != null)
                    {
                        Private___14_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __47_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___47_intnl_SystemBoolean != null)
                {
                    return Private___47_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___47_intnl_SystemBoolean != null)
                    {
                        Private___47_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour gateControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gateControl != null)
                {
                    return Private_gateControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_gateControl != null)
                {
                    Private_gateControl.Value = value;
                }
            }
        }

        internal string __4_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemString != null)
                {
                    return Private___4_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_SystemString != null)
                {
                    Private___4_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __134_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___134_intnl_SystemBoolean != null)
                {
                    return Private___134_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___134_intnl_SystemBoolean != null)
                    {
                        Private___134_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject masterText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_masterText != null)
                {
                    return Private_masterText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_masterText != null)
                {
                    Private_masterText.Value = value;
                }
            }
        }

        internal string __47_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___47_const_intnl_SystemString != null)
                {
                    return Private___47_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___47_const_intnl_SystemString != null)
                {
                    Private___47_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __133_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___133_intnl_SystemBoolean != null)
                {
                    return Private___133_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___133_intnl_SystemBoolean != null)
                    {
                        Private___133_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour spectatorDisplay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_spectatorDisplay != null)
                {
                    return Private_spectatorDisplay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_spectatorDisplay != null)
                {
                    Private_spectatorDisplay.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __4_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_UnityEngineTransform != null)
                {
                    return Private___4_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_UnityEngineTransform != null)
                {
                    Private___4_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        internal string __14_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_SystemString != null)
                {
                    return Private___14_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___14_intnl_SystemString != null)
                {
                    Private___14_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __10_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_const_intnl_SystemInt32 != null)
                {
                    return Private___10_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_const_intnl_SystemInt32 != null)
                    {
                        Private___10_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __19_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_const_intnl_SystemString != null)
                {
                    return Private___19_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___19_const_intnl_SystemString != null)
                {
                    Private___19_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal uint? __17_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___17_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___17_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __7_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___7_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___7_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal bool? __116_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___116_intnl_SystemBoolean != null)
                {
                    return Private___116_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___116_intnl_SystemBoolean != null)
                    {
                        Private___116_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject startTimeoutText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_startTimeoutText != null)
                {
                    return Private_startTimeoutText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_startTimeoutText != null)
                {
                    Private_startTimeoutText.Value = value;
                }
            }
        }

        internal bool? __135_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___135_intnl_SystemBoolean != null)
                {
                    return Private___135_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___135_intnl_SystemBoolean != null)
                    {
                        Private___135_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __30_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___30_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___30_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___30_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___30_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __39_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___39_intnl_SystemBoolean != null)
                {
                    return Private___39_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___39_intnl_SystemBoolean != null)
                    {
                        Private___39_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __69_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___69_const_intnl_SystemString != null)
                {
                    return Private___69_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___69_const_intnl_SystemString != null)
                {
                    Private___69_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __0_prisoners_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_prisoners_Int32 != null)
                {
                    return Private___0_prisoners_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_prisoners_Int32 != null)
                    {
                        Private___0_prisoners_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __28_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___28_intnl_SystemBoolean != null)
                {
                    return Private___28_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___28_intnl_SystemBoolean != null)
                    {
                        Private___28_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __36_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_intnl_SystemInt32 != null)
                {
                    return Private___36_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___36_intnl_SystemInt32 != null)
                    {
                        Private___36_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_pData_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_pData_PlayerData != null)
                {
                    return Private___0_pData_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_pData_PlayerData != null)
                {
                    Private___0_pData_PlayerData.Value = value;
                }
            }
        }

        internal bool? __6_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemBoolean != null)
                {
                    return Private___6_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemBoolean != null)
                    {
                        Private___6_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject startPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_startPanel != null)
                {
                    return Private_startPanel.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_startPanel != null)
                {
                    Private_startPanel.Value = value;
                }
            }
        }

        internal float? __20_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_intnl_SystemSingle != null)
                {
                    return Private___20_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___20_intnl_SystemSingle != null)
                    {
                        Private___20_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal float? __4_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemSingle != null)
                {
                    return Private___4_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_SystemSingle != null)
                    {
                        Private___4_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal string __11_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_SystemString != null)
                {
                    return Private___11_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___11_intnl_SystemString != null)
                {
                    Private___11_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __146_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___146_intnl_SystemBoolean != null)
                {
                    return Private___146_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___146_intnl_SystemBoolean != null)
                    {
                        Private___146_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __1_intnl_VRCSDK3ComponentsVRCObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    return Private___1_intnl_VRCSDK3ComponentsVRCObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    Private___1_intnl_VRCSDK3ComponentsVRCObjectPool.Value = value;
                }
            }
        }

        internal bool? __84_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___84_intnl_SystemBoolean != null)
                {
                    return Private___84_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___84_intnl_SystemBoolean != null)
                    {
                        Private___84_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __110_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___110_intnl_SystemBoolean != null)
                {
                    return Private___110_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___110_intnl_SystemBoolean != null)
                    {
                        Private___110_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __24_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_const_intnl_SystemString != null)
                {
                    return Private___24_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___24_const_intnl_SystemString != null)
                {
                    Private___24_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __54_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___54_const_intnl_SystemString != null)
                {
                    return Private___54_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___54_const_intnl_SystemString != null)
                {
                    Private___54_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __16_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_SystemInt32 != null)
                {
                    return Private___16_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___16_intnl_SystemInt32 != null)
                    {
                        Private___16_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __69_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___69_intnl_SystemBoolean != null)
                {
                    return Private___69_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___69_intnl_SystemBoolean != null)
                    {
                        Private___69_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __167_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___167_intnl_SystemBoolean != null)
                {
                    return Private___167_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___167_intnl_SystemBoolean != null)
                    {
                        Private___167_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __12_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_SystemSingle != null)
                {
                    return Private___12_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___12_intnl_SystemSingle != null)
                    {
                        Private___12_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal string __38_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___38_const_intnl_SystemString != null)
                {
                    return Private___38_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___38_const_intnl_SystemString != null)
                {
                    Private___38_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __198_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___198_intnl_SystemBoolean != null)
                {
                    return Private___198_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___198_intnl_SystemBoolean != null)
                    {
                        Private___198_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __14_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_SystemBoolean != null)
                {
                    return Private___14_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_intnl_SystemBoolean != null)
                    {
                        Private___14_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_guards_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_guards_Int32 != null)
                {
                    return Private___1_guards_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_guards_Int32 != null)
                    {
                        Private___1_guards_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour lootCrateControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lootCrateControl != null)
                {
                    return Private_lootCrateControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_lootCrateControl != null)
                {
                    Private_lootCrateControl.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour openableControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_openableControl != null)
                {
                    return Private_openableControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_openableControl != null)
                {
                    Private_openableControl.Value = value;
                }
            }
        }

        internal bool? __111_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___111_intnl_SystemBoolean != null)
                {
                    return Private___111_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___111_intnl_SystemBoolean != null)
                    {
                        Private___111_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __2_obj_GameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_obj_GameObject != null)
                {
                    return Private___2_obj_GameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_obj_GameObject != null)
                {
                    Private___2_obj_GameObject.Value = value;
                }
            }
        }

        internal long? __0_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemInt64 != null)
                {
                    return Private___0_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemInt64 != null)
                    {
                        Private___0_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __140_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___140_intnl_SystemBoolean != null)
                {
                    return Private___140_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___140_intnl_SystemBoolean != null)
                    {
                        Private___140_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __10_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___10_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___10_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___10_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal uint? __47_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___47_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___47_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___47_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___47_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __3_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemInt32 != null)
                {
                    return Private___3_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemInt32 != null)
                    {
                        Private___3_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __31_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_intnl_SystemBoolean != null)
                {
                    return Private___31_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___31_intnl_SystemBoolean != null)
                    {
                        Private___31_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __199_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___199_intnl_SystemBoolean != null)
                {
                    return Private___199_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___199_intnl_SystemBoolean != null)
                    {
                        Private___199_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __55_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___55_intnl_SystemBoolean != null)
                {
                    return Private___55_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___55_intnl_SystemBoolean != null)
                    {
                        Private___55_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __25_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___25_const_intnl_SystemString != null)
                {
                    return Private___25_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___25_const_intnl_SystemString != null)
                {
                    Private___25_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __55_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___55_const_intnl_SystemString != null)
                {
                    return Private___55_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___55_const_intnl_SystemString != null)
                {
                    Private___55_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __5_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_UnityEngineGameObject != null)
                {
                    return Private___5_intnl_UnityEngineGameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_UnityEngineGameObject != null)
                {
                    Private___5_intnl_UnityEngineGameObject.Value = value;
                }
            }
        }

        internal uint? __11_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___11_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___11_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___11_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __8_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemBoolean != null)
                {
                    return Private___8_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_SystemBoolean != null)
                    {
                        Private___8_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __1_intnl_interpolatedStr_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_interpolatedStr_String != null)
                {
                    return Private___1_intnl_interpolatedStr_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_interpolatedStr_String != null)
                {
                    Private___1_intnl_interpolatedStr_String.Value = value;
                }
            }
        }

        internal bool? __20_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_intnl_SystemBoolean != null)
                {
                    return Private___20_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___20_intnl_SystemBoolean != null)
                    {
                        Private___20_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __2_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineVector3 != null)
                {
                    return Private___2_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_UnityEngineVector3 != null)
                    {
                        Private___2_intnl_UnityEngineVector3.Value = value.Value;
                    }
                }
            }
        }

        internal string __3_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemString != null)
                {
                    return Private___3_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_SystemString != null)
                {
                    Private___3_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __141_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___141_intnl_SystemBoolean != null)
                {
                    return Private___141_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___141_intnl_SystemBoolean != null)
                    {
                        Private___141_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __39_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___39_const_intnl_SystemString != null)
                {
                    return Private___39_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___39_const_intnl_SystemString != null)
                {
                    Private___39_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __74_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___74_intnl_SystemBoolean != null)
                {
                    return Private___74_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___74_intnl_SystemBoolean != null)
                    {
                        Private___74_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __7_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_UnityEngineTransform != null)
                {
                    return Private___7_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_UnityEngineTransform != null)
                {
                    Private___7_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemObject != null)
                {
                    return Private___1_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_SystemObject != null)
                {
                    Private___1_intnl_SystemObject.Value = value;
                }
            }
        }

        internal bool? __122_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___122_intnl_SystemBoolean != null)
                {
                    return Private___122_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___122_intnl_SystemBoolean != null)
                    {
                        Private___122_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_guard_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_guard_Boolean != null)
                {
                    return Private___0_guard_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_guard_Boolean != null)
                    {
                        Private___0_guard_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __25_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___25_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___25_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___25_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___25_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __33_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_intnl_SystemObject != null)
                {
                    return Private___33_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___33_intnl_SystemObject != null)
                    {
                        Private___33_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __61_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___61_intnl_SystemBoolean != null)
                {
                    return Private___61_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___61_intnl_SystemBoolean != null)
                    {
                        Private___61_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __98_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___98_intnl_SystemBoolean != null)
                {
                    return Private___98_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___98_intnl_SystemBoolean != null)
                    {
                        Private___98_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour afkDetector
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_afkDetector != null)
                {
                    return Private_afkDetector.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_afkDetector != null)
                {
                    Private_afkDetector.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __8_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_UnityEngineTransform != null)
                {
                    return Private___8_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_intnl_UnityEngineTransform != null)
                {
                    Private___8_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        internal uint? __29_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___29_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___29_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___29_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __1_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineVector3 != null)
                {
                    return Private___1_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_UnityEngineVector3 != null)
                    {
                        Private___1_intnl_UnityEngineVector3.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __53_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___53_intnl_SystemBoolean != null)
                {
                    return Private___53_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___53_intnl_SystemBoolean != null)
                    {
                        Private___53_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __4_intnl_interpolatedStr_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_interpolatedStr_String != null)
                {
                    return Private___4_intnl_interpolatedStr_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_interpolatedStr_String != null)
                {
                    Private___4_intnl_interpolatedStr_String.Value = value;
                }
            }
        }

        internal string __80_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___80_const_intnl_SystemString != null)
                {
                    return Private___80_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___80_const_intnl_SystemString != null)
                {
                    Private___80_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __27_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___27_intnl_SystemBoolean != null)
                {
                    return Private___27_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___27_intnl_SystemBoolean != null)
                    {
                        Private___27_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __19_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_intnl_SystemString != null)
                {
                    return Private___19_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___19_intnl_SystemString != null)
                {
                    Private___19_intnl_SystemString.Value = value;
                }
            }
        }

        internal uint? __51_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___51_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___51_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___51_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___51_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __2_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_const_intnl_SystemInt32 != null)
                {
                    return Private___2_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_const_intnl_SystemInt32 != null)
                    {
                        Private___2_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal float? __3_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemSingle != null)
                {
                    return Private___3_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemSingle != null)
                    {
                        Private___3_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal string __74_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___74_const_intnl_SystemString != null)
                {
                    return Private___74_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___74_const_intnl_SystemString != null)
                {
                    Private___74_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.Animator __0_intnl_UnityEngineAnimator
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineAnimator != null)
                {
                    return Private___0_intnl_UnityEngineAnimator.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineAnimator != null)
                {
                    Private___0_intnl_UnityEngineAnimator.Value = value;
                }
            }
        }

        internal bool? __157_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___157_intnl_SystemBoolean != null)
                {
                    return Private___157_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___157_intnl_SystemBoolean != null)
                    {
                        Private___157_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __136_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___136_intnl_SystemBoolean != null)
                {
                    return Private___136_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___136_intnl_SystemBoolean != null)
                    {
                        Private___136_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __27_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___27_const_intnl_SystemString != null)
                {
                    return Private___27_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___27_const_intnl_SystemString != null)
                {
                    Private___27_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __0_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineVector3 != null)
                {
                    return Private___0_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_UnityEngineVector3 != null)
                    {
                        Private___0_intnl_UnityEngineVector3.Value = value.Value;
                    }
                }
            }
        }

        internal string __57_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___57_const_intnl_SystemString != null)
                {
                    return Private___57_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___57_const_intnl_SystemString != null)
                {
                    Private___57_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __10_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_const_intnl_SystemString != null)
                {
                    return Private___10_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___10_const_intnl_SystemString != null)
                {
                    Private___10_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject[] __4_intnl_UnityEngineGameObjectArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_UnityEngineGameObjectArray != null)
                {
                    return Private___4_intnl_UnityEngineGameObjectArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_UnityEngineGameObjectArray != null)
                {
                    Private___4_intnl_UnityEngineGameObjectArray.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject[] prisObjects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_prisObjects != null)
                {
                    return Private_prisObjects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_prisObjects != null)
                {
                    Private_prisObjects.Value = value;
                }
            }
        }

        internal bool? __32_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_intnl_SystemBoolean != null)
                {
                    return Private___32_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___32_intnl_SystemBoolean != null)
                    {
                        Private___32_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __4_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_UnityEngineComponent != null)
                {
                    return Private___4_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_UnityEngineComponent != null)
                {
                    Private___4_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        internal long? __30_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___30_intnl_SystemObject != null)
                {
                    return Private___30_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___30_intnl_SystemObject != null)
                    {
                        Private___30_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __56_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___56_intnl_SystemBoolean != null)
                {
                    return Private___56_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___56_intnl_SystemBoolean != null)
                    {
                        Private___56_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __2_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___2_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___2_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal uint? __41_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___41_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___41_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___41_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___41_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __42_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___42_const_intnl_SystemString != null)
                {
                    return Private___42_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___42_const_intnl_SystemString != null)
                {
                    Private___42_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal float? __18_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_intnl_SystemSingle != null)
                {
                    return Private___18_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_intnl_SystemSingle != null)
                    {
                        Private___18_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __184_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___184_intnl_SystemBoolean != null)
                {
                    return Private___184_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___184_intnl_SystemBoolean != null)
                    {
                        Private___184_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __16_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_SystemObject != null)
                {
                    return Private___16_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___16_intnl_SystemObject != null)
                {
                    Private___16_intnl_SystemObject.Value = value;
                }
            }
        }

        internal long? __4_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemInt64 != null)
                {
                    return Private___4_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_SystemInt64 != null)
                    {
                        Private___4_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __45_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___45_intnl_SystemBoolean != null)
                {
                    return Private___45_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___45_intnl_SystemBoolean != null)
                    {
                        Private___45_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __81_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___81_const_intnl_SystemString != null)
                {
                    return Private___81_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___81_const_intnl_SystemString != null)
                {
                    Private___81_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __60_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___60_const_intnl_SystemString != null)
                {
                    return Private___60_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___60_const_intnl_SystemString != null)
                {
                    Private___60_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __183_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___183_intnl_SystemBoolean != null)
                {
                    return Private___183_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___183_intnl_SystemBoolean != null)
                    {
                        Private___183_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __28_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___28_intnl_SystemInt32 != null)
                {
                    return Private___28_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___28_intnl_SystemInt32 != null)
                    {
                        Private___28_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __7_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemInt32 != null)
                {
                    return Private___7_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_SystemInt32 != null)
                    {
                        Private___7_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __1_intnl_TMProTextMeshProUGUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_TMProTextMeshProUGUI != null)
                {
                    return Private___1_intnl_TMProTextMeshProUGUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_TMProTextMeshProUGUI != null)
                {
                    Private___1_intnl_TMProTextMeshProUGUI.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __0_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineTransform != null)
                {
                    return Private___0_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineTransform != null)
                {
                    Private___0_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        internal string __86_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___86_const_intnl_SystemString != null)
                {
                    return Private___86_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___86_const_intnl_SystemString != null)
                {
                    Private___86_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __1_const_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_SystemBoolean != null)
                {
                    return Private___1_const_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_SystemBoolean != null)
                    {
                        Private___1_const_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform[] __0_mp_spawns_TransformArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_spawns_TransformArray != null)
                {
                    return Private___0_mp_spawns_TransformArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_spawns_TransformArray != null)
                {
                    Private___0_mp_spawns_TransformArray.Value = value;
                }
            }
        }

        internal bool? __90_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___90_intnl_SystemBoolean != null)
                {
                    return Private___90_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___90_intnl_SystemBoolean != null)
                    {
                        Private___90_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __75_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___75_const_intnl_SystemString != null)
                {
                    return Private___75_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___75_const_intnl_SystemString != null)
                {
                    Private___75_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __130_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___130_intnl_SystemBoolean != null)
                {
                    return Private___130_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___130_intnl_SystemBoolean != null)
                    {
                        Private___130_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __185_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___185_intnl_SystemBoolean != null)
                {
                    return Private___185_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___185_intnl_SystemBoolean != null)
                    {
                        Private___185_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __0_intnl_UnityEngineColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineColor != null)
                {
                    return Private___0_intnl_UnityEngineColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_UnityEngineColor != null)
                    {
                        Private___0_intnl_UnityEngineColor.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __3_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_PlayerData != null)
                {
                    return Private___3_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_PlayerData != null)
                {
                    Private___3_intnl_PlayerData.Value = value;
                }
            }
        }

        internal string __7_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemString != null)
                {
                    return Private___7_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_SystemString != null)
                {
                    Private___7_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __62_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___62_intnl_SystemBoolean != null)
                {
                    return Private___62_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___62_intnl_SystemBoolean != null)
                    {
                        Private___62_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __200_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___200_intnl_SystemBoolean != null)
                {
                    return Private___200_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___200_intnl_SystemBoolean != null)
                    {
                        Private___200_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __11_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_const_intnl_SystemString != null)
                {
                    return Private___11_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___11_const_intnl_SystemString != null)
                {
                    Private___11_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __16_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_const_intnl_SystemString != null)
                {
                    return Private___16_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___16_const_intnl_SystemString != null)
                {
                    Private___16_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __112_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___112_intnl_SystemBoolean != null)
                {
                    return Private___112_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___112_intnl_SystemBoolean != null)
                    {
                        Private___112_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __88_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___88_intnl_SystemBoolean != null)
                {
                    return Private___88_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___88_intnl_SystemBoolean != null)
                    {
                        Private___88_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __32_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___32_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___32_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___32_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal float? cachedPrisRatio
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedPrisRatio != null)
                {
                    return Private_cachedPrisRatio.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedPrisRatio != null)
                    {
                        Private_cachedPrisRatio.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform afkRespawn
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_afkRespawn != null)
                {
                    return Private_afkRespawn.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_afkRespawn != null)
                {
                    Private_afkRespawn.Value = value;
                }
            }
        }

        internal long? __0_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemInt64 != null)
                {
                    return Private___0_const_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemInt64 != null)
                    {
                        Private___0_const_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __131_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___131_intnl_SystemBoolean != null)
                {
                    return Private___131_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___131_intnl_SystemBoolean != null)
                    {
                        Private___131_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __43_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___43_intnl_SystemBoolean != null)
                {
                    return Private___43_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___43_intnl_SystemBoolean != null)
                    {
                        Private___43_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __61_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___61_const_intnl_SystemString != null)
                {
                    return Private___61_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___61_const_intnl_SystemString != null)
                {
                    Private___61_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __66_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___66_const_intnl_SystemString != null)
                {
                    return Private___66_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___66_const_intnl_SystemString != null)
                {
                    Private___66_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __5_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_UnityEngineTransform != null)
                {
                    return Private___5_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_UnityEngineTransform != null)
                {
                    Private___5_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        internal bool? __18_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_intnl_SystemBoolean != null)
                {
                    return Private___18_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_intnl_SystemBoolean != null)
                    {
                        Private___18_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __97_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___97_intnl_SystemBoolean != null)
                {
                    return Private___97_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___97_intnl_SystemBoolean != null)
                    {
                        Private___97_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __2_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemBoolean != null)
                {
                    return Private___2_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemBoolean != null)
                    {
                        Private___2_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal float? __10_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_SystemSingle != null)
                {
                    return Private___10_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_SystemSingle != null)
                    {
                        Private___10_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal float? __25_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___25_intnl_SystemSingle != null)
                {
                    return Private___25_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___25_intnl_SystemSingle != null)
                    {
                        Private___25_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __14_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___14_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___14_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __142_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___142_intnl_SystemBoolean != null)
                {
                    return Private___142_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___142_intnl_SystemBoolean != null)
                    {
                        Private___142_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __83_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___83_const_intnl_SystemString != null)
                {
                    return Private___83_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___83_const_intnl_SystemString != null)
                {
                    Private___83_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __3_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_const_intnl_SystemInt32 != null)
                {
                    return Private___3_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_const_intnl_SystemInt32 != null)
                    {
                        Private___3_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal float? __7_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemSingle != null)
                {
                    return Private___7_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_intnl_SystemSingle != null)
                    {
                        Private___7_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __37_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_intnl_SystemObject != null)
                {
                    return Private___37_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___37_intnl_SystemObject != null)
                    {
                        Private___37_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.Common.Interfaces.NetworkEventTarget? __0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget != null)
                {
                    return Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget != null)
                    {
                        Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __164_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___164_intnl_SystemBoolean != null)
                {
                    return Private___164_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___164_intnl_SystemBoolean != null)
                    {
                        Private___164_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __59_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___59_intnl_SystemBoolean != null)
                {
                    return Private___59_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___59_intnl_SystemBoolean != null)
                    {
                        Private___59_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __163_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___163_intnl_SystemBoolean != null)
                {
                    return Private___163_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___163_intnl_SystemBoolean != null)
                    {
                        Private___163_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __18_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___18_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___18_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __46_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___46_intnl_SystemBoolean != null)
                {
                    return Private___46_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___46_intnl_SystemBoolean != null)
                    {
                        Private___46_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __17_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_SystemString != null)
                {
                    return Private___17_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___17_intnl_SystemString != null)
                {
                    Private___17_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __39_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___39_intnl_SystemInt32 != null)
                {
                    return Private___39_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___39_intnl_SystemInt32 != null)
                    {
                        Private___39_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour playerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerObjectPool != null)
                {
                    return Private_playerObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerObjectPool != null)
                {
                    Private_playerObjectPool.Value = value;
                }
            }
        }

        internal string __77_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___77_const_intnl_SystemString != null)
                {
                    return Private___77_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___77_const_intnl_SystemString != null)
                {
                    Private___77_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __30_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___30_const_intnl_SystemString != null)
                {
                    return Private___30_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___30_const_intnl_SystemString != null)
                {
                    Private___30_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __13_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_const_intnl_SystemString != null)
                {
                    return Private___13_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___13_const_intnl_SystemString != null)
                {
                    Private___13_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __78_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___78_intnl_SystemBoolean != null)
                {
                    return Private___78_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___78_intnl_SystemBoolean != null)
                    {
                        Private___78_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __8_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemInt32 != null)
                {
                    return Private___8_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_SystemInt32 != null)
                    {
                        Private___8_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? guardHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_guardHealth != null)
                {
                    return Private_guardHealth.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_guardHealth != null)
                    {
                        Private_guardHealth.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __165_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___165_intnl_SystemBoolean != null)
                {
                    return Private___165_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___165_intnl_SystemBoolean != null)
                    {
                        Private___165_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __7_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_UnityEngineComponent != null)
                {
                    return Private___7_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_UnityEngineComponent != null)
                {
                    Private___7_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        internal int? __0_randomIndex_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_randomIndex_Int32 != null)
                {
                    return Private___0_randomIndex_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_randomIndex_Int32 != null)
                    {
                        Private___0_randomIndex_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __80_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___80_intnl_SystemBoolean != null)
                {
                    return Private___80_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___80_intnl_SystemBoolean != null)
                    {
                        Private___80_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __19_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_intnl_SystemInt32 != null)
                {
                    return Private___19_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_intnl_SystemInt32 != null)
                    {
                        Private___19_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject winPanel
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_winPanel != null)
                {
                    return Private_winPanel.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_winPanel != null)
                {
                    Private_winPanel.Value = value;
                }
            }
        }

        internal int? __24_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_intnl_SystemInt32 != null)
                {
                    return Private___24_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___24_intnl_SystemInt32 != null)
                    {
                        Private___24_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __63_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___63_const_intnl_SystemString != null)
                {
                    return Private___63_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___63_const_intnl_SystemString != null)
                {
                    Private___63_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __8_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemString != null)
                {
                    return Private___8_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_intnl_SystemString != null)
                {
                    Private___8_intnl_SystemString.Value = value;
                }
            }
        }

        internal long? __3_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemInt64 != null)
                {
                    return Private___3_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemInt64 != null)
                    {
                        Private___3_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDK3.Components.VRCObjectPool __15_intnl_VRCSDK3ComponentsVRCObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    return Private___15_intnl_VRCSDK3ComponentsVRCObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___15_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    Private___15_intnl_VRCSDK3ComponentsVRCObjectPool.Value = value;
                }
            }
        }

        internal uint? __13_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___13_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___13_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___13_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __3_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_UnityEngineTransform != null)
                {
                    return Private___3_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_UnityEngineTransform != null)
                {
                    Private___3_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        internal string __0_timeText_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_timeText_String != null)
                {
                    return Private___0_timeText_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_timeText_String != null)
                {
                    Private___0_timeText_String.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __2_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineGameObject != null)
                {
                    return Private___2_intnl_UnityEngineGameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineGameObject != null)
                {
                    Private___2_intnl_UnityEngineGameObject.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject[] guardObjects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_guardObjects != null)
                {
                    return Private_guardObjects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_guardObjects != null)
                {
                    Private_guardObjects.Value = value;
                }
            }
        }

        internal bool? __10_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___10_intnl_SystemBoolean != null)
                {
                    return Private___10_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___10_intnl_SystemBoolean != null)
                    {
                        Private___10_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __34_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_intnl_SystemObject != null)
                {
                    return Private___34_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_intnl_SystemObject != null)
                    {
                        Private___34_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal string __90_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___90_const_intnl_SystemString != null)
                {
                    return Private___90_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___90_const_intnl_SystemString != null)
                {
                    Private___90_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __177_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___177_intnl_SystemBoolean != null)
                {
                    return Private___177_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___177_intnl_SystemBoolean != null)
                    {
                        Private___177_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __2_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_const_intnl_SystemString != null)
                {
                    return Private___2_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_const_intnl_SystemString != null)
                {
                    Private___2_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal string __31_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_const_intnl_SystemString != null)
                {
                    return Private___31_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___31_const_intnl_SystemString != null)
                {
                    Private___31_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __31_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_intnl_SystemObject != null)
                {
                    return Private___31_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___31_intnl_SystemObject != null)
                {
                    Private___31_intnl_SystemObject.Value = value;
                }
            }
        }

        internal int? __21_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_intnl_SystemInt32 != null)
                {
                    return Private___21_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___21_intnl_SystemInt32 != null)
                    {
                        Private___21_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __27_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___27_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___27_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___27_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___27_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __27_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___27_intnl_SystemInt32 != null)
                {
                    return Private___27_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___27_intnl_SystemInt32 != null)
                    {
                        Private___27_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __36_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_const_intnl_SystemString != null)
                {
                    return Private___36_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___36_const_intnl_SystemString != null)
                {
                    Private___36_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __4_intnl_UnityEngineComponentArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_UnityEngineComponentArray != null)
                {
                    return Private___4_intnl_UnityEngineComponentArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_UnityEngineComponentArray != null)
                {
                    Private___4_intnl_UnityEngineComponentArray.Value = value;
                }
            }
        }

        internal long? __1_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_SystemInt64 != null)
                {
                    return Private___1_const_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_SystemInt64 != null)
                    {
                        Private___1_const_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __44_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___44_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___44_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___44_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___44_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __128_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___128_intnl_SystemBoolean != null)
                {
                    return Private___128_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___128_intnl_SystemBoolean != null)
                    {
                        Private___128_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __5_pData_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_pData_PlayerData != null)
                {
                    return Private___5_pData_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_pData_PlayerData != null)
                {
                    Private___5_pData_PlayerData.Value = value;
                }
            }
        }

        internal bool? __87_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___87_intnl_SystemBoolean != null)
                {
                    return Private___87_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___87_intnl_SystemBoolean != null)
                    {
                        Private___87_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __51_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___51_intnl_SystemBoolean != null)
                {
                    return Private___51_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___51_intnl_SystemBoolean != null)
                    {
                        Private___51_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? displayWinner
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_displayWinner != null)
                {
                    return Private_displayWinner.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_displayWinner != null)
                    {
                        Private_displayWinner.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemInt32 != null)
                {
                    return Private___0_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemInt32 != null)
                    {
                        Private___0_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __107_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___107_intnl_SystemBoolean != null)
                {
                    return Private___107_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___107_intnl_SystemBoolean != null)
                    {
                        Private___107_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __1_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___1_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___1_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __25_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___25_intnl_SystemBoolean != null)
                {
                    return Private___25_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___25_intnl_SystemBoolean != null)
                    {
                        Private___25_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_guardCount_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_guardCount_Int32 != null)
                {
                    return Private___0_guardCount_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_guardCount_Int32 != null)
                    {
                        Private___0_guardCount_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __48_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___48_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___48_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___48_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___48_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string __22_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_const_intnl_SystemString != null)
                {
                    return Private___22_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___22_const_intnl_SystemString != null)
                {
                    Private___22_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal float? __8_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemSingle != null)
                {
                    return Private___8_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_SystemSingle != null)
                    {
                        Private___8_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal string __52_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___52_const_intnl_SystemString != null)
                {
                    return Private___52_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___52_const_intnl_SystemString != null)
                {
                    Private___52_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __70_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___70_intnl_SystemBoolean != null)
                {
                    return Private___70_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___70_intnl_SystemBoolean != null)
                    {
                        Private___70_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __129_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___129_intnl_SystemBoolean != null)
                {
                    return Private___129_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___129_intnl_SystemBoolean != null)
                    {
                        Private___129_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __0_obj_GameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_obj_GameObject != null)
                {
                    return Private___0_obj_GameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_obj_GameObject != null)
                {
                    Private___0_obj_GameObject.Value = value;
                }
            }
        }

        internal bool? __186_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___186_intnl_SystemBoolean != null)
                {
                    return Private___186_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___186_intnl_SystemBoolean != null)
                    {
                        Private___186_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __17_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_SystemBoolean != null)
                {
                    return Private___17_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_intnl_SystemBoolean != null)
                    {
                        Private___17_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_prisCount_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_prisCount_Int32 != null)
                {
                    return Private___1_prisCount_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_prisCount_Int32 != null)
                    {
                        Private___1_prisCount_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __49_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___49_intnl_SystemBoolean != null)
                {
                    return Private___49_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___49_intnl_SystemBoolean != null)
                    {
                        Private___49_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __91_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___91_const_intnl_SystemString != null)
                {
                    return Private___91_const_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___91_const_intnl_SystemString != null)
                {
                    Private___91_const_intnl_SystemString.Value = value;
                }
            }
        }

        internal int? __0_intnl_returnValSymbol_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_Int32 != null)
                {
                    return Private___0_intnl_returnValSymbol_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_Int32 != null)
                    {
                        Private___0_intnl_returnValSymbol_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineComponent != null)
                {
                    return Private___0_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineComponent != null)
                {
                    Private___0_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        internal bool? __154_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___154_intnl_SystemBoolean != null)
                {
                    return Private___154_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___154_intnl_SystemBoolean != null)
                    {
                        Private___154_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal string __16_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_intnl_SystemString != null)
                {
                    return Private___16_intnl_SystemString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___16_intnl_SystemString != null)
                {
                    Private___16_intnl_SystemString.Value = value;
                }
            }
        }

        internal bool? __153_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___153_intnl_SystemBoolean != null)
                {
                    return Private___153_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___153_intnl_SystemBoolean != null)
                    {
                        Private___153_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __132_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___132_intnl_SystemBoolean != null)
                {
                    return Private___132_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___132_intnl_SystemBoolean != null)
                    {
                        Private___132_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __9_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___9_intnl_UnityEngineTransform != null)
                {
                    return Private___9_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___9_intnl_UnityEngineTransform != null)
                {
                    Private___9_intnl_UnityEngineTransform.Value = value;
                }
            }
        }

        #endregion Getter / Setters UdonVariables  of GameData



        internal void Initialize_GameData()
        {
            Private___3_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__3_intnl_interpolatedStr_String");
            Private___6_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__6_intnl_UnityEngineTransform");
            Private___35_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__35_intnl_SystemInt32");
            Private___43_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__43_const_intnl_exitJumpLoc_UInt32");
            Private_updatedTeams = new AstroUdonVariable<bool>(GameData, "updatedTeams");
            Private___33_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__33_const_intnl_SystemString");
            Private___0_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__0_intnl_TMProTextMeshProUGUI");
            Private___0_newTimeLimit_Int32 = new AstroUdonVariable<int>(GameData, "__0_newTimeLimit_Int32");
            Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__23_intnl_SystemBoolean");
            Private___10_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__10_pData_PlayerData");
            Private___0_guards_Int32 = new AstroUdonVariable<int>(GameData, "__0_guards_Int32");
            Private___155_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__155_intnl_SystemBoolean");
            Private___0_playerDataObj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__0_playerDataObj_GameObject");
            Private___32_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__32_intnl_SystemInt32");
            Private___180_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__180_intnl_SystemBoolean");
            Private___77_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__77_intnl_SystemBoolean");
            Private___8_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__8_intnl_PlayerData");
            Private___48_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__48_const_intnl_SystemString");
            Private___7_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__7_intnl_SystemInt64");
            Private___15_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__15_intnl_SystemInt32");
            Private___1_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__1_intnl_UnityEngineGameObject");
            Private___3_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameData, "__3_mp_player_VRCPlayerApi");
            Private___5_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__5_intnl_UnityEngineComponent");
            Private___21_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__21_const_intnl_exitJumpLoc_UInt32");
            Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__12_intnl_SystemInt32");
            Private___181_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__181_intnl_SystemBoolean");
            Private___52_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__52_intnl_SystemBoolean");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__3_const_intnl_SystemString");
            Private___6_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__6_intnl_interpolatedStr_String");
            Private___6_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__6_const_intnl_SystemInt32");
            Private___0_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__0_intnl_PlayerData");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__3_const_intnl_exitJumpLoc_UInt32");
            Private_guardSpawns = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "guardSpawns");
            Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__26_intnl_SystemBoolean");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__0_const_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(GameData, "__1_intnl_UnityEngineQuaternion");
            Private___41_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__41_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__1_intnl_UnityEngineTransform");
            Private___166_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__166_intnl_SystemBoolean");
            Private___118_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__118_intnl_SystemBoolean");
            Private___95_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__95_intnl_SystemBoolean");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__1_const_intnl_SystemInt32");
            Private___49_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__49_const_intnl_SystemString");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__1_intnl_SystemInt32");
            Private_scoreboardDisplay = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "scoreboardDisplay");
            Private___16_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__16_const_intnl_exitJumpLoc_UInt32");
            Private_versionErrorPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "versionErrorPanel");
            Private___1_prisoners_Int32 = new AstroUdonVariable<int>(GameData, "__1_prisoners_Int32");
            Private___72_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__72_const_intnl_SystemString");
            Private___119_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__119_intnl_SystemBoolean");
            Private___15_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__15_intnl_SystemSingle");
            Private___35_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__35_intnl_SystemObject");
            Private___2_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__2_intnl_SystemObject");
            Private___8_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__8_pData_PlayerData");
            Private___148_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__148_intnl_SystemBoolean");
            Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(GameData, "__0_const_intnl_VRCUdonCommonEnumsEventTiming");
            Private___15_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__15_intnl_SystemString");
            Private___1_i_Int32 = new AstroUdonVariable<int>(GameData, "__1_i_Int32");
            Private___0_i_Int32 = new AstroUdonVariable<int>(GameData, "__0_i_Int32");
            Private___2_i_Int32 = new AstroUdonVariable<int>(GameData, "__2_i_Int32");
            Private___197_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__197_intnl_SystemBoolean");
            Private___160_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__160_intnl_SystemBoolean");
            Private___42_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__42_intnl_SystemInt32");
            Private_itemControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "itemControl");
            Private___35_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__35_const_intnl_exitJumpLoc_UInt32");
            Private_gameStartDelay = new AstroUdonVariable<int>(GameData, "gameStartDelay");
            Private___3_intnl_UnityEngineComponent = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__3_intnl_UnityEngineComponent");
            Private___93_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__93_intnl_SystemBoolean");
            Private___149_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__149_intnl_SystemBoolean");
            Private___8_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__8_intnl_SystemInt64");
            Private___161_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__161_intnl_SystemBoolean");
            Private___39_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__39_const_intnl_exitJumpLoc_UInt32");
            Private___2_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__2_pData_PlayerData");
            Private_desktopInteract = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "desktopInteract");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__0_const_intnl_SystemString");
            Private___1_mp_lastAlive_Boolean = new AstroUdonVariable<bool>(GameData, "__1_mp_lastAlive_Boolean");
            Private_prisRatioText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "prisRatioText");
            Private___21_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__21_intnl_SystemSingle");
            Private___42_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__42_intnl_SystemBoolean");
            Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__0_const_intnl_SystemSingle");
            Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__29_intnl_SystemBoolean");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__1_intnl_SystemSingle");
            Private_playerTracker = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "playerTracker");
            Private___174_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__174_intnl_SystemBoolean");
            Private___96_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__96_intnl_SystemBoolean");
            Private___7_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__7_const_intnl_SystemInt32");
            Private_timeLimitSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(GameData, "timeLimitSlider");
            Private___173_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__173_intnl_SystemBoolean");
            Private___9_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__9_intnl_SystemObject");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__5_intnl_SystemBoolean");
            Private___46_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__46_const_intnl_exitJumpLoc_UInt32");
            Private___85_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__85_intnl_SystemBoolean");
            Private_winSubtitle = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "winSubtitle");
            Private___9_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__9_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___156_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__156_intnl_SystemBoolean");
            Private___175_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__175_intnl_SystemBoolean");
            Private___32_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__32_intnl_SystemObject");
            Private___10_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__10_const_intnl_exitJumpLoc_UInt32");
            Private_updatingTimeRemaining = new AstroUdonVariable<bool>(GameData, "updatingTimeRemaining");
            Private___11_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__11_const_intnl_SystemInt32");
            Private___104_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__104_intnl_SystemBoolean");
            Private_syncedTimeRemaining = new AstroUdonVariable<int>(GameData, "syncedTimeRemaining");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___103_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__103_intnl_SystemBoolean");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__15_intnl_SystemBoolean");
            Private___24_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__24_const_intnl_exitJumpLoc_UInt32");
            Private___182_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__182_intnl_SystemBoolean");
            Private___20_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__20_intnl_SystemString");
            Private___6_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__6_intnl_SystemObject");
            Private___0_mp_lastAlive_Boolean = new AstroUdonVariable<bool>(GameData, "__0_mp_lastAlive_Boolean");
            Private___5_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__5_intnl_SystemString");
            Private___105_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__105_intnl_SystemBoolean");
            Private___34_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__34_intnl_SystemBoolean");
            Private___28_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__28_const_intnl_SystemString");
            Private___2_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__2_intnl_UnityEngineTransform");
            Private___58_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__58_const_intnl_SystemString");
            Private___83_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__83_intnl_SystemBoolean");
            Private___150_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__150_intnl_SystemBoolean");
            Private___28_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__28_const_intnl_exitJumpLoc_UInt32");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__6_const_intnl_SystemString");
            Private_joinErrorPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "joinErrorPanel");
            Private___7_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__7_intnl_UnityEngineGameObjectArray");
            Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__21_intnl_SystemBoolean");
            Private___138_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__138_intnl_SystemBoolean");
            Private___201_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__201_intnl_SystemBoolean");
            Private___0_prisCount_Int32 = new AstroUdonVariable<int>(GameData, "__0_prisCount_Int32");
            Private_sceneControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "sceneControl");
            Private___75_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__75_intnl_SystemBoolean");
            Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__5_const_intnl_exitJumpLoc_UInt32");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__13_intnl_SystemBoolean");
            Private___50_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__50_const_intnl_exitJumpLoc_UInt32");
            Private___151_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__151_intnl_SystemBoolean");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__1_const_intnl_SystemString");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__4_const_intnl_SystemInt32");
            Private_gameStarted = new AstroUdonVariable<bool>(GameData, "gameStarted");
            Private___64_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__64_intnl_SystemBoolean");
            Private___40_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__40_const_intnl_SystemString");
            Private___139_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__139_intnl_SystemBoolean");
            Private___99_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__99_intnl_SystemBoolean");
            Private___38_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__38_intnl_SystemInt32");
            Private_versionError = new AstroUdonVariable<bool>(GameData, "versionError");
            Private___86_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__86_intnl_SystemBoolean");
            Private___29_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__29_const_intnl_SystemString");
            Private___23_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__23_const_intnl_exitJumpLoc_UInt32");
            Private___59_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__59_const_intnl_SystemString");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__5_intnl_SystemSingle");
            Private___84_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__84_const_intnl_SystemString");
            Private___40_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__40_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__3_intnl_TMProTextMeshProUGUI");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___18_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__18_intnl_SystemInt32");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__16_intnl_SystemBoolean");
            Private___73_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__73_intnl_SystemBoolean");
            Private___162_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__162_intnl_SystemBoolean");
            Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__14_const_intnl_SystemString");
            Private___1_obj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__1_obj_GameObject");
            Private___1_guardCount_Int32 = new AstroUdonVariable<int>(GameData, "__1_guardCount_Int32");
            Private___0_this_intnl_GameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__0_this_intnl_GameManager");
            Private___19_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__19_intnl_SystemSingle");
            Private___41_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__41_const_intnl_SystemString");
            Private___46_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__46_const_intnl_SystemString");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__7_intnl_SystemBoolean");
            Private___20_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__20_intnl_SystemInt32");
            Private___1_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__1_intnl_SystemInt64");
            Private___85_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__85_const_intnl_SystemString");
            Private___64_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__64_const_intnl_SystemString");
            Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__22_intnl_SystemBoolean");
            Private___20_intnl_SystemObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__20_intnl_SystemObject");
            Private___0_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameData, "__0_intnl_UnityEngineComponentArray");
            Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__7_const_intnl_exitJumpLoc_UInt32");
            Private___76_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__76_intnl_SystemBoolean");
            Private___194_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__194_intnl_SystemBoolean");
            Private_respawnPoints = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "respawnPoints");
            Private___78_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__78_const_intnl_SystemString");
            Private___2_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__2_intnl_interpolatedStr_String");
            Private___23_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__23_intnl_SystemInt32");
            Private___91_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__91_intnl_SystemBoolean");
            Private___37_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__37_const_intnl_exitJumpLoc_UInt32");
            Private___193_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__193_intnl_SystemBoolean");
            Private___36_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__36_intnl_SystemObject");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__7_const_intnl_SystemString");
            Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__15_const_intnl_SystemString");
            Private___176_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__176_intnl_SystemBoolean");
            Private___195_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__195_intnl_SystemBoolean");
            Private_masterName = new AstroUdonVariable<string>(GameData, "masterName");
            Private___2_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameData, "__2_intnl_UnityEngineComponentArray");
            Private___0_spawn_Transform = new AstroUdonVariable<UnityEngine.Transform>(GameData, "__0_spawn_Transform");
            Private___89_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__89_intnl_SystemBoolean");
            Private___5_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__5_const_intnl_SystemInt32");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(GameData, "__refl_const_intnl_udonTypeID");
            Private___65_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__65_const_intnl_SystemString");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__4_intnl_SystemBoolean");
            Private_playerCount = new AstroUdonVariable<int>(GameData, "playerCount");
            Private_gameJoinTrigger = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "gameJoinTrigger");
            Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__11_intnl_SystemSingle");
            Private___106_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__106_intnl_SystemBoolean");
            Private___43_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__43_const_intnl_SystemString");
            Private___34_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__34_intnl_SystemInt32");
            Private_gameEffects = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "gameEffects");
            Private___79_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__79_const_intnl_SystemString");
            Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__19_intnl_SystemBoolean");
            Private_gameStartCountdown = new AstroUdonVariable<bool>(GameData, "gameStartCountdown");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(GameData, "__refl_const_intnl_udonTypeName");
            Private___127_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__127_intnl_SystemBoolean");
            Private___170_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__170_intnl_SystemBoolean");
            Private___87_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__87_const_intnl_SystemString");
            Private_audioControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "audioControl");
            Private_startButton = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startButton");
            Private___0_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__0_intnl_SystemObject");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__1_intnl_SystemBoolean");
            Private___38_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__38_intnl_SystemBoolean");
            Private___31_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__31_intnl_SystemInt32");
            Private___37_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__37_intnl_SystemInt32");
            Private___14_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__14_intnl_SystemInt32");
            Private_escapeeName = new AstroUdonVariable<string>(GameData, "escapeeName");
            Private___2_intnl_UnityEngineComponent = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__2_intnl_UnityEngineComponent");
            Private___152_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__152_intnl_SystemBoolean");
            Private___12_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__12_const_intnl_exitJumpLoc_UInt32");
            Private___34_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__34_const_intnl_SystemString");
            Private___171_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__171_intnl_SystemBoolean");
            Private___14_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__14_intnl_PlayerData");
            Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__17_const_intnl_SystemString");
            Private___100_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__100_intnl_SystemBoolean");
            Private_timeLimit = new AstroUdonVariable<int>(GameData, "timeLimit");
            Private___6_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__6_intnl_TMProTextMeshProUGUI");
            Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__11_intnl_SystemInt32");
            Private___79_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__79_intnl_SystemBoolean");
            Private___92_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__92_intnl_SystemBoolean");
            Private___17_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__17_intnl_SystemInt32");
            Private___5_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__5_intnl_SystemInt64");
            Private___26_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__26_const_intnl_exitJumpLoc_UInt32");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__4_const_intnl_SystemString");
            Private___28_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__28_intnl_SystemObject");
            Private___81_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__81_intnl_SystemBoolean");
            Private___31_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__31_const_intnl_exitJumpLoc_UInt32");
            Private___5_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__5_intnl_TMProTextMeshProUGUI");
            Private___10_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__10_intnl_SystemString");
            Private___68_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__68_intnl_SystemBoolean");
            Private___67_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__67_const_intnl_SystemString");
            Private___20_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__20_const_intnl_SystemString");
            Private___188_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__188_intnl_SystemBoolean");
            Private___50_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__50_const_intnl_SystemString");
            Private___101_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__101_intnl_SystemBoolean");
            Private_startButtonEnabled = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startButtonEnabled");
            Private___7_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__7_intnl_UnityEngineGameObject");
            Private___7_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__7_intnl_PlayerData");
            Private___35_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__35_const_intnl_SystemString");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__11_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__2_intnl_SystemInt32");
            Private___17_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__17_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___189_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__189_intnl_SystemBoolean");
            Private___8_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__8_const_intnl_SystemInt32");
            Private___1_intnl_UnityEngineTransformArray = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "__1_intnl_UnityEngineTransformArray");
            Private___52_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__52_const_intnl_exitJumpLoc_UInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__4_const_intnl_exitJumpLoc_UInt32");
            Private_prisRatio = new AstroUdonVariable<float>(GameData, "prisRatio");
            Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__30_intnl_SystemBoolean");
            Private___0_updated_Boolean = new AstroUdonVariable<bool>(GameData, "__0_updated_Boolean");
            Private___26_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__26_intnl_SystemInt32");
            Private___54_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__54_intnl_SystemBoolean");
            Private___2_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__2_intnl_SystemString");
            Private_winState = new AstroUdonVariable<int>(GameData, "winState");
            Private___21_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__21_const_intnl_SystemString");
            Private___51_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__51_const_intnl_SystemString");
            Private___41_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__41_intnl_SystemInt32");
            Private___26_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__26_const_intnl_SystemString");
            Private___56_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__56_const_intnl_SystemString");
            Private___42_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__42_const_intnl_exitJumpLoc_UInt32");
            Private___71_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__71_intnl_SystemBoolean");
            Private___23_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__23_intnl_SystemString");
            Private___117_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__117_intnl_SystemBoolean");
            Private_winTitle = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "winTitle");
            Private___9_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__9_intnl_TMProTextMeshProUGUI");
            Private_countdownPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "countdownPanel");
            Private___0_players_Int32 = new AstroUdonVariable<int>(GameData, "__0_players_Int32");
            Private_timeRemaining = new AstroUdonVariable<int>(GameData, "timeRemaining");
            Private___9_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__9_const_intnl_exitJumpLoc_UInt32");
            Private___60_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__60_intnl_SystemBoolean");
            Private___196_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__196_intnl_SystemBoolean");
            Private___37_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__37_intnl_SystemBoolean");
            Private___82_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__82_intnl_SystemBoolean");
            Private___20_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__20_const_intnl_exitJumpLoc_UInt32");
            Private___168_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__168_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__1_intnl_UnityEngineGameObjectArray");
            Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__9_intnl_SystemInt32");
            Private___37_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__37_const_intnl_SystemString");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__2_intnl_SystemSingle");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__3_intnl_SystemBoolean");
            Private___147_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__147_intnl_SystemBoolean");
            Private_prisText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "prisText");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(GameData, "__0_intnl_returnValSymbol_Boolean");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__12_intnl_SystemBoolean");
            Private___9_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__9_intnl_SystemString");
            Private___10_intnl_SystemObject = new AstroUdonVariable<long>(GameData, "__10_intnl_SystemObject");
            Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__6_const_intnl_exitJumpLoc_UInt32");
            Private___169_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__169_intnl_SystemBoolean");
            Private___2_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__2_intnl_PlayerData");
            Private___18_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__18_intnl_SystemString");
            Private___70_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__70_const_intnl_SystemString");
            Private_doorControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "doorControl");
            Private___190_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__190_intnl_SystemBoolean");
            Private___67_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__67_intnl_SystemBoolean");
            Private___23_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__23_const_intnl_SystemString");
            Private___53_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__53_const_intnl_SystemString");
            Private_hiddenSpectate = new AstroUdonVariable<bool>(GameData, "hiddenSpectate");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__6_intnl_SystemInt32");
            Private___172_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__172_intnl_SystemBoolean");
            Private___9_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__9_const_intnl_SystemInt32");
            Private_cachedTimeLimit = new AstroUdonVariable<int>(GameData, "cachedTimeLimit");
            Private___44_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__44_intnl_SystemBoolean");
            Private___17_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__17_intnl_SystemSingle");
            Private_cachedWinState = new AstroUdonVariable<int>(GameData, "cachedWinState");
            Private___191_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__191_intnl_SystemBoolean");
            Private___29_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__29_intnl_SystemObject");
            Private___0_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__0_intnl_UnityEngineGameObjectArray");
            Private___82_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__82_const_intnl_SystemString");
            Private___72_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__72_intnl_SystemBoolean");
            Private___6_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__6_intnl_SystemString");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__0_intnl_SystemBoolean");
            Private___9_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__9_intnl_PlayerData");
            Private___34_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__34_const_intnl_exitJumpLoc_UInt32");
            Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__9_intnl_SystemSingle");
            Private___102_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__102_intnl_SystemBoolean");
            Private___71_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__71_const_intnl_SystemString");
            Private___76_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__76_const_intnl_SystemString");
            Private_startButtonDisabled = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startButtonDisabled");
            Private___22_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__22_intnl_SystemString");
            Private___124_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__124_intnl_SystemBoolean");
            Private_isGuard = new AstroUdonVariable<bool[]>(GameData, "isGuard");
            Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__12_const_intnl_SystemString");
            Private___38_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__38_const_intnl_exitJumpLoc_UInt32");
            Private___123_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__123_intnl_SystemBoolean");
            Private___0_this_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__0_this_intnl_UnityEngineGameObject");
            Private_prisSpawns = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "prisSpawns");
            Private___3_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__3_intnl_SystemObject");
            Private___23_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__23_intnl_SystemSingle");
            Private___0_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__0_intnl_UnityEngineGameObject");
            Private___125_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__125_intnl_SystemBoolean");
            Private___62_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__62_const_intnl_SystemString");
            Private___17_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__17_intnl_SystemObject");
            Private___158_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__158_intnl_SystemBoolean");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__8_const_intnl_SystemString");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__6_intnl_SystemSingle");
            Private___4_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__4_intnl_TMProTextMeshProUGUI");
            Private___33_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__33_const_intnl_exitJumpLoc_UInt32");
            Private___18_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__18_intnl_SystemObject");
            Private___0_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(GameData, "__0_intnl_UnityEngineQuaternion");
            Private___9_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__9_pData_PlayerData");
            Private___24_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__24_intnl_SystemSingle");
            Private___159_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__159_intnl_SystemBoolean");
            Private___58_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__58_intnl_SystemBoolean");
            Private___15_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__15_intnl_PlayerData");
            Private___137_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__137_intnl_SystemBoolean");
            Private_onPlayerJoinedPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameData, "onPlayerJoinedPlayer");
            Private___24_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__24_intnl_SystemString");
            Private_gameStartTime = new AstroUdonVariable<float>(GameData, "gameStartTime");
            Private___73_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__73_const_intnl_SystemString");
            Private_patronControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "patronControl");
            Private___15_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__15_const_intnl_exitJumpLoc_UInt32");
            Private___4_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__4_intnl_PlayerData");
            Private___16_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__16_intnl_SystemSingle");
            Private___3_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__3_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___2_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__2_intnl_SystemInt64");
            Private___1_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameData, "__1_mp_player_VRCPlayerApi");
            Private___4_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__4_pData_PlayerData");
            Private_timeLimitText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "timeLimitText");
            Private___19_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__19_const_intnl_exitJumpLoc_UInt32");
            Private___12_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__12_const_intnl_SystemInt32");
            Private___8_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__8_intnl_TMProTextMeshProUGUI");
            Private___21_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__21_intnl_SystemString");
            Private_timeoutSecs = new AstroUdonVariable<int>(GameData, "timeoutSecs");
            Private___114_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__114_intnl_SystemBoolean");
            Private___13_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__13_intnl_SystemString");
            Private___32_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__32_const_intnl_SystemString");
            Private___5_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__5_intnl_interpolatedStr_String");
            Private___113_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__113_intnl_SystemBoolean");
            Private___0_newPrisRatio_Single = new AstroUdonVariable<float>(GameData, "__0_newPrisRatio_Single");
            Private___29_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__29_intnl_SystemInt32");
            Private___35_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__35_intnl_SystemBoolean");
            Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__8_const_intnl_exitJumpLoc_UInt32");
            Private___0_rand_Int32 = new AstroUdonVariable<int>(GameData, "__0_rand_Int32");
            Private___50_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__50_intnl_SystemBoolean");
            Private___22_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__22_intnl_SystemSingle");
            Private___192_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__192_intnl_SystemBoolean");
            Private___7_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__7_intnl_SystemObject");
            Private___22_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__22_const_intnl_exitJumpLoc_UInt32");
            Private___115_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__115_intnl_SystemBoolean");
            Private_joinError = new AstroUdonVariable<bool>(GameData, "joinError");
            Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__24_intnl_SystemBoolean");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__9_const_intnl_SystemString");
            Private___13_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__13_intnl_PlayerData");
            Private___13_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__13_const_intnl_SystemInt32");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__0_intnl_SystemInt32");
            Private___9_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__9_intnl_SystemInt64");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(GameData, "__0_intnl_returnTarget_UInt32");
            Private___144_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__144_intnl_SystemBoolean");
            Private_cachedGameStarted = new AstroUdonVariable<bool>(GameData, "cachedGameStarted");
            Private___48_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__48_intnl_SystemBoolean");
            Private___0_mp_error_Boolean = new AstroUdonVariable<bool>(GameData, "__0_mp_error_Boolean");
            Private_guardText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "guardText");
            Private___143_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__143_intnl_SystemBoolean");
            Private___30_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__30_intnl_SystemInt32");
            Private___45_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__45_const_intnl_exitJumpLoc_UInt32");
            Private___44_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__44_const_intnl_SystemString");
            Private___65_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__65_intnl_SystemBoolean");
            Private___92_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__92_const_intnl_SystemString");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__0_intnl_SystemString");
            Private___33_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__33_intnl_SystemBoolean");
            Private___145_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__145_intnl_SystemBoolean");
            Private___57_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__57_intnl_SystemBoolean");
            Private___33_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__33_intnl_SystemInt32");
            Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__10_intnl_SystemInt32");
            Private___49_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__49_const_intnl_exitJumpLoc_UInt32");
            Private___126_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__126_intnl_SystemBoolean");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(GameData, "__0_const_intnl_SystemUInt32");
            Private___6_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__6_intnl_SystemInt64");
            Private___178_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__178_intnl_SystemBoolean");
            Private___8_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__8_intnl_UnityEngineGameObjectArray");
            Private___16_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__16_intnl_PlayerData");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__9_intnl_SystemBoolean");
            Private___19_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__19_intnl_SystemObject");
            Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__13_intnl_SystemInt32");
            Private___36_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__36_const_intnl_exitJumpLoc_UInt32");
            Private___45_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__45_const_intnl_SystemString");
            Private___63_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__63_intnl_SystemBoolean");
            Private___36_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__36_intnl_SystemBoolean");
            Private___179_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__179_intnl_SystemBoolean");
            Private___88_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__88_const_intnl_SystemString");
            Private_spectatePanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "spectatePanel");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__0_intnl_SystemSingle");
            Private___108_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__108_intnl_SystemBoolean");
            Private___12_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__12_intnl_SystemString");
            Private___40_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__40_intnl_SystemBoolean");
            Private___120_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__120_intnl_SystemBoolean");
            Private___94_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__94_intnl_SystemBoolean");
            Private___25_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__25_intnl_SystemInt32");
            Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__18_const_intnl_SystemString");
            Private___109_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__109_intnl_SystemBoolean");
            Private___40_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__40_intnl_SystemInt32");
            Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__13_intnl_SystemSingle");
            Private_prisRatioSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(GameData, "prisRatioSlider");
            Private___66_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__66_intnl_SystemBoolean");
            Private___121_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__121_intnl_SystemBoolean");
            Private___22_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__22_intnl_SystemInt32");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__4_intnl_SystemInt32");
            Private___187_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__187_intnl_SystemBoolean");
            Private___89_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__89_const_intnl_SystemString");
            Private___68_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__68_const_intnl_SystemString");
            Private___14_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__14_intnl_SystemSingle");
            Private___47_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__47_intnl_SystemBoolean");
            Private_gateControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "gateControl");
            Private___4_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__4_intnl_SystemString");
            Private___134_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__134_intnl_SystemBoolean");
            Private_masterText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "masterText");
            Private___47_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__47_const_intnl_SystemString");
            Private___133_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__133_intnl_SystemBoolean");
            Private_spectatorDisplay = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "spectatorDisplay");
            Private___4_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__4_intnl_UnityEngineTransform");
            Private___14_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__14_intnl_SystemString");
            Private___10_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__10_const_intnl_SystemInt32");
            Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__19_const_intnl_SystemString");
            Private___17_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__17_const_intnl_exitJumpLoc_UInt32");
            Private___7_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__7_intnl_TMProTextMeshProUGUI");
            Private___116_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__116_intnl_SystemBoolean");
            Private_startTimeoutText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startTimeoutText");
            Private___135_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__135_intnl_SystemBoolean");
            Private___30_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__30_const_intnl_exitJumpLoc_UInt32");
            Private___39_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__39_intnl_SystemBoolean");
            Private___69_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__69_const_intnl_SystemString");
            Private___0_prisoners_Int32 = new AstroUdonVariable<int>(GameData, "__0_prisoners_Int32");
            Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__28_intnl_SystemBoolean");
            Private___36_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__36_intnl_SystemInt32");
            Private___0_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__0_pData_PlayerData");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__6_intnl_SystemBoolean");
            Private_startPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startPanel");
            Private___20_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__20_intnl_SystemSingle");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__4_intnl_SystemSingle");
            Private___11_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__11_intnl_SystemString");
            Private___146_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__146_intnl_SystemBoolean");
            Private___1_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__1_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___84_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__84_intnl_SystemBoolean");
            Private___110_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__110_intnl_SystemBoolean");
            Private___24_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__24_const_intnl_SystemString");
            Private___54_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__54_const_intnl_SystemString");
            Private___16_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__16_intnl_SystemInt32");
            Private___69_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__69_intnl_SystemBoolean");
            Private___167_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__167_intnl_SystemBoolean");
            Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__12_intnl_SystemSingle");
            Private___38_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__38_const_intnl_SystemString");
            Private___198_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__198_intnl_SystemBoolean");
            Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__14_intnl_SystemBoolean");
            Private___1_guards_Int32 = new AstroUdonVariable<int>(GameData, "__1_guards_Int32");
            Private_lootCrateControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "lootCrateControl");
            Private_openableControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "openableControl");
            Private___111_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__111_intnl_SystemBoolean");
            Private___2_obj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__2_obj_GameObject");
            Private___0_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__0_intnl_SystemInt64");
            Private___140_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__140_intnl_SystemBoolean");
            Private___10_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__10_intnl_TMProTextMeshProUGUI");
            Private___47_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__47_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__3_intnl_SystemInt32");
            Private___31_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__31_intnl_SystemBoolean");
            Private___199_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__199_intnl_SystemBoolean");
            Private___55_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__55_intnl_SystemBoolean");
            Private___25_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__25_const_intnl_SystemString");
            Private___55_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__55_const_intnl_SystemString");
            Private___5_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__5_intnl_UnityEngineGameObject");
            Private___11_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__11_const_intnl_exitJumpLoc_UInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__8_intnl_SystemBoolean");
            Private___1_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__1_intnl_interpolatedStr_String");
            Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__20_intnl_SystemBoolean");
            Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameData, "__2_intnl_UnityEngineVector3");
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__3_intnl_SystemString");
            Private___141_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__141_intnl_SystemBoolean");
            Private___39_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__39_const_intnl_SystemString");
            Private___74_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__74_intnl_SystemBoolean");
            Private___7_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__7_intnl_UnityEngineTransform");
            Private___1_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__1_intnl_SystemObject");
            Private___122_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__122_intnl_SystemBoolean");
            Private___0_guard_Boolean = new AstroUdonVariable<bool>(GameData, "__0_guard_Boolean");
            Private___25_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__25_const_intnl_exitJumpLoc_UInt32");
            Private___33_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__33_intnl_SystemObject");
            Private___61_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__61_intnl_SystemBoolean");
            Private___98_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__98_intnl_SystemBoolean");
            Private_afkDetector = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "afkDetector");
            Private___8_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__8_intnl_UnityEngineTransform");
            Private___29_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__29_const_intnl_exitJumpLoc_UInt32");
            Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameData, "__1_intnl_UnityEngineVector3");
            Private___53_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__53_intnl_SystemBoolean");
            Private___4_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__4_intnl_interpolatedStr_String");
            Private___80_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__80_const_intnl_SystemString");
            Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__27_intnl_SystemBoolean");
            Private___19_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__19_intnl_SystemString");
            Private___51_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__51_const_intnl_exitJumpLoc_UInt32");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__3_intnl_SystemSingle");
            Private___74_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__74_const_intnl_SystemString");
            Private___0_intnl_UnityEngineAnimator = new AstroUdonVariable<UnityEngine.Animator>(GameData, "__0_intnl_UnityEngineAnimator");
            Private___157_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__157_intnl_SystemBoolean");
            Private___136_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__136_intnl_SystemBoolean");
            Private___27_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__27_const_intnl_SystemString");
            Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameData, "__0_intnl_UnityEngineVector3");
            Private___57_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__57_const_intnl_SystemString");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__10_const_intnl_SystemString");
            Private___4_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__4_intnl_UnityEngineGameObjectArray");
            Private_prisObjects = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "prisObjects");
            Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__32_intnl_SystemBoolean");
            Private___4_intnl_UnityEngineComponent = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__4_intnl_UnityEngineComponent");
            Private___30_intnl_SystemObject = new AstroUdonVariable<long>(GameData, "__30_intnl_SystemObject");
            Private___56_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__56_intnl_SystemBoolean");
            Private___2_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__2_intnl_TMProTextMeshProUGUI");
            Private___41_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__41_const_intnl_exitJumpLoc_UInt32");
            Private___42_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__42_const_intnl_SystemString");
            Private___18_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__18_intnl_SystemSingle");
            Private___184_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__184_intnl_SystemBoolean");
            Private___16_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__16_intnl_SystemObject");
            Private___4_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__4_intnl_SystemInt64");
            Private___45_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__45_intnl_SystemBoolean");
            Private___81_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__81_const_intnl_SystemString");
            Private___60_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__60_const_intnl_SystemString");
            Private___183_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__183_intnl_SystemBoolean");
            Private___28_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__28_intnl_SystemInt32");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__7_intnl_SystemInt32");
            Private___1_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__1_intnl_TMProTextMeshProUGUI");
            Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__0_intnl_UnityEngineTransform");
            Private___86_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__86_const_intnl_SystemString");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__1_const_intnl_SystemBoolean");
            Private___0_mp_spawns_TransformArray = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "__0_mp_spawns_TransformArray");
            Private___90_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__90_intnl_SystemBoolean");
            Private___75_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__75_const_intnl_SystemString");
            Private___130_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__130_intnl_SystemBoolean");
            Private___185_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__185_intnl_SystemBoolean");
            Private___0_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(GameData, "__0_intnl_UnityEngineColor");
            Private___3_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__3_intnl_PlayerData");
            Private___7_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__7_intnl_SystemString");
            Private___62_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__62_intnl_SystemBoolean");
            Private___200_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__200_intnl_SystemBoolean");
            Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__11_const_intnl_SystemString");
            Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__16_const_intnl_SystemString");
            Private___112_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__112_intnl_SystemBoolean");
            Private___88_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__88_intnl_SystemBoolean");
            Private___32_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__32_const_intnl_exitJumpLoc_UInt32");
            Private_cachedPrisRatio = new AstroUdonVariable<float>(GameData, "cachedPrisRatio");
            Private_afkRespawn = new AstroUdonVariable<UnityEngine.Transform>(GameData, "afkRespawn");
            Private___0_const_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__0_const_intnl_SystemInt64");
            Private___131_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__131_intnl_SystemBoolean");
            Private___43_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__43_intnl_SystemBoolean");
            Private___61_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__61_const_intnl_SystemString");
            Private___66_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__66_const_intnl_SystemString");
            Private___5_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__5_intnl_UnityEngineTransform");
            Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__18_intnl_SystemBoolean");
            Private___97_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__97_intnl_SystemBoolean");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__2_intnl_SystemBoolean");
            Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__10_intnl_SystemSingle");
            Private___25_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__25_intnl_SystemSingle");
            Private___14_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__14_const_intnl_exitJumpLoc_UInt32");
            Private___142_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__142_intnl_SystemBoolean");
            Private___83_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__83_const_intnl_SystemString");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__3_const_intnl_SystemInt32");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__7_intnl_SystemSingle");
            Private___37_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__37_intnl_SystemObject");
            Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(GameData, "__0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget");
            Private___164_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__164_intnl_SystemBoolean");
            Private___59_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__59_intnl_SystemBoolean");
            Private___163_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__163_intnl_SystemBoolean");
            Private___18_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__18_const_intnl_exitJumpLoc_UInt32");
            Private___46_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__46_intnl_SystemBoolean");
            Private___17_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__17_intnl_SystemString");
            Private___39_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__39_intnl_SystemInt32");
            Private_playerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "playerObjectPool");
            Private___77_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__77_const_intnl_SystemString");
            Private___30_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__30_const_intnl_SystemString");
            Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__13_const_intnl_SystemString");
            Private___78_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__78_intnl_SystemBoolean");
            Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__8_intnl_SystemInt32");
            Private_guardHealth = new AstroUdonVariable<int>(GameData, "guardHealth");
            Private___165_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__165_intnl_SystemBoolean");
            Private___7_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__7_intnl_UnityEngineComponent");
            Private___0_randomIndex_Int32 = new AstroUdonVariable<int>(GameData, "__0_randomIndex_Int32");
            Private___80_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__80_intnl_SystemBoolean");
            Private___19_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__19_intnl_SystemInt32");
            Private_winPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "winPanel");
            Private___24_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__24_intnl_SystemInt32");
            Private___63_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__63_const_intnl_SystemString");
            Private___8_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__8_intnl_SystemString");
            Private___3_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__3_intnl_SystemInt64");
            Private___15_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__15_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___13_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__13_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__3_intnl_UnityEngineTransform");
            Private___0_timeText_String = new AstroUdonVariable<string>(GameData, "__0_timeText_String");
            Private___2_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__2_intnl_UnityEngineGameObject");
            Private_guardObjects = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "guardObjects");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__10_intnl_SystemBoolean");
            Private___34_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__34_intnl_SystemObject");
            Private___90_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__90_const_intnl_SystemString");
            Private___177_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__177_intnl_SystemBoolean");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__2_const_intnl_SystemString");
            Private___31_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__31_const_intnl_SystemString");
            Private___31_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__31_intnl_SystemObject");
            Private___21_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__21_intnl_SystemInt32");
            Private___27_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__27_const_intnl_exitJumpLoc_UInt32");
            Private___27_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__27_intnl_SystemInt32");
            Private___36_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__36_const_intnl_SystemString");
            Private___4_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameData, "__4_intnl_UnityEngineComponentArray");
            Private___1_const_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__1_const_intnl_SystemInt64");
            Private___44_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__44_const_intnl_exitJumpLoc_UInt32");
            Private___128_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__128_intnl_SystemBoolean");
            Private___5_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__5_pData_PlayerData");
            Private___87_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__87_intnl_SystemBoolean");
            Private___51_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__51_intnl_SystemBoolean");
            Private_displayWinner = new AstroUdonVariable<bool>(GameData, "displayWinner");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__0_const_intnl_SystemInt32");
            Private___107_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__107_intnl_SystemBoolean");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__25_intnl_SystemBoolean");
            Private___0_guardCount_Int32 = new AstroUdonVariable<int>(GameData, "__0_guardCount_Int32");
            Private___48_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__48_const_intnl_exitJumpLoc_UInt32");
            Private___22_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__22_const_intnl_SystemString");
            Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__8_intnl_SystemSingle");
            Private___52_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__52_const_intnl_SystemString");
            Private___70_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__70_intnl_SystemBoolean");
            Private___129_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__129_intnl_SystemBoolean");
            Private___0_obj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__0_obj_GameObject");
            Private___186_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__186_intnl_SystemBoolean");
            Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__17_intnl_SystemBoolean");
            Private___1_prisCount_Int32 = new AstroUdonVariable<int>(GameData, "__1_prisCount_Int32");
            Private___49_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__49_intnl_SystemBoolean");
            Private___91_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__91_const_intnl_SystemString");
            Private___0_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(GameData, "__0_intnl_returnValSymbol_Int32");
            Private___0_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__0_intnl_UnityEngineComponent");
            Private___154_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__154_intnl_SystemBoolean");
            Private___16_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__16_intnl_SystemString");
            Private___153_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__153_intnl_SystemBoolean");
            Private___132_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__132_intnl_SystemBoolean");
            Private___9_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(GameData, "__9_intnl_UnityEngineTransform");
        }

        void OnDestroy()
        {
            Cleanup_GameData();
        }
        internal void Cleanup_GameData()
        {
            Private___3_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__3_intnl_interpolatedStr_String");
            Private___6_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__6_intnl_UnityEngineTransform");
            Private___35_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__35_intnl_SystemInt32");
            Private___43_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__43_const_intnl_exitJumpLoc_UInt32");
            Private_updatedTeams = new AstroUdonVariable<bool>(GameData, "updatedTeams");
            Private___33_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__33_const_intnl_SystemString");
            Private___0_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__0_intnl_TMProTextMeshProUGUI");
            Private___0_newTimeLimit_Int32 = new AstroUdonVariable<int>(GameData, "__0_newTimeLimit_Int32");
            Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__23_intnl_SystemBoolean");
            Private___10_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__10_pData_PlayerData");
            Private___0_guards_Int32 = new AstroUdonVariable<int>(GameData, "__0_guards_Int32");
            Private___155_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__155_intnl_SystemBoolean");
            Private___0_playerDataObj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__0_playerDataObj_GameObject");
            Private___32_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__32_intnl_SystemInt32");
            Private___180_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__180_intnl_SystemBoolean");
            Private___77_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__77_intnl_SystemBoolean");
            Private___8_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__8_intnl_PlayerData");
            Private___48_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__48_const_intnl_SystemString");
            Private___7_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__7_intnl_SystemInt64");
            Private___15_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__15_intnl_SystemInt32");
            Private___1_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__1_intnl_UnityEngineGameObject");
            Private___3_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameData, "__3_mp_player_VRCPlayerApi");
            Private___5_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__5_intnl_UnityEngineComponent");
            Private___21_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__21_const_intnl_exitJumpLoc_UInt32");
            Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__12_intnl_SystemInt32");
            Private___181_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__181_intnl_SystemBoolean");
            Private___52_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__52_intnl_SystemBoolean");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__3_const_intnl_SystemString");
            Private___6_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__6_intnl_interpolatedStr_String");
            Private___6_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__6_const_intnl_SystemInt32");
            Private___0_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__0_intnl_PlayerData");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__3_const_intnl_exitJumpLoc_UInt32");
            Private_guardSpawns = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "guardSpawns");
            Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__26_intnl_SystemBoolean");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__0_const_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(GameData, "__1_intnl_UnityEngineQuaternion");
            Private___41_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__41_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__1_intnl_UnityEngineTransform");
            Private___166_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__166_intnl_SystemBoolean");
            Private___118_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__118_intnl_SystemBoolean");
            Private___95_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__95_intnl_SystemBoolean");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__1_const_intnl_SystemInt32");
            Private___49_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__49_const_intnl_SystemString");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__1_intnl_SystemInt32");
            Private_scoreboardDisplay = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "scoreboardDisplay");
            Private___16_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__16_const_intnl_exitJumpLoc_UInt32");
            Private_versionErrorPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "versionErrorPanel");
            Private___1_prisoners_Int32 = new AstroUdonVariable<int>(GameData, "__1_prisoners_Int32");
            Private___72_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__72_const_intnl_SystemString");
            Private___119_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__119_intnl_SystemBoolean");
            Private___15_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__15_intnl_SystemSingle");
            Private___35_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__35_intnl_SystemObject");
            Private___2_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__2_intnl_SystemObject");
            Private___8_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__8_pData_PlayerData");
            Private___148_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__148_intnl_SystemBoolean");
            Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(GameData, "__0_const_intnl_VRCUdonCommonEnumsEventTiming");
            Private___15_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__15_intnl_SystemString");
            Private___1_i_Int32 = new AstroUdonVariable<int>(GameData, "__1_i_Int32");
            Private___0_i_Int32 = new AstroUdonVariable<int>(GameData, "__0_i_Int32");
            Private___2_i_Int32 = new AstroUdonVariable<int>(GameData, "__2_i_Int32");
            Private___197_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__197_intnl_SystemBoolean");
            Private___160_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__160_intnl_SystemBoolean");
            Private___42_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__42_intnl_SystemInt32");
            Private_itemControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "itemControl");
            Private___35_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__35_const_intnl_exitJumpLoc_UInt32");
            Private_gameStartDelay = new AstroUdonVariable<int>(GameData, "gameStartDelay");
            Private___3_intnl_UnityEngineComponent = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__3_intnl_UnityEngineComponent");
            Private___93_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__93_intnl_SystemBoolean");
            Private___149_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__149_intnl_SystemBoolean");
            Private___8_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__8_intnl_SystemInt64");
            Private___161_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__161_intnl_SystemBoolean");
            Private___39_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__39_const_intnl_exitJumpLoc_UInt32");
            Private___2_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__2_pData_PlayerData");
            Private_desktopInteract = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "desktopInteract");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__0_const_intnl_SystemString");
            Private___1_mp_lastAlive_Boolean = new AstroUdonVariable<bool>(GameData, "__1_mp_lastAlive_Boolean");
            Private_prisRatioText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "prisRatioText");
            Private___21_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__21_intnl_SystemSingle");
            Private___42_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__42_intnl_SystemBoolean");
            Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__0_const_intnl_SystemSingle");
            Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__29_intnl_SystemBoolean");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__1_intnl_SystemSingle");
            Private_playerTracker = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "playerTracker");
            Private___174_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__174_intnl_SystemBoolean");
            Private___96_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__96_intnl_SystemBoolean");
            Private___7_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__7_const_intnl_SystemInt32");
            Private_timeLimitSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(GameData, "timeLimitSlider");
            Private___173_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__173_intnl_SystemBoolean");
            Private___9_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__9_intnl_SystemObject");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__5_intnl_SystemBoolean");
            Private___46_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__46_const_intnl_exitJumpLoc_UInt32");
            Private___85_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__85_intnl_SystemBoolean");
            Private_winSubtitle = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "winSubtitle");
            Private___9_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__9_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___156_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__156_intnl_SystemBoolean");
            Private___175_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__175_intnl_SystemBoolean");
            Private___32_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__32_intnl_SystemObject");
            Private___10_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__10_const_intnl_exitJumpLoc_UInt32");
            Private_updatingTimeRemaining = new AstroUdonVariable<bool>(GameData, "updatingTimeRemaining");
            Private___11_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__11_const_intnl_SystemInt32");
            Private___104_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__104_intnl_SystemBoolean");
            Private_syncedTimeRemaining = new AstroUdonVariable<int>(GameData, "syncedTimeRemaining");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___103_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__103_intnl_SystemBoolean");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__15_intnl_SystemBoolean");
            Private___24_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__24_const_intnl_exitJumpLoc_UInt32");
            Private___182_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__182_intnl_SystemBoolean");
            Private___20_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__20_intnl_SystemString");
            Private___6_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__6_intnl_SystemObject");
            Private___0_mp_lastAlive_Boolean = new AstroUdonVariable<bool>(GameData, "__0_mp_lastAlive_Boolean");
            Private___5_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__5_intnl_SystemString");
            Private___105_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__105_intnl_SystemBoolean");
            Private___34_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__34_intnl_SystemBoolean");
            Private___28_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__28_const_intnl_SystemString");
            Private___2_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__2_intnl_UnityEngineTransform");
            Private___58_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__58_const_intnl_SystemString");
            Private___83_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__83_intnl_SystemBoolean");
            Private___150_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__150_intnl_SystemBoolean");
            Private___28_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__28_const_intnl_exitJumpLoc_UInt32");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__6_const_intnl_SystemString");
            Private_joinErrorPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "joinErrorPanel");
            Private___7_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__7_intnl_UnityEngineGameObjectArray");
            Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__21_intnl_SystemBoolean");
            Private___138_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__138_intnl_SystemBoolean");
            Private___201_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__201_intnl_SystemBoolean");
            Private___0_prisCount_Int32 = new AstroUdonVariable<int>(GameData, "__0_prisCount_Int32");
            Private_sceneControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "sceneControl");
            Private___75_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__75_intnl_SystemBoolean");
            Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__5_const_intnl_exitJumpLoc_UInt32");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__13_intnl_SystemBoolean");
            Private___50_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__50_const_intnl_exitJumpLoc_UInt32");
            Private___151_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__151_intnl_SystemBoolean");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__1_const_intnl_SystemString");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__4_const_intnl_SystemInt32");
            Private_gameStarted = new AstroUdonVariable<bool>(GameData, "gameStarted");
            Private___64_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__64_intnl_SystemBoolean");
            Private___40_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__40_const_intnl_SystemString");
            Private___139_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__139_intnl_SystemBoolean");
            Private___99_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__99_intnl_SystemBoolean");
            Private___38_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__38_intnl_SystemInt32");
            Private_versionError = new AstroUdonVariable<bool>(GameData, "versionError");
            Private___86_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__86_intnl_SystemBoolean");
            Private___29_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__29_const_intnl_SystemString");
            Private___23_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__23_const_intnl_exitJumpLoc_UInt32");
            Private___59_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__59_const_intnl_SystemString");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__5_intnl_SystemSingle");
            Private___84_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__84_const_intnl_SystemString");
            Private___40_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__40_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__3_intnl_TMProTextMeshProUGUI");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___18_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__18_intnl_SystemInt32");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__16_intnl_SystemBoolean");
            Private___73_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__73_intnl_SystemBoolean");
            Private___162_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__162_intnl_SystemBoolean");
            Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__14_const_intnl_SystemString");
            Private___1_obj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__1_obj_GameObject");
            Private___1_guardCount_Int32 = new AstroUdonVariable<int>(GameData, "__1_guardCount_Int32");
            Private___0_this_intnl_GameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__0_this_intnl_GameManager");
            Private___19_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__19_intnl_SystemSingle");
            Private___41_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__41_const_intnl_SystemString");
            Private___46_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__46_const_intnl_SystemString");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__7_intnl_SystemBoolean");
            Private___20_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__20_intnl_SystemInt32");
            Private___1_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__1_intnl_SystemInt64");
            Private___85_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__85_const_intnl_SystemString");
            Private___64_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__64_const_intnl_SystemString");
            Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__22_intnl_SystemBoolean");
            Private___20_intnl_SystemObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__20_intnl_SystemObject");
            Private___0_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameData, "__0_intnl_UnityEngineComponentArray");
            Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__7_const_intnl_exitJumpLoc_UInt32");
            Private___76_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__76_intnl_SystemBoolean");
            Private___194_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__194_intnl_SystemBoolean");
            Private_respawnPoints = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "respawnPoints");
            Private___78_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__78_const_intnl_SystemString");
            Private___2_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__2_intnl_interpolatedStr_String");
            Private___23_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__23_intnl_SystemInt32");
            Private___91_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__91_intnl_SystemBoolean");
            Private___37_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__37_const_intnl_exitJumpLoc_UInt32");
            Private___193_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__193_intnl_SystemBoolean");
            Private___36_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__36_intnl_SystemObject");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__7_const_intnl_SystemString");
            Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__15_const_intnl_SystemString");
            Private___176_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__176_intnl_SystemBoolean");
            Private___195_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__195_intnl_SystemBoolean");
            Private_masterName = new AstroUdonVariable<string>(GameData, "masterName");
            Private___2_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameData, "__2_intnl_UnityEngineComponentArray");
            Private___0_spawn_Transform = new AstroUdonVariable<UnityEngine.Transform>(GameData, "__0_spawn_Transform");
            Private___89_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__89_intnl_SystemBoolean");
            Private___5_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__5_const_intnl_SystemInt32");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(GameData, "__refl_const_intnl_udonTypeID");
            Private___65_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__65_const_intnl_SystemString");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__4_intnl_SystemBoolean");
            Private_playerCount = new AstroUdonVariable<int>(GameData, "playerCount");
            Private_gameJoinTrigger = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "gameJoinTrigger");
            Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__11_intnl_SystemSingle");
            Private___106_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__106_intnl_SystemBoolean");
            Private___43_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__43_const_intnl_SystemString");
            Private___34_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__34_intnl_SystemInt32");
            Private_gameEffects = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "gameEffects");
            Private___79_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__79_const_intnl_SystemString");
            Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__19_intnl_SystemBoolean");
            Private_gameStartCountdown = new AstroUdonVariable<bool>(GameData, "gameStartCountdown");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(GameData, "__refl_const_intnl_udonTypeName");
            Private___127_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__127_intnl_SystemBoolean");
            Private___170_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__170_intnl_SystemBoolean");
            Private___87_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__87_const_intnl_SystemString");
            Private_audioControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "audioControl");
            Private_startButton = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startButton");
            Private___0_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__0_intnl_SystemObject");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__1_intnl_SystemBoolean");
            Private___38_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__38_intnl_SystemBoolean");
            Private___31_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__31_intnl_SystemInt32");
            Private___37_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__37_intnl_SystemInt32");
            Private___14_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__14_intnl_SystemInt32");
            Private_escapeeName = new AstroUdonVariable<string>(GameData, "escapeeName");
            Private___2_intnl_UnityEngineComponent = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__2_intnl_UnityEngineComponent");
            Private___152_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__152_intnl_SystemBoolean");
            Private___12_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__12_const_intnl_exitJumpLoc_UInt32");
            Private___34_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__34_const_intnl_SystemString");
            Private___171_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__171_intnl_SystemBoolean");
            Private___14_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__14_intnl_PlayerData");
            Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__17_const_intnl_SystemString");
            Private___100_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__100_intnl_SystemBoolean");
            Private_timeLimit = new AstroUdonVariable<int>(GameData, "timeLimit");
            Private___6_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__6_intnl_TMProTextMeshProUGUI");
            Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__11_intnl_SystemInt32");
            Private___79_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__79_intnl_SystemBoolean");
            Private___92_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__92_intnl_SystemBoolean");
            Private___17_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__17_intnl_SystemInt32");
            Private___5_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__5_intnl_SystemInt64");
            Private___26_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__26_const_intnl_exitJumpLoc_UInt32");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__4_const_intnl_SystemString");
            Private___28_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__28_intnl_SystemObject");
            Private___81_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__81_intnl_SystemBoolean");
            Private___31_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__31_const_intnl_exitJumpLoc_UInt32");
            Private___5_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__5_intnl_TMProTextMeshProUGUI");
            Private___10_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__10_intnl_SystemString");
            Private___68_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__68_intnl_SystemBoolean");
            Private___67_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__67_const_intnl_SystemString");
            Private___20_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__20_const_intnl_SystemString");
            Private___188_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__188_intnl_SystemBoolean");
            Private___50_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__50_const_intnl_SystemString");
            Private___101_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__101_intnl_SystemBoolean");
            Private_startButtonEnabled = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startButtonEnabled");
            Private___7_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__7_intnl_UnityEngineGameObject");
            Private___7_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__7_intnl_PlayerData");
            Private___35_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__35_const_intnl_SystemString");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__11_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__2_intnl_SystemInt32");
            Private___17_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__17_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___189_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__189_intnl_SystemBoolean");
            Private___8_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__8_const_intnl_SystemInt32");
            Private___1_intnl_UnityEngineTransformArray = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "__1_intnl_UnityEngineTransformArray");
            Private___52_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__52_const_intnl_exitJumpLoc_UInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__4_const_intnl_exitJumpLoc_UInt32");
            Private_prisRatio = new AstroUdonVariable<float>(GameData, "prisRatio");
            Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__30_intnl_SystemBoolean");
            Private___0_updated_Boolean = new AstroUdonVariable<bool>(GameData, "__0_updated_Boolean");
            Private___26_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__26_intnl_SystemInt32");
            Private___54_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__54_intnl_SystemBoolean");
            Private___2_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__2_intnl_SystemString");
            Private_winState = new AstroUdonVariable<int>(GameData, "winState");
            Private___21_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__21_const_intnl_SystemString");
            Private___51_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__51_const_intnl_SystemString");
            Private___41_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__41_intnl_SystemInt32");
            Private___26_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__26_const_intnl_SystemString");
            Private___56_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__56_const_intnl_SystemString");
            Private___42_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__42_const_intnl_exitJumpLoc_UInt32");
            Private___71_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__71_intnl_SystemBoolean");
            Private___23_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__23_intnl_SystemString");
            Private___117_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__117_intnl_SystemBoolean");
            Private_winTitle = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "winTitle");
            Private___9_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__9_intnl_TMProTextMeshProUGUI");
            Private_countdownPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "countdownPanel");
            Private___0_players_Int32 = new AstroUdonVariable<int>(GameData, "__0_players_Int32");
            Private_timeRemaining = new AstroUdonVariable<int>(GameData, "timeRemaining");
            Private___9_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__9_const_intnl_exitJumpLoc_UInt32");
            Private___60_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__60_intnl_SystemBoolean");
            Private___196_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__196_intnl_SystemBoolean");
            Private___37_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__37_intnl_SystemBoolean");
            Private___82_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__82_intnl_SystemBoolean");
            Private___20_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__20_const_intnl_exitJumpLoc_UInt32");
            Private___168_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__168_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__1_intnl_UnityEngineGameObjectArray");
            Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__9_intnl_SystemInt32");
            Private___37_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__37_const_intnl_SystemString");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__2_intnl_SystemSingle");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__3_intnl_SystemBoolean");
            Private___147_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__147_intnl_SystemBoolean");
            Private_prisText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "prisText");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(GameData, "__0_intnl_returnValSymbol_Boolean");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__12_intnl_SystemBoolean");
            Private___9_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__9_intnl_SystemString");
            Private___10_intnl_SystemObject = new AstroUdonVariable<long>(GameData, "__10_intnl_SystemObject");
            Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__6_const_intnl_exitJumpLoc_UInt32");
            Private___169_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__169_intnl_SystemBoolean");
            Private___2_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__2_intnl_PlayerData");
            Private___18_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__18_intnl_SystemString");
            Private___70_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__70_const_intnl_SystemString");
            Private_doorControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "doorControl");
            Private___190_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__190_intnl_SystemBoolean");
            Private___67_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__67_intnl_SystemBoolean");
            Private___23_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__23_const_intnl_SystemString");
            Private___53_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__53_const_intnl_SystemString");
            Private_hiddenSpectate = new AstroUdonVariable<bool>(GameData, "hiddenSpectate");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__6_intnl_SystemInt32");
            Private___172_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__172_intnl_SystemBoolean");
            Private___9_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__9_const_intnl_SystemInt32");
            Private_cachedTimeLimit = new AstroUdonVariable<int>(GameData, "cachedTimeLimit");
            Private___44_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__44_intnl_SystemBoolean");
            Private___17_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__17_intnl_SystemSingle");
            Private_cachedWinState = new AstroUdonVariable<int>(GameData, "cachedWinState");
            Private___191_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__191_intnl_SystemBoolean");
            Private___29_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__29_intnl_SystemObject");
            Private___0_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__0_intnl_UnityEngineGameObjectArray");
            Private___82_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__82_const_intnl_SystemString");
            Private___72_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__72_intnl_SystemBoolean");
            Private___6_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__6_intnl_SystemString");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__0_intnl_SystemBoolean");
            Private___9_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__9_intnl_PlayerData");
            Private___34_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__34_const_intnl_exitJumpLoc_UInt32");
            Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__9_intnl_SystemSingle");
            Private___102_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__102_intnl_SystemBoolean");
            Private___71_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__71_const_intnl_SystemString");
            Private___76_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__76_const_intnl_SystemString");
            Private_startButtonDisabled = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startButtonDisabled");
            Private___22_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__22_intnl_SystemString");
            Private___124_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__124_intnl_SystemBoolean");
            Private_isGuard = new AstroUdonVariable<bool[]>(GameData, "isGuard");
            Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__12_const_intnl_SystemString");
            Private___38_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__38_const_intnl_exitJumpLoc_UInt32");
            Private___123_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__123_intnl_SystemBoolean");
            Private___0_this_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__0_this_intnl_UnityEngineGameObject");
            Private_prisSpawns = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "prisSpawns");
            Private___3_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__3_intnl_SystemObject");
            Private___23_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__23_intnl_SystemSingle");
            Private___0_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__0_intnl_UnityEngineGameObject");
            Private___125_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__125_intnl_SystemBoolean");
            Private___62_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__62_const_intnl_SystemString");
            Private___17_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__17_intnl_SystemObject");
            Private___158_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__158_intnl_SystemBoolean");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__8_const_intnl_SystemString");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__6_intnl_SystemSingle");
            Private___4_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__4_intnl_TMProTextMeshProUGUI");
            Private___33_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__33_const_intnl_exitJumpLoc_UInt32");
            Private___18_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__18_intnl_SystemObject");
            Private___0_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(GameData, "__0_intnl_UnityEngineQuaternion");
            Private___9_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__9_pData_PlayerData");
            Private___24_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__24_intnl_SystemSingle");
            Private___159_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__159_intnl_SystemBoolean");
            Private___58_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__58_intnl_SystemBoolean");
            Private___15_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__15_intnl_PlayerData");
            Private___137_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__137_intnl_SystemBoolean");
            Private_onPlayerJoinedPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameData, "onPlayerJoinedPlayer");
            Private___24_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__24_intnl_SystemString");
            Private_gameStartTime = new AstroUdonVariable<float>(GameData, "gameStartTime");
            Private___73_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__73_const_intnl_SystemString");
            Private_patronControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "patronControl");
            Private___15_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__15_const_intnl_exitJumpLoc_UInt32");
            Private___4_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__4_intnl_PlayerData");
            Private___16_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__16_intnl_SystemSingle");
            Private___3_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__3_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___2_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__2_intnl_SystemInt64");
            Private___1_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(GameData, "__1_mp_player_VRCPlayerApi");
            Private___4_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__4_pData_PlayerData");
            Private_timeLimitText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "timeLimitText");
            Private___19_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__19_const_intnl_exitJumpLoc_UInt32");
            Private___12_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__12_const_intnl_SystemInt32");
            Private___8_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__8_intnl_TMProTextMeshProUGUI");
            Private___21_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__21_intnl_SystemString");
            Private_timeoutSecs = new AstroUdonVariable<int>(GameData, "timeoutSecs");
            Private___114_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__114_intnl_SystemBoolean");
            Private___13_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__13_intnl_SystemString");
            Private___32_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__32_const_intnl_SystemString");
            Private___5_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__5_intnl_interpolatedStr_String");
            Private___113_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__113_intnl_SystemBoolean");
            Private___0_newPrisRatio_Single = new AstroUdonVariable<float>(GameData, "__0_newPrisRatio_Single");
            Private___29_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__29_intnl_SystemInt32");
            Private___35_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__35_intnl_SystemBoolean");
            Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__8_const_intnl_exitJumpLoc_UInt32");
            Private___0_rand_Int32 = new AstroUdonVariable<int>(GameData, "__0_rand_Int32");
            Private___50_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__50_intnl_SystemBoolean");
            Private___22_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__22_intnl_SystemSingle");
            Private___192_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__192_intnl_SystemBoolean");
            Private___7_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__7_intnl_SystemObject");
            Private___22_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__22_const_intnl_exitJumpLoc_UInt32");
            Private___115_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__115_intnl_SystemBoolean");
            Private_joinError = new AstroUdonVariable<bool>(GameData, "joinError");
            Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__24_intnl_SystemBoolean");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__9_const_intnl_SystemString");
            Private___13_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__13_intnl_PlayerData");
            Private___13_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__13_const_intnl_SystemInt32");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__0_intnl_SystemInt32");
            Private___9_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__9_intnl_SystemInt64");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(GameData, "__0_intnl_returnTarget_UInt32");
            Private___144_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__144_intnl_SystemBoolean");
            Private_cachedGameStarted = new AstroUdonVariable<bool>(GameData, "cachedGameStarted");
            Private___48_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__48_intnl_SystemBoolean");
            Private___0_mp_error_Boolean = new AstroUdonVariable<bool>(GameData, "__0_mp_error_Boolean");
            Private_guardText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "guardText");
            Private___143_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__143_intnl_SystemBoolean");
            Private___30_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__30_intnl_SystemInt32");
            Private___45_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__45_const_intnl_exitJumpLoc_UInt32");
            Private___44_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__44_const_intnl_SystemString");
            Private___65_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__65_intnl_SystemBoolean");
            Private___92_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__92_const_intnl_SystemString");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__0_intnl_SystemString");
            Private___33_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__33_intnl_SystemBoolean");
            Private___145_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__145_intnl_SystemBoolean");
            Private___57_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__57_intnl_SystemBoolean");
            Private___33_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__33_intnl_SystemInt32");
            Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__10_intnl_SystemInt32");
            Private___49_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__49_const_intnl_exitJumpLoc_UInt32");
            Private___126_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__126_intnl_SystemBoolean");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(GameData, "__0_const_intnl_SystemUInt32");
            Private___6_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__6_intnl_SystemInt64");
            Private___178_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__178_intnl_SystemBoolean");
            Private___8_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__8_intnl_UnityEngineGameObjectArray");
            Private___16_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__16_intnl_PlayerData");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__9_intnl_SystemBoolean");
            Private___19_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__19_intnl_SystemObject");
            Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__13_intnl_SystemInt32");
            Private___36_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__36_const_intnl_exitJumpLoc_UInt32");
            Private___45_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__45_const_intnl_SystemString");
            Private___63_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__63_intnl_SystemBoolean");
            Private___36_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__36_intnl_SystemBoolean");
            Private___179_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__179_intnl_SystemBoolean");
            Private___88_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__88_const_intnl_SystemString");
            Private_spectatePanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "spectatePanel");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__0_intnl_SystemSingle");
            Private___108_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__108_intnl_SystemBoolean");
            Private___12_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__12_intnl_SystemString");
            Private___40_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__40_intnl_SystemBoolean");
            Private___120_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__120_intnl_SystemBoolean");
            Private___94_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__94_intnl_SystemBoolean");
            Private___25_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__25_intnl_SystemInt32");
            Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__18_const_intnl_SystemString");
            Private___109_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__109_intnl_SystemBoolean");
            Private___40_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__40_intnl_SystemInt32");
            Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__13_intnl_SystemSingle");
            Private_prisRatioSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(GameData, "prisRatioSlider");
            Private___66_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__66_intnl_SystemBoolean");
            Private___121_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__121_intnl_SystemBoolean");
            Private___22_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__22_intnl_SystemInt32");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__4_intnl_SystemInt32");
            Private___187_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__187_intnl_SystemBoolean");
            Private___89_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__89_const_intnl_SystemString");
            Private___68_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__68_const_intnl_SystemString");
            Private___14_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__14_intnl_SystemSingle");
            Private___47_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__47_intnl_SystemBoolean");
            Private_gateControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "gateControl");
            Private___4_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__4_intnl_SystemString");
            Private___134_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__134_intnl_SystemBoolean");
            Private_masterText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "masterText");
            Private___47_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__47_const_intnl_SystemString");
            Private___133_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__133_intnl_SystemBoolean");
            Private_spectatorDisplay = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "spectatorDisplay");
            Private___4_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__4_intnl_UnityEngineTransform");
            Private___14_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__14_intnl_SystemString");
            Private___10_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__10_const_intnl_SystemInt32");
            Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__19_const_intnl_SystemString");
            Private___17_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__17_const_intnl_exitJumpLoc_UInt32");
            Private___7_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__7_intnl_TMProTextMeshProUGUI");
            Private___116_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__116_intnl_SystemBoolean");
            Private_startTimeoutText = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startTimeoutText");
            Private___135_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__135_intnl_SystemBoolean");
            Private___30_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__30_const_intnl_exitJumpLoc_UInt32");
            Private___39_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__39_intnl_SystemBoolean");
            Private___69_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__69_const_intnl_SystemString");
            Private___0_prisoners_Int32 = new AstroUdonVariable<int>(GameData, "__0_prisoners_Int32");
            Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__28_intnl_SystemBoolean");
            Private___36_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__36_intnl_SystemInt32");
            Private___0_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__0_pData_PlayerData");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__6_intnl_SystemBoolean");
            Private_startPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "startPanel");
            Private___20_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__20_intnl_SystemSingle");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__4_intnl_SystemSingle");
            Private___11_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__11_intnl_SystemString");
            Private___146_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__146_intnl_SystemBoolean");
            Private___1_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__1_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___84_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__84_intnl_SystemBoolean");
            Private___110_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__110_intnl_SystemBoolean");
            Private___24_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__24_const_intnl_SystemString");
            Private___54_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__54_const_intnl_SystemString");
            Private___16_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__16_intnl_SystemInt32");
            Private___69_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__69_intnl_SystemBoolean");
            Private___167_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__167_intnl_SystemBoolean");
            Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__12_intnl_SystemSingle");
            Private___38_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__38_const_intnl_SystemString");
            Private___198_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__198_intnl_SystemBoolean");
            Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__14_intnl_SystemBoolean");
            Private___1_guards_Int32 = new AstroUdonVariable<int>(GameData, "__1_guards_Int32");
            Private_lootCrateControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "lootCrateControl");
            Private_openableControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "openableControl");
            Private___111_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__111_intnl_SystemBoolean");
            Private___2_obj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__2_obj_GameObject");
            Private___0_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__0_intnl_SystemInt64");
            Private___140_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__140_intnl_SystemBoolean");
            Private___10_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__10_intnl_TMProTextMeshProUGUI");
            Private___47_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__47_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__3_intnl_SystemInt32");
            Private___31_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__31_intnl_SystemBoolean");
            Private___199_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__199_intnl_SystemBoolean");
            Private___55_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__55_intnl_SystemBoolean");
            Private___25_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__25_const_intnl_SystemString");
            Private___55_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__55_const_intnl_SystemString");
            Private___5_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__5_intnl_UnityEngineGameObject");
            Private___11_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__11_const_intnl_exitJumpLoc_UInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__8_intnl_SystemBoolean");
            Private___1_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__1_intnl_interpolatedStr_String");
            Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__20_intnl_SystemBoolean");
            Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameData, "__2_intnl_UnityEngineVector3");
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__3_intnl_SystemString");
            Private___141_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__141_intnl_SystemBoolean");
            Private___39_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__39_const_intnl_SystemString");
            Private___74_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__74_intnl_SystemBoolean");
            Private___7_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__7_intnl_UnityEngineTransform");
            Private___1_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__1_intnl_SystemObject");
            Private___122_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__122_intnl_SystemBoolean");
            Private___0_guard_Boolean = new AstroUdonVariable<bool>(GameData, "__0_guard_Boolean");
            Private___25_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__25_const_intnl_exitJumpLoc_UInt32");
            Private___33_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__33_intnl_SystemObject");
            Private___61_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__61_intnl_SystemBoolean");
            Private___98_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__98_intnl_SystemBoolean");
            Private_afkDetector = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "afkDetector");
            Private___8_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__8_intnl_UnityEngineTransform");
            Private___29_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__29_const_intnl_exitJumpLoc_UInt32");
            Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameData, "__1_intnl_UnityEngineVector3");
            Private___53_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__53_intnl_SystemBoolean");
            Private___4_intnl_interpolatedStr_String = new AstroUdonVariable<string>(GameData, "__4_intnl_interpolatedStr_String");
            Private___80_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__80_const_intnl_SystemString");
            Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__27_intnl_SystemBoolean");
            Private___19_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__19_intnl_SystemString");
            Private___51_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__51_const_intnl_exitJumpLoc_UInt32");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__3_intnl_SystemSingle");
            Private___74_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__74_const_intnl_SystemString");
            Private___0_intnl_UnityEngineAnimator = new AstroUdonVariable<UnityEngine.Animator>(GameData, "__0_intnl_UnityEngineAnimator");
            Private___157_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__157_intnl_SystemBoolean");
            Private___136_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__136_intnl_SystemBoolean");
            Private___27_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__27_const_intnl_SystemString");
            Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(GameData, "__0_intnl_UnityEngineVector3");
            Private___57_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__57_const_intnl_SystemString");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__10_const_intnl_SystemString");
            Private___4_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "__4_intnl_UnityEngineGameObjectArray");
            Private_prisObjects = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "prisObjects");
            Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__32_intnl_SystemBoolean");
            Private___4_intnl_UnityEngineComponent = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__4_intnl_UnityEngineComponent");
            Private___30_intnl_SystemObject = new AstroUdonVariable<long>(GameData, "__30_intnl_SystemObject");
            Private___56_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__56_intnl_SystemBoolean");
            Private___2_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__2_intnl_TMProTextMeshProUGUI");
            Private___41_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__41_const_intnl_exitJumpLoc_UInt32");
            Private___42_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__42_const_intnl_SystemString");
            Private___18_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__18_intnl_SystemSingle");
            Private___184_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__184_intnl_SystemBoolean");
            Private___16_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__16_intnl_SystemObject");
            Private___4_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__4_intnl_SystemInt64");
            Private___45_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__45_intnl_SystemBoolean");
            Private___81_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__81_const_intnl_SystemString");
            Private___60_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__60_const_intnl_SystemString");
            Private___183_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__183_intnl_SystemBoolean");
            Private___28_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__28_intnl_SystemInt32");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__7_intnl_SystemInt32");
            Private___1_intnl_TMProTextMeshProUGUI = new AstroUdonVariable<TMPro.TextMeshProUGUI>(GameData, "__1_intnl_TMProTextMeshProUGUI");
            Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__0_intnl_UnityEngineTransform");
            Private___86_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__86_const_intnl_SystemString");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__1_const_intnl_SystemBoolean");
            Private___0_mp_spawns_TransformArray = new AstroUdonVariable<UnityEngine.Transform[]>(GameData, "__0_mp_spawns_TransformArray");
            Private___90_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__90_intnl_SystemBoolean");
            Private___75_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__75_const_intnl_SystemString");
            Private___130_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__130_intnl_SystemBoolean");
            Private___185_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__185_intnl_SystemBoolean");
            Private___0_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(GameData, "__0_intnl_UnityEngineColor");
            Private___3_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__3_intnl_PlayerData");
            Private___7_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__7_intnl_SystemString");
            Private___62_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__62_intnl_SystemBoolean");
            Private___200_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__200_intnl_SystemBoolean");
            Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__11_const_intnl_SystemString");
            Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__16_const_intnl_SystemString");
            Private___112_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__112_intnl_SystemBoolean");
            Private___88_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__88_intnl_SystemBoolean");
            Private___32_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__32_const_intnl_exitJumpLoc_UInt32");
            Private_cachedPrisRatio = new AstroUdonVariable<float>(GameData, "cachedPrisRatio");
            Private_afkRespawn = new AstroUdonVariable<UnityEngine.Transform>(GameData, "afkRespawn");
            Private___0_const_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__0_const_intnl_SystemInt64");
            Private___131_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__131_intnl_SystemBoolean");
            Private___43_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__43_intnl_SystemBoolean");
            Private___61_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__61_const_intnl_SystemString");
            Private___66_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__66_const_intnl_SystemString");
            Private___5_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__5_intnl_UnityEngineTransform");
            Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__18_intnl_SystemBoolean");
            Private___97_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__97_intnl_SystemBoolean");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__2_intnl_SystemBoolean");
            Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__10_intnl_SystemSingle");
            Private___25_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__25_intnl_SystemSingle");
            Private___14_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__14_const_intnl_exitJumpLoc_UInt32");
            Private___142_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__142_intnl_SystemBoolean");
            Private___83_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__83_const_intnl_SystemString");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__3_const_intnl_SystemInt32");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__7_intnl_SystemSingle");
            Private___37_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__37_intnl_SystemObject");
            Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(GameData, "__0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget");
            Private___164_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__164_intnl_SystemBoolean");
            Private___59_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__59_intnl_SystemBoolean");
            Private___163_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__163_intnl_SystemBoolean");
            Private___18_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__18_const_intnl_exitJumpLoc_UInt32");
            Private___46_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__46_intnl_SystemBoolean");
            Private___17_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__17_intnl_SystemString");
            Private___39_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__39_intnl_SystemInt32");
            Private_playerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "playerObjectPool");
            Private___77_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__77_const_intnl_SystemString");
            Private___30_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__30_const_intnl_SystemString");
            Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__13_const_intnl_SystemString");
            Private___78_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__78_intnl_SystemBoolean");
            Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__8_intnl_SystemInt32");
            Private_guardHealth = new AstroUdonVariable<int>(GameData, "guardHealth");
            Private___165_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__165_intnl_SystemBoolean");
            Private___7_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__7_intnl_UnityEngineComponent");
            Private___0_randomIndex_Int32 = new AstroUdonVariable<int>(GameData, "__0_randomIndex_Int32");
            Private___80_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__80_intnl_SystemBoolean");
            Private___19_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__19_intnl_SystemInt32");
            Private_winPanel = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "winPanel");
            Private___24_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__24_intnl_SystemInt32");
            Private___63_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__63_const_intnl_SystemString");
            Private___8_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__8_intnl_SystemString");
            Private___3_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__3_intnl_SystemInt64");
            Private___15_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(GameData, "__15_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___13_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__13_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.RectTransform>(GameData, "__3_intnl_UnityEngineTransform");
            Private___0_timeText_String = new AstroUdonVariable<string>(GameData, "__0_timeText_String");
            Private___2_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__2_intnl_UnityEngineGameObject");
            Private_guardObjects = new AstroUdonVariable<UnityEngine.GameObject[]>(GameData, "guardObjects");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__10_intnl_SystemBoolean");
            Private___34_intnl_SystemObject = new AstroUdonVariable<bool>(GameData, "__34_intnl_SystemObject");
            Private___90_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__90_const_intnl_SystemString");
            Private___177_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__177_intnl_SystemBoolean");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__2_const_intnl_SystemString");
            Private___31_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__31_const_intnl_SystemString");
            Private___31_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__31_intnl_SystemObject");
            Private___21_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__21_intnl_SystemInt32");
            Private___27_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__27_const_intnl_exitJumpLoc_UInt32");
            Private___27_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__27_intnl_SystemInt32");
            Private___36_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__36_const_intnl_SystemString");
            Private___4_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(GameData, "__4_intnl_UnityEngineComponentArray");
            Private___1_const_intnl_SystemInt64 = new AstroUdonVariable<long>(GameData, "__1_const_intnl_SystemInt64");
            Private___44_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__44_const_intnl_exitJumpLoc_UInt32");
            Private___128_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__128_intnl_SystemBoolean");
            Private___5_pData_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__5_pData_PlayerData");
            Private___87_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__87_intnl_SystemBoolean");
            Private___51_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__51_intnl_SystemBoolean");
            Private_displayWinner = new AstroUdonVariable<bool>(GameData, "displayWinner");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(GameData, "__0_const_intnl_SystemInt32");
            Private___107_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__107_intnl_SystemBoolean");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__25_intnl_SystemBoolean");
            Private___0_guardCount_Int32 = new AstroUdonVariable<int>(GameData, "__0_guardCount_Int32");
            Private___48_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(GameData, "__48_const_intnl_exitJumpLoc_UInt32");
            Private___22_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__22_const_intnl_SystemString");
            Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(GameData, "__8_intnl_SystemSingle");
            Private___52_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__52_const_intnl_SystemString");
            Private___70_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__70_intnl_SystemBoolean");
            Private___129_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__129_intnl_SystemBoolean");
            Private___0_obj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(GameData, "__0_obj_GameObject");
            Private___186_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__186_intnl_SystemBoolean");
            Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__17_intnl_SystemBoolean");
            Private___1_prisCount_Int32 = new AstroUdonVariable<int>(GameData, "__1_prisCount_Int32");
            Private___49_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__49_intnl_SystemBoolean");
            Private___91_const_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__91_const_intnl_SystemString");
            Private___0_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(GameData, "__0_intnl_returnValSymbol_Int32");
            Private___0_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GameData, "__0_intnl_UnityEngineComponent");
            Private___154_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__154_intnl_SystemBoolean");
            Private___16_intnl_SystemString = new AstroUdonVariable<string>(GameData, "__16_intnl_SystemString");
            Private___153_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__153_intnl_SystemBoolean");
            Private___132_intnl_SystemBoolean = new AstroUdonVariable<bool>(GameData, "__132_intnl_SystemBoolean");
            Private___9_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(GameData, "__9_intnl_UnityEngineTransform");
        }

        #region UdonVariables  of GameData

        private AstroUdonVariable<string> Private___3_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___6_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___35_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___43_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_updatedTeams { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___33_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___0_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_newTimeLimit_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___10_pData_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_guards_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___155_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_playerDataObj_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___32_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___180_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___77_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___8_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___48_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___7_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___15_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___1_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___3_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___5_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___21_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___12_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___181_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___52_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform[]> Private_guardSpawns { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___26_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Quaternion> Private___1_intnl_UnityEngineQuaternion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___41_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___1_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___166_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___118_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___95_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___49_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_scoreboardDisplay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___16_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_versionErrorPanel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_prisoners_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___72_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___119_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___15_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___35_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___8_pData_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___148_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___0_const_intnl_VRCUdonCommonEnumsEventTiming { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___15_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___197_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___160_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___42_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_itemControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___35_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_gameStartDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___3_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___93_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___149_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___8_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___161_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___39_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_pData_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_desktopInteract { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_mp_lastAlive_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_prisRatioText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___21_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___42_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___29_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_playerTracker { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___174_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___96_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Slider> Private_timeLimitSlider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___173_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___9_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___46_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___85_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_winSubtitle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___9_intnl_VRCSDK3ComponentsVRCObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___156_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___175_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___32_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___10_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_updatingTimeRemaining { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___11_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___104_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_syncedTimeRemaining { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___103_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___24_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___182_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___20_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___6_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_lastAlive_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___105_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___34_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___28_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___2_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___58_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___83_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___150_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___28_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_joinErrorPanel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private___7_intnl_UnityEngineGameObjectArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___138_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___201_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_prisCount_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_sceneControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___75_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___50_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___151_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_gameStarted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___64_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___40_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___139_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___99_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___38_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_versionError { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___86_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___29_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___23_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___59_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___84_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___40_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___3_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___18_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___73_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___162_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___1_obj_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_guardCount_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_GameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___19_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___41_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___46_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___20_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___1_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___85_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___64_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___20_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___0_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___76_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___194_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform[]> Private_respawnPoints { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___78_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___23_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___91_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___37_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___193_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___36_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___176_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___195_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_masterName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___2_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_spawn_Transform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___89_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___65_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_playerCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gameJoinTrigger { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___11_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___106_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___43_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___34_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gameEffects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___79_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_gameStartCountdown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___127_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___170_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___87_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_audioControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_startButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___0_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___38_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___31_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___37_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___14_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_escapeeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___2_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___152_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___12_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___34_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___171_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___14_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___100_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_timeLimit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___6_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___11_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___79_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___92_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___17_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___5_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___26_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___28_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___81_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___31_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___5_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___68_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___67_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___20_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___188_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___50_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___101_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_startButtonEnabled { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___7_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___7_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___35_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___17_intnl_VRCSDK3ComponentsVRCObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___189_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform[]> Private___1_intnl_UnityEngineTransformArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___52_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_prisRatio { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___30_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_updated_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___26_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___54_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_winState { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___21_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___51_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___41_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___26_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___56_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___42_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___71_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___23_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___117_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_winTitle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___9_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_countdownPanel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_players_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_timeRemaining { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___9_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___60_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___196_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___37_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___82_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___20_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___168_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private___1_intnl_UnityEngineGameObjectArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___37_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___147_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_prisText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___10_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___169_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___18_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___70_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_doorControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___190_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___67_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___23_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___53_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_hiddenSpectate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___172_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_cachedTimeLimit { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___44_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___17_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_cachedWinState { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___191_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___29_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private___0_intnl_UnityEngineGameObjectArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___82_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___72_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___9_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___34_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___102_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___71_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___76_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_startButtonDisabled { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___22_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___124_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool[]> Private_isGuard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___38_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___123_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_this_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform[]> Private_prisSpawns { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___23_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___125_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___62_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___17_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___158_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___4_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___33_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___18_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Quaternion> Private___0_intnl_UnityEngineQuaternion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___9_pData_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___24_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___159_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___58_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___15_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___137_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_onPlayerJoinedPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___24_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_gameStartTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___73_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_patronControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___15_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___4_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___16_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___3_intnl_VRCSDK3ComponentsVRCObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___2_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___4_pData_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_timeLimitText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___19_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___12_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___8_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___21_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_timeoutSecs { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___114_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___32_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___113_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_newPrisRatio_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___29_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___35_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_rand_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___50_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___22_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___192_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___22_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___115_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_joinError { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___24_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___13_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___13_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___9_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___144_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedGameStarted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___48_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_error_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_guardText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___143_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___30_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___45_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___44_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___65_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___92_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___33_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___145_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___57_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___33_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___10_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___49_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___126_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___6_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___178_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private___8_intnl_UnityEngineGameObjectArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___16_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___19_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___13_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___36_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___45_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___63_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___36_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___179_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___88_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_spectatePanel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___108_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___40_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___120_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___94_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___25_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___109_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___40_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___13_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Slider> Private_prisRatioSlider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___66_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___121_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___22_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___187_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___89_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___68_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___14_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___47_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gateControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___134_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_masterText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___47_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___133_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_spectatorDisplay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___4_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___14_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___10_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___19_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___17_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___7_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___116_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_startTimeoutText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___135_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___30_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___39_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___69_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_prisoners_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___28_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___36_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_pData_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_startPanel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___20_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___146_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___1_intnl_VRCSDK3ComponentsVRCObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___84_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___110_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___24_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___54_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___16_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___69_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___167_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___12_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___38_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___198_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_guards_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_lootCrateControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_openableControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___111_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___2_obj_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___140_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___10_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___47_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___31_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___199_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___55_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___25_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___55_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___5_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___11_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___20_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___2_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___141_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___39_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___74_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___7_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___122_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_guard_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___25_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___33_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___61_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___98_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_afkDetector { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___8_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___29_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___53_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___80_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___27_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___19_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___51_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___74_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Animator> Private___0_intnl_UnityEngineAnimator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___157_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___136_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___27_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___57_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private___4_intnl_UnityEngineGameObjectArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private_prisObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___32_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___4_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___30_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___56_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___2_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___41_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___42_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___18_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___184_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___16_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___4_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___45_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___81_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___60_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___183_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___28_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___1_intnl_TMProTextMeshProUGUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___86_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform[]> Private___0_mp_spawns_TransformArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___90_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___75_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___130_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___185_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___0_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___3_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___62_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___200_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___112_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___88_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___32_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_cachedPrisRatio { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_afkRespawn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___131_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___43_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___61_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___66_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___5_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___97_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___25_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___14_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___142_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___83_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___37_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget> Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___164_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___59_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___163_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___18_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___46_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___17_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___39_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_playerObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___77_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___30_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___78_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_guardHealth { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___165_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___7_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_randomIndex_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___80_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___19_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_winPanel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___24_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___63_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___3_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___15_intnl_VRCSDK3ComponentsVRCObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___13_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private___3_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_timeText_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___2_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private_guardObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___34_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___90_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___177_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___31_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___31_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___21_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___27_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___27_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___36_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___4_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___1_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___44_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___128_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___5_pData_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___87_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___51_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_displayWinner { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___107_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___25_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_guardCount_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___48_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___22_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___52_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___70_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___129_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_obj_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___186_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_prisCount_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___49_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___91_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___154_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___16_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___153_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___132_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___9_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion UdonVariables  of GameData

        internal RawUdonBehaviour GameData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    }
}