using System;
using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Tools.UdonEditor;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds.PriceGuess
{
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class PriceGuess_Controller_reader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PriceGuess_Controller_reader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        // TODO: Bind UdonBehaviour with this section
        // TODO: I HIGHLY RECCOMEND TO RENAME THIS VARIABLE BEFORE PASTING!
        // TODO: READER FOR UDONBEHAVIOUR PriceGame!

        //Behaviour PriceGame EventKeys
        //Event Key : __0_SetLocalPlayer
        //Event Key : _start
        //Event Key : _update
        //Event Key : _OnStartButton
        //Event Key : RPC_OnStartButton
        //Event Key : _OnAbortButton
        //Event Key : _OnMasterLockToggle
        //Event Key : __0_SubmitLocalGuess
        //Event Key : __0_OnPlayerGuess
        //Event Key : _OnJoinButton
        //Event Key : _OnLeaveButton
        //Event Key : _ForceCloseKeypad
        //Event Key : LocalPlayerIsParticipating
        //Event Key : IsRoundPhase
        //Event Key : __0_UpdateScoreboardEntry
        //Event Key : __0_DoScoreChangesound
        //Event Key : _RevealPriceDelayed
        //Event Key : _RevealExactDelayed
        //Event Key : _RevealGuessDelayed
        //Event Key : _HideItemAnim
        //Event Key : _DelayedPostRevealMusic
        //Event Key : __0_DoSubmittedSound
        //Event Key : _SortScoreboardDelayed
        //Event Key : CanSubmitGuesses
        //Event Key : __0_SelectCurrency
        //
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

        private void OnRoomLeft()
        {
            Destroy(this);
        }
        private RawUdonBehaviour PriceGuessGameRaw { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        public void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PriceGuess))
            {
                PriceGuessGameRaw = UdonSearch.FindUdonEvent("PriceGame", "__0_SetLocalPlayer").RawItem;
                Initialize_PriceGuessGameRaw();
                InvokeRepeating(nameof(RevealAnswer), 0.01f, 0.01f);

            }
            else
                Destroy(this);
        }

        internal void RevealAnswer()
        {
            if (!WorldModifications.WorldHacks.Jar.PriceGuess.PriceGuess.ShowAnswers) return;
            WorldModifications.WorldHacks.Jar.PriceGuess.PriceGuess.Answer_Text.text = $"Price is : {Environment.NewLine}{itemValue.ToString()}";
        }


        public void OnDestroy()
        {
            Cleanup_PriceGuessGameRaw(); 
            
        }

        private void Initialize_PriceGuessGameRaw()
        {
            Private___const_SystemSingle_8 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_8");
            Private___intnl_SystemBoolean_83 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_83");
            Private___intnl_SystemBoolean_93 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_93");
            Private___intnl_SystemBoolean_13 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_13");
            Private___intnl_SystemBoolean_23 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_23");
            Private___intnl_SystemBoolean_33 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_33");
            Private___intnl_SystemBoolean_43 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_43");
            Private___intnl_SystemBoolean_53 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_53");
            Private___intnl_SystemBoolean_63 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_63");
            Private___intnl_SystemBoolean_73 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_73");
            Private_secondScoreText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "secondScoreText");
            Private___lcl_totalPlayers_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_totalPlayers_SystemInt32_0");
            Private___gintnl_SystemUInt32_16 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_16");
            Private___gintnl_SystemUInt32_26 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_26");
            Private___intnl_SystemSingle_20 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_20");
            Private___intnl_SystemSingle_21 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_21");
            Private___intnl_SystemSingle_22 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_22");
            Private___intnl_SystemSingle_23 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_23");
            Private___intnl_SystemSingle_24 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_24");
            Private___intnl_SystemSingle_25 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_25");
            Private___intnl_SystemSingle_26 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_26");
            Private___intnl_SystemSingle_27 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_27");
            Private___intnl_SystemSingle_28 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_28");
            Private___intnl_SystemSingle_29 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_29");
            Private___lcl_instanceBehaviours_UnityEngineComponentArray_1 = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__lcl_instanceBehaviours_UnityEngineComponentArray_1");
            Private___intnl_SystemInt32_15 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_15");
            Private___intnl_SystemInt32_35 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_35");
            Private___intnl_SystemInt32_25 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_25");
            Private___intnl_SystemInt32_45 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_45");
            Private___const_SystemInt64_1 = new AstroUdonVariable<long>(PriceGuessGameRaw, "__const_SystemInt64_1");
            Private___const_SystemInt64_0 = new AstroUdonVariable<long>(PriceGuessGameRaw, "__const_SystemInt64_0");
            Private___lcl_numHighscorePlayers_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_numHighscorePlayers_SystemInt32_0");
            Private_victoryNameText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "victoryNameText");
            Private___gintnl_SystemObjectArray_1 = new AstroUdonVariable<System.Object[]>(PriceGuessGameRaw, "__gintnl_SystemObjectArray_1");
            Private___lcl_N_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_N_SystemInt32_0");
            Private___lcl_participating_SystemBoolean_0 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__lcl_participating_SystemBoolean_0");
            Private___lcl_targetIdx_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_targetIdx_SystemInt32_0");
            Private___lcl_targetIdx_SystemInt32_1 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_targetIdx_SystemInt32_1");
            Private___intnl_SystemString_1 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__intnl_SystemString_1");
            Private___0_currentUI__param = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__0_currentUI__param");
            Private___6__intnlparam = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__6__intnlparam");
            Private___intnl_UnityEngineObject_12 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_12");
            Private___const_SystemString_46 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_46");
            Private___const_SystemString_47 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_47");
            Private___const_SystemString_44 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_44");
            Private___const_SystemString_45 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_45");
            Private___const_SystemString_42 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_42");
            Private___const_SystemString_43 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_43");
            Private___const_SystemString_40 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_40");
            Private___const_SystemString_41 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_41");
            Private___const_SystemString_48 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_48");
            Private___const_SystemString_49 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_49");
            Private___intnl_SystemSingle_0 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_0");
            Private___intnl_SystemObject_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemObject_0");
            Private_randomItemIndex = new AstroUdonVariable<int>(PriceGuessGameRaw, "randomItemIndex");
            Private___lcl_targetID_SystemInt64_1 = new AstroUdonVariable<long>(PriceGuessGameRaw, "__lcl_targetID_SystemInt64_1");
            Private___lcl_highestScore_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_highestScore_SystemInt32_0");
            Private_itemImage = new AstroUdonVariable<UnityEngine.UI.RawImage>(PriceGuessGameRaw, "itemImage");
            Private_currencies = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "currencies");
            Private___lcl_exactGuess_SystemBoolean_0 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__lcl_exactGuess_SystemBoolean_0");
            Private___const_SystemString_0 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_0");
            Private___intnl_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(PriceGuessGameRaw, "__intnl_UnityEngineTransform_0");
            Private_hurryUpPlayersMin = new AstroUdonVariable<int>(PriceGuessGameRaw, "hurryUpPlayersMin");
            Private___const_SystemSingle_0 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_0");
            Private_lastTimer = new AstroUdonVariable<int>(PriceGuessGameRaw, "lastTimer");
            Private_masterCalculationDelay = new AstroUdonVariable<int>(PriceGuessGameRaw, "masterCalculationDelay");
            Private___intnl_SystemBoolean_86 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_86");
            Private___intnl_SystemBoolean_96 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_96");
            Private___intnl_SystemBoolean_16 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_16");
            Private___intnl_SystemBoolean_26 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_26");
            Private___intnl_SystemBoolean_36 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_36");
            Private___intnl_SystemBoolean_46 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_46");
            Private___intnl_SystemBoolean_56 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_56");
            Private___intnl_SystemBoolean_66 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_66");
            Private___intnl_SystemBoolean_76 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_76");
            Private_countdownDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "countdownDuration");
            Private___intnl_SystemSingle_10 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_10");
            Private___intnl_SystemSingle_11 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_11");
            Private___intnl_SystemSingle_12 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_12");
            Private___intnl_SystemSingle_13 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_13");
            Private___intnl_SystemSingle_14 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_14");
            Private___intnl_SystemSingle_15 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_15");
            Private___intnl_SystemSingle_16 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_16");
            Private___intnl_SystemSingle_17 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_17");
            Private___intnl_SystemSingle_18 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_18");
            Private___intnl_SystemSingle_19 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_19");
            Private___lcl_j_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_j_SystemInt32_0");
            Private___intnl_SystemInt32_12 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_12");
            Private___intnl_SystemInt32_32 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_32");
            Private___intnl_SystemInt32_22 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_22");
            Private___intnl_SystemInt32_52 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_52");
            Private___intnl_SystemInt32_42 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_42");
            Private_timerTexts = new AstroUdonVariable<UnityEngine.UI.Text[]>(PriceGuessGameRaw, "timerTexts");
            Private_gamePhase = new AstroUdonVariable<int>(PriceGuessGameRaw, "gamePhase");
            Private___gintnl_SystemUInt32Array_0 = new AstroUdonVariable<uint[]>(PriceGuessGameRaw, "__gintnl_SystemUInt32Array_0");
            Private___this_VRCUdonUdonBehaviour_12 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_12");
            Private_thirdPlaceObjects = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "thirdPlaceObjects");
            Private___intnl_SystemSingle_8 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_8");
            Private___gintnl_SystemUInt32_9 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_9");
            Private___gintnl_SystemUInt32_8 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_8");
            Private___gintnl_SystemUInt32_5 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_5");
            Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_4");
            Private___gintnl_SystemUInt32_7 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_7");
            Private___gintnl_SystemUInt32_6 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_6");
            Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_1");
            Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_0");
            Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_3");
            Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_2");
            Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__const_SystemBoolean_0");
            Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__const_SystemBoolean_1");
            Private___intnl_UnityEngineObject_11 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_11");
            Private___lcl_numSecondPlayers_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_numSecondPlayers_SystemInt32_0");
            Private___lcl_foundBehaviours_UnityEngineComponentArray_0 = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__lcl_foundBehaviours_UnityEngineComponentArray_0");
            Private___lcl_foundBehaviours_UnityEngineComponentArray_1 = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__lcl_foundBehaviours_UnityEngineComponentArray_1");
            Private_lastGamePhase = new AstroUdonVariable<int>(PriceGuessGameRaw, "lastGamePhase");
            Private___const_SystemString_5 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_5");
            Private_selectedCurrency = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "selectedCurrency");
            Private___0_CanSubmitGuesses__ret = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__0_CanSubmitGuesses__ret");
            Private___gintnl_SystemCharArray_1 = new AstroUdonVariable<char[]>(PriceGuessGameRaw, "__gintnl_SystemCharArray_1");
            Private___const_SystemSingle_7 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_7");
            Private_scoreboardUI = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "scoreboardUI");
            Private___lcl_p_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_p_SystemInt32_0");
            Private___gintnl_SystemUInt32_13 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_13");
            Private___gintnl_SystemUInt32_33 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_33");
            Private___gintnl_SystemUInt32_23 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_23");
            Private___intnl_SystemUInt32_3 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__intnl_SystemUInt32_3");
            Private___3__intnlparam = new AstroUdonVariable<UnityEngine.Transform>(PriceGuessGameRaw, "__3__intnlparam");
            Private___intnl_UnityEngineObject_9 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_9");
            Private___intnl_UnityEngineObject_8 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_8");
            Private___intnl_UnityEngineObject_7 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_7");
            Private___intnl_UnityEngineObject_6 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_6");
            Private___intnl_UnityEngineObject_5 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_5");
            Private___intnl_UnityEngineObject_4 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_4");
            Private___intnl_UnityEngineObject_3 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_3");
            Private___intnl_UnityEngineObject_2 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_2");
            Private___intnl_UnityEngineObject_1 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_1");
            Private___intnl_UnityEngineObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_0");
            Private___lcl_evulatateA_SystemSingle_0 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__lcl_evulatateA_SystemSingle_0");
            Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 = new AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget>(PriceGuessGameRaw, "__const_VRCUdonCommonInterfacesNetworkEventTarget_0");
            Private___intnl_SystemString_6 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__intnl_SystemString_6");
            Private___gintnl_SystemUInt32Array_3 = new AstroUdonVariable<uint[]>(PriceGuessGameRaw, "__gintnl_SystemUInt32Array_3");
            Private___const_SystemString_16 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_16");
            Private___const_SystemString_17 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_17");
            Private___const_SystemString_14 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_14");
            Private___const_SystemString_15 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_15");
            Private___const_SystemString_12 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_12");
            Private___const_SystemString_13 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_13");
            Private___const_SystemString_10 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_10");
            Private___const_SystemString_11 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_11");
            Private___const_SystemString_18 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_18");
            Private___const_SystemString_19 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_19");
            Private___intnl_SystemSingle_7 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_7");
            Private_turnDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "turnDuration");
            Private___refl_typeid = new AstroUdonVariable<long>(PriceGuessGameRaw, "__refl_typeid");
            Private_maxRounds = new AstroUdonVariable<int>(PriceGuessGameRaw, "maxRounds");
            Private_item = new AstroUdonVariable<int>(PriceGuessGameRaw, "item");
            Private_thirdScoreText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "thirdScoreText");
            Private_roundsPerPlayer = new AstroUdonVariable<int>(PriceGuessGameRaw, "roundsPerPlayer");
            Private___lcl_rankPercent_SystemSingle_0 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__lcl_rankPercent_SystemSingle_0");
            Private___lcl_minTimer_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_minTimer_SystemInt32_0");
            Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__const_SystemUInt32_0");
            Private___0_newGamePhase__param = new AstroUdonVariable<int>(PriceGuessGameRaw, "__0_newGamePhase__param");
            Private_secondPlaceObjects = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "secondPlaceObjects");
            Private___intnl_UnityEngineComponent_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__intnl_UnityEngineComponent_0");
            Private___intnl_SystemBoolean_81 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_81");
            Private___intnl_SystemBoolean_91 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_91");
            Private___intnl_SystemBoolean_11 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_11");
            Private___intnl_SystemBoolean_21 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_21");
            Private___intnl_SystemBoolean_31 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_31");
            Private___intnl_SystemBoolean_41 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_41");
            Private___intnl_SystemBoolean_51 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_51");
            Private___intnl_SystemBoolean_61 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_61");
            Private___intnl_SystemBoolean_71 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_71");
            Private_totalRounds = new AstroUdonVariable<int>(PriceGuessGameRaw, "totalRounds");
            Private___gintnl_SystemUInt32_14 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_14");
            Private___gintnl_SystemUInt32_34 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_34");
            Private___gintnl_SystemUInt32_24 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_24");
            Private_items = new AstroUdonVariable<UnityEngine.Texture2D[]>(PriceGuessGameRaw, "items");
            Private___intnl_SystemSingle_40 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_40");
            Private___intnl_SystemSingle_41 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_41");
            Private___intnl_SystemSingle_42 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_42");
            Private___intnl_SystemInt32_17 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_17");
            Private___intnl_SystemInt32_37 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_37");
            Private___intnl_SystemInt32_27 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_27");
            Private___intnl_SystemInt32_47 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_47");
            Private_itemNameText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "itemNameText");
            Private_startButton = new AstroUdonVariable<UnityEngine.UI.Button>(PriceGuessGameRaw, "startButton");
            Private___lcl_secondScore_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_secondScore_SystemInt32_0");
            Private_scoreShuffleSound = new AstroUdonVariable<UnityEngine.AudioSource>(PriceGuessGameRaw, "scoreShuffleSound");
            Private___0__intnlparam = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__0__intnlparam");
            Private_itemHideMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "itemHideMusic");
            Private___lcl_waitingOnPlayers_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_waitingOnPlayers_SystemInt32_0");
            Private___const_SystemString_66 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_66");
            Private___const_SystemString_67 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_67");
            Private___const_SystemString_64 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_64");
            Private___const_SystemString_65 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_65");
            Private___const_SystemString_62 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_62");
            Private___const_SystemString_63 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_63");
            Private___const_SystemString_60 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_60");
            Private___const_SystemString_61 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_61");
            Private___const_SystemString_68 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_68");
            Private___const_SystemString_69 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_69");
            Private___intnl_SystemSingle_2 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_2");
            Private___0_newCurrencyIndex__param = new AstroUdonVariable<int>(PriceGuessGameRaw, "__0_newCurrencyIndex__param");
            Private___lcl_effectiveRank_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_effectiveRank_SystemInt32_0");
            Private___7__intnlparam = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__7__intnlparam");
            Private_masterNameText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "masterNameText");
            Private___intnl_UnityEngineBounds_0 = new AstroUdonVariable<UnityEngine.Bounds>(PriceGuessGameRaw, "__intnl_UnityEngineBounds_0");
            Private___const_SystemString_2 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_2");
            Private_timer = new AstroUdonVariable<int>(PriceGuessGameRaw, "timer");
            Private___const_SystemSingle_2 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_2");
            Private___intnl_SystemBoolean_89 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_89");
            Private___intnl_SystemBoolean_99 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_99");
            Private___intnl_SystemBoolean_19 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_19");
            Private___intnl_SystemBoolean_29 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_29");
            Private___intnl_SystemBoolean_39 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_39");
            Private___intnl_SystemBoolean_49 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_49");
            Private___intnl_SystemBoolean_59 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_59");
            Private___intnl_SystemBoolean_69 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_69");
            Private___intnl_SystemBoolean_79 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_79");
            Private___intnl_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(PriceGuessGameRaw, "__intnl_UnityEngineVector3_0");
            Private___intnl_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineGameObject_0");
            Private___intnl_UnityEngineGameObject_5 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineGameObject_5");
            Private___const_SystemSingle_9 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_9");
            Private___intnl_SystemBoolean_84 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_84");
            Private___intnl_SystemBoolean_94 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_94");
            Private___intnl_SystemBoolean_14 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_14");
            Private___intnl_SystemBoolean_24 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_24");
            Private___intnl_SystemBoolean_34 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_34");
            Private___intnl_SystemBoolean_44 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_44");
            Private___intnl_SystemBoolean_54 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_54");
            Private___intnl_SystemBoolean_64 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_64");
            Private___intnl_SystemBoolean_74 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_74");
            Private___intnl_SystemObject_34 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemObject_34");
            Private___intnl_UnityEngineComponentArray_3 = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__intnl_UnityEngineComponentArray_3");
            Private___intnl_UnityEngineComponentArray_2 = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__intnl_UnityEngineComponentArray_2");
            Private___intnl_SystemSingle_30 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_30");
            Private___intnl_SystemSingle_31 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_31");
            Private___intnl_SystemSingle_32 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_32");
            Private___intnl_SystemSingle_33 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_33");
            Private___intnl_SystemSingle_34 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_34");
            Private___intnl_SystemSingle_35 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_35");
            Private___intnl_SystemSingle_36 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_36");
            Private___intnl_SystemSingle_37 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_37");
            Private___intnl_SystemSingle_38 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_38");
            Private___intnl_SystemSingle_39 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_39");
            Private___intnl_SystemInt32_14 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_14");
            Private___intnl_SystemInt32_34 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_34");
            Private___intnl_SystemInt32_24 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_24");
            Private___intnl_SystemInt32_44 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_44");
            Private_players = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "players");
            Private_stageGuessUI = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "stageGuessUI");
            Private___intnl_SystemInt32_19 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_19");
            Private___intnl_SystemInt32_39 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_39");
            Private___intnl_SystemInt32_29 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_29");
            Private___intnl_SystemInt32_49 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_49");
            Private_cooldownDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "cooldownDuration");
            Private___intnl_UnityEngineObject_13 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_13");
            Private___intnl_SystemSingle_1 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_1");
            Private_ph_PhaseNames = new AstroUdonVariable<string[]>(PriceGuessGameRaw, "ph_PhaseNames");
            Private___const_SystemString_7 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_7");
            Private___4__intnlparam = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__4__intnlparam");
            Private___lcl_numthirdPlayers_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_numthirdPlayers_SystemInt32_0");
            Private___lcl_allPlayersSubmitted_SystemBoolean_0 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__lcl_allPlayersSubmitted_SystemBoolean_0");
            Private___const_SystemSingle_1 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_1");
            Private___gintnl_SystemUInt32_11 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_11");
            Private___gintnl_SystemUInt32_31 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_31");
            Private___gintnl_SystemUInt32_21 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_21");
            Private___intnl_SystemBoolean_87 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_87");
            Private___intnl_SystemBoolean_97 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_97");
            Private___intnl_SystemBoolean_17 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_17");
            Private___intnl_SystemBoolean_27 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_27");
            Private___intnl_SystemBoolean_37 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_37");
            Private___intnl_SystemBoolean_47 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_47");
            Private___intnl_SystemBoolean_57 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_57");
            Private___intnl_SystemBoolean_67 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_67");
            Private___intnl_SystemBoolean_77 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_77");
            Private___const_SystemInt32_10 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_10");
            Private___const_VRCUdonCommonEnumsEventTiming_0 = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(PriceGuessGameRaw, "__const_VRCUdonCommonEnumsEventTiming_0");
            Private___intnl_SystemInt32_11 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_11");
            Private___intnl_SystemInt32_31 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_31");
            Private___intnl_SystemInt32_21 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_21");
            Private___intnl_SystemInt32_51 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_51");
            Private___intnl_SystemInt32_41 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_41");
            Private___lcl_highestRank_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_highestRank_SystemInt32_0");
            Private_itemAnimator = new AstroUdonVariable<UnityEngine.Animator>(PriceGuessGameRaw, "itemAnimator");
            Private___0_num__param = new AstroUdonVariable<int>(PriceGuessGameRaw, "__0_num__param");
            Private___intnl_SystemString_8 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__intnl_SystemString_8");
            Private___gintnl_SystemUInt32Array_1 = new AstroUdonVariable<uint[]>(PriceGuessGameRaw, "__gintnl_SystemUInt32Array_1");
            Private_randomItemOrder = new AstroUdonVariable<int[]>(PriceGuessGameRaw, "randomItemOrder");
            Private___this_VRCUdonUdonBehaviour_11 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_11");
            Private___const_SystemString_36 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_36");
            Private___const_SystemString_37 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_37");
            Private___const_SystemString_34 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_34");
            Private___const_SystemString_35 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_35");
            Private___const_SystemString_32 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_32");
            Private___const_SystemString_33 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_33");
            Private___const_SystemString_30 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_30");
            Private___const_SystemString_31 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_31");
            Private___const_SystemString_38 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_38");
            Private___const_SystemString_39 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_39");
            Private_drumrollDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "drumrollDuration");
            Private___intnl_SystemSingle_9 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_9");
            Private___lcl_secs_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_secs_SystemInt32_0");
            Private_postgameMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "postgameMusic");
            Private___const_SystemString_86 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_86");
            Private___const_SystemString_87 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_87");
            Private___const_SystemString_84 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_84");
            Private___const_SystemString_85 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_85");
            Private___const_SystemString_82 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_82");
            Private___const_SystemString_83 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_83");
            Private___const_SystemString_80 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_80");
            Private___const_SystemString_81 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_81");
            Private___const_SystemString_88 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_88");
            Private___const_SystemString_89 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_89");
            Private___lcl_q_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_q_SystemInt32_0");
            Private___intnl_SystemInt64_1 = new AstroUdonVariable<long>(PriceGuessGameRaw, "__intnl_SystemInt64_1");
            Private___intnl_SystemInt64_0 = new AstroUdonVariable<long>(PriceGuessGameRaw, "__intnl_SystemInt64_0");
            Private___lcl_guessValue_SystemSingle_0 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__lcl_guessValue_SystemSingle_0");
            Private_canAbortGame = new AstroUdonVariable<bool>(PriceGuessGameRaw, "canAbortGame");
            Private___intnl_VRCUdonUdonBehaviour_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__intnl_VRCUdonUdonBehaviour_4");
            Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__intnl_returnJump_SystemUInt32_0");
            Private_minPlayers = new AstroUdonVariable<int>(PriceGuessGameRaw, "minPlayers");
            Private___lcl_v_SystemSingle_0 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__lcl_v_SystemSingle_0");
            Private___const_SystemString_4 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_4");
            Private___const_UnityEngineKeyCode_0 = new AstroUdonVariable<UnityEngine.KeyCode>(PriceGuessGameRaw, "__const_UnityEngineKeyCode_0");
            Private___gintnl_SystemUInt32_19 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_19");
            Private___gintnl_SystemUInt32_29 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_29");
            Private_revealBestGuessDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "revealBestGuessDuration");
            Private___const_SystemSingle_4 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_4");
            Private_postRevealMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "postRevealMusic");
            Private___gintnl_SystemUInt32_12 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_12");
            Private___gintnl_SystemUInt32_32 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_32");
            Private___gintnl_SystemUInt32_22 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_22");
            Private___intnl_SystemUInt32_0 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__intnl_SystemUInt32_0");
            Private___lcl_i_SystemInt32_1 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_i_SystemInt32_1");
            Private___lcl_i_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_i_SystemInt32_0");
            Private___lcl_revealCumulativeDelay_SystemSingle_0 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__lcl_revealCumulativeDelay_SystemSingle_0");
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__lcl_behaviour_VRCUdonUdonBehaviour_0");
            Private_nextTimerTime = new AstroUdonVariable<float>(PriceGuessGameRaw, "nextTimerTime");
            Private_selectedCurrencyIndex = new AstroUdonVariable<int>(PriceGuessGameRaw, "selectedCurrencyIndex");
            Private_stageCountdownUI = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "stageCountdownUI");
            Private_timerTickSound1 = new AstroUdonVariable<UnityEngine.AudioSource>(PriceGuessGameRaw, "timerTickSound1");
            Private_timerTickSound0 = new AstroUdonVariable<UnityEngine.AudioSource>(PriceGuessGameRaw, "timerTickSound0");
            Private___0_LocalPlayerIsParticipating__ret = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__0_LocalPlayerIsParticipating__ret");
            Private_minRounds = new AstroUdonVariable<int>(PriceGuessGameRaw, "minRounds");
            Private_scoreStartSound = new AstroUdonVariable<UnityEngine.AudioSource>(PriceGuessGameRaw, "scoreStartSound");
            Private_scoreboardShuffleDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "scoreboardShuffleDuration");
            Private___intnl_SystemSingle_4 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_4");
            Private___1__intnlparam = new AstroUdonVariable<UnityEngine.Transform>(PriceGuessGameRaw, "__1__intnlparam");
            Private_masterLockIndicator = new AstroUdonVariable<UnityEngine.UI.Image>(PriceGuessGameRaw, "masterLockIndicator");
            Private___intnl_SystemBoolean_100 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_100");
            Private_postRevealMusicDelay = new AstroUdonVariable<float>(PriceGuessGameRaw, "postRevealMusicDelay");
            Private___const_SystemString_9 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_9");
            Private_guessRevealMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "guessRevealMusic");
            Private_tickingSoundDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "tickingSoundDuration");
            Private___intnl_SystemBoolean_82 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_82");
            Private___intnl_SystemBoolean_92 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_92");
            Private___intnl_SystemBoolean_12 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_12");
            Private___intnl_SystemBoolean_22 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_22");
            Private___intnl_SystemBoolean_32 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_32");
            Private___intnl_SystemBoolean_42 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_42");
            Private___intnl_SystemBoolean_52 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_52");
            Private___intnl_SystemBoolean_62 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_62");
            Private___intnl_SystemBoolean_72 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_72");
            Private_itemShowMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "itemShowMusic");
            Private___gintnl_SystemUInt32_17 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_17");
            Private___gintnl_SystemUInt32_27 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_27");
            Private___lcl_instanceBehaviours_UnityEngineComponentArray_0 = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__lcl_instanceBehaviours_UnityEngineComponentArray_0");
            Private___intnl_SystemInt32_16 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_16");
            Private___intnl_SystemInt32_36 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_36");
            Private___intnl_SystemInt32_26 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_26");
            Private___intnl_SystemInt32_46 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_46");
            Private___refl_typename = new AstroUdonVariable<string>(PriceGuessGameRaw, "__refl_typename");
            Private___gintnl_SystemObjectArray_0 = new AstroUdonVariable<System.Object[]>(PriceGuessGameRaw, "__gintnl_SystemObjectArray_0");
            Private_revealActualPriceDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "revealActualPriceDuration");
            Private___lcl_guessedExact_SystemBoolean_0 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__lcl_guessedExact_SystemBoolean_0");
            Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_1");
            Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_0");
            Private___intnl_SystemInt32_3 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_3");
            Private___intnl_SystemInt32_2 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_2");
            Private___intnl_SystemInt32_5 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_5");
            Private___intnl_SystemInt32_4 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_4");
            Private___intnl_SystemInt32_7 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_7");
            Private___intnl_SystemInt32_6 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_6");
            Private___intnl_SystemInt32_9 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_9");
            Private___intnl_SystemInt32_8 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_8");
            Private___lcl_thirdScore_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_thirdScore_SystemInt32_0");
            Private_stagePostgameUI = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "stagePostgameUI");
            Private___const_SystemString_56 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_56");
            Private___const_SystemString_57 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_57");
            Private___const_SystemString_54 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_54");
            Private___const_SystemString_55 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_55");
            Private___const_SystemString_52 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_52");
            Private___const_SystemString_53 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_53");
            Private___const_SystemString_50 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_50");
            Private___const_SystemString_51 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_51");
            Private___const_SystemString_58 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_58");
            Private___const_SystemString_59 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_59");
            Private___intnl_SystemSingle_3 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_3");
            Private_waitToAddScoresDelay = new AstroUdonVariable<int>(PriceGuessGameRaw, "waitToAddScoresDelay");
            Private_priceRevealAnim = new AstroUdonVariable<UnityEngine.Animator>(PriceGuessGameRaw, "priceRevealAnim");
            Private___lcl_totalNumPlayers_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_totalNumPlayers_SystemInt32_0");
            Private_itemMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "itemMusic");
            Private___lcl_mins_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_mins_SystemInt32_0");
            Private___lcl_targetID_SystemInt64_0 = new AstroUdonVariable<long>(PriceGuessGameRaw, "__lcl_targetID_SystemInt64_0");
            Private___lcl_ascendingRank_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_ascendingRank_SystemInt32_0");
            Private___const_SystemString_1 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_1");
            Private___intnl_UnityEngineTransform_1 = new AstroUdonVariable<UnityEngine.Transform>(PriceGuessGameRaw, "__intnl_UnityEngineTransform_1");
            Private_canStartGame = new AstroUdonVariable<bool>(PriceGuessGameRaw, "canStartGame");
            Private___const_SystemSingle_3 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_3");
            Private_playerManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "playerManager");
            Private___5__intnlparam = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__5__intnlparam");
            Private_roundsPassed = new AstroUdonVariable<int>(PriceGuessGameRaw, "roundsPassed");
            Private___intnl_SystemBoolean_85 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_85");
            Private___intnl_SystemBoolean_95 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_95");
            Private___intnl_SystemBoolean_15 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_15");
            Private___intnl_SystemBoolean_25 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_25");
            Private___intnl_SystemBoolean_35 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_35");
            Private___intnl_SystemBoolean_45 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_45");
            Private___intnl_SystemBoolean_55 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_55");
            Private___intnl_SystemBoolean_65 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_65");
            Private___intnl_SystemBoolean_75 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_75");
            Private___intnl_SystemInt32_13 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_13");
            Private___intnl_SystemInt32_33 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_33");
            Private___intnl_SystemInt32_23 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_23");
            Private___intnl_SystemInt32_53 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_53");
            Private___intnl_SystemInt32_43 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_43");
            Private___lcl_numPlayersRevealed_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_numPlayersRevealed_SystemInt32_0");
            Private___lcl_scoreChange_SystemSingle_0 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__lcl_scoreChange_SystemSingle_0");
            Private_postgameDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "postgameDuration");
            Private_exactGuessThreshold = new AstroUdonVariable<float>(PriceGuessGameRaw, "exactGuessThreshold");
            Private___intnl_SystemInt32_18 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_18");
            Private___intnl_SystemInt32_38 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_38");
            Private___intnl_SystemInt32_28 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_28");
            Private___intnl_SystemInt32_48 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_48");
            Private_introMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "introMusic");
            Private___lcl_t_UnityEngineUIText_0 = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "__lcl_t_UnityEngineUIText_0");
            Private_roundText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "roundText");
            Private___this_VRCUdonUdonBehaviour_13 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_13");
            Private_hurryUpSeconds = new AstroUdonVariable<int>(PriceGuessGameRaw, "hurryUpSeconds");
            Private_exactGuessMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "exactGuessMusic");
            Private_itemNameAnimator = new AstroUdonVariable<UnityEngine.Animator>(PriceGuessGameRaw, "itemNameAnimator");
            Private___intnl_UnityEngineObject_10 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__intnl_UnityEngineObject_10");
            Private___const_SystemChar_0 = new AstroUdonVariable<char>(PriceGuessGameRaw, "__const_SystemChar_0");
            Private_thirdNameText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "thirdNameText");
            Private___lcl_arraySize_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_arraySize_SystemInt32_0");
            Private___lcl_arraySize_SystemInt32_1 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_arraySize_SystemInt32_1");
            Private_secondNameText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "secondNameText");
            Private_revealMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "revealMusic");
            Private_keypad = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "keypad");
            Private___const_SystemString_6 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_6");
            Private___gintnl_SystemCharArray_0 = new AstroUdonVariable<char[]>(PriceGuessGameRaw, "__gintnl_SystemCharArray_0");
            Private___const_SystemSingle_6 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_6");
            Private___gintnl_SystemUInt32_10 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_10");
            Private___gintnl_SystemUInt32_30 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_30");
            Private___gintnl_SystemUInt32_20 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_20");
            Private___intnl_SystemUInt32_2 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__intnl_SystemUInt32_2");
            Private___intnl_SystemInt32_10 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_10");
            Private___intnl_SystemInt32_30 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_30");
            Private___intnl_SystemInt32_20 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_20");
            Private___intnl_SystemInt32_50 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_50");
            Private___intnl_SystemInt32_40 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__intnl_SystemInt32_40");
            Private___0_IsRoundPhase__ret = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__0_IsRoundPhase__ret");
            Private___intnl_SystemString_7 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__intnl_SystemString_7");
            Private_revealGuessValueText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "revealGuessValueText");
            Private___gintnl_SystemUInt32Array_2 = new AstroUdonVariable<uint[]>(PriceGuessGameRaw, "__gintnl_SystemUInt32Array_2");
            Private_stageItemUI = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "stageItemUI");
            Private___this_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "__this_UnityEngineGameObject_0");
            Private___this_VRCUdonUdonBehaviour_10 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_10");
            Private_hurryUpPlayersDisregarded = new AstroUdonVariable<int>(PriceGuessGameRaw, "hurryUpPlayersDisregarded");
            Private___const_SystemString_26 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_26");
            Private___const_SystemString_27 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_27");
            Private___const_SystemString_24 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_24");
            Private___const_SystemString_25 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_25");
            Private___const_SystemString_22 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_22");
            Private___const_SystemString_23 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_23");
            Private___const_SystemString_20 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_20");
            Private___const_SystemString_21 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_21");
            Private___const_SystemString_28 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_28");
            Private___const_SystemString_29 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_29");
            Private_revealEachPlayerDuration = new AstroUdonVariable<int>(PriceGuessGameRaw, "revealEachPlayerDuration");
            Private___intnl_SystemSingle_6 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_6");
            Private_itemPriceText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "itemPriceText");
            Private_scoreGiveSound = new AstroUdonVariable<UnityEngine.AudioSource>(PriceGuessGameRaw, "scoreGiveSound");
            Private_numPlayersForSoundFX = new AstroUdonVariable<int>(PriceGuessGameRaw, "numPlayersForSoundFX");
            Private___intnl_VRCUdonUdonBehaviour_5 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__intnl_VRCUdonUdonBehaviour_5");
            Private_stageWaitingUI = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "stageWaitingUI");
            Private___lcl_v_SystemSingle_1 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__lcl_v_SystemSingle_1");
            Private_timerBlipAnim = new AstroUdonVariable<UnityEngine.Animator>(PriceGuessGameRaw, "timerBlipAnim");
            Private___gintnl_SystemUInt32_18 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_18");
            Private___gintnl_SystemUInt32_28 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_28");
            Private_stageLoadingUI = new AstroUdonVariable<UnityEngine.GameObject>(PriceGuessGameRaw, "stageLoadingUI");
            Private___const_SystemSingle_5 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_5");
            Private_lastItem = new AstroUdonVariable<int>(PriceGuessGameRaw, "lastItem");
            Private___2__intnlparam = new AstroUdonVariable<UnityEngine.Component[]>(PriceGuessGameRaw, "__2__intnlparam");
            Private___intnl_UnityEngineComponent_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__intnl_UnityEngineComponent_1");
            Private___intnl_SystemBoolean_80 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_80");
            Private___intnl_SystemBoolean_90 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_90");
            Private___intnl_SystemBoolean_10 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_10");
            Private___intnl_SystemBoolean_20 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_20");
            Private___intnl_SystemBoolean_30 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_30");
            Private___intnl_SystemBoolean_40 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_40");
            Private___intnl_SystemBoolean_50 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_50");
            Private___intnl_SystemBoolean_60 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_60");
            Private___intnl_SystemBoolean_70 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_70");
            Private___lcl_evulatateB_SystemSingle_0 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__lcl_evulatateB_SystemSingle_0");
            Private_masterLocked = new AstroUdonVariable<bool>(PriceGuessGameRaw, "masterLocked");
            Private___gintnl_SystemUInt32_15 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_15");
            Private___gintnl_SystemUInt32_25 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__gintnl_SystemUInt32_25");
            Private___intnl_SystemUInt32_1 = new AstroUdonVariable<uint>(PriceGuessGameRaw, "__intnl_SystemUInt32_1");
            Private___const_SystemInt32_9 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_9");
            Private___const_SystemInt32_8 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_8");
            Private___const_SystemInt32_1 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_1");
            Private___const_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_0");
            Private___const_SystemInt32_3 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_3");
            Private___const_SystemInt32_2 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_2");
            Private___const_SystemInt32_5 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_5");
            Private___const_SystemInt32_4 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_4");
            Private___const_SystemInt32_7 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_7");
            Private___const_SystemInt32_6 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__const_SystemInt32_6");
            Private_scoreboardSubmitSound = new AstroUdonVariable<UnityEngine.AudioSource>(PriceGuessGameRaw, "scoreboardSubmitSound");
            Private___gintnl_SystemObjectArray_2 = new AstroUdonVariable<System.Object[]>(PriceGuessGameRaw, "__gintnl_SystemObjectArray_2");
            Private_restartButton = new AstroUdonVariable<UnityEngine.UI.Button>(PriceGuessGameRaw, "restartButton");
            Private___lcl_behaviour_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__lcl_behaviour_VRCUdonUdonBehaviour_1");
            Private_newPlayersShouldAutoJoin = new AstroUdonVariable<bool>(PriceGuessGameRaw, "newPlayersShouldAutoJoin");
            Private_drumrollMusic = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "drumrollMusic");
            Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_8");
            Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_9");
            Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_0");
            Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_1");
            Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_2");
            Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_3");
            Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_4");
            Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_5");
            Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_6");
            Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_7");
            Private_itemSourceText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "itemSourceText");
            Private___lcl_numHighrankPlayers_SystemInt32_0 = new AstroUdonVariable<int>(PriceGuessGameRaw, "__lcl_numHighrankPlayers_SystemInt32_0");
            Private_revealGuessNameText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "revealGuessNameText");
            Private___lcl_timeString_SystemString_0 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__lcl_timeString_SystemString_0");
            Private_victoryScoreText = new AstroUdonVariable<UnityEngine.UI.Text>(PriceGuessGameRaw, "victoryScoreText");
            Private___const_SystemString_76 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_76");
            Private___const_SystemString_77 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_77");
            Private___const_SystemString_74 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_74");
            Private___const_SystemString_75 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_75");
            Private___const_SystemString_72 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_72");
            Private___const_SystemString_73 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_73");
            Private___const_SystemString_70 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_70");
            Private___const_SystemString_71 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_71");
            Private___const_SystemString_78 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_78");
            Private___const_SystemString_79 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_79");
            Private___intnl_SystemSingle_5 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__intnl_SystemSingle_5");
            Private___const_SystemSingle_10 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_10");
            Private___const_SystemSingle_11 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_11");
            Private___const_SystemSingle_12 = new AstroUdonVariable<float>(PriceGuessGameRaw, "__const_SystemSingle_12");
            Private_abortButton = new AstroUdonVariable<UnityEngine.UI.Button>(PriceGuessGameRaw, "abortButton");
            Private_scoreboard = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "scoreboard");
            Private_gameAreaBounds = new AstroUdonVariable<UnityEngine.BoxCollider>(PriceGuessGameRaw, "gameAreaBounds");
            Private___const_SystemString_3 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_3");
            Private___this_VRCUdonUdonBehaviour_9 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_9");
            Private___this_VRCUdonUdonBehaviour_8 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_8");
            Private___this_VRCUdonUdonBehaviour_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_3");
            Private___this_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_2");
            Private___this_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_1");
            Private___this_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_0");
            Private___this_VRCUdonUdonBehaviour_7 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_7");
            Private___this_VRCUdonUdonBehaviour_6 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_6");
            Private___this_VRCUdonUdonBehaviour_5 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_5");
            Private___this_VRCUdonUdonBehaviour_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PriceGuessGameRaw, "__this_VRCUdonUdonBehaviour_4");
            Private_itemValue = new AstroUdonVariable<float>(PriceGuessGameRaw, "itemValue");
            Private___const_SystemString_8 = new AstroUdonVariable<string>(PriceGuessGameRaw, "__const_SystemString_8");
            Private___intnl_SystemBoolean_88 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_88");
            Private___intnl_SystemBoolean_98 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_98");
            Private___intnl_SystemBoolean_18 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_18");
            Private___intnl_SystemBoolean_28 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_28");
            Private___intnl_SystemBoolean_38 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_38");
            Private___intnl_SystemBoolean_48 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_48");
            Private___intnl_SystemBoolean_58 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_58");
            Private___intnl_SystemBoolean_68 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_68");
            Private___intnl_SystemBoolean_78 = new AstroUdonVariable<bool>(PriceGuessGameRaw, "__intnl_SystemBoolean_78");
            Private___lcl_typeID_SystemObject_1 = new AstroUdonVariable<long>(PriceGuessGameRaw, "__lcl_typeID_SystemObject_1");
            Private___lcl_typeID_SystemObject_0 = new AstroUdonVariable<long>(PriceGuessGameRaw, "__lcl_typeID_SystemObject_0");
        }

        private void Cleanup_PriceGuessGameRaw()
        {
            Private___const_SystemSingle_8 = null;
            Private___intnl_SystemBoolean_83 = null;
            Private___intnl_SystemBoolean_93 = null;
            Private___intnl_SystemBoolean_13 = null;
            Private___intnl_SystemBoolean_23 = null;
            Private___intnl_SystemBoolean_33 = null;
            Private___intnl_SystemBoolean_43 = null;
            Private___intnl_SystemBoolean_53 = null;
            Private___intnl_SystemBoolean_63 = null;
            Private___intnl_SystemBoolean_73 = null;
            Private_secondScoreText = null;
            Private___lcl_totalPlayers_SystemInt32_0 = null;
            Private___gintnl_SystemUInt32_16 = null;
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
            Private___lcl_instanceBehaviours_UnityEngineComponentArray_1 = null;
            Private___intnl_SystemInt32_15 = null;
            Private___intnl_SystemInt32_35 = null;
            Private___intnl_SystemInt32_25 = null;
            Private___intnl_SystemInt32_45 = null;
            Private___const_SystemInt64_1 = null;
            Private___const_SystemInt64_0 = null;
            Private___lcl_numHighscorePlayers_SystemInt32_0 = null;
            Private_victoryNameText = null;
            Private___gintnl_SystemObjectArray_1 = null;
            Private___lcl_N_SystemInt32_0 = null;
            Private___lcl_participating_SystemBoolean_0 = null;
            Private___lcl_targetIdx_SystemInt32_0 = null;
            Private___lcl_targetIdx_SystemInt32_1 = null;
            Private___intnl_SystemString_1 = null;
            Private___0_currentUI__param = null;
            Private___6__intnlparam = null;
            Private___intnl_UnityEngineObject_12 = null;
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
            Private_randomItemIndex = null;
            Private___lcl_targetID_SystemInt64_1 = null;
            Private___lcl_highestScore_SystemInt32_0 = null;
            Private_itemImage = null;
            Private_currencies = null;
            Private___lcl_exactGuess_SystemBoolean_0 = null;
            Private___const_SystemString_0 = null;
            Private___intnl_UnityEngineTransform_0 = null;
            Private_hurryUpPlayersMin = null;
            Private___const_SystemSingle_0 = null;
            Private_lastTimer = null;
            Private_masterCalculationDelay = null;
            Private___intnl_SystemBoolean_86 = null;
            Private___intnl_SystemBoolean_96 = null;
            Private___intnl_SystemBoolean_16 = null;
            Private___intnl_SystemBoolean_26 = null;
            Private___intnl_SystemBoolean_36 = null;
            Private___intnl_SystemBoolean_46 = null;
            Private___intnl_SystemBoolean_56 = null;
            Private___intnl_SystemBoolean_66 = null;
            Private___intnl_SystemBoolean_76 = null;
            Private_countdownDuration = null;
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
            Private___intnl_SystemInt32_52 = null;
            Private___intnl_SystemInt32_42 = null;
            Private_timerTexts = null;
            Private_gamePhase = null;
            Private___gintnl_SystemUInt32Array_0 = null;
            Private___this_VRCUdonUdonBehaviour_12 = null;
            Private_thirdPlaceObjects = null;
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
            Private___intnl_UnityEngineObject_11 = null;
            Private___lcl_numSecondPlayers_SystemInt32_0 = null;
            Private___lcl_foundBehaviours_UnityEngineComponentArray_0 = null;
            Private___lcl_foundBehaviours_UnityEngineComponentArray_1 = null;
            Private_lastGamePhase = null;
            Private___const_SystemString_5 = null;
            Private_selectedCurrency = null;
            Private___0_CanSubmitGuesses__ret = null;
            Private___gintnl_SystemCharArray_1 = null;
            Private___const_SystemSingle_7 = null;
            Private_scoreboardUI = null;
            Private___lcl_p_SystemInt32_0 = null;
            Private___gintnl_SystemUInt32_13 = null;
            Private___gintnl_SystemUInt32_33 = null;
            Private___gintnl_SystemUInt32_23 = null;
            Private___intnl_SystemUInt32_3 = null;
            Private___3__intnlparam = null;
            Private___intnl_UnityEngineObject_9 = null;
            Private___intnl_UnityEngineObject_8 = null;
            Private___intnl_UnityEngineObject_7 = null;
            Private___intnl_UnityEngineObject_6 = null;
            Private___intnl_UnityEngineObject_5 = null;
            Private___intnl_UnityEngineObject_4 = null;
            Private___intnl_UnityEngineObject_3 = null;
            Private___intnl_UnityEngineObject_2 = null;
            Private___intnl_UnityEngineObject_1 = null;
            Private___intnl_UnityEngineObject_0 = null;
            Private___lcl_evulatateA_SystemSingle_0 = null;
            Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 = null;
            Private___intnl_SystemString_6 = null;
            Private___gintnl_SystemUInt32Array_3 = null;
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
            Private_turnDuration = null;
            Private___refl_typeid = null;
            Private_maxRounds = null;
            Private_item = null;
            Private_thirdScoreText = null;
            Private_roundsPerPlayer = null;
            Private___lcl_rankPercent_SystemSingle_0 = null;
            Private___lcl_minTimer_SystemInt32_0 = null;
            Private___const_SystemUInt32_0 = null;
            Private___0_newGamePhase__param = null;
            Private_secondPlaceObjects = null;
            Private___intnl_UnityEngineComponent_0 = null;
            Private___intnl_SystemBoolean_81 = null;
            Private___intnl_SystemBoolean_91 = null;
            Private___intnl_SystemBoolean_11 = null;
            Private___intnl_SystemBoolean_21 = null;
            Private___intnl_SystemBoolean_31 = null;
            Private___intnl_SystemBoolean_41 = null;
            Private___intnl_SystemBoolean_51 = null;
            Private___intnl_SystemBoolean_61 = null;
            Private___intnl_SystemBoolean_71 = null;
            Private_totalRounds = null;
            Private___gintnl_SystemUInt32_14 = null;
            Private___gintnl_SystemUInt32_34 = null;
            Private___gintnl_SystemUInt32_24 = null;
            Private_items = null;
            Private___intnl_SystemSingle_40 = null;
            Private___intnl_SystemSingle_41 = null;
            Private___intnl_SystemSingle_42 = null;
            Private___intnl_SystemInt32_17 = null;
            Private___intnl_SystemInt32_37 = null;
            Private___intnl_SystemInt32_27 = null;
            Private___intnl_SystemInt32_47 = null;
            Private_itemNameText = null;
            Private_startButton = null;
            Private___lcl_secondScore_SystemInt32_0 = null;
            Private_scoreShuffleSound = null;
            Private___0__intnlparam = null;
            Private_itemHideMusic = null;
            Private___lcl_waitingOnPlayers_SystemInt32_0 = null;
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
            Private___0_newCurrencyIndex__param = null;
            Private___lcl_effectiveRank_SystemInt32_0 = null;
            Private___7__intnlparam = null;
            Private_masterNameText = null;
            Private___intnl_UnityEngineBounds_0 = null;
            Private___const_SystemString_2 = null;
            Private_timer = null;
            Private___const_SystemSingle_2 = null;
            Private___intnl_SystemBoolean_89 = null;
            Private___intnl_SystemBoolean_99 = null;
            Private___intnl_SystemBoolean_19 = null;
            Private___intnl_SystemBoolean_29 = null;
            Private___intnl_SystemBoolean_39 = null;
            Private___intnl_SystemBoolean_49 = null;
            Private___intnl_SystemBoolean_59 = null;
            Private___intnl_SystemBoolean_69 = null;
            Private___intnl_SystemBoolean_79 = null;
            Private___intnl_UnityEngineVector3_0 = null;
            Private___intnl_UnityEngineGameObject_0 = null;
            Private___intnl_UnityEngineGameObject_5 = null;
            Private___const_SystemSingle_9 = null;
            Private___intnl_SystemBoolean_84 = null;
            Private___intnl_SystemBoolean_94 = null;
            Private___intnl_SystemBoolean_14 = null;
            Private___intnl_SystemBoolean_24 = null;
            Private___intnl_SystemBoolean_34 = null;
            Private___intnl_SystemBoolean_44 = null;
            Private___intnl_SystemBoolean_54 = null;
            Private___intnl_SystemBoolean_64 = null;
            Private___intnl_SystemBoolean_74 = null;
            Private___intnl_SystemObject_34 = null;
            Private___intnl_UnityEngineComponentArray_3 = null;
            Private___intnl_UnityEngineComponentArray_2 = null;
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
            Private_players = null;
            Private_stageGuessUI = null;
            Private___intnl_SystemInt32_19 = null;
            Private___intnl_SystemInt32_39 = null;
            Private___intnl_SystemInt32_29 = null;
            Private___intnl_SystemInt32_49 = null;
            Private_cooldownDuration = null;
            Private___intnl_UnityEngineObject_13 = null;
            Private___intnl_SystemSingle_1 = null;
            Private_ph_PhaseNames = null;
            Private___const_SystemString_7 = null;
            Private___4__intnlparam = null;
            Private___lcl_numthirdPlayers_SystemInt32_0 = null;
            Private___lcl_allPlayersSubmitted_SystemBoolean_0 = null;
            Private___const_SystemSingle_1 = null;
            Private___gintnl_SystemUInt32_11 = null;
            Private___gintnl_SystemUInt32_31 = null;
            Private___gintnl_SystemUInt32_21 = null;
            Private___intnl_SystemBoolean_87 = null;
            Private___intnl_SystemBoolean_97 = null;
            Private___intnl_SystemBoolean_17 = null;
            Private___intnl_SystemBoolean_27 = null;
            Private___intnl_SystemBoolean_37 = null;
            Private___intnl_SystemBoolean_47 = null;
            Private___intnl_SystemBoolean_57 = null;
            Private___intnl_SystemBoolean_67 = null;
            Private___intnl_SystemBoolean_77 = null;
            Private___const_SystemInt32_10 = null;
            Private___const_VRCUdonCommonEnumsEventTiming_0 = null;
            Private___intnl_SystemInt32_11 = null;
            Private___intnl_SystemInt32_31 = null;
            Private___intnl_SystemInt32_21 = null;
            Private___intnl_SystemInt32_51 = null;
            Private___intnl_SystemInt32_41 = null;
            Private___lcl_highestRank_SystemInt32_0 = null;
            Private_itemAnimator = null;
            Private___0_num__param = null;
            Private___intnl_SystemString_8 = null;
            Private___gintnl_SystemUInt32Array_1 = null;
            Private_randomItemOrder = null;
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
            Private_drumrollDuration = null;
            Private___intnl_SystemSingle_9 = null;
            Private___lcl_secs_SystemInt32_0 = null;
            Private_postgameMusic = null;
            Private___const_SystemString_86 = null;
            Private___const_SystemString_87 = null;
            Private___const_SystemString_84 = null;
            Private___const_SystemString_85 = null;
            Private___const_SystemString_82 = null;
            Private___const_SystemString_83 = null;
            Private___const_SystemString_80 = null;
            Private___const_SystemString_81 = null;
            Private___const_SystemString_88 = null;
            Private___const_SystemString_89 = null;
            Private___lcl_q_SystemInt32_0 = null;
            Private___intnl_SystemInt64_1 = null;
            Private___intnl_SystemInt64_0 = null;
            Private___lcl_guessValue_SystemSingle_0 = null;
            Private_canAbortGame = null;
            Private___intnl_VRCUdonUdonBehaviour_4 = null;
            Private___intnl_returnJump_SystemUInt32_0 = null;
            Private_minPlayers = null;
            Private___lcl_v_SystemSingle_0 = null;
            Private___const_SystemString_4 = null;
            Private___const_UnityEngineKeyCode_0 = null;
            Private___gintnl_SystemUInt32_19 = null;
            Private___gintnl_SystemUInt32_29 = null;
            Private_revealBestGuessDuration = null;
            Private___const_SystemSingle_4 = null;
            Private_postRevealMusic = null;
            Private___gintnl_SystemUInt32_12 = null;
            Private___gintnl_SystemUInt32_32 = null;
            Private___gintnl_SystemUInt32_22 = null;
            Private___intnl_SystemUInt32_0 = null;
            Private___lcl_i_SystemInt32_1 = null;
            Private___lcl_i_SystemInt32_0 = null;
            Private___lcl_revealCumulativeDelay_SystemSingle_0 = null;
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = null;
            Private_nextTimerTime = null;
            Private_selectedCurrencyIndex = null;
            Private_stageCountdownUI = null;
            Private_timerTickSound1 = null;
            Private_timerTickSound0 = null;
            Private___0_LocalPlayerIsParticipating__ret = null;
            Private_minRounds = null;
            Private_scoreStartSound = null;
            Private_scoreboardShuffleDuration = null;
            Private___intnl_SystemSingle_4 = null;
            Private___1__intnlparam = null;
            Private_masterLockIndicator = null;
            Private___intnl_SystemBoolean_100 = null;
            Private_postRevealMusicDelay = null;
            Private___const_SystemString_9 = null;
            Private_guessRevealMusic = null;
            Private_tickingSoundDuration = null;
            Private___intnl_SystemBoolean_82 = null;
            Private___intnl_SystemBoolean_92 = null;
            Private___intnl_SystemBoolean_12 = null;
            Private___intnl_SystemBoolean_22 = null;
            Private___intnl_SystemBoolean_32 = null;
            Private___intnl_SystemBoolean_42 = null;
            Private___intnl_SystemBoolean_52 = null;
            Private___intnl_SystemBoolean_62 = null;
            Private___intnl_SystemBoolean_72 = null;
            Private_itemShowMusic = null;
            Private___gintnl_SystemUInt32_17 = null;
            Private___gintnl_SystemUInt32_27 = null;
            Private___lcl_instanceBehaviours_UnityEngineComponentArray_0 = null;
            Private___intnl_SystemInt32_16 = null;
            Private___intnl_SystemInt32_36 = null;
            Private___intnl_SystemInt32_26 = null;
            Private___intnl_SystemInt32_46 = null;
            Private___refl_typename = null;
            Private___gintnl_SystemObjectArray_0 = null;
            Private_revealActualPriceDuration = null;
            Private___lcl_guessedExact_SystemBoolean_0 = null;
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
            Private___lcl_thirdScore_SystemInt32_0 = null;
            Private_stagePostgameUI = null;
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
            Private___intnl_SystemSingle_3 = null;
            Private_waitToAddScoresDelay = null;
            Private_priceRevealAnim = null;
            Private___lcl_totalNumPlayers_SystemInt32_0 = null;
            Private_itemMusic = null;
            Private___lcl_mins_SystemInt32_0 = null;
            Private___lcl_targetID_SystemInt64_0 = null;
            Private___lcl_ascendingRank_SystemInt32_0 = null;
            Private___const_SystemString_1 = null;
            Private___intnl_UnityEngineTransform_1 = null;
            Private_canStartGame = null;
            Private___const_SystemSingle_3 = null;
            Private_playerManager = null;
            Private___5__intnlparam = null;
            Private_roundsPassed = null;
            Private___intnl_SystemBoolean_85 = null;
            Private___intnl_SystemBoolean_95 = null;
            Private___intnl_SystemBoolean_15 = null;
            Private___intnl_SystemBoolean_25 = null;
            Private___intnl_SystemBoolean_35 = null;
            Private___intnl_SystemBoolean_45 = null;
            Private___intnl_SystemBoolean_55 = null;
            Private___intnl_SystemBoolean_65 = null;
            Private___intnl_SystemBoolean_75 = null;
            Private___intnl_SystemInt32_13 = null;
            Private___intnl_SystemInt32_33 = null;
            Private___intnl_SystemInt32_23 = null;
            Private___intnl_SystemInt32_53 = null;
            Private___intnl_SystemInt32_43 = null;
            Private___lcl_numPlayersRevealed_SystemInt32_0 = null;
            Private___lcl_scoreChange_SystemSingle_0 = null;
            Private_postgameDuration = null;
            Private_exactGuessThreshold = null;
            Private___intnl_SystemInt32_18 = null;
            Private___intnl_SystemInt32_38 = null;
            Private___intnl_SystemInt32_28 = null;
            Private___intnl_SystemInt32_48 = null;
            Private_introMusic = null;
            Private___lcl_t_UnityEngineUIText_0 = null;
            Private_roundText = null;
            Private___this_VRCUdonUdonBehaviour_13 = null;
            Private_hurryUpSeconds = null;
            Private_exactGuessMusic = null;
            Private_itemNameAnimator = null;
            Private___intnl_UnityEngineObject_10 = null;
            Private___const_SystemChar_0 = null;
            Private_thirdNameText = null;
            Private___lcl_arraySize_SystemInt32_0 = null;
            Private___lcl_arraySize_SystemInt32_1 = null;
            Private_secondNameText = null;
            Private_revealMusic = null;
            Private_keypad = null;
            Private___const_SystemString_6 = null;
            Private___gintnl_SystemCharArray_0 = null;
            Private___const_SystemSingle_6 = null;
            Private___gintnl_SystemUInt32_10 = null;
            Private___gintnl_SystemUInt32_30 = null;
            Private___gintnl_SystemUInt32_20 = null;
            Private___intnl_SystemUInt32_2 = null;
            Private___intnl_SystemInt32_10 = null;
            Private___intnl_SystemInt32_30 = null;
            Private___intnl_SystemInt32_20 = null;
            Private___intnl_SystemInt32_50 = null;
            Private___intnl_SystemInt32_40 = null;
            Private___0_IsRoundPhase__ret = null;
            Private___intnl_SystemString_7 = null;
            Private_revealGuessValueText = null;
            Private___gintnl_SystemUInt32Array_2 = null;
            Private_stageItemUI = null;
            Private___this_UnityEngineGameObject_0 = null;
            Private___this_VRCUdonUdonBehaviour_10 = null;
            Private_hurryUpPlayersDisregarded = null;
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
            Private_revealEachPlayerDuration = null;
            Private___intnl_SystemSingle_6 = null;
            Private_itemPriceText = null;
            Private_scoreGiveSound = null;
            Private_numPlayersForSoundFX = null;
            Private___intnl_VRCUdonUdonBehaviour_5 = null;
            Private_stageWaitingUI = null;
            Private___lcl_v_SystemSingle_1 = null;
            Private_timerBlipAnim = null;
            Private___gintnl_SystemUInt32_18 = null;
            Private___gintnl_SystemUInt32_28 = null;
            Private_stageLoadingUI = null;
            Private___const_SystemSingle_5 = null;
            Private_lastItem = null;
            Private___2__intnlparam = null;
            Private___intnl_UnityEngineComponent_1 = null;
            Private___intnl_SystemBoolean_80 = null;
            Private___intnl_SystemBoolean_90 = null;
            Private___intnl_SystemBoolean_10 = null;
            Private___intnl_SystemBoolean_20 = null;
            Private___intnl_SystemBoolean_30 = null;
            Private___intnl_SystemBoolean_40 = null;
            Private___intnl_SystemBoolean_50 = null;
            Private___intnl_SystemBoolean_60 = null;
            Private___intnl_SystemBoolean_70 = null;
            Private___lcl_evulatateB_SystemSingle_0 = null;
            Private_masterLocked = null;
            Private___gintnl_SystemUInt32_15 = null;
            Private___gintnl_SystemUInt32_25 = null;
            Private___intnl_SystemUInt32_1 = null;
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
            Private_scoreboardSubmitSound = null;
            Private___gintnl_SystemObjectArray_2 = null;
            Private_restartButton = null;
            Private___lcl_behaviour_VRCUdonUdonBehaviour_1 = null;
            Private_newPlayersShouldAutoJoin = null;
            Private_drumrollMusic = null;
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
            Private_itemSourceText = null;
            Private___lcl_numHighrankPlayers_SystemInt32_0 = null;
            Private_revealGuessNameText = null;
            Private___lcl_timeString_SystemString_0 = null;
            Private_victoryScoreText = null;
            Private___const_SystemString_76 = null;
            Private___const_SystemString_77 = null;
            Private___const_SystemString_74 = null;
            Private___const_SystemString_75 = null;
            Private___const_SystemString_72 = null;
            Private___const_SystemString_73 = null;
            Private___const_SystemString_70 = null;
            Private___const_SystemString_71 = null;
            Private___const_SystemString_78 = null;
            Private___const_SystemString_79 = null;
            Private___intnl_SystemSingle_5 = null;
            Private___const_SystemSingle_10 = null;
            Private___const_SystemSingle_11 = null;
            Private___const_SystemSingle_12 = null;
            Private_abortButton = null;
            Private_scoreboard = null;
            Private_gameAreaBounds = null;
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
            Private_itemValue = null;
            Private___const_SystemString_8 = null;
            Private___intnl_SystemBoolean_88 = null;
            Private___intnl_SystemBoolean_98 = null;
            Private___intnl_SystemBoolean_18 = null;
            Private___intnl_SystemBoolean_28 = null;
            Private___intnl_SystemBoolean_38 = null;
            Private___intnl_SystemBoolean_48 = null;
            Private___intnl_SystemBoolean_58 = null;
            Private___intnl_SystemBoolean_68 = null;
            Private___intnl_SystemBoolean_78 = null;
            Private___lcl_typeID_SystemObject_1 = null;
            Private___lcl_typeID_SystemObject_0 = null;
        }

        #region Getter / Setters AstroUdonVariables  of PriceGuessGameRaw

        internal float? __const_SystemSingle_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_8 != null)
                {
                    return Private___const_SystemSingle_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_8 != null)
                    {
                        Private___const_SystemSingle_8.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_83
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_83 != null)
                {
                    return Private___intnl_SystemBoolean_83.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_83 != null)
                    {
                        Private___intnl_SystemBoolean_83.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_93
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_93 != null)
                {
                    return Private___intnl_SystemBoolean_93.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_93 != null)
                    {
                        Private___intnl_SystemBoolean_93.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_63
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_63 != null)
                {
                    return Private___intnl_SystemBoolean_63.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_63 != null)
                    {
                        Private___intnl_SystemBoolean_63.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_73
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_73 != null)
                {
                    return Private___intnl_SystemBoolean_73.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_73 != null)
                    {
                        Private___intnl_SystemBoolean_73.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text secondScoreText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondScoreText != null)
                {
                    return Private_secondScoreText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_secondScoreText != null)
                {
                    Private_secondScoreText.Value = value;
                }
            }
        }

        internal int? __lcl_totalPlayers_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_totalPlayers_SystemInt32_0 != null)
                {
                    return Private___lcl_totalPlayers_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_totalPlayers_SystemInt32_0 != null)
                    {
                        Private___lcl_totalPlayers_SystemInt32_0.Value = value.Value;
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

        internal UnityEngine.Component[] __lcl_instanceBehaviours_UnityEngineComponentArray_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_instanceBehaviours_UnityEngineComponentArray_1 != null)
                {
                    return Private___lcl_instanceBehaviours_UnityEngineComponentArray_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_instanceBehaviours_UnityEngineComponentArray_1 != null)
                {
                    Private___lcl_instanceBehaviours_UnityEngineComponentArray_1.Value = value;
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

        internal long? __const_SystemInt64_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt64_1 != null)
                {
                    return Private___const_SystemInt64_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt64_1 != null)
                    {
                        Private___const_SystemInt64_1.Value = value.Value;
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

        internal int? __lcl_numHighscorePlayers_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_numHighscorePlayers_SystemInt32_0 != null)
                {
                    return Private___lcl_numHighscorePlayers_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_numHighscorePlayers_SystemInt32_0 != null)
                    {
                        Private___lcl_numHighscorePlayers_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text victoryNameText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_victoryNameText != null)
                {
                    return Private_victoryNameText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_victoryNameText != null)
                {
                    Private_victoryNameText.Value = value;
                }
            }
        }

        internal System.Object[] __gintnl_SystemObjectArray_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemObjectArray_1 != null)
                {
                    return Private___gintnl_SystemObjectArray_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemObjectArray_1 != null)
                {
                    Private___gintnl_SystemObjectArray_1.Value = value;
                }
            }
        }

        internal int? __lcl_N_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_N_SystemInt32_0 != null)
                {
                    return Private___lcl_N_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_N_SystemInt32_0 != null)
                    {
                        Private___lcl_N_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __lcl_participating_SystemBoolean_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_participating_SystemBoolean_0 != null)
                {
                    return Private___lcl_participating_SystemBoolean_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_participating_SystemBoolean_0 != null)
                    {
                        Private___lcl_participating_SystemBoolean_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_targetIdx_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_targetIdx_SystemInt32_0 != null)
                {
                    return Private___lcl_targetIdx_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_targetIdx_SystemInt32_0 != null)
                    {
                        Private___lcl_targetIdx_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_targetIdx_SystemInt32_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_targetIdx_SystemInt32_1 != null)
                {
                    return Private___lcl_targetIdx_SystemInt32_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_targetIdx_SystemInt32_1 != null)
                    {
                        Private___lcl_targetIdx_SystemInt32_1.Value = value.Value;
                    }
                }
            }
        }

        internal string __intnl_SystemString_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemString_1 != null)
                {
                    return Private___intnl_SystemString_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemString_1 != null)
                {
                    Private___intnl_SystemString_1.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __0_currentUI__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_currentUI__param != null)
                {
                    return Private___0_currentUI__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_currentUI__param != null)
                {
                    Private___0_currentUI__param.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __6__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6__intnlparam != null)
                {
                    return Private___6__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___6__intnlparam != null)
                {
                    Private___6__intnlparam.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_12 != null)
                {
                    return Private___intnl_UnityEngineObject_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_12 != null)
                {
                    Private___intnl_UnityEngineObject_12.Value = value;
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

        internal int? __intnl_SystemObject_0
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
                if (value.HasValue)
                {
                    if (Private___intnl_SystemObject_0 != null)
                    {
                        Private___intnl_SystemObject_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? randomItemIndex
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_randomItemIndex != null)
                {
                    return Private_randomItemIndex.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_randomItemIndex != null)
                    {
                        Private_randomItemIndex.Value = value.Value;
                    }
                }
            }
        }

        internal long? __lcl_targetID_SystemInt64_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_targetID_SystemInt64_1 != null)
                {
                    return Private___lcl_targetID_SystemInt64_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_targetID_SystemInt64_1 != null)
                    {
                        Private___lcl_targetID_SystemInt64_1.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_highestScore_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_highestScore_SystemInt32_0 != null)
                {
                    return Private___lcl_highestScore_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_highestScore_SystemInt32_0 != null)
                    {
                        Private___lcl_highestScore_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.RawImage itemImage
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemImage != null)
                {
                    return Private_itemImage.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemImage != null)
                {
                    Private_itemImage.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] currencies
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_currencies != null)
                {
                    return Private_currencies.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_currencies != null)
                {
                    Private_currencies.Value = value;
                }
            }
        }

        internal bool? __lcl_exactGuess_SystemBoolean_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_exactGuess_SystemBoolean_0 != null)
                {
                    return Private___lcl_exactGuess_SystemBoolean_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_exactGuess_SystemBoolean_0 != null)
                    {
                        Private___lcl_exactGuess_SystemBoolean_0.Value = value.Value;
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

        internal UnityEngine.Transform __intnl_UnityEngineTransform_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_0 != null)
                {
                    return Private___intnl_UnityEngineTransform_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_0 != null)
                {
                    Private___intnl_UnityEngineTransform_0.Value = value;
                }
            }
        }

        internal int? hurryUpPlayersMin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hurryUpPlayersMin != null)
                {
                    return Private_hurryUpPlayersMin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hurryUpPlayersMin != null)
                    {
                        Private_hurryUpPlayersMin.Value = value.Value;
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

        internal int? lastTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lastTimer != null)
                {
                    return Private_lastTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lastTimer != null)
                    {
                        Private_lastTimer.Value = value.Value;
                    }
                }
            }
        }

        internal int? masterCalculationDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_masterCalculationDelay != null)
                {
                    return Private_masterCalculationDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_masterCalculationDelay != null)
                    {
                        Private_masterCalculationDelay.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_86
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_86 != null)
                {
                    return Private___intnl_SystemBoolean_86.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_86 != null)
                    {
                        Private___intnl_SystemBoolean_86.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_96
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_96 != null)
                {
                    return Private___intnl_SystemBoolean_96.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_96 != null)
                    {
                        Private___intnl_SystemBoolean_96.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_66
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_66 != null)
                {
                    return Private___intnl_SystemBoolean_66.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_66 != null)
                    {
                        Private___intnl_SystemBoolean_66.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_76
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_76 != null)
                {
                    return Private___intnl_SystemBoolean_76.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_76 != null)
                    {
                        Private___intnl_SystemBoolean_76.Value = value.Value;
                    }
                }
            }
        }

        internal int? countdownDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_countdownDuration != null)
                {
                    return Private_countdownDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_countdownDuration != null)
                    {
                        Private_countdownDuration.Value = value.Value;
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

        internal int? __intnl_SystemInt32_52
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_52 != null)
                {
                    return Private___intnl_SystemInt32_52.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_52 != null)
                    {
                        Private___intnl_SystemInt32_52.Value = value.Value;
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

        internal UnityEngine.UI.Text[] timerTexts
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerTexts != null)
                {
                    return Private_timerTexts.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_timerTexts != null)
                {
                    Private_timerTexts.Value = value;
                }
            }
        }

        internal int? gamePhase
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gamePhase != null)
                {
                    return Private_gamePhase.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gamePhase != null)
                    {
                        Private_gamePhase.Value = value.Value;
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

        internal UnityEngine.GameObject thirdPlaceObjects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_thirdPlaceObjects != null)
                {
                    return Private_thirdPlaceObjects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_thirdPlaceObjects != null)
                {
                    Private_thirdPlaceObjects.Value = value;
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

        internal UnityEngine.GameObject __intnl_UnityEngineObject_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_11 != null)
                {
                    return Private___intnl_UnityEngineObject_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_11 != null)
                {
                    Private___intnl_UnityEngineObject_11.Value = value;
                }
            }
        }

        internal int? __lcl_numSecondPlayers_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_numSecondPlayers_SystemInt32_0 != null)
                {
                    return Private___lcl_numSecondPlayers_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_numSecondPlayers_SystemInt32_0 != null)
                    {
                        Private___lcl_numSecondPlayers_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __lcl_foundBehaviours_UnityEngineComponentArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_foundBehaviours_UnityEngineComponentArray_0 != null)
                {
                    return Private___lcl_foundBehaviours_UnityEngineComponentArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_foundBehaviours_UnityEngineComponentArray_0 != null)
                {
                    Private___lcl_foundBehaviours_UnityEngineComponentArray_0.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __lcl_foundBehaviours_UnityEngineComponentArray_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_foundBehaviours_UnityEngineComponentArray_1 != null)
                {
                    return Private___lcl_foundBehaviours_UnityEngineComponentArray_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_foundBehaviours_UnityEngineComponentArray_1 != null)
                {
                    Private___lcl_foundBehaviours_UnityEngineComponentArray_1.Value = value;
                }
            }
        }

        internal int? lastGamePhase
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lastGamePhase != null)
                {
                    return Private_lastGamePhase.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lastGamePhase != null)
                    {
                        Private_lastGamePhase.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour selectedCurrency
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_selectedCurrency != null)
                {
                    return Private_selectedCurrency.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_selectedCurrency != null)
                {
                    Private_selectedCurrency.Value = value;
                }
            }
        }

        internal bool? __0_CanSubmitGuesses__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_CanSubmitGuesses__ret != null)
                {
                    return Private___0_CanSubmitGuesses__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_CanSubmitGuesses__ret != null)
                    {
                        Private___0_CanSubmitGuesses__ret.Value = value.Value;
                    }
                }
            }
        }

        internal char[] __gintnl_SystemCharArray_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemCharArray_1 != null)
                {
                    return Private___gintnl_SystemCharArray_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemCharArray_1 != null)
                {
                    Private___gintnl_SystemCharArray_1.Value = value;
                }
            }
        }

        internal float? __const_SystemSingle_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_7 != null)
                {
                    return Private___const_SystemSingle_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_7 != null)
                    {
                        Private___const_SystemSingle_7.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject scoreboardUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scoreboardUI != null)
                {
                    return Private_scoreboardUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_scoreboardUI != null)
                {
                    Private_scoreboardUI.Value = value;
                }
            }
        }

        internal int? __lcl_p_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_p_SystemInt32_0 != null)
                {
                    return Private___lcl_p_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_p_SystemInt32_0 != null)
                    {
                        Private___lcl_p_SystemInt32_0.Value = value.Value;
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

        internal UnityEngine.Transform __3__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3__intnlparam != null)
                {
                    return Private___3__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3__intnlparam != null)
                {
                    Private___3__intnlparam.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_9 != null)
                {
                    return Private___intnl_UnityEngineObject_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_9 != null)
                {
                    Private___intnl_UnityEngineObject_9.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_8 != null)
                {
                    return Private___intnl_UnityEngineObject_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_8 != null)
                {
                    Private___intnl_UnityEngineObject_8.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_7 != null)
                {
                    return Private___intnl_UnityEngineObject_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_7 != null)
                {
                    Private___intnl_UnityEngineObject_7.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_6 != null)
                {
                    return Private___intnl_UnityEngineObject_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_6 != null)
                {
                    Private___intnl_UnityEngineObject_6.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_5 != null)
                {
                    return Private___intnl_UnityEngineObject_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_5 != null)
                {
                    Private___intnl_UnityEngineObject_5.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_4 != null)
                {
                    return Private___intnl_UnityEngineObject_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_4 != null)
                {
                    Private___intnl_UnityEngineObject_4.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_3 != null)
                {
                    return Private___intnl_UnityEngineObject_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_3 != null)
                {
                    Private___intnl_UnityEngineObject_3.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_2 != null)
                {
                    return Private___intnl_UnityEngineObject_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_2 != null)
                {
                    Private___intnl_UnityEngineObject_2.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_1 != null)
                {
                    return Private___intnl_UnityEngineObject_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_1 != null)
                {
                    Private___intnl_UnityEngineObject_1.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_0 != null)
                {
                    return Private___intnl_UnityEngineObject_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_0 != null)
                {
                    Private___intnl_UnityEngineObject_0.Value = value;
                }
            }
        }

        internal float? __lcl_evulatateA_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_evulatateA_SystemSingle_0 != null)
                {
                    return Private___lcl_evulatateA_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_evulatateA_SystemSingle_0 != null)
                    {
                        Private___lcl_evulatateA_SystemSingle_0.Value = value.Value;
                    }
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

        internal string __intnl_SystemString_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemString_6 != null)
                {
                    return Private___intnl_SystemString_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemString_6 != null)
                {
                    Private___intnl_SystemString_6.Value = value;
                }
            }
        }

        internal uint[] __gintnl_SystemUInt32Array_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32Array_3 != null)
                {
                    return Private___gintnl_SystemUInt32Array_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemUInt32Array_3 != null)
                {
                    Private___gintnl_SystemUInt32Array_3.Value = value;
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

        internal int? turnDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_turnDuration != null)
                {
                    return Private_turnDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_turnDuration != null)
                    {
                        Private_turnDuration.Value = value.Value;
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

        internal int? maxRounds
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_maxRounds != null)
                {
                    return Private_maxRounds.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_maxRounds != null)
                    {
                        Private_maxRounds.Value = value.Value;
                    }
                }
            }
        }

        internal int? item
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_item != null)
                {
                    return Private_item.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_item != null)
                    {
                        Private_item.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text thirdScoreText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_thirdScoreText != null)
                {
                    return Private_thirdScoreText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_thirdScoreText != null)
                {
                    Private_thirdScoreText.Value = value;
                }
            }
        }

        internal int? roundsPerPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_roundsPerPlayer != null)
                {
                    return Private_roundsPerPlayer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_roundsPerPlayer != null)
                    {
                        Private_roundsPerPlayer.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_rankPercent_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_rankPercent_SystemSingle_0 != null)
                {
                    return Private___lcl_rankPercent_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_rankPercent_SystemSingle_0 != null)
                    {
                        Private___lcl_rankPercent_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_minTimer_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_minTimer_SystemInt32_0 != null)
                {
                    return Private___lcl_minTimer_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_minTimer_SystemInt32_0 != null)
                    {
                        Private___lcl_minTimer_SystemInt32_0.Value = value.Value;
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

        internal int? __0_newGamePhase__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newGamePhase__param != null)
                {
                    return Private___0_newGamePhase__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newGamePhase__param != null)
                    {
                        Private___0_newGamePhase__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject secondPlaceObjects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondPlaceObjects != null)
                {
                    return Private_secondPlaceObjects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_secondPlaceObjects != null)
                {
                    Private_secondPlaceObjects.Value = value;
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

        internal bool? __intnl_SystemBoolean_81
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_81 != null)
                {
                    return Private___intnl_SystemBoolean_81.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_81 != null)
                    {
                        Private___intnl_SystemBoolean_81.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_91
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_91 != null)
                {
                    return Private___intnl_SystemBoolean_91.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_91 != null)
                    {
                        Private___intnl_SystemBoolean_91.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_71
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_71 != null)
                {
                    return Private___intnl_SystemBoolean_71.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_71 != null)
                    {
                        Private___intnl_SystemBoolean_71.Value = value.Value;
                    }
                }
            }
        }

        internal int? totalRounds
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_totalRounds != null)
                {
                    return Private_totalRounds.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_totalRounds != null)
                    {
                        Private_totalRounds.Value = value.Value;
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

        internal UnityEngine.Texture2D[] items
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_items != null)
                {
                    return Private_items.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_items != null)
                {
                    Private_items.Value = value;
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

        internal int? __intnl_SystemInt32_47
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_47 != null)
                {
                    return Private___intnl_SystemInt32_47.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_47 != null)
                    {
                        Private___intnl_SystemInt32_47.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text itemNameText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemNameText != null)
                {
                    return Private_itemNameText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemNameText != null)
                {
                    Private_itemNameText.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Button startButton
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

        internal int? __lcl_secondScore_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_secondScore_SystemInt32_0 != null)
                {
                    return Private___lcl_secondScore_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_secondScore_SystemInt32_0 != null)
                    {
                        Private___lcl_secondScore_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioSource scoreShuffleSound
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scoreShuffleSound != null)
                {
                    return Private_scoreShuffleSound.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_scoreShuffleSound != null)
                {
                    Private_scoreShuffleSound.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __0__intnlparam
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

        internal VRC.Udon.UdonBehaviour itemHideMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemHideMusic != null)
                {
                    return Private_itemHideMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemHideMusic != null)
                {
                    Private_itemHideMusic.Value = value;
                }
            }
        }

        internal int? __lcl_waitingOnPlayers_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_waitingOnPlayers_SystemInt32_0 != null)
                {
                    return Private___lcl_waitingOnPlayers_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_waitingOnPlayers_SystemInt32_0 != null)
                    {
                        Private___lcl_waitingOnPlayers_SystemInt32_0.Value = value.Value;
                    }
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

        internal int? __0_newCurrencyIndex__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_newCurrencyIndex__param != null)
                {
                    return Private___0_newCurrencyIndex__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_newCurrencyIndex__param != null)
                    {
                        Private___0_newCurrencyIndex__param.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_effectiveRank_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_effectiveRank_SystemInt32_0 != null)
                {
                    return Private___lcl_effectiveRank_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_effectiveRank_SystemInt32_0 != null)
                    {
                        Private___lcl_effectiveRank_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __7__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7__intnlparam != null)
                {
                    return Private___7__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7__intnlparam != null)
                {
                    Private___7__intnlparam.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Text masterNameText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_masterNameText != null)
                {
                    return Private_masterNameText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_masterNameText != null)
                {
                    Private_masterNameText.Value = value;
                }
            }
        }

        internal UnityEngine.Bounds? __intnl_UnityEngineBounds_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineBounds_0 != null)
                {
                    return Private___intnl_UnityEngineBounds_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineBounds_0 != null)
                    {
                        Private___intnl_UnityEngineBounds_0.Value = value.Value;
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

        internal int? timer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timer != null)
                {
                    return Private_timer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timer != null)
                    {
                        Private_timer.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_89
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_89 != null)
                {
                    return Private___intnl_SystemBoolean_89.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_89 != null)
                    {
                        Private___intnl_SystemBoolean_89.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_99
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_99 != null)
                {
                    return Private___intnl_SystemBoolean_99.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_99 != null)
                    {
                        Private___intnl_SystemBoolean_99.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_69
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_69 != null)
                {
                    return Private___intnl_SystemBoolean_69.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_69 != null)
                    {
                        Private___intnl_SystemBoolean_69.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_79
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_79 != null)
                {
                    return Private___intnl_SystemBoolean_79.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_79 != null)
                    {
                        Private___intnl_SystemBoolean_79.Value = value.Value;
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

        internal UnityEngine.GameObject __intnl_UnityEngineGameObject_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineGameObject_5 != null)
                {
                    return Private___intnl_UnityEngineGameObject_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineGameObject_5 != null)
                {
                    Private___intnl_UnityEngineGameObject_5.Value = value;
                }
            }
        }

        internal float? __const_SystemSingle_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_9 != null)
                {
                    return Private___const_SystemSingle_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_9 != null)
                    {
                        Private___const_SystemSingle_9.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_84
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_84 != null)
                {
                    return Private___intnl_SystemBoolean_84.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_84 != null)
                    {
                        Private___intnl_SystemBoolean_84.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_94
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_94 != null)
                {
                    return Private___intnl_SystemBoolean_94.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_94 != null)
                    {
                        Private___intnl_SystemBoolean_94.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_64 != null)
                {
                    return Private___intnl_SystemBoolean_64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_64 != null)
                    {
                        Private___intnl_SystemBoolean_64.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_74
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_74 != null)
                {
                    return Private___intnl_SystemBoolean_74.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_74 != null)
                    {
                        Private___intnl_SystemBoolean_74.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemObject_34
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_34 != null)
                {
                    return Private___intnl_SystemObject_34.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemObject_34 != null)
                    {
                        Private___intnl_SystemObject_34.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __intnl_UnityEngineComponentArray_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponentArray_3 != null)
                {
                    return Private___intnl_UnityEngineComponentArray_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponentArray_3 != null)
                {
                    Private___intnl_UnityEngineComponentArray_3.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __intnl_UnityEngineComponentArray_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponentArray_2 != null)
                {
                    return Private___intnl_UnityEngineComponentArray_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponentArray_2 != null)
                {
                    Private___intnl_UnityEngineComponentArray_2.Value = value;
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

        internal UnityEngine.Component[] players
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_players != null)
                {
                    return Private_players.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_players != null)
                {
                    Private_players.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject stageGuessUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_stageGuessUI != null)
                {
                    return Private_stageGuessUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_stageGuessUI != null)
                {
                    Private_stageGuessUI.Value = value;
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

        internal int? __intnl_SystemInt32_49
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_49 != null)
                {
                    return Private___intnl_SystemInt32_49.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_49 != null)
                    {
                        Private___intnl_SystemInt32_49.Value = value.Value;
                    }
                }
            }
        }

        internal int? cooldownDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cooldownDuration != null)
                {
                    return Private_cooldownDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cooldownDuration != null)
                    {
                        Private_cooldownDuration.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_13 != null)
                {
                    return Private___intnl_UnityEngineObject_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_13 != null)
                {
                    Private___intnl_UnityEngineObject_13.Value = value;
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

        internal string[] ph_PhaseNames
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ph_PhaseNames != null)
                {
                    return Private_ph_PhaseNames.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ph_PhaseNames != null)
                {
                    Private_ph_PhaseNames.Value = value;
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

        internal UnityEngine.Component[] __4__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4__intnlparam != null)
                {
                    return Private___4__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4__intnlparam != null)
                {
                    Private___4__intnlparam.Value = value;
                }
            }
        }

        internal int? __lcl_numthirdPlayers_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_numthirdPlayers_SystemInt32_0 != null)
                {
                    return Private___lcl_numthirdPlayers_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_numthirdPlayers_SystemInt32_0 != null)
                    {
                        Private___lcl_numthirdPlayers_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __lcl_allPlayersSubmitted_SystemBoolean_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_allPlayersSubmitted_SystemBoolean_0 != null)
                {
                    return Private___lcl_allPlayersSubmitted_SystemBoolean_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_allPlayersSubmitted_SystemBoolean_0 != null)
                    {
                        Private___lcl_allPlayersSubmitted_SystemBoolean_0.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_87
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_87 != null)
                {
                    return Private___intnl_SystemBoolean_87.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_87 != null)
                    {
                        Private___intnl_SystemBoolean_87.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_97
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_97 != null)
                {
                    return Private___intnl_SystemBoolean_97.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_97 != null)
                    {
                        Private___intnl_SystemBoolean_97.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_67
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_67 != null)
                {
                    return Private___intnl_SystemBoolean_67.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_67 != null)
                    {
                        Private___intnl_SystemBoolean_67.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_77
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_77 != null)
                {
                    return Private___intnl_SystemBoolean_77.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_77 != null)
                    {
                        Private___intnl_SystemBoolean_77.Value = value.Value;
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

        internal int? __intnl_SystemInt32_51
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_51 != null)
                {
                    return Private___intnl_SystemInt32_51.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_51 != null)
                    {
                        Private___intnl_SystemInt32_51.Value = value.Value;
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

        internal int? __lcl_highestRank_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_highestRank_SystemInt32_0 != null)
                {
                    return Private___lcl_highestRank_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_highestRank_SystemInt32_0 != null)
                    {
                        Private___lcl_highestRank_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Animator itemAnimator
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemAnimator != null)
                {
                    return Private_itemAnimator.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemAnimator != null)
                {
                    Private_itemAnimator.Value = value;
                }
            }
        }

        internal int? __0_num__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_num__param != null)
                {
                    return Private___0_num__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_num__param != null)
                    {
                        Private___0_num__param.Value = value.Value;
                    }
                }
            }
        }

        internal string __intnl_SystemString_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemString_8 != null)
                {
                    return Private___intnl_SystemString_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemString_8 != null)
                {
                    Private___intnl_SystemString_8.Value = value;
                }
            }
        }

        internal uint[] __gintnl_SystemUInt32Array_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32Array_1 != null)
                {
                    return Private___gintnl_SystemUInt32Array_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemUInt32Array_1 != null)
                {
                    Private___gintnl_SystemUInt32Array_1.Value = value;
                }
            }
        }

        internal int[] randomItemOrder
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_randomItemOrder != null)
                {
                    return Private_randomItemOrder.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_randomItemOrder != null)
                {
                    Private_randomItemOrder.Value = value;
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

        internal int? drumrollDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_drumrollDuration != null)
                {
                    return Private_drumrollDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_drumrollDuration != null)
                    {
                        Private_drumrollDuration.Value = value.Value;
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

        internal int? __lcl_secs_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_secs_SystemInt32_0 != null)
                {
                    return Private___lcl_secs_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_secs_SystemInt32_0 != null)
                    {
                        Private___lcl_secs_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour postgameMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_postgameMusic != null)
                {
                    return Private_postgameMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_postgameMusic != null)
                {
                    Private_postgameMusic.Value = value;
                }
            }
        }

        internal string __const_SystemString_86
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_86 != null)
                {
                    return Private___const_SystemString_86.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_86 != null)
                {
                    Private___const_SystemString_86.Value = value;
                }
            }
        }

        internal string __const_SystemString_87
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_87 != null)
                {
                    return Private___const_SystemString_87.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_87 != null)
                {
                    Private___const_SystemString_87.Value = value;
                }
            }
        }

        internal string __const_SystemString_84
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_84 != null)
                {
                    return Private___const_SystemString_84.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_84 != null)
                {
                    Private___const_SystemString_84.Value = value;
                }
            }
        }

        internal string __const_SystemString_85
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_85 != null)
                {
                    return Private___const_SystemString_85.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_85 != null)
                {
                    Private___const_SystemString_85.Value = value;
                }
            }
        }

        internal string __const_SystemString_82
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_82 != null)
                {
                    return Private___const_SystemString_82.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_82 != null)
                {
                    Private___const_SystemString_82.Value = value;
                }
            }
        }

        internal string __const_SystemString_83
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_83 != null)
                {
                    return Private___const_SystemString_83.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_83 != null)
                {
                    Private___const_SystemString_83.Value = value;
                }
            }
        }

        internal string __const_SystemString_80
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_80 != null)
                {
                    return Private___const_SystemString_80.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_80 != null)
                {
                    Private___const_SystemString_80.Value = value;
                }
            }
        }

        internal string __const_SystemString_81
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_81 != null)
                {
                    return Private___const_SystemString_81.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_81 != null)
                {
                    Private___const_SystemString_81.Value = value;
                }
            }
        }

        internal string __const_SystemString_88
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_88 != null)
                {
                    return Private___const_SystemString_88.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_88 != null)
                {
                    Private___const_SystemString_88.Value = value;
                }
            }
        }

        internal string __const_SystemString_89
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_89 != null)
                {
                    return Private___const_SystemString_89.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_89 != null)
                {
                    Private___const_SystemString_89.Value = value;
                }
            }
        }

        internal int? __lcl_q_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_q_SystemInt32_0 != null)
                {
                    return Private___lcl_q_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_q_SystemInt32_0 != null)
                    {
                        Private___lcl_q_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal long? __intnl_SystemInt64_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt64_1 != null)
                {
                    return Private___intnl_SystemInt64_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt64_1 != null)
                    {
                        Private___intnl_SystemInt64_1.Value = value.Value;
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

        internal float? __lcl_guessValue_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_guessValue_SystemSingle_0 != null)
                {
                    return Private___lcl_guessValue_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_guessValue_SystemSingle_0 != null)
                    {
                        Private___lcl_guessValue_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? canAbortGame
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_canAbortGame != null)
                {
                    return Private_canAbortGame.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_canAbortGame != null)
                    {
                        Private_canAbortGame.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_4 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_4 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_4.Value = value;
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

        internal int? minPlayers
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_minPlayers != null)
                {
                    return Private_minPlayers.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_minPlayers != null)
                    {
                        Private_minPlayers.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_v_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_v_SystemSingle_0 != null)
                {
                    return Private___lcl_v_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_v_SystemSingle_0 != null)
                    {
                        Private___lcl_v_SystemSingle_0.Value = value.Value;
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

        internal UnityEngine.KeyCode? __const_UnityEngineKeyCode_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_UnityEngineKeyCode_0 != null)
                {
                    return Private___const_UnityEngineKeyCode_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_UnityEngineKeyCode_0 != null)
                    {
                        Private___const_UnityEngineKeyCode_0.Value = value.Value;
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

        internal int? revealBestGuessDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_revealBestGuessDuration != null)
                {
                    return Private_revealBestGuessDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_revealBestGuessDuration != null)
                    {
                        Private_revealBestGuessDuration.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour postRevealMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_postRevealMusic != null)
                {
                    return Private_postRevealMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_postRevealMusic != null)
                {
                    Private_postRevealMusic.Value = value;
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

        internal float? __lcl_revealCumulativeDelay_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_revealCumulativeDelay_SystemSingle_0 != null)
                {
                    return Private___lcl_revealCumulativeDelay_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_revealCumulativeDelay_SystemSingle_0 != null)
                    {
                        Private___lcl_revealCumulativeDelay_SystemSingle_0.Value = value.Value;
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

        internal float? nextTimerTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_nextTimerTime != null)
                {
                    return Private_nextTimerTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_nextTimerTime != null)
                    {
                        Private_nextTimerTime.Value = value.Value;
                    }
                }
            }
        }

        internal int? selectedCurrencyIndex
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_selectedCurrencyIndex != null)
                {
                    return Private_selectedCurrencyIndex.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_selectedCurrencyIndex != null)
                    {
                        Private_selectedCurrencyIndex.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject stageCountdownUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_stageCountdownUI != null)
                {
                    return Private_stageCountdownUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_stageCountdownUI != null)
                {
                    Private_stageCountdownUI.Value = value;
                }
            }
        }

        internal UnityEngine.AudioSource timerTickSound1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerTickSound1 != null)
                {
                    return Private_timerTickSound1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_timerTickSound1 != null)
                {
                    Private_timerTickSound1.Value = value;
                }
            }
        }

        internal UnityEngine.AudioSource timerTickSound0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerTickSound0 != null)
                {
                    return Private_timerTickSound0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_timerTickSound0 != null)
                {
                    Private_timerTickSound0.Value = value;
                }
            }
        }

        internal bool? __0_LocalPlayerIsParticipating__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_LocalPlayerIsParticipating__ret != null)
                {
                    return Private___0_LocalPlayerIsParticipating__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_LocalPlayerIsParticipating__ret != null)
                    {
                        Private___0_LocalPlayerIsParticipating__ret.Value = value.Value;
                    }
                }
            }
        }

        internal int? minRounds
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_minRounds != null)
                {
                    return Private_minRounds.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_minRounds != null)
                    {
                        Private_minRounds.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioSource scoreStartSound
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scoreStartSound != null)
                {
                    return Private_scoreStartSound.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_scoreStartSound != null)
                {
                    Private_scoreStartSound.Value = value;
                }
            }
        }

        internal int? scoreboardShuffleDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scoreboardShuffleDuration != null)
                {
                    return Private_scoreboardShuffleDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_scoreboardShuffleDuration != null)
                    {
                        Private_scoreboardShuffleDuration.Value = value.Value;
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

        internal UnityEngine.UI.Image masterLockIndicator
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_masterLockIndicator != null)
                {
                    return Private_masterLockIndicator.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_masterLockIndicator != null)
                {
                    Private_masterLockIndicator.Value = value;
                }
            }
        }

        internal bool? __intnl_SystemBoolean_100
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_100 != null)
                {
                    return Private___intnl_SystemBoolean_100.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_100 != null)
                    {
                        Private___intnl_SystemBoolean_100.Value = value.Value;
                    }
                }
            }
        }

        internal float? postRevealMusicDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_postRevealMusicDelay != null)
                {
                    return Private_postRevealMusicDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_postRevealMusicDelay != null)
                    {
                        Private_postRevealMusicDelay.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour guessRevealMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_guessRevealMusic != null)
                {
                    return Private_guessRevealMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_guessRevealMusic != null)
                {
                    Private_guessRevealMusic.Value = value;
                }
            }
        }

        internal int? tickingSoundDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tickingSoundDuration != null)
                {
                    return Private_tickingSoundDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_tickingSoundDuration != null)
                    {
                        Private_tickingSoundDuration.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_82
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_82 != null)
                {
                    return Private___intnl_SystemBoolean_82.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_82 != null)
                    {
                        Private___intnl_SystemBoolean_82.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_92
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_92 != null)
                {
                    return Private___intnl_SystemBoolean_92.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_92 != null)
                    {
                        Private___intnl_SystemBoolean_92.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_62
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_62 != null)
                {
                    return Private___intnl_SystemBoolean_62.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_62 != null)
                    {
                        Private___intnl_SystemBoolean_62.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_72
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_72 != null)
                {
                    return Private___intnl_SystemBoolean_72.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_72 != null)
                    {
                        Private___intnl_SystemBoolean_72.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour itemShowMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemShowMusic != null)
                {
                    return Private_itemShowMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemShowMusic != null)
                {
                    Private_itemShowMusic.Value = value;
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

        internal UnityEngine.Component[] __lcl_instanceBehaviours_UnityEngineComponentArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_instanceBehaviours_UnityEngineComponentArray_0 != null)
                {
                    return Private___lcl_instanceBehaviours_UnityEngineComponentArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_instanceBehaviours_UnityEngineComponentArray_0 != null)
                {
                    Private___lcl_instanceBehaviours_UnityEngineComponentArray_0.Value = value;
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

        internal System.Object[] __gintnl_SystemObjectArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemObjectArray_0 != null)
                {
                    return Private___gintnl_SystemObjectArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemObjectArray_0 != null)
                {
                    Private___gintnl_SystemObjectArray_0.Value = value;
                }
            }
        }

        internal int? revealActualPriceDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_revealActualPriceDuration != null)
                {
                    return Private_revealActualPriceDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_revealActualPriceDuration != null)
                    {
                        Private_revealActualPriceDuration.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __lcl_guessedExact_SystemBoolean_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_guessedExact_SystemBoolean_0 != null)
                {
                    return Private___lcl_guessedExact_SystemBoolean_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_guessedExact_SystemBoolean_0 != null)
                    {
                        Private___lcl_guessedExact_SystemBoolean_0.Value = value.Value;
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

        internal int? __lcl_thirdScore_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_thirdScore_SystemInt32_0 != null)
                {
                    return Private___lcl_thirdScore_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_thirdScore_SystemInt32_0 != null)
                    {
                        Private___lcl_thirdScore_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject stagePostgameUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_stagePostgameUI != null)
                {
                    return Private_stagePostgameUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_stagePostgameUI != null)
                {
                    Private_stagePostgameUI.Value = value;
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

        internal int? waitToAddScoresDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_waitToAddScoresDelay != null)
                {
                    return Private_waitToAddScoresDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_waitToAddScoresDelay != null)
                    {
                        Private_waitToAddScoresDelay.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Animator priceRevealAnim
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_priceRevealAnim != null)
                {
                    return Private_priceRevealAnim.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_priceRevealAnim != null)
                {
                    Private_priceRevealAnim.Value = value;
                }
            }
        }

        internal int? __lcl_totalNumPlayers_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_totalNumPlayers_SystemInt32_0 != null)
                {
                    return Private___lcl_totalNumPlayers_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_totalNumPlayers_SystemInt32_0 != null)
                    {
                        Private___lcl_totalNumPlayers_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour itemMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemMusic != null)
                {
                    return Private_itemMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemMusic != null)
                {
                    Private_itemMusic.Value = value;
                }
            }
        }

        internal int? __lcl_mins_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_mins_SystemInt32_0 != null)
                {
                    return Private___lcl_mins_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_mins_SystemInt32_0 != null)
                    {
                        Private___lcl_mins_SystemInt32_0.Value = value.Value;
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

        internal int? __lcl_ascendingRank_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_ascendingRank_SystemInt32_0 != null)
                {
                    return Private___lcl_ascendingRank_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_ascendingRank_SystemInt32_0 != null)
                    {
                        Private___lcl_ascendingRank_SystemInt32_0.Value = value.Value;
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

        internal UnityEngine.Transform __intnl_UnityEngineTransform_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_1 != null)
                {
                    return Private___intnl_UnityEngineTransform_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_1 != null)
                {
                    Private___intnl_UnityEngineTransform_1.Value = value;
                }
            }
        }

        internal bool? canStartGame
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_canStartGame != null)
                {
                    return Private_canStartGame.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_canStartGame != null)
                    {
                        Private_canStartGame.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour playerManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerManager != null)
                {
                    return Private_playerManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerManager != null)
                {
                    Private_playerManager.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __5__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5__intnlparam != null)
                {
                    return Private___5__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5__intnlparam != null)
                {
                    Private___5__intnlparam.Value = value;
                }
            }
        }

        internal int? roundsPassed
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_roundsPassed != null)
                {
                    return Private_roundsPassed.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_roundsPassed != null)
                    {
                        Private_roundsPassed.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_85
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_85 != null)
                {
                    return Private___intnl_SystemBoolean_85.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_85 != null)
                    {
                        Private___intnl_SystemBoolean_85.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_95
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_95 != null)
                {
                    return Private___intnl_SystemBoolean_95.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_95 != null)
                    {
                        Private___intnl_SystemBoolean_95.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_65
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_65 != null)
                {
                    return Private___intnl_SystemBoolean_65.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_65 != null)
                    {
                        Private___intnl_SystemBoolean_65.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_75
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_75 != null)
                {
                    return Private___intnl_SystemBoolean_75.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_75 != null)
                    {
                        Private___intnl_SystemBoolean_75.Value = value.Value;
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

        internal int? __intnl_SystemInt32_53
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_53 != null)
                {
                    return Private___intnl_SystemInt32_53.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_53 != null)
                    {
                        Private___intnl_SystemInt32_53.Value = value.Value;
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

        internal int? __lcl_numPlayersRevealed_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_numPlayersRevealed_SystemInt32_0 != null)
                {
                    return Private___lcl_numPlayersRevealed_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_numPlayersRevealed_SystemInt32_0 != null)
                    {
                        Private___lcl_numPlayersRevealed_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_scoreChange_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_scoreChange_SystemSingle_0 != null)
                {
                    return Private___lcl_scoreChange_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_scoreChange_SystemSingle_0 != null)
                    {
                        Private___lcl_scoreChange_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? postgameDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_postgameDuration != null)
                {
                    return Private_postgameDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_postgameDuration != null)
                    {
                        Private_postgameDuration.Value = value.Value;
                    }
                }
            }
        }

        internal float? exactGuessThreshold
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_exactGuessThreshold != null)
                {
                    return Private_exactGuessThreshold.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_exactGuessThreshold != null)
                    {
                        Private_exactGuessThreshold.Value = value.Value;
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

        internal int? __intnl_SystemInt32_48
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_48 != null)
                {
                    return Private___intnl_SystemInt32_48.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_48 != null)
                    {
                        Private___intnl_SystemInt32_48.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour introMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_introMusic != null)
                {
                    return Private_introMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_introMusic != null)
                {
                    Private_introMusic.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Text __lcl_t_UnityEngineUIText_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t_UnityEngineUIText_0 != null)
                {
                    return Private___lcl_t_UnityEngineUIText_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_t_UnityEngineUIText_0 != null)
                {
                    Private___lcl_t_UnityEngineUIText_0.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Text roundText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_roundText != null)
                {
                    return Private_roundText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_roundText != null)
                {
                    Private_roundText.Value = value;
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

        internal int? hurryUpSeconds
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hurryUpSeconds != null)
                {
                    return Private_hurryUpSeconds.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hurryUpSeconds != null)
                    {
                        Private_hurryUpSeconds.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour exactGuessMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_exactGuessMusic != null)
                {
                    return Private_exactGuessMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_exactGuessMusic != null)
                {
                    Private_exactGuessMusic.Value = value;
                }
            }
        }

        internal UnityEngine.Animator itemNameAnimator
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemNameAnimator != null)
                {
                    return Private_itemNameAnimator.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemNameAnimator != null)
                {
                    Private_itemNameAnimator.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __intnl_UnityEngineObject_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineObject_10 != null)
                {
                    return Private___intnl_UnityEngineObject_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineObject_10 != null)
                {
                    Private___intnl_UnityEngineObject_10.Value = value;
                }
            }
        }

        internal char? __const_SystemChar_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemChar_0 != null)
                {
                    return Private___const_SystemChar_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemChar_0 != null)
                    {
                        Private___const_SystemChar_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text thirdNameText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_thirdNameText != null)
                {
                    return Private_thirdNameText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_thirdNameText != null)
                {
                    Private_thirdNameText.Value = value;
                }
            }
        }

        internal int? __lcl_arraySize_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_arraySize_SystemInt32_0 != null)
                {
                    return Private___lcl_arraySize_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_arraySize_SystemInt32_0 != null)
                    {
                        Private___lcl_arraySize_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_arraySize_SystemInt32_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_arraySize_SystemInt32_1 != null)
                {
                    return Private___lcl_arraySize_SystemInt32_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_arraySize_SystemInt32_1 != null)
                    {
                        Private___lcl_arraySize_SystemInt32_1.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text secondNameText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondNameText != null)
                {
                    return Private_secondNameText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_secondNameText != null)
                {
                    Private_secondNameText.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour revealMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_revealMusic != null)
                {
                    return Private_revealMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_revealMusic != null)
                {
                    Private_revealMusic.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour keypad
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_keypad != null)
                {
                    return Private_keypad.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_keypad != null)
                {
                    Private_keypad.Value = value;
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

        internal char[] __gintnl_SystemCharArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemCharArray_0 != null)
                {
                    return Private___gintnl_SystemCharArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemCharArray_0 != null)
                {
                    Private___gintnl_SystemCharArray_0.Value = value;
                }
            }
        }

        internal float? __const_SystemSingle_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_6 != null)
                {
                    return Private___const_SystemSingle_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_6 != null)
                    {
                        Private___const_SystemSingle_6.Value = value.Value;
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

        internal int? __intnl_SystemInt32_50
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_50 != null)
                {
                    return Private___intnl_SystemInt32_50.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_50 != null)
                    {
                        Private___intnl_SystemInt32_50.Value = value.Value;
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

        internal bool? __0_IsRoundPhase__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_IsRoundPhase__ret != null)
                {
                    return Private___0_IsRoundPhase__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_IsRoundPhase__ret != null)
                    {
                        Private___0_IsRoundPhase__ret.Value = value.Value;
                    }
                }
            }
        }

        internal string __intnl_SystemString_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemString_7 != null)
                {
                    return Private___intnl_SystemString_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemString_7 != null)
                {
                    Private___intnl_SystemString_7.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Text revealGuessValueText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_revealGuessValueText != null)
                {
                    return Private_revealGuessValueText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_revealGuessValueText != null)
                {
                    Private_revealGuessValueText.Value = value;
                }
            }
        }

        internal uint[] __gintnl_SystemUInt32Array_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32Array_2 != null)
                {
                    return Private___gintnl_SystemUInt32Array_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemUInt32Array_2 != null)
                {
                    Private___gintnl_SystemUInt32Array_2.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject stageItemUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_stageItemUI != null)
                {
                    return Private_stageItemUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_stageItemUI != null)
                {
                    Private_stageItemUI.Value = value;
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

        internal int? hurryUpPlayersDisregarded
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hurryUpPlayersDisregarded != null)
                {
                    return Private_hurryUpPlayersDisregarded.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hurryUpPlayersDisregarded != null)
                    {
                        Private_hurryUpPlayersDisregarded.Value = value.Value;
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

        internal int? revealEachPlayerDuration
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_revealEachPlayerDuration != null)
                {
                    return Private_revealEachPlayerDuration.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_revealEachPlayerDuration != null)
                    {
                        Private_revealEachPlayerDuration.Value = value.Value;
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

        internal UnityEngine.UI.Text itemPriceText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemPriceText != null)
                {
                    return Private_itemPriceText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemPriceText != null)
                {
                    Private_itemPriceText.Value = value;
                }
            }
        }

        internal UnityEngine.AudioSource scoreGiveSound
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scoreGiveSound != null)
                {
                    return Private_scoreGiveSound.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_scoreGiveSound != null)
                {
                    Private_scoreGiveSound.Value = value;
                }
            }
        }

        internal int? numPlayersForSoundFX
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_numPlayersForSoundFX != null)
                {
                    return Private_numPlayersForSoundFX.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_numPlayersForSoundFX != null)
                    {
                        Private_numPlayersForSoundFX.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_5 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_5 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_5.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject stageWaitingUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_stageWaitingUI != null)
                {
                    return Private_stageWaitingUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_stageWaitingUI != null)
                {
                    Private_stageWaitingUI.Value = value;
                }
            }
        }

        internal float? __lcl_v_SystemSingle_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_v_SystemSingle_1 != null)
                {
                    return Private___lcl_v_SystemSingle_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_v_SystemSingle_1 != null)
                    {
                        Private___lcl_v_SystemSingle_1.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Animator timerBlipAnim
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timerBlipAnim != null)
                {
                    return Private_timerBlipAnim.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_timerBlipAnim != null)
                {
                    Private_timerBlipAnim.Value = value;
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

        internal UnityEngine.GameObject stageLoadingUI
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_stageLoadingUI != null)
                {
                    return Private_stageLoadingUI.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_stageLoadingUI != null)
                {
                    Private_stageLoadingUI.Value = value;
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

        internal int? lastItem
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lastItem != null)
                {
                    return Private_lastItem.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lastItem != null)
                    {
                        Private_lastItem.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __2__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2__intnlparam != null)
                {
                    return Private___2__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2__intnlparam != null)
                {
                    Private___2__intnlparam.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineComponent_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponent_1 != null)
                {
                    return Private___intnl_UnityEngineComponent_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponent_1 != null)
                {
                    Private___intnl_UnityEngineComponent_1.Value = value;
                }
            }
        }

        internal bool? __intnl_SystemBoolean_80
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_80 != null)
                {
                    return Private___intnl_SystemBoolean_80.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_80 != null)
                    {
                        Private___intnl_SystemBoolean_80.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_90
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_90 != null)
                {
                    return Private___intnl_SystemBoolean_90.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_90 != null)
                    {
                        Private___intnl_SystemBoolean_90.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_70
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_70 != null)
                {
                    return Private___intnl_SystemBoolean_70.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_70 != null)
                    {
                        Private___intnl_SystemBoolean_70.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_evulatateB_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_evulatateB_SystemSingle_0 != null)
                {
                    return Private___lcl_evulatateB_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_evulatateB_SystemSingle_0 != null)
                    {
                        Private___lcl_evulatateB_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? masterLocked
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_masterLocked != null)
                {
                    return Private_masterLocked.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_masterLocked != null)
                    {
                        Private_masterLocked.Value = value.Value;
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

        internal UnityEngine.AudioSource scoreboardSubmitSound
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scoreboardSubmitSound != null)
                {
                    return Private_scoreboardSubmitSound.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_scoreboardSubmitSound != null)
                {
                    Private_scoreboardSubmitSound.Value = value;
                }
            }
        }

        internal System.Object[] __gintnl_SystemObjectArray_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemObjectArray_2 != null)
                {
                    return Private___gintnl_SystemObjectArray_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemObjectArray_2 != null)
                {
                    Private___gintnl_SystemObjectArray_2.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Button restartButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_restartButton != null)
                {
                    return Private_restartButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_restartButton != null)
                {
                    Private_restartButton.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __lcl_behaviour_VRCUdonUdonBehaviour_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_1 != null)
                {
                    return Private___lcl_behaviour_VRCUdonUdonBehaviour_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_1 != null)
                {
                    Private___lcl_behaviour_VRCUdonUdonBehaviour_1.Value = value;
                }
            }
        }

        internal bool? newPlayersShouldAutoJoin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_newPlayersShouldAutoJoin != null)
                {
                    return Private_newPlayersShouldAutoJoin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_newPlayersShouldAutoJoin != null)
                    {
                        Private_newPlayersShouldAutoJoin.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour drumrollMusic
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_drumrollMusic != null)
                {
                    return Private_drumrollMusic.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_drumrollMusic != null)
                {
                    Private_drumrollMusic.Value = value;
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

        internal UnityEngine.UI.Text itemSourceText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemSourceText != null)
                {
                    return Private_itemSourceText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_itemSourceText != null)
                {
                    Private_itemSourceText.Value = value;
                }
            }
        }

        internal int? __lcl_numHighrankPlayers_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_numHighrankPlayers_SystemInt32_0 != null)
                {
                    return Private___lcl_numHighrankPlayers_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_numHighrankPlayers_SystemInt32_0 != null)
                    {
                        Private___lcl_numHighrankPlayers_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text revealGuessNameText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_revealGuessNameText != null)
                {
                    return Private_revealGuessNameText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_revealGuessNameText != null)
                {
                    Private_revealGuessNameText.Value = value;
                }
            }
        }

        internal string __lcl_timeString_SystemString_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_timeString_SystemString_0 != null)
                {
                    return Private___lcl_timeString_SystemString_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_timeString_SystemString_0 != null)
                {
                    Private___lcl_timeString_SystemString_0.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Text victoryScoreText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_victoryScoreText != null)
                {
                    return Private_victoryScoreText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_victoryScoreText != null)
                {
                    Private_victoryScoreText.Value = value;
                }
            }
        }

        internal string __const_SystemString_76
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_76 != null)
                {
                    return Private___const_SystemString_76.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_76 != null)
                {
                    Private___const_SystemString_76.Value = value;
                }
            }
        }

        internal string __const_SystemString_77
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_77 != null)
                {
                    return Private___const_SystemString_77.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_77 != null)
                {
                    Private___const_SystemString_77.Value = value;
                }
            }
        }

        internal string __const_SystemString_74
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_74 != null)
                {
                    return Private___const_SystemString_74.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_74 != null)
                {
                    Private___const_SystemString_74.Value = value;
                }
            }
        }

        internal string __const_SystemString_75
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_75 != null)
                {
                    return Private___const_SystemString_75.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_75 != null)
                {
                    Private___const_SystemString_75.Value = value;
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

        internal string __const_SystemString_73
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_73 != null)
                {
                    return Private___const_SystemString_73.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_73 != null)
                {
                    Private___const_SystemString_73.Value = value;
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

        internal string __const_SystemString_78
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_78 != null)
                {
                    return Private___const_SystemString_78.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_78 != null)
                {
                    Private___const_SystemString_78.Value = value;
                }
            }
        }

        internal string __const_SystemString_79
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_79 != null)
                {
                    return Private___const_SystemString_79.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_79 != null)
                {
                    Private___const_SystemString_79.Value = value;
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

        internal float? __const_SystemSingle_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_10 != null)
                {
                    return Private___const_SystemSingle_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_10 != null)
                    {
                        Private___const_SystemSingle_10.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_11 != null)
                {
                    return Private___const_SystemSingle_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_11 != null)
                    {
                        Private___const_SystemSingle_11.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_12 != null)
                {
                    return Private___const_SystemSingle_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_12 != null)
                    {
                        Private___const_SystemSingle_12.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Button abortButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_abortButton != null)
                {
                    return Private_abortButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_abortButton != null)
                {
                    Private_abortButton.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour scoreboard
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_scoreboard != null)
                {
                    return Private_scoreboard.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_scoreboard != null)
                {
                    Private_scoreboard.Value = value;
                }
            }
        }

        internal UnityEngine.BoxCollider gameAreaBounds
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gameAreaBounds != null)
                {
                    return Private_gameAreaBounds.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_gameAreaBounds != null)
                {
                    Private_gameAreaBounds.Value = value;
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

        internal float? itemValue
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_itemValue != null)
                {
                    return Private_itemValue.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_itemValue != null)
                    {
                        Private_itemValue.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_88
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_88 != null)
                {
                    return Private___intnl_SystemBoolean_88.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_88 != null)
                    {
                        Private___intnl_SystemBoolean_88.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_98
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_98 != null)
                {
                    return Private___intnl_SystemBoolean_98.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_98 != null)
                    {
                        Private___intnl_SystemBoolean_98.Value = value.Value;
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

        internal bool? __intnl_SystemBoolean_68
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_68 != null)
                {
                    return Private___intnl_SystemBoolean_68.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_68 != null)
                    {
                        Private___intnl_SystemBoolean_68.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_78
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_78 != null)
                {
                    return Private___intnl_SystemBoolean_78.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_78 != null)
                    {
                        Private___intnl_SystemBoolean_78.Value = value.Value;
                    }
                }
            }
        }

        internal long? __lcl_typeID_SystemObject_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_typeID_SystemObject_1 != null)
                {
                    return Private___lcl_typeID_SystemObject_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_typeID_SystemObject_1 != null)
                    {
                        Private___lcl_typeID_SystemObject_1.Value = value.Value;
                    }
                }
            }
        }

        internal long? __lcl_typeID_SystemObject_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_typeID_SystemObject_0 != null)
                {
                    return Private___lcl_typeID_SystemObject_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_typeID_SystemObject_0 != null)
                    {
                        Private___lcl_typeID_SystemObject_0.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of PriceGuessGameRaw

        #region AstroUdonVariables  of PriceGuessGameRaw

        private AstroUdonVariable<float> Private___const_SystemSingle_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_83 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_93 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_63 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_73 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_secondScoreText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_totalPlayers_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.Component[]> Private___lcl_instanceBehaviours_UnityEngineComponentArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___const_SystemInt64_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___const_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_numHighscorePlayers_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_victoryNameText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Object[]> Private___gintnl_SystemObjectArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_N_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___lcl_participating_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_targetIdx_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_targetIdx_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___intnl_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___0_currentUI__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___6__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private___intnl_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_randomItemIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_targetID_SystemInt64_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_highestScore_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.RawImage> Private_itemImage { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private_currencies { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___lcl_exactGuess_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_hurryUpPlayersMin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_lastTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_masterCalculationDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_86 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_96 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_66 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_76 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_countdownDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private___intnl_SystemInt32_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text[]> Private_timerTexts { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_gamePhase { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint[]> Private___gintnl_SystemUInt32Array_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_thirdPlaceObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_numSecondPlayers_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___lcl_foundBehaviours_UnityEngineComponentArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___lcl_foundBehaviours_UnityEngineComponentArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_lastGamePhase { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_selectedCurrency { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_CanSubmitGuesses__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_scoreboardUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_p_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___3__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_evulatateA_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.Common.Interfaces.NetworkEventTarget> Private___const_VRCUdonCommonInterfacesNetworkEventTarget_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___intnl_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint[]> Private___gintnl_SystemUInt32Array_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private_turnDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_maxRounds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_item { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_thirdScoreText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_roundsPerPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_rankPercent_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_minTimer_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_newGamePhase__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_secondPlaceObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineComponent_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_81 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_91 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_61 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_71 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_totalRounds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Texture2D[]> Private_items { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_itemNameText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Button> Private_startButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_secondScore_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.AudioSource> Private_scoreShuffleSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___0__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_itemHideMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_waitingOnPlayers_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private___0_newCurrencyIndex__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_effectiveRank_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___7__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_masterNameText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Bounds> Private___intnl_UnityEngineBounds_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_timer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_89 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_99 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_69 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_79 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineGameObject_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_84 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_94 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_74 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemObject_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___intnl_UnityEngineComponentArray_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___intnl_UnityEngineComponentArray_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.Component[]> Private_players { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_stageGuessUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_cooldownDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string[]> Private_ph_PhaseNames { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___4__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_numthirdPlayers_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___lcl_allPlayersSubmitted_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_87 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_97 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_67 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_77 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___const_VRCUdonCommonEnumsEventTiming_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_highestRank_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Animator> Private_itemAnimator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_num__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___intnl_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint[]> Private___gintnl_SystemUInt32Array_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int[]> Private_randomItemOrder { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private_drumrollDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_secs_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_postgameMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_86 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_87 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_84 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_85 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_82 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_83 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_80 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_81 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_88 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_89 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_q_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___intnl_SystemInt64_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___intnl_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_guessValue_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_canAbortGame { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_minPlayers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_v_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.KeyCode> Private___const_UnityEngineKeyCode_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_revealBestGuessDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_postRevealMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_revealCumulativeDelay_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_behaviour_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private_nextTimerTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_selectedCurrencyIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_stageCountdownUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.AudioSource> Private_timerTickSound1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.AudioSource> Private_timerTickSound0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_LocalPlayerIsParticipating__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_minRounds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.AudioSource> Private_scoreStartSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_scoreboardShuffleDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___1__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Image> Private_masterLockIndicator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_100 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private_postRevealMusicDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_guessRevealMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_tickingSoundDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_82 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_92 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_62 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_72 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_itemShowMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___lcl_instanceBehaviours_UnityEngineComponentArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Object[]> Private___gintnl_SystemObjectArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_revealActualPriceDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___lcl_guessedExact_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private___lcl_thirdScore_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_stagePostgameUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<float> Private___intnl_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_waitToAddScoresDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Animator> Private_priceRevealAnim { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_totalNumPlayers_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_itemMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_mins_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_targetID_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_ascendingRank_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_canStartGame { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_playerManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___5__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_roundsPassed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_85 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_95 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_65 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_75 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_numPlayersRevealed_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_scoreChange_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_postgameDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private_exactGuessThreshold { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_introMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private___lcl_t_UnityEngineUIText_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_roundText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_hurryUpSeconds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_exactGuessMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Animator> Private_itemNameAnimator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char> Private___const_SystemChar_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_thirdNameText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_arraySize_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_arraySize_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_secondNameText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_revealMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_keypad { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_IsRoundPhase__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___intnl_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_revealGuessValueText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint[]> Private___gintnl_SystemUInt32Array_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_stageItemUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___this_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_hurryUpPlayersDisregarded { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private_revealEachPlayerDuration { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_itemPriceText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.AudioSource> Private_scoreGiveSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_numPlayersForSoundFX { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_stageWaitingUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_v_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Animator> Private_timerBlipAnim { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_stageLoadingUI { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_lastItem { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___2__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineComponent_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_80 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_90 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_70 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_evulatateB_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_masterLocked { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_SystemUInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.AudioSource> Private_scoreboardSubmitSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Object[]> Private___gintnl_SystemObjectArray_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Button> Private_restartButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_behaviour_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_newPlayersShouldAutoJoin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_drumrollMusic { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.UI.Text> Private_itemSourceText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_numHighrankPlayers_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_revealGuessNameText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___lcl_timeString_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Text> Private_victoryScoreText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_76 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_77 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_74 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_75 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_72 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_73 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_70 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_71 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_78 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_79 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Button> Private_abortButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_scoreboard { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.BoxCollider> Private_gameAreaBounds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<float> Private_itemValue { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_88 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_98 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_68 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_78 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_typeID_SystemObject_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_typeID_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of PriceGuessGameRaw
    }
}