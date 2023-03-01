using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using System;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PoolParlor
{
    [RegisterComponent]
    public class PoolParlor_NetworkingManagerReader_Two : MonoBehaviour
    {
        //Behaviour NetworkingManager EventKeys
        //Event Key : __0__Init
        //Event Key : __0__OnPlayerSlotChanged
        //Event Key : _Tick
        //Event Key : __0__OnGameWin
        //Event Key : __0__OnPreviewWinner
        //Event Key : _OnGameReset
        //Event Key : __0__OnSimulationEnded
        //Event Key : __0__OnTurnPass
        //Event Key : __0__OnTurnFoul
        //Event Key : _OnTurnContinue
        //Event Key : __0__OnTableClosed
        //Event Key : __0__OnHitBall
        //Event Key : __0__OnRepositionBalls
        //Event Key : _OnLobbyOpened
        //Event Key : _OnLobbyClosed
        //Event Key : __0__OnGameStart
        //Event Key : __0__OnJoinTeam
        //Event Key : __0__OnLeaveLobby
        //Event Key : __0__OnKickLobby
        //Event Key : __0__OnTeamsChanged
        //Event Key : __0__OnNoGuidelineChanged
        //Event Key : __0__OnNoLockingChanged
        //Event Key : __0__OnTimerChanged
        //Event Key : __0__OnGameModeChanged
        //Event Key : __0__ForceLoadFromState
        //Event Key : __0__OnGlobalSettingsChanged
        //Event Key : _FlushBuffer
        //Event Key : _OnPlayerPrepareShoot
        //Event Key : OnPlayerPrepareShoot
        //Event Key : __0__OnLoadGameState
        //Event Key : _EncodeGameState
        //
        //

        private List<Object> AntiGarbageCollection = new();

        public PoolParlor_NetworkingManagerReader_Two(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal bool ForceGuidelineOn { get; set; } = false;

        internal void Start()
        {
            Initialize();
        }

        internal void Initialize()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PoolParlor))
            {
                var one = gameObject.FindUdonEvent("_OnPlayerPrepareShoot");
                if (one != null)
                {
                    if (NetworkingManager == null)
                    {
                        NetworkingManager = one.UdonBehaviour.ToRawUdonBehaviour();
                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        Initialize_NetworkingManager();
                    }
                }
                else
                {
                    Log.Error("Can't Find Networking Manager 2 behaviour, Unable to Add Reader Component, did the author update the world?");
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
            ClientEventActions.OnRoomLeft -= OnRoomLeft;
            Cleanup_NetworkingManager();
        }

        private RawUdonBehaviour NetworkingManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_NetworkingManager()
        {
            Private___intnl_SystemUInt32_9 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_9");
            Private___0_newTableModel__param = new AstroUdonVariable<byte>(NetworkingManager, "__0_newTableModel__param");
            Private___intnl_SystemBoolean_13 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_13");
            Private___intnl_SystemBoolean_23 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_23");
            Private___intnl_SystemBoolean_33 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_33");
            Private___intnl_SystemBoolean_43 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_43");
            Private___intnl_SystemBoolean_53 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_53");
            Private___gintnl_SystemUInt32_56 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_56");
            Private___gintnl_SystemUInt32_46 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_46");
            Private___gintnl_SystemUInt32_16 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_16");
            Private___gintnl_SystemUInt32_36 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_36");
            Private___gintnl_SystemUInt32_26 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_26");
            Private___intnl_SystemSingle_20 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_20");
            Private___intnl_SystemSingle_21 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_21");
            Private___intnl_SystemSingle_22 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_22");
            Private___intnl_SystemSingle_23 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_23");
            Private___intnl_SystemSingle_24 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_24");
            Private___intnl_SystemSingle_25 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_25");
            Private___intnl_SystemSingle_26 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_26");
            Private___intnl_SystemSingle_27 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_27");
            Private___intnl_SystemSingle_28 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_28");
            Private___intnl_SystemSingle_29 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_29");
            Private___intnl_SystemInt32_15 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_15");
            Private___intnl_SystemInt32_35 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_35");
            Private___intnl_SystemInt32_25 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_25");
            Private___intnl_SystemInt32_45 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_45");
            Private___intnl_SystemUInt32_4 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_4");
            Private___const_SystemInt64_0 = new AstroUdonVariable<long>(NetworkingManager, "__const_SystemInt64_0");
            Private_ballsPocketedSynced = new AstroUdonVariable<uint>(NetworkingManager, "ballsPocketedSynced");
            Private___lcl__b_SystemUInt16_0 = new AstroUdonVariable<ushort>(NetworkingManager, "__lcl__b_SystemUInt16_0");
            Private___0_playerId__param = new AstroUdonVariable<int>(NetworkingManager, "__0_playerId__param");
            Private___0_ballsPocketed__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_ballsPocketed__param");
            Private___0___0__OnJoinTeam__ret = new AstroUdonVariable<int>(NetworkingManager, "__0___0__OnJoinTeam__ret");
            Private_cueBallVSynced = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "cueBallVSynced");
            Private___const_SystemByte_1 = new AstroUdonVariable<byte>(NetworkingManager, "__const_SystemByte_1");
            Private___0_cueBallW__param = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__0_cueBallW__param");
            Private___intnl_SystemSingle_0 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_0");
            Private___intnl_SystemUInt16_1 = new AstroUdonVariable<ushort>(NetworkingManager, "__intnl_SystemUInt16_1");
            Private___1_pos__param = new AstroUdonVariable<int>(NetworkingManager, "__1_pos__param");
            Private___intnl_SystemChar_1 = new AstroUdonVariable<char>(NetworkingManager, "__intnl_SystemChar_1");
            Private___0_pos__param = new AstroUdonVariable<int>(NetworkingManager, "__0_pos__param");
            Private___0_noGuidelineEnabled__param = new AstroUdonVariable<bool>(NetworkingManager, "__0_noGuidelineEnabled__param");
            Private___3_pos__param = new AstroUdonVariable<int>(NetworkingManager, "__3_pos__param");
            Private_ownershipManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "ownershipManager");
            Private___0___0_decodeU16__ret = new AstroUdonVariable<ushort>(NetworkingManager, "__0___0_decodeU16__ret");
            Private___const_SystemString_0 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_0");
            Private___2_pos__param = new AstroUdonVariable<int>(NetworkingManager, "__2_pos__param");
            Private___const_SystemUInt32_6 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_6");
            Private___0_urgent__param = new AstroUdonVariable<bool>(NetworkingManager, "__0_urgent__param");
            Private___const_SystemSingle_0 = new AstroUdonVariable<float>(NetworkingManager, "__const_SystemSingle_0");
            Private___intnl_SystemDouble_3 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_3");
            Private_timerSynced = new AstroUdonVariable<uint>(NetworkingManager, "timerSynced");
            Private___0_previewWinningTeam__param = new AstroUdonVariable<byte>(NetworkingManager, "__0_previewWinningTeam__param");
            Private___intnl_SystemBoolean_16 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_16");
            Private___intnl_SystemBoolean_26 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_26");
            Private___intnl_SystemBoolean_36 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_36");
            Private___intnl_SystemBoolean_46 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_46");
            Private_timerStartSynced = new AstroUdonVariable<int>(NetworkingManager, "timerStartSynced");
            Private___const_SystemInt32_11 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_11");
            Private___const_SystemInt32_31 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_31");
            Private___const_SystemInt32_21 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_21");
            Private___intnl_SystemSingle_10 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_10");
            Private___intnl_SystemSingle_11 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_11");
            Private___intnl_SystemSingle_12 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_12");
            Private___intnl_SystemSingle_13 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_13");
            Private___intnl_SystemSingle_14 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_14");
            Private___intnl_SystemSingle_15 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_15");
            Private___intnl_SystemSingle_16 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_16");
            Private___intnl_SystemSingle_17 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_17");
            Private___intnl_SystemSingle_18 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_18");
            Private___intnl_SystemSingle_19 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_19");
            Private___lcl_j_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_j_SystemInt32_0");
            Private___intnl_SystemInt32_12 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_12");
            Private___intnl_SystemInt32_32 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_32");
            Private___intnl_SystemInt32_22 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_22");
            Private___intnl_SystemInt32_42 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_42");
            Private___lcl_occurences_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_occurences_SystemInt32_0");
            Private___gintnl_SystemUInt32Array_0 = new AstroUdonVariable<uint[]>(NetworkingManager, "__gintnl_SystemUInt32Array_0");
            Private_repositionStateSynced = new AstroUdonVariable<byte>(NetworkingManager, "repositionStateSynced");
            Private___lcl_intValue_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_intValue_SystemInt32_0");
            Private___0_gameMode__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_gameMode__param");
            Private___intnl_SystemByte_3 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_3");
            Private___intnl_SystemSingle_8 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_8");
            Private___gintnl_SystemUInt32_9 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_9");
            Private___gintnl_SystemUInt32_8 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_8");
            Private___gintnl_SystemUInt32_5 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_5");
            Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_4");
            Private___gintnl_SystemUInt32_7 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_7");
            Private___gintnl_SystemUInt32_6 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_6");
            Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_1");
            Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_0");
            Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_3");
            Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_2");
            Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(NetworkingManager, "__const_SystemBoolean_0");
            Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(NetworkingManager, "__const_SystemBoolean_1");
            Private___const_SystemByte_2 = new AstroUdonVariable<byte>(NetworkingManager, "__const_SystemByte_2");
            Private___0_newPhysicsMode__param = new AstroUdonVariable<byte>(NetworkingManager, "__0_newPhysicsMode__param");
            Private___const_SystemUInt32_11 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_11");
            Private___const_SystemUInt32_10 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_10");
            Private___const_SystemUInt32_13 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_13");
            Private___const_SystemUInt32_12 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_12");
            Private___const_SystemUInt32_15 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_15");
            Private___const_SystemUInt32_14 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_14");
            Private___const_SystemUInt32_16 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_16");
            Private___lcl_index_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_index_SystemInt32_0");
            Private_fourBallScoresSynced = new AstroUdonVariable<int[]>(NetworkingManager, "fourBallScoresSynced");
            Private___const_SystemString_5 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_5");
            Private___const_SystemUInt32_5 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_5");
            Private_hasBufferedMessages = new AstroUdonVariable<bool>(NetworkingManager, "hasBufferedMessages");
            Private___const_SystemUInt32_8 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_8");
            Private___const_SystemInt32_19 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_19");
            Private___const_SystemInt32_39 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_39");
            Private___const_SystemInt32_29 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_29");
            Private___gintnl_SystemUInt32_53 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_53");
            Private___gintnl_SystemUInt32_43 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_43");
            Private___gintnl_SystemUInt32_13 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_13");
            Private___gintnl_SystemUInt32_33 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_33");
            Private___gintnl_SystemUInt32_23 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_23");
            Private_noGuidelineSynced = new AstroUdonVariable<bool>(NetworkingManager, "noGuidelineSynced");
            Private___intnl_SystemUInt32_3 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_3");
            Private___const_SystemInt32_16 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_16");
            Private___const_SystemInt32_36 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_36");
            Private___const_SystemInt32_26 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_26");
            Private_ballsPSynced = new AstroUdonVariable<UnityEngine.Vector3[]>(NetworkingManager, "ballsPSynced");
            Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(NetworkingManager, "__const_VRCUdonCommonInterfacesNetworkEventTarget_0");
            Private___0_range__param = new AstroUdonVariable<float>(NetworkingManager, "__0_range__param");
            Private___0_fourBallCueBall__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_fourBallCueBall__param");
            Private_tableModelSynced = new AstroUdonVariable<byte>(NetworkingManager, "tableModelSynced");
            Private_isUrgentSynced = new AstroUdonVariable<byte>(NetworkingManager, "isUrgentSynced");
            Private___const_SystemString_16 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_16");
            Private___const_SystemString_17 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_17");
            Private___const_SystemString_14 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_14");
            Private___const_SystemString_15 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_15");
            Private___const_SystemString_12 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_12");
            Private___const_SystemString_13 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_13");
            Private___const_SystemString_10 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_10");
            Private___const_SystemString_11 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_11");
            Private___const_SystemString_18 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_18");
            Private___const_SystemString_19 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_19");
            Private___intnl_SystemByte_4 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_4");
            Private___intnl_SystemSingle_7 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_7");
            Private___intnl_SystemUInt16_4 = new AstroUdonVariable<ushort>(NetworkingManager, "__intnl_SystemUInt16_4");
            Private___refl_typeid = new AstroUdonVariable<long>(NetworkingManager, "__refl_typeid");
            Private_previewWinningTeamSynced = new AstroUdonVariable<byte>(NetworkingManager, "previewWinningTeamSynced");
            Private___1_cueBallW__param = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__1_cueBallW__param");
            Private___1_teamId__param = new AstroUdonVariable<uint>(NetworkingManager, "__1_teamId__param");
            Private___0_teamsEnabled__param = new AstroUdonVariable<bool>(NetworkingManager, "__0_teamsEnabled__param");
            Private___intnl_SystemDouble_4 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_4");
            Private___2_teamId__param = new AstroUdonVariable<int>(NetworkingManager, "__2_teamId__param");
            Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_0");
            Private___intnl_UnityEngineComponent_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__intnl_UnityEngineComponent_0");
            Private___lcl_y_SystemSingle_1 = new AstroUdonVariable<float>(NetworkingManager, "__lcl_y_SystemSingle_1");
            Private___intnl_SystemBoolean_11 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_11");
            Private___intnl_SystemBoolean_21 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_21");
            Private___intnl_SystemBoolean_31 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_31");
            Private___intnl_SystemBoolean_41 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_41");
            Private___intnl_SystemBoolean_51 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_51");
            Private___1_winnerId__param = new AstroUdonVariable<uint>(NetworkingManager, "__1_winnerId__param");
            Private___gintnl_SystemUInt32_54 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_54");
            Private___gintnl_SystemUInt32_44 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_44");
            Private___gintnl_SystemUInt32_14 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_14");
            Private___gintnl_SystemUInt32_34 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_34");
            Private___gintnl_SystemUInt32_24 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_24");
            Private___intnl_SystemSingle_40 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_40");
            Private___intnl_SystemSingle_41 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_41");
            Private___intnl_SystemSingle_42 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_42");
            Private___intnl_SystemSingle_43 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_43");
            Private___intnl_SystemSingle_44 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_44");
            Private___intnl_SystemSingle_45 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_45");
            Private___intnl_SystemSingle_46 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_46");
            Private___intnl_SystemSingle_47 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_47");
            Private___intnl_SystemSingle_48 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_48");
            Private___intnl_SystemSingle_49 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_49");
            Private___const_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__const_UnityEngineVector3_0");
            Private___intnl_SystemInt32_17 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_17");
            Private___intnl_SystemInt32_37 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_37");
            Private___intnl_SystemInt32_27 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_27");
            Private___intnl_SystemUInt32_6 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_6");
            Private___0__intnlparam = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__0__intnlparam");
            Private___1_ballsPocketed__param = new AstroUdonVariable<uint>(NetworkingManager, "__1_ballsPocketed__param");
            Private___intnl_SystemSingle_2 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_2");
            Private___intnl_SystemUInt16_3 = new AstroUdonVariable<ushort>(NetworkingManager, "__intnl_SystemUInt16_3");
            Private___0_table___param = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__0_table___param");
            Private_gameStateSynced = new AstroUdonVariable<byte>(NetworkingManager, "gameStateSynced");
            Private___intnl_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__intnl_VRCUdonUdonBehaviour_1");
            Private_playerSlots = new AstroUdonVariable<UnityEngine.Component[]>(NetworkingManager, "playerSlots");
            Private___const_SystemString_2 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_2");
            Private___0_consumeReposition__param = new AstroUdonVariable<bool>(NetworkingManager, "__0_consumeReposition__param");
            Private___1_addr__param = new AstroUdonVariable<int>(NetworkingManager, "__1_addr__param");
            Private___0_repositionState__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_repositionState__param");
            Private___const_SystemSingle_2 = new AstroUdonVariable<float>(NetworkingManager, "__const_SystemSingle_2");
            Private___intnl_SystemDouble_1 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_1");
            Private___intnl_SystemBoolean_19 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_19");
            Private___intnl_SystemBoolean_29 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_29");
            Private___intnl_SystemBoolean_39 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_39");
            Private___intnl_SystemBoolean_49 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_49");
            Private___lcl__a_SystemUInt16_0 = new AstroUdonVariable<ushort>(NetworkingManager, "__lcl__a_SystemUInt16_0");
            Private___intnl_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__intnl_UnityEngineVector3_0");
            Private___intnl_SystemBoolean_14 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_14");
            Private___intnl_SystemBoolean_24 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_24");
            Private___intnl_SystemBoolean_34 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_34");
            Private___intnl_SystemBoolean_44 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_44");
            Private___intnl_SystemBoolean_54 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_54");
            Private___const_SystemInt32_13 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_13");
            Private___const_SystemInt32_33 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_33");
            Private___const_SystemInt32_23 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_23");
            Private___intnl_UnityEngineComponentArray_0 = new AstroUdonVariable<UnityEngine.Component[]>(NetworkingManager, "__intnl_UnityEngineComponentArray_0");
            Private___intnl_SystemSingle_30 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_30");
            Private___intnl_SystemSingle_31 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_31");
            Private___intnl_SystemSingle_32 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_32");
            Private___intnl_SystemSingle_33 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_33");
            Private___intnl_SystemSingle_34 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_34");
            Private___intnl_SystemSingle_35 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_35");
            Private___intnl_SystemSingle_36 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_36");
            Private___intnl_SystemSingle_37 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_37");
            Private___intnl_SystemSingle_38 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_38");
            Private___intnl_SystemSingle_39 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_39");
            Private___intnl_SystemInt32_14 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_14");
            Private___intnl_SystemInt32_34 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_34");
            Private___intnl_SystemInt32_24 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_24");
            Private___intnl_SystemInt32_44 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_44");
            Private___intnl_SystemUInt32_5 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_5");
            Private_packetIdSynced = new AstroUdonVariable<int>(NetworkingManager, "packetIdSynced");
            Private_winningTeamSynced = new AstroUdonVariable<byte>(NetworkingManager, "winningTeamSynced");
            Private___intnl_SystemInt32_19 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_19");
            Private___intnl_SystemInt32_39 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_39");
            Private___intnl_SystemInt32_29 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_29");
            Private___intnl_SystemByte_1 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_1");
            Private_teamColorSynced = new AstroUdonVariable<byte>(NetworkingManager, "teamColorSynced");
            Private___4_range__param = new AstroUdonVariable<float>(NetworkingManager, "__4_range__param");
            Private___const_SystemByte_0 = new AstroUdonVariable<byte>(NetworkingManager, "__const_SystemByte_0");
            Private___intnl_SystemSingle_1 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_1");
            Private___intnl_SystemChar_0 = new AstroUdonVariable<char>(NetworkingManager, "__intnl_SystemChar_0");
            Private_playerNamesSynced = new AstroUdonVariable<string[]>(NetworkingManager, "playerNamesSynced");
            Private___lcl__z_SystemUInt16_0 = new AstroUdonVariable<ushort>(NetworkingManager, "__lcl__z_SystemUInt16_0");
            Private___0_cueBallV__param = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__0_cueBallV__param");
            Private___0_isTableOpen__param = new AstroUdonVariable<bool>(NetworkingManager, "__0_isTableOpen__param");
            Private___intnl_SystemDouble_9 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_9");
            Private___const_SystemString_7 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_7");
            Private___0___0_decodeVec3Full__ret = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__0___0_decodeVec3Full__ret");
            Private___const_SystemUInt32_7 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_7");
            Private___0_turnStateLocal__param = new AstroUdonVariable<byte>(NetworkingManager, "__0_turnStateLocal__param");
            Private___const_SystemSingle_1 = new AstroUdonVariable<float>(NetworkingManager, "__const_SystemSingle_1");
            Private___intnl_SystemDouble_2 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_2");
            Private___1_playerId__param = new AstroUdonVariable<int>(NetworkingManager, "__1_playerId__param");
            Private___lcl_z_SystemSingle_0 = new AstroUdonVariable<float>(NetworkingManager, "__lcl_z_SystemSingle_0");
            Private___gintnl_SystemUInt32_51 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_51");
            Private___gintnl_SystemUInt32_41 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_41");
            Private___gintnl_SystemUInt32_61 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_61");
            Private___gintnl_SystemUInt32_11 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_11");
            Private___gintnl_SystemUInt32_31 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_31");
            Private___gintnl_SystemUInt32_21 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_21");
            Private___intnl_SystemBoolean_17 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_17");
            Private___intnl_SystemBoolean_27 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_27");
            Private___intnl_SystemBoolean_37 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_37");
            Private___intnl_SystemBoolean_47 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_47");
            Private_isTableOpenSynced = new AstroUdonVariable<bool>(NetworkingManager, "isTableOpenSynced");
            Private___const_SystemInt32_10 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_10");
            Private___const_SystemInt32_30 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_30");
            Private___const_SystemInt32_20 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_20");
            Private___intnl_SystemInt32_11 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_11");
            Private___intnl_SystemInt32_31 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_31");
            Private___intnl_SystemInt32_21 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_21");
            Private___intnl_SystemInt32_41 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_41");
            Private___intnl_SystemByte_9 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_9");
            Private___const_SystemString_34 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_34");
            Private___const_SystemString_32 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_32");
            Private___const_SystemString_33 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_33");
            Private___const_SystemString_30 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_30");
            Private___const_SystemString_31 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_31");
            Private___intnl_SystemByte_2 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_2");
            Private___intnl_SystemSingle_9 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_9");
            Private___intnl_SystemUInt16_6 = new AstroUdonVariable<ushort>(NetworkingManager, "__intnl_SystemUInt16_6");
            Private___intnl_SystemInt64_0 = new AstroUdonVariable<long>(NetworkingManager, "__intnl_SystemInt64_0");
            Private___intnl_SystemUInt32_21 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_21");
            Private___intnl_SystemUInt32_20 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_20");
            Private___intnl_SystemUInt32_23 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_23");
            Private___intnl_SystemUInt32_22 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_22");
            Private___3_range__param = new AstroUdonVariable<float>(NetworkingManager, "__3_range__param");
            Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_returnJump_SystemUInt32_0");
            Private___0_defaultBallsPocketed__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_defaultBallsPocketed__param");
            Private___const_SystemString_4 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_4");
            Private___lcl__g_SystemUInt16_0 = new AstroUdonVariable<ushort>(NetworkingManager, "__lcl__g_SystemUInt16_0");
            Private___0___0_decodeF32__ret = new AstroUdonVariable<float>(NetworkingManager, "__0___0_decodeF32__ret");
            Private___const_SystemUInt32_2 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_2");
            Private___gintnl_SystemUInt32_59 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_59");
            Private___gintnl_SystemUInt32_49 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_49");
            Private___gintnl_SystemUInt32_19 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_19");
            Private___gintnl_SystemUInt32_39 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_39");
            Private___gintnl_SystemUInt32_29 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_29");
            Private___const_SystemSingle_4 = new AstroUdonVariable<float>(NetworkingManager, "__const_SystemSingle_4");
            Private___const_SystemUInt32_9 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_9");
            Private___const_SystemInt32_18 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_18");
            Private___const_SystemInt32_38 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_38");
            Private___const_SystemInt32_28 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_28");
            Private_gameModeSynced = new AstroUdonVariable<byte>(NetworkingManager, "gameModeSynced");
            Private___gintnl_SystemUInt32_52 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_52");
            Private___gintnl_SystemUInt32_42 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_42");
            Private___gintnl_SystemUInt32_62 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_62");
            Private___gintnl_SystemUInt32_12 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_12");
            Private___gintnl_SystemUInt32_32 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_32");
            Private___gintnl_SystemUInt32_22 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_22");
            Private___intnl_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_0");
            Private___lcl_i_SystemInt32_8 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_8");
            Private___lcl_i_SystemInt32_1 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_1");
            Private___lcl_i_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_0");
            Private___lcl_i_SystemInt32_3 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_3");
            Private___lcl_i_SystemInt32_2 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_2");
            Private___lcl_i_SystemInt32_5 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_5");
            Private___lcl_i_SystemInt32_4 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_4");
            Private___lcl_i_SystemInt32_7 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_7");
            Private___lcl_i_SystemInt32_6 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_6");
            Private___const_SystemInt32_15 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_15");
            Private___const_SystemInt32_35 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_35");
            Private___const_SystemInt32_25 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_25");
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__lcl_behaviour_VRCUdonUdonBehaviour_0");
            Private___intnl_SystemByte_11 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_11");
            Private___intnl_SystemByte_10 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_10");
            Private___1_start__param = new AstroUdonVariable<int>(NetworkingManager, "__1_start__param");
            Private___lcl_state_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__lcl_state_SystemUInt32_0");
            Private___0_teamId__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_teamId__param");
            Private___lcl_x_SystemSingle_0 = new AstroUdonVariable<float>(NetworkingManager, "__lcl_x_SystemSingle_0");
            Private___intnl_SystemByte_7 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_7");
            Private___intnl_SystemSingle_4 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_4");
            Private___intnl_SystemUInt16_5 = new AstroUdonVariable<ushort>(NetworkingManager, "__intnl_SystemUInt16_5");
            Private___1__intnlparam = new AstroUdonVariable<UnityEngine.Transform>(NetworkingManager, "__1__intnlparam");
            Private_physicsModeSynced = new AstroUdonVariable<byte>(NetworkingManager, "physicsModeSynced");
            Private___intnl_SystemUInt32_19 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_19");
            Private___intnl_SystemUInt32_18 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_18");
            Private___intnl_SystemUInt32_11 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_11");
            Private___intnl_SystemUInt32_10 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_10");
            Private___intnl_SystemUInt32_13 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_13");
            Private___intnl_SystemUInt32_12 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_12");
            Private___intnl_SystemUInt32_15 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_15");
            Private___intnl_SystemUInt32_14 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_14");
            Private___intnl_SystemUInt32_17 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_17");
            Private___intnl_SystemUInt32_16 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_16");
            Private___0___0_decodeColor__ret = new AstroUdonVariable<UnityEngine.Color>(NetworkingManager, "__0___0_decodeColor__ret");
            Private___1_cueBallV__param = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__1_cueBallV__param");
            Private___intnl_SystemDouble_7 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_7");
            Private___lcl_timerSetting_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__lcl_timerSetting_SystemUInt32_0");
            Private___const_SystemString_9 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_9");
            Private___const_SystemUInt32_1 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_1");
            Private___intnl_SystemUInt32_8 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_8");
            Private_stateIdSynced = new AstroUdonVariable<int>(NetworkingManager, "stateIdSynced");
            Private_table = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "table");
            Private___lcl_registrationsChanged_SystemBoolean_0 = new AstroUdonVariable<bool>(NetworkingManager, "__lcl_registrationsChanged_SystemBoolean_0");
            Private___intnl_SystemBoolean_12 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_12");
            Private___intnl_SystemBoolean_22 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_22");
            Private___intnl_SystemBoolean_32 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_32");
            Private___intnl_SystemBoolean_42 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_42");
            Private___intnl_SystemBoolean_52 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_52");
            Private___0_stateIdLocal__param = new AstroUdonVariable<int>(NetworkingManager, "__0_stateIdLocal__param");
            Private___gintnl_SystemUInt32_57 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_57");
            Private___gintnl_SystemUInt32_47 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_47");
            Private___gintnl_SystemUInt32_17 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_17");
            Private___gintnl_SystemUInt32_37 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_37");
            Private___gintnl_SystemUInt32_27 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_27");
            Private___intnl_SystemSingle_50 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_50");
            Private___intnl_SystemSingle_51 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_51");
            Private___intnl_SystemSingle_52 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_52");
            Private___intnl_SystemSingle_53 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_53");
            Private___intnl_SystemSingle_54 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_54");
            Private___intnl_SystemSingle_55 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_55");
            Private___intnl_SystemSingle_56 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_56");
            Private___intnl_SystemSingle_57 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_57");
            Private___intnl_SystemSingle_58 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_58");
            Private___intnl_SystemSingle_59 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_59");
            Private___intnl_SystemInt32_16 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_16");
            Private___intnl_SystemInt32_36 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_36");
            Private___intnl_SystemInt32_26 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_26");
            Private___intnl_SystemInt32_46 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_46");
            Private___intnl_SystemUInt32_7 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_7");
            Private___refl_typename = new AstroUdonVariable<string>(NetworkingManager, "__refl_typename");
            Private___const_SystemBase64FormattingOptions_0 = new AstroUdonVariable<System.Base64FormattingOptions>(NetworkingManager, "__const_SystemBase64FormattingOptions_0");
            Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_1");
            Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_0");
            Private___intnl_SystemInt32_3 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_3");
            Private___intnl_SystemInt32_2 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_2");
            Private___intnl_SystemInt32_5 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_5");
            Private___intnl_SystemInt32_4 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_4");
            Private___intnl_SystemInt32_7 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_7");
            Private___intnl_SystemInt32_6 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_6");
            Private___intnl_SystemInt32_9 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_9");
            Private___intnl_SystemInt32_8 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_8");
            Private___0_addr__param = new AstroUdonVariable<int>(NetworkingManager, "__0_addr__param");
            Private___0_v__param = new AstroUdonVariable<ushort>(NetworkingManager, "__0_v__param");
            Private___intnl_SystemSingle_3 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_3");
            Private___intnl_SystemUInt16_0 = new AstroUdonVariable<ushort>(NetworkingManager, "__intnl_SystemUInt16_0");
            Private___this_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(NetworkingManager, "__this_UnityEngineTransform_0");
            Private___intnl_SystemChar_2 = new AstroUdonVariable<char>(NetworkingManager, "__intnl_SystemChar_2");
            Private___1_teamColor__param = new AstroUdonVariable<uint>(NetworkingManager, "__1_teamColor__param");
            Private___lcl_targetID_SystemInt64_0 = new AstroUdonVariable<long>(NetworkingManager, "__lcl_targetID_SystemInt64_0");
            Private___const_SystemString_1 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_1");
            Private___const_SystemSingle_3 = new AstroUdonVariable<float>(NetworkingManager, "__const_SystemSingle_3");
            Private___intnl_SystemDouble_0 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_0");
            Private___lcl_idValue_SystemObject_0 = new AstroUdonVariable<long>(NetworkingManager, "__lcl_idValue_SystemObject_0");
            Private___intnl_UnityEngineVector3_1 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__intnl_UnityEngineVector3_1");
            Private_turnStateSynced = new AstroUdonVariable<byte>(NetworkingManager, "turnStateSynced");
            Private___intnl_SystemBoolean_15 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_15");
            Private___intnl_SystemBoolean_25 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_25");
            Private___intnl_SystemBoolean_35 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_35");
            Private___intnl_SystemBoolean_45 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_45");
            Private_teamsSynced = new AstroUdonVariable<bool>(NetworkingManager, "teamsSynced");
            Private___const_SystemInt32_12 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_12");
            Private___const_SystemInt32_32 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_32");
            Private___const_SystemInt32_22 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_22");
            Private___intnl_SystemInt32_13 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_13");
            Private___intnl_SystemInt32_33 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_33");
            Private___intnl_SystemInt32_23 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_23");
            Private___intnl_SystemInt32_43 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_43");
            Private___0___0_decodeVec3Part__ret = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__0___0_decodeVec3Part__ret");
            Private___intnl_SystemInt32_18 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_18");
            Private___intnl_SystemInt32_38 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_38");
            Private___intnl_SystemInt32_28 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_28");
            Private___lcl__y_SystemUInt16_1 = new AstroUdonVariable<ushort>(NetworkingManager, "__lcl__y_SystemUInt16_1");
            Private___lcl__y_SystemUInt16_0 = new AstroUdonVariable<ushort>(NetworkingManager, "__lcl__y_SystemUInt16_0");
            Private___intnl_SystemByte_0 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_0");
            Private___0___0_isValidBase64__ret = new AstroUdonVariable<bool>(NetworkingManager, "__0___0_isValidBase64__ret");
            Private___const_SystemByte_3 = new AstroUdonVariable<byte>(NetworkingManager, "__const_SystemByte_3");
            Private___0_newGameMode__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_newGameMode__param");
            Private_fourBallCueBallSynced = new AstroUdonVariable<byte>(NetworkingManager, "fourBallCueBallSynced");
            Private___intnl_SystemDouble_8 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_8");
            Private___const_SystemString_6 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_6");
            Private___2_range__param = new AstroUdonVariable<float>(NetworkingManager, "__2_range__param");
            Private___0_winnerId__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_winnerId__param");
            Private___const_SystemUInt32_4 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_4");
            Private___0_newTableSkin__param = new AstroUdonVariable<byte>(NetworkingManager, "__0_newTableSkin__param");
            Private___gintnl_SystemUInt32_50 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_50");
            Private___gintnl_SystemUInt32_40 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_40");
            Private___gintnl_SystemUInt32_60 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_60");
            Private___gintnl_SystemUInt32_10 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_10");
            Private___gintnl_SystemUInt32_30 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_30");
            Private___gintnl_SystemUInt32_20 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_20");
            Private___intnl_SystemUInt32_2 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_2");
            Private___const_SystemInt32_17 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_17");
            Private___const_SystemInt32_37 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_37");
            Private___const_SystemInt32_27 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_27");
            Private___intnl_SystemInt32_10 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_10");
            Private___intnl_SystemInt32_30 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_30");
            Private___intnl_SystemInt32_20 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_20");
            Private___intnl_SystemInt32_40 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_40");
            Private___0_start__param = new AstroUdonVariable<int>(NetworkingManager, "__0_start__param");
            Private___intnl_SystemByte_8 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_8");
            Private___lcl_temp_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__lcl_temp_UnityEngineVector3_0");
            Private___this_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(NetworkingManager, "__this_UnityEngineGameObject_0");
            Private___1_value__param = new AstroUdonVariable<char>(NetworkingManager, "__1_value__param");
            Private_teamIdSynced = new AstroUdonVariable<byte>(NetworkingManager, "teamIdSynced");
            Private_cueBallWSynced = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "cueBallWSynced");
            Private___const_SystemString_26 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_26");
            Private___const_SystemString_27 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_27");
            Private___const_SystemString_24 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_24");
            Private___const_SystemString_25 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_25");
            Private___const_SystemString_22 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_22");
            Private___const_SystemString_23 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_23");
            Private___const_SystemString_20 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_20");
            Private___const_SystemString_21 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_21");
            Private___const_SystemString_28 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_28");
            Private___const_SystemString_29 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_29");
            Private___intnl_SystemByte_5 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_5");
            Private___intnl_SystemSingle_6 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_6");
            Private_tableSkinSynced = new AstroUdonVariable<byte>(NetworkingManager, "tableSkinSynced");
            Private_noLockingSynced = new AstroUdonVariable<bool>(NetworkingManager, "noLockingSynced");
            Private___0_newTimer__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_newTimer__param");
            Private___0_teamColor__param = new AstroUdonVariable<uint>(NetworkingManager, "__0_teamColor__param");
            Private___intnl_SystemDouble_5 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_5");
            Private___const_SystemUInt32_3 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_3");
            Private___gintnl_SystemUInt32_58 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_58");
            Private___gintnl_SystemUInt32_48 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_48");
            Private___gintnl_SystemUInt32_18 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_18");
            Private___gintnl_SystemUInt32_38 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_38");
            Private___gintnl_SystemUInt32_28 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_28");
            Private___const_SystemSingle_5 = new AstroUdonVariable<float>(NetworkingManager, "__const_SystemSingle_5");
            Private___lcl_y_SystemSingle_0 = new AstroUdonVariable<float>(NetworkingManager, "__lcl_y_SystemSingle_0");
            Private___intnl_SystemBoolean_10 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_10");
            Private___intnl_SystemBoolean_20 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_20");
            Private___intnl_SystemBoolean_30 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_30");
            Private___intnl_SystemBoolean_40 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_40");
            Private___intnl_SystemBoolean_50 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_50");
            Private___0_noLockingEnabled__param = new AstroUdonVariable<bool>(NetworkingManager, "__0_noLockingEnabled__param");
            Private___lcl_spec_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__lcl_spec_SystemUInt32_0");
            Private___gintnl_SystemUInt32_55 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_55");
            Private___gintnl_SystemUInt32_45 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_45");
            Private___gintnl_SystemUInt32_15 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_15");
            Private___gintnl_SystemUInt32_35 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_35");
            Private___gintnl_SystemUInt32_25 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_25");
            Private___intnl_SystemUInt32_1 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_SystemUInt32_1");
            Private___1_range__param = new AstroUdonVariable<float>(NetworkingManager, "__1_range__param");
            Private___const_SystemInt32_9 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_9");
            Private___const_SystemInt32_8 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_8");
            Private___const_SystemInt32_1 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_1");
            Private___const_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_0");
            Private___const_SystemInt32_3 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_3");
            Private___const_SystemInt32_2 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_2");
            Private___const_SystemInt32_5 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_5");
            Private___const_SystemInt32_4 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_4");
            Private___const_SystemInt32_7 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_7");
            Private___const_SystemInt32_6 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_6");
            Private___const_SystemInt32_14 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_14");
            Private___const_SystemInt32_34 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_34");
            Private___const_SystemInt32_24 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_24");
            Private___3_teamId__param = new AstroUdonVariable<uint>(NetworkingManager, "__3_teamId__param");
            Private___lcl_udonBehaviours_UnityEngineComponentArray_0 = new AstroUdonVariable<UnityEngine.Component[]>(NetworkingManager, "__lcl_udonBehaviours_UnityEngineComponentArray_0");
            Private___0___0_isInvalidBase64Char__ret = new AstroUdonVariable<bool>(NetworkingManager, "__0___0_isInvalidBase64Char__ret");
            Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_8");
            Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_9");
            Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_0");
            Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_1");
            Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_2");
            Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_3");
            Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_4");
            Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_5");
            Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_6");
            Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_7");
            Private___1_vec__param = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__1_vec__param");
            Private___0_vec__param = new AstroUdonVariable<UnityEngine.Vector3>(NetworkingManager, "__0_vec__param");
            Private_lastProcessedPacketId = new AstroUdonVariable<int>(NetworkingManager, "lastProcessedPacketId");
            Private___lcl_x_SystemSingle_1 = new AstroUdonVariable<float>(NetworkingManager, "__lcl_x_SystemSingle_1");
            Private___intnl_SystemByte_6 = new AstroUdonVariable<byte>(NetworkingManager, "__intnl_SystemByte_6");
            Private___intnl_SystemSingle_5 = new AstroUdonVariable<float>(NetworkingManager, "__intnl_SystemSingle_5");
            Private___intnl_SystemUInt16_2 = new AstroUdonVariable<ushort>(NetworkingManager, "__intnl_SystemUInt16_2");
            Private___lcl__r_SystemUInt16_0 = new AstroUdonVariable<ushort>(NetworkingManager, "__lcl__r_SystemUInt16_0");
            Private___intnl_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__intnl_VRCUdonUdonBehaviour_0");
            Private___const_SystemString_3 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_3");
            Private___this_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__this_VRCUdonUdonBehaviour_2");
            Private___this_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__this_VRCUdonUdonBehaviour_1");
            Private___this_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__this_VRCUdonUdonBehaviour_0");
            Private___intnl_SystemDouble_6 = new AstroUdonVariable<double>(NetworkingManager, "__intnl_SystemDouble_6");
            Private___const_SystemString_8 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_8");
            Private___lcl__x_SystemUInt16_1 = new AstroUdonVariable<ushort>(NetworkingManager, "__lcl__x_SystemUInt16_1");
            Private___lcl__x_SystemUInt16_0 = new AstroUdonVariable<ushort>(NetworkingManager, "__lcl__x_SystemUInt16_0");
            Private___intnl_SystemBoolean_18 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_18");
            Private___intnl_SystemBoolean_28 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_28");
            Private___intnl_SystemBoolean_38 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_38");
            Private___intnl_SystemBoolean_48 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_48");
        }

        private void Cleanup_NetworkingManager()
        {
            Private___intnl_SystemUInt32_9 = null;
            Private___0_newTableModel__param = null;
            Private___intnl_SystemBoolean_13 = null;
            Private___intnl_SystemBoolean_23 = null;
            Private___intnl_SystemBoolean_33 = null;
            Private___intnl_SystemBoolean_43 = null;
            Private___intnl_SystemBoolean_53 = null;
            Private___gintnl_SystemUInt32_56 = null;
            Private___gintnl_SystemUInt32_46 = null;
            Private___gintnl_SystemUInt32_16 = null;
            Private___gintnl_SystemUInt32_36 = null;
            Private___gintnl_SystemUInt32_26 = null;
            Private___intnl_SystemSingle_20 = null;
            Private___intnl_SystemSingle_21 = null;
            Private___intnl_SystemSingle_22 = null;
            Private___intnl_SystemSingle_23 = null;
            Private___intnl_SystemSingle_24 = null;
            Private___intnl_SystemSingle_25 = null;
            Private___intnl_SystemSingle_26 = null;
            Private___intnl_SystemSingle_27 = null;
            Private___intnl_SystemSingle_28 = null;
            Private___intnl_SystemSingle_29 = null;
            Private___intnl_SystemInt32_15 = null;
            Private___intnl_SystemInt32_35 = null;
            Private___intnl_SystemInt32_25 = null;
            Private___intnl_SystemInt32_45 = null;
            Private___intnl_SystemUInt32_4 = null;
            Private___const_SystemInt64_0 = null;
            Private_ballsPocketedSynced = null;
            Private___lcl__b_SystemUInt16_0 = null;
            Private___0_playerId__param = null;
            Private___0_ballsPocketed__param = null;
            Private___0___0__OnJoinTeam__ret = null;
            Private_cueBallVSynced = null;
            Private___const_SystemByte_1 = null;
            Private___0_cueBallW__param = null;
            Private___intnl_SystemSingle_0 = null;
            Private___intnl_SystemUInt16_1 = null;
            Private___1_pos__param = null;
            Private___intnl_SystemChar_1 = null;
            Private___0_pos__param = null;
            Private___0_noGuidelineEnabled__param = null;
            Private___3_pos__param = null;
            Private_ownershipManager = null;
            Private___0___0_decodeU16__ret = null;
            Private___const_SystemString_0 = null;
            Private___2_pos__param = null;
            Private___const_SystemUInt32_6 = null;
            Private___0_urgent__param = null;
            Private___const_SystemSingle_0 = null;
            Private___intnl_SystemDouble_3 = null;
            Private_timerSynced = null;
            Private___0_previewWinningTeam__param = null;
            Private___intnl_SystemBoolean_16 = null;
            Private___intnl_SystemBoolean_26 = null;
            Private___intnl_SystemBoolean_36 = null;
            Private___intnl_SystemBoolean_46 = null;
            Private_timerStartSynced = null;
            Private___const_SystemInt32_11 = null;
            Private___const_SystemInt32_31 = null;
            Private___const_SystemInt32_21 = null;
            Private___intnl_SystemSingle_10 = null;
            Private___intnl_SystemSingle_11 = null;
            Private___intnl_SystemSingle_12 = null;
            Private___intnl_SystemSingle_13 = null;
            Private___intnl_SystemSingle_14 = null;
            Private___intnl_SystemSingle_15 = null;
            Private___intnl_SystemSingle_16 = null;
            Private___intnl_SystemSingle_17 = null;
            Private___intnl_SystemSingle_18 = null;
            Private___intnl_SystemSingle_19 = null;
            Private___lcl_j_SystemInt32_0 = null;
            Private___intnl_SystemInt32_12 = null;
            Private___intnl_SystemInt32_32 = null;
            Private___intnl_SystemInt32_22 = null;
            Private___intnl_SystemInt32_42 = null;
            Private___lcl_occurences_SystemInt32_0 = null;
            Private___gintnl_SystemUInt32Array_0 = null;
            Private_repositionStateSynced = null;
            Private___lcl_intValue_SystemInt32_0 = null;
            Private___0_gameMode__param = null;
            Private___intnl_SystemByte_3 = null;
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
            Private___const_SystemByte_2 = null;
            Private___0_newPhysicsMode__param = null;
            Private___const_SystemUInt32_11 = null;
            Private___const_SystemUInt32_10 = null;
            Private___const_SystemUInt32_13 = null;
            Private___const_SystemUInt32_12 = null;
            Private___const_SystemUInt32_15 = null;
            Private___const_SystemUInt32_14 = null;
            Private___const_SystemUInt32_16 = null;
            Private___lcl_index_SystemInt32_0 = null;
            Private_fourBallScoresSynced = null;
            Private___const_SystemString_5 = null;
            Private___const_SystemUInt32_5 = null;
            Private_hasBufferedMessages = null;
            Private___const_SystemUInt32_8 = null;
            Private___const_SystemInt32_19 = null;
            Private___const_SystemInt32_39 = null;
            Private___const_SystemInt32_29 = null;
            Private___gintnl_SystemUInt32_53 = null;
            Private___gintnl_SystemUInt32_43 = null;
            Private___gintnl_SystemUInt32_13 = null;
            Private___gintnl_SystemUInt32_33 = null;
            Private___gintnl_SystemUInt32_23 = null;
            Private_noGuidelineSynced = null;
            Private___intnl_SystemUInt32_3 = null;
            Private___const_SystemInt32_16 = null;
            Private___const_SystemInt32_36 = null;
            Private___const_SystemInt32_26 = null;
            Private_ballsPSynced = null;
            Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 = null;
            Private___0_range__param = null;
            Private___0_fourBallCueBall__param = null;
            Private_tableModelSynced = null;
            Private_isUrgentSynced = null;
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
            Private___intnl_SystemByte_4 = null;
            Private___intnl_SystemSingle_7 = null;
            Private___intnl_SystemUInt16_4 = null;
            Private___refl_typeid = null;
            Private_previewWinningTeamSynced = null;
            Private___1_cueBallW__param = null;
            Private___1_teamId__param = null;
            Private___0_teamsEnabled__param = null;
            Private___intnl_SystemDouble_4 = null;
            Private___2_teamId__param = null;
            Private___const_SystemUInt32_0 = null;
            Private___intnl_UnityEngineComponent_0 = null;
            Private___lcl_y_SystemSingle_1 = null;
            Private___intnl_SystemBoolean_11 = null;
            Private___intnl_SystemBoolean_21 = null;
            Private___intnl_SystemBoolean_31 = null;
            Private___intnl_SystemBoolean_41 = null;
            Private___intnl_SystemBoolean_51 = null;
            Private___1_winnerId__param = null;
            Private___gintnl_SystemUInt32_54 = null;
            Private___gintnl_SystemUInt32_44 = null;
            Private___gintnl_SystemUInt32_14 = null;
            Private___gintnl_SystemUInt32_34 = null;
            Private___gintnl_SystemUInt32_24 = null;
            Private___intnl_SystemSingle_40 = null;
            Private___intnl_SystemSingle_41 = null;
            Private___intnl_SystemSingle_42 = null;
            Private___intnl_SystemSingle_43 = null;
            Private___intnl_SystemSingle_44 = null;
            Private___intnl_SystemSingle_45 = null;
            Private___intnl_SystemSingle_46 = null;
            Private___intnl_SystemSingle_47 = null;
            Private___intnl_SystemSingle_48 = null;
            Private___intnl_SystemSingle_49 = null;
            Private___const_UnityEngineVector3_0 = null;
            Private___intnl_SystemInt32_17 = null;
            Private___intnl_SystemInt32_37 = null;
            Private___intnl_SystemInt32_27 = null;
            Private___intnl_SystemUInt32_6 = null;
            Private___0__intnlparam = null;
            Private___1_ballsPocketed__param = null;
            Private___intnl_SystemSingle_2 = null;
            Private___intnl_SystemUInt16_3 = null;
            Private___0_table___param = null;
            Private_gameStateSynced = null;
            Private___intnl_VRCUdonUdonBehaviour_1 = null;
            Private_playerSlots = null;
            Private___const_SystemString_2 = null;
            Private___0_consumeReposition__param = null;
            Private___1_addr__param = null;
            Private___0_repositionState__param = null;
            Private___const_SystemSingle_2 = null;
            Private___intnl_SystemDouble_1 = null;
            Private___intnl_SystemBoolean_19 = null;
            Private___intnl_SystemBoolean_29 = null;
            Private___intnl_SystemBoolean_39 = null;
            Private___intnl_SystemBoolean_49 = null;
            Private___lcl__a_SystemUInt16_0 = null;
            Private___intnl_UnityEngineVector3_0 = null;
            Private___intnl_SystemBoolean_14 = null;
            Private___intnl_SystemBoolean_24 = null;
            Private___intnl_SystemBoolean_34 = null;
            Private___intnl_SystemBoolean_44 = null;
            Private___intnl_SystemBoolean_54 = null;
            Private___const_SystemInt32_13 = null;
            Private___const_SystemInt32_33 = null;
            Private___const_SystemInt32_23 = null;
            Private___intnl_UnityEngineComponentArray_0 = null;
            Private___intnl_SystemSingle_30 = null;
            Private___intnl_SystemSingle_31 = null;
            Private___intnl_SystemSingle_32 = null;
            Private___intnl_SystemSingle_33 = null;
            Private___intnl_SystemSingle_34 = null;
            Private___intnl_SystemSingle_35 = null;
            Private___intnl_SystemSingle_36 = null;
            Private___intnl_SystemSingle_37 = null;
            Private___intnl_SystemSingle_38 = null;
            Private___intnl_SystemSingle_39 = null;
            Private___intnl_SystemInt32_14 = null;
            Private___intnl_SystemInt32_34 = null;
            Private___intnl_SystemInt32_24 = null;
            Private___intnl_SystemInt32_44 = null;
            Private___intnl_SystemUInt32_5 = null;
            Private_packetIdSynced = null;
            Private_winningTeamSynced = null;
            Private___intnl_SystemInt32_19 = null;
            Private___intnl_SystemInt32_39 = null;
            Private___intnl_SystemInt32_29 = null;
            Private___intnl_SystemByte_1 = null;
            Private_teamColorSynced = null;
            Private___4_range__param = null;
            Private___const_SystemByte_0 = null;
            Private___intnl_SystemSingle_1 = null;
            Private___intnl_SystemChar_0 = null;
            Private_playerNamesSynced = null;
            Private___lcl__z_SystemUInt16_0 = null;
            Private___0_cueBallV__param = null;
            Private___0_isTableOpen__param = null;
            Private___intnl_SystemDouble_9 = null;
            Private___const_SystemString_7 = null;
            Private___0___0_decodeVec3Full__ret = null;
            Private___const_SystemUInt32_7 = null;
            Private___0_turnStateLocal__param = null;
            Private___const_SystemSingle_1 = null;
            Private___intnl_SystemDouble_2 = null;
            Private___1_playerId__param = null;
            Private___lcl_z_SystemSingle_0 = null;
            Private___gintnl_SystemUInt32_51 = null;
            Private___gintnl_SystemUInt32_41 = null;
            Private___gintnl_SystemUInt32_61 = null;
            Private___gintnl_SystemUInt32_11 = null;
            Private___gintnl_SystemUInt32_31 = null;
            Private___gintnl_SystemUInt32_21 = null;
            Private___intnl_SystemBoolean_17 = null;
            Private___intnl_SystemBoolean_27 = null;
            Private___intnl_SystemBoolean_37 = null;
            Private___intnl_SystemBoolean_47 = null;
            Private_isTableOpenSynced = null;
            Private___const_SystemInt32_10 = null;
            Private___const_SystemInt32_30 = null;
            Private___const_SystemInt32_20 = null;
            Private___intnl_SystemInt32_11 = null;
            Private___intnl_SystemInt32_31 = null;
            Private___intnl_SystemInt32_21 = null;
            Private___intnl_SystemInt32_41 = null;
            Private___intnl_SystemByte_9 = null;
            Private___const_SystemString_34 = null;
            Private___const_SystemString_32 = null;
            Private___const_SystemString_33 = null;
            Private___const_SystemString_30 = null;
            Private___const_SystemString_31 = null;
            Private___intnl_SystemByte_2 = null;
            Private___intnl_SystemSingle_9 = null;
            Private___intnl_SystemUInt16_6 = null;
            Private___intnl_SystemInt64_0 = null;
            Private___intnl_SystemUInt32_21 = null;
            Private___intnl_SystemUInt32_20 = null;
            Private___intnl_SystemUInt32_23 = null;
            Private___intnl_SystemUInt32_22 = null;
            Private___3_range__param = null;
            Private___intnl_returnJump_SystemUInt32_0 = null;
            Private___0_defaultBallsPocketed__param = null;
            Private___const_SystemString_4 = null;
            Private___lcl__g_SystemUInt16_0 = null;
            Private___0___0_decodeF32__ret = null;
            Private___const_SystemUInt32_2 = null;
            Private___gintnl_SystemUInt32_59 = null;
            Private___gintnl_SystemUInt32_49 = null;
            Private___gintnl_SystemUInt32_19 = null;
            Private___gintnl_SystemUInt32_39 = null;
            Private___gintnl_SystemUInt32_29 = null;
            Private___const_SystemSingle_4 = null;
            Private___const_SystemUInt32_9 = null;
            Private___const_SystemInt32_18 = null;
            Private___const_SystemInt32_38 = null;
            Private___const_SystemInt32_28 = null;
            Private_gameModeSynced = null;
            Private___gintnl_SystemUInt32_52 = null;
            Private___gintnl_SystemUInt32_42 = null;
            Private___gintnl_SystemUInt32_62 = null;
            Private___gintnl_SystemUInt32_12 = null;
            Private___gintnl_SystemUInt32_32 = null;
            Private___gintnl_SystemUInt32_22 = null;
            Private___intnl_SystemUInt32_0 = null;
            Private___lcl_i_SystemInt32_8 = null;
            Private___lcl_i_SystemInt32_1 = null;
            Private___lcl_i_SystemInt32_0 = null;
            Private___lcl_i_SystemInt32_3 = null;
            Private___lcl_i_SystemInt32_2 = null;
            Private___lcl_i_SystemInt32_5 = null;
            Private___lcl_i_SystemInt32_4 = null;
            Private___lcl_i_SystemInt32_7 = null;
            Private___lcl_i_SystemInt32_6 = null;
            Private___const_SystemInt32_15 = null;
            Private___const_SystemInt32_35 = null;
            Private___const_SystemInt32_25 = null;
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = null;
            Private___intnl_SystemByte_11 = null;
            Private___intnl_SystemByte_10 = null;
            Private___1_start__param = null;
            Private___lcl_state_SystemUInt32_0 = null;
            Private___0_teamId__param = null;
            Private___lcl_x_SystemSingle_0 = null;
            Private___intnl_SystemByte_7 = null;
            Private___intnl_SystemSingle_4 = null;
            Private___intnl_SystemUInt16_5 = null;
            Private___1__intnlparam = null;
            Private_physicsModeSynced = null;
            Private___intnl_SystemUInt32_19 = null;
            Private___intnl_SystemUInt32_18 = null;
            Private___intnl_SystemUInt32_11 = null;
            Private___intnl_SystemUInt32_10 = null;
            Private___intnl_SystemUInt32_13 = null;
            Private___intnl_SystemUInt32_12 = null;
            Private___intnl_SystemUInt32_15 = null;
            Private___intnl_SystemUInt32_14 = null;
            Private___intnl_SystemUInt32_17 = null;
            Private___intnl_SystemUInt32_16 = null;
            Private___0___0_decodeColor__ret = null;
            Private___1_cueBallV__param = null;
            Private___intnl_SystemDouble_7 = null;
            Private___lcl_timerSetting_SystemUInt32_0 = null;
            Private___const_SystemString_9 = null;
            Private___const_SystemUInt32_1 = null;
            Private___intnl_SystemUInt32_8 = null;
            Private_stateIdSynced = null;
            Private_table = null;
            Private___lcl_registrationsChanged_SystemBoolean_0 = null;
            Private___intnl_SystemBoolean_12 = null;
            Private___intnl_SystemBoolean_22 = null;
            Private___intnl_SystemBoolean_32 = null;
            Private___intnl_SystemBoolean_42 = null;
            Private___intnl_SystemBoolean_52 = null;
            Private___0_stateIdLocal__param = null;
            Private___gintnl_SystemUInt32_57 = null;
            Private___gintnl_SystemUInt32_47 = null;
            Private___gintnl_SystemUInt32_17 = null;
            Private___gintnl_SystemUInt32_37 = null;
            Private___gintnl_SystemUInt32_27 = null;
            Private___intnl_SystemSingle_50 = null;
            Private___intnl_SystemSingle_51 = null;
            Private___intnl_SystemSingle_52 = null;
            Private___intnl_SystemSingle_53 = null;
            Private___intnl_SystemSingle_54 = null;
            Private___intnl_SystemSingle_55 = null;
            Private___intnl_SystemSingle_56 = null;
            Private___intnl_SystemSingle_57 = null;
            Private___intnl_SystemSingle_58 = null;
            Private___intnl_SystemSingle_59 = null;
            Private___intnl_SystemInt32_16 = null;
            Private___intnl_SystemInt32_36 = null;
            Private___intnl_SystemInt32_26 = null;
            Private___intnl_SystemInt32_46 = null;
            Private___intnl_SystemUInt32_7 = null;
            Private___refl_typename = null;
            Private___const_SystemBase64FormattingOptions_0 = null;
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
            Private___0_addr__param = null;
            Private___0_v__param = null;
            Private___intnl_SystemSingle_3 = null;
            Private___intnl_SystemUInt16_0 = null;
            Private___this_UnityEngineTransform_0 = null;
            Private___intnl_SystemChar_2 = null;
            Private___1_teamColor__param = null;
            Private___lcl_targetID_SystemInt64_0 = null;
            Private___const_SystemString_1 = null;
            Private___const_SystemSingle_3 = null;
            Private___intnl_SystemDouble_0 = null;
            Private___lcl_idValue_SystemObject_0 = null;
            Private___intnl_UnityEngineVector3_1 = null;
            Private_turnStateSynced = null;
            Private___intnl_SystemBoolean_15 = null;
            Private___intnl_SystemBoolean_25 = null;
            Private___intnl_SystemBoolean_35 = null;
            Private___intnl_SystemBoolean_45 = null;
            Private_teamsSynced = null;
            Private___const_SystemInt32_12 = null;
            Private___const_SystemInt32_32 = null;
            Private___const_SystemInt32_22 = null;
            Private___intnl_SystemInt32_13 = null;
            Private___intnl_SystemInt32_33 = null;
            Private___intnl_SystemInt32_23 = null;
            Private___intnl_SystemInt32_43 = null;
            Private___0___0_decodeVec3Part__ret = null;
            Private___intnl_SystemInt32_18 = null;
            Private___intnl_SystemInt32_38 = null;
            Private___intnl_SystemInt32_28 = null;
            Private___lcl__y_SystemUInt16_1 = null;
            Private___lcl__y_SystemUInt16_0 = null;
            Private___intnl_SystemByte_0 = null;
            Private___0___0_isValidBase64__ret = null;
            Private___const_SystemByte_3 = null;
            Private___0_newGameMode__param = null;
            Private_fourBallCueBallSynced = null;
            Private___intnl_SystemDouble_8 = null;
            Private___const_SystemString_6 = null;
            Private___2_range__param = null;
            Private___0_winnerId__param = null;
            Private___const_SystemUInt32_4 = null;
            Private___0_newTableSkin__param = null;
            Private___gintnl_SystemUInt32_50 = null;
            Private___gintnl_SystemUInt32_40 = null;
            Private___gintnl_SystemUInt32_60 = null;
            Private___gintnl_SystemUInt32_10 = null;
            Private___gintnl_SystemUInt32_30 = null;
            Private___gintnl_SystemUInt32_20 = null;
            Private___intnl_SystemUInt32_2 = null;
            Private___const_SystemInt32_17 = null;
            Private___const_SystemInt32_37 = null;
            Private___const_SystemInt32_27 = null;
            Private___intnl_SystemInt32_10 = null;
            Private___intnl_SystemInt32_30 = null;
            Private___intnl_SystemInt32_20 = null;
            Private___intnl_SystemInt32_40 = null;
            Private___0_start__param = null;
            Private___intnl_SystemByte_8 = null;
            Private___lcl_temp_UnityEngineVector3_0 = null;
            Private___this_UnityEngineGameObject_0 = null;
            Private___1_value__param = null;
            Private_teamIdSynced = null;
            Private_cueBallWSynced = null;
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
            Private___intnl_SystemByte_5 = null;
            Private___intnl_SystemSingle_6 = null;
            Private_tableSkinSynced = null;
            Private_noLockingSynced = null;
            Private___0_newTimer__param = null;
            Private___0_teamColor__param = null;
            Private___intnl_SystemDouble_5 = null;
            Private___const_SystemUInt32_3 = null;
            Private___gintnl_SystemUInt32_58 = null;
            Private___gintnl_SystemUInt32_48 = null;
            Private___gintnl_SystemUInt32_18 = null;
            Private___gintnl_SystemUInt32_38 = null;
            Private___gintnl_SystemUInt32_28 = null;
            Private___const_SystemSingle_5 = null;
            Private___lcl_y_SystemSingle_0 = null;
            Private___intnl_SystemBoolean_10 = null;
            Private___intnl_SystemBoolean_20 = null;
            Private___intnl_SystemBoolean_30 = null;
            Private___intnl_SystemBoolean_40 = null;
            Private___intnl_SystemBoolean_50 = null;
            Private___0_noLockingEnabled__param = null;
            Private___lcl_spec_SystemUInt32_0 = null;
            Private___gintnl_SystemUInt32_55 = null;
            Private___gintnl_SystemUInt32_45 = null;
            Private___gintnl_SystemUInt32_15 = null;
            Private___gintnl_SystemUInt32_35 = null;
            Private___gintnl_SystemUInt32_25 = null;
            Private___intnl_SystemUInt32_1 = null;
            Private___1_range__param = null;
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
            Private___3_teamId__param = null;
            Private___lcl_udonBehaviours_UnityEngineComponentArray_0 = null;
            Private___0___0_isInvalidBase64Char__ret = null;
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
            Private___1_vec__param = null;
            Private___0_vec__param = null;
            Private_lastProcessedPacketId = null;
            Private___lcl_x_SystemSingle_1 = null;
            Private___intnl_SystemByte_6 = null;
            Private___intnl_SystemSingle_5 = null;
            Private___intnl_SystemUInt16_2 = null;
            Private___lcl__r_SystemUInt16_0 = null;
            Private___intnl_VRCUdonUdonBehaviour_0 = null;
            Private___const_SystemString_3 = null;
            Private___this_VRCUdonUdonBehaviour_2 = null;
            Private___this_VRCUdonUdonBehaviour_1 = null;
            Private___this_VRCUdonUdonBehaviour_0 = null;
            Private___intnl_SystemDouble_6 = null;
            Private___const_SystemString_8 = null;
            Private___lcl__x_SystemUInt16_1 = null;
            Private___lcl__x_SystemUInt16_0 = null;
            Private___intnl_SystemBoolean_18 = null;
            Private___intnl_SystemBoolean_28 = null;
            Private___intnl_SystemBoolean_38 = null;
            Private___intnl_SystemBoolean_48 = null;
        }

        #region Getter / Setters AstroUdonVariables  of NetworkingManager

        internal uint? __intnl_SystemUInt32_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_9 != null)
                {
                    return Private___intnl_SystemUInt32_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_9 != null)
                    {
                        Private___intnl_SystemUInt32_9.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_newTableModel__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newTableModel__param != null)
                {
                    return Private___0_newTableModel__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newTableModel__param != null)
                    {
                        Private___0_newTableModel__param.Value = value.Value;
                    }
                }
            }
        }

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

        internal float? __intnl_SystemSingle_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_20 != null)
                {
                    return Private___intnl_SystemSingle_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_20 != null)
                    {
                        Private___intnl_SystemSingle_20.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_21 != null)
                {
                    return Private___intnl_SystemSingle_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_21 != null)
                    {
                        Private___intnl_SystemSingle_21.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_22 != null)
                {
                    return Private___intnl_SystemSingle_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_22 != null)
                    {
                        Private___intnl_SystemSingle_22.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_23 != null)
                {
                    return Private___intnl_SystemSingle_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_23 != null)
                    {
                        Private___intnl_SystemSingle_23.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_24
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_24 != null)
                {
                    return Private___intnl_SystemSingle_24.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_24 != null)
                    {
                        Private___intnl_SystemSingle_24.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_25 != null)
                {
                    return Private___intnl_SystemSingle_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_25 != null)
                    {
                        Private___intnl_SystemSingle_25.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_26
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_26 != null)
                {
                    return Private___intnl_SystemSingle_26.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_26 != null)
                    {
                        Private___intnl_SystemSingle_26.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_27
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_27 != null)
                {
                    return Private___intnl_SystemSingle_27.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_27 != null)
                    {
                        Private___intnl_SystemSingle_27.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_28
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_28 != null)
                {
                    return Private___intnl_SystemSingle_28.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_28 != null)
                    {
                        Private___intnl_SystemSingle_28.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_29
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_29 != null)
                {
                    return Private___intnl_SystemSingle_29.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_29 != null)
                    {
                        Private___intnl_SystemSingle_29.Value = value.Value;
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

        internal int? __intnl_SystemInt32_45
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_45 != null)
                {
                    return Private___intnl_SystemInt32_45.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_45 != null)
                    {
                        Private___intnl_SystemInt32_45.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_4 != null)
                {
                    return Private___intnl_SystemUInt32_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_4 != null)
                    {
                        Private___intnl_SystemUInt32_4.Value = value.Value;
                    }
                }
            }
        }

        internal long? __const_SystemInt64_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt64_0 != null)
                {
                    return Private___const_SystemInt64_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt64_0 != null)
                    {
                        Private___const_SystemInt64_0.Value = value.Value;
                    }
                }
            }
        }

        internal uint? ballsPocketedSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ballsPocketedSynced != null)
                {
                    return Private_ballsPocketedSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_ballsPocketedSynced != null)
                    {
                        Private_ballsPocketedSynced.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? __lcl__b_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl__b_SystemUInt16_0 != null)
                {
                    return Private___lcl__b_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl__b_SystemUInt16_0 != null)
                    {
                        Private___lcl__b_SystemUInt16_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_playerId__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_playerId__param != null)
                {
                    return Private___0_playerId__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_playerId__param != null)
                    {
                        Private___0_playerId__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_ballsPocketed__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_ballsPocketed__param != null)
                {
                    return Private___0_ballsPocketed__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_ballsPocketed__param != null)
                    {
                        Private___0_ballsPocketed__param.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0___0__OnJoinTeam__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0__OnJoinTeam__ret != null)
                {
                    return Private___0___0__OnJoinTeam__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0__OnJoinTeam__ret != null)
                    {
                        Private___0___0__OnJoinTeam__ret.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? cueBallVSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueBallVSynced != null)
                {
                    return Private_cueBallVSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cueBallVSynced != null)
                    {
                        Private_cueBallVSynced.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __const_SystemByte_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemByte_1 != null)
                {
                    return Private___const_SystemByte_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemByte_1 != null)
                    {
                        Private___const_SystemByte_1.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0_cueBallW__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_cueBallW__param != null)
                {
                    return Private___0_cueBallW__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_cueBallW__param != null)
                    {
                        Private___0_cueBallW__param.Value = value.Value;
                    }
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

        internal ushort? __intnl_SystemUInt16_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt16_1 != null)
                {
                    return Private___intnl_SystemUInt16_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt16_1 != null)
                    {
                        Private___intnl_SystemUInt16_1.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_pos__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_pos__param != null)
                {
                    return Private___1_pos__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_pos__param != null)
                    {
                        Private___1_pos__param.Value = value.Value;
                    }
                }
            }
        }

        internal char? __intnl_SystemChar_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemChar_1 != null)
                {
                    return Private___intnl_SystemChar_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemChar_1 != null)
                    {
                        Private___intnl_SystemChar_1.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_pos__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_pos__param != null)
                {
                    return Private___0_pos__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_pos__param != null)
                    {
                        Private___0_pos__param.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_noGuidelineEnabled__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_noGuidelineEnabled__param != null)
                {
                    return Private___0_noGuidelineEnabled__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_noGuidelineEnabled__param != null)
                    {
                        Private___0_noGuidelineEnabled__param.Value = value.Value;
                    }
                }
            }
        }

        internal int? __3_pos__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_pos__param != null)
                {
                    return Private___3_pos__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_pos__param != null)
                    {
                        Private___3_pos__param.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour ownershipManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ownershipManager != null)
                {
                    return Private_ownershipManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ownershipManager != null)
                {
                    Private_ownershipManager.Value = value;
                }
            }
        }

        internal ushort? __0___0_decodeU16__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_decodeU16__ret != null)
                {
                    return Private___0___0_decodeU16__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_decodeU16__ret != null)
                    {
                        Private___0___0_decodeU16__ret.Value = value.Value;
                    }
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

        internal int? __2_pos__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_pos__param != null)
                {
                    return Private___2_pos__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_pos__param != null)
                    {
                        Private___2_pos__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_6 != null)
                {
                    return Private___const_SystemUInt32_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_6 != null)
                    {
                        Private___const_SystemUInt32_6.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_urgent__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_urgent__param != null)
                {
                    return Private___0_urgent__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_urgent__param != null)
                    {
                        Private___0_urgent__param.Value = value.Value;
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

        internal double? __intnl_SystemDouble_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_3 != null)
                {
                    return Private___intnl_SystemDouble_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_3 != null)
                    {
                        Private___intnl_SystemDouble_3.Value = value.Value;
                    }
                }
            }
        }

        internal uint? timerSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerSynced != null)
                {
                    return Private_timerSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timerSynced != null)
                    {
                        Private_timerSynced.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_previewWinningTeam__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_previewWinningTeam__param != null)
                {
                    return Private___0_previewWinningTeam__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_previewWinningTeam__param != null)
                    {
                        Private___0_previewWinningTeam__param.Value = value.Value;
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

        internal int? timerStartSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerStartSynced != null)
                {
                    return Private_timerStartSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timerStartSynced != null)
                    {
                        Private_timerStartSynced.Value = value.Value;
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

        internal float? __intnl_SystemSingle_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_13 != null)
                {
                    return Private___intnl_SystemSingle_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_13 != null)
                    {
                        Private___intnl_SystemSingle_13.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_14 != null)
                {
                    return Private___intnl_SystemSingle_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_14 != null)
                    {
                        Private___intnl_SystemSingle_14.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_15 != null)
                {
                    return Private___intnl_SystemSingle_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_15 != null)
                    {
                        Private___intnl_SystemSingle_15.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_16 != null)
                {
                    return Private___intnl_SystemSingle_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_16 != null)
                    {
                        Private___intnl_SystemSingle_16.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_17 != null)
                {
                    return Private___intnl_SystemSingle_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_17 != null)
                    {
                        Private___intnl_SystemSingle_17.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_18 != null)
                {
                    return Private___intnl_SystemSingle_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_18 != null)
                    {
                        Private___intnl_SystemSingle_18.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_19 != null)
                {
                    return Private___intnl_SystemSingle_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_19 != null)
                    {
                        Private___intnl_SystemSingle_19.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_j_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_j_SystemInt32_0 != null)
                {
                    return Private___lcl_j_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_j_SystemInt32_0 != null)
                    {
                        Private___lcl_j_SystemInt32_0.Value = value.Value;
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

        internal int? __lcl_occurences_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_occurences_SystemInt32_0 != null)
                {
                    return Private___lcl_occurences_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_occurences_SystemInt32_0 != null)
                    {
                        Private___lcl_occurences_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal uint[] __gintnl_SystemUInt32Array_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32Array_0 != null)
                {
                    return Private___gintnl_SystemUInt32Array_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemUInt32Array_0 != null)
                {
                    Private___gintnl_SystemUInt32Array_0.Value = value;
                }
            }
        }

        internal byte? repositionStateSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_repositionStateSynced != null)
                {
                    return Private_repositionStateSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_repositionStateSynced != null)
                    {
                        Private_repositionStateSynced.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_intValue_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_intValue_SystemInt32_0 != null)
                {
                    return Private___lcl_intValue_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_intValue_SystemInt32_0 != null)
                    {
                        Private___lcl_intValue_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_gameMode__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_gameMode__param != null)
                {
                    return Private___0_gameMode__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_gameMode__param != null)
                    {
                        Private___0_gameMode__param.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __intnl_SystemByte_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_3 != null)
                {
                    return Private___intnl_SystemByte_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_3 != null)
                    {
                        Private___intnl_SystemByte_3.Value = value.Value;
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

        internal byte? __const_SystemByte_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemByte_2 != null)
                {
                    return Private___const_SystemByte_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemByte_2 != null)
                    {
                        Private___const_SystemByte_2.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_newPhysicsMode__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newPhysicsMode__param != null)
                {
                    return Private___0_newPhysicsMode__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newPhysicsMode__param != null)
                    {
                        Private___0_newPhysicsMode__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_11 != null)
                {
                    return Private___const_SystemUInt32_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_11 != null)
                    {
                        Private___const_SystemUInt32_11.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_10 != null)
                {
                    return Private___const_SystemUInt32_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_10 != null)
                    {
                        Private___const_SystemUInt32_10.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_13 != null)
                {
                    return Private___const_SystemUInt32_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_13 != null)
                    {
                        Private___const_SystemUInt32_13.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_12 != null)
                {
                    return Private___const_SystemUInt32_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_12 != null)
                    {
                        Private___const_SystemUInt32_12.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_15 != null)
                {
                    return Private___const_SystemUInt32_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_15 != null)
                    {
                        Private___const_SystemUInt32_15.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_14 != null)
                {
                    return Private___const_SystemUInt32_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_14 != null)
                    {
                        Private___const_SystemUInt32_14.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_16 != null)
                {
                    return Private___const_SystemUInt32_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_16 != null)
                    {
                        Private___const_SystemUInt32_16.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_index_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_index_SystemInt32_0 != null)
                {
                    return Private___lcl_index_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_index_SystemInt32_0 != null)
                    {
                        Private___lcl_index_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int[] fourBallScoresSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_fourBallScoresSynced != null)
                {
                    return Private_fourBallScoresSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_fourBallScoresSynced != null)
                {
                    Private_fourBallScoresSynced.Value = value;
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

        internal uint? __const_SystemUInt32_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_5 != null)
                {
                    return Private___const_SystemUInt32_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_5 != null)
                    {
                        Private___const_SystemUInt32_5.Value = value.Value;
                    }
                }
            }
        }

        internal bool? hasBufferedMessages
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hasBufferedMessages != null)
                {
                    return Private_hasBufferedMessages.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hasBufferedMessages != null)
                    {
                        Private_hasBufferedMessages.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_8 != null)
                {
                    return Private___const_SystemUInt32_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_8 != null)
                    {
                        Private___const_SystemUInt32_8.Value = value.Value;
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

        internal bool? noGuidelineSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_noGuidelineSynced != null)
                {
                    return Private_noGuidelineSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_noGuidelineSynced != null)
                    {
                        Private_noGuidelineSynced.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_3 != null)
                {
                    return Private___intnl_SystemUInt32_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_3 != null)
                    {
                        Private___intnl_SystemUInt32_3.Value = value.Value;
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

        internal UnityEngine.Vector3[] ballsPSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ballsPSynced != null)
                {
                    return Private_ballsPSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ballsPSynced != null)
                {
                    Private_ballsPSynced.Value = value;
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

        internal float? __0_range__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_range__param != null)
                {
                    return Private___0_range__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_range__param != null)
                    {
                        Private___0_range__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_fourBallCueBall__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_fourBallCueBall__param != null)
                {
                    return Private___0_fourBallCueBall__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_fourBallCueBall__param != null)
                    {
                        Private___0_fourBallCueBall__param.Value = value.Value;
                    }
                }
            }
        }

        internal byte? tableModelSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableModelSynced != null)
                {
                    return Private_tableModelSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_tableModelSynced != null)
                    {
                        Private_tableModelSynced.Value = value.Value;
                    }
                }
            }
        }

        internal byte? isUrgentSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isUrgentSynced != null)
                {
                    return Private_isUrgentSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isUrgentSynced != null)
                    {
                        Private_isUrgentSynced.Value = value.Value;
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

        internal byte? __intnl_SystemByte_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_4 != null)
                {
                    return Private___intnl_SystemByte_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_4 != null)
                    {
                        Private___intnl_SystemByte_4.Value = value.Value;
                    }
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

        internal ushort? __intnl_SystemUInt16_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt16_4 != null)
                {
                    return Private___intnl_SystemUInt16_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt16_4 != null)
                    {
                        Private___intnl_SystemUInt16_4.Value = value.Value;
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

        internal byte? previewWinningTeamSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_previewWinningTeamSynced != null)
                {
                    return Private_previewWinningTeamSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_previewWinningTeamSynced != null)
                    {
                        Private_previewWinningTeamSynced.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __1_cueBallW__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_cueBallW__param != null)
                {
                    return Private___1_cueBallW__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_cueBallW__param != null)
                    {
                        Private___1_cueBallW__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __1_teamId__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_teamId__param != null)
                {
                    return Private___1_teamId__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_teamId__param != null)
                    {
                        Private___1_teamId__param.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_teamsEnabled__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_teamsEnabled__param != null)
                {
                    return Private___0_teamsEnabled__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_teamsEnabled__param != null)
                    {
                        Private___0_teamsEnabled__param.Value = value.Value;
                    }
                }
            }
        }

        internal double? __intnl_SystemDouble_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_4 != null)
                {
                    return Private___intnl_SystemDouble_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_4 != null)
                    {
                        Private___intnl_SystemDouble_4.Value = value.Value;
                    }
                }
            }
        }

        internal int? __2_teamId__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_teamId__param != null)
                {
                    return Private___2_teamId__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_teamId__param != null)
                    {
                        Private___2_teamId__param.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineComponent_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponent_0 != null)
                {
                    return Private___intnl_UnityEngineComponent_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponent_0 != null)
                {
                    Private___intnl_UnityEngineComponent_0.Value = value;
                }
            }
        }

        internal float? __lcl_y_SystemSingle_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_y_SystemSingle_1 != null)
                {
                    return Private___lcl_y_SystemSingle_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_y_SystemSingle_1 != null)
                    {
                        Private___lcl_y_SystemSingle_1.Value = value.Value;
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

        internal uint? __1_winnerId__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_winnerId__param != null)
                {
                    return Private___1_winnerId__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_winnerId__param != null)
                    {
                        Private___1_winnerId__param.Value = value.Value;
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

        internal float? __intnl_SystemSingle_40
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_40 != null)
                {
                    return Private___intnl_SystemSingle_40.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_40 != null)
                    {
                        Private___intnl_SystemSingle_40.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_41
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_41 != null)
                {
                    return Private___intnl_SystemSingle_41.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_41 != null)
                    {
                        Private___intnl_SystemSingle_41.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_42
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_42 != null)
                {
                    return Private___intnl_SystemSingle_42.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_42 != null)
                    {
                        Private___intnl_SystemSingle_42.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_43
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_43 != null)
                {
                    return Private___intnl_SystemSingle_43.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_43 != null)
                    {
                        Private___intnl_SystemSingle_43.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_44
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_44 != null)
                {
                    return Private___intnl_SystemSingle_44.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_44 != null)
                    {
                        Private___intnl_SystemSingle_44.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_45
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_45 != null)
                {
                    return Private___intnl_SystemSingle_45.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_45 != null)
                    {
                        Private___intnl_SystemSingle_45.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_46
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_46 != null)
                {
                    return Private___intnl_SystemSingle_46.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_46 != null)
                    {
                        Private___intnl_SystemSingle_46.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_47
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_47 != null)
                {
                    return Private___intnl_SystemSingle_47.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_47 != null)
                    {
                        Private___intnl_SystemSingle_47.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_48
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_48 != null)
                {
                    return Private___intnl_SystemSingle_48.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_48 != null)
                    {
                        Private___intnl_SystemSingle_48.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_49
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_49 != null)
                {
                    return Private___intnl_SystemSingle_49.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_49 != null)
                    {
                        Private___intnl_SystemSingle_49.Value = value.Value;
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

        internal uint? __intnl_SystemUInt32_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_6 != null)
                {
                    return Private___intnl_SystemUInt32_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_6 != null)
                    {
                        Private___intnl_SystemUInt32_6.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0__intnlparam != null)
                {
                    return Private___0__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0__intnlparam != null)
                {
                    Private___0__intnlparam.Value = value;
                }
            }
        }

        internal uint? __1_ballsPocketed__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_ballsPocketed__param != null)
                {
                    return Private___1_ballsPocketed__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_ballsPocketed__param != null)
                    {
                        Private___1_ballsPocketed__param.Value = value.Value;
                    }
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

        internal ushort? __intnl_SystemUInt16_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt16_3 != null)
                {
                    return Private___intnl_SystemUInt16_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt16_3 != null)
                    {
                        Private___intnl_SystemUInt16_3.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_table___param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_table___param != null)
                {
                    return Private___0_table___param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_table___param != null)
                {
                    Private___0_table___param.Value = value;
                }
            }
        }

        internal byte? gameStateSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameStateSynced != null)
                {
                    return Private_gameStateSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameStateSynced != null)
                    {
                        Private_gameStateSynced.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_1 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_1 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_1.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] playerSlots
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerSlots != null)
                {
                    return Private_playerSlots.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerSlots != null)
                {
                    Private_playerSlots.Value = value;
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

        internal bool? __0_consumeReposition__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_consumeReposition__param != null)
                {
                    return Private___0_consumeReposition__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_consumeReposition__param != null)
                    {
                        Private___0_consumeReposition__param.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_addr__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_addr__param != null)
                {
                    return Private___1_addr__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_addr__param != null)
                    {
                        Private___1_addr__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_repositionState__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_repositionState__param != null)
                {
                    return Private___0_repositionState__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_repositionState__param != null)
                    {
                        Private___0_repositionState__param.Value = value.Value;
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

        internal double? __intnl_SystemDouble_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_1 != null)
                {
                    return Private___intnl_SystemDouble_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_1 != null)
                    {
                        Private___intnl_SystemDouble_1.Value = value.Value;
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

        internal ushort? __lcl__a_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl__a_SystemUInt16_0 != null)
                {
                    return Private___lcl__a_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl__a_SystemUInt16_0 != null)
                    {
                        Private___lcl__a_SystemUInt16_0.Value = value.Value;
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

        internal UnityEngine.Component[] __intnl_UnityEngineComponentArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponentArray_0 != null)
                {
                    return Private___intnl_UnityEngineComponentArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponentArray_0 != null)
                {
                    Private___intnl_UnityEngineComponentArray_0.Value = value;
                }
            }
        }

        internal float? __intnl_SystemSingle_30
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_30 != null)
                {
                    return Private___intnl_SystemSingle_30.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_30 != null)
                    {
                        Private___intnl_SystemSingle_30.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_31
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_31 != null)
                {
                    return Private___intnl_SystemSingle_31.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_31 != null)
                    {
                        Private___intnl_SystemSingle_31.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_32 != null)
                {
                    return Private___intnl_SystemSingle_32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_32 != null)
                    {
                        Private___intnl_SystemSingle_32.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_33
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_33 != null)
                {
                    return Private___intnl_SystemSingle_33.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_33 != null)
                    {
                        Private___intnl_SystemSingle_33.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_34
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_34 != null)
                {
                    return Private___intnl_SystemSingle_34.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_34 != null)
                    {
                        Private___intnl_SystemSingle_34.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_35
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_35 != null)
                {
                    return Private___intnl_SystemSingle_35.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_35 != null)
                    {
                        Private___intnl_SystemSingle_35.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_36
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_36 != null)
                {
                    return Private___intnl_SystemSingle_36.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_36 != null)
                    {
                        Private___intnl_SystemSingle_36.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_37
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_37 != null)
                {
                    return Private___intnl_SystemSingle_37.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_37 != null)
                    {
                        Private___intnl_SystemSingle_37.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_38
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_38 != null)
                {
                    return Private___intnl_SystemSingle_38.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_38 != null)
                    {
                        Private___intnl_SystemSingle_38.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_39
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_39 != null)
                {
                    return Private___intnl_SystemSingle_39.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_39 != null)
                    {
                        Private___intnl_SystemSingle_39.Value = value.Value;
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

        internal int? __intnl_SystemInt32_44
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_44 != null)
                {
                    return Private___intnl_SystemInt32_44.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_44 != null)
                    {
                        Private___intnl_SystemInt32_44.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_5 != null)
                {
                    return Private___intnl_SystemUInt32_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_5 != null)
                    {
                        Private___intnl_SystemUInt32_5.Value = value.Value;
                    }
                }
            }
        }

        internal int? packetIdSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_packetIdSynced != null)
                {
                    return Private_packetIdSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_packetIdSynced != null)
                    {
                        Private_packetIdSynced.Value = value.Value;
                    }
                }
            }
        }

        internal byte? winningTeamSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_winningTeamSynced != null)
                {
                    return Private_winningTeamSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_winningTeamSynced != null)
                    {
                        Private_winningTeamSynced.Value = value.Value;
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

        internal byte? __intnl_SystemByte_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_1 != null)
                {
                    return Private___intnl_SystemByte_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_1 != null)
                    {
                        Private___intnl_SystemByte_1.Value = value.Value;
                    }
                }
            }
        }

        internal byte? teamColorSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamColorSynced != null)
                {
                    return Private_teamColorSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teamColorSynced != null)
                    {
                        Private_teamColorSynced.Value = value.Value;
                    }
                }
            }
        }

        internal float? __4_range__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_range__param != null)
                {
                    return Private___4_range__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_range__param != null)
                    {
                        Private___4_range__param.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __const_SystemByte_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemByte_0 != null)
                {
                    return Private___const_SystemByte_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemByte_0 != null)
                    {
                        Private___const_SystemByte_0.Value = value.Value;
                    }
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

        internal char? __intnl_SystemChar_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemChar_0 != null)
                {
                    return Private___intnl_SystemChar_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemChar_0 != null)
                    {
                        Private___intnl_SystemChar_0.Value = value.Value;
                    }
                }
            }
        }

        internal string[] playerNamesSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerNamesSynced != null)
                {
                    return Private_playerNamesSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerNamesSynced != null)
                {
                    Private_playerNamesSynced.Value = value;
                }
            }
        }

        internal ushort? __lcl__z_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl__z_SystemUInt16_0 != null)
                {
                    return Private___lcl__z_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl__z_SystemUInt16_0 != null)
                    {
                        Private___lcl__z_SystemUInt16_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0_cueBallV__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_cueBallV__param != null)
                {
                    return Private___0_cueBallV__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_cueBallV__param != null)
                    {
                        Private___0_cueBallV__param.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_isTableOpen__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_isTableOpen__param != null)
                {
                    return Private___0_isTableOpen__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_isTableOpen__param != null)
                    {
                        Private___0_isTableOpen__param.Value = value.Value;
                    }
                }
            }
        }

        internal double? __intnl_SystemDouble_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_9 != null)
                {
                    return Private___intnl_SystemDouble_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_9 != null)
                    {
                        Private___intnl_SystemDouble_9.Value = value.Value;
                    }
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

        internal UnityEngine.Vector3? __0___0_decodeVec3Full__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_decodeVec3Full__ret != null)
                {
                    return Private___0___0_decodeVec3Full__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_decodeVec3Full__ret != null)
                    {
                        Private___0___0_decodeVec3Full__ret.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_7 != null)
                {
                    return Private___const_SystemUInt32_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_7 != null)
                    {
                        Private___const_SystemUInt32_7.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_turnStateLocal__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_turnStateLocal__param != null)
                {
                    return Private___0_turnStateLocal__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_turnStateLocal__param != null)
                    {
                        Private___0_turnStateLocal__param.Value = value.Value;
                    }
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

        internal double? __intnl_SystemDouble_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_2 != null)
                {
                    return Private___intnl_SystemDouble_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_2 != null)
                    {
                        Private___intnl_SystemDouble_2.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_playerId__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_playerId__param != null)
                {
                    return Private___1_playerId__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_playerId__param != null)
                    {
                        Private___1_playerId__param.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_z_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_z_SystemSingle_0 != null)
                {
                    return Private___lcl_z_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_z_SystemSingle_0 != null)
                    {
                        Private___lcl_z_SystemSingle_0.Value = value.Value;
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

        internal bool? isTableOpenSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isTableOpenSynced != null)
                {
                    return Private_isTableOpenSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isTableOpenSynced != null)
                    {
                        Private_isTableOpenSynced.Value = value.Value;
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

        internal byte? __intnl_SystemByte_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_9 != null)
                {
                    return Private___intnl_SystemByte_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_9 != null)
                    {
                        Private___intnl_SystemByte_9.Value = value.Value;
                    }
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

        internal byte? __intnl_SystemByte_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_2 != null)
                {
                    return Private___intnl_SystemByte_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_2 != null)
                    {
                        Private___intnl_SystemByte_2.Value = value.Value;
                    }
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

        internal ushort? __intnl_SystemUInt16_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt16_6 != null)
                {
                    return Private___intnl_SystemUInt16_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt16_6 != null)
                    {
                        Private___intnl_SystemUInt16_6.Value = value.Value;
                    }
                }
            }
        }

        internal long? __intnl_SystemInt64_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt64_0 != null)
                {
                    return Private___intnl_SystemInt64_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt64_0 != null)
                    {
                        Private___intnl_SystemInt64_0.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_21 != null)
                {
                    return Private___intnl_SystemUInt32_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_21 != null)
                    {
                        Private___intnl_SystemUInt32_21.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_20 != null)
                {
                    return Private___intnl_SystemUInt32_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_20 != null)
                    {
                        Private___intnl_SystemUInt32_20.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_23 != null)
                {
                    return Private___intnl_SystemUInt32_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_23 != null)
                    {
                        Private___intnl_SystemUInt32_23.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_22 != null)
                {
                    return Private___intnl_SystemUInt32_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_22 != null)
                    {
                        Private___intnl_SystemUInt32_22.Value = value.Value;
                    }
                }
            }
        }

        internal float? __3_range__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_range__param != null)
                {
                    return Private___3_range__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_range__param != null)
                    {
                        Private___3_range__param.Value = value.Value;
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

        internal uint? __0_defaultBallsPocketed__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_defaultBallsPocketed__param != null)
                {
                    return Private___0_defaultBallsPocketed__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_defaultBallsPocketed__param != null)
                    {
                        Private___0_defaultBallsPocketed__param.Value = value.Value;
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

        internal ushort? __lcl__g_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl__g_SystemUInt16_0 != null)
                {
                    return Private___lcl__g_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl__g_SystemUInt16_0 != null)
                    {
                        Private___lcl__g_SystemUInt16_0.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0___0_decodeF32__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_decodeF32__ret != null)
                {
                    return Private___0___0_decodeF32__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_decodeF32__ret != null)
                    {
                        Private___0___0_decodeF32__ret.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_2 != null)
                {
                    return Private___const_SystemUInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_2 != null)
                    {
                        Private___const_SystemUInt32_2.Value = value.Value;
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

        internal uint? __const_SystemUInt32_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_9 != null)
                {
                    return Private___const_SystemUInt32_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_9 != null)
                    {
                        Private___const_SystemUInt32_9.Value = value.Value;
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

        internal byte? gameModeSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameModeSynced != null)
                {
                    return Private_gameModeSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gameModeSynced != null)
                    {
                        Private_gameModeSynced.Value = value.Value;
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

        internal uint? __intnl_SystemUInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_0 != null)
                {
                    return Private___intnl_SystemUInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_0 != null)
                    {
                        Private___intnl_SystemUInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_i_SystemInt32_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_i_SystemInt32_8 != null)
                {
                    return Private___lcl_i_SystemInt32_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_i_SystemInt32_8 != null)
                    {
                        Private___lcl_i_SystemInt32_8.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_i_SystemInt32_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_i_SystemInt32_1 != null)
                {
                    return Private___lcl_i_SystemInt32_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_i_SystemInt32_1 != null)
                    {
                        Private___lcl_i_SystemInt32_1.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_i_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_i_SystemInt32_0 != null)
                {
                    return Private___lcl_i_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_i_SystemInt32_0 != null)
                    {
                        Private___lcl_i_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_i_SystemInt32_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_i_SystemInt32_3 != null)
                {
                    return Private___lcl_i_SystemInt32_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_i_SystemInt32_3 != null)
                    {
                        Private___lcl_i_SystemInt32_3.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_i_SystemInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_i_SystemInt32_2 != null)
                {
                    return Private___lcl_i_SystemInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_i_SystemInt32_2 != null)
                    {
                        Private___lcl_i_SystemInt32_2.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_i_SystemInt32_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_i_SystemInt32_5 != null)
                {
                    return Private___lcl_i_SystemInt32_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_i_SystemInt32_5 != null)
                    {
                        Private___lcl_i_SystemInt32_5.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_i_SystemInt32_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_i_SystemInt32_4 != null)
                {
                    return Private___lcl_i_SystemInt32_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_i_SystemInt32_4 != null)
                    {
                        Private___lcl_i_SystemInt32_4.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_i_SystemInt32_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_i_SystemInt32_7 != null)
                {
                    return Private___lcl_i_SystemInt32_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_i_SystemInt32_7 != null)
                    {
                        Private___lcl_i_SystemInt32_7.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_i_SystemInt32_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_i_SystemInt32_6 != null)
                {
                    return Private___lcl_i_SystemInt32_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_i_SystemInt32_6 != null)
                    {
                        Private___lcl_i_SystemInt32_6.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour __lcl_behaviour_VRCUdonUdonBehaviour_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_0 != null)
                {
                    return Private___lcl_behaviour_VRCUdonUdonBehaviour_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_0 != null)
                {
                    Private___lcl_behaviour_VRCUdonUdonBehaviour_0.Value = value;
                }
            }
        }

        internal byte? __intnl_SystemByte_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_11 != null)
                {
                    return Private___intnl_SystemByte_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_11 != null)
                    {
                        Private___intnl_SystemByte_11.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __intnl_SystemByte_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_10 != null)
                {
                    return Private___intnl_SystemByte_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_10 != null)
                    {
                        Private___intnl_SystemByte_10.Value = value.Value;
                    }
                }
            }
        }

        internal int? __1_start__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_start__param != null)
                {
                    return Private___1_start__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_start__param != null)
                    {
                        Private___1_start__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __lcl_state_SystemUInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_state_SystemUInt32_0 != null)
                {
                    return Private___lcl_state_SystemUInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_state_SystemUInt32_0 != null)
                    {
                        Private___lcl_state_SystemUInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_teamId__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_teamId__param != null)
                {
                    return Private___0_teamId__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_teamId__param != null)
                    {
                        Private___0_teamId__param.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_x_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_x_SystemSingle_0 != null)
                {
                    return Private___lcl_x_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_x_SystemSingle_0 != null)
                    {
                        Private___lcl_x_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __intnl_SystemByte_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_7 != null)
                {
                    return Private___intnl_SystemByte_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_7 != null)
                    {
                        Private___intnl_SystemByte_7.Value = value.Value;
                    }
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

        internal ushort? __intnl_SystemUInt16_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt16_5 != null)
                {
                    return Private___intnl_SystemUInt16_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt16_5 != null)
                    {
                        Private___intnl_SystemUInt16_5.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __1__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1__intnlparam != null)
                {
                    return Private___1__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1__intnlparam != null)
                {
                    Private___1__intnlparam.Value = value;
                }
            }
        }

        internal byte? physicsModeSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_physicsModeSynced != null)
                {
                    return Private_physicsModeSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_physicsModeSynced != null)
                    {
                        Private_physicsModeSynced.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_19 != null)
                {
                    return Private___intnl_SystemUInt32_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_19 != null)
                    {
                        Private___intnl_SystemUInt32_19.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_18 != null)
                {
                    return Private___intnl_SystemUInt32_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_18 != null)
                    {
                        Private___intnl_SystemUInt32_18.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_11 != null)
                {
                    return Private___intnl_SystemUInt32_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_11 != null)
                    {
                        Private___intnl_SystemUInt32_11.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_10 != null)
                {
                    return Private___intnl_SystemUInt32_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_10 != null)
                    {
                        Private___intnl_SystemUInt32_10.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_13 != null)
                {
                    return Private___intnl_SystemUInt32_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_13 != null)
                    {
                        Private___intnl_SystemUInt32_13.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_12 != null)
                {
                    return Private___intnl_SystemUInt32_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_12 != null)
                    {
                        Private___intnl_SystemUInt32_12.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_15 != null)
                {
                    return Private___intnl_SystemUInt32_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_15 != null)
                    {
                        Private___intnl_SystemUInt32_15.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_14 != null)
                {
                    return Private___intnl_SystemUInt32_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_14 != null)
                    {
                        Private___intnl_SystemUInt32_14.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_17 != null)
                {
                    return Private___intnl_SystemUInt32_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_17 != null)
                    {
                        Private___intnl_SystemUInt32_17.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_16 != null)
                {
                    return Private___intnl_SystemUInt32_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_16 != null)
                    {
                        Private___intnl_SystemUInt32_16.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __0___0_decodeColor__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_decodeColor__ret != null)
                {
                    return Private___0___0_decodeColor__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_decodeColor__ret != null)
                    {
                        Private___0___0_decodeColor__ret.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __1_cueBallV__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_cueBallV__param != null)
                {
                    return Private___1_cueBallV__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_cueBallV__param != null)
                    {
                        Private___1_cueBallV__param.Value = value.Value;
                    }
                }
            }
        }

        internal double? __intnl_SystemDouble_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_7 != null)
                {
                    return Private___intnl_SystemDouble_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_7 != null)
                    {
                        Private___intnl_SystemDouble_7.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __lcl_timerSetting_SystemUInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_timerSetting_SystemUInt32_0 != null)
                {
                    return Private___lcl_timerSetting_SystemUInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_timerSetting_SystemUInt32_0 != null)
                    {
                        Private___lcl_timerSetting_SystemUInt32_0.Value = value.Value;
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

        internal uint? __const_SystemUInt32_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_1 != null)
                {
                    return Private___const_SystemUInt32_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_1 != null)
                    {
                        Private___const_SystemUInt32_1.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_8 != null)
                {
                    return Private___intnl_SystemUInt32_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_8 != null)
                    {
                        Private___intnl_SystemUInt32_8.Value = value.Value;
                    }
                }
            }
        }

        internal int? stateIdSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_stateIdSynced != null)
                {
                    return Private_stateIdSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_stateIdSynced != null)
                    {
                        Private_stateIdSynced.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour table
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_table != null)
                {
                    return Private_table.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_table != null)
                {
                    Private_table.Value = value;
                }
            }
        }

        internal bool? __lcl_registrationsChanged_SystemBoolean_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_registrationsChanged_SystemBoolean_0 != null)
                {
                    return Private___lcl_registrationsChanged_SystemBoolean_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_registrationsChanged_SystemBoolean_0 != null)
                    {
                        Private___lcl_registrationsChanged_SystemBoolean_0.Value = value.Value;
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

        internal int? __0_stateIdLocal__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_stateIdLocal__param != null)
                {
                    return Private___0_stateIdLocal__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_stateIdLocal__param != null)
                    {
                        Private___0_stateIdLocal__param.Value = value.Value;
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

        internal float? __intnl_SystemSingle_50
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_50 != null)
                {
                    return Private___intnl_SystemSingle_50.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_50 != null)
                    {
                        Private___intnl_SystemSingle_50.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_51
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_51 != null)
                {
                    return Private___intnl_SystemSingle_51.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_51 != null)
                    {
                        Private___intnl_SystemSingle_51.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_52
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_52 != null)
                {
                    return Private___intnl_SystemSingle_52.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_52 != null)
                    {
                        Private___intnl_SystemSingle_52.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_53
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_53 != null)
                {
                    return Private___intnl_SystemSingle_53.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_53 != null)
                    {
                        Private___intnl_SystemSingle_53.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_54
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_54 != null)
                {
                    return Private___intnl_SystemSingle_54.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_54 != null)
                    {
                        Private___intnl_SystemSingle_54.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_55
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_55 != null)
                {
                    return Private___intnl_SystemSingle_55.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_55 != null)
                    {
                        Private___intnl_SystemSingle_55.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_56
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_56 != null)
                {
                    return Private___intnl_SystemSingle_56.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_56 != null)
                    {
                        Private___intnl_SystemSingle_56.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_57
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_57 != null)
                {
                    return Private___intnl_SystemSingle_57.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_57 != null)
                    {
                        Private___intnl_SystemSingle_57.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_58
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_58 != null)
                {
                    return Private___intnl_SystemSingle_58.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_58 != null)
                    {
                        Private___intnl_SystemSingle_58.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_59
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_59 != null)
                {
                    return Private___intnl_SystemSingle_59.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_59 != null)
                    {
                        Private___intnl_SystemSingle_59.Value = value.Value;
                    }
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

        internal int? __intnl_SystemInt32_46
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_46 != null)
                {
                    return Private___intnl_SystemInt32_46.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_46 != null)
                    {
                        Private___intnl_SystemInt32_46.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __intnl_SystemUInt32_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_7 != null)
                {
                    return Private___intnl_SystemUInt32_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_7 != null)
                    {
                        Private___intnl_SystemUInt32_7.Value = value.Value;
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

        internal System.Base64FormattingOptions? __const_SystemBase64FormattingOptions_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemBase64FormattingOptions_0 != null)
                {
                    return Private___const_SystemBase64FormattingOptions_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemBase64FormattingOptions_0 != null)
                    {
                        Private___const_SystemBase64FormattingOptions_0.Value = value.Value;
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

        internal int? __0_addr__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_addr__param != null)
                {
                    return Private___0_addr__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_addr__param != null)
                    {
                        Private___0_addr__param.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? __0_v__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_v__param != null)
                {
                    return Private___0_v__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_v__param != null)
                    {
                        Private___0_v__param.Value = value.Value;
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

        internal UnityEngine.Transform __this_UnityEngineTransform_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_UnityEngineTransform_0 != null)
                {
                    return Private___this_UnityEngineTransform_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_UnityEngineTransform_0 != null)
                {
                    Private___this_UnityEngineTransform_0.Value = value;
                }
            }
        }

        internal char? __intnl_SystemChar_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemChar_2 != null)
                {
                    return Private___intnl_SystemChar_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemChar_2 != null)
                    {
                        Private___intnl_SystemChar_2.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __1_teamColor__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_teamColor__param != null)
                {
                    return Private___1_teamColor__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_teamColor__param != null)
                    {
                        Private___1_teamColor__param.Value = value.Value;
                    }
                }
            }
        }

        internal long? __lcl_targetID_SystemInt64_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_targetID_SystemInt64_0 != null)
                {
                    return Private___lcl_targetID_SystemInt64_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_targetID_SystemInt64_0 != null)
                    {
                        Private___lcl_targetID_SystemInt64_0.Value = value.Value;
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

        internal double? __intnl_SystemDouble_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_0 != null)
                {
                    return Private___intnl_SystemDouble_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_0 != null)
                    {
                        Private___intnl_SystemDouble_0.Value = value.Value;
                    }
                }
            }
        }

        internal long? __lcl_idValue_SystemObject_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_idValue_SystemObject_0 != null)
                {
                    return Private___lcl_idValue_SystemObject_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_idValue_SystemObject_0 != null)
                    {
                        Private___lcl_idValue_SystemObject_0.Value = value.Value;
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

        internal byte? turnStateSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_turnStateSynced != null)
                {
                    return Private_turnStateSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_turnStateSynced != null)
                    {
                        Private_turnStateSynced.Value = value.Value;
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

        internal bool? teamsSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamsSynced != null)
                {
                    return Private_teamsSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teamsSynced != null)
                    {
                        Private_teamsSynced.Value = value.Value;
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

        internal int? __intnl_SystemInt32_43
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_43 != null)
                {
                    return Private___intnl_SystemInt32_43.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_43 != null)
                    {
                        Private___intnl_SystemInt32_43.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0___0_decodeVec3Part__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_decodeVec3Part__ret != null)
                {
                    return Private___0___0_decodeVec3Part__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_decodeVec3Part__ret != null)
                    {
                        Private___0___0_decodeVec3Part__ret.Value = value.Value;
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

        internal ushort? __lcl__y_SystemUInt16_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl__y_SystemUInt16_1 != null)
                {
                    return Private___lcl__y_SystemUInt16_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl__y_SystemUInt16_1 != null)
                    {
                        Private___lcl__y_SystemUInt16_1.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? __lcl__y_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl__y_SystemUInt16_0 != null)
                {
                    return Private___lcl__y_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl__y_SystemUInt16_0 != null)
                    {
                        Private___lcl__y_SystemUInt16_0.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __intnl_SystemByte_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_0 != null)
                {
                    return Private___intnl_SystemByte_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_0 != null)
                    {
                        Private___intnl_SystemByte_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0___0_isValidBase64__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_isValidBase64__ret != null)
                {
                    return Private___0___0_isValidBase64__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_isValidBase64__ret != null)
                    {
                        Private___0___0_isValidBase64__ret.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __const_SystemByte_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemByte_3 != null)
                {
                    return Private___const_SystemByte_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemByte_3 != null)
                    {
                        Private___const_SystemByte_3.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_newGameMode__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newGameMode__param != null)
                {
                    return Private___0_newGameMode__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newGameMode__param != null)
                    {
                        Private___0_newGameMode__param.Value = value.Value;
                    }
                }
            }
        }

        internal byte? fourBallCueBallSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_fourBallCueBallSynced != null)
                {
                    return Private_fourBallCueBallSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_fourBallCueBallSynced != null)
                    {
                        Private_fourBallCueBallSynced.Value = value.Value;
                    }
                }
            }
        }

        internal double? __intnl_SystemDouble_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_8 != null)
                {
                    return Private___intnl_SystemDouble_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_8 != null)
                    {
                        Private___intnl_SystemDouble_8.Value = value.Value;
                    }
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

        internal float? __2_range__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_range__param != null)
                {
                    return Private___2_range__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_range__param != null)
                    {
                        Private___2_range__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_winnerId__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_winnerId__param != null)
                {
                    return Private___0_winnerId__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_winnerId__param != null)
                    {
                        Private___0_winnerId__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_4 != null)
                {
                    return Private___const_SystemUInt32_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_4 != null)
                    {
                        Private___const_SystemUInt32_4.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __0_newTableSkin__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newTableSkin__param != null)
                {
                    return Private___0_newTableSkin__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newTableSkin__param != null)
                    {
                        Private___0_newTableSkin__param.Value = value.Value;
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

        internal uint? __intnl_SystemUInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_2 != null)
                {
                    return Private___intnl_SystemUInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_2 != null)
                    {
                        Private___intnl_SystemUInt32_2.Value = value.Value;
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

        internal int? __0_start__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_start__param != null)
                {
                    return Private___0_start__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_start__param != null)
                    {
                        Private___0_start__param.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __intnl_SystemByte_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_8 != null)
                {
                    return Private___intnl_SystemByte_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_8 != null)
                    {
                        Private___intnl_SystemByte_8.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __lcl_temp_UnityEngineVector3_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_temp_UnityEngineVector3_0 != null)
                {
                    return Private___lcl_temp_UnityEngineVector3_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_temp_UnityEngineVector3_0 != null)
                    {
                        Private___lcl_temp_UnityEngineVector3_0.Value = value.Value;
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

        internal char? __1_value__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_value__param != null)
                {
                    return Private___1_value__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_value__param != null)
                    {
                        Private___1_value__param.Value = value.Value;
                    }
                }
            }
        }

        internal byte? teamIdSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_teamIdSynced != null)
                {
                    return Private_teamIdSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_teamIdSynced != null)
                    {
                        Private_teamIdSynced.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? cueBallWSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueBallWSynced != null)
                {
                    return Private_cueBallWSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cueBallWSynced != null)
                    {
                        Private_cueBallWSynced.Value = value.Value;
                    }
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

        internal byte? __intnl_SystemByte_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_5 != null)
                {
                    return Private___intnl_SystemByte_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_5 != null)
                    {
                        Private___intnl_SystemByte_5.Value = value.Value;
                    }
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

        internal byte? tableSkinSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableSkinSynced != null)
                {
                    return Private_tableSkinSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_tableSkinSynced != null)
                    {
                        Private_tableSkinSynced.Value = value.Value;
                    }
                }
            }
        }

        internal bool? noLockingSynced
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_noLockingSynced != null)
                {
                    return Private_noLockingSynced.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_noLockingSynced != null)
                    {
                        Private_noLockingSynced.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_newTimer__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newTimer__param != null)
                {
                    return Private___0_newTimer__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newTimer__param != null)
                    {
                        Private___0_newTimer__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_teamColor__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_teamColor__param != null)
                {
                    return Private___0_teamColor__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_teamColor__param != null)
                    {
                        Private___0_teamColor__param.Value = value.Value;
                    }
                }
            }
        }

        internal double? __intnl_SystemDouble_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_5 != null)
                {
                    return Private___intnl_SystemDouble_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_5 != null)
                    {
                        Private___intnl_SystemDouble_5.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __const_SystemUInt32_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemUInt32_3 != null)
                {
                    return Private___const_SystemUInt32_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemUInt32_3 != null)
                    {
                        Private___const_SystemUInt32_3.Value = value.Value;
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

        internal float? __const_SystemSingle_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_5 != null)
                {
                    return Private___const_SystemSingle_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_5 != null)
                    {
                        Private___const_SystemSingle_5.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_y_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_y_SystemSingle_0 != null)
                {
                    return Private___lcl_y_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_y_SystemSingle_0 != null)
                    {
                        Private___lcl_y_SystemSingle_0.Value = value.Value;
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

        internal bool? __0_noLockingEnabled__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_noLockingEnabled__param != null)
                {
                    return Private___0_noLockingEnabled__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_noLockingEnabled__param != null)
                    {
                        Private___0_noLockingEnabled__param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __lcl_spec_SystemUInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_spec_SystemUInt32_0 != null)
                {
                    return Private___lcl_spec_SystemUInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_spec_SystemUInt32_0 != null)
                    {
                        Private___lcl_spec_SystemUInt32_0.Value = value.Value;
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

        internal uint? __intnl_SystemUInt32_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt32_1 != null)
                {
                    return Private___intnl_SystemUInt32_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt32_1 != null)
                    {
                        Private___intnl_SystemUInt32_1.Value = value.Value;
                    }
                }
            }
        }

        internal float? __1_range__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_range__param != null)
                {
                    return Private___1_range__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_range__param != null)
                    {
                        Private___1_range__param.Value = value.Value;
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

        internal uint? __3_teamId__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_teamId__param != null)
                {
                    return Private___3_teamId__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_teamId__param != null)
                    {
                        Private___3_teamId__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __lcl_udonBehaviours_UnityEngineComponentArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_udonBehaviours_UnityEngineComponentArray_0 != null)
                {
                    return Private___lcl_udonBehaviours_UnityEngineComponentArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_udonBehaviours_UnityEngineComponentArray_0 != null)
                {
                    Private___lcl_udonBehaviours_UnityEngineComponentArray_0.Value = value;
                }
            }
        }

        internal bool? __0___0_isInvalidBase64Char__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_isInvalidBase64Char__ret != null)
                {
                    return Private___0___0_isInvalidBase64Char__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_isInvalidBase64Char__ret != null)
                    {
                        Private___0___0_isInvalidBase64Char__ret.Value = value.Value;
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

        internal UnityEngine.Vector3? __1_vec__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_vec__param != null)
                {
                    return Private___1_vec__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_vec__param != null)
                    {
                        Private___1_vec__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0_vec__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_vec__param != null)
                {
                    return Private___0_vec__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_vec__param != null)
                    {
                        Private___0_vec__param.Value = value.Value;
                    }
                }
            }
        }

        internal int? lastProcessedPacketId
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lastProcessedPacketId != null)
                {
                    return Private_lastProcessedPacketId.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lastProcessedPacketId != null)
                    {
                        Private_lastProcessedPacketId.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_x_SystemSingle_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_x_SystemSingle_1 != null)
                {
                    return Private___lcl_x_SystemSingle_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_x_SystemSingle_1 != null)
                    {
                        Private___lcl_x_SystemSingle_1.Value = value.Value;
                    }
                }
            }
        }

        internal byte? __intnl_SystemByte_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemByte_6 != null)
                {
                    return Private___intnl_SystemByte_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemByte_6 != null)
                    {
                        Private___intnl_SystemByte_6.Value = value.Value;
                    }
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

        internal ushort? __intnl_SystemUInt16_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemUInt16_2 != null)
                {
                    return Private___intnl_SystemUInt16_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemUInt16_2 != null)
                    {
                        Private___intnl_SystemUInt16_2.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? __lcl__r_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl__r_SystemUInt16_0 != null)
                {
                    return Private___lcl__r_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl__r_SystemUInt16_0 != null)
                    {
                        Private___lcl__r_SystemUInt16_0.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_0 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_0 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_0.Value = value;
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

        internal double? __intnl_SystemDouble_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDouble_6 != null)
                {
                    return Private___intnl_SystemDouble_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDouble_6 != null)
                    {
                        Private___intnl_SystemDouble_6.Value = value.Value;
                    }
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

        internal ushort? __lcl__x_SystemUInt16_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl__x_SystemUInt16_1 != null)
                {
                    return Private___lcl__x_SystemUInt16_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl__x_SystemUInt16_1 != null)
                    {
                        Private___lcl__x_SystemUInt16_1.Value = value.Value;
                    }
                }
            }
        }

        internal ushort? __lcl__x_SystemUInt16_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl__x_SystemUInt16_0 != null)
                {
                    return Private___lcl__x_SystemUInt16_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl__x_SystemUInt16_0 != null)
                    {
                        Private___lcl__x_SystemUInt16_0.Value = value.Value;
                    }
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

        #endregion Getter / Setters AstroUdonVariables  of NetworkingManager

        #region AstroUdonVariables  of NetworkingManager

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___0_newTableModel__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___const_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private_ballsPocketedSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___lcl__b_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_playerId__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_ballsPocketed__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0___0__OnJoinTeam__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_cueBallVSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___const_SystemByte_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___0_cueBallW__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___intnl_SystemUInt16_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___1_pos__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char> Private___intnl_SystemChar_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_pos__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_noGuidelineEnabled__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___3_pos__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_ownershipManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___0___0_decodeU16__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___2_pos__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_urgent__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private_timerSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___0_previewWinningTeam__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_timerStartSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_j_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_occurences_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint[]> Private___gintnl_SystemUInt32Array_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_repositionStateSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_intValue_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_gameMode__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<byte> Private___const_SystemByte_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___0_newPhysicsMode__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_index_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int[]> Private_fourBallScoresSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_hasBufferedMessages { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_noGuidelineSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3[]> Private_ballsPSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget> Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___0_range__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_fourBallCueBall__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_tableModelSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_isUrgentSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<byte> Private___intnl_SystemByte_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___intnl_SystemUInt16_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_previewWinningTeamSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___1_cueBallW__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___1_teamId__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_teamsEnabled__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___2_teamId__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineComponent_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_y_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___1_winnerId__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___const_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___1_ballsPocketed__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___intnl_SystemUInt16_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_table___param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_gameStateSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private_playerSlots { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_consumeReposition__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___1_addr__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_repositionState__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___lcl__a_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___intnl_UnityEngineComponentArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_packetIdSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_winningTeamSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_teamColorSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___4_range__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___const_SystemByte_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char> Private___intnl_SystemChar_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string[]> Private_playerNamesSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___lcl__z_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___0_cueBallV__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_isTableOpen__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___0___0_decodeVec3Full__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___0_turnStateLocal__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___1_playerId__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_z_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_61 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_isTableOpenSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___intnl_SystemUInt16_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___intnl_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___3_range__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_defaultBallsPocketed__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___lcl__g_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___0___0_decodeF32__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_gameModeSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_62 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_behaviour_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___1_start__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___lcl_state_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_teamId__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_x_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___intnl_SystemUInt16_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___1__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_physicsModeSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___0___0_decodeColor__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___1_cueBallV__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___lcl_timerSetting_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_stateIdSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_table { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___lcl_registrationsChanged_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_stateIdLocal__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Base64FormattingOptions> Private___const_SystemBase64FormattingOptions_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private___0_addr__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___0_v__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___intnl_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___this_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char> Private___intnl_SystemChar_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___1_teamColor__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_targetID_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_idValue_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_turnStateSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_teamsSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___0___0_decodeVec3Part__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___lcl__y_SystemUInt16_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___lcl__y_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0___0_isValidBase64__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___const_SystemByte_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_newGameMode__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_fourBallCueBallSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___2_range__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_winnerId__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___0_newTableSkin__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_start__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___lcl_temp_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___this_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char> Private___1_value__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_teamIdSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_cueBallWSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<byte> Private___intnl_SystemByte_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private_tableSkinSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_noLockingSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_newTimer__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___0_teamColor__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_y_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_noLockingEnabled__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___lcl_spec_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___1_range__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<uint> Private___3_teamId__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___lcl_udonBehaviours_UnityEngineComponentArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0___0_isInvalidBase64Char__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.Vector3> Private___1_vec__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___0_vec__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_lastProcessedPacketId { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_x_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___intnl_SystemUInt16_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___lcl__r_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___lcl__x_SystemUInt16_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<ushort> Private___lcl__x_SystemUInt16_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of NetworkingManager
    }
}