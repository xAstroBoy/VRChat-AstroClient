using AstroClient.ClientActions;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC.Udon;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;

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
                var obj = gameObject.FindUdonEvent("__0__SetWantedSynced");
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
                #region PlayerData Zone

                //if (isNotPoolOrThisBehaviour(__0_this_intnl_PlayerData))
                //{
                //    return __0_this_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__0_intnl_PlayerData))
                //{
                //    return __0_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__1_intnl_PlayerData))
                //{
                //    return __1_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__2_intnl_PlayerData))
                //{
                //    return __2_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__3_intnl_PlayerData))
                //{
                //    return __3_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__4_intnl_PlayerData))
                //{
                //    return __4_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__5_intnl_PlayerData))
                //{
                //    return __5_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                ////else if (isNotPoolOrThisBehaviour(__6_intnl_PlayerData))
                ////{
                ////    return __6_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__7_intnl_PlayerData))
                ////{
                ////    return __7_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__8_intnl_PlayerData))
                ////{
                ////    return __8_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__9_intnl_PlayerData))
                ////{
                ////    return __9_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__10_intnl_PlayerData))
                ////{
                ////    return __10_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__11_intnl_PlayerData))
                ////{
                ////    return __11_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__12_intnl_PlayerData))
                ////{
                ////    return __12_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__13_intnl_PlayerData))
                ////{
                ////    return __13_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__14_intnl_PlayerData))
                ////{
                ////    return __14_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__15_intnl_PlayerData))
                ////{
                ////    return __15_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__16_intnl_PlayerData))
                ////{
                ////    return __16_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__17_intnl_PlayerData))
                ////{
                ////    return __17_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__18_intnl_PlayerData))
                ////{
                ////    return __18_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__19_intnl_PlayerData))
                ////{
                ////    return __19_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}
                ////else if (isNotPoolOrThisBehaviour(__20_intnl_PlayerData))
                ////{
                ////    return __20_intnl_PlayerData.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                ////}

                //#endregion PlayerData Zone

                //#region SystemObject Zone

                //else if (isNotPoolOrThisBehaviour(__0_intnl_SystemObject))
                //{
                //    return __0_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__1_intnl_SystemObject))
                //{
                //    return __1_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__5_intnl_SystemObject))
                //{
                //    return __5_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__7_intnl_SystemObject))
                //{
                //    return __7_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__9_intnl_SystemObject))
                //{
                //    return __9_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__10_intnl_SystemObject))
                //{
                //    return __10_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__11_intnl_SystemObject))
                //{
                //    return __11_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__12_intnl_SystemObject))
                //{
                //    return __12_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__13_intnl_SystemObject))
                //{
                //    return __13_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__14_intnl_SystemObject))
                //{
                //    return __14_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__15_intnl_SystemObject))
                //{
                //    return __15_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__16_intnl_SystemObject))
                //{
                //    return __16_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__17_intnl_SystemObject))
                //{
                //    return __17_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__18_intnl_SystemObject))
                //{
                //    return __18_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__19_intnl_SystemObject))
                //{
                //    return __19_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__20_intnl_SystemObject))
                //{
                //    return __20_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__22_intnl_SystemObject))
                //{
                //    return __22_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__23_intnl_SystemObject))
                //{
                //    return __23_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__25_intnl_SystemObject))
                //{
                //    return __25_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__29_intnl_SystemObject))
                //{
                //    return __29_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}
                //else if (isNotPoolOrThisBehaviour(__30_intnl_SystemObject))
                //{
                //    return __30_intnl_SystemObject.gameObject.GetOrAddComponent<PrisonEscape_PoolDataReader>();
                //}

                //#endregion SystemObject Zone

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
         #endregion
        private void Initialize_PlayerData()
        {
            Private___intnl_SystemBoolean_13 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_13");
            Private___intnl_SystemBoolean_23 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_23");
            Private___intnl_SystemBoolean_33 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_33");
            Private___intnl_SystemBoolean_43 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_43");
            Private___intnl_SystemBoolean_53 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_53");
            Private_cachedTimesWanted = new AstroUdonVariable<ushort>(PlayerData, "cachedTimesWanted");
            Private_isWanted = new AstroUdonVariable<bool>(PlayerData, "isWanted");
            Private___gintnl_SystemUInt32_56 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_56");
            Private___gintnl_SystemUInt32_46 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_46");
            Private___gintnl_SystemUInt32_76 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_76");
            Private___gintnl_SystemUInt32_66 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_66");
            Private___gintnl_SystemUInt32_16 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_16");
            Private___gintnl_SystemUInt32_36 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_36");
            Private___gintnl_SystemUInt32_26 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_26");
            Private___intnl_SystemInt32_15 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_15");
            Private___intnl_SystemInt32_35 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_35");
            Private___intnl_SystemInt32_25 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_25");
            Private___lcl_wasActive_SystemBoolean_0 = new AstroUdonVariable<bool>(PlayerData, "__lcl_wasActive_SystemBoolean_0");
            Private___const_SystemString_46 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_46");
            Private___const_SystemString_47 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_47");
            Private___const_SystemString_44 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_44");
            Private___const_SystemString_45 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_45");
            Private___const_SystemString_42 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_42");
            Private___const_SystemString_43 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_43");
            Private___const_SystemString_40 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_40");
            Private___const_SystemString_41 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_41");
            Private___const_SystemString_48 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_48");
            Private___const_SystemString_49 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_49");
            Private___intnl_SystemSingle_0 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_0");
            Private___intnl_SystemObject_0 = new AstroUdonVariable<UnityEngine.Transform>(PlayerData, "__intnl_SystemObject_0");
            Private___const_SystemString_0 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_0");
            Private_cachedIsSuspicious = new AstroUdonVariable<bool>(PlayerData, "cachedIsSuspicious");
            Private_timesWanted = new AstroUdonVariable<ushort>(PlayerData, "timesWanted");
            Private___const_SystemSingle_0 = new AstroUdonVariable<float>(PlayerData, "__const_SystemSingle_0");
            Private_taken = new AstroUdonVariable<bool>(PlayerData, "taken");
            Private___intnl_SystemBoolean_16 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_16");
            Private___intnl_SystemBoolean_26 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_26");
            Private___intnl_SystemBoolean_36 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_36");
            Private___intnl_SystemBoolean_46 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_46");
            Private___intnl_SystemBoolean_56 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_56");
            Private___const_SystemInt32_11 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_11");
            Private___const_SystemInt32_31 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_31");
            Private___const_SystemInt32_21 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_21");
            Private___const_SystemInt32_41 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_41");
            Private_doublePoints = new AstroUdonVariable<bool>(PlayerData, "doublePoints");
            Private___intnl_SystemSingle_10 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_10");
            Private___intnl_SystemSingle_11 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_11");
            Private___intnl_SystemSingle_12 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_12");
            Private___intnl_SystemInt32_12 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_12");
            Private___intnl_SystemInt32_32 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_32");
            Private___intnl_SystemInt32_22 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_22");
            Private___intnl_SystemInt32_42 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_42");
            Private___this_VRCUdonUdonBehaviour_22 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_22");
            Private___this_VRCUdonUdonBehaviour_12 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_12");
            Private_tagHeightScalar = new AstroUdonVariable<float>(PlayerData, "tagHeightScalar");
            Private___intnl_SystemSingle_8 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_8");
            Private___gintnl_SystemUInt32_9 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_9");
            Private___gintnl_SystemUInt32_8 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_8");
            Private___gintnl_SystemUInt32_5 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_5");
            Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_4");
            Private___gintnl_SystemUInt32_7 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_7");
            Private___gintnl_SystemUInt32_6 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_6");
            Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_1");
            Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_0");
            Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_3");
            Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_2");
            Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(PlayerData, "__const_SystemBoolean_0");
            Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(PlayerData, "__const_SystemBoolean_1");
            Private___const_SystemUInt16_0 = new AstroUdonVariable<ushort>(PlayerData, "__const_SystemUInt16_0");
            Private_hitbox = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "hitbox");
            Private___0_count__param = new AstroUdonVariable<int>(PlayerData, "__0_count__param");
            Private___const_SystemString_5 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_5");
            Private___0_damage__param = new AstroUdonVariable<int>(PlayerData, "__0_damage__param");
            Private_maxHealth = new AstroUdonVariable<int>(PlayerData, "maxHealth");
            Private_cachedIsWanted = new AstroUdonVariable<bool>(PlayerData, "cachedIsWanted");
            Private___const_SystemInt32_19 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_19");
            Private___const_SystemInt32_39 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_39");
            Private___const_SystemInt32_29 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_29");
            Private___gintnl_SystemUInt32_53 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_53");
            Private___gintnl_SystemUInt32_43 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_43");
            Private___gintnl_SystemUInt32_73 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_73");
            Private___gintnl_SystemUInt32_63 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_63");
            Private___gintnl_SystemUInt32_13 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_13");
            Private___gintnl_SystemUInt32_33 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_33");
            Private___gintnl_SystemUInt32_23 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_23");
            Private___const_SystemInt32_16 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_16");
            Private___const_SystemInt32_36 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_36");
            Private___const_SystemInt32_26 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_26");
            Private___const_SystemInt32_46 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_46");
            Private_hitboxHead = new AstroUdonVariable<UnityEngine.Transform>(PlayerData, "hitboxHead");
            Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(PlayerData, "__const_VRCUdonCommonInterfacesNetworkEventTarget_0");
            Private___this_VRCUdonUdonBehaviour_27 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_27");
            Private___this_VRCUdonUdonBehaviour_17 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_17");
            Private_goldGuns = new AstroUdonVariable<bool>(PlayerData, "goldGuns");
            Private___0_enabled__param = new AstroUdonVariable<bool>(PlayerData, "__0_enabled__param");
            Private___0_get_IsInnocent__ret = new AstroUdonVariable<bool>(PlayerData, "__0_get_IsInnocent__ret");
            Private___const_SystemString_16 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_16");
            Private___const_SystemString_17 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_17");
            Private___const_SystemString_14 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_14");
            Private___const_SystemString_15 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_15");
            Private___const_SystemString_12 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_12");
            Private___const_SystemString_13 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_13");
            Private___const_SystemString_10 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_10");
            Private___const_SystemString_11 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_11");
            Private___const_SystemString_18 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_18");
            Private___const_SystemString_19 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_19");
            Private___intnl_SystemSingle_7 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_7");
            Private___refl_typeid = new AstroUdonVariable<long>(PlayerData, "__refl_typeid");
            Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(PlayerData, "__const_SystemUInt32_0");
            Private___0_dead__param = new AstroUdonVariable<bool>(PlayerData, "__0_dead__param");
            Private___intnl_SystemBoolean_11 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_11");
            Private___intnl_SystemBoolean_21 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_21");
            Private___intnl_SystemBoolean_31 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_31");
            Private___intnl_SystemBoolean_41 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_41");
            Private___intnl_SystemBoolean_51 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_51");
            Private___intnl_SystemBoolean_61 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_61");
            Private___gintnl_SystemUInt32_54 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_54");
            Private___gintnl_SystemUInt32_44 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_44");
            Private___gintnl_SystemUInt32_74 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_74");
            Private___gintnl_SystemUInt32_64 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_64");
            Private___gintnl_SystemUInt32_14 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_14");
            Private___gintnl_SystemUInt32_34 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_34");
            Private___gintnl_SystemUInt32_24 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_24");
            Private___const_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__const_UnityEngineVector3_0");
            Private___intnl_SystemInt32_17 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_17");
            Private___intnl_SystemInt32_37 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_37");
            Private___intnl_SystemInt32_27 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_27");
            Private_health = new AstroUdonVariable<ushort>(PlayerData, "health");
            Private_healthRegenDelay = new AstroUdonVariable<float>(PlayerData, "healthRegenDelay");
            Private_canDealDamage = new AstroUdonVariable<bool>(PlayerData, "canDealDamage");
            Private___this_VRCUdonUdonBehaviour_24 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_24");
            Private___this_VRCUdonUdonBehaviour_14 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_14");
            Private___0_newName__param = new AstroUdonVariable<string>(PlayerData, "__0_newName__param");
            Private___const_SystemString_66 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_66");
            Private___const_SystemString_67 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_67");
            Private___const_SystemString_64 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_64");
            Private___const_SystemString_65 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_65");
            Private___const_SystemString_62 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_62");
            Private___const_SystemString_63 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_63");
            Private___const_SystemString_60 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_60");
            Private___const_SystemString_61 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_61");
            Private___const_SystemString_68 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_68");
            Private___const_SystemString_69 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_69");
            Private___intnl_SystemSingle_2 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_2");
            Private___const_SystemString_2 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_2");
            Private___0__InstaHeal__ret = new AstroUdonVariable<bool>(PlayerData, "__0__InstaHeal__ret");
            Private___const_SystemSingle_2 = new AstroUdonVariable<float>(PlayerData, "__const_SystemSingle_2");
            Private_lastInstaHealTime = new AstroUdonVariable<float>(PlayerData, "lastInstaHealTime");
            Private___intnl_SystemBoolean_19 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_19");
            Private___intnl_SystemBoolean_29 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_29");
            Private___intnl_SystemBoolean_39 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_39");
            Private___intnl_SystemBoolean_49 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_49");
            Private___intnl_SystemBoolean_59 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_59");
            Private___intnl_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__intnl_UnityEngineVector3_0");
            Private___intnl_UnityEngineGameObject_2 = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__intnl_UnityEngineGameObject_2");
            Private___intnl_UnityEngineGameObject_1 = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__intnl_UnityEngineGameObject_1");
            Private___intnl_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__intnl_UnityEngineGameObject_0");
            Private_cachedArmor = new AstroUdonVariable<ushort>(PlayerData, "cachedArmor");
            Private___intnl_SystemBoolean_14 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_14");
            Private___intnl_SystemBoolean_24 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_24");
            Private___intnl_SystemBoolean_34 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_34");
            Private___intnl_SystemBoolean_44 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_44");
            Private___intnl_SystemBoolean_54 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_54");
            Private___const_SystemInt32_13 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_13");
            Private___const_SystemInt32_33 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_33");
            Private___const_SystemInt32_23 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_23");
            Private___const_SystemInt32_43 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_43");
            Private___intnl_SystemInt32_14 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_14");
            Private___intnl_SystemInt32_34 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_34");
            Private___intnl_SystemInt32_24 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_24");
            Private___0_guard__param = new AstroUdonVariable<bool>(PlayerData, "__0_guard__param");
            Private_damagedInFrame = new AstroUdonVariable<bool>(PlayerData, "damagedInFrame");
            Private___intnl_SystemInt32_19 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_19");
            Private___intnl_SystemInt32_39 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_39");
            Private___intnl_SystemInt32_29 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_29");
            Private___intnl_SystemString_0 = new AstroUdonVariable<string>(PlayerData, "__intnl_SystemString_0");
            Private___this_VRCUdonUdonBehaviour_19 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_19");
            Private___intnl_SystemSingle_1 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_1");
            Private___intnl_SystemObject_1 = new AstroUdonVariable<UnityEngine.Transform>(PlayerData, "__intnl_SystemObject_1");
            Private___const_SystemString_7 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_7");
            Private___const_SystemSingle_1 = new AstroUdonVariable<float>(PlayerData, "__const_SystemSingle_1");
            Private___gintnl_SystemUInt32_51 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_51");
            Private___gintnl_SystemUInt32_41 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_41");
            Private___gintnl_SystemUInt32_71 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_71");
            Private___gintnl_SystemUInt32_61 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_61");
            Private___gintnl_SystemUInt32_11 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_11");
            Private___gintnl_SystemUInt32_31 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_31");
            Private___gintnl_SystemUInt32_21 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_21");
            Private_cachedIsDead = new AstroUdonVariable<bool>(PlayerData, "cachedIsDead");
            Private___intnl_SystemBoolean_17 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_17");
            Private___intnl_SystemBoolean_27 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_27");
            Private___intnl_SystemBoolean_37 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_37");
            Private___intnl_SystemBoolean_47 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_47");
            Private___intnl_SystemBoolean_57 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_57");
            Private___const_SystemInt32_10 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_10");
            Private___const_SystemInt32_30 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_30");
            Private___const_SystemInt32_20 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_20");
            Private___const_SystemInt32_40 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_40");
            Private___const_VRCUdonCommonEnumsEventTiming_0 = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(PlayerData, "__const_VRCUdonCommonEnumsEventTiming_0");
            Private_isGuard = new AstroUdonVariable<bool>(PlayerData, "isGuard");
            Private___intnl_SystemInt32_11 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_11");
            Private___intnl_SystemInt32_31 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_31");
            Private___intnl_SystemInt32_21 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_21");
            Private___intnl_SystemInt32_41 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_41");
            Private___0_sus__param = new AstroUdonVariable<bool>(PlayerData, "__0_sus__param");
            Private___this_VRCUdonUdonBehaviour_21 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_21");
            Private___this_VRCUdonUdonBehaviour_11 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_11");
            Private___const_SystemString_36 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_36");
            Private___const_SystemString_37 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_37");
            Private___const_SystemString_34 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_34");
            Private___const_SystemString_35 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_35");
            Private___const_SystemString_32 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_32");
            Private___const_SystemString_33 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_33");
            Private___const_SystemString_30 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_30");
            Private___const_SystemString_31 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_31");
            Private___const_SystemString_38 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_38");
            Private___const_SystemString_39 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_39");
            Private___intnl_SystemSingle_9 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_9");
            Private___intnl_UnityEngineObject_16 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__intnl_UnityEngineObject_16");
            Private_maxArmor = new AstroUdonVariable<int>(PlayerData, "maxArmor");
            Private_armor = new AstroUdonVariable<ushort>(PlayerData, "armor");
            Private___1_hp__param = new AstroUdonVariable<int>(PlayerData, "__1_hp__param");
            Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(PlayerData, "__intnl_returnJump_SystemUInt32_0");
            Private___0_hp__param = new AstroUdonVariable<int>(PlayerData, "__0_hp__param");
            Private___const_SystemString_4 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_4");
            Private_instaHealDelay = new AstroUdonVariable<float>(PlayerData, "instaHealDelay");
            Private___gintnl_SystemUInt32_59 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_59");
            Private___gintnl_SystemUInt32_49 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_49");
            Private___gintnl_SystemUInt32_69 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_69");
            Private___gintnl_SystemUInt32_19 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_19");
            Private___gintnl_SystemUInt32_39 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_39");
            Private___gintnl_SystemUInt32_29 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_29");
            Private___const_SystemSingle_4 = new AstroUdonVariable<float>(PlayerData, "__const_SystemSingle_4");
            Private___2_hp__param = new AstroUdonVariable<int>(PlayerData, "__2_hp__param");
            Private___const_SystemInt32_18 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_18");
            Private___const_SystemInt32_38 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_38");
            Private___const_SystemInt32_28 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_28");
            Private___gintnl_SystemUInt32_52 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_52");
            Private___gintnl_SystemUInt32_42 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_42");
            Private___gintnl_SystemUInt32_72 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_72");
            Private___gintnl_SystemUInt32_62 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_62");
            Private___gintnl_SystemUInt32_12 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_12");
            Private___gintnl_SystemUInt32_32 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_32");
            Private___gintnl_SystemUInt32_22 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_22");
            Private___intnl_SystemObject_63 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__intnl_SystemObject_63");
            Private___intnl_SystemObject_62 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__intnl_SystemObject_62");
            Private___const_SystemInt32_15 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_15");
            Private___const_SystemInt32_35 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_35");
            Private___const_SystemInt32_25 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_25");
            Private___const_SystemInt32_45 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_45");
            Private___lcl_tagHeight_SystemSingle_0 = new AstroUdonVariable<float>(PlayerData, "__lcl_tagHeight_SystemSingle_0");
            Private___this_VRCUdonUdonBehaviour_26 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_26");
            Private___this_VRCUdonUdonBehaviour_16 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_16");
            Private___intnl_SystemSingle_4 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_4");
            Private_scorecard = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "scorecard");
            Private_cachedHealth = new AstroUdonVariable<ushort>(PlayerData, "cachedHealth");
            Private___const_SystemString_9 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_9");
            Private___intnl_UnityEngineVector3_2 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__intnl_UnityEngineVector3_2");
            Private___intnl_SystemBoolean_12 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_12");
            Private___intnl_SystemBoolean_22 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_22");
            Private___intnl_SystemBoolean_32 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_32");
            Private___intnl_SystemBoolean_42 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_42");
            Private___intnl_SystemBoolean_52 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_52");
            Private___gintnl_SystemUInt32_57 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_57");
            Private___gintnl_SystemUInt32_47 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_47");
            Private___gintnl_SystemUInt32_77 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_77");
            Private___gintnl_SystemUInt32_67 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_67");
            Private___gintnl_SystemUInt32_17 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_17");
            Private___gintnl_SystemUInt32_37 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_37");
            Private___gintnl_SystemUInt32_27 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_27");
            Private_spectateCamera = new AstroUdonVariable<UnityEngine.Camera>(PlayerData, "spectateCamera");
            Private___intnl_SystemInt32_16 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_16");
            Private___intnl_SystemInt32_36 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_36");
            Private___intnl_SystemInt32_26 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_26");
            Private___refl_typename = new AstroUdonVariable<string>(PlayerData, "__refl_typename");
            Private_lastDamageTime = new AstroUdonVariable<float>(PlayerData, "lastDamageTime");
            Private_photoCamera = new AstroUdonVariable<UnityEngine.Camera>(PlayerData, "photoCamera");
            Private_killedByLocal = new AstroUdonVariable<bool>(PlayerData, "killedByLocal");
            Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_1");
            Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_0");
            Private___intnl_SystemInt32_3 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_3");
            Private___intnl_SystemInt32_2 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_2");
            Private___intnl_SystemInt32_5 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_5");
            Private___intnl_SystemInt32_4 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_4");
            Private___intnl_SystemInt32_7 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_7");
            Private___intnl_SystemInt32_6 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_6");
            Private___intnl_SystemInt32_9 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_9");
            Private___intnl_SystemInt32_8 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_8");
            Private_isPlaying = new AstroUdonVariable<bool>(PlayerData, "isPlaying");
            Private___const_SystemString_56 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_56");
            Private___const_SystemString_57 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_57");
            Private___const_SystemString_54 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_54");
            Private___const_SystemString_55 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_55");
            Private___const_SystemString_52 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_52");
            Private___const_SystemString_53 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_53");
            Private___const_SystemString_50 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_50");
            Private___const_SystemString_51 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_51");
            Private___const_SystemString_58 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_58");
            Private___const_SystemString_59 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_59");
            Private___0_t__param = new AstroUdonVariable<bool>(PlayerData, "__0_t__param");
            Private___intnl_SystemSingle_3 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_3");
            Private___intnl_SystemUInt16_0 = new AstroUdonVariable<ushort>(PlayerData, "__intnl_SystemUInt16_0");
            Private_isSuspicious = new AstroUdonVariable<bool>(PlayerData, "isSuspicious");
            Private___const_SystemString_1 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_1");
            Private___const_SystemSingle_3 = new AstroUdonVariable<float>(PlayerData, "__const_SystemSingle_3");
            Private___intnl_UnityEngineVector3_1 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__intnl_UnityEngineVector3_1");
            Private___intnl_SystemBoolean_15 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_15");
            Private___intnl_SystemBoolean_25 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_25");
            Private___intnl_SystemBoolean_35 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_35");
            Private___intnl_SystemBoolean_45 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_45");
            Private___intnl_SystemBoolean_55 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_55");
            Private___const_SystemInt32_12 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_12");
            Private___const_SystemInt32_32 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_32");
            Private___const_SystemInt32_22 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_22");
            Private___const_SystemInt32_42 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_42");
            Private___intnl_SystemInt32_13 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_13");
            Private___intnl_SystemInt32_33 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_33");
            Private___intnl_SystemInt32_23 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_23");
            Private_cachedIsPlaying = new AstroUdonVariable<bool>(PlayerData, "cachedIsPlaying");
            Private___intnl_SystemInt32_18 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_18");
            Private___intnl_SystemInt32_38 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_38");
            Private___intnl_SystemInt32_28 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_28");
            Private_cachedHasKeycard = new AstroUdonVariable<bool>(PlayerData, "cachedHasKeycard");
            Private___this_VRCUdonUdonBehaviour_23 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_23");
            Private___this_VRCUdonUdonBehaviour_13 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_13");
            Private___this_VRCUdonUdonBehaviour_18 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_18");
            Private___intnl_VRCUdonUdonBehaviour_53 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__intnl_VRCUdonUdonBehaviour_53");
            Private___intnl_VRCUdonUdonBehaviour_55 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__intnl_VRCUdonUdonBehaviour_55");
            Private___intnl_VRCUdonUdonBehaviour_56 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__intnl_VRCUdonUdonBehaviour_56");
            Private___const_SystemString_6 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_6");
            Private___intnl_UnityEngineVector3_4 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__intnl_UnityEngineVector3_4");
            Private___gintnl_SystemUInt32_50 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_50");
            Private___gintnl_SystemUInt32_40 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_40");
            Private___gintnl_SystemUInt32_70 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_70");
            Private___gintnl_SystemUInt32_60 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_60");
            Private___gintnl_SystemUInt32_10 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_10");
            Private___gintnl_SystemUInt32_30 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_30");
            Private___gintnl_SystemUInt32_20 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_20");
            Private___const_SystemInt32_17 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_17");
            Private___const_SystemInt32_37 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_37");
            Private___const_SystemInt32_27 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_27");
            Private___const_SystemInt32_47 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_47");
            Private___intnl_SystemInt32_10 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_10");
            Private___intnl_SystemInt32_30 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_30");
            Private___intnl_SystemInt32_20 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_20");
            Private___intnl_SystemInt32_40 = new AstroUdonVariable<int>(PlayerData, "__intnl_SystemInt32_40");
            Private___1_damage__param = new AstroUdonVariable<int>(PlayerData, "__1_damage__param");
            Private___this_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "__this_UnityEngineGameObject_0");
            Private___this_VRCUdonUdonBehaviour_20 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_20");
            Private___this_VRCUdonUdonBehaviour_10 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_10");
            Private___const_SystemString_26 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_26");
            Private___const_SystemString_27 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_27");
            Private___const_SystemString_24 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_24");
            Private___const_SystemString_25 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_25");
            Private___const_SystemString_22 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_22");
            Private___const_SystemString_23 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_23");
            Private___const_SystemString_20 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_20");
            Private___const_SystemString_21 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_21");
            Private___const_SystemString_28 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_28");
            Private___const_SystemString_29 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_29");
            Private___intnl_SystemSingle_6 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_6");
            Private___intnl_UnityEngineObject_17 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__intnl_UnityEngineObject_17");
            Private_healthRegenAmt = new AstroUdonVariable<int>(PlayerData, "healthRegenAmt");
            Private___0_playing__param = new AstroUdonVariable<bool>(PlayerData, "__0_playing__param");
            Private_hitboxRoot = new AstroUdonVariable<UnityEngine.Transform>(PlayerData, "hitboxRoot");
            Private_joinedRound = new AstroUdonVariable<bool>(PlayerData, "joinedRound");
            Private_tagHeightMin = new AstroUdonVariable<float>(PlayerData, "tagHeightMin");
            Private___gintnl_SystemUInt32_58 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_58");
            Private___gintnl_SystemUInt32_48 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_48");
            Private___gintnl_SystemUInt32_78 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_78");
            Private___gintnl_SystemUInt32_68 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_68");
            Private___gintnl_SystemUInt32_18 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_18");
            Private___gintnl_SystemUInt32_38 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_38");
            Private___gintnl_SystemUInt32_28 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_28");
            Private_teamTagObj = new AstroUdonVariable<UnityEngine.GameObject>(PlayerData, "teamTagObj");
            Private_isDead = new AstroUdonVariable<bool>(PlayerData, "isDead");
            Private___intnl_SystemBoolean_10 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_10");
            Private___intnl_SystemBoolean_20 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_20");
            Private___intnl_SystemBoolean_30 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_30");
            Private___intnl_SystemBoolean_40 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_40");
            Private___intnl_SystemBoolean_50 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_50");
            Private___intnl_SystemBoolean_60 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_60");
            Private___gintnl_SystemUInt32_55 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_55");
            Private___gintnl_SystemUInt32_45 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_45");
            Private___gintnl_SystemUInt32_75 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_75");
            Private___gintnl_SystemUInt32_65 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_65");
            Private___gintnl_SystemUInt32_15 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_15");
            Private___gintnl_SystemUInt32_35 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_35");
            Private___gintnl_SystemUInt32_25 = new AstroUdonVariable<uint>(PlayerData, "__gintnl_SystemUInt32_25");
            Private_gameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "gameManager");
            Private_permaSuspicious = new AstroUdonVariable<bool>(PlayerData, "permaSuspicious");
            Private___const_SystemInt32_9 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_9");
            Private___const_SystemInt32_8 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_8");
            Private___const_SystemInt32_1 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_1");
            Private___const_SystemInt32_0 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_0");
            Private___const_SystemInt32_3 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_3");
            Private___const_SystemInt32_2 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_2");
            Private___const_SystemInt32_5 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_5");
            Private___const_SystemInt32_4 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_4");
            Private___const_SystemInt32_7 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_7");
            Private___const_SystemInt32_6 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_6");
            Private___const_SystemInt32_14 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_14");
            Private___const_SystemInt32_34 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_34");
            Private___const_SystemInt32_24 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_24");
            Private___const_SystemInt32_44 = new AstroUdonVariable<int>(PlayerData, "__const_SystemInt32_44");
            Private_deathLoc = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "deathLoc");
            Private___lcl_startArmor_SystemUInt16_0 = new AstroUdonVariable<ushort>(PlayerData, "__lcl_startArmor_SystemUInt16_0");
            Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_8");
            Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_9");
            Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_0");
            Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_1");
            Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_2");
            Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_3");
            Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_4");
            Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_5");
            Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_6");
            Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_7");
            Private___this_VRCUdonUdonBehaviour_25 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_25");
            Private___this_VRCUdonUdonBehaviour_15 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_15");
            Private___0_wanted__param = new AstroUdonVariable<bool>(PlayerData, "__0_wanted__param");
            Private___const_SystemString_72 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_72");
            Private___const_SystemString_70 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_70");
            Private___const_SystemString_71 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_71");
            Private___intnl_SystemSingle_5 = new AstroUdonVariable<float>(PlayerData, "__intnl_SystemSingle_5");
            Private_playerName = new AstroUdonVariable<string>(PlayerData, "playerName");
            Private___const_SystemString_3 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_3");
            Private___this_VRCUdonUdonBehaviour_9 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_9");
            Private___this_VRCUdonUdonBehaviour_8 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_8");
            Private___this_VRCUdonUdonBehaviour_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_3");
            Private___this_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_2");
            Private___this_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_1");
            Private___this_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_0");
            Private___this_VRCUdonUdonBehaviour_7 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_7");
            Private___this_VRCUdonUdonBehaviour_6 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_6");
            Private___this_VRCUdonUdonBehaviour_5 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_5");
            Private___this_VRCUdonUdonBehaviour_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "__this_VRCUdonUdonBehaviour_4");
            Private_teamTag = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PlayerData, "teamTag");
            Private___const_SystemString_8 = new AstroUdonVariable<string>(PlayerData, "__const_SystemString_8");
            Private___intnl_SystemBoolean_18 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_18");
            Private___intnl_SystemBoolean_28 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_28");
            Private___intnl_SystemBoolean_38 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_38");
            Private___intnl_SystemBoolean_48 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_48");
            Private___intnl_SystemBoolean_58 = new AstroUdonVariable<bool>(PlayerData, "__intnl_SystemBoolean_58");
            Private_hasKeycard = new AstroUdonVariable<bool>(PlayerData, "hasKeycard");
            Private___intnl_UnityEngineVector3_3 = new AstroUdonVariable<UnityEngine.Vector3>(PlayerData, "__intnl_UnityEngineVector3_3");
        }

        private void Cleanup_PlayerData()
        {
            Private___intnl_SystemBoolean_13 = null;
            Private___intnl_SystemBoolean_23 = null;
            Private___intnl_SystemBoolean_33 = null;
            Private___intnl_SystemBoolean_43 = null;
            Private___intnl_SystemBoolean_53 = null;
            Private_cachedTimesWanted = null;
            Private_isWanted = null;
            Private___gintnl_SystemUInt32_56 = null;
            Private___gintnl_SystemUInt32_46 = null;
            Private___gintnl_SystemUInt32_76 = null;
            Private___gintnl_SystemUInt32_66 = null;
            Private___gintnl_SystemUInt32_16 = null;
            Private___gintnl_SystemUInt32_36 = null;
            Private___gintnl_SystemUInt32_26 = null;
            Private___intnl_SystemInt32_15 = null;
            Private___intnl_SystemInt32_35 = null;
            Private___intnl_SystemInt32_25 = null;
            Private___lcl_wasActive_SystemBoolean_0 = null;
            Private___const_SystemString_46 = null;
            Private___const_SystemString_47 = null;
            Private___const_SystemString_44 = null;
            Private___const_SystemString_45 = null;
            Private___const_SystemString_42 = null;
            Private___const_SystemString_43 = null;
            Private___const_SystemString_40 = null;
            Private___const_SystemString_41 = null;
            Private___const_SystemString_48 = null;
            Private___const_SystemString_49 = null;
            Private___intnl_SystemSingle_0 = null;
            Private___intnl_SystemObject_0 = null;
            Private___const_SystemString_0 = null;
            Private_cachedIsSuspicious = null;
            Private_timesWanted = null;
            Private___const_SystemSingle_0 = null;
            Private_taken = null;
            Private___intnl_SystemBoolean_16 = null;
            Private___intnl_SystemBoolean_26 = null;
            Private___intnl_SystemBoolean_36 = null;
            Private___intnl_SystemBoolean_46 = null;
            Private___intnl_SystemBoolean_56 = null;
            Private___const_SystemInt32_11 = null;
            Private___const_SystemInt32_31 = null;
            Private___const_SystemInt32_21 = null;
            Private___const_SystemInt32_41 = null;
            Private_doublePoints = null;
            Private___intnl_SystemSingle_10 = null;
            Private___intnl_SystemSingle_11 = null;
            Private___intnl_SystemSingle_12 = null;
            Private___intnl_SystemInt32_12 = null;
            Private___intnl_SystemInt32_32 = null;
            Private___intnl_SystemInt32_22 = null;
            Private___intnl_SystemInt32_42 = null;
            Private___this_VRCUdonUdonBehaviour_22 = null;
            Private___this_VRCUdonUdonBehaviour_12 = null;
            Private_tagHeightScalar = null;
            Private___intnl_SystemSingle_8 = null;
            Private___gintnl_SystemUInt32_9 = null;
            Private___gintnl_SystemUInt32_8 = null;
            Private___gintnl_SystemUInt32_5 = null;
            Private___gintnl_SystemUInt32_4 = null;
            Private___gintnl_SystemUInt32_7 = null;
            Private___gintnl_SystemUInt32_6 = null;
            Private___gintnl_SystemUInt32_1 = null;
            Private___gintnl_SystemUInt32_0 = null;
            Private___gintnl_SystemUInt32_3 = null;
            Private___gintnl_SystemUInt32_2 = null;
            Private___const_SystemBoolean_0 = null;
            Private___const_SystemBoolean_1 = null;
            Private___const_SystemUInt16_0 = null;
            Private_hitbox = null;
            Private___0_count__param = null;
            Private___const_SystemString_5 = null;
            Private___0_damage__param = null;
            Private_maxHealth = null;
            Private_cachedIsWanted = null;
            Private___const_SystemInt32_19 = null;
            Private___const_SystemInt32_39 = null;
            Private___const_SystemInt32_29 = null;
            Private___gintnl_SystemUInt32_53 = null;
            Private___gintnl_SystemUInt32_43 = null;
            Private___gintnl_SystemUInt32_73 = null;
            Private___gintnl_SystemUInt32_63 = null;
            Private___gintnl_SystemUInt32_13 = null;
            Private___gintnl_SystemUInt32_33 = null;
            Private___gintnl_SystemUInt32_23 = null;
            Private___const_SystemInt32_16 = null;
            Private___const_SystemInt32_36 = null;
            Private___const_SystemInt32_26 = null;
            Private___const_SystemInt32_46 = null;
            Private_hitboxHead = null;
            Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 = null;
            Private___this_VRCUdonUdonBehaviour_27 = null;
            Private___this_VRCUdonUdonBehaviour_17 = null;
            Private_goldGuns = null;
            Private___0_enabled__param = null;
            Private___0_get_IsInnocent__ret = null;
            Private___const_SystemString_16 = null;
            Private___const_SystemString_17 = null;
            Private___const_SystemString_14 = null;
            Private___const_SystemString_15 = null;
            Private___const_SystemString_12 = null;
            Private___const_SystemString_13 = null;
            Private___const_SystemString_10 = null;
            Private___const_SystemString_11 = null;
            Private___const_SystemString_18 = null;
            Private___const_SystemString_19 = null;
            Private___intnl_SystemSingle_7 = null;
            Private___refl_typeid = null;
            Private___const_SystemUInt32_0 = null;
            Private___0_dead__param = null;
            Private___intnl_SystemBoolean_11 = null;
            Private___intnl_SystemBoolean_21 = null;
            Private___intnl_SystemBoolean_31 = null;
            Private___intnl_SystemBoolean_41 = null;
            Private___intnl_SystemBoolean_51 = null;
            Private___intnl_SystemBoolean_61 = null;
            Private___gintnl_SystemUInt32_54 = null;
            Private___gintnl_SystemUInt32_44 = null;
            Private___gintnl_SystemUInt32_74 = null;
            Private___gintnl_SystemUInt32_64 = null;
            Private___gintnl_SystemUInt32_14 = null;
            Private___gintnl_SystemUInt32_34 = null;
            Private___gintnl_SystemUInt32_24 = null;
            Private___const_UnityEngineVector3_0 = null;
            Private___intnl_SystemInt32_17 = null;
            Private___intnl_SystemInt32_37 = null;
            Private___intnl_SystemInt32_27 = null;
            Private_health = null;
            Private_healthRegenDelay = null;
            Private_canDealDamage = null;
            Private___this_VRCUdonUdonBehaviour_24 = null;
            Private___this_VRCUdonUdonBehaviour_14 = null;
            Private___0_newName__param = null;
            Private___const_SystemString_66 = null;
            Private___const_SystemString_67 = null;
            Private___const_SystemString_64 = null;
            Private___const_SystemString_65 = null;
            Private___const_SystemString_62 = null;
            Private___const_SystemString_63 = null;
            Private___const_SystemString_60 = null;
            Private___const_SystemString_61 = null;
            Private___const_SystemString_68 = null;
            Private___const_SystemString_69 = null;
            Private___intnl_SystemSingle_2 = null;
            Private___const_SystemString_2 = null;
            Private___0__InstaHeal__ret = null;
            Private___const_SystemSingle_2 = null;
            Private_lastInstaHealTime = null;
            Private___intnl_SystemBoolean_19 = null;
            Private___intnl_SystemBoolean_29 = null;
            Private___intnl_SystemBoolean_39 = null;
            Private___intnl_SystemBoolean_49 = null;
            Private___intnl_SystemBoolean_59 = null;
            Private___intnl_UnityEngineVector3_0 = null;
            Private___intnl_UnityEngineGameObject_2 = null;
            Private___intnl_UnityEngineGameObject_1 = null;
            Private___intnl_UnityEngineGameObject_0 = null;
            Private_cachedArmor = null;
            Private___intnl_SystemBoolean_14 = null;
            Private___intnl_SystemBoolean_24 = null;
            Private___intnl_SystemBoolean_34 = null;
            Private___intnl_SystemBoolean_44 = null;
            Private___intnl_SystemBoolean_54 = null;
            Private___const_SystemInt32_13 = null;
            Private___const_SystemInt32_33 = null;
            Private___const_SystemInt32_23 = null;
            Private___const_SystemInt32_43 = null;
            Private___intnl_SystemInt32_14 = null;
            Private___intnl_SystemInt32_34 = null;
            Private___intnl_SystemInt32_24 = null;
            Private___0_guard__param = null;
            Private_damagedInFrame = null;
            Private___intnl_SystemInt32_19 = null;
            Private___intnl_SystemInt32_39 = null;
            Private___intnl_SystemInt32_29 = null;
            Private___intnl_SystemString_0 = null;
            Private___this_VRCUdonUdonBehaviour_19 = null;
            Private___intnl_SystemSingle_1 = null;
            Private___intnl_SystemObject_1 = null;
            Private___const_SystemString_7 = null;
            Private___const_SystemSingle_1 = null;
            Private___gintnl_SystemUInt32_51 = null;
            Private___gintnl_SystemUInt32_41 = null;
            Private___gintnl_SystemUInt32_71 = null;
            Private___gintnl_SystemUInt32_61 = null;
            Private___gintnl_SystemUInt32_11 = null;
            Private___gintnl_SystemUInt32_31 = null;
            Private___gintnl_SystemUInt32_21 = null;
            Private_cachedIsDead = null;
            Private___intnl_SystemBoolean_17 = null;
            Private___intnl_SystemBoolean_27 = null;
            Private___intnl_SystemBoolean_37 = null;
            Private___intnl_SystemBoolean_47 = null;
            Private___intnl_SystemBoolean_57 = null;
            Private___const_SystemInt32_10 = null;
            Private___const_SystemInt32_30 = null;
            Private___const_SystemInt32_20 = null;
            Private___const_SystemInt32_40 = null;
            Private___const_VRCUdonCommonEnumsEventTiming_0 = null;
            Private_isGuard = null;
            Private___intnl_SystemInt32_11 = null;
            Private___intnl_SystemInt32_31 = null;
            Private___intnl_SystemInt32_21 = null;
            Private___intnl_SystemInt32_41 = null;
            Private___0_sus__param = null;
            Private___this_VRCUdonUdonBehaviour_21 = null;
            Private___this_VRCUdonUdonBehaviour_11 = null;
            Private___const_SystemString_36 = null;
            Private___const_SystemString_37 = null;
            Private___const_SystemString_34 = null;
            Private___const_SystemString_35 = null;
            Private___const_SystemString_32 = null;
            Private___const_SystemString_33 = null;
            Private___const_SystemString_30 = null;
            Private___const_SystemString_31 = null;
            Private___const_SystemString_38 = null;
            Private___const_SystemString_39 = null;
            Private___intnl_SystemSingle_9 = null;
            Private___intnl_UnityEngineObject_16 = null;
            Private_maxArmor = null;
            Private_armor = null;
            Private___1_hp__param = null;
            Private___intnl_returnJump_SystemUInt32_0 = null;
            Private___0_hp__param = null;
            Private___const_SystemString_4 = null;
            Private_instaHealDelay = null;
            Private___gintnl_SystemUInt32_59 = null;
            Private___gintnl_SystemUInt32_49 = null;
            Private___gintnl_SystemUInt32_69 = null;
            Private___gintnl_SystemUInt32_19 = null;
            Private___gintnl_SystemUInt32_39 = null;
            Private___gintnl_SystemUInt32_29 = null;
            Private___const_SystemSingle_4 = null;
            Private___2_hp__param = null;
            Private___const_SystemInt32_18 = null;
            Private___const_SystemInt32_38 = null;
            Private___const_SystemInt32_28 = null;
            Private___gintnl_SystemUInt32_52 = null;
            Private___gintnl_SystemUInt32_42 = null;
            Private___gintnl_SystemUInt32_72 = null;
            Private___gintnl_SystemUInt32_62 = null;
            Private___gintnl_SystemUInt32_12 = null;
            Private___gintnl_SystemUInt32_32 = null;
            Private___gintnl_SystemUInt32_22 = null;
            Private___intnl_SystemObject_63 = null;
            Private___intnl_SystemObject_62 = null;
            Private___const_SystemInt32_15 = null;
            Private___const_SystemInt32_35 = null;
            Private___const_SystemInt32_25 = null;
            Private___const_SystemInt32_45 = null;
            Private___lcl_tagHeight_SystemSingle_0 = null;
            Private___this_VRCUdonUdonBehaviour_26 = null;
            Private___this_VRCUdonUdonBehaviour_16 = null;
            Private___intnl_SystemSingle_4 = null;
            Private_scorecard = null;
            Private_cachedHealth = null;
            Private___const_SystemString_9 = null;
            Private___intnl_UnityEngineVector3_2 = null;
            Private___intnl_SystemBoolean_12 = null;
            Private___intnl_SystemBoolean_22 = null;
            Private___intnl_SystemBoolean_32 = null;
            Private___intnl_SystemBoolean_42 = null;
            Private___intnl_SystemBoolean_52 = null;
            Private___gintnl_SystemUInt32_57 = null;
            Private___gintnl_SystemUInt32_47 = null;
            Private___gintnl_SystemUInt32_77 = null;
            Private___gintnl_SystemUInt32_67 = null;
            Private___gintnl_SystemUInt32_17 = null;
            Private___gintnl_SystemUInt32_37 = null;
            Private___gintnl_SystemUInt32_27 = null;
            Private_spectateCamera = null;
            Private___intnl_SystemInt32_16 = null;
            Private___intnl_SystemInt32_36 = null;
            Private___intnl_SystemInt32_26 = null;
            Private___refl_typename = null;
            Private_lastDamageTime = null;
            Private_photoCamera = null;
            Private_killedByLocal = null;
            Private___intnl_SystemInt32_1 = null;
            Private___intnl_SystemInt32_0 = null;
            Private___intnl_SystemInt32_3 = null;
            Private___intnl_SystemInt32_2 = null;
            Private___intnl_SystemInt32_5 = null;
            Private___intnl_SystemInt32_4 = null;
            Private___intnl_SystemInt32_7 = null;
            Private___intnl_SystemInt32_6 = null;
            Private___intnl_SystemInt32_9 = null;
            Private___intnl_SystemInt32_8 = null;
            Private_isPlaying = null;
            Private___const_SystemString_56 = null;
            Private___const_SystemString_57 = null;
            Private___const_SystemString_54 = null;
            Private___const_SystemString_55 = null;
            Private___const_SystemString_52 = null;
            Private___const_SystemString_53 = null;
            Private___const_SystemString_50 = null;
            Private___const_SystemString_51 = null;
            Private___const_SystemString_58 = null;
            Private___const_SystemString_59 = null;
            Private___0_t__param = null;
            Private___intnl_SystemSingle_3 = null;
            Private___intnl_SystemUInt16_0 = null;
            Private_isSuspicious = null;
            Private___const_SystemString_1 = null;
            Private___const_SystemSingle_3 = null;
            Private___intnl_UnityEngineVector3_1 = null;
            Private___intnl_SystemBoolean_15 = null;
            Private___intnl_SystemBoolean_25 = null;
            Private___intnl_SystemBoolean_35 = null;
            Private___intnl_SystemBoolean_45 = null;
            Private___intnl_SystemBoolean_55 = null;
            Private___const_SystemInt32_12 = null;
            Private___const_SystemInt32_32 = null;
            Private___const_SystemInt32_22 = null;
            Private___const_SystemInt32_42 = null;
            Private___intnl_SystemInt32_13 = null;
            Private___intnl_SystemInt32_33 = null;
            Private___intnl_SystemInt32_23 = null;
            Private_cachedIsPlaying = null;
            Private___intnl_SystemInt32_18 = null;
            Private___intnl_SystemInt32_38 = null;
            Private___intnl_SystemInt32_28 = null;
            Private_cachedHasKeycard = null;
            Private___this_VRCUdonUdonBehaviour_23 = null;
            Private___this_VRCUdonUdonBehaviour_13 = null;
            Private___this_VRCUdonUdonBehaviour_18 = null;
            Private___intnl_VRCUdonUdonBehaviour_53 = null;
            Private___intnl_VRCUdonUdonBehaviour_55 = null;
            Private___intnl_VRCUdonUdonBehaviour_56 = null;
            Private___const_SystemString_6 = null;
            Private___intnl_UnityEngineVector3_4 = null;
            Private___gintnl_SystemUInt32_50 = null;
            Private___gintnl_SystemUInt32_40 = null;
            Private___gintnl_SystemUInt32_70 = null;
            Private___gintnl_SystemUInt32_60 = null;
            Private___gintnl_SystemUInt32_10 = null;
            Private___gintnl_SystemUInt32_30 = null;
            Private___gintnl_SystemUInt32_20 = null;
            Private___const_SystemInt32_17 = null;
            Private___const_SystemInt32_37 = null;
            Private___const_SystemInt32_27 = null;
            Private___const_SystemInt32_47 = null;
            Private___intnl_SystemInt32_10 = null;
            Private___intnl_SystemInt32_30 = null;
            Private___intnl_SystemInt32_20 = null;
            Private___intnl_SystemInt32_40 = null;
            Private___1_damage__param = null;
            Private___this_UnityEngineGameObject_0 = null;
            Private___this_VRCUdonUdonBehaviour_20 = null;
            Private___this_VRCUdonUdonBehaviour_10 = null;
            Private___const_SystemString_26 = null;
            Private___const_SystemString_27 = null;
            Private___const_SystemString_24 = null;
            Private___const_SystemString_25 = null;
            Private___const_SystemString_22 = null;
            Private___const_SystemString_23 = null;
            Private___const_SystemString_20 = null;
            Private___const_SystemString_21 = null;
            Private___const_SystemString_28 = null;
            Private___const_SystemString_29 = null;
            Private___intnl_SystemSingle_6 = null;
            Private___intnl_UnityEngineObject_17 = null;
            Private_healthRegenAmt = null;
            Private___0_playing__param = null;
            Private_hitboxRoot = null;
            Private_joinedRound = null;
            Private_tagHeightMin = null;
            Private___gintnl_SystemUInt32_58 = null;
            Private___gintnl_SystemUInt32_48 = null;
            Private___gintnl_SystemUInt32_78 = null;
            Private___gintnl_SystemUInt32_68 = null;
            Private___gintnl_SystemUInt32_18 = null;
            Private___gintnl_SystemUInt32_38 = null;
            Private___gintnl_SystemUInt32_28 = null;
            Private_teamTagObj = null;
            Private_isDead = null;
            Private___intnl_SystemBoolean_10 = null;
            Private___intnl_SystemBoolean_20 = null;
            Private___intnl_SystemBoolean_30 = null;
            Private___intnl_SystemBoolean_40 = null;
            Private___intnl_SystemBoolean_50 = null;
            Private___intnl_SystemBoolean_60 = null;
            Private___gintnl_SystemUInt32_55 = null;
            Private___gintnl_SystemUInt32_45 = null;
            Private___gintnl_SystemUInt32_75 = null;
            Private___gintnl_SystemUInt32_65 = null;
            Private___gintnl_SystemUInt32_15 = null;
            Private___gintnl_SystemUInt32_35 = null;
            Private___gintnl_SystemUInt32_25 = null;
            Private_gameManager = null;
            Private_permaSuspicious = null;
            Private___const_SystemInt32_9 = null;
            Private___const_SystemInt32_8 = null;
            Private___const_SystemInt32_1 = null;
            Private___const_SystemInt32_0 = null;
            Private___const_SystemInt32_3 = null;
            Private___const_SystemInt32_2 = null;
            Private___const_SystemInt32_5 = null;
            Private___const_SystemInt32_4 = null;
            Private___const_SystemInt32_7 = null;
            Private___const_SystemInt32_6 = null;
            Private___const_SystemInt32_14 = null;
            Private___const_SystemInt32_34 = null;
            Private___const_SystemInt32_24 = null;
            Private___const_SystemInt32_44 = null;
            Private_deathLoc = null;
            Private___lcl_startArmor_SystemUInt16_0 = null;
            Private___intnl_SystemBoolean_8 = null;
            Private___intnl_SystemBoolean_9 = null;
            Private___intnl_SystemBoolean_0 = null;
            Private___intnl_SystemBoolean_1 = null;
            Private___intnl_SystemBoolean_2 = null;
            Private___intnl_SystemBoolean_3 = null;
            Private___intnl_SystemBoolean_4 = null;
            Private___intnl_SystemBoolean_5 = null;
            Private___intnl_SystemBoolean_6 = null;
            Private___intnl_SystemBoolean_7 = null;
            Private___this_VRCUdonUdonBehaviour_25 = null;
            Private___this_VRCUdonUdonBehaviour_15 = null;
            Private___0_wanted__param = null;
            Private___const_SystemString_72 = null;
            Private___const_SystemString_70 = null;
            Private___const_SystemString_71 = null;
            Private___intnl_SystemSingle_5 = null;
            Private_playerName = null;
            Private___const_SystemString_3 = null;
            Private___this_VRCUdonUdonBehaviour_9 = null;
            Private___this_VRCUdonUdonBehaviour_8 = null;
            Private___this_VRCUdonUdonBehaviour_3 = null;
            Private___this_VRCUdonUdonBehaviour_2 = null;
            Private___this_VRCUdonUdonBehaviour_1 = null;
            Private___this_VRCUdonUdonBehaviour_0 = null;
            Private___this_VRCUdonUdonBehaviour_7 = null;
            Private___this_VRCUdonUdonBehaviour_6 = null;
            Private___this_VRCUdonUdonBehaviour_5 = null;
            Private___this_VRCUdonUdonBehaviour_4 = null;
            Private_teamTag = null;
            Private___const_SystemString_8 = null;
            Private___intnl_SystemBoolean_18 = null;
            Private___intnl_SystemBoolean_28 = null;
            Private___intnl_SystemBoolean_38 = null;
            Private___intnl_SystemBoolean_48 = null;
            Private___intnl_SystemBoolean_58 = null;
            Private_hasKeycard = null;
            Private___intnl_UnityEngineVector3_3 = null;
        }

        #region Getter / Setters AstroUdonVariables  of PlayerData

        internal bool? __intnl_SystemBoolean_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_13 != null)
                {
                    return Private___intnl_SystemBoolean_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_13 != null)
                    {
                        Private___intnl_SystemBoolean_13.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_23 != null)
                {
                    return Private___intnl_SystemBoolean_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_23 != null)
                    {
                        Private___intnl_SystemBoolean_23.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_33
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_33 != null)
                {
                    return Private___intnl_SystemBoolean_33.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_33 != null)
                    {
                        Private___intnl_SystemBoolean_33.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_43
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_43 != null)
                {
                    return Private___intnl_SystemBoolean_43.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_43 != null)
                    {
                        Private___intnl_SystemBoolean_43.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_53
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_53 != null)
                {
                    return Private___intnl_SystemBoolean_53.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_53 != null)
                    {
                        Private___intnl_SystemBoolean_53.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? cachedTimesWanted
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedTimesWanted != null)
                {
                    return Private_cachedTimesWanted.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedTimesWanted != null)
                    {
                        Private_cachedTimesWanted.Value = value.Value;
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

        internal uint? __gintnl_SystemUInt32_56
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_56 != null)
                {
                    return Private___gintnl_SystemUInt32_56.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_56 != null)
                    {
                        Private___gintnl_SystemUInt32_56.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_46
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_46 != null)
                {
                    return Private___gintnl_SystemUInt32_46.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_46 != null)
                    {
                        Private___gintnl_SystemUInt32_46.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_76
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_76 != null)
                {
                    return Private___gintnl_SystemUInt32_76.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_76 != null)
                    {
                        Private___gintnl_SystemUInt32_76.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_66
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_66 != null)
                {
                    return Private___gintnl_SystemUInt32_66.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_66 != null)
                    {
                        Private___gintnl_SystemUInt32_66.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_16 != null)
                {
                    return Private___gintnl_SystemUInt32_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_16 != null)
                    {
                        Private___gintnl_SystemUInt32_16.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_36
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_36 != null)
                {
                    return Private___gintnl_SystemUInt32_36.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_36 != null)
                    {
                        Private___gintnl_SystemUInt32_36.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_26
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_26 != null)
                {
                    return Private___gintnl_SystemUInt32_26.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_26 != null)
                    {
                        Private___gintnl_SystemUInt32_26.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_15 != null)
                {
                    return Private___intnl_SystemInt32_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_15 != null)
                    {
                        Private___intnl_SystemInt32_15.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_35
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_35 != null)
                {
                    return Private___intnl_SystemInt32_35.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_35 != null)
                    {
                        Private___intnl_SystemInt32_35.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_25 != null)
                {
                    return Private___intnl_SystemInt32_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_25 != null)
                    {
                        Private___intnl_SystemInt32_25.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __lcl_wasActive_SystemBoolean_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_wasActive_SystemBoolean_0 != null)
                {
                    return Private___lcl_wasActive_SystemBoolean_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_wasActive_SystemBoolean_0 != null)
                    {
                        Private___lcl_wasActive_SystemBoolean_0.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_46
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_46 != null)
                {
                    return Private___const_SystemString_46.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_46 != null)
                {
                    Private___const_SystemString_46.Value = value;
                }
            }
        }

        internal string __const_SystemString_47
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_47 != null)
                {
                    return Private___const_SystemString_47.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_47 != null)
                {
                    Private___const_SystemString_47.Value = value;
                }
            }
        }

        internal string __const_SystemString_44
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_44 != null)
                {
                    return Private___const_SystemString_44.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_44 != null)
                {
                    Private___const_SystemString_44.Value = value;
                }
            }
        }

        internal string __const_SystemString_45
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_45 != null)
                {
                    return Private___const_SystemString_45.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_45 != null)
                {
                    Private___const_SystemString_45.Value = value;
                }
            }
        }

        internal string __const_SystemString_42
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_42 != null)
                {
                    return Private___const_SystemString_42.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_42 != null)
                {
                    Private___const_SystemString_42.Value = value;
                }
            }
        }

        internal string __const_SystemString_43
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_43 != null)
                {
                    return Private___const_SystemString_43.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_43 != null)
                {
                    Private___const_SystemString_43.Value = value;
                }
            }
        }

        internal string __const_SystemString_40
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_40 != null)
                {
                    return Private___const_SystemString_40.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_40 != null)
                {
                    Private___const_SystemString_40.Value = value;
                }
            }
        }

        internal string __const_SystemString_41
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_41 != null)
                {
                    return Private___const_SystemString_41.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_41 != null)
                {
                    Private___const_SystemString_41.Value = value;
                }
            }
        }

        internal string __const_SystemString_48
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_48 != null)
                {
                    return Private___const_SystemString_48.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_48 != null)
                {
                    Private___const_SystemString_48.Value = value;
                }
            }
        }

        internal string __const_SystemString_49
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_49 != null)
                {
                    return Private___const_SystemString_49.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_49 != null)
                {
                    Private___const_SystemString_49.Value = value;
                }
            }
        }

        internal float? __intnl_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_0 != null)
                {
                    return Private___intnl_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_0 != null)
                    {
                        Private___intnl_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __intnl_SystemObject_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_0 != null)
                {
                    return Private___intnl_SystemObject_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_0 != null)
                {
                    Private___intnl_SystemObject_0.Value = value;
                }
            }
        }

        internal string __const_SystemString_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_0 != null)
                {
                    return Private___const_SystemString_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_0 != null)
                {
                    Private___const_SystemString_0.Value = value;
                }
            }
        }

        internal bool? cachedIsSuspicious
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedIsSuspicious != null)
                {
                    return Private_cachedIsSuspicious.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedIsSuspicious != null)
                    {
                        Private_cachedIsSuspicious.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? timesWanted
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timesWanted != null)
                {
                    return Private_timesWanted.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timesWanted != null)
                    {
                        Private_timesWanted.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_0 != null)
                {
                    return Private___const_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_0 != null)
                    {
                        Private___const_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? taken
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_taken != null)
                {
                    return Private_taken.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_taken != null)
                    {
                        Private_taken.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_16 != null)
                {
                    return Private___intnl_SystemBoolean_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_16 != null)
                    {
                        Private___intnl_SystemBoolean_16.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_26
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_26 != null)
                {
                    return Private___intnl_SystemBoolean_26.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_26 != null)
                    {
                        Private___intnl_SystemBoolean_26.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_36
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_36 != null)
                {
                    return Private___intnl_SystemBoolean_36.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_36 != null)
                    {
                        Private___intnl_SystemBoolean_36.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_46
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_46 != null)
                {
                    return Private___intnl_SystemBoolean_46.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_46 != null)
                    {
                        Private___intnl_SystemBoolean_46.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_56
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_56 != null)
                {
                    return Private___intnl_SystemBoolean_56.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_56 != null)
                    {
                        Private___intnl_SystemBoolean_56.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_11 != null)
                {
                    return Private___const_SystemInt32_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_11 != null)
                    {
                        Private___const_SystemInt32_11.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_31
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_31 != null)
                {
                    return Private___const_SystemInt32_31.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_31 != null)
                    {
                        Private___const_SystemInt32_31.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_21 != null)
                {
                    return Private___const_SystemInt32_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_21 != null)
                    {
                        Private___const_SystemInt32_21.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_41
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_41 != null)
                {
                    return Private___const_SystemInt32_41.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_41 != null)
                    {
                        Private___const_SystemInt32_41.Value = value.Value;
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

        internal float? __intnl_SystemSingle_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_10 != null)
                {
                    return Private___intnl_SystemSingle_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_10 != null)
                    {
                        Private___intnl_SystemSingle_10.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_11 != null)
                {
                    return Private___intnl_SystemSingle_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_11 != null)
                    {
                        Private___intnl_SystemSingle_11.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_12 != null)
                {
                    return Private___intnl_SystemSingle_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_12 != null)
                    {
                        Private___intnl_SystemSingle_12.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_12 != null)
                {
                    return Private___intnl_SystemInt32_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_12 != null)
                    {
                        Private___intnl_SystemInt32_12.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_32 != null)
                {
                    return Private___intnl_SystemInt32_32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_32 != null)
                    {
                        Private___intnl_SystemInt32_32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_22 != null)
                {
                    return Private___intnl_SystemInt32_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_22 != null)
                    {
                        Private___intnl_SystemInt32_22.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_42
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_42 != null)
                {
                    return Private___intnl_SystemInt32_42.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_42 != null)
                    {
                        Private___intnl_SystemInt32_42.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_22 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_22 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_22.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_12 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_12 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_12.Value = value;
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

        internal float? __intnl_SystemSingle_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_8 != null)
                {
                    return Private___intnl_SystemSingle_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_8 != null)
                    {
                        Private___intnl_SystemSingle_8.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_9 != null)
                {
                    return Private___gintnl_SystemUInt32_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_9 != null)
                    {
                        Private___gintnl_SystemUInt32_9.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_8 != null)
                {
                    return Private___gintnl_SystemUInt32_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_8 != null)
                    {
                        Private___gintnl_SystemUInt32_8.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_5 != null)
                {
                    return Private___gintnl_SystemUInt32_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_5 != null)
                    {
                        Private___gintnl_SystemUInt32_5.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_4 != null)
                {
                    return Private___gintnl_SystemUInt32_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_4 != null)
                    {
                        Private___gintnl_SystemUInt32_4.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_7 != null)
                {
                    return Private___gintnl_SystemUInt32_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_7 != null)
                    {
                        Private___gintnl_SystemUInt32_7.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_6 != null)
                {
                    return Private___gintnl_SystemUInt32_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_6 != null)
                    {
                        Private___gintnl_SystemUInt32_6.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_1 != null)
                {
                    return Private___gintnl_SystemUInt32_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_1 != null)
                    {
                        Private___gintnl_SystemUInt32_1.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_0 != null)
                {
                    return Private___gintnl_SystemUInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_0 != null)
                    {
                        Private___gintnl_SystemUInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_3 != null)
                {
                    return Private___gintnl_SystemUInt32_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_3 != null)
                    {
                        Private___gintnl_SystemUInt32_3.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_2 != null)
                {
                    return Private___gintnl_SystemUInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_2 != null)
                    {
                        Private___gintnl_SystemUInt32_2.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __const_SystemBoolean_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemBoolean_0 != null)
                {
                    return Private___const_SystemBoolean_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemBoolean_0 != null)
                    {
                        Private___const_SystemBoolean_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __const_SystemBoolean_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemBoolean_1 != null)
                {
                    return Private___const_SystemBoolean_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemBoolean_1 != null)
                    {
                        Private___const_SystemBoolean_1.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? __const_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt16_0 != null)
                {
                    return Private___const_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt16_0 != null)
                    {
                        Private___const_SystemUInt16_0.Value = value.Value;
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

        internal int? __0_count__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_count__param != null)
                {
                    return Private___0_count__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_count__param != null)
                    {
                        Private___0_count__param.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_5 != null)
                {
                    return Private___const_SystemString_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_5 != null)
                {
                    Private___const_SystemString_5.Value = value;
                }
            }
        }

        internal int? __0_damage__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_damage__param != null)
                {
                    return Private___0_damage__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_damage__param != null)
                    {
                        Private___0_damage__param.Value = value.Value;
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

        internal int? __const_SystemInt32_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_19 != null)
                {
                    return Private___const_SystemInt32_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_19 != null)
                    {
                        Private___const_SystemInt32_19.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_39
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_39 != null)
                {
                    return Private___const_SystemInt32_39.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_39 != null)
                    {
                        Private___const_SystemInt32_39.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_29
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_29 != null)
                {
                    return Private___const_SystemInt32_29.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_29 != null)
                    {
                        Private___const_SystemInt32_29.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_53
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_53 != null)
                {
                    return Private___gintnl_SystemUInt32_53.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_53 != null)
                    {
                        Private___gintnl_SystemUInt32_53.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_43
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_43 != null)
                {
                    return Private___gintnl_SystemUInt32_43.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_43 != null)
                    {
                        Private___gintnl_SystemUInt32_43.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_73
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_73 != null)
                {
                    return Private___gintnl_SystemUInt32_73.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_73 != null)
                    {
                        Private___gintnl_SystemUInt32_73.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_63
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_63 != null)
                {
                    return Private___gintnl_SystemUInt32_63.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_63 != null)
                    {
                        Private___gintnl_SystemUInt32_63.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_13 != null)
                {
                    return Private___gintnl_SystemUInt32_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_13 != null)
                    {
                        Private___gintnl_SystemUInt32_13.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_33
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_33 != null)
                {
                    return Private___gintnl_SystemUInt32_33.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_33 != null)
                    {
                        Private___gintnl_SystemUInt32_33.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_23 != null)
                {
                    return Private___gintnl_SystemUInt32_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_23 != null)
                    {
                        Private___gintnl_SystemUInt32_23.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_16 != null)
                {
                    return Private___const_SystemInt32_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_16 != null)
                    {
                        Private___const_SystemInt32_16.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_36
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_36 != null)
                {
                    return Private___const_SystemInt32_36.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_36 != null)
                    {
                        Private___const_SystemInt32_36.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_26
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_26 != null)
                {
                    return Private___const_SystemInt32_26.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_26 != null)
                    {
                        Private___const_SystemInt32_26.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_46
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_46 != null)
                {
                    return Private___const_SystemInt32_46.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_46 != null)
                    {
                        Private___const_SystemInt32_46.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform hitboxHead
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hitboxHead != null)
                {
                    return Private_hitboxHead.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_hitboxHead != null)
                {
                    Private_hitboxHead.Value = value;
                }
            }
        }

        internal VRC.Udon.Common.Interfaces.NetworkEventTarget? __const_VRCUdonCommonInterfacesNetworkEventTarget_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 != null)
                {
                    return Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 != null)
                    {
                        Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_27
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_27 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_27.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_27 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_27.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_17 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_17 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_17.Value = value;
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

        internal bool? __0_enabled__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_enabled__param != null)
                {
                    return Private___0_enabled__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_enabled__param != null)
                    {
                        Private___0_enabled__param.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_get_IsInnocent__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_get_IsInnocent__ret != null)
                {
                    return Private___0_get_IsInnocent__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_get_IsInnocent__ret != null)
                    {
                        Private___0_get_IsInnocent__ret.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_16 != null)
                {
                    return Private___const_SystemString_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_16 != null)
                {
                    Private___const_SystemString_16.Value = value;
                }
            }
        }

        internal string __const_SystemString_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_17 != null)
                {
                    return Private___const_SystemString_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_17 != null)
                {
                    Private___const_SystemString_17.Value = value;
                }
            }
        }

        internal string __const_SystemString_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_14 != null)
                {
                    return Private___const_SystemString_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_14 != null)
                {
                    Private___const_SystemString_14.Value = value;
                }
            }
        }

        internal string __const_SystemString_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_15 != null)
                {
                    return Private___const_SystemString_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_15 != null)
                {
                    Private___const_SystemString_15.Value = value;
                }
            }
        }

        internal string __const_SystemString_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_12 != null)
                {
                    return Private___const_SystemString_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_12 != null)
                {
                    Private___const_SystemString_12.Value = value;
                }
            }
        }

        internal string __const_SystemString_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_13 != null)
                {
                    return Private___const_SystemString_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_13 != null)
                {
                    Private___const_SystemString_13.Value = value;
                }
            }
        }

        internal string __const_SystemString_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_10 != null)
                {
                    return Private___const_SystemString_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_10 != null)
                {
                    Private___const_SystemString_10.Value = value;
                }
            }
        }

        internal string __const_SystemString_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_11 != null)
                {
                    return Private___const_SystemString_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_11 != null)
                {
                    Private___const_SystemString_11.Value = value;
                }
            }
        }

        internal string __const_SystemString_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_18 != null)
                {
                    return Private___const_SystemString_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_18 != null)
                {
                    Private___const_SystemString_18.Value = value;
                }
            }
        }

        internal string __const_SystemString_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_19 != null)
                {
                    return Private___const_SystemString_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_19 != null)
                {
                    Private___const_SystemString_19.Value = value;
                }
            }
        }

        internal float? __intnl_SystemSingle_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_7 != null)
                {
                    return Private___intnl_SystemSingle_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_7 != null)
                    {
                        Private___intnl_SystemSingle_7.Value = value.Value;
                    }
                }
            }
        }

        internal long? __refl_typeid
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___refl_typeid != null)
                {
                    return Private___refl_typeid.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___refl_typeid != null)
                    {
                        Private___refl_typeid.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_0 != null)
                {
                    return Private___const_SystemUInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_0 != null)
                    {
                        Private___const_SystemUInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_dead__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_dead__param != null)
                {
                    return Private___0_dead__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_dead__param != null)
                    {
                        Private___0_dead__param.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_11 != null)
                {
                    return Private___intnl_SystemBoolean_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_11 != null)
                    {
                        Private___intnl_SystemBoolean_11.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_21 != null)
                {
                    return Private___intnl_SystemBoolean_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_21 != null)
                    {
                        Private___intnl_SystemBoolean_21.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_31
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_31 != null)
                {
                    return Private___intnl_SystemBoolean_31.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_31 != null)
                    {
                        Private___intnl_SystemBoolean_31.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_41
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_41 != null)
                {
                    return Private___intnl_SystemBoolean_41.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_41 != null)
                    {
                        Private___intnl_SystemBoolean_41.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_51
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_51 != null)
                {
                    return Private___intnl_SystemBoolean_51.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_51 != null)
                    {
                        Private___intnl_SystemBoolean_51.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_61
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_61 != null)
                {
                    return Private___intnl_SystemBoolean_61.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_61 != null)
                    {
                        Private___intnl_SystemBoolean_61.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_54
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_54 != null)
                {
                    return Private___gintnl_SystemUInt32_54.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_54 != null)
                    {
                        Private___gintnl_SystemUInt32_54.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_44
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_44 != null)
                {
                    return Private___gintnl_SystemUInt32_44.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_44 != null)
                    {
                        Private___gintnl_SystemUInt32_44.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_74
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_74 != null)
                {
                    return Private___gintnl_SystemUInt32_74.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_74 != null)
                    {
                        Private___gintnl_SystemUInt32_74.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_64 != null)
                {
                    return Private___gintnl_SystemUInt32_64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_64 != null)
                    {
                        Private___gintnl_SystemUInt32_64.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_14 != null)
                {
                    return Private___gintnl_SystemUInt32_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_14 != null)
                    {
                        Private___gintnl_SystemUInt32_14.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_34
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_34 != null)
                {
                    return Private___gintnl_SystemUInt32_34.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_34 != null)
                    {
                        Private___gintnl_SystemUInt32_34.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_24
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_24 != null)
                {
                    return Private___gintnl_SystemUInt32_24.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_24 != null)
                    {
                        Private___gintnl_SystemUInt32_24.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __const_UnityEngineVector3_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_UnityEngineVector3_0 != null)
                {
                    return Private___const_UnityEngineVector3_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_UnityEngineVector3_0 != null)
                    {
                        Private___const_UnityEngineVector3_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_17 != null)
                {
                    return Private___intnl_SystemInt32_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_17 != null)
                    {
                        Private___intnl_SystemInt32_17.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_37
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_37 != null)
                {
                    return Private___intnl_SystemInt32_37.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_37 != null)
                    {
                        Private___intnl_SystemInt32_37.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_27
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_27 != null)
                {
                    return Private___intnl_SystemInt32_27.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_27 != null)
                    {
                        Private___intnl_SystemInt32_27.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? health
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

        internal bool? canDealDamage
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_canDealDamage != null)
                {
                    return Private_canDealDamage.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_canDealDamage != null)
                    {
                        Private_canDealDamage.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_24
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_24 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_24.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_24 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_24.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_14 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_14 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_14.Value = value;
                }
            }
        }

        internal string __0_newName__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newName__param != null)
                {
                    return Private___0_newName__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_newName__param != null)
                {
                    Private___0_newName__param.Value = value;
                }
            }
        }

        internal string __const_SystemString_66
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_66 != null)
                {
                    return Private___const_SystemString_66.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_66 != null)
                {
                    Private___const_SystemString_66.Value = value;
                }
            }
        }

        internal string __const_SystemString_67
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_67 != null)
                {
                    return Private___const_SystemString_67.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_67 != null)
                {
                    Private___const_SystemString_67.Value = value;
                }
            }
        }

        internal string __const_SystemString_64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_64 != null)
                {
                    return Private___const_SystemString_64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_64 != null)
                {
                    Private___const_SystemString_64.Value = value;
                }
            }
        }

        internal string __const_SystemString_65
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_65 != null)
                {
                    return Private___const_SystemString_65.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_65 != null)
                {
                    Private___const_SystemString_65.Value = value;
                }
            }
        }

        internal string __const_SystemString_62
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_62 != null)
                {
                    return Private___const_SystemString_62.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_62 != null)
                {
                    Private___const_SystemString_62.Value = value;
                }
            }
        }

        internal string __const_SystemString_63
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_63 != null)
                {
                    return Private___const_SystemString_63.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_63 != null)
                {
                    Private___const_SystemString_63.Value = value;
                }
            }
        }

        internal string __const_SystemString_60
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_60 != null)
                {
                    return Private___const_SystemString_60.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_60 != null)
                {
                    Private___const_SystemString_60.Value = value;
                }
            }
        }

        internal string __const_SystemString_61
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_61 != null)
                {
                    return Private___const_SystemString_61.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_61 != null)
                {
                    Private___const_SystemString_61.Value = value;
                }
            }
        }

        internal string __const_SystemString_68
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_68 != null)
                {
                    return Private___const_SystemString_68.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_68 != null)
                {
                    Private___const_SystemString_68.Value = value;
                }
            }
        }

        internal string __const_SystemString_69
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_69 != null)
                {
                    return Private___const_SystemString_69.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_69 != null)
                {
                    Private___const_SystemString_69.Value = value;
                }
            }
        }

        internal float? __intnl_SystemSingle_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_2 != null)
                {
                    return Private___intnl_SystemSingle_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_2 != null)
                    {
                        Private___intnl_SystemSingle_2.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_2 != null)
                {
                    return Private___const_SystemString_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_2 != null)
                {
                    Private___const_SystemString_2.Value = value;
                }
            }
        }

        internal bool? __0__InstaHeal__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0__InstaHeal__ret != null)
                {
                    return Private___0__InstaHeal__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0__InstaHeal__ret != null)
                    {
                        Private___0__InstaHeal__ret.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_2 != null)
                {
                    return Private___const_SystemSingle_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_2 != null)
                    {
                        Private___const_SystemSingle_2.Value = value.Value;
                    }
                }
            }
        }

        internal float? lastInstaHealTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lastInstaHealTime != null)
                {
                    return Private_lastInstaHealTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lastInstaHealTime != null)
                    {
                        Private_lastInstaHealTime.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_19 != null)
                {
                    return Private___intnl_SystemBoolean_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_19 != null)
                    {
                        Private___intnl_SystemBoolean_19.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_29
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_29 != null)
                {
                    return Private___intnl_SystemBoolean_29.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_29 != null)
                    {
                        Private___intnl_SystemBoolean_29.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_39
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_39 != null)
                {
                    return Private___intnl_SystemBoolean_39.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_39 != null)
                    {
                        Private___intnl_SystemBoolean_39.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_49
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_49 != null)
                {
                    return Private___intnl_SystemBoolean_49.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_49 != null)
                    {
                        Private___intnl_SystemBoolean_49.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_59
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_59 != null)
                {
                    return Private___intnl_SystemBoolean_59.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_59 != null)
                    {
                        Private___intnl_SystemBoolean_59.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_0 != null)
                {
                    return Private___intnl_UnityEngineVector3_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_0 != null)
                    {
                        Private___intnl_UnityEngineVector3_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineGameObject_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineGameObject_2 != null)
                {
                    return Private___intnl_UnityEngineGameObject_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineGameObject_2 != null)
                {
                    Private___intnl_UnityEngineGameObject_2.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineGameObject_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineGameObject_1 != null)
                {
                    return Private___intnl_UnityEngineGameObject_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineGameObject_1 != null)
                {
                    Private___intnl_UnityEngineGameObject_1.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineGameObject_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineGameObject_0 != null)
                {
                    return Private___intnl_UnityEngineGameObject_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineGameObject_0 != null)
                {
                    Private___intnl_UnityEngineGameObject_0.Value = value;
                }
            }
        }

        internal ushort? cachedArmor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedArmor != null)
                {
                    return Private_cachedArmor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedArmor != null)
                    {
                        Private_cachedArmor.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_14 != null)
                {
                    return Private___intnl_SystemBoolean_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_14 != null)
                    {
                        Private___intnl_SystemBoolean_14.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_24
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_24 != null)
                {
                    return Private___intnl_SystemBoolean_24.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_24 != null)
                    {
                        Private___intnl_SystemBoolean_24.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_34
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_34 != null)
                {
                    return Private___intnl_SystemBoolean_34.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_34 != null)
                    {
                        Private___intnl_SystemBoolean_34.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_44
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_44 != null)
                {
                    return Private___intnl_SystemBoolean_44.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_44 != null)
                    {
                        Private___intnl_SystemBoolean_44.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_54
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_54 != null)
                {
                    return Private___intnl_SystemBoolean_54.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_54 != null)
                    {
                        Private___intnl_SystemBoolean_54.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_13 != null)
                {
                    return Private___const_SystemInt32_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_13 != null)
                    {
                        Private___const_SystemInt32_13.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_33
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_33 != null)
                {
                    return Private___const_SystemInt32_33.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_33 != null)
                    {
                        Private___const_SystemInt32_33.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_23 != null)
                {
                    return Private___const_SystemInt32_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_23 != null)
                    {
                        Private___const_SystemInt32_23.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_43
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_43 != null)
                {
                    return Private___const_SystemInt32_43.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_43 != null)
                    {
                        Private___const_SystemInt32_43.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_14 != null)
                {
                    return Private___intnl_SystemInt32_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_14 != null)
                    {
                        Private___intnl_SystemInt32_14.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_34
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_34 != null)
                {
                    return Private___intnl_SystemInt32_34.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_34 != null)
                    {
                        Private___intnl_SystemInt32_34.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_24
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_24 != null)
                {
                    return Private___intnl_SystemInt32_24.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_24 != null)
                    {
                        Private___intnl_SystemInt32_24.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_guard__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_guard__param != null)
                {
                    return Private___0_guard__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_guard__param != null)
                    {
                        Private___0_guard__param.Value = value.Value;
                    }
                }
            }
        }

        internal bool? damagedInFrame
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_damagedInFrame != null)
                {
                    return Private_damagedInFrame.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_damagedInFrame != null)
                    {
                        Private_damagedInFrame.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_19 != null)
                {
                    return Private___intnl_SystemInt32_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_19 != null)
                    {
                        Private___intnl_SystemInt32_19.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_39
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_39 != null)
                {
                    return Private___intnl_SystemInt32_39.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_39 != null)
                    {
                        Private___intnl_SystemInt32_39.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_29
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_29 != null)
                {
                    return Private___intnl_SystemInt32_29.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_29 != null)
                    {
                        Private___intnl_SystemInt32_29.Value = value.Value;
                    }
                }
            }
        }

        internal string __intnl_SystemString_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemString_0 != null)
                {
                    return Private___intnl_SystemString_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemString_0 != null)
                {
                    Private___intnl_SystemString_0.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_19 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_19 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_19.Value = value;
                }
            }
        }

        internal float? __intnl_SystemSingle_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_1 != null)
                {
                    return Private___intnl_SystemSingle_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_1 != null)
                    {
                        Private___intnl_SystemSingle_1.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __intnl_SystemObject_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_1 != null)
                {
                    return Private___intnl_SystemObject_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_1 != null)
                {
                    Private___intnl_SystemObject_1.Value = value;
                }
            }
        }

        internal string __const_SystemString_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_7 != null)
                {
                    return Private___const_SystemString_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_7 != null)
                {
                    Private___const_SystemString_7.Value = value;
                }
            }
        }

        internal float? __const_SystemSingle_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_1 != null)
                {
                    return Private___const_SystemSingle_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_1 != null)
                    {
                        Private___const_SystemSingle_1.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_51
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_51 != null)
                {
                    return Private___gintnl_SystemUInt32_51.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_51 != null)
                    {
                        Private___gintnl_SystemUInt32_51.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_41
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_41 != null)
                {
                    return Private___gintnl_SystemUInt32_41.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_41 != null)
                    {
                        Private___gintnl_SystemUInt32_41.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_71
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_71 != null)
                {
                    return Private___gintnl_SystemUInt32_71.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_71 != null)
                    {
                        Private___gintnl_SystemUInt32_71.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_61
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_61 != null)
                {
                    return Private___gintnl_SystemUInt32_61.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_61 != null)
                    {
                        Private___gintnl_SystemUInt32_61.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_11 != null)
                {
                    return Private___gintnl_SystemUInt32_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_11 != null)
                    {
                        Private___gintnl_SystemUInt32_11.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_31
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_31 != null)
                {
                    return Private___gintnl_SystemUInt32_31.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_31 != null)
                    {
                        Private___gintnl_SystemUInt32_31.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_21 != null)
                {
                    return Private___gintnl_SystemUInt32_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_21 != null)
                    {
                        Private___gintnl_SystemUInt32_21.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_17 != null)
                {
                    return Private___intnl_SystemBoolean_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_17 != null)
                    {
                        Private___intnl_SystemBoolean_17.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_27
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_27 != null)
                {
                    return Private___intnl_SystemBoolean_27.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_27 != null)
                    {
                        Private___intnl_SystemBoolean_27.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_37
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_37 != null)
                {
                    return Private___intnl_SystemBoolean_37.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_37 != null)
                    {
                        Private___intnl_SystemBoolean_37.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_47
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_47 != null)
                {
                    return Private___intnl_SystemBoolean_47.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_47 != null)
                    {
                        Private___intnl_SystemBoolean_47.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_57
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_57 != null)
                {
                    return Private___intnl_SystemBoolean_57.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_57 != null)
                    {
                        Private___intnl_SystemBoolean_57.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_10 != null)
                {
                    return Private___const_SystemInt32_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_10 != null)
                    {
                        Private___const_SystemInt32_10.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_30
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_30 != null)
                {
                    return Private___const_SystemInt32_30.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_30 != null)
                    {
                        Private___const_SystemInt32_30.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_20 != null)
                {
                    return Private___const_SystemInt32_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_20 != null)
                    {
                        Private___const_SystemInt32_20.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_40
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_40 != null)
                {
                    return Private___const_SystemInt32_40.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_40 != null)
                    {
                        Private___const_SystemInt32_40.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.Common.Enums.EventTiming? __const_VRCUdonCommonEnumsEventTiming_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_VRCUdonCommonEnumsEventTiming_0 != null)
                {
                    return Private___const_VRCUdonCommonEnumsEventTiming_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_VRCUdonCommonEnumsEventTiming_0 != null)
                    {
                        Private___const_VRCUdonCommonEnumsEventTiming_0.Value = value.Value;
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

        internal int? __intnl_SystemInt32_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_11 != null)
                {
                    return Private___intnl_SystemInt32_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_11 != null)
                    {
                        Private___intnl_SystemInt32_11.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_31
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_31 != null)
                {
                    return Private___intnl_SystemInt32_31.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_31 != null)
                    {
                        Private___intnl_SystemInt32_31.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_21 != null)
                {
                    return Private___intnl_SystemInt32_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_21 != null)
                    {
                        Private___intnl_SystemInt32_21.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_41
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_41 != null)
                {
                    return Private___intnl_SystemInt32_41.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_41 != null)
                    {
                        Private___intnl_SystemInt32_41.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_sus__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_sus__param != null)
                {
                    return Private___0_sus__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_sus__param != null)
                    {
                        Private___0_sus__param.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_21 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_21 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_21.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_11 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_11 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_11.Value = value;
                }
            }
        }

        internal string __const_SystemString_36
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_36 != null)
                {
                    return Private___const_SystemString_36.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_36 != null)
                {
                    Private___const_SystemString_36.Value = value;
                }
            }
        }

        internal string __const_SystemString_37
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_37 != null)
                {
                    return Private___const_SystemString_37.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_37 != null)
                {
                    Private___const_SystemString_37.Value = value;
                }
            }
        }

        internal string __const_SystemString_34
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_34 != null)
                {
                    return Private___const_SystemString_34.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_34 != null)
                {
                    Private___const_SystemString_34.Value = value;
                }
            }
        }

        internal string __const_SystemString_35
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_35 != null)
                {
                    return Private___const_SystemString_35.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_35 != null)
                {
                    Private___const_SystemString_35.Value = value;
                }
            }
        }

        internal string __const_SystemString_32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_32 != null)
                {
                    return Private___const_SystemString_32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_32 != null)
                {
                    Private___const_SystemString_32.Value = value;
                }
            }
        }

        internal string __const_SystemString_33
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_33 != null)
                {
                    return Private___const_SystemString_33.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_33 != null)
                {
                    Private___const_SystemString_33.Value = value;
                }
            }
        }

        internal string __const_SystemString_30
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_30 != null)
                {
                    return Private___const_SystemString_30.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_30 != null)
                {
                    Private___const_SystemString_30.Value = value;
                }
            }
        }

        internal string __const_SystemString_31
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_31 != null)
                {
                    return Private___const_SystemString_31.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_31 != null)
                {
                    Private___const_SystemString_31.Value = value;
                }
            }
        }

        internal string __const_SystemString_38
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_38 != null)
                {
                    return Private___const_SystemString_38.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_38 != null)
                {
                    Private___const_SystemString_38.Value = value;
                }
            }
        }

        internal string __const_SystemString_39
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_39 != null)
                {
                    return Private___const_SystemString_39.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_39 != null)
                {
                    Private___const_SystemString_39.Value = value;
                }
            }
        }

        internal float? __intnl_SystemSingle_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_9 != null)
                {
                    return Private___intnl_SystemSingle_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_9 != null)
                    {
                        Private___intnl_SystemSingle_9.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineObject_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_16 != null)
                {
                    return Private___intnl_UnityEngineObject_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_16 != null)
                {
                    Private___intnl_UnityEngineObject_16.Value = value;
                }
            }
        }

        internal int? maxArmor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_maxArmor != null)
                {
                    return Private_maxArmor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_maxArmor != null)
                    {
                        Private_maxArmor.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? armor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_armor != null)
                {
                    return Private_armor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_armor != null)
                    {
                        Private_armor.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_hp__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_hp__param != null)
                {
                    return Private___1_hp__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_hp__param != null)
                    {
                        Private___1_hp__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_returnJump_SystemUInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_returnJump_SystemUInt32_0 != null)
                {
                    return Private___intnl_returnJump_SystemUInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_returnJump_SystemUInt32_0 != null)
                    {
                        Private___intnl_returnJump_SystemUInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_hp__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_hp__param != null)
                {
                    return Private___0_hp__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_hp__param != null)
                    {
                        Private___0_hp__param.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_4 != null)
                {
                    return Private___const_SystemString_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_4 != null)
                {
                    Private___const_SystemString_4.Value = value;
                }
            }
        }

        internal float? instaHealDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_instaHealDelay != null)
                {
                    return Private_instaHealDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_instaHealDelay != null)
                    {
                        Private_instaHealDelay.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_59
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_59 != null)
                {
                    return Private___gintnl_SystemUInt32_59.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_59 != null)
                    {
                        Private___gintnl_SystemUInt32_59.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_49
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_49 != null)
                {
                    return Private___gintnl_SystemUInt32_49.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_49 != null)
                    {
                        Private___gintnl_SystemUInt32_49.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_69
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_69 != null)
                {
                    return Private___gintnl_SystemUInt32_69.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_69 != null)
                    {
                        Private___gintnl_SystemUInt32_69.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_19 != null)
                {
                    return Private___gintnl_SystemUInt32_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_19 != null)
                    {
                        Private___gintnl_SystemUInt32_19.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_39
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_39 != null)
                {
                    return Private___gintnl_SystemUInt32_39.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_39 != null)
                    {
                        Private___gintnl_SystemUInt32_39.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_29
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_29 != null)
                {
                    return Private___gintnl_SystemUInt32_29.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_29 != null)
                    {
                        Private___gintnl_SystemUInt32_29.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_4 != null)
                {
                    return Private___const_SystemSingle_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_4 != null)
                    {
                        Private___const_SystemSingle_4.Value = value.Value;
                    }
                }
            }
        }

        internal int? __2_hp__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_hp__param != null)
                {
                    return Private___2_hp__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_hp__param != null)
                    {
                        Private___2_hp__param.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_18 != null)
                {
                    return Private___const_SystemInt32_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_18 != null)
                    {
                        Private___const_SystemInt32_18.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_38
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_38 != null)
                {
                    return Private___const_SystemInt32_38.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_38 != null)
                    {
                        Private___const_SystemInt32_38.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_28
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_28 != null)
                {
                    return Private___const_SystemInt32_28.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_28 != null)
                    {
                        Private___const_SystemInt32_28.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_52
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_52 != null)
                {
                    return Private___gintnl_SystemUInt32_52.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_52 != null)
                    {
                        Private___gintnl_SystemUInt32_52.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_42
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_42 != null)
                {
                    return Private___gintnl_SystemUInt32_42.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_42 != null)
                    {
                        Private___gintnl_SystemUInt32_42.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_72
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_72 != null)
                {
                    return Private___gintnl_SystemUInt32_72.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_72 != null)
                    {
                        Private___gintnl_SystemUInt32_72.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_62
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_62 != null)
                {
                    return Private___gintnl_SystemUInt32_62.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_62 != null)
                    {
                        Private___gintnl_SystemUInt32_62.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_12 != null)
                {
                    return Private___gintnl_SystemUInt32_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_12 != null)
                    {
                        Private___gintnl_SystemUInt32_12.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_32 != null)
                {
                    return Private___gintnl_SystemUInt32_32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_32 != null)
                    {
                        Private___gintnl_SystemUInt32_32.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_22 != null)
                {
                    return Private___gintnl_SystemUInt32_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_22 != null)
                    {
                        Private___gintnl_SystemUInt32_22.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_63
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_63 != null)
                {
                    return Private___intnl_SystemObject_63.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_63 != null)
                {
                    Private___intnl_SystemObject_63.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_62
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_62 != null)
                {
                    return Private___intnl_SystemObject_62.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_62 != null)
                {
                    Private___intnl_SystemObject_62.Value = value;
                }
            }
        }

        internal int? __const_SystemInt32_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_15 != null)
                {
                    return Private___const_SystemInt32_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_15 != null)
                    {
                        Private___const_SystemInt32_15.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_35
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_35 != null)
                {
                    return Private___const_SystemInt32_35.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_35 != null)
                    {
                        Private___const_SystemInt32_35.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_25 != null)
                {
                    return Private___const_SystemInt32_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_25 != null)
                    {
                        Private___const_SystemInt32_25.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_45
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_45 != null)
                {
                    return Private___const_SystemInt32_45.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_45 != null)
                    {
                        Private___const_SystemInt32_45.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_tagHeight_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_tagHeight_SystemSingle_0 != null)
                {
                    return Private___lcl_tagHeight_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_tagHeight_SystemSingle_0 != null)
                    {
                        Private___lcl_tagHeight_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_26
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_26 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_26.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_26 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_26.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_16 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_16 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_16.Value = value;
                }
            }
        }

        internal float? __intnl_SystemSingle_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_4 != null)
                {
                    return Private___intnl_SystemSingle_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_4 != null)
                    {
                        Private___intnl_SystemSingle_4.Value = value.Value;
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

        internal ushort? cachedHealth
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

        internal string __const_SystemString_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_9 != null)
                {
                    return Private___const_SystemString_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_9 != null)
                {
                    Private___const_SystemString_9.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_2 != null)
                {
                    return Private___intnl_UnityEngineVector3_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_2 != null)
                    {
                        Private___intnl_UnityEngineVector3_2.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_12 != null)
                {
                    return Private___intnl_SystemBoolean_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_12 != null)
                    {
                        Private___intnl_SystemBoolean_12.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_22 != null)
                {
                    return Private___intnl_SystemBoolean_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_22 != null)
                    {
                        Private___intnl_SystemBoolean_22.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_32 != null)
                {
                    return Private___intnl_SystemBoolean_32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_32 != null)
                    {
                        Private___intnl_SystemBoolean_32.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_42
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_42 != null)
                {
                    return Private___intnl_SystemBoolean_42.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_42 != null)
                    {
                        Private___intnl_SystemBoolean_42.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_52
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_52 != null)
                {
                    return Private___intnl_SystemBoolean_52.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_52 != null)
                    {
                        Private___intnl_SystemBoolean_52.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_57
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_57 != null)
                {
                    return Private___gintnl_SystemUInt32_57.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_57 != null)
                    {
                        Private___gintnl_SystemUInt32_57.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_47
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_47 != null)
                {
                    return Private___gintnl_SystemUInt32_47.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_47 != null)
                    {
                        Private___gintnl_SystemUInt32_47.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_77
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_77 != null)
                {
                    return Private___gintnl_SystemUInt32_77.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_77 != null)
                    {
                        Private___gintnl_SystemUInt32_77.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_67
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_67 != null)
                {
                    return Private___gintnl_SystemUInt32_67.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_67 != null)
                    {
                        Private___gintnl_SystemUInt32_67.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_17 != null)
                {
                    return Private___gintnl_SystemUInt32_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_17 != null)
                    {
                        Private___gintnl_SystemUInt32_17.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_37
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_37 != null)
                {
                    return Private___gintnl_SystemUInt32_37.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_37 != null)
                    {
                        Private___gintnl_SystemUInt32_37.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_27
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_27 != null)
                {
                    return Private___gintnl_SystemUInt32_27.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_27 != null)
                    {
                        Private___gintnl_SystemUInt32_27.Value = value.Value;
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

        internal int? __intnl_SystemInt32_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_16 != null)
                {
                    return Private___intnl_SystemInt32_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_16 != null)
                    {
                        Private___intnl_SystemInt32_16.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_36
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_36 != null)
                {
                    return Private___intnl_SystemInt32_36.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_36 != null)
                    {
                        Private___intnl_SystemInt32_36.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_26
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_26 != null)
                {
                    return Private___intnl_SystemInt32_26.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_26 != null)
                    {
                        Private___intnl_SystemInt32_26.Value = value.Value;
                    }
                }
            }
        }

        internal string __refl_typename
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___refl_typename != null)
                {
                    return Private___refl_typename.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___refl_typename != null)
                {
                    Private___refl_typename.Value = value;
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

        internal UnityEngine.Camera photoCamera
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_photoCamera != null)
                {
                    return Private_photoCamera.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_photoCamera != null)
                {
                    Private_photoCamera.Value = value;
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

        internal int? __intnl_SystemInt32_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_1 != null)
                {
                    return Private___intnl_SystemInt32_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_1 != null)
                    {
                        Private___intnl_SystemInt32_1.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_0 != null)
                {
                    return Private___intnl_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_0 != null)
                    {
                        Private___intnl_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_3 != null)
                {
                    return Private___intnl_SystemInt32_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_3 != null)
                    {
                        Private___intnl_SystemInt32_3.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_2 != null)
                {
                    return Private___intnl_SystemInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_2 != null)
                    {
                        Private___intnl_SystemInt32_2.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_5 != null)
                {
                    return Private___intnl_SystemInt32_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_5 != null)
                    {
                        Private___intnl_SystemInt32_5.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_4 != null)
                {
                    return Private___intnl_SystemInt32_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_4 != null)
                    {
                        Private___intnl_SystemInt32_4.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_7 != null)
                {
                    return Private___intnl_SystemInt32_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_7 != null)
                    {
                        Private___intnl_SystemInt32_7.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_6 != null)
                {
                    return Private___intnl_SystemInt32_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_6 != null)
                    {
                        Private___intnl_SystemInt32_6.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_9 != null)
                {
                    return Private___intnl_SystemInt32_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_9 != null)
                    {
                        Private___intnl_SystemInt32_9.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_8 != null)
                {
                    return Private___intnl_SystemInt32_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_8 != null)
                    {
                        Private___intnl_SystemInt32_8.Value = value.Value;
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

        internal string __const_SystemString_56
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_56 != null)
                {
                    return Private___const_SystemString_56.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_56 != null)
                {
                    Private___const_SystemString_56.Value = value;
                }
            }
        }

        internal string __const_SystemString_57
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_57 != null)
                {
                    return Private___const_SystemString_57.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_57 != null)
                {
                    Private___const_SystemString_57.Value = value;
                }
            }
        }

        internal string __const_SystemString_54
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_54 != null)
                {
                    return Private___const_SystemString_54.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_54 != null)
                {
                    Private___const_SystemString_54.Value = value;
                }
            }
        }

        internal string __const_SystemString_55
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_55 != null)
                {
                    return Private___const_SystemString_55.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_55 != null)
                {
                    Private___const_SystemString_55.Value = value;
                }
            }
        }

        internal string __const_SystemString_52
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_52 != null)
                {
                    return Private___const_SystemString_52.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_52 != null)
                {
                    Private___const_SystemString_52.Value = value;
                }
            }
        }

        internal string __const_SystemString_53
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_53 != null)
                {
                    return Private___const_SystemString_53.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_53 != null)
                {
                    Private___const_SystemString_53.Value = value;
                }
            }
        }

        internal string __const_SystemString_50
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_50 != null)
                {
                    return Private___const_SystemString_50.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_50 != null)
                {
                    Private___const_SystemString_50.Value = value;
                }
            }
        }

        internal string __const_SystemString_51
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_51 != null)
                {
                    return Private___const_SystemString_51.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_51 != null)
                {
                    Private___const_SystemString_51.Value = value;
                }
            }
        }

        internal string __const_SystemString_58
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_58 != null)
                {
                    return Private___const_SystemString_58.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_58 != null)
                {
                    Private___const_SystemString_58.Value = value;
                }
            }
        }

        internal string __const_SystemString_59
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_59 != null)
                {
                    return Private___const_SystemString_59.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_59 != null)
                {
                    Private___const_SystemString_59.Value = value;
                }
            }
        }

        internal bool? __0_t__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t__param != null)
                {
                    return Private___0_t__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t__param != null)
                    {
                        Private___0_t__param.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_3 != null)
                {
                    return Private___intnl_SystemSingle_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_3 != null)
                    {
                        Private___intnl_SystemSingle_3.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? __intnl_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt16_0 != null)
                {
                    return Private___intnl_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt16_0 != null)
                    {
                        Private___intnl_SystemUInt16_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isSuspicious
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isSuspicious != null)
                {
                    return Private_isSuspicious.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isSuspicious != null)
                    {
                        Private_isSuspicious.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_1 != null)
                {
                    return Private___const_SystemString_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_1 != null)
                {
                    Private___const_SystemString_1.Value = value;
                }
            }
        }

        internal float? __const_SystemSingle_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_3 != null)
                {
                    return Private___const_SystemSingle_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_3 != null)
                    {
                        Private___const_SystemSingle_3.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_1 != null)
                {
                    return Private___intnl_UnityEngineVector3_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_1 != null)
                    {
                        Private___intnl_UnityEngineVector3_1.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_15 != null)
                {
                    return Private___intnl_SystemBoolean_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_15 != null)
                    {
                        Private___intnl_SystemBoolean_15.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_25 != null)
                {
                    return Private___intnl_SystemBoolean_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_25 != null)
                    {
                        Private___intnl_SystemBoolean_25.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_35
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_35 != null)
                {
                    return Private___intnl_SystemBoolean_35.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_35 != null)
                    {
                        Private___intnl_SystemBoolean_35.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_45
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_45 != null)
                {
                    return Private___intnl_SystemBoolean_45.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_45 != null)
                    {
                        Private___intnl_SystemBoolean_45.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_55
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_55 != null)
                {
                    return Private___intnl_SystemBoolean_55.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_55 != null)
                    {
                        Private___intnl_SystemBoolean_55.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_12 != null)
                {
                    return Private___const_SystemInt32_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_12 != null)
                    {
                        Private___const_SystemInt32_12.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_32 != null)
                {
                    return Private___const_SystemInt32_32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_32 != null)
                    {
                        Private___const_SystemInt32_32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_22 != null)
                {
                    return Private___const_SystemInt32_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_22 != null)
                    {
                        Private___const_SystemInt32_22.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_42
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_42 != null)
                {
                    return Private___const_SystemInt32_42.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_42 != null)
                    {
                        Private___const_SystemInt32_42.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_13 != null)
                {
                    return Private___intnl_SystemInt32_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_13 != null)
                    {
                        Private___intnl_SystemInt32_13.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_33
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_33 != null)
                {
                    return Private___intnl_SystemInt32_33.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_33 != null)
                    {
                        Private___intnl_SystemInt32_33.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_23 != null)
                {
                    return Private___intnl_SystemInt32_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_23 != null)
                    {
                        Private___intnl_SystemInt32_23.Value = value.Value;
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

        internal int? __intnl_SystemInt32_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_18 != null)
                {
                    return Private___intnl_SystemInt32_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_18 != null)
                    {
                        Private___intnl_SystemInt32_18.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_38
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_38 != null)
                {
                    return Private___intnl_SystemInt32_38.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_38 != null)
                    {
                        Private___intnl_SystemInt32_38.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_28
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_28 != null)
                {
                    return Private___intnl_SystemInt32_28.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_28 != null)
                    {
                        Private___intnl_SystemInt32_28.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_23 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_23 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_23.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_13 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_13 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_13.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_18 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_18 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_18.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_53
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_53 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_53.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_53 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_53.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_55
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_55 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_55.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_55 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_55.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_56
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_56 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_56.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_56 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_56.Value = value;
                }
            }
        }

        internal string __const_SystemString_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_6 != null)
                {
                    return Private___const_SystemString_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_6 != null)
                {
                    Private___const_SystemString_6.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_4 != null)
                {
                    return Private___intnl_UnityEngineVector3_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_4 != null)
                    {
                        Private___intnl_UnityEngineVector3_4.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_50
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_50 != null)
                {
                    return Private___gintnl_SystemUInt32_50.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_50 != null)
                    {
                        Private___gintnl_SystemUInt32_50.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_40
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_40 != null)
                {
                    return Private___gintnl_SystemUInt32_40.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_40 != null)
                    {
                        Private___gintnl_SystemUInt32_40.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_70
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_70 != null)
                {
                    return Private___gintnl_SystemUInt32_70.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_70 != null)
                    {
                        Private___gintnl_SystemUInt32_70.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_60
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_60 != null)
                {
                    return Private___gintnl_SystemUInt32_60.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_60 != null)
                    {
                        Private___gintnl_SystemUInt32_60.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_10 != null)
                {
                    return Private___gintnl_SystemUInt32_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_10 != null)
                    {
                        Private___gintnl_SystemUInt32_10.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_30
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_30 != null)
                {
                    return Private___gintnl_SystemUInt32_30.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_30 != null)
                    {
                        Private___gintnl_SystemUInt32_30.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_20 != null)
                {
                    return Private___gintnl_SystemUInt32_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_20 != null)
                    {
                        Private___gintnl_SystemUInt32_20.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_17 != null)
                {
                    return Private___const_SystemInt32_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_17 != null)
                    {
                        Private___const_SystemInt32_17.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_37
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_37 != null)
                {
                    return Private___const_SystemInt32_37.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_37 != null)
                    {
                        Private___const_SystemInt32_37.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_27
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_27 != null)
                {
                    return Private___const_SystemInt32_27.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_27 != null)
                    {
                        Private___const_SystemInt32_27.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_47
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_47 != null)
                {
                    return Private___const_SystemInt32_47.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_47 != null)
                    {
                        Private___const_SystemInt32_47.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_10 != null)
                {
                    return Private___intnl_SystemInt32_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_10 != null)
                    {
                        Private___intnl_SystemInt32_10.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_30
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_30 != null)
                {
                    return Private___intnl_SystemInt32_30.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_30 != null)
                    {
                        Private___intnl_SystemInt32_30.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_20 != null)
                {
                    return Private___intnl_SystemInt32_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_20 != null)
                    {
                        Private___intnl_SystemInt32_20.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_40
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_40 != null)
                {
                    return Private___intnl_SystemInt32_40.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_40 != null)
                    {
                        Private___intnl_SystemInt32_40.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_damage__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_damage__param != null)
                {
                    return Private___1_damage__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_damage__param != null)
                    {
                        Private___1_damage__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __this_UnityEngineGameObject_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_UnityEngineGameObject_0 != null)
                {
                    return Private___this_UnityEngineGameObject_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_UnityEngineGameObject_0 != null)
                {
                    Private___this_UnityEngineGameObject_0.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_20 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_20 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_20.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_10 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_10 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_10.Value = value;
                }
            }
        }

        internal string __const_SystemString_26
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_26 != null)
                {
                    return Private___const_SystemString_26.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_26 != null)
                {
                    Private___const_SystemString_26.Value = value;
                }
            }
        }

        internal string __const_SystemString_27
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_27 != null)
                {
                    return Private___const_SystemString_27.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_27 != null)
                {
                    Private___const_SystemString_27.Value = value;
                }
            }
        }

        internal string __const_SystemString_24
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_24 != null)
                {
                    return Private___const_SystemString_24.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_24 != null)
                {
                    Private___const_SystemString_24.Value = value;
                }
            }
        }

        internal string __const_SystemString_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_25 != null)
                {
                    return Private___const_SystemString_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_25 != null)
                {
                    Private___const_SystemString_25.Value = value;
                }
            }
        }

        internal string __const_SystemString_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_22 != null)
                {
                    return Private___const_SystemString_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_22 != null)
                {
                    Private___const_SystemString_22.Value = value;
                }
            }
        }

        internal string __const_SystemString_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_23 != null)
                {
                    return Private___const_SystemString_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_23 != null)
                {
                    Private___const_SystemString_23.Value = value;
                }
            }
        }

        internal string __const_SystemString_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_20 != null)
                {
                    return Private___const_SystemString_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_20 != null)
                {
                    Private___const_SystemString_20.Value = value;
                }
            }
        }

        internal string __const_SystemString_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_21 != null)
                {
                    return Private___const_SystemString_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_21 != null)
                {
                    Private___const_SystemString_21.Value = value;
                }
            }
        }

        internal string __const_SystemString_28
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_28 != null)
                {
                    return Private___const_SystemString_28.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_28 != null)
                {
                    Private___const_SystemString_28.Value = value;
                }
            }
        }

        internal string __const_SystemString_29
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_29 != null)
                {
                    return Private___const_SystemString_29.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_29 != null)
                {
                    Private___const_SystemString_29.Value = value;
                }
            }
        }

        internal float? __intnl_SystemSingle_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_6 != null)
                {
                    return Private___intnl_SystemSingle_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_6 != null)
                    {
                        Private___intnl_SystemSingle_6.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineObject_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_17 != null)
                {
                    return Private___intnl_UnityEngineObject_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_17 != null)
                {
                    Private___intnl_UnityEngineObject_17.Value = value;
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

        internal bool? __0_playing__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_playing__param != null)
                {
                    return Private___0_playing__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_playing__param != null)
                    {
                        Private___0_playing__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform hitboxRoot
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hitboxRoot != null)
                {
                    return Private_hitboxRoot.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_hitboxRoot != null)
                {
                    Private_hitboxRoot.Value = value;
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

        internal uint? __gintnl_SystemUInt32_58
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_58 != null)
                {
                    return Private___gintnl_SystemUInt32_58.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_58 != null)
                    {
                        Private___gintnl_SystemUInt32_58.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_48
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_48 != null)
                {
                    return Private___gintnl_SystemUInt32_48.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_48 != null)
                    {
                        Private___gintnl_SystemUInt32_48.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_78
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_78 != null)
                {
                    return Private___gintnl_SystemUInt32_78.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_78 != null)
                    {
                        Private___gintnl_SystemUInt32_78.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_68
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_68 != null)
                {
                    return Private___gintnl_SystemUInt32_68.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_68 != null)
                    {
                        Private___gintnl_SystemUInt32_68.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_18 != null)
                {
                    return Private___gintnl_SystemUInt32_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_18 != null)
                    {
                        Private___gintnl_SystemUInt32_18.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_38
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_38 != null)
                {
                    return Private___gintnl_SystemUInt32_38.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_38 != null)
                    {
                        Private___gintnl_SystemUInt32_38.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_28
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_28 != null)
                {
                    return Private___gintnl_SystemUInt32_28.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_28 != null)
                    {
                        Private___gintnl_SystemUInt32_28.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject teamTagObj
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamTagObj != null)
                {
                    return Private_teamTagObj.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_teamTagObj != null)
                {
                    Private_teamTagObj.Value = value;
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

        internal bool? __intnl_SystemBoolean_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_10 != null)
                {
                    return Private___intnl_SystemBoolean_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_10 != null)
                    {
                        Private___intnl_SystemBoolean_10.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_20 != null)
                {
                    return Private___intnl_SystemBoolean_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_20 != null)
                    {
                        Private___intnl_SystemBoolean_20.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_30
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_30 != null)
                {
                    return Private___intnl_SystemBoolean_30.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_30 != null)
                    {
                        Private___intnl_SystemBoolean_30.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_40
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_40 != null)
                {
                    return Private___intnl_SystemBoolean_40.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_40 != null)
                    {
                        Private___intnl_SystemBoolean_40.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_50
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_50 != null)
                {
                    return Private___intnl_SystemBoolean_50.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_50 != null)
                    {
                        Private___intnl_SystemBoolean_50.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_60
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_60 != null)
                {
                    return Private___intnl_SystemBoolean_60.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_60 != null)
                    {
                        Private___intnl_SystemBoolean_60.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_55
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_55 != null)
                {
                    return Private___gintnl_SystemUInt32_55.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_55 != null)
                    {
                        Private___gintnl_SystemUInt32_55.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_45
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_45 != null)
                {
                    return Private___gintnl_SystemUInt32_45.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_45 != null)
                    {
                        Private___gintnl_SystemUInt32_45.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_75
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_75 != null)
                {
                    return Private___gintnl_SystemUInt32_75.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_75 != null)
                    {
                        Private___gintnl_SystemUInt32_75.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_65
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_65 != null)
                {
                    return Private___gintnl_SystemUInt32_65.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_65 != null)
                    {
                        Private___gintnl_SystemUInt32_65.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_15 != null)
                {
                    return Private___gintnl_SystemUInt32_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_15 != null)
                    {
                        Private___gintnl_SystemUInt32_15.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_35
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_35 != null)
                {
                    return Private___gintnl_SystemUInt32_35.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_35 != null)
                    {
                        Private___gintnl_SystemUInt32_35.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_25 != null)
                {
                    return Private___gintnl_SystemUInt32_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_25 != null)
                    {
                        Private___gintnl_SystemUInt32_25.Value = value.Value;
                    }
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

        internal bool? permaSuspicious
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_permaSuspicious != null)
                {
                    return Private_permaSuspicious.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_permaSuspicious != null)
                    {
                        Private_permaSuspicious.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_9 != null)
                {
                    return Private___const_SystemInt32_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_9 != null)
                    {
                        Private___const_SystemInt32_9.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_8 != null)
                {
                    return Private___const_SystemInt32_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_8 != null)
                    {
                        Private___const_SystemInt32_8.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_1 != null)
                {
                    return Private___const_SystemInt32_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_1 != null)
                    {
                        Private___const_SystemInt32_1.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_0 != null)
                {
                    return Private___const_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_0 != null)
                    {
                        Private___const_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_3 != null)
                {
                    return Private___const_SystemInt32_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_3 != null)
                    {
                        Private___const_SystemInt32_3.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_2 != null)
                {
                    return Private___const_SystemInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_2 != null)
                    {
                        Private___const_SystemInt32_2.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_5 != null)
                {
                    return Private___const_SystemInt32_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_5 != null)
                    {
                        Private___const_SystemInt32_5.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_4 != null)
                {
                    return Private___const_SystemInt32_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_4 != null)
                    {
                        Private___const_SystemInt32_4.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_7 != null)
                {
                    return Private___const_SystemInt32_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_7 != null)
                    {
                        Private___const_SystemInt32_7.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_6 != null)
                {
                    return Private___const_SystemInt32_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_6 != null)
                    {
                        Private___const_SystemInt32_6.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_14 != null)
                {
                    return Private___const_SystemInt32_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_14 != null)
                    {
                        Private___const_SystemInt32_14.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_34
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_34 != null)
                {
                    return Private___const_SystemInt32_34.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_34 != null)
                    {
                        Private___const_SystemInt32_34.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_24
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_24 != null)
                {
                    return Private___const_SystemInt32_24.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_24 != null)
                    {
                        Private___const_SystemInt32_24.Value = value.Value;
                    }
                }
            }
        }

        internal int? __const_SystemInt32_44
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt32_44 != null)
                {
                    return Private___const_SystemInt32_44.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt32_44 != null)
                    {
                        Private___const_SystemInt32_44.Value = value.Value;
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

        internal ushort? __lcl_startArmor_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_startArmor_SystemUInt16_0 != null)
                {
                    return Private___lcl_startArmor_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_startArmor_SystemUInt16_0 != null)
                    {
                        Private___lcl_startArmor_SystemUInt16_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_8 != null)
                {
                    return Private___intnl_SystemBoolean_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_8 != null)
                    {
                        Private___intnl_SystemBoolean_8.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_9 != null)
                {
                    return Private___intnl_SystemBoolean_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_9 != null)
                    {
                        Private___intnl_SystemBoolean_9.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_0 != null)
                {
                    return Private___intnl_SystemBoolean_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_0 != null)
                    {
                        Private___intnl_SystemBoolean_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_1 != null)
                {
                    return Private___intnl_SystemBoolean_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_1 != null)
                    {
                        Private___intnl_SystemBoolean_1.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_2 != null)
                {
                    return Private___intnl_SystemBoolean_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_2 != null)
                    {
                        Private___intnl_SystemBoolean_2.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_3 != null)
                {
                    return Private___intnl_SystemBoolean_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_3 != null)
                    {
                        Private___intnl_SystemBoolean_3.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_4 != null)
                {
                    return Private___intnl_SystemBoolean_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_4 != null)
                    {
                        Private___intnl_SystemBoolean_4.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_5 != null)
                {
                    return Private___intnl_SystemBoolean_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_5 != null)
                    {
                        Private___intnl_SystemBoolean_5.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_6 != null)
                {
                    return Private___intnl_SystemBoolean_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_6 != null)
                    {
                        Private___intnl_SystemBoolean_6.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_7 != null)
                {
                    return Private___intnl_SystemBoolean_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_7 != null)
                    {
                        Private___intnl_SystemBoolean_7.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_25 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_25 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_25.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_15 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_15 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_15.Value = value;
                }
            }
        }

        internal bool? __0_wanted__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_wanted__param != null)
                {
                    return Private___0_wanted__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_wanted__param != null)
                    {
                        Private___0_wanted__param.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_72
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_72 != null)
                {
                    return Private___const_SystemString_72.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_72 != null)
                {
                    Private___const_SystemString_72.Value = value;
                }
            }
        }

        internal string __const_SystemString_70
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_70 != null)
                {
                    return Private___const_SystemString_70.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_70 != null)
                {
                    Private___const_SystemString_70.Value = value;
                }
            }
        }

        internal string __const_SystemString_71
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_71 != null)
                {
                    return Private___const_SystemString_71.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_71 != null)
                {
                    Private___const_SystemString_71.Value = value;
                }
            }
        }

        internal float? __intnl_SystemSingle_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_5 != null)
                {
                    return Private___intnl_SystemSingle_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_5 != null)
                    {
                        Private___intnl_SystemSingle_5.Value = value.Value;
                    }
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

        internal string __const_SystemString_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_3 != null)
                {
                    return Private___const_SystemString_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_3 != null)
                {
                    Private___const_SystemString_3.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_9 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_9 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_9.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_8 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_8 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_8.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_3 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_3 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_3.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_2 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_2 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_2.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_1 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_1 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_1.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_0 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_0 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_0.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_7 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_7 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_7.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_6 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_6 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_6.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_5 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_5 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_5.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_4 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_4 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_4.Value = value;
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

        internal string __const_SystemString_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_8 != null)
                {
                    return Private___const_SystemString_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_8 != null)
                {
                    Private___const_SystemString_8.Value = value;
                }
            }
        }

        internal bool? __intnl_SystemBoolean_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_18 != null)
                {
                    return Private___intnl_SystemBoolean_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_18 != null)
                    {
                        Private___intnl_SystemBoolean_18.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_28
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_28 != null)
                {
                    return Private___intnl_SystemBoolean_28.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_28 != null)
                    {
                        Private___intnl_SystemBoolean_28.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_38
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_38 != null)
                {
                    return Private___intnl_SystemBoolean_38.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_38 != null)
                    {
                        Private___intnl_SystemBoolean_38.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_48
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_48 != null)
                {
                    return Private___intnl_SystemBoolean_48.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_48 != null)
                    {
                        Private___intnl_SystemBoolean_48.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_58
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_58 != null)
                {
                    return Private___intnl_SystemBoolean_58.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_58 != null)
                    {
                        Private___intnl_SystemBoolean_58.Value = value.Value;
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

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_3 != null)
                {
                    return Private___intnl_UnityEngineVector3_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_3 != null)
                    {
                        Private___intnl_UnityEngineVector3_3.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of PlayerData

        #region AstroUdonVariables  of PlayerData

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private_cachedTimesWanted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isWanted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_76 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_66 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___lcl_wasActive_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedIsSuspicious { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private_timesWanted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___const_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_taken { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_doublePoints { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_tagHeightScalar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___const_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___const_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private___const_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_hitbox { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_count__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_damage__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_maxHealth { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedIsWanted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_73 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_63 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_hitboxHead { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget> Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_goldGuns { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_enabled__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_get_IsInnocent__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_dead__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_61 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_74 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___const_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private_health { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_healthRegenDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_canDealDamage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_newName__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_66 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_67 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_65 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_62 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_63 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_61 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_68 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_69 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0__InstaHeal__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___const_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_lastInstaHealTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineGameObject_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineGameObject_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private_cachedArmor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_guard__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_damagedInFrame { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_SystemObject_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___const_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_71 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_61 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedIsDead { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___const_VRCUdonCommonEnumsEventTiming_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isGuard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_sus__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineObject_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_maxArmor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private_armor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_hp__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_hp__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_instaHealDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_69 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___const_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_hp__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_72 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_62 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_63 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_62 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___lcl_tagHeight_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_scorecard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private_cachedHealth { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_77 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_67 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Camera> Private_spectateCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_lastDamageTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Camera> Private_photoCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_killedByLocal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isPlaying { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_t__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private___intnl_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isSuspicious { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___const_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedIsPlaying { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedHasKeycard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_70 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_damage__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___this_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineObject_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_healthRegenAmt { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_playing__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_hitboxRoot { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_joinedRound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_tagHeightMin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_78 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_68 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_teamTagObj { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_isDead { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_75 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_65 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_permaSuspicious { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private_deathLoc { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<ushort> Private___lcl_startArmor_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_wanted__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_72 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_70 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_71 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___intnl_SystemSingle_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_playerName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_teamTag { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_hasKeycard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of PlayerData

        private static RawUdonBehaviour PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
       
    }
}