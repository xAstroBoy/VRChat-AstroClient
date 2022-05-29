using AstroClient.ClientActions;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape;

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
    using UnityEngine;

    [RegisterComponent]
    public class PrisonEscape_PoolDataReader : MonoBehaviour
    {
        private List<Il2CppSystem.Object> AntiGarbageCollection = new();

        public PrisonEscape_PoolDataReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PrisonEscape))
            {
                var obj = gameObject.FindUdonEvent("_SetWantedSynced");
                if (obj != null)
                {
                    PlayerData = obj.RawItem;
                    Initialize_PlayerData();
                    HasSubscribed = true;
                }
                else
                {
                    Log.Error($"Can't Find Player Data behaviour, Unable to Add Reader on  {gameObject.name} GameObject, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnDestroy()
        {
            HasSubscribed = false;
            Cleanup_PlayerData();
        }




        [HideFromIl2Cpp]
        private bool isNotPoolOrThisBehaviour(UdonBehaviour behaviour)
        {
            try
            {
                if (behaviour != null && behaviour != PlayerData.udonBehaviour && behaviour.name.Contains("Player"))
                {
                    if (behaviour.gameObject != PrisonEscape.Player_Object_Pool)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }

            return false;
        }

        internal PrisonEscape_PoolDataReader GetActualDataReader
        {
            get
            {
                //if (!HitBoxReader.Root.active) return null; // do this to allow more accuracy and get the correct ones!

                #region PlayerData Zone

                if (isNotPoolOrThisBehaviour(__0_this_intnl_PlayerData))
                {
                    return __0_this_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__0_intnl_PlayerData))
                {
                    return __0_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__1_intnl_PlayerData))
                {
                    return __1_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__2_intnl_PlayerData))
                {
                    return __2_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__3_intnl_PlayerData))
                {
                    return __3_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__4_intnl_PlayerData))
                {
                    return __4_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__5_intnl_PlayerData))
                {
                    return __5_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                //else if (isNotPoolOrThisBehaviour(__6_intnl_PlayerData))
                //{
                //    return __6_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__7_intnl_PlayerData))
                //{
                //    return __7_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__8_intnl_PlayerData))
                //{
                //    return __8_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__9_intnl_PlayerData))
                //{
                //    return __9_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__10_intnl_PlayerData))
                //{
                //    return __10_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__11_intnl_PlayerData))
                //{
                //    return __11_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__12_intnl_PlayerData))
                //{
                //    return __12_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__13_intnl_PlayerData))
                //{
                //    return __13_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__14_intnl_PlayerData))
                //{
                //    return __14_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__15_intnl_PlayerData))
                //{
                //    return __15_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__16_intnl_PlayerData))
                //{
                //    return __16_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__17_intnl_PlayerData))
                //{
                //    return __17_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__18_intnl_PlayerData))
                //{
                //    return __18_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__19_intnl_PlayerData))
                //{
                //    return __19_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__20_intnl_PlayerData))
                //{
                //    return __20_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}

                #endregion PlayerData Zone

                #region SystemObject Zone

                else if (isNotPoolOrThisBehaviour(__0_intnl_SystemObject))
                {
                    return __0_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__1_intnl_SystemObject))
                {
                    return __1_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__5_intnl_SystemObject))
                {
                    return __5_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__7_intnl_SystemObject))
                {
                    return __7_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__9_intnl_SystemObject))
                {
                    return __9_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__10_intnl_SystemObject))
                {
                    return __10_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__11_intnl_SystemObject))
                {
                    return __11_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__12_intnl_SystemObject))
                {
                    return __12_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__13_intnl_SystemObject))
                {
                    return __13_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__14_intnl_SystemObject))
                {
                    return __14_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__15_intnl_SystemObject))
                {
                    return __15_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__16_intnl_SystemObject))
                {
                    return __16_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__17_intnl_SystemObject))
                {
                    return __17_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__18_intnl_SystemObject))
                {
                    return __18_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__19_intnl_SystemObject))
                {
                    return __19_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__20_intnl_SystemObject))
                {
                    return __20_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__22_intnl_SystemObject))
                {
                    return __22_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__23_intnl_SystemObject))
                {
                    return __23_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__25_intnl_SystemObject))
                {
                    return __25_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__29_intnl_SystemObject))
                {
                    return __29_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                else if (isNotPoolOrThisBehaviour(__30_intnl_SystemObject))
                {
                    return __30_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                }
                #endregion SystemObject Zone

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


        private static RawUdonBehaviour PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;


        #region Getter / Setters UdonVariables  of PlayerData

        internal int? __18_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_const_intnl_SystemInt32 != null)
                {
                    return Private___18_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_const_intnl_SystemInt32 != null)
                    {
                        Private___18_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isWanted
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isWanted != null)
                {
                    return Private_isWanted.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isWanted != null)
                    {
                        Private_isWanted.Value = value.Value;
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

        internal int? __20_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_const_intnl_SystemInt32 != null)
                {
                    return Private___20_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___20_const_intnl_SystemInt32 != null)
                    {
                        Private___20_const_intnl_SystemInt32.Value = value.Value;
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

        internal UnityEngine.Transform __1_intnl_UnityEngineTransform
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

        internal VRC.Udon.UdonBehaviour __0_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_PlayerObjectPool != null)
                {
                    return Private___0_intnl_PlayerObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_PlayerObjectPool != null)
                {
                    Private___0_intnl_PlayerObjectPool.Value = value;
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

        internal UnityEngine.Transform __2_intnl_SystemObject
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
                if (Private___2_intnl_SystemObject != null)
                {
                    Private___2_intnl_SystemObject.Value = value;
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

        internal bool? doublePoints
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_doublePoints != null)
                {
                    return Private_doublePoints.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_doublePoints != null)
                    {
                        Private_doublePoints.Value = value.Value;
                    }
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

        internal uint? __56_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___56_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___56_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___56_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___56_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __9_intnl_SystemObject
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

        internal float? tagHeightScalar
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tagHeightScalar != null)
                {
                    return Private_tagHeightScalar.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_tagHeightScalar != null)
                    {
                        Private_tagHeightScalar.Value = value.Value;
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

        internal int? __35_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_const_intnl_SystemInt32 != null)
                {
                    return Private___35_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_const_intnl_SystemInt32 != null)
                    {
                        Private___35_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour hitbox
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hitbox != null)
                {
                    return Private_hitbox.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_hitbox != null)
                {
                    Private_hitbox.Value = value;
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

        internal VRC.Udon.UdonBehaviour __2_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_PlayerObjectPool != null)
                {
                    return Private___2_intnl_PlayerObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_PlayerObjectPool != null)
                {
                    Private___2_intnl_PlayerObjectPool.Value = value;
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

        internal UnityEngine.Transform __2_intnl_UnityEngineTransform
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

        internal int? maxHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_maxHealth != null)
                {
                    return Private_maxHealth.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_maxHealth != null)
                    {
                        Private_maxHealth.Value = value.Value;
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

        internal bool? cachedIsWanted
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedIsWanted != null)
                {
                    return Private_cachedIsWanted.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedIsWanted != null)
                    {
                        Private_cachedIsWanted.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __5_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_PlayerObjectPool != null)
                {
                    return Private___5_intnl_PlayerObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_PlayerObjectPool != null)
                {
                    Private___5_intnl_PlayerObjectPool.Value = value;
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

        internal float? __1_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_SystemSingle != null)
                {
                    return Private___1_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_SystemSingle != null)
                    {
                        Private___1_const_intnl_SystemSingle.Value = value.Value;
                    }
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

        internal int? __25_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___25_const_intnl_SystemInt32 != null)
                {
                    return Private___25_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___25_const_intnl_SystemInt32 != null)
                    {
                        Private___25_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal bool? goldGuns
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_goldGuns != null)
                {
                    return Private_goldGuns.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_goldGuns != null)
                    {
                        Private_goldGuns.Value = value.Value;
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

        internal int? __1_mp_hp_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_hp_Int32 != null)
                {
                    return Private___1_mp_hp_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_hp_Int32 != null)
                    {
                        Private___1_mp_hp_Int32.Value = value.Value;
                    }
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

        internal int? __38_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___38_const_intnl_SystemInt32 != null)
                {
                    return Private___38_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___38_const_intnl_SystemInt32 != null)
                    {
                        Private___38_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __20_intnl_SystemObject
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

        internal VRC.Udon.UdonBehaviour __4_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_PlayerObjectPool != null)
                {
                    return Private___4_intnl_PlayerObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_PlayerObjectPool != null)
                {
                    Private___4_intnl_PlayerObjectPool.Value = value;
                }
            }
        }

        internal bool? __0_mp_playing_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_playing_Boolean != null)
                {
                    return Private___0_mp_playing_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_playing_Boolean != null)
                    {
                        Private___0_mp_playing_Boolean.Value = value.Value;
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

        internal int? __16_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___16_const_intnl_SystemInt32 != null)
                {
                    return Private___16_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___16_const_intnl_SystemInt32 != null)
                    {
                        Private___16_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal int? health
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_health != null)
                {
                    return Private_health.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_health != null)
                    {
                        Private_health.Value = value.Value;
                    }
                }
            }
        }

        internal float? healthRegenDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_healthRegenDelay != null)
                {
                    return Private_healthRegenDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_healthRegenDelay != null)
                    {
                        Private_healthRegenDelay.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_SystemObject
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

        internal int? __28_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___28_const_intnl_SystemInt32 != null)
                {
                    return Private___28_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___28_const_intnl_SystemInt32 != null)
                    {
                        Private___28_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __17_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_const_intnl_SystemInt32 != null)
                {
                    return Private___17_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_const_intnl_SystemInt32 != null)
                    {
                        Private___17_const_intnl_SystemInt32.Value = value.Value;
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

        internal bool? __0_mp_wanted_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_wanted_Boolean != null)
                {
                    return Private___0_mp_wanted_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_wanted_Boolean != null)
                    {
                        Private___0_mp_wanted_Boolean.Value = value.Value;
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

        internal int? __31_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_const_intnl_SystemInt32 != null)
                {
                    return Private___31_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___31_const_intnl_SystemInt32 != null)
                    {
                        Private___31_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __4_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_SystemObject != null)
                {
                    return Private___4_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_SystemObject != null)
                {
                    Private___4_intnl_SystemObject.Value = value;
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

        internal VRC.Udon.UdonBehaviour __0_this_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_PlayerData != null)
                {
                    return Private___0_this_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_PlayerData != null)
                {
                    Private___0_this_intnl_PlayerData.Value = value;
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

        internal VRC.Udon.UdonBehaviour __10_intnl_SystemObject
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
                if (Private___10_intnl_SystemObject != null)
                {
                    Private___10_intnl_SystemObject.Value = value;
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

        internal UnityEngine.Vector3? __5_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_UnityEngineVector3 != null)
                {
                    return Private___5_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_intnl_UnityEngineVector3 != null)
                    {
                        Private___5_intnl_UnityEngineVector3.Value = value.Value;
                    }
                }
            }
        }

        internal int? __14_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_const_intnl_SystemInt32 != null)
                {
                    return Private___14_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___14_const_intnl_SystemInt32 != null)
                    {
                        Private___14_const_intnl_SystemInt32.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __29_intnl_SystemObject
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

        internal int? __19_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_const_intnl_SystemInt32 != null)
                {
                    return Private___19_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_const_intnl_SystemInt32 != null)
                    {
                        Private___19_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal UnityEngine.Vector3? __4_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_UnityEngineVector3 != null)
                {
                    return Private___4_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_intnl_UnityEngineVector3 != null)
                    {
                        Private___4_intnl_UnityEngineVector3.Value = value.Value;
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

        internal int? __21_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_const_intnl_SystemInt32 != null)
                {
                    return Private___21_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___21_const_intnl_SystemInt32 != null)
                    {
                        Private___21_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? cachedIsDead
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedIsDead != null)
                {
                    return Private_cachedIsDead.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedIsDead != null)
                    {
                        Private_cachedIsDead.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isGuard
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
                if (value.HasValue)
                {
                    if (Private_isGuard != null)
                    {
                        Private_isGuard.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour __1_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_PlayerData != null)
                {
                    return Private___1_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_PlayerData != null)
                {
                    Private___1_intnl_PlayerData.Value = value;
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

        internal float? __3_intnl_SystemObject
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

        internal int? __36_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___36_const_intnl_SystemInt32 != null)
                {
                    return Private___36_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___36_const_intnl_SystemInt32 != null)
                    {
                        Private___36_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal string cachedPlayerName
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedPlayerName != null)
                {
                    return Private_cachedPlayerName.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cachedPlayerName != null)
                {
                    Private_cachedPlayerName.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __11_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___11_intnl_SystemObject != null)
                {
                    return Private___11_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___11_intnl_SystemObject != null)
                {
                    Private___11_intnl_SystemObject.Value = value;
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

        internal VRC.Udon.UdonBehaviour __22_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_intnl_SystemObject != null)
                {
                    return Private___22_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___22_intnl_SystemObject != null)
                {
                    Private___22_intnl_SystemObject.Value = value;
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

        internal float? __0_tagHeight_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_tagHeight_Single != null)
                {
                    return Private___0_tagHeight_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_tagHeight_Single != null)
                    {
                        Private___0_tagHeight_Single.Value = value.Value;
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

        internal int? __37_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___37_const_intnl_SystemInt32 != null)
                {
                    return Private___37_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___37_const_intnl_SystemInt32 != null)
                    {
                        Private___37_const_intnl_SystemInt32.Value = value.Value;
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

        internal int? __0_mp_hp_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_hp_Int32 != null)
                {
                    return Private___0_mp_hp_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_hp_Int32 != null)
                    {
                        Private___0_mp_hp_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __55_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___55_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___55_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___55_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___55_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal uint? __59_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___59_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___59_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___59_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___59_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal int? __26_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___26_const_intnl_SystemInt32 != null)
                {
                    return Private___26_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___26_const_intnl_SystemInt32 != null)
                    {
                        Private___26_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __3_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_UnityEngineGameObject != null)
                {
                    return Private___3_intnl_UnityEngineGameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_UnityEngineGameObject != null)
                {
                    Private___3_intnl_UnityEngineGameObject.Value = value;
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

        internal VRC.Udon.UdonBehaviour scorecard
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scorecard != null)
                {
                    return Private_scorecard.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_scorecard != null)
                {
                    Private_scorecard.Value = value;
                }
            }
        }

        internal int? cachedHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedHealth != null)
                {
                    return Private_cachedHealth.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedHealth != null)
                    {
                        Private_cachedHealth.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour __19_intnl_SystemObject
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
                if (Private___19_intnl_SystemObject != null)
                {
                    Private___19_intnl_SystemObject.Value = value;
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

        internal int? __27_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___27_const_intnl_SystemInt32 != null)
                {
                    return Private___27_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___27_const_intnl_SystemInt32 != null)
                    {
                        Private___27_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal UnityEngine.Camera spectateCamera
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_spectateCamera != null)
                {
                    return Private_spectateCamera.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_spectateCamera != null)
                {
                    Private_spectateCamera.Value = value;
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

        internal float? lastDamageTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lastDamageTime != null)
                {
                    return Private_lastDamageTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lastDamageTime != null)
                    {
                        Private_lastDamageTime.Value = value.Value;
                    }
                }
            }
        }

        internal bool? killedByLocal
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_killedByLocal != null)
                {
                    return Private_killedByLocal.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_killedByLocal != null)
                    {
                        Private_killedByLocal.Value = value.Value;
                    }
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

        internal int? __0_mp_damage_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_damage_Int32 != null)
                {
                    return Private___0_mp_damage_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_damage_Int32 != null)
                    {
                        Private___0_mp_damage_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isPlaying
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isPlaying != null)
                {
                    return Private_isPlaying.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isPlaying != null)
                    {
                        Private_isPlaying.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __3_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_UnityEngineVector3 != null)
                {
                    return Private___3_intnl_UnityEngineVector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_UnityEngineVector3 != null)
                    {
                        Private___3_intnl_UnityEngineVector3.Value = value.Value;
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

        internal int? __34_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_const_intnl_SystemInt32 != null)
                {
                    return Private___34_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_const_intnl_SystemInt32 != null)
                    {
                        Private___34_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __4_intnl_UnityEngineTransform
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

        internal VRC.Udon.UdonBehaviour __12_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___12_intnl_SystemObject != null)
                {
                    return Private___12_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___12_intnl_SystemObject != null)
                {
                    Private___12_intnl_SystemObject.Value = value;
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

        internal uint? __57_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___57_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___57_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___57_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___57_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal bool? cachedIsPlaying
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedIsPlaying != null)
                {
                    return Private_cachedIsPlaying.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedIsPlaying != null)
                    {
                        Private_cachedIsPlaying.Value = value.Value;
                    }
                }
            }
        }

        internal int? __24_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_const_intnl_SystemInt32 != null)
                {
                    return Private___24_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___24_const_intnl_SystemInt32 != null)
                    {
                        Private___24_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? cachedHasKeycard
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedHasKeycard != null)
                {
                    return Private_cachedHasKeycard.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedHasKeycard != null)
                    {
                        Private_cachedHasKeycard.Value = value.Value;
                    }
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

        internal int? __29_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_const_intnl_SystemInt32 != null)
                {
                    return Private___29_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___29_const_intnl_SystemInt32 != null)
                    {
                        Private___29_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal bool? __0_mp_enabled_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_enabled_Boolean != null)
                {
                    return Private___0_mp_enabled_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_enabled_Boolean != null)
                    {
                        Private___0_mp_enabled_Boolean.Value = value.Value;
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

        internal int? __32_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_const_intnl_SystemInt32 != null)
                {
                    return Private___32_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___32_const_intnl_SystemInt32 != null)
                    {
                        Private___32_const_intnl_SystemInt32.Value = value.Value;
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

        internal bool? __0_mp_dead_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_dead_Boolean != null)
                {
                    return Private___0_mp_dead_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_dead_Boolean != null)
                    {
                        Private___0_mp_dead_Boolean.Value = value.Value;
                    }
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

        internal int? __33_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_const_intnl_SystemInt32 != null)
                {
                    return Private___33_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___33_const_intnl_SystemInt32 != null)
                    {
                        Private___33_const_intnl_SystemInt32.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __30_intnl_SystemObject
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
                if (Private___30_intnl_SystemObject != null)
                {
                    Private___30_intnl_SystemObject.Value = value;
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

        internal int? __22_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_const_intnl_SystemInt32 != null)
                {
                    return Private___22_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___22_const_intnl_SystemInt32 != null)
                    {
                        Private___22_const_intnl_SystemInt32.Value = value.Value;
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

        internal int? healthRegenAmt
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_healthRegenAmt != null)
                {
                    return Private_healthRegenAmt.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_healthRegenAmt != null)
                    {
                        Private_healthRegenAmt.Value = value.Value;
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

        internal int? __15_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_const_intnl_SystemInt32 != null)
                {
                    return Private___15_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___15_const_intnl_SystemInt32 != null)
                    {
                        Private___15_const_intnl_SystemInt32.Value = value.Value;
                    }
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

        internal bool? __0_mp_t_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_t_Boolean != null)
                {
                    return Private___0_mp_t_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_t_Boolean != null)
                    {
                        Private___0_mp_t_Boolean.Value = value.Value;
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

        internal int? __1_mp_damage_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_damage_Int32 != null)
                {
                    return Private___1_mp_damage_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_damage_Int32 != null)
                    {
                        Private___1_mp_damage_Int32.Value = value.Value;
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

        internal int? __23_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_const_intnl_SystemInt32 != null)
                {
                    return Private___23_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___23_const_intnl_SystemInt32 != null)
                    {
                        Private___23_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? joinedRound
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_joinedRound != null)
                {
                    return Private_joinedRound.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_joinedRound != null)
                    {
                        Private_joinedRound.Value = value.Value;
                    }
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

        internal float? tagHeightMin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tagHeightMin != null)
                {
                    return Private_tagHeightMin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_tagHeightMin != null)
                    {
                        Private_tagHeightMin.Value = value.Value;
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

        internal bool? isDead
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isDead != null)
                {
                    return Private_isDead.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isDead != null)
                    {
                        Private_isDead.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour gameManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameManager != null)
                {
                    return Private_gameManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_gameManager != null)
                {
                    Private_gameManager.Value = value;
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

        internal bool? __0_mp_guard_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_guard_Boolean != null)
                {
                    return Private___0_mp_guard_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_guard_Boolean != null)
                    {
                        Private___0_mp_guard_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? deathLoc
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_deathLoc != null)
                {
                    return Private_deathLoc.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_deathLoc != null)
                    {
                        Private_deathLoc.Value = value.Value;
                    }
                }
            }
        }

        internal int? __30_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___30_const_intnl_SystemInt32 != null)
                {
                    return Private___30_const_intnl_SystemInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___30_const_intnl_SystemInt32 != null)
                    {
                        Private___30_const_intnl_SystemInt32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __54_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___54_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___54_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___54_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___54_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
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

        internal uint? __58_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___58_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___58_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___58_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___58_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __5_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_PlayerData != null)
                {
                    return Private___5_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_PlayerData != null)
                {
                    Private___5_intnl_PlayerData.Value = value;
                }
            }
        }

        internal string playerName
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerName != null)
                {
                    return Private_playerName.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerName != null)
                {
                    Private_playerName.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __3_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_PlayerObjectPool != null)
                {
                    return Private___3_intnl_PlayerObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_PlayerObjectPool != null)
                {
                    Private___3_intnl_PlayerObjectPool.Value = value;
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

        internal VRC.Udon.UdonBehaviour __1_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_PlayerObjectPool != null)
                {
                    return Private___1_intnl_PlayerObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_PlayerObjectPool != null)
                {
                    Private___1_intnl_PlayerObjectPool.Value = value;
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

        internal string __0_mp_newName_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_newName_String != null)
                {
                    return Private___0_mp_newName_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_newName_String != null)
                {
                    Private___0_mp_newName_String.Value = value;
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

        internal VRC.Udon.UdonBehaviour teamTag
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamTag != null)
                {
                    return Private_teamTag.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_teamTag != null)
                {
                    Private_teamTag.Value = value;
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

        internal uint? __53_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___53_const_intnl_exitJumpLoc_UInt32 != null)
                {
                    return Private___53_const_intnl_exitJumpLoc_UInt32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___53_const_intnl_exitJumpLoc_UInt32 != null)
                    {
                        Private___53_const_intnl_exitJumpLoc_UInt32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? hasKeycard
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hasKeycard != null)
                {
                    return Private_hasKeycard.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hasKeycard != null)
                    {
                        Private_hasKeycard.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __23_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_intnl_SystemObject != null)
                {
                    return Private___23_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___23_intnl_SystemObject != null)
                {
                    Private___23_intnl_SystemObject.Value = value;
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

        internal int? __28_intnl_SystemObject
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
                if (value.HasValue)
                {
                    if (Private___28_intnl_SystemObject != null)
                    {
                        Private___28_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __3_intnl_GameEffects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_GameEffects != null)
                {
                    return Private___3_intnl_GameEffects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_GameEffects != null)
                {
                    Private___3_intnl_GameEffects.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Slider __3_intnl_UnityEngineUISlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_UnityEngineUISlider != null)
                {
                    return Private___3_intnl_UnityEngineUISlider.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_UnityEngineUISlider != null)
                {
                    Private___3_intnl_UnityEngineUISlider.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Slider __32_intnl_SystemObject
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
                if (Private___32_intnl_SystemObject != null)
                {
                    Private___32_intnl_SystemObject.Value = value;
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __1_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___1_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___1_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal bool? __6_intnl_SystemObject
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
                if (value.HasValue)
                {
                    if (Private___6_intnl_SystemObject != null)
                    {
                        Private___6_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __4_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_UnityEngineGameObject != null)
                {
                    return Private___4_intnl_UnityEngineGameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_UnityEngineGameObject != null)
                {
                    Private___4_intnl_UnityEngineGameObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_ItemControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_ItemControl != null)
                {
                    return Private___0_intnl_ItemControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_ItemControl != null)
                {
                    Private___0_intnl_ItemControl.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_GameJoinTrigger
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_GameJoinTrigger != null)
                {
                    return Private___0_intnl_GameJoinTrigger.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_GameJoinTrigger != null)
                {
                    Private___0_intnl_GameJoinTrigger.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_intnl_GameEffects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_GameEffects != null)
                {
                    return Private___1_intnl_GameEffects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_GameEffects != null)
                {
                    Private___1_intnl_GameEffects.Value = value;
                }
            }
        }

        internal bool? __24_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___24_intnl_SystemObject != null)
                {
                    return Private___24_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___24_intnl_SystemObject != null)
                    {
                        Private___24_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __5_intnl_GameEffects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_GameEffects != null)
                {
                    return Private___5_intnl_GameEffects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_GameEffects != null)
                {
                    Private___5_intnl_GameEffects.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __13_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___13_intnl_SystemObject != null)
                {
                    return Private___13_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___13_intnl_SystemObject != null)
                {
                    Private___13_intnl_SystemObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_ScoreboardDisplay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_ScoreboardDisplay != null)
                {
                    return Private___0_intnl_ScoreboardDisplay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_ScoreboardDisplay != null)
                {
                    Private___0_intnl_ScoreboardDisplay.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __25_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___25_intnl_SystemObject != null)
                {
                    return Private___25_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___25_intnl_SystemObject != null)
                {
                    Private___25_intnl_SystemObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __17_intnl_SystemObject
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
                if (Private___17_intnl_SystemObject != null)
                {
                    Private___17_intnl_SystemObject.Value = value;
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

        internal VRC.Udon.UdonBehaviour __14_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___14_intnl_SystemObject != null)
                {
                    return Private___14_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___14_intnl_SystemObject != null)
                {
                    Private___14_intnl_SystemObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __7_intnl_SystemObject
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
                if (Private___7_intnl_SystemObject != null)
                {
                    Private___7_intnl_SystemObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_PatronControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_PatronControl != null)
                {
                    return Private___0_intnl_PatronControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_PatronControl != null)
                {
                    Private___0_intnl_PatronControl.Value = value;
                }
            }
        }

        internal bool? __8_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemObject != null)
                {
                    return Private___8_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___8_intnl_SystemObject != null)
                    {
                        Private___8_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __15_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___15_intnl_SystemObject != null)
                {
                    return Private___15_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___15_intnl_SystemObject != null)
                {
                    Private___15_intnl_SystemObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_intnl_PatronControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_PatronControl != null)
                {
                    return Private___1_intnl_PatronControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_PatronControl != null)
                {
                    Private___1_intnl_PatronControl.Value = value;
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi __4_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    return Private___4_intnl_VRCSDKBaseVRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4_intnl_VRCSDKBaseVRCPlayerApi != null)
                {
                    Private___4_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __16_intnl_SystemObject
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

        internal VRC.Udon.UdonBehaviour __5_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemObject != null)
                {
                    return Private___5_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_SystemObject != null)
                {
                    Private___5_intnl_SystemObject.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_GameEffects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_GameEffects != null)
                {
                    return Private___0_intnl_GameEffects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_GameEffects != null)
                {
                    Private___0_intnl_GameEffects.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_AFKDetector
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_AFKDetector != null)
                {
                    return Private___0_intnl_AFKDetector.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_AFKDetector != null)
                {
                    Private___0_intnl_AFKDetector.Value = value;
                }
            }
        }

 

        #endregion Getter / Setters UdonVariables  of PlayerData



        internal void Initialize_PlayerData()
        {
            Private___18_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__18_const_intnl_SystemInt32");
            Private_isWanted = new AstroUdonVariable<bool>(PlayerData, "isWanted");
            Private___43_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__43_const_intnl_exitJumpLoc_UInt32");
            Private___33_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__33_const_intnl_SystemString");
            Private___20_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__20_const_intnl_SystemInt32");
            Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__23_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__1_intnl_UnityEngineGameObject");
            Private___21_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__21_const_intnl_exitJumpLoc_UInt32");
            Private___52_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__52_intnl_SystemBoolean");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__3_const_intnl_SystemString");
            Private___6_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__6_const_intnl_SystemInt32");
            Private___0_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_intnl_PlayerData");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__3_const_intnl_exitJumpLoc_UInt32");
            Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__26_intnl_SystemBoolean");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__0_const_intnl_SystemBoolean");
            Private___41_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__41_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PlayerData, "__1_intnl_UnityEngineTransform");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__1_const_intnl_SystemInt32");
            Private___0_intnl_PlayerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_intnl_PlayerObjectPool");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__1_intnl_SystemInt32");
            Private___16_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__16_const_intnl_exitJumpLoc_UInt32");
            Private___2_intnl_SystemObject = new AstroUdonVariable<UnityEngine.Transform>(PlayerData, "__2_intnl_SystemObject");
            Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(PlayerData, "__0_const_intnl_VRCUdonCommonEnumsEventTiming");
            Private___35_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__35_const_intnl_exitJumpLoc_UInt32");
            Private___39_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__39_const_intnl_exitJumpLoc_UInt32");
            Private_doublePoints = new AstroUdonVariable<bool>(PlayerData, "doublePoints");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__0_const_intnl_SystemString");
            Private___56_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__56_const_intnl_exitJumpLoc_UInt32");
            Private___42_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__42_intnl_SystemBoolean");
            Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__0_const_intnl_SystemSingle");
            Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__29_intnl_SystemBoolean");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__1_intnl_SystemSingle");
            Private___7_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__7_const_intnl_SystemInt32");
            Private___9_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__9_intnl_SystemObject");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__5_intnl_SystemBoolean");
            Private_tagHeightScalar = new AstroUdonVariable<float>(PlayerData, "tagHeightScalar");
            Private___46_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__46_const_intnl_exitJumpLoc_UInt32");
            Private___35_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__35_const_intnl_SystemInt32");
            Private_hitbox = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "hitbox");
            Private___10_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__10_const_intnl_exitJumpLoc_UInt32");
            Private___11_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__11_const_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___2_intnl_PlayerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__2_intnl_PlayerObjectPool");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__15_intnl_SystemBoolean");
            Private___24_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__24_const_intnl_exitJumpLoc_UInt32");
            Private___34_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__34_intnl_SystemBoolean");
            Private___28_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__28_const_intnl_SystemString");
            Private___2_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PlayerData, "__2_intnl_UnityEngineTransform");
            Private___28_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__28_const_intnl_exitJumpLoc_UInt32");
            Private_maxHealth = new AstroUdonVariable<int>(PlayerData, "maxHealth");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__6_const_intnl_SystemString");
            Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__21_intnl_SystemBoolean");
            Private_cachedIsWanted = new AstroUdonVariable<bool>(PlayerData, "cachedIsWanted");
            Private___5_intnl_PlayerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__5_intnl_PlayerObjectPool");
            Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__5_const_intnl_exitJumpLoc_UInt32");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__13_intnl_SystemBoolean");
            Private___50_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__50_const_intnl_exitJumpLoc_UInt32");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__1_const_intnl_SystemString");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__4_const_intnl_SystemInt32");
            Private___64_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__64_intnl_SystemBoolean");
            Private___40_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__40_const_intnl_SystemString");
            Private___29_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__29_const_intnl_SystemString");
            Private___1_const_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__1_const_intnl_SystemSingle");
            Private___23_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__23_const_intnl_exitJumpLoc_UInt32");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__5_intnl_SystemSingle");
            Private___25_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__25_const_intnl_SystemInt32");
            Private___40_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__40_const_intnl_exitJumpLoc_UInt32");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__16_intnl_SystemBoolean");
            Private_goldGuns = new AstroUdonVariable<bool>(PlayerData, "goldGuns");
            Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__14_const_intnl_SystemString");
            Private___1_mp_hp_Int32 = new AstroUdonVariable<int>(PlayerData, "__1_mp_hp_Int32");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__7_intnl_SystemBoolean");
            Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__22_intnl_SystemBoolean");
            Private___38_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__38_const_intnl_SystemInt32");
            Private___20_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__20_intnl_SystemObject");
            Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__7_const_intnl_exitJumpLoc_UInt32");
            Private___37_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__37_const_intnl_exitJumpLoc_UInt32");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__7_const_intnl_SystemString");
            Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__15_const_intnl_SystemString");
            Private___4_intnl_PlayerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__4_intnl_PlayerObjectPool");
            Private___0_mp_playing_Boolean = new AstroUdonVariable<bool>(PlayerData, "__0_mp_playing_Boolean");
            Private___5_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__5_const_intnl_SystemInt32");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(PlayerData, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__4_intnl_SystemBoolean");
            Private___16_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__16_const_intnl_SystemInt32");
            Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__19_intnl_SystemBoolean");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(PlayerData, "__refl_const_intnl_udonTypeName");
            Private_health = new AstroUdonVariable<int>(PlayerData, "health");
            Private_healthRegenDelay = new AstroUdonVariable<float>(PlayerData, "healthRegenDelay");
            Private___0_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_intnl_SystemObject");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__1_intnl_SystemBoolean");
            Private___38_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__38_intnl_SystemBoolean");
            Private___12_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__12_const_intnl_exitJumpLoc_UInt32");
            Private___34_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__34_const_intnl_SystemString");
            Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__17_const_intnl_SystemString");
            Private___28_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__28_const_intnl_SystemInt32");
            Private___17_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__17_const_intnl_SystemInt32");
            Private___26_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__26_const_intnl_exitJumpLoc_UInt32");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__4_const_intnl_SystemString");
            Private___31_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__31_const_intnl_exitJumpLoc_UInt32");
            Private___68_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__68_intnl_SystemBoolean");
            Private___20_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__20_const_intnl_SystemString");
            Private___35_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__35_const_intnl_SystemString");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__11_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__2_intnl_SystemInt32");
            Private___8_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__8_const_intnl_SystemInt32");
            Private___52_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__52_const_intnl_exitJumpLoc_UInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__4_const_intnl_exitJumpLoc_UInt32");
            Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__30_intnl_SystemBoolean");
            Private___0_mp_wanted_Boolean = new AstroUdonVariable<bool>(PlayerData, "__0_mp_wanted_Boolean");
            Private___54_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__54_intnl_SystemBoolean");
            Private___21_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__21_const_intnl_SystemString");
            Private___26_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__26_const_intnl_SystemString");
            Private___42_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__42_const_intnl_exitJumpLoc_UInt32");
            Private___71_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__71_intnl_SystemBoolean");
            Private___31_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__31_const_intnl_SystemInt32");
            Private___4_intnl_SystemObject = new AstroUdonVariable<UnityEngine.Transform>(PlayerData, "__4_intnl_SystemObject");
            Private___9_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__9_const_intnl_exitJumpLoc_UInt32");
            Private___60_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__60_intnl_SystemBoolean");
            Private___37_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__37_intnl_SystemBoolean");
            Private___20_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__20_const_intnl_exitJumpLoc_UInt32");
            Private___37_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__37_const_intnl_SystemString");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__2_intnl_SystemSingle");
            Private___0_this_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_this_intnl_PlayerData");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__3_intnl_SystemBoolean");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__12_intnl_SystemBoolean");
            Private___10_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__10_intnl_SystemObject");
            Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__6_const_intnl_exitJumpLoc_UInt32");
            Private___2_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__2_intnl_PlayerData");
            Private___67_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__67_intnl_SystemBoolean");
            Private___23_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__23_const_intnl_SystemString");
            Private___5_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__5_intnl_UnityEngineVector3");
            Private___14_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__14_const_intnl_SystemInt32");
            Private___9_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__9_const_intnl_SystemInt32");
            Private___44_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__44_intnl_SystemBoolean");
            Private___29_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__29_intnl_SystemObject");
            Private___72_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__72_intnl_SystemBoolean");
            Private___19_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__19_const_intnl_SystemInt32");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__0_intnl_SystemBoolean");
            Private___34_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__34_const_intnl_exitJumpLoc_UInt32");
            Private___4_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__4_intnl_UnityEngineVector3");
            Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__9_intnl_SystemSingle");
            Private___21_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__21_const_intnl_SystemInt32");
            Private_cachedIsDead = new AstroUdonVariable<bool>(PlayerData, "cachedIsDead");
            Private_isGuard = new AstroUdonVariable<bool>(PlayerData, "isGuard");
            Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__12_const_intnl_SystemString");
            Private___38_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__38_const_intnl_exitJumpLoc_UInt32");
            Private___1_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__1_intnl_PlayerData");
            Private___0_this_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__0_this_intnl_UnityEngineGameObject");
            Private___3_intnl_SystemObject = new AstroUdonVariable<float>(PlayerData, "__3_intnl_SystemObject");
            Private___0_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__0_intnl_UnityEngineGameObject");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__8_const_intnl_SystemString");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__6_intnl_SystemSingle");
            Private___33_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__33_const_intnl_exitJumpLoc_UInt32");
            Private___58_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__58_intnl_SystemBoolean");
            Private___15_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__15_const_intnl_exitJumpLoc_UInt32");
            Private___36_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__36_const_intnl_SystemInt32");
            Private_cachedPlayerName = new AstroUdonVariable<string>(PlayerData, "cachedPlayerName");
            Private___11_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__11_intnl_SystemObject");
            Private___19_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__19_const_intnl_exitJumpLoc_UInt32");
            Private___12_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__12_const_intnl_SystemInt32");
            Private___22_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__22_intnl_SystemObject");
            Private___32_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__32_const_intnl_SystemString");
            Private___0_tagHeight_Single = new AstroUdonVariable<float>(PlayerData, "__0_tagHeight_Single");
            Private___35_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__35_intnl_SystemBoolean");
            Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__8_const_intnl_exitJumpLoc_UInt32");
            Private___37_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__37_const_intnl_SystemInt32");
            Private___50_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__50_intnl_SystemBoolean");
            Private___0_mp_hp_Int32 = new AstroUdonVariable<int>(PlayerData, "__0_mp_hp_Int32");
            Private___55_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__55_const_intnl_exitJumpLoc_UInt32");
            Private___22_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__22_const_intnl_exitJumpLoc_UInt32");
            Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__24_intnl_SystemBoolean");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__9_const_intnl_SystemString");
            Private___13_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__13_const_intnl_SystemInt32");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__0_intnl_returnTarget_UInt32");
            Private___48_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__48_intnl_SystemBoolean");
            Private___59_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__59_const_intnl_exitJumpLoc_UInt32");
            Private___45_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__45_const_intnl_exitJumpLoc_UInt32");
            Private___65_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__65_intnl_SystemBoolean");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__0_intnl_SystemString");
            Private___33_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__33_intnl_SystemBoolean");
            Private___57_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__57_intnl_SystemBoolean");
            Private___26_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__26_const_intnl_SystemInt32");
            Private___3_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__3_intnl_UnityEngineGameObject");
            Private___49_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__49_const_intnl_exitJumpLoc_UInt32");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(PlayerData, "__0_const_intnl_SystemUInt32");
            Private_scorecard = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "scorecard");
            Private_cachedHealth = new AstroUdonVariable<int>(PlayerData, "cachedHealth");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__9_intnl_SystemBoolean");
            Private___19_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__19_intnl_SystemObject");
            Private___36_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__36_const_intnl_exitJumpLoc_UInt32");
            Private___63_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__63_intnl_SystemBoolean");
            Private___36_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__36_intnl_SystemBoolean");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__0_intnl_SystemSingle");
            Private___27_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__27_const_intnl_SystemInt32");
            Private___40_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__40_intnl_SystemBoolean");
            Private_spectateCamera = new AstroUdonVariable<UnityEngine.Camera>(PlayerData, "spectateCamera");
            Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__18_const_intnl_SystemString");
            Private_lastDamageTime = new AstroUdonVariable<float>(PlayerData, "lastDamageTime");
            Private_killedByLocal = new AstroUdonVariable<bool>(PlayerData, "killedByLocal");
            Private___66_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__66_intnl_SystemBoolean");
            Private___0_mp_damage_Int32 = new AstroUdonVariable<int>(PlayerData, "__0_mp_damage_Int32");
            Private_isPlaying = new AstroUdonVariable<bool>(PlayerData, "isPlaying");
            Private___3_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__3_intnl_UnityEngineVector3");
            Private___47_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__47_intnl_SystemBoolean");
            Private___34_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__34_const_intnl_SystemInt32");
            Private___4_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PlayerData, "__4_intnl_UnityEngineTransform");
            Private___10_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__10_const_intnl_SystemInt32");
            Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__19_const_intnl_SystemString");
            Private___17_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__17_const_intnl_exitJumpLoc_UInt32");
            Private___30_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__30_const_intnl_exitJumpLoc_UInt32");
            Private___39_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__39_intnl_SystemBoolean");
            Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__28_intnl_SystemBoolean");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__6_intnl_SystemBoolean");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__4_intnl_SystemSingle");
            Private___12_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__12_intnl_SystemObject");
            Private___24_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__24_const_intnl_SystemString");
            Private___69_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__69_intnl_SystemBoolean");
            Private___57_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__57_const_intnl_exitJumpLoc_UInt32");
            Private___38_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__38_const_intnl_SystemString");
            Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__14_intnl_SystemBoolean");
            Private_cachedIsPlaying = new AstroUdonVariable<bool>(PlayerData, "cachedIsPlaying");
            Private___24_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__24_const_intnl_SystemInt32");
            Private_cachedHasKeycard = new AstroUdonVariable<bool>(PlayerData, "cachedHasKeycard");
            Private___47_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__47_const_intnl_exitJumpLoc_UInt32");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__3_intnl_SystemInt32");
            Private___31_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__31_intnl_SystemBoolean");
            Private___55_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__55_intnl_SystemBoolean");
            Private___25_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__25_const_intnl_SystemString");
            Private___29_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__29_const_intnl_SystemInt32");
            Private___11_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__11_const_intnl_exitJumpLoc_UInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__8_intnl_SystemBoolean");
            Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__20_intnl_SystemBoolean");
            Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__2_intnl_UnityEngineVector3");
            Private___39_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__39_const_intnl_SystemString");
            Private___1_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__1_intnl_SystemObject");
            Private___0_mp_enabled_Boolean = new AstroUdonVariable<bool>(PlayerData, "__0_mp_enabled_Boolean");
            Private___25_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__25_const_intnl_exitJumpLoc_UInt32");
            Private___32_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__32_const_intnl_SystemInt32");
            Private___61_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__61_intnl_SystemBoolean");
            Private___29_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__29_const_intnl_exitJumpLoc_UInt32");
            Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__1_intnl_UnityEngineVector3");
            Private___53_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__53_intnl_SystemBoolean");
            Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__27_intnl_SystemBoolean");
            Private___0_mp_dead_Boolean = new AstroUdonVariable<bool>(PlayerData, "__0_mp_dead_Boolean");
            Private___51_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__51_const_intnl_exitJumpLoc_UInt32");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__3_intnl_SystemSingle");
            Private___33_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__33_const_intnl_SystemInt32");
            Private___27_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__27_const_intnl_SystemString");
            Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__0_intnl_UnityEngineVector3");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__10_const_intnl_SystemString");
            Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__32_intnl_SystemBoolean");
            Private___30_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__30_intnl_SystemObject");
            Private___56_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__56_intnl_SystemBoolean");
            Private___41_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__41_const_intnl_exitJumpLoc_UInt32");
            Private___45_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__45_intnl_SystemBoolean");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__1_const_intnl_SystemBoolean");
            Private___22_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__22_const_intnl_SystemInt32");
            Private___3_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__3_intnl_PlayerData");
            Private___62_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__62_intnl_SystemBoolean");
            Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__11_const_intnl_SystemString");
            Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__16_const_intnl_SystemString");
            Private_healthRegenAmt = new AstroUdonVariable<int>(PlayerData, "healthRegenAmt");
            Private___32_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__32_const_intnl_exitJumpLoc_UInt32");
            Private___43_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__43_intnl_SystemBoolean");
            Private___15_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__15_const_intnl_SystemInt32");
            Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__18_intnl_SystemBoolean");
            Private___0_mp_t_Boolean = new AstroUdonVariable<bool>(PlayerData, "__0_mp_t_Boolean");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__2_intnl_SystemBoolean");
            Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__10_intnl_SystemSingle");
            Private___1_mp_damage_Int32 = new AstroUdonVariable<int>(PlayerData, "__1_mp_damage_Int32");
            Private___14_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__14_const_intnl_exitJumpLoc_UInt32");
            Private___23_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__23_const_intnl_SystemInt32");
            Private_joinedRound = new AstroUdonVariable<bool>(PlayerData, "joinedRound");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__3_const_intnl_SystemInt32");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__7_intnl_SystemSingle");
            Private_tagHeightMin = new AstroUdonVariable<float>(PlayerData, "tagHeightMin");
            Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(PlayerData, "__0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget");
            Private___59_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__59_intnl_SystemBoolean");
            Private_isDead = new AstroUdonVariable<bool>(PlayerData, "isDead");
            Private___18_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__18_const_intnl_exitJumpLoc_UInt32");
            Private___46_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__46_intnl_SystemBoolean");
            Private___30_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__30_const_intnl_SystemString");
            Private_gameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "gameManager");
            Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__13_const_intnl_SystemString");
            Private___0_mp_guard_Boolean = new AstroUdonVariable<bool>(PlayerData, "__0_mp_guard_Boolean");
            Private_deathLoc = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "deathLoc");
            Private___30_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__30_const_intnl_SystemInt32");
            Private___54_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__54_const_intnl_exitJumpLoc_UInt32");
            Private___13_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__13_const_intnl_exitJumpLoc_UInt32");
            Private___2_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__2_intnl_UnityEngineGameObject");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__10_intnl_SystemBoolean");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__2_const_intnl_SystemString");
            Private___31_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__31_const_intnl_SystemString");
            Private___27_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__27_const_intnl_exitJumpLoc_UInt32");
            Private___36_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__36_const_intnl_SystemString");
            Private___58_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__58_const_intnl_exitJumpLoc_UInt32");
            Private___44_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__44_const_intnl_exitJumpLoc_UInt32");
            Private___5_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__5_intnl_PlayerData");
            Private_playerName = new AstroUdonVariable<string>(PlayerData, "playerName");
            Private___3_intnl_PlayerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__3_intnl_PlayerObjectPool");
            Private___51_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__51_intnl_SystemBoolean");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PlayerData, "__0_const_intnl_SystemInt32");
            Private___1_intnl_PlayerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__1_intnl_PlayerObjectPool");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__25_intnl_SystemBoolean");
            Private___48_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__48_const_intnl_exitJumpLoc_UInt32");
            Private___22_const_intnl_SystemString = new AstroUdonVariable<string>(PlayerData, "__22_const_intnl_SystemString");
            Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(PlayerData, "__8_intnl_SystemSingle");
            Private___0_mp_newName_String = new AstroUdonVariable<string>(PlayerData, "__0_mp_newName_String");
            Private___70_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__70_intnl_SystemBoolean");
            Private_teamTag = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "teamTag");
            Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__17_intnl_SystemBoolean");
            Private___49_intnl_SystemBoolean = new AstroUdonVariable<bool>(PlayerData, "__49_intnl_SystemBoolean");
            Private___53_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PlayerData, "__53_const_intnl_exitJumpLoc_UInt32");
            Private_hasKeycard = new AstroUdonVariable<bool>(PlayerData, "hasKeycard");
            Private___23_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__23_intnl_SystemObject");
            Private___4_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__4_intnl_PlayerData");
            Private___28_intnl_SystemObject = new AstroUdonVariable<int>(PlayerData, "__28_intnl_SystemObject");
            Private___3_intnl_GameEffects = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__3_intnl_GameEffects");
            Private___3_intnl_UnityEngineUISlider = new AstroUdonVariable<UnityEngine.UI.Slider>(PlayerData, "__3_intnl_UnityEngineUISlider");
            Private___32_intnl_SystemObject = new AstroUdonVariable<UnityEngine.UI.Slider>(PlayerData, "__32_intnl_SystemObject");
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PlayerData, "__1_intnl_VRCSDKBaseVRCPlayerApi");
            Private___6_intnl_SystemObject = new AstroUdonVariable<bool>(PlayerData, "__6_intnl_SystemObject");
            Private___4_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__4_intnl_UnityEngineGameObject");
            Private___0_intnl_ItemControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_intnl_ItemControl");
            Private___0_intnl_GameJoinTrigger = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_intnl_GameJoinTrigger");
            Private___1_intnl_GameEffects = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__1_intnl_GameEffects");
            Private___24_intnl_SystemObject = new AstroUdonVariable<bool>(PlayerData, "__24_intnl_SystemObject");
            Private___5_intnl_GameEffects = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__5_intnl_GameEffects");
            Private___13_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__13_intnl_SystemObject");
            Private___0_intnl_ScoreboardDisplay = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_intnl_ScoreboardDisplay");
            Private___25_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__25_intnl_SystemObject");
            Private___17_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__17_intnl_SystemObject");
            Private___18_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__18_intnl_SystemObject");
            Private___14_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__14_intnl_SystemObject");
            Private___7_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__7_intnl_SystemObject");
            Private___0_intnl_PatronControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_intnl_PatronControl");
            Private___8_intnl_SystemObject = new AstroUdonVariable<bool>(PlayerData, "__8_intnl_SystemObject");
            Private___15_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__15_intnl_SystemObject");
            Private___1_intnl_PatronControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__1_intnl_PatronControl");
            Private___4_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PlayerData, "__4_intnl_VRCSDKBaseVRCPlayerApi");
            Private___16_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__16_intnl_SystemObject");
            Private___5_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__5_intnl_SystemObject");
            Private___0_intnl_GameEffects = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_intnl_GameEffects");
            Private___0_intnl_AFKDetector = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__0_intnl_AFKDetector");
        }

        internal void Cleanup_PlayerData()
        {
            Private___18_const_intnl_SystemInt32 = null;
            Private_isWanted = null;
            Private___43_const_intnl_exitJumpLoc_UInt32 = null;
            Private___33_const_intnl_SystemString = null;
            Private___20_const_intnl_SystemInt32 = null;
            Private___23_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineGameObject = null;
            Private___21_const_intnl_exitJumpLoc_UInt32 = null;
            Private___52_intnl_SystemBoolean = null;
            Private___3_const_intnl_SystemString = null;
            Private___6_const_intnl_SystemInt32 = null;
            Private___0_intnl_PlayerData = null;
            Private___3_const_intnl_exitJumpLoc_UInt32 = null;
            Private___26_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___41_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineTransform = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___0_intnl_PlayerObjectPool = null;
            Private___1_intnl_SystemInt32 = null;
            Private___16_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_intnl_SystemObject = null;
            Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = null;
            Private___35_const_intnl_exitJumpLoc_UInt32 = null;
            Private___39_const_intnl_exitJumpLoc_UInt32 = null;
            Private_doublePoints = null;
            Private___0_const_intnl_SystemString = null;
            Private___56_const_intnl_exitJumpLoc_UInt32 = null;
            Private___42_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemSingle = null;
            Private___29_intnl_SystemBoolean = null;
            Private___1_intnl_SystemSingle = null;
            Private___7_const_intnl_SystemInt32 = null;
            Private___9_intnl_SystemObject = null;
            Private___5_intnl_SystemBoolean = null;
            Private_tagHeightScalar = null;
            Private___46_const_intnl_exitJumpLoc_UInt32 = null;
            Private___35_const_intnl_SystemInt32 = null;
            Private_hitbox = null;
            Private___10_const_intnl_exitJumpLoc_UInt32 = null;
            Private___11_const_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_intnl_PlayerObjectPool = null;
            Private___15_intnl_SystemBoolean = null;
            Private___24_const_intnl_exitJumpLoc_UInt32 = null;
            Private___34_intnl_SystemBoolean = null;
            Private___28_const_intnl_SystemString = null;
            Private___2_intnl_UnityEngineTransform = null;
            Private___28_const_intnl_exitJumpLoc_UInt32 = null;
            Private_maxHealth = null;
            Private___6_const_intnl_SystemString = null;
            Private___21_intnl_SystemBoolean = null;
            Private_cachedIsWanted = null;
            Private___5_intnl_PlayerObjectPool = null;
            Private___5_const_intnl_exitJumpLoc_UInt32 = null;
            Private___13_intnl_SystemBoolean = null;
            Private___50_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemInt32 = null;
            Private___64_intnl_SystemBoolean = null;
            Private___40_const_intnl_SystemString = null;
            Private___29_const_intnl_SystemString = null;
            Private___1_const_intnl_SystemSingle = null;
            Private___23_const_intnl_exitJumpLoc_UInt32 = null;
            Private___5_intnl_SystemSingle = null;
            Private___25_const_intnl_SystemInt32 = null;
            Private___40_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private___16_intnl_SystemBoolean = null;
            Private_goldGuns = null;
            Private___14_const_intnl_SystemString = null;
            Private___1_mp_hp_Int32 = null;
            Private___7_intnl_SystemBoolean = null;
            Private___22_intnl_SystemBoolean = null;
            Private___38_const_intnl_SystemInt32 = null;
            Private___20_intnl_SystemObject = null;
            Private___7_const_intnl_exitJumpLoc_UInt32 = null;
            Private___37_const_intnl_exitJumpLoc_UInt32 = null;
            Private___7_const_intnl_SystemString = null;
            Private___15_const_intnl_SystemString = null;
            Private___4_intnl_PlayerObjectPool = null;
            Private___0_mp_playing_Boolean = null;
            Private___5_const_intnl_SystemInt32 = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private___16_const_intnl_SystemInt32 = null;
            Private___19_intnl_SystemBoolean = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private_health = null;
            Private_healthRegenDelay = null;
            Private___0_intnl_SystemObject = null;
            Private___1_intnl_SystemBoolean = null;
            Private___38_intnl_SystemBoolean = null;
            Private___12_const_intnl_exitJumpLoc_UInt32 = null;
            Private___34_const_intnl_SystemString = null;
            Private___17_const_intnl_SystemString = null;
            Private___28_const_intnl_SystemInt32 = null;
            Private___17_const_intnl_SystemInt32 = null;
            Private___26_const_intnl_exitJumpLoc_UInt32 = null;
            Private___4_const_intnl_SystemString = null;
            Private___31_const_intnl_exitJumpLoc_UInt32 = null;
            Private___68_intnl_SystemBoolean = null;
            Private___20_const_intnl_SystemString = null;
            Private___35_const_intnl_SystemString = null;
            Private___11_intnl_SystemBoolean = null;
            Private___2_intnl_SystemInt32 = null;
            Private___8_const_intnl_SystemInt32 = null;
            Private___52_const_intnl_exitJumpLoc_UInt32 = null;
            Private___4_const_intnl_exitJumpLoc_UInt32 = null;
            Private___30_intnl_SystemBoolean = null;
            Private___0_mp_wanted_Boolean = null;
            Private___54_intnl_SystemBoolean = null;
            Private___21_const_intnl_SystemString = null;
            Private___26_const_intnl_SystemString = null;
            Private___42_const_intnl_exitJumpLoc_UInt32 = null;
            Private___71_intnl_SystemBoolean = null;
            Private___31_const_intnl_SystemInt32 = null;
            Private___4_intnl_SystemObject = null;
            Private___9_const_intnl_exitJumpLoc_UInt32 = null;
            Private___60_intnl_SystemBoolean = null;
            Private___37_intnl_SystemBoolean = null;
            Private___20_const_intnl_exitJumpLoc_UInt32 = null;
            Private___37_const_intnl_SystemString = null;
            Private___2_intnl_SystemSingle = null;
            Private___0_this_intnl_PlayerData = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___12_intnl_SystemBoolean = null;
            Private___10_intnl_SystemObject = null;
            Private___6_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_intnl_PlayerData = null;
            Private___67_intnl_SystemBoolean = null;
            Private___23_const_intnl_SystemString = null;
            Private___5_intnl_UnityEngineVector3 = null;
            Private___14_const_intnl_SystemInt32 = null;
            Private___9_const_intnl_SystemInt32 = null;
            Private___44_intnl_SystemBoolean = null;
            Private___29_intnl_SystemObject = null;
            Private___72_intnl_SystemBoolean = null;
            Private___19_const_intnl_SystemInt32 = null;
            Private___0_intnl_SystemBoolean = null;
            Private___34_const_intnl_exitJumpLoc_UInt32 = null;
            Private___4_intnl_UnityEngineVector3 = null;
            Private___9_intnl_SystemSingle = null;
            Private___21_const_intnl_SystemInt32 = null;
            Private_cachedIsDead = null;
            Private_isGuard = null;
            Private___12_const_intnl_SystemString = null;
            Private___38_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_intnl_PlayerData = null;
            Private___0_this_intnl_UnityEngineGameObject = null;
            Private___3_intnl_SystemObject = null;
            Private___0_intnl_UnityEngineGameObject = null;
            Private___8_const_intnl_SystemString = null;
            Private___6_intnl_SystemSingle = null;
            Private___33_const_intnl_exitJumpLoc_UInt32 = null;
            Private___58_intnl_SystemBoolean = null;
            Private___15_const_intnl_exitJumpLoc_UInt32 = null;
            Private___36_const_intnl_SystemInt32 = null;
            Private_cachedPlayerName = null;
            Private___11_intnl_SystemObject = null;
            Private___19_const_intnl_exitJumpLoc_UInt32 = null;
            Private___12_const_intnl_SystemInt32 = null;
            Private___22_intnl_SystemObject = null;
            Private___32_const_intnl_SystemString = null;
            Private___0_tagHeight_Single = null;
            Private___35_intnl_SystemBoolean = null;
            Private___8_const_intnl_exitJumpLoc_UInt32 = null;
            Private___37_const_intnl_SystemInt32 = null;
            Private___50_intnl_SystemBoolean = null;
            Private___0_mp_hp_Int32 = null;
            Private___55_const_intnl_exitJumpLoc_UInt32 = null;
            Private___22_const_intnl_exitJumpLoc_UInt32 = null;
            Private___24_intnl_SystemBoolean = null;
            Private___9_const_intnl_SystemString = null;
            Private___13_const_intnl_SystemInt32 = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___48_intnl_SystemBoolean = null;
            Private___59_const_intnl_exitJumpLoc_UInt32 = null;
            Private___45_const_intnl_exitJumpLoc_UInt32 = null;
            Private___65_intnl_SystemBoolean = null;
            Private___0_intnl_SystemString = null;
            Private___33_intnl_SystemBoolean = null;
            Private___57_intnl_SystemBoolean = null;
            Private___26_const_intnl_SystemInt32 = null;
            Private___3_intnl_UnityEngineGameObject = null;
            Private___49_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private_scorecard = null;
            Private_cachedHealth = null;
            Private___9_intnl_SystemBoolean = null;
            Private___19_intnl_SystemObject = null;
            Private___36_const_intnl_exitJumpLoc_UInt32 = null;
            Private___63_intnl_SystemBoolean = null;
            Private___36_intnl_SystemBoolean = null;
            Private___0_intnl_SystemSingle = null;
            Private___27_const_intnl_SystemInt32 = null;
            Private___40_intnl_SystemBoolean = null;
            Private_spectateCamera = null;
            Private___18_const_intnl_SystemString = null;
            Private_lastDamageTime = null;
            Private_killedByLocal = null;
            Private___66_intnl_SystemBoolean = null;
            Private___0_mp_damage_Int32 = null;
            Private_isPlaying = null;
            Private___3_intnl_UnityEngineVector3 = null;
            Private___47_intnl_SystemBoolean = null;
            Private___34_const_intnl_SystemInt32 = null;
            Private___4_intnl_UnityEngineTransform = null;
            Private___10_const_intnl_SystemInt32 = null;
            Private___19_const_intnl_SystemString = null;
            Private___17_const_intnl_exitJumpLoc_UInt32 = null;
            Private___30_const_intnl_exitJumpLoc_UInt32 = null;
            Private___39_intnl_SystemBoolean = null;
            Private___28_intnl_SystemBoolean = null;
            Private___6_intnl_SystemBoolean = null;
            Private___4_intnl_SystemSingle = null;
            Private___12_intnl_SystemObject = null;
            Private___24_const_intnl_SystemString = null;
            Private___69_intnl_SystemBoolean = null;
            Private___57_const_intnl_exitJumpLoc_UInt32 = null;
            Private___38_const_intnl_SystemString = null;
            Private___14_intnl_SystemBoolean = null;
            Private_cachedIsPlaying = null;
            Private___24_const_intnl_SystemInt32 = null;
            Private_cachedHasKeycard = null;
            Private___47_const_intnl_exitJumpLoc_UInt32 = null;
            Private___3_intnl_SystemInt32 = null;
            Private___31_intnl_SystemBoolean = null;
            Private___55_intnl_SystemBoolean = null;
            Private___25_const_intnl_SystemString = null;
            Private___29_const_intnl_SystemInt32 = null;
            Private___11_const_intnl_exitJumpLoc_UInt32 = null;
            Private___8_intnl_SystemBoolean = null;
            Private___20_intnl_SystemBoolean = null;
            Private___2_intnl_UnityEngineVector3 = null;
            Private___39_const_intnl_SystemString = null;
            Private___1_intnl_SystemObject = null;
            Private___0_mp_enabled_Boolean = null;
            Private___25_const_intnl_exitJumpLoc_UInt32 = null;
            Private___32_const_intnl_SystemInt32 = null;
            Private___61_intnl_SystemBoolean = null;
            Private___29_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_intnl_UnityEngineVector3 = null;
            Private___53_intnl_SystemBoolean = null;
            Private___27_intnl_SystemBoolean = null;
            Private___0_mp_dead_Boolean = null;
            Private___51_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___3_intnl_SystemSingle = null;
            Private___33_const_intnl_SystemInt32 = null;
            Private___27_const_intnl_SystemString = null;
            Private___0_intnl_UnityEngineVector3 = null;
            Private___10_const_intnl_SystemString = null;
            Private___32_intnl_SystemBoolean = null;
            Private___30_intnl_SystemObject = null;
            Private___56_intnl_SystemBoolean = null;
            Private___41_const_intnl_exitJumpLoc_UInt32 = null;
            Private___45_intnl_SystemBoolean = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private___22_const_intnl_SystemInt32 = null;
            Private___3_intnl_PlayerData = null;
            Private___62_intnl_SystemBoolean = null;
            Private___11_const_intnl_SystemString = null;
            Private___16_const_intnl_SystemString = null;
            Private_healthRegenAmt = null;
            Private___32_const_intnl_exitJumpLoc_UInt32 = null;
            Private___43_intnl_SystemBoolean = null;
            Private___15_const_intnl_SystemInt32 = null;
            Private___18_intnl_SystemBoolean = null;
            Private___0_mp_t_Boolean = null;
            Private___2_intnl_SystemBoolean = null;
            Private___10_intnl_SystemSingle = null;
            Private___1_mp_damage_Int32 = null;
            Private___14_const_intnl_exitJumpLoc_UInt32 = null;
            Private___23_const_intnl_SystemInt32 = null;
            Private_joinedRound = null;
            Private___3_const_intnl_SystemInt32 = null;
            Private___7_intnl_SystemSingle = null;
            Private_tagHeightMin = null;
            Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget = null;
            Private___59_intnl_SystemBoolean = null;
            Private_isDead = null;
            Private___18_const_intnl_exitJumpLoc_UInt32 = null;
            Private___46_intnl_SystemBoolean = null;
            Private___30_const_intnl_SystemString = null;
            Private_gameManager = null;
            Private___13_const_intnl_SystemString = null;
            Private___0_mp_guard_Boolean = null;
            Private_deathLoc = null;
            Private___30_const_intnl_SystemInt32 = null;
            Private___54_const_intnl_exitJumpLoc_UInt32 = null;
            Private___13_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_intnl_UnityEngineGameObject = null;
            Private___10_intnl_SystemBoolean = null;
            Private___2_const_intnl_SystemString = null;
            Private___31_const_intnl_SystemString = null;
            Private___27_const_intnl_exitJumpLoc_UInt32 = null;
            Private___36_const_intnl_SystemString = null;
            Private___58_const_intnl_exitJumpLoc_UInt32 = null;
            Private___44_const_intnl_exitJumpLoc_UInt32 = null;
            Private___5_intnl_PlayerData = null;
            Private_playerName = null;
            Private___3_intnl_PlayerObjectPool = null;
            Private___51_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___1_intnl_PlayerObjectPool = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
            Private___25_intnl_SystemBoolean = null;
            Private___48_const_intnl_exitJumpLoc_UInt32 = null;
            Private___22_const_intnl_SystemString = null;
            Private___8_intnl_SystemSingle = null;
            Private___0_mp_newName_String = null;
            Private___70_intnl_SystemBoolean = null;
            Private_teamTag = null;
            Private___17_intnl_SystemBoolean = null;
            Private___49_intnl_SystemBoolean = null;
            Private___53_const_intnl_exitJumpLoc_UInt32 = null;
            Private_hasKeycard = null;
            Private___23_intnl_SystemObject = null;
            Private___4_intnl_PlayerData = null;
            Private___28_intnl_SystemObject = null;
            Private___3_intnl_GameEffects = null;
            Private___3_intnl_UnityEngineUISlider = null;
            Private___32_intnl_SystemObject = null;
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___6_intnl_SystemObject = null;
            Private___4_intnl_UnityEngineGameObject = null;
            Private___0_intnl_ItemControl = null;
            Private___0_intnl_GameJoinTrigger = null;
            Private___1_intnl_GameEffects = null;
            Private___24_intnl_SystemObject = null;
            Private___5_intnl_GameEffects = null;
            Private___13_intnl_SystemObject = null;
            Private___0_intnl_ScoreboardDisplay = null;
            Private___25_intnl_SystemObject = null;
            Private___17_intnl_SystemObject = null;
            Private___18_intnl_SystemObject = null;
            Private___14_intnl_SystemObject = null;
            Private___7_intnl_SystemObject = null;
            Private___0_intnl_PatronControl = null;
            Private___8_intnl_SystemObject = null;
            Private___15_intnl_SystemObject = null;
            Private___1_intnl_PatronControl = null;
            Private___4_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___16_intnl_SystemObject = null;
            Private___5_intnl_SystemObject = null;
            Private___0_intnl_GameEffects = null;
            Private___0_intnl_AFKDetector = null;
        }

        #region UdonVariables  of PlayerData

        private AstroUdonVariable<int> Private___18_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isWanted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___43_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___33_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___20_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___1_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___21_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___52_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___26_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___41_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___1_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_PlayerObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___16_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___2_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___0_const_intnl_VRCUdonCommonEnumsEventTiming { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___35_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___39_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_doublePoints { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___56_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___42_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___29_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___9_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_tagHeightScalar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___46_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___35_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_hitbox { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___10_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___11_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_PlayerObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___24_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___34_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___28_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___2_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___28_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_maxHealth { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedIsWanted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___5_intnl_PlayerObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___50_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___64_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___40_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___29_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___23_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___25_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___40_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_goldGuns { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_hp_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___38_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___20_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___37_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___4_intnl_PlayerObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_playing_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___16_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_health { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_healthRegenDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___38_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___12_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___34_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___28_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___17_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___26_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___31_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___68_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___20_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___35_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___52_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___30_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_wanted_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___54_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___21_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___26_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___42_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___71_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___31_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___4_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___9_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___60_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___37_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___20_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___37_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___10_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___67_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___23_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___5_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___14_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___44_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___29_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___72_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___19_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___34_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___4_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___21_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedIsDead { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isGuard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___38_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_this_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___33_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___58_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___15_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___36_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_cachedPlayerName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___11_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___19_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___12_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___22_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___32_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_tagHeight_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___35_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___37_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___50_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_hp_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___55_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___22_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___24_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___13_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___48_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___59_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___45_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___65_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___33_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___57_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___26_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___3_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___49_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_scorecard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_cachedHealth { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___19_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___36_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___63_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___36_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___27_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___40_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Camera> Private_spectateCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_lastDamageTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_killedByLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___66_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_damage_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isPlaying { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___3_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___47_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___34_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___4_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___10_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___19_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___17_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___30_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___39_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___28_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___12_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___24_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___69_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___57_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___38_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedIsPlaying { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___24_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedHasKeycard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___47_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___31_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___55_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___25_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___29_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___11_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___20_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___2_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___39_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_enabled_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___25_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___32_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___61_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___29_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___53_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___27_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_dead_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___51_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___33_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___27_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___32_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___30_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___56_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___41_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___45_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___22_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___3_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___62_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_healthRegenAmt { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___32_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___43_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___15_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_t_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_mp_damage_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___14_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___23_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_joinedRound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_tagHeightMin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget> Private___0_const_intnl_VRCUdonCommonInterfacesNetworkEventTarget { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___59_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isDead { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___18_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___46_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___30_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_guard_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_deathLoc { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___30_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___54_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___13_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___2_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___31_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___27_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___36_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___58_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___44_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___5_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_playerName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___3_intnl_PlayerObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___51_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_PlayerObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___25_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___48_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___22_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_newName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___70_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_teamTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___49_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___53_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_hasKeycard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___23_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___4_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___28_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___3_intnl_GameEffects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Slider> Private___3_intnl_UnityEngineUISlider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Slider> Private___32_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___4_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_ItemControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_GameJoinTrigger { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_GameEffects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___24_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___5_intnl_GameEffects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___13_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_ScoreboardDisplay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___25_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___17_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___18_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___14_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___7_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_PatronControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___15_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_PatronControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___4_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___16_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___5_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_GameEffects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_AFKDetector { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion UdonVariables  of PlayerData

    }
}