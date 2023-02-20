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
    public class PoolParlor_PoolParlorModuleReader : MonoBehaviour
    {
        //Behaviour PoolParlorModule EventKeys
        //Event Key : _onEnable
        //Event Key : _GetSAOMenu
        //Event Key : __0__PrepareVideoForQuest
        //Event Key : __0__SearchYoutube
        //Event Key : __0__PlayVideo
        //Event Key : _update
        //Event Key : __0__SetPhysicsMode
        //Event Key : _SaveGame
        //Event Key : _SAOLoadGame
        //Event Key : _TogglePlayerActive
        //Event Key : _TogglePensActive
        //Event Key : _ToggleExperimentalPhysics
        //Event Key : _ToggleCameraSystem
        //Event Key : _ToggleHologram
        //Event Key : _ToggleProps
        //Event Key : _OnEnableMirror
        //Event Key : _ToggleUSColors
        //Event Key : _ToggleShadowsDisabled
        //Event Key : _ToggleTableTimer
        //Event Key : _SelectCameraOff
        //Event Key : _SelectCameraAuto
        //Event Key : _SelectCameraTop
        //Event Key : _SelectCameraFront
        //Event Key : _SelectCameraSide
        //Event Key : _SelectCameraDynamic
        //Event Key : _SelectTableSkinDefault
        //Event Key : _SelectTableSkinGreen
        //Event Key : _SelectTableSkinBlue
        //Event Key : _SelectTableSkinPurple
        //Event Key : _SelectTableSkinTitanium
        //Event Key : _SelectTableSkinRed
        //Event Key : _SelectTableSkinBlackRed
        //Event Key : _SelectTableSkinBlackBlue
        //Event Key : _SelectTableSkinNavyBlue
        //Event Key : _SelectTableSkinWhiteRed
        //Event Key : _SelectTableSkinTrip
        //Event Key : _SelectTableSkinWoodPinkFelt
        //Event Key : _SelectTableSkinWoodBlackFelt
        //Event Key : _SelectTableSkinWhiteBlue
        //Event Key : _SelectTableSkinPink
        //Event Key : _SelectTableSkinSpace
        //Event Key : _SelectTableSkinMiniGolf
        //Event Key : _SelectTableModelRegular
        //Event Key : _SelectCueSkinDefault
        //Event Key : _SelectCueSkinTournamentWinner
        //Event Key : _SelectCueSkinTrickshotter
        //Event Key : _SelectCueSkinBetaTester
        //Event Key : _SelectCueSkinBlack
        //Event Key : _SelectCueSkinBlue
        //Event Key : _SelectCueSkinPurple
        //Event Key : _SelectCueSkinRed
        //Event Key : _SelectCueSkinWhite
        //Event Key : _SelectCueSkinLightWood
        //Event Key : _SelectCueSkinRedWood
        //Event Key : _SelectCueSkinGuck
        //Event Key : _SelectCueSkinManyDots
        //Event Key : _SelectCueSkinRedMist
        //Event Key : _SelectCueSkinSnakeTrails
        //Event Key : _SelectCueSkinBlahaj
        //Event Key : _SelectCueSkinReferee
        //Event Key : _SelectCueSkinContributor
        //Event Key : _SelectTableSkinContributor
        //Event Key : _OnSAOWalkSpeedChanged
        //Event Key : _OnSAORunSpeedChanged
        //Event Key : _OnSAOStrafeSpeedChanged
        //Event Key : _OnSAOJumpImpulseChanged
        //Event Key : _OnSAOLoliLifterChanged
        //Event Key : _OnLobbyOpened
        //Event Key : _OnReceivedRemoteVersion
        //Event Key : _OnRemoteVersionTimedOut
        //Event Key : _OnDataDecoded
        //Event Key : _GetPenSocialSetting
        //Event Key : _PromptForPenSyncPermission
        //Event Key : __0__RespondToSync
        //Event Key : _OnPenSyncAccepted
        //Event Key : _OnPenSyncRejected
        //Event Key : _OnSyncCompleted
        //Event Key : __0__RespondToPenVisibility
        //Event Key : _CanUseCueSkin
        //Event Key : _CanUseTableSkin
        //Event Key : _GetNameColor
        //Event Key : _OnChatCommand
        //Event Key : _onDeserialization
        //
        private List<Object> AntiGarbageCollection = new();

        public PoolParlor_PoolParlorModuleReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PoolParlor))
            {
                var obj = gameObject.FindUdonEvent("_OnSAOJumpImpulseChanged");
                if (obj != null)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                    PoolParlorModule = obj.RawItem;
                    Initialize_PoolParlorModule();
                }
                else
                {
                    Log.Error("Can't Find BilliardsModule behaviour, Unable to Add Reader Component, did the author update the world?");
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
            Cleanup_PoolParlorModule();
        }

        private RawUdonBehaviour PoolParlorModule { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_PoolParlorModule()
        {
            Private___intnl_SystemBoolean_83 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_83");
            Private___intnl_SystemBoolean_93 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_93");
            Private___intnl_SystemBoolean_13 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_13");
            Private___intnl_SystemBoolean_23 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_23");
            Private___intnl_SystemBoolean_33 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_33");
            Private___intnl_SystemBoolean_43 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_43");
            Private___intnl_SystemBoolean_53 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_53");
            Private___intnl_SystemBoolean_63 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_63");
            Private___intnl_SystemBoolean_73 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_73");
            Private_hologramSystem = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "hologramSystem");
            Private___gintnl_SystemUInt32_96 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_96");
            Private___gintnl_SystemUInt32_86 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_86");
            Private___gintnl_SystemUInt32_56 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_56");
            Private___gintnl_SystemUInt32_46 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_46");
            Private___gintnl_SystemUInt32_76 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_76");
            Private___gintnl_SystemUInt32_66 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_66");
            Private___gintnl_SystemUInt32_16 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_16");
            Private___gintnl_SystemUInt32_36 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_36");
            Private___gintnl_SystemUInt32_26 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_26");
            Private___intnl_SystemInt32_15 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_15");
            Private___intnl_SystemInt32_35 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_35");
            Private___intnl_SystemInt32_25 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_25");
            Private___intnl_SystemInt32_45 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_45");
            Private___const_SystemInt64_0 = new AstroUdonVariable<long>(PoolParlorModule, "__const_SystemInt64_0");
            Private___lcl_tableCount_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_tableCount_SystemInt32_0");
            Private___1_accept__param = new AstroUdonVariable<bool>(PoolParlorModule, "__1_accept__param");
            Private_selectedTableModel = new AstroUdonVariable<int>(PoolParlorModule, "selectedTableModel");
            Private___lcl_saoTableModelsRoot_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__lcl_saoTableModelsRoot_UnityEngineTransform_0");
            Private___intnl_UnityEngineTransform_130 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_130");
            Private___intnl_UnityEngineTransform_120 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_120");
            Private___intnl_UnityEngineTransform_110 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_110");
            Private___intnl_UnityEngineTransform_100 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_100");
            Private___const_SystemString_167 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_167");
            Private___const_SystemString_177 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_177");
            Private___const_SystemString_147 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_147");
            Private___const_SystemString_157 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_157");
            Private___const_SystemString_127 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_127");
            Private___const_SystemString_137 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_137");
            Private___const_SystemString_107 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_107");
            Private___const_SystemString_117 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_117");
            Private___const_SystemString_187 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_187");
            Private___const_SystemString_197 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_197");
            Private___intnl_UnityEngineMaterial_0 = new AstroUdonVariable<UnityEngine.Material>(PoolParlorModule, "__intnl_UnityEngineMaterial_0");
            Private___0__SelectTableSkinContributor__ret = new AstroUdonVariable<bool>(PoolParlorModule, "__0__SelectTableSkinContributor__ret");
            Private___intnl_SystemDateTimeOffset_0 = new AstroUdonVariable<System.DateTimeOffset>(PoolParlorModule, "__intnl_SystemDateTimeOffset_0");
            Private_ping = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "ping");
            Private___2_active__param = new AstroUdonVariable<bool>(PoolParlorModule, "__2_active__param");
            Private___intnl_TMProTextMeshProUGUI_9 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_9");
            Private___const_SystemString_46 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_46");
            Private___const_SystemString_47 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_47");
            Private___const_SystemString_44 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_44");
            Private___const_SystemString_45 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_45");
            Private___const_SystemString_42 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_42");
            Private___const_SystemString_43 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_43");
            Private___const_SystemString_40 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_40");
            Private___const_SystemString_41 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_41");
            Private___const_SystemString_48 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_48");
            Private___const_SystemString_49 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_49");
            Private___intnl_SystemSingle_0 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_0");
            Private___intnl_TMProTextMeshProUGUI_2 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_2");
            Private___intnl_SystemObject_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_SystemObject_0");
            Private___1_id__param = new AstroUdonVariable<int>(PoolParlorModule, "__1_id__param");
            Private_outCanUse = new AstroUdonVariable<bool>(PoolParlorModule, "outCanUse");
            Private___intnl_TMProTextMeshProUGUI_60 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_60");
            Private___const_SystemString_247 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_247");
            Private___const_SystemString_257 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_257");
            Private___const_SystemString_227 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_227");
            Private___const_SystemString_237 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_237");
            Private___const_SystemString_207 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_207");
            Private___const_SystemString_217 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_217");
            Private_liftModule = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "liftModule");
            Private___0_accept__param = new AstroUdonVariable<bool>(PoolParlorModule, "__0_accept__param");
            Private___0_id__param = new AstroUdonVariable<int>(PoolParlorModule, "__0_id__param");
            Private___const_SystemString_0 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_0");
            Private___3_id__param = new AstroUdonVariable<int>(PoolParlorModule, "__3_id__param");
            Private___intnl_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(PoolParlorModule, "__intnl_UnityEngineTransform_0");
            Private___0_shadowsDisabled__param = new AstroUdonVariable<bool>(PoolParlorModule, "__0_shadowsDisabled__param");
            Private___gintnl_SystemCharArray_2 = new AstroUdonVariable<char[]>(PoolParlorModule, "__gintnl_SystemCharArray_2");
            Private___const_SystemSingle_0 = new AstroUdonVariable<float>(PoolParlorModule, "__const_SystemSingle_0");
            Private___2_id__param = new AstroUdonVariable<int>(PoolParlorModule, "__2_id__param");
            Private___intnl_UnityEngineTransform_79 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_79");
            Private___intnl_UnityEngineTransform_78 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_78");
            Private___intnl_UnityEngineTransform_73 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_73");
            Private___intnl_UnityEngineTransform_72 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_72");
            Private___intnl_UnityEngineTransform_71 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_71");
            Private___intnl_UnityEngineTransform_70 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_70");
            Private___intnl_UnityEngineTransform_77 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_77");
            Private___intnl_UnityEngineTransform_76 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_76");
            Private___intnl_UnityEngineTransform_75 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_75");
            Private___intnl_UnityEngineTransform_74 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_74");
            Private___intnl_SystemBoolean_86 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_86");
            Private___intnl_SystemBoolean_96 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_96");
            Private___intnl_SystemBoolean_16 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_16");
            Private___intnl_SystemBoolean_26 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_26");
            Private___intnl_SystemBoolean_36 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_36");
            Private___intnl_SystemBoolean_46 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_46");
            Private___intnl_SystemBoolean_56 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_56");
            Private___intnl_SystemBoolean_66 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_66");
            Private___intnl_SystemBoolean_76 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_76");
            Private___const_SystemInt32_11 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_11");
            Private___const_SystemInt32_31 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_31");
            Private___const_SystemInt32_21 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_21");
            Private_saoToggleCamera = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "saoToggleCamera");
            Private___intnl_SystemObject_15 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_SystemObject_15");
            Private___intnl_SystemObject_18 = new AstroUdonVariable<UnityEngine.Texture2D[]>(PoolParlorModule, "__intnl_SystemObject_18");
            Private___intnl_SystemSingle_10 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_10");
            Private___intnl_SystemSingle_11 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_11");
            Private___intnl_SystemSingle_12 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_12");
            Private___intnl_SystemSingle_13 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_13");
            Private___intnl_SystemInt32_12 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_12");
            Private___intnl_SystemInt32_32 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_32");
            Private___intnl_SystemInt32_22 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_22");
            Private___intnl_SystemInt32_52 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_52");
            Private___intnl_SystemInt32_42 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_42");
            Private_saoCameras = new AstroUdonVariable<TMPro.TextMeshProUGUI[]>(PoolParlorModule, "saoCameras");
            Private___intnl_SystemSingle_8 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_8");
            Private___gintnl_SystemUInt32_9 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_9");
            Private___gintnl_SystemUInt32_8 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_8");
            Private___gintnl_SystemUInt32_5 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_5");
            Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_4");
            Private___gintnl_SystemUInt32_7 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_7");
            Private___gintnl_SystemUInt32_6 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_6");
            Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_1");
            Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_0");
            Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_3");
            Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_2");
            Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(PoolParlorModule, "__const_SystemBoolean_0");
            Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(PoolParlorModule, "__const_SystemBoolean_1");
            Private___lcl_cueSkinId_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_cueSkinId_SystemInt32_0");
            Private___0_value__param = new AstroUdonVariable<float>(PoolParlorModule, "__0_value__param");
            Private___const_SystemString_96 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_96");
            Private___const_SystemString_97 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_97");
            Private___const_SystemString_94 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_94");
            Private___const_SystemString_95 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_95");
            Private___const_SystemString_92 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_92");
            Private___const_SystemString_93 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_93");
            Private___const_SystemString_90 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_90");
            Private___const_SystemString_91 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_91");
            Private___const_SystemString_98 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_98");
            Private___const_SystemString_99 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_99");
            Private___0_newPhysicsMode__param = new AstroUdonVariable<int>(PoolParlorModule, "__0_newPhysicsMode__param");
            Private___intnl_VRCUdonUdonBehaviour_20 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_20");
            Private___intnl_VRCUdonUdonBehaviour_25 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_25");
            Private___lcl_cueCount_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_cueCount_SystemInt32_0");
            Private___intnl_TMProTextMeshProUGUI_7 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_7");
            Private_saoToggleHologram = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "saoToggleHologram");
            Private_cueButtonToSkin = new AstroUdonVariable<int[]>(PoolParlorModule, "cueButtonToSkin");
            Private___intnl_VRCUdonUdonBehaviour_7 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_7");
            Private___const_SystemString_248 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_248");
            Private___const_SystemString_258 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_258");
            Private___const_SystemString_228 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_228");
            Private___const_SystemString_238 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_238");
            Private___const_SystemString_208 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_208");
            Private___const_SystemString_218 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_218");
            Private___lcl_tableId_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_tableId_SystemInt32_0");
            Private___0_usColors__param = new AstroUdonVariable<bool>(PoolParlorModule, "__0_usColors__param");
            Private___intnl_UnityEngineColor_6 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_6");
            Private___1_enabled__param = new AstroUdonVariable<bool>(PoolParlorModule, "__1_enabled__param");
            Private___const_SystemString_5 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_5");
            Private___gintnl_SystemCharArray_1 = new AstroUdonVariable<char[]>(PoolParlorModule, "__gintnl_SystemCharArray_1");
            Private___1_skin__param = new AstroUdonVariable<int>(PoolParlorModule, "__1_skin__param");
            Private_selectedCamera = new AstroUdonVariable<int>(PoolParlorModule, "selectedCamera");
            Private___intnl_UnityEngineTransform_49 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_49");
            Private___intnl_UnityEngineTransform_48 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_48");
            Private___intnl_UnityEngineTransform_43 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_43");
            Private___intnl_UnityEngineTransform_42 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_42");
            Private___intnl_UnityEngineTransform_41 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_41");
            Private___intnl_UnityEngineTransform_40 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_40");
            Private___intnl_UnityEngineTransform_47 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_47");
            Private___intnl_UnityEngineTransform_46 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_46");
            Private___intnl_UnityEngineTransform_45 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_45");
            Private___intnl_UnityEngineTransform_44 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_44");
            Private___const_SystemInt32_19 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_19");
            Private___const_SystemInt32_29 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_29");
            Private___gintnl_SystemUInt32_93 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_93");
            Private___gintnl_SystemUInt32_83 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_83");
            Private___gintnl_SystemUInt32_53 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_53");
            Private___gintnl_SystemUInt32_43 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_43");
            Private___gintnl_SystemUInt32_73 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_73");
            Private___gintnl_SystemUInt32_63 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_63");
            Private___gintnl_SystemUInt32_13 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_13");
            Private___gintnl_SystemUInt32_33 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_33");
            Private___gintnl_SystemUInt32_23 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_23");
            Private_inMode = new AstroUdonVariable<int>(PoolParlorModule, "inMode");
            Private___lcl_tableSkinId_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_tableSkinId_SystemInt32_0");
            Private_isPolling = new AstroUdonVariable<bool>(PoolParlorModule, "isPolling");
            Private___intnl_UnityEngineTransform_127 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_127");
            Private___intnl_UnityEngineTransform_117 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_117");
            Private___intnl_UnityEngineTransform_107 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_107");
            Private_metaverse = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "metaverse");
            Private___intnl_UnityEngineTransform_99 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_99");
            Private___intnl_UnityEngineTransform_98 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_98");
            Private___intnl_UnityEngineTransform_93 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_93");
            Private___intnl_UnityEngineTransform_92 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_92");
            Private___intnl_UnityEngineTransform_91 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_91");
            Private___intnl_UnityEngineTransform_90 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_90");
            Private___intnl_UnityEngineTransform_97 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_97");
            Private___intnl_UnityEngineTransform_96 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_96");
            Private___intnl_UnityEngineTransform_95 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_95");
            Private___intnl_UnityEngineTransform_94 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_94");
            Private___const_SystemInt32_16 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_16");
            Private___const_SystemInt32_36 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_36");
            Private___const_SystemInt32_26 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_26");
            Private_physicsMode = new AstroUdonVariable<int>(PoolParlorModule, "physicsMode");
            Private___const_SystemString_162 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_162");
            Private___const_SystemString_172 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_172");
            Private___const_SystemString_142 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_142");
            Private___const_SystemString_152 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_152");
            Private___const_SystemString_122 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_122");
            Private___const_SystemString_132 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_132");
            Private___const_SystemString_102 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_102");
            Private___const_SystemString_112 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_112");
            Private___const_SystemString_182 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_182");
            Private___const_SystemString_192 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_192");
            Private_tables = new AstroUdonVariable<UnityEngine.Component[]>(PoolParlorModule, "tables");
            Private___lcl_renderer_UnityEngineMeshRenderer_0 = new AstroUdonVariable<UnityEngine.MeshRenderer>(PoolParlorModule, "__lcl_renderer_UnityEngineMeshRenderer_0");
            Private___intnl_SystemTimeSpan_0 = new AstroUdonVariable<System.TimeSpan>(PoolParlorModule, "__intnl_SystemTimeSpan_0");
            Private___const_SystemString_169 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_169");
            Private___const_SystemString_179 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_179");
            Private___const_SystemString_149 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_149");
            Private___const_SystemString_159 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_159");
            Private___const_SystemString_129 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_129");
            Private___const_SystemString_139 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_139");
            Private___const_SystemString_109 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_109");
            Private___const_SystemString_119 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_119");
            Private___const_SystemString_189 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_189");
            Private___const_SystemString_199 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_199");
            Private_modModule = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "modModule");
            Private___lcl_saoTableSettings_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__lcl_saoTableSettings_UnityEngineTransform_0");
            Private___0_enabled__param = new AstroUdonVariable<bool>(PoolParlorModule, "__0_enabled__param");
            Private___const_SystemString_16 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_16");
            Private___const_SystemString_17 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_17");
            Private___const_SystemString_14 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_14");
            Private___const_SystemString_15 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_15");
            Private___const_SystemString_12 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_12");
            Private___const_SystemString_13 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_13");
            Private___const_SystemString_10 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_10");
            Private___const_SystemString_11 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_11");
            Private___const_SystemString_18 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_18");
            Private___const_SystemString_19 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_19");
            Private___intnl_SystemSingle_7 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_7");
            Private___refl_typeid = new AstroUdonVariable<long>(PoolParlorModule, "__refl_typeid");
            Private___intnl_SystemObject_7 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_SystemObject_7");
            Private_toaster = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "toaster");
            Private___intnl_TMProTextMeshProUGUI_31 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_31");
            Private___intnl_TMProTextMeshProUGUI_30 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_30");
            Private___intnl_TMProTextMeshProUGUI_33 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_33");
            Private___intnl_TMProTextMeshProUGUI_32 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_32");
            Private___intnl_TMProTextMeshProUGUI_35 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_35");
            Private___intnl_TMProTextMeshProUGUI_34 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_34");
            Private___intnl_TMProTextMeshProUGUI_37 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_37");
            Private___intnl_TMProTextMeshProUGUI_36 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_36");
            Private___intnl_TMProTextMeshProUGUI_39 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_39");
            Private___intnl_TMProTextMeshProUGUI_38 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_38");
            Private___const_SystemString_260 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_260");
            Private___const_SystemString_240 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_240");
            Private___const_SystemString_250 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_250");
            Private___const_SystemString_220 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_220");
            Private___const_SystemString_230 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_230");
            Private___const_SystemString_200 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_200");
            Private___const_SystemString_210 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_210");
            Private___intnl_VRCUdonUdonBehaviour_19 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_19");
            Private___intnl_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_2");
            Private_SAO_COLOR_ENABLED = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "SAO_COLOR_ENABLED");
            Private___1_active__param = new AstroUdonVariable<bool>(PoolParlorModule, "__1_active__param");
            Private___intnl_UnityEngineTransform_5 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_5");
            Private_inSkin = new AstroUdonVariable<int>(PoolParlorModule, "inSkin");
            Private___intnl_UnityEngineColor_5 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_5");
            Private_decoder = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "decoder");
            Private___2_owner__param = new AstroUdonVariable<string>(PoolParlorModule, "__2_owner__param");
            Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(PoolParlorModule, "__const_SystemUInt32_0");
            Private___4_value__param = new AstroUdonVariable<float>(PoolParlorModule, "__4_value__param");
            Private___intnl_SystemBoolean_81 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_81");
            Private___intnl_SystemBoolean_91 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_91");
            Private___intnl_SystemBoolean_11 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_11");
            Private___intnl_SystemBoolean_21 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_21");
            Private___intnl_SystemBoolean_31 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_31");
            Private___intnl_SystemBoolean_41 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_41");
            Private___intnl_SystemBoolean_51 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_51");
            Private___intnl_SystemBoolean_61 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_61");
            Private___intnl_SystemBoolean_71 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_71");
            Private___intnl_UnityEngineTransform_19 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_19");
            Private___intnl_UnityEngineTransform_18 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_18");
            Private___intnl_UnityEngineTransform_13 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_13");
            Private___intnl_UnityEngineTransform_12 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_12");
            Private___intnl_UnityEngineTransform_11 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_11");
            Private___intnl_UnityEngineTransform_10 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_10");
            Private___intnl_UnityEngineTransform_17 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_17");
            Private___intnl_UnityEngineTransform_16 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_16");
            Private___intnl_UnityEngineTransform_15 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_15");
            Private___intnl_UnityEngineTransform_14 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_14");
            Private___gintnl_SystemUInt32_94 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_94");
            Private___gintnl_SystemUInt32_84 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_84");
            Private___gintnl_SystemUInt32_54 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_54");
            Private___gintnl_SystemUInt32_44 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_44");
            Private___gintnl_SystemUInt32_74 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_74");
            Private___gintnl_SystemUInt32_64 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_64");
            Private___gintnl_SystemUInt32_14 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_14");
            Private___gintnl_SystemUInt32_34 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_34");
            Private___gintnl_SystemUInt32_24 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_24");
            Private___const_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(PoolParlorModule, "__const_UnityEngineVector3_0");
            Private___intnl_SystemInt32_17 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_17");
            Private___intnl_SystemInt32_37 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_37");
            Private___intnl_SystemInt32_27 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_27");
            Private___intnl_SystemInt32_47 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_47");
            Private___intnl_UnityEngineTransform_122 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_122");
            Private___intnl_UnityEngineTransform_112 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_112");
            Private___intnl_UnityEngineTransform_102 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_102");
            Private_outSuccessful = new AstroUdonVariable<bool>(PoolParlorModule, "outSuccessful");
            Private___intnl_UnityEngineTransform_129 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_129");
            Private___intnl_UnityEngineTransform_119 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_119");
            Private___intnl_UnityEngineTransform_109 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_109");
            Private___const_SystemString_161 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_161");
            Private___const_SystemString_171 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_171");
            Private___const_SystemString_141 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_141");
            Private___const_SystemString_151 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_151");
            Private___const_SystemString_121 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_121");
            Private___const_SystemString_131 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_131");
            Private___const_SystemString_101 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_101");
            Private___const_SystemString_111 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_111");
            Private___const_SystemString_181 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_181");
            Private___const_SystemString_191 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_191");
            Private_SAO_COLOR_DISABLED = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "SAO_COLOR_DISABLED");
            Private_props = new AstroUdonVariable<UnityEngine.GameObject[]>(PoolParlorModule, "props");
            Private___0__intnlparam = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__0__intnlparam");
            Private_moderators = new AstroUdonVariable<string[]>(PoolParlorModule, "moderators");
            Private___const_SystemString_66 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_66");
            Private___const_SystemString_67 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_67");
            Private___const_SystemString_64 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_64");
            Private___const_SystemString_65 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_65");
            Private___const_SystemString_62 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_62");
            Private___const_SystemString_63 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_63");
            Private___const_SystemString_60 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_60");
            Private___const_SystemString_61 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_61");
            Private___const_SystemString_68 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_68");
            Private___const_SystemString_69 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_69");
            Private_penModule = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "penModule");
            Private___intnl_SystemGuid_0 = new AstroUdonVariable<System.Guid>(PoolParlorModule, "__intnl_SystemGuid_0");
            Private___intnl_SystemSingle_2 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_2");
            Private___intnl_TMProTextMeshProUGUI_0 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_0");
            Private___lcl_saoCueSkinsRoot_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__lcl_saoCueSkinsRoot_UnityEngineTransform_0");
            Private___intnl_SystemObject_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_SystemObject_2");
            Private___0___0_getNameColor__ret = new AstroUdonVariable<string>(PoolParlorModule, "__0___0_getNameColor__ret");
            Private___lcl_objectsModule_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__lcl_objectsModule_VRCUdonUdonBehaviour_0");
            Private___intnl_TMProTextMeshProUGUI_41 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_41");
            Private___intnl_TMProTextMeshProUGUI_40 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_40");
            Private___intnl_TMProTextMeshProUGUI_43 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_43");
            Private___intnl_TMProTextMeshProUGUI_42 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_42");
            Private___intnl_TMProTextMeshProUGUI_45 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_45");
            Private___intnl_TMProTextMeshProUGUI_44 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_44");
            Private___intnl_TMProTextMeshProUGUI_47 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_47");
            Private___intnl_TMProTextMeshProUGUI_46 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_46");
            Private___const_SystemString_245 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_245");
            Private___const_SystemString_255 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_255");
            Private___const_SystemString_225 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_225");
            Private___const_SystemString_235 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_235");
            Private___const_SystemString_205 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_205");
            Private___const_SystemString_215 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_215");
            Private___intnl_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_1");
            Private___const_SystemString_2 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_2");
            Private___intnl_SystemBoolean_121 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_121");
            Private___intnl_SystemBoolean_120 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_120");
            Private___intnl_SystemBoolean_123 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_123");
            Private___intnl_SystemBoolean_122 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_122");
            Private___intnl_SystemBoolean_125 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_125");
            Private___intnl_SystemBoolean_124 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_124");
            Private___intnl_SystemBoolean_127 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_127");
            Private___intnl_SystemBoolean_126 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_126");
            Private___intnl_UnityEngineTransform_2 = new AstroUdonVariable<UnityEngine.Transform>(PoolParlorModule, "__intnl_UnityEngineTransform_2");
            Private___intnl_UnityEngineTexture_0 = new AstroUdonVariable<UnityEngine.Texture2D>(PoolParlorModule, "__intnl_UnityEngineTexture_0");
            Private___0_tournament__param = new AstroUdonVariable<System.DateTime>(PoolParlorModule, "__0_tournament__param");
            Private___gintnl_SystemCharArray_4 = new AstroUdonVariable<char[]>(PoolParlorModule, "__gintnl_SystemCharArray_4");
            Private___const_SystemSingle_2 = new AstroUdonVariable<float>(PoolParlorModule, "__const_SystemSingle_2");
            Private___intnl_UnityEngineColor_0 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_0");
            Private_shouldBlahaj = new AstroUdonVariable<bool>(PoolParlorModule, "shouldBlahaj");
            Private_saoToggleProps = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "saoToggleProps");
            Private___intnl_SystemBoolean_89 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_89");
            Private___intnl_SystemBoolean_99 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_99");
            Private___intnl_SystemBoolean_19 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_19");
            Private___intnl_SystemBoolean_29 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_29");
            Private___intnl_SystemBoolean_39 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_39");
            Private___intnl_SystemBoolean_49 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_49");
            Private___intnl_SystemBoolean_59 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_59");
            Private___intnl_SystemBoolean_69 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_69");
            Private___intnl_SystemBoolean_79 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_79");
            Private_saoCueSkins = new AstroUdonVariable<TMPro.TextMeshProUGUI[]>(PoolParlorModule, "saoCueSkins");
            Private___0_active__param = new AstroUdonVariable<bool>(PoolParlorModule, "__0_active__param");
            Private___intnl_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "__intnl_UnityEngineGameObject_0");
            Private___lcl_playerId_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_playerId_SystemInt32_0");
            Private___intnl_SystemBoolean_84 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_84");
            Private___intnl_SystemBoolean_94 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_94");
            Private___intnl_SystemBoolean_14 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_14");
            Private___intnl_SystemBoolean_24 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_24");
            Private___intnl_SystemBoolean_34 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_34");
            Private___intnl_SystemBoolean_44 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_44");
            Private___intnl_SystemBoolean_54 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_54");
            Private___intnl_SystemBoolean_64 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_64");
            Private___intnl_SystemBoolean_74 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_74");
            Private___const_SystemInt32_13 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_13");
            Private___const_SystemInt32_33 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_33");
            Private___const_SystemInt32_23 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_23");
            Private___lcl_hours_SystemSingle_0 = new AstroUdonVariable<float>(PoolParlorModule, "__lcl_hours_SystemSingle_0");
            Private___intnl_UnityEngineComponentArray_1 = new AstroUdonVariable<UnityEngine.Component[]>(PoolParlorModule, "__intnl_UnityEngineComponentArray_1");
            Private___intnl_SystemInt32_14 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_14");
            Private___intnl_SystemInt32_34 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_34");
            Private___intnl_SystemInt32_24 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_24");
            Private___intnl_SystemInt32_44 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_44");
            Private___lcl_saoCamerasRoot_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__lcl_saoCamerasRoot_UnityEngineTransform_0");
            Private___intnl_UnityEngineTransform_131 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_131");
            Private___intnl_UnityEngineTransform_121 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_121");
            Private___intnl_UnityEngineTransform_111 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_111");
            Private___intnl_UnityEngineTransform_101 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_101");
            Private___intnl_SystemInt32_19 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_19");
            Private___intnl_SystemInt32_39 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_39");
            Private___intnl_SystemInt32_29 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_29");
            Private___intnl_SystemInt32_49 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_49");
            Private_SAO_COLOR_LOCKED = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "SAO_COLOR_LOCKED");
            Private___const_SystemString_164 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_164");
            Private___const_SystemString_174 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_174");
            Private___const_SystemString_144 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_144");
            Private___const_SystemString_154 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_154");
            Private___const_SystemString_124 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_124");
            Private___const_SystemString_134 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_134");
            Private___const_SystemString_104 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_104");
            Private___const_SystemString_114 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_114");
            Private___const_SystemString_184 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_184");
            Private___const_SystemString_194 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_194");
            Private_activeYoutubeSearchAttempts = new AstroUdonVariable<int>(PoolParlorModule, "activeYoutubeSearchAttempts");
            Private___intnl_TMProTextMeshProUGUI_8 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_8");
            Private___intnl_SystemSingle_1 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_1");
            Private___intnl_UnityEngineMaterialArray_0 = new AstroUdonVariable<UnityEngine.Material[]>(PoolParlorModule, "__intnl_UnityEngineMaterialArray_0");
            Private_worldUpdate = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "worldUpdate");
            Private___intnl_TMProTextMeshProUGUI_5 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_5");
            Private___const_SystemChar_1 = new AstroUdonVariable<char>(PoolParlorModule, "__const_SystemChar_1");
            Private___intnl_SystemObject_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_SystemObject_1");
            Private_inOwner = new AstroUdonVariable<string>(PoolParlorModule, "inOwner");
            Private_cueSkinAllowed = new AstroUdonVariable<System.Object[]>(PoolParlorModule, "cueSkinAllowed");
            Private___const_SystemString_246 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_246");
            Private___const_SystemString_256 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_256");
            Private___const_SystemString_226 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_226");
            Private___const_SystemString_236 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_236");
            Private___const_SystemString_206 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_206");
            Private___const_SystemString_216 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_216");
            Private_nameColorMap = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "nameColorMap");
            Private_propsEnabled = new AstroUdonVariable<bool>(PoolParlorModule, "propsEnabled");
            Private___0___0_isTournamentRunning__ret = new AstroUdonVariable<bool>(PoolParlorModule, "__0___0_isTournamentRunning__ret");
            Private___intnl_UnityEngineColor_8 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_8");
            Private___const_SystemString_7 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_7");
            Private___0_skin__param = new AstroUdonVariable<int>(PoolParlorModule, "__0_skin__param");
            Private___gintnl_SystemCharArray_3 = new AstroUdonVariable<char[]>(PoolParlorModule, "__gintnl_SystemCharArray_3");
            Private___const_SystemSingle_1 = new AstroUdonVariable<float>(PoolParlorModule, "__const_SystemSingle_1");
            Private___intnl_UnityEngineTransform_69 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_69");
            Private___intnl_UnityEngineTransform_68 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_68");
            Private___intnl_UnityEngineTransform_63 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_63");
            Private___intnl_UnityEngineTransform_62 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_62");
            Private___intnl_UnityEngineTransform_61 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_61");
            Private___intnl_UnityEngineTransform_60 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_60");
            Private___intnl_UnityEngineTransform_67 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_67");
            Private___intnl_UnityEngineTransform_66 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_66");
            Private___intnl_UnityEngineTransform_65 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_65");
            Private___intnl_UnityEngineTransform_64 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_64");
            Private___lcl_saoPlayerSettings_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__lcl_saoPlayerSettings_UnityEngineTransform_0");
            Private___gintnl_SystemUInt32_91 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_91");
            Private___gintnl_SystemUInt32_81 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_81");
            Private___gintnl_SystemUInt32_51 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_51");
            Private___gintnl_SystemUInt32_41 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_41");
            Private___gintnl_SystemUInt32_71 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_71");
            Private___gintnl_SystemUInt32_61 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_61");
            Private___gintnl_SystemUInt32_11 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_11");
            Private___gintnl_SystemUInt32_31 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_31");
            Private___gintnl_SystemUInt32_21 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_21");
            Private___3_value__param = new AstroUdonVariable<float>(PoolParlorModule, "__3_value__param");
            Private___intnl_SystemBoolean_87 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_87");
            Private___intnl_SystemBoolean_97 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_97");
            Private___intnl_SystemBoolean_17 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_17");
            Private___intnl_SystemBoolean_27 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_27");
            Private___intnl_SystemBoolean_37 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_37");
            Private___intnl_SystemBoolean_47 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_47");
            Private___intnl_SystemBoolean_57 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_57");
            Private___intnl_SystemBoolean_67 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_67");
            Private___intnl_SystemBoolean_77 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_77");
            Private_popcat = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "popcat");
            Private___const_SystemInt32_10 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_10");
            Private___const_SystemInt32_30 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_30");
            Private___const_SystemInt32_20 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_20");
            Private_chat = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "chat");
            Private___intnl_SystemInt32_11 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_11");
            Private___intnl_SystemInt32_31 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_31");
            Private___intnl_SystemInt32_21 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_21");
            Private___intnl_SystemInt32_51 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_51");
            Private___intnl_SystemInt32_41 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_41");
            Private_saoRunSpeedSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(PoolParlorModule, "saoRunSpeedSlider");
            Private_VERSION = new AstroUdonVariable<string>(PoolParlorModule, "VERSION");
            Private___const_SystemString_36 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_36");
            Private___const_SystemString_37 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_37");
            Private___const_SystemString_34 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_34");
            Private___const_SystemString_35 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_35");
            Private___const_SystemString_32 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_32");
            Private___const_SystemString_33 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_33");
            Private___const_SystemString_30 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_30");
            Private___const_SystemString_31 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_31");
            Private___const_SystemString_38 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_38");
            Private___const_SystemString_39 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_39");
            Private___intnl_SystemSingle_9 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_9");
            Private_saoSaveLoadInput = new AstroUdonVariable<UnityEngine.UI.InputField>(PoolParlorModule, "saoSaveLoadInput");
            Private___const_SystemString_86 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_86");
            Private___const_SystemString_87 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_87");
            Private___const_SystemString_84 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_84");
            Private___const_SystemString_85 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_85");
            Private___const_SystemString_82 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_82");
            Private___const_SystemString_83 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_83");
            Private___const_SystemString_80 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_80");
            Private___const_SystemString_81 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_81");
            Private___const_SystemString_88 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_88");
            Private___const_SystemString_89 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_89");
            Private___intnl_TMProTextMeshProUGUI_11 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_11");
            Private___intnl_TMProTextMeshProUGUI_10 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_10");
            Private___intnl_TMProTextMeshProUGUI_13 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_13");
            Private___intnl_TMProTextMeshProUGUI_12 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_12");
            Private___intnl_TMProTextMeshProUGUI_15 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_15");
            Private___intnl_TMProTextMeshProUGUI_14 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_14");
            Private___intnl_TMProTextMeshProUGUI_17 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_17");
            Private___intnl_TMProTextMeshProUGUI_16 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_16");
            Private___intnl_TMProTextMeshProUGUI_19 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_19");
            Private___intnl_TMProTextMeshProUGUI_18 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_18");
            Private___intnl_VRCUdonUdonBehaviour_38 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_38");
            Private___intnl_SystemInt64_1 = new AstroUdonVariable<long>(PoolParlorModule, "__intnl_SystemInt64_1");
            Private___intnl_SystemInt64_0 = new AstroUdonVariable<long>(PoolParlorModule, "__intnl_SystemInt64_0");
            Private___intnl_TMProTextMeshProUGUI_6 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_6");
            Private___lcl_utcNow_SystemDateTime_0 = new AstroUdonVariable<System.DateTime>(PoolParlorModule, "__lcl_utcNow_SystemDateTime_0");
            Private___intnl_VRCUdonUdonBehaviour_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_4");
            Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(PoolParlorModule, "__intnl_returnJump_SystemUInt32_0");
            Private___intnl_UnityEngineTransform_7 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_7");
            Private___intnl_UnityEngineColor_10 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_10");
            Private___intnl_UnityEngineColor_7 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_7");
            Private___const_SystemString_4 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_4");
            Private___const_UnityEngineKeyCode_0 = new AstroUdonVariable<UnityEngine.KeyCode>(PoolParlorModule, "__const_UnityEngineKeyCode_0");
            Private___gintnl_SystemUInt32_99 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_99");
            Private___gintnl_SystemUInt32_89 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_89");
            Private___gintnl_SystemUInt32_59 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_59");
            Private___gintnl_SystemUInt32_49 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_49");
            Private___gintnl_SystemUInt32_79 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_79");
            Private___gintnl_SystemUInt32_69 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_69");
            Private___gintnl_SystemUInt32_19 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_19");
            Private___gintnl_SystemUInt32_39 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_39");
            Private___gintnl_SystemUInt32_29 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_29");
            Private___const_SystemSingle_4 = new AstroUdonVariable<float>(PoolParlorModule, "__const_SystemSingle_4");
            Private___intnl_UnityEngineTransform_39 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_39");
            Private___intnl_UnityEngineTransform_38 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_38");
            Private___intnl_UnityEngineTransform_33 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_33");
            Private___intnl_UnityEngineTransform_32 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_32");
            Private___intnl_UnityEngineTransform_31 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_31");
            Private___intnl_UnityEngineTransform_30 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_30");
            Private___intnl_UnityEngineTransform_37 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_37");
            Private___intnl_UnityEngineTransform_36 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_36");
            Private___intnl_UnityEngineTransform_35 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_35");
            Private___intnl_UnityEngineTransform_34 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_34");
            Private___const_SystemInt32_18 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_18");
            Private___const_SystemInt32_38 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_38");
            Private___const_SystemInt32_28 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_28");
            Private___0_physicsMode___param = new AstroUdonVariable<int>(PoolParlorModule, "__0_physicsMode___param");
            Private___gintnl_SystemUInt32_92 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_92");
            Private___gintnl_SystemUInt32_82 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_82");
            Private___gintnl_SystemUInt32_52 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_52");
            Private___gintnl_SystemUInt32_42 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_42");
            Private___gintnl_SystemUInt32_72 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_72");
            Private___gintnl_SystemUInt32_62 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_62");
            Private___gintnl_SystemUInt32_12 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_12");
            Private___gintnl_SystemUInt32_32 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_32");
            Private___gintnl_SystemUInt32_22 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_22");
            Private_saoWalkSpeedSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(PoolParlorModule, "saoWalkSpeedSlider");
            Private___intnl_UnityEngineTransform_124 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_124");
            Private___intnl_UnityEngineTransform_114 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_114");
            Private___intnl_UnityEngineTransform_104 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_104");
            Private___intnl_UnityEngineTransform_89 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_89");
            Private___intnl_UnityEngineTransform_88 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_88");
            Private___intnl_UnityEngineTransform_83 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_83");
            Private___intnl_UnityEngineTransform_82 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_82");
            Private___intnl_UnityEngineTransform_81 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_81");
            Private___intnl_UnityEngineTransform_80 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_80");
            Private___intnl_UnityEngineTransform_87 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_87");
            Private___intnl_UnityEngineTransform_86 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_86");
            Private___intnl_UnityEngineTransform_85 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_85");
            Private___intnl_UnityEngineTransform_84 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_84");
            Private___lcl_i_SystemInt32_8 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_i_SystemInt32_8");
            Private___lcl_i_SystemInt32_1 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_i_SystemInt32_1");
            Private___lcl_i_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_i_SystemInt32_0");
            Private___lcl_i_SystemInt32_3 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_i_SystemInt32_3");
            Private___lcl_i_SystemInt32_2 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_i_SystemInt32_2");
            Private___lcl_i_SystemInt32_5 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_i_SystemInt32_5");
            Private___lcl_i_SystemInt32_4 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_i_SystemInt32_4");
            Private___lcl_i_SystemInt32_7 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_i_SystemInt32_7");
            Private___lcl_i_SystemInt32_6 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_i_SystemInt32_6");
            Private_shouldPing = new AstroUdonVariable<bool>(PoolParlorModule, "shouldPing");
            Private___const_SystemInt32_15 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_15");
            Private___const_SystemInt32_35 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_35");
            Private___const_SystemInt32_25 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_25");
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__lcl_behaviour_VRCUdonUdonBehaviour_0");
            Private___const_SystemString_163 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_163");
            Private___const_SystemString_173 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_173");
            Private___const_SystemString_143 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_143");
            Private___const_SystemString_153 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_153");
            Private___const_SystemString_123 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_123");
            Private___const_SystemString_133 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_133");
            Private___const_SystemString_103 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_103");
            Private___const_SystemString_113 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_113");
            Private___const_SystemString_183 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_183");
            Private___const_SystemString_193 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_193");
            Private_inLocalVersion = new AstroUdonVariable<int>(PoolParlorModule, "inLocalVersion");
            Private___intnl_SystemSingle_4 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_4");
            Private___1__intnlparam = new AstroUdonVariable<UnityEngine.Transform>(PoolParlorModule, "__1__intnlparam");
            Private___intnl_SystemObject_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_SystemObject_4");
            Private_saoTogglePens = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "saoTogglePens");
            Private_tournamentDate = new AstroUdonVariable<System.DateTime>(PoolParlorModule, "tournamentDate");
            Private___intnl_TMProTextMeshProUGUI_21 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_21");
            Private___intnl_TMProTextMeshProUGUI_20 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_20");
            Private___intnl_TMProTextMeshProUGUI_23 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_23");
            Private___intnl_TMProTextMeshProUGUI_22 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_22");
            Private___intnl_TMProTextMeshProUGUI_25 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_25");
            Private___intnl_TMProTextMeshProUGUI_24 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_24");
            Private___intnl_TMProTextMeshProUGUI_27 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_27");
            Private___intnl_TMProTextMeshProUGUI_26 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_26");
            Private___intnl_TMProTextMeshProUGUI_29 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_29");
            Private___intnl_TMProTextMeshProUGUI_28 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_28");
            Private___const_SystemString_263 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_263");
            Private___const_SystemString_243 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_243");
            Private___const_SystemString_253 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_253");
            Private___const_SystemString_223 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_223");
            Private___const_SystemString_233 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_233");
            Private___const_SystemString_203 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_203");
            Private___const_SystemString_213 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_213");
            Private_shouldToaster = new AstroUdonVariable<bool>(PoolParlorModule, "shouldToaster");
            Private___const_UnityEngineSpace_0 = new AstroUdonVariable<UnityEngine.Space>(PoolParlorModule, "__const_UnityEngineSpace_0");
            Private___intnl_VRCUdonUdonBehaviour_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_3");
            Private___intnl_SystemBoolean_109 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_109");
            Private___intnl_SystemBoolean_108 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_108");
            Private___intnl_SystemBoolean_101 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_101");
            Private___intnl_SystemBoolean_100 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_100");
            Private___intnl_SystemBoolean_103 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_103");
            Private___intnl_SystemBoolean_102 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_102");
            Private___intnl_SystemBoolean_105 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_105");
            Private___intnl_SystemBoolean_104 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_104");
            Private___intnl_SystemBoolean_107 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_107");
            Private___intnl_SystemBoolean_106 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_106");
            Private___intnl_UnityEngineTransform_4 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_4");
            Private___0___0_canUseTableSkin__ret = new AstroUdonVariable<bool>(PoolParlorModule, "__0___0_canUseTableSkin__ret");
            Private___gintnl_SystemCharArray_6 = new AstroUdonVariable<char[]>(PoolParlorModule, "__gintnl_SystemCharArray_6");
            Private___intnl_UnityEngineColor_2 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_2");
            Private___const_SystemString_9 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_9");
            Private___intnl_UnityEngineTexture2DArray_0 = new AstroUdonVariable<UnityEngine.Texture2D[]>(PoolParlorModule, "__intnl_UnityEngineTexture2DArray_0");
            Private___intnl_UnityEngineTransform_9 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_9");
            Private___intnl_SystemBoolean_82 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_82");
            Private___intnl_SystemBoolean_92 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_92");
            Private___intnl_SystemBoolean_12 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_12");
            Private___intnl_SystemBoolean_22 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_22");
            Private___intnl_SystemBoolean_32 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_32");
            Private___intnl_SystemBoolean_42 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_42");
            Private___intnl_SystemBoolean_52 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_52");
            Private___intnl_SystemBoolean_62 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_62");
            Private___intnl_SystemBoolean_72 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_72");
            Private_saoToggleTableTimer = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "saoToggleTableTimer");
            Private___gintnl_SystemUInt32_97 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_97");
            Private___gintnl_SystemUInt32_87 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_87");
            Private___gintnl_SystemUInt32_57 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_57");
            Private___gintnl_SystemUInt32_47 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_47");
            Private___gintnl_SystemUInt32_77 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_77");
            Private___gintnl_SystemUInt32_67 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_67");
            Private___gintnl_SystemUInt32_17 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_17");
            Private___gintnl_SystemUInt32_37 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_37");
            Private___gintnl_SystemUInt32_27 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_27");
            Private___intnl_SystemInt32_16 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_16");
            Private___intnl_SystemInt32_36 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_36");
            Private___intnl_SystemInt32_26 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_26");
            Private___intnl_SystemInt32_46 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_46");
            Private___intnl_UnityEngineTransform_133 = new AstroUdonVariable<UnityEngine.Transform>(PoolParlorModule, "__intnl_UnityEngineTransform_133");
            Private___intnl_UnityEngineTransform_123 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_123");
            Private___intnl_UnityEngineTransform_113 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_113");
            Private___intnl_UnityEngineTransform_103 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_103");
            Private___refl_typename = new AstroUdonVariable<string>(PoolParlorModule, "__refl_typename");
            Private___gintnl_SystemObjectArray_0 = new AstroUdonVariable<System.Object[]>(PoolParlorModule, "__gintnl_SystemObjectArray_0");
            Private___const_SystemString_166 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_166");
            Private___const_SystemString_176 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_176");
            Private___const_SystemString_146 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_146");
            Private___const_SystemString_156 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_156");
            Private___const_SystemString_126 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_126");
            Private___const_SystemString_136 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_136");
            Private___const_SystemString_106 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_106");
            Private___const_SystemString_116 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_116");
            Private___const_SystemString_186 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_186");
            Private___const_SystemString_196 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_196");
            Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_1");
            Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_0");
            Private___intnl_SystemInt32_3 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_3");
            Private___intnl_SystemInt32_2 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_2");
            Private___intnl_SystemInt32_5 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_5");
            Private___intnl_SystemInt32_4 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_4");
            Private___intnl_SystemInt32_7 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_7");
            Private___intnl_SystemInt32_6 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_6");
            Private___intnl_SystemInt32_9 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_9");
            Private___intnl_SystemInt32_8 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_8");
            Private_tableButtonToSkin = new AstroUdonVariable<int[]>(PoolParlorModule, "tableButtonToSkin");
            Private___intnl_SystemDateTime_0 = new AstroUdonVariable<System.DateTime>(PoolParlorModule, "__intnl_SystemDateTime_0");
            Private___const_SystemString_56 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_56");
            Private___const_SystemString_57 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_57");
            Private___const_SystemString_54 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_54");
            Private___const_SystemString_55 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_55");
            Private___const_SystemString_52 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_52");
            Private___const_SystemString_53 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_53");
            Private___const_SystemString_50 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_50");
            Private___const_SystemString_51 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_51");
            Private___const_SystemString_58 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_58");
            Private___const_SystemString_59 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_59");
            Private___intnl_SystemGuid_1 = new AstroUdonVariable<System.Guid>(PoolParlorModule, "__intnl_SystemGuid_1");
            Private___intnl_SystemSingle_3 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_3");
            Private___intnl_TMProTextMeshProUGUI_3 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_3");
            Private___intnl_SystemObject_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_SystemObject_3");
            Private___const_SystemString_264 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_264");
            Private___const_SystemString_244 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_244");
            Private___const_SystemString_254 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_254");
            Private___const_SystemString_224 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_224");
            Private___const_SystemString_234 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_234");
            Private___const_SystemString_204 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_204");
            Private___const_SystemString_214 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_214");
            Private___lcl_saoWorldSettings_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__lcl_saoWorldSettings_UnityEngineTransform_0");
            Private___lcl_targetID_SystemInt64_0 = new AstroUdonVariable<long>(PoolParlorModule, "__lcl_targetID_SystemInt64_0");
            Private___const_SystemString_1 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_1");
            Private___intnl_UnityEngineTransform_1 = new AstroUdonVariable<UnityEngine.Transform>(PoolParlorModule, "__intnl_UnityEngineTransform_1");
            Private___gintnl_SystemCharArray_5 = new AstroUdonVariable<char[]>(PoolParlorModule, "__gintnl_SystemCharArray_5");
            Private___const_SystemSingle_3 = new AstroUdonVariable<float>(PoolParlorModule, "__const_SystemSingle_3");
            Private___intnl_SystemDouble_0 = new AstroUdonVariable<double>(PoolParlorModule, "__intnl_SystemDouble_0");
            Private___lcl_idValue_SystemObject_0 = new AstroUdonVariable<long>(PoolParlorModule, "__lcl_idValue_SystemObject_0");
            Private___intnl_UnityEngineColor_1 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_1");
            Private___lcl_saoTableSkinsRoot_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__lcl_saoTableSkinsRoot_UnityEngineTransform_0");
            Private___intnl_SystemBoolean_85 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_85");
            Private___intnl_SystemBoolean_95 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_95");
            Private___intnl_SystemBoolean_15 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_15");
            Private___intnl_SystemBoolean_25 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_25");
            Private___intnl_SystemBoolean_35 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_35");
            Private___intnl_SystemBoolean_45 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_45");
            Private___intnl_SystemBoolean_55 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_55");
            Private___intnl_SystemBoolean_65 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_65");
            Private___intnl_SystemBoolean_75 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_75");
            Private_previewCue = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "previewCue");
            Private___const_SystemInt32_12 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_12");
            Private___const_SystemInt32_32 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_32");
            Private___const_SystemInt32_22 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_22");
            Private___0_tableTimer__param = new AstroUdonVariable<bool>(PoolParlorModule, "__0_tableTimer__param");
            Private___2_value__param = new AstroUdonVariable<float>(PoolParlorModule, "__2_value__param");
            Private___intnl_SystemInt32_13 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_13");
            Private___intnl_SystemInt32_33 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_33");
            Private___intnl_SystemInt32_23 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_23");
            Private___intnl_SystemInt32_43 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_43");
            Private___lcl_cueId_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__lcl_cueId_SystemInt32_0");
            Private___intnl_SystemInt32_18 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_18");
            Private___intnl_SystemInt32_38 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_38");
            Private___intnl_SystemInt32_28 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_28");
            Private___intnl_SystemInt32_48 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_48");
            Private___const_SystemString_165 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_165");
            Private___const_SystemString_175 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_175");
            Private___const_SystemString_145 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_145");
            Private___const_SystemString_155 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_155");
            Private___const_SystemString_125 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_125");
            Private___const_SystemString_135 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_135");
            Private___const_SystemString_105 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_105");
            Private___const_SystemString_115 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_115");
            Private___const_SystemString_185 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_185");
            Private___const_SystemString_195 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_195");
            Private_shouldPopcat = new AstroUdonVariable<bool>(PoolParlorModule, "shouldPopcat");
            Private___intnl_SystemByte_0 = new AstroUdonVariable<byte>(PoolParlorModule, "__intnl_SystemByte_0");
            Private___0_mode__param = new AstroUdonVariable<int>(PoolParlorModule, "__0_mode__param");
            Private_saoTableModels = new AstroUdonVariable<TMPro.TextMeshProUGUI[]>(PoolParlorModule, "saoTableModels");
            Private_saoTogglePlayer = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "saoTogglePlayer");
            Private___intnl_TMProTextMeshProUGUI_4 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_4");
            Private___const_SystemChar_0 = new AstroUdonVariable<char>(PoolParlorModule, "__const_SystemChar_0");
            Private___lcl_ch_SystemChar_0 = new AstroUdonVariable<char>(PoolParlorModule, "__lcl_ch_SystemChar_0");
            Private___intnl_VRCUdonUdonBehaviour_6 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_6");
            Private___const_SystemString_249 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_249");
            Private___const_SystemString_259 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_259");
            Private___const_SystemString_229 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_229");
            Private___const_SystemString_239 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_239");
            Private___const_SystemString_209 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_209");
            Private___const_SystemString_219 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_219");
            Private_outColor = new AstroUdonVariable<string>(PoolParlorModule, "outColor");
            Private___intnl_UnityEngineColor_9 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_9");
            Private___const_SystemString_6 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_6");
            Private___gintnl_SystemCharArray_0 = new AstroUdonVariable<char[]>(PoolParlorModule, "__gintnl_SystemCharArray_0");
            Private_outSetting = new AstroUdonVariable<int>(PoolParlorModule, "outSetting");
            Private___intnl_UnityEngineTransform_59 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_59");
            Private___intnl_UnityEngineTransform_58 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_58");
            Private___intnl_UnityEngineTransform_53 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_53");
            Private___intnl_UnityEngineTransform_52 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_52");
            Private___intnl_UnityEngineTransform_51 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_51");
            Private___intnl_UnityEngineTransform_50 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_50");
            Private___intnl_UnityEngineTransform_57 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_57");
            Private___intnl_UnityEngineTransform_56 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_56");
            Private___intnl_UnityEngineTransform_55 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_55");
            Private___intnl_UnityEngineTransform_54 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_54");
            Private___0___0_getPenSocialSetting__ret = new AstroUdonVariable<int>(PoolParlorModule, "__0___0_getPenSocialSetting__ret");
            Private___gintnl_SystemUInt32_90 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_90");
            Private___gintnl_SystemUInt32_80 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_80");
            Private___gintnl_SystemUInt32_50 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_50");
            Private___gintnl_SystemUInt32_40 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_40");
            Private___gintnl_SystemUInt32_70 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_70");
            Private___gintnl_SystemUInt32_60 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_60");
            Private___gintnl_SystemUInt32_10 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_10");
            Private___gintnl_SystemUInt32_30 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_30");
            Private___gintnl_SystemUInt32_20 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_20");
            Private___0___0_canUseCueSkin__ret = new AstroUdonVariable<bool>(PoolParlorModule, "__0___0_canUseCueSkin__ret");
            Private___intnl_UnityEngineTransform_126 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_126");
            Private___intnl_UnityEngineTransform_116 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_116");
            Private___intnl_UnityEngineTransform_106 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_106");
            Private___const_SystemInt32_17 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_17");
            Private___const_SystemInt32_37 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_37");
            Private___const_SystemInt32_27 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_27");
            Private___intnl_UnityEngineTexture2D_0 = new AstroUdonVariable<UnityEngine.Texture2D>(PoolParlorModule, "__intnl_UnityEngineTexture2D_0");
            Private___intnl_SystemInt32_10 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_10");
            Private___intnl_SystemInt32_30 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_30");
            Private___intnl_SystemInt32_20 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_20");
            Private___intnl_SystemInt32_50 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_50");
            Private___intnl_SystemInt32_40 = new AstroUdonVariable<int>(PoolParlorModule, "__intnl_SystemInt32_40");
            Private_tournamentRefs = new AstroUdonVariable<string[]>(PoolParlorModule, "tournamentRefs");
            Private_saoStrafeSpeedSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(PoolParlorModule, "saoStrafeSpeedSlider");
            Private___const_SystemString_168 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_168");
            Private___const_SystemString_178 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_178");
            Private___const_SystemString_148 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_148");
            Private___const_SystemString_158 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_158");
            Private___const_SystemString_128 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_128");
            Private___const_SystemString_138 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_138");
            Private___const_SystemString_108 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_108");
            Private___const_SystemString_118 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_118");
            Private___const_SystemString_188 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_188");
            Private___const_SystemString_198 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_198");
            Private_saoToggleBallShadow = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "saoToggleBallShadow");
            Private___this_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "__this_UnityEngineGameObject_0");
            Private___1_value__param = new AstroUdonVariable<float>(PoolParlorModule, "__1_value__param");
            Private_saoToggleLegacyPhysics = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "saoToggleLegacyPhysics");
            Private_blahaj = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "blahaj");
            Private___const_SystemString_26 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_26");
            Private___const_SystemString_27 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_27");
            Private___const_SystemString_24 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_24");
            Private___const_SystemString_25 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_25");
            Private___const_SystemString_22 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_22");
            Private___const_SystemString_23 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_23");
            Private___const_SystemString_20 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_20");
            Private___const_SystemString_21 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_21");
            Private___const_SystemString_28 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_28");
            Private___const_SystemString_29 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_29");
            Private___intnl_SystemSingle_6 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_6");
            Private___gintnl_SystemUInt32_100 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_100");
            Private___gintnl_SystemUInt32_101 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_101");
            Private___gintnl_SystemUInt32_102 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_102");
            Private___gintnl_SystemUInt32_103 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_103");
            Private_saoLoliLifterSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(PoolParlorModule, "saoLoliLifterSlider");
            Private___intnl_SystemObject_6 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_SystemObject_6");
            Private_INITIALIZED = new AstroUdonVariable<bool>(PoolParlorModule, "INITIALIZED");
            Private___const_SystemString_261 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_261");
            Private___const_SystemString_241 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_241");
            Private___const_SystemString_251 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_251");
            Private___const_SystemString_221 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_221");
            Private___const_SystemString_231 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_231");
            Private___const_SystemString_201 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_201");
            Private___const_SystemString_211 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_211");
            Private_selectedCueSkin = new AstroUdonVariable<int>(PoolParlorModule, "selectedCueSkin");
            Private___intnl_VRCUdonUdonBehaviour_5 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_5");
            Private___0_hasPendingRequest__ret = new AstroUdonVariable<bool>(PoolParlorModule, "__0_hasPendingRequest__ret");
            Private___intnl_UnityEngineTransform_6 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_6");
            Private_inRemoteVersion = new AstroUdonVariable<int>(PoolParlorModule, "inRemoteVersion");
            Private_activeYoutubeSearch = new AstroUdonVariable<System.Guid>(PoolParlorModule, "activeYoutubeSearch");
            Private___intnl_UnityEngineColor_4 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_4");
            Private___gintnl_SystemUInt32_98 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_98");
            Private___gintnl_SystemUInt32_88 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_88");
            Private___gintnl_SystemUInt32_58 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_58");
            Private___gintnl_SystemUInt32_48 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_48");
            Private___gintnl_SystemUInt32_78 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_78");
            Private___gintnl_SystemUInt32_68 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_68");
            Private___gintnl_SystemUInt32_18 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_18");
            Private___gintnl_SystemUInt32_38 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_38");
            Private___gintnl_SystemUInt32_28 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_28");
            Private_selectedTableSkin = new AstroUdonVariable<int>(PoolParlorModule, "selectedTableSkin");
            Private_DEPENDENCIES = new AstroUdonVariable<string[]>(PoolParlorModule, "DEPENDENCIES");
            Private___intnl_UnityEngineComponent_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_UnityEngineComponent_1");
            Private___intnl_SystemBoolean_80 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_80");
            Private___intnl_SystemBoolean_90 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_90");
            Private___intnl_SystemBoolean_10 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_10");
            Private___intnl_SystemBoolean_20 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_20");
            Private___intnl_SystemBoolean_30 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_30");
            Private___intnl_SystemBoolean_40 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_40");
            Private___intnl_SystemBoolean_50 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_50");
            Private___intnl_SystemBoolean_60 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_60");
            Private___intnl_SystemBoolean_70 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_70");
            Private___intnl_UnityEngineTransform_29 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_29");
            Private___intnl_UnityEngineTransform_28 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_28");
            Private___intnl_UnityEngineTransform_23 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_23");
            Private___intnl_UnityEngineTransform_22 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_22");
            Private___intnl_UnityEngineTransform_21 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_21");
            Private___intnl_UnityEngineTransform_20 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_20");
            Private___intnl_UnityEngineTransform_27 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_27");
            Private___intnl_UnityEngineTransform_26 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_26");
            Private___intnl_UnityEngineTransform_25 = new AstroUdonVariable<UnityEngine.Transform>(PoolParlorModule, "__intnl_UnityEngineTransform_25");
            Private___intnl_UnityEngineTransform_24 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_24");
            Private___gintnl_SystemUInt32_95 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_95");
            Private___gintnl_SystemUInt32_85 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_85");
            Private___gintnl_SystemUInt32_55 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_55");
            Private___gintnl_SystemUInt32_45 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_45");
            Private___gintnl_SystemUInt32_75 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_75");
            Private___gintnl_SystemUInt32_65 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_65");
            Private___gintnl_SystemUInt32_15 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_15");
            Private___gintnl_SystemUInt32_35 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_35");
            Private___gintnl_SystemUInt32_25 = new AstroUdonVariable<uint>(PoolParlorModule, "__gintnl_SystemUInt32_25");
            Private___0__SelectCueSkinContributor__ret = new AstroUdonVariable<bool>(PoolParlorModule, "__0__SelectCueSkinContributor__ret");
            Private_tableSkinAllowed = new AstroUdonVariable<System.Object[]>(PoolParlorModule, "tableSkinAllowed");
            Private___intnl_UnityEngineTransform_125 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_125");
            Private___intnl_UnityEngineTransform_115 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_115");
            Private___intnl_UnityEngineTransform_105 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_105");
            Private___const_SystemInt32_9 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_9");
            Private___const_SystemInt32_8 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_8");
            Private___const_SystemInt32_1 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_1");
            Private___const_SystemInt32_0 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_0");
            Private___const_SystemInt32_3 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_3");
            Private___const_SystemInt32_2 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_2");
            Private___const_SystemInt32_5 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_5");
            Private___const_SystemInt32_4 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_4");
            Private___const_SystemInt32_7 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_7");
            Private___const_SystemInt32_6 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_6");
            Private___const_SystemInt32_14 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_14");
            Private___const_SystemInt32_34 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_34");
            Private___const_SystemInt32_24 = new AstroUdonVariable<int>(PoolParlorModule, "__const_SystemInt32_24");
            Private___lcl_udonBehaviours_UnityEngineComponentArray_0 = new AstroUdonVariable<UnityEngine.Component[]>(PoolParlorModule, "__lcl_udonBehaviours_UnityEngineComponentArray_0");
            Private_lastPoll = new AstroUdonVariable<float>(PoolParlorModule, "lastPoll");
            Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_8");
            Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_9");
            Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_0");
            Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_1");
            Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_2");
            Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_3");
            Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_4");
            Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_5");
            Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_6");
            Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_7");
            Private___intnl_UnityEngineTransform_128 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_128");
            Private___intnl_UnityEngineTransform_118 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_118");
            Private___intnl_UnityEngineTransform_108 = new AstroUdonVariable<UnityEngine.Transform>(PoolParlorModule, "__intnl_UnityEngineTransform_108");
            Private___const_SystemString_160 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_160");
            Private___const_SystemString_170 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_170");
            Private___const_SystemString_140 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_140");
            Private___const_SystemString_150 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_150");
            Private___const_SystemString_120 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_120");
            Private___const_SystemString_130 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_130");
            Private___const_SystemString_100 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_100");
            Private___const_SystemString_110 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_110");
            Private___const_SystemString_180 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_180");
            Private___const_SystemString_190 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_190");
            Private___const_SystemString_76 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_76");
            Private___const_SystemString_77 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_77");
            Private___const_SystemString_74 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_74");
            Private___const_SystemString_75 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_75");
            Private___const_SystemString_72 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_72");
            Private___const_SystemString_73 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_73");
            Private___const_SystemString_70 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_70");
            Private___const_SystemString_71 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_71");
            Private___const_SystemString_78 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_78");
            Private___const_SystemString_79 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_79");
            Private___intnl_SystemSingle_5 = new AstroUdonVariable<float>(PoolParlorModule, "__intnl_SystemSingle_5");
            Private_saoToggleUSColors = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "saoToggleUSColors");
            Private___0___0_onChatCommand__ret = new AstroUdonVariable<bool>(PoolParlorModule, "__0___0_onChatCommand__ret");
            Private___intnl_TMProTextMeshProUGUI_1 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_1");
            Private___intnl_SystemObject_5 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_SystemObject_5");
            Private___intnl_TMProTextMeshProUGUI_57 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_57");
            Private___intnl_TMProTextMeshProUGUI_58 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PoolParlorModule, "__intnl_TMProTextMeshProUGUI_58");
            Private___const_SystemString_262 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_262");
            Private___const_SystemString_242 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_242");
            Private___const_SystemString_252 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_252");
            Private___const_SystemString_222 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_222");
            Private___const_SystemString_232 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_232");
            Private___const_SystemString_202 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_202");
            Private___const_SystemString_212 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_212");
            Private_saoJumpImpulseSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(PoolParlorModule, "saoJumpImpulseSlider");
            Private___intnl_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__intnl_VRCUdonUdonBehaviour_0");
            Private_saoMenu = new AstroUdonVariable<UnityEngine.GameObject>(PoolParlorModule, "saoMenu");
            Private___const_SystemString_3 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_3");
            Private___this_VRCUdonUdonBehaviour_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__this_VRCUdonUdonBehaviour_3");
            Private___this_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__this_VRCUdonUdonBehaviour_2");
            Private___this_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__this_VRCUdonUdonBehaviour_1");
            Private___this_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__this_VRCUdonUdonBehaviour_0");
            Private___this_VRCUdonUdonBehaviour_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolParlorModule, "__this_VRCUdonUdonBehaviour_4");
            Private_saoTableSkins = new AstroUdonVariable<TMPro.TextMeshProUGUI[]>(PoolParlorModule, "saoTableSkins");
            Private___intnl_SystemBoolean_119 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_119");
            Private___intnl_SystemBoolean_118 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_118");
            Private___intnl_SystemBoolean_111 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_111");
            Private___intnl_SystemBoolean_110 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_110");
            Private___intnl_SystemBoolean_113 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_113");
            Private___intnl_SystemBoolean_112 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_112");
            Private___intnl_SystemBoolean_115 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_115");
            Private___intnl_SystemBoolean_114 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_114");
            Private___intnl_SystemBoolean_117 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_117");
            Private___intnl_SystemBoolean_116 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_116");
            Private___intnl_UnityEngineTransform_3 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_3");
            Private___intnl_UnityEngineColor_3 = new AstroUdonVariable<UnityEngine.Color>(PoolParlorModule, "__intnl_UnityEngineColor_3");
            Private___const_SystemString_8 = new AstroUdonVariable<string>(PoolParlorModule, "__const_SystemString_8");
            Private___intnl_SystemBoolean_88 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_88");
            Private___intnl_SystemBoolean_98 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_98");
            Private___intnl_SystemBoolean_18 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_18");
            Private___intnl_SystemBoolean_28 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_28");
            Private___intnl_SystemBoolean_38 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_38");
            Private___intnl_SystemBoolean_48 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_48");
            Private___intnl_SystemBoolean_58 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_58");
            Private___intnl_SystemBoolean_68 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_68");
            Private___intnl_SystemBoolean_78 = new AstroUdonVariable<bool>(PoolParlorModule, "__intnl_SystemBoolean_78");
            Private___intnl_UnityEngineTransform_8 = new AstroUdonVariable<UnityEngine.RectTransform>(PoolParlorModule, "__intnl_UnityEngineTransform_8");
        }

        private void Cleanup_PoolParlorModule()
        {
            Private___intnl_SystemBoolean_83 = null;
            Private___intnl_SystemBoolean_93 = null;
            Private___intnl_SystemBoolean_13 = null;
            Private___intnl_SystemBoolean_23 = null;
            Private___intnl_SystemBoolean_33 = null;
            Private___intnl_SystemBoolean_43 = null;
            Private___intnl_SystemBoolean_53 = null;
            Private___intnl_SystemBoolean_63 = null;
            Private___intnl_SystemBoolean_73 = null;
            Private_hologramSystem = null;
            Private___gintnl_SystemUInt32_96 = null;
            Private___gintnl_SystemUInt32_86 = null;
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
            Private___intnl_SystemInt32_45 = null;
            Private___const_SystemInt64_0 = null;
            Private___lcl_tableCount_SystemInt32_0 = null;
            Private___1_accept__param = null;
            Private_selectedTableModel = null;
            Private___lcl_saoTableModelsRoot_UnityEngineTransform_0 = null;
            Private___intnl_UnityEngineTransform_130 = null;
            Private___intnl_UnityEngineTransform_120 = null;
            Private___intnl_UnityEngineTransform_110 = null;
            Private___intnl_UnityEngineTransform_100 = null;
            Private___const_SystemString_167 = null;
            Private___const_SystemString_177 = null;
            Private___const_SystemString_147 = null;
            Private___const_SystemString_157 = null;
            Private___const_SystemString_127 = null;
            Private___const_SystemString_137 = null;
            Private___const_SystemString_107 = null;
            Private___const_SystemString_117 = null;
            Private___const_SystemString_187 = null;
            Private___const_SystemString_197 = null;
            Private___intnl_UnityEngineMaterial_0 = null;
            Private___0__SelectTableSkinContributor__ret = null;
            Private___intnl_SystemDateTimeOffset_0 = null;
            Private_ping = null;
            Private___2_active__param = null;
            Private___intnl_TMProTextMeshProUGUI_9 = null;
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
            Private___intnl_TMProTextMeshProUGUI_2 = null;
            Private___intnl_SystemObject_0 = null;
            Private___1_id__param = null;
            Private_outCanUse = null;
            Private___intnl_TMProTextMeshProUGUI_60 = null;
            Private___const_SystemString_247 = null;
            Private___const_SystemString_257 = null;
            Private___const_SystemString_227 = null;
            Private___const_SystemString_237 = null;
            Private___const_SystemString_207 = null;
            Private___const_SystemString_217 = null;
            Private_liftModule = null;
            Private___0_accept__param = null;
            Private___0_id__param = null;
            Private___const_SystemString_0 = null;
            Private___3_id__param = null;
            Private___intnl_UnityEngineTransform_0 = null;
            Private___0_shadowsDisabled__param = null;
            Private___gintnl_SystemCharArray_2 = null;
            Private___const_SystemSingle_0 = null;
            Private___2_id__param = null;
            Private___intnl_UnityEngineTransform_79 = null;
            Private___intnl_UnityEngineTransform_78 = null;
            Private___intnl_UnityEngineTransform_73 = null;
            Private___intnl_UnityEngineTransform_72 = null;
            Private___intnl_UnityEngineTransform_71 = null;
            Private___intnl_UnityEngineTransform_70 = null;
            Private___intnl_UnityEngineTransform_77 = null;
            Private___intnl_UnityEngineTransform_76 = null;
            Private___intnl_UnityEngineTransform_75 = null;
            Private___intnl_UnityEngineTransform_74 = null;
            Private___intnl_SystemBoolean_86 = null;
            Private___intnl_SystemBoolean_96 = null;
            Private___intnl_SystemBoolean_16 = null;
            Private___intnl_SystemBoolean_26 = null;
            Private___intnl_SystemBoolean_36 = null;
            Private___intnl_SystemBoolean_46 = null;
            Private___intnl_SystemBoolean_56 = null;
            Private___intnl_SystemBoolean_66 = null;
            Private___intnl_SystemBoolean_76 = null;
            Private___const_SystemInt32_11 = null;
            Private___const_SystemInt32_31 = null;
            Private___const_SystemInt32_21 = null;
            Private_saoToggleCamera = null;
            Private___intnl_SystemObject_15 = null;
            Private___intnl_SystemObject_18 = null;
            Private___intnl_SystemSingle_10 = null;
            Private___intnl_SystemSingle_11 = null;
            Private___intnl_SystemSingle_12 = null;
            Private___intnl_SystemSingle_13 = null;
            Private___intnl_SystemInt32_12 = null;
            Private___intnl_SystemInt32_32 = null;
            Private___intnl_SystemInt32_22 = null;
            Private___intnl_SystemInt32_52 = null;
            Private___intnl_SystemInt32_42 = null;
            Private_saoCameras = null;
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
            Private___lcl_cueSkinId_SystemInt32_0 = null;
            Private___0_value__param = null;
            Private___const_SystemString_96 = null;
            Private___const_SystemString_97 = null;
            Private___const_SystemString_94 = null;
            Private___const_SystemString_95 = null;
            Private___const_SystemString_92 = null;
            Private___const_SystemString_93 = null;
            Private___const_SystemString_90 = null;
            Private___const_SystemString_91 = null;
            Private___const_SystemString_98 = null;
            Private___const_SystemString_99 = null;
            Private___0_newPhysicsMode__param = null;
            Private___intnl_VRCUdonUdonBehaviour_20 = null;
            Private___intnl_VRCUdonUdonBehaviour_25 = null;
            Private___lcl_cueCount_SystemInt32_0 = null;
            Private___intnl_TMProTextMeshProUGUI_7 = null;
            Private_saoToggleHologram = null;
            Private_cueButtonToSkin = null;
            Private___intnl_VRCUdonUdonBehaviour_7 = null;
            Private___const_SystemString_248 = null;
            Private___const_SystemString_258 = null;
            Private___const_SystemString_228 = null;
            Private___const_SystemString_238 = null;
            Private___const_SystemString_208 = null;
            Private___const_SystemString_218 = null;
            Private___lcl_tableId_SystemInt32_0 = null;
            Private___0_usColors__param = null;
            Private___intnl_UnityEngineColor_6 = null;
            Private___1_enabled__param = null;
            Private___const_SystemString_5 = null;
            Private___gintnl_SystemCharArray_1 = null;
            Private___1_skin__param = null;
            Private_selectedCamera = null;
            Private___intnl_UnityEngineTransform_49 = null;
            Private___intnl_UnityEngineTransform_48 = null;
            Private___intnl_UnityEngineTransform_43 = null;
            Private___intnl_UnityEngineTransform_42 = null;
            Private___intnl_UnityEngineTransform_41 = null;
            Private___intnl_UnityEngineTransform_40 = null;
            Private___intnl_UnityEngineTransform_47 = null;
            Private___intnl_UnityEngineTransform_46 = null;
            Private___intnl_UnityEngineTransform_45 = null;
            Private___intnl_UnityEngineTransform_44 = null;
            Private___const_SystemInt32_19 = null;
            Private___const_SystemInt32_29 = null;
            Private___gintnl_SystemUInt32_93 = null;
            Private___gintnl_SystemUInt32_83 = null;
            Private___gintnl_SystemUInt32_53 = null;
            Private___gintnl_SystemUInt32_43 = null;
            Private___gintnl_SystemUInt32_73 = null;
            Private___gintnl_SystemUInt32_63 = null;
            Private___gintnl_SystemUInt32_13 = null;
            Private___gintnl_SystemUInt32_33 = null;
            Private___gintnl_SystemUInt32_23 = null;
            Private_inMode = null;
            Private___lcl_tableSkinId_SystemInt32_0 = null;
            Private_isPolling = null;
            Private___intnl_UnityEngineTransform_127 = null;
            Private___intnl_UnityEngineTransform_117 = null;
            Private___intnl_UnityEngineTransform_107 = null;
            Private_metaverse = null;
            Private___intnl_UnityEngineTransform_99 = null;
            Private___intnl_UnityEngineTransform_98 = null;
            Private___intnl_UnityEngineTransform_93 = null;
            Private___intnl_UnityEngineTransform_92 = null;
            Private___intnl_UnityEngineTransform_91 = null;
            Private___intnl_UnityEngineTransform_90 = null;
            Private___intnl_UnityEngineTransform_97 = null;
            Private___intnl_UnityEngineTransform_96 = null;
            Private___intnl_UnityEngineTransform_95 = null;
            Private___intnl_UnityEngineTransform_94 = null;
            Private___const_SystemInt32_16 = null;
            Private___const_SystemInt32_36 = null;
            Private___const_SystemInt32_26 = null;
            Private_physicsMode = null;
            Private___const_SystemString_162 = null;
            Private___const_SystemString_172 = null;
            Private___const_SystemString_142 = null;
            Private___const_SystemString_152 = null;
            Private___const_SystemString_122 = null;
            Private___const_SystemString_132 = null;
            Private___const_SystemString_102 = null;
            Private___const_SystemString_112 = null;
            Private___const_SystemString_182 = null;
            Private___const_SystemString_192 = null;
            Private_tables = null;
            Private___lcl_renderer_UnityEngineMeshRenderer_0 = null;
            Private___intnl_SystemTimeSpan_0 = null;
            Private___const_SystemString_169 = null;
            Private___const_SystemString_179 = null;
            Private___const_SystemString_149 = null;
            Private___const_SystemString_159 = null;
            Private___const_SystemString_129 = null;
            Private___const_SystemString_139 = null;
            Private___const_SystemString_109 = null;
            Private___const_SystemString_119 = null;
            Private___const_SystemString_189 = null;
            Private___const_SystemString_199 = null;
            Private_modModule = null;
            Private___lcl_saoTableSettings_UnityEngineTransform_0 = null;
            Private___0_enabled__param = null;
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
            Private___intnl_SystemObject_7 = null;
            Private_toaster = null;
            Private___intnl_TMProTextMeshProUGUI_31 = null;
            Private___intnl_TMProTextMeshProUGUI_30 = null;
            Private___intnl_TMProTextMeshProUGUI_33 = null;
            Private___intnl_TMProTextMeshProUGUI_32 = null;
            Private___intnl_TMProTextMeshProUGUI_35 = null;
            Private___intnl_TMProTextMeshProUGUI_34 = null;
            Private___intnl_TMProTextMeshProUGUI_37 = null;
            Private___intnl_TMProTextMeshProUGUI_36 = null;
            Private___intnl_TMProTextMeshProUGUI_39 = null;
            Private___intnl_TMProTextMeshProUGUI_38 = null;
            Private___const_SystemString_260 = null;
            Private___const_SystemString_240 = null;
            Private___const_SystemString_250 = null;
            Private___const_SystemString_220 = null;
            Private___const_SystemString_230 = null;
            Private___const_SystemString_200 = null;
            Private___const_SystemString_210 = null;
            Private___intnl_VRCUdonUdonBehaviour_19 = null;
            Private___intnl_VRCUdonUdonBehaviour_2 = null;
            Private_SAO_COLOR_ENABLED = null;
            Private___1_active__param = null;
            Private___intnl_UnityEngineTransform_5 = null;
            Private_inSkin = null;
            Private___intnl_UnityEngineColor_5 = null;
            Private_decoder = null;
            Private___2_owner__param = null;
            Private___const_SystemUInt32_0 = null;
            Private___4_value__param = null;
            Private___intnl_SystemBoolean_81 = null;
            Private___intnl_SystemBoolean_91 = null;
            Private___intnl_SystemBoolean_11 = null;
            Private___intnl_SystemBoolean_21 = null;
            Private___intnl_SystemBoolean_31 = null;
            Private___intnl_SystemBoolean_41 = null;
            Private___intnl_SystemBoolean_51 = null;
            Private___intnl_SystemBoolean_61 = null;
            Private___intnl_SystemBoolean_71 = null;
            Private___intnl_UnityEngineTransform_19 = null;
            Private___intnl_UnityEngineTransform_18 = null;
            Private___intnl_UnityEngineTransform_13 = null;
            Private___intnl_UnityEngineTransform_12 = null;
            Private___intnl_UnityEngineTransform_11 = null;
            Private___intnl_UnityEngineTransform_10 = null;
            Private___intnl_UnityEngineTransform_17 = null;
            Private___intnl_UnityEngineTransform_16 = null;
            Private___intnl_UnityEngineTransform_15 = null;
            Private___intnl_UnityEngineTransform_14 = null;
            Private___gintnl_SystemUInt32_94 = null;
            Private___gintnl_SystemUInt32_84 = null;
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
            Private___intnl_SystemInt32_47 = null;
            Private___intnl_UnityEngineTransform_122 = null;
            Private___intnl_UnityEngineTransform_112 = null;
            Private___intnl_UnityEngineTransform_102 = null;
            Private_outSuccessful = null;
            Private___intnl_UnityEngineTransform_129 = null;
            Private___intnl_UnityEngineTransform_119 = null;
            Private___intnl_UnityEngineTransform_109 = null;
            Private___const_SystemString_161 = null;
            Private___const_SystemString_171 = null;
            Private___const_SystemString_141 = null;
            Private___const_SystemString_151 = null;
            Private___const_SystemString_121 = null;
            Private___const_SystemString_131 = null;
            Private___const_SystemString_101 = null;
            Private___const_SystemString_111 = null;
            Private___const_SystemString_181 = null;
            Private___const_SystemString_191 = null;
            Private_SAO_COLOR_DISABLED = null;
            Private_props = null;
            Private___0__intnlparam = null;
            Private_moderators = null;
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
            Private_penModule = null;
            Private___intnl_SystemGuid_0 = null;
            Private___intnl_SystemSingle_2 = null;
            Private___intnl_TMProTextMeshProUGUI_0 = null;
            Private___lcl_saoCueSkinsRoot_UnityEngineTransform_0 = null;
            Private___intnl_SystemObject_2 = null;
            Private___0___0_getNameColor__ret = null;
            Private___lcl_objectsModule_VRCUdonUdonBehaviour_0 = null;
            Private___intnl_TMProTextMeshProUGUI_41 = null;
            Private___intnl_TMProTextMeshProUGUI_40 = null;
            Private___intnl_TMProTextMeshProUGUI_43 = null;
            Private___intnl_TMProTextMeshProUGUI_42 = null;
            Private___intnl_TMProTextMeshProUGUI_45 = null;
            Private___intnl_TMProTextMeshProUGUI_44 = null;
            Private___intnl_TMProTextMeshProUGUI_47 = null;
            Private___intnl_TMProTextMeshProUGUI_46 = null;
            Private___const_SystemString_245 = null;
            Private___const_SystemString_255 = null;
            Private___const_SystemString_225 = null;
            Private___const_SystemString_235 = null;
            Private___const_SystemString_205 = null;
            Private___const_SystemString_215 = null;
            Private___intnl_VRCUdonUdonBehaviour_1 = null;
            Private___const_SystemString_2 = null;
            Private___intnl_SystemBoolean_121 = null;
            Private___intnl_SystemBoolean_120 = null;
            Private___intnl_SystemBoolean_123 = null;
            Private___intnl_SystemBoolean_122 = null;
            Private___intnl_SystemBoolean_125 = null;
            Private___intnl_SystemBoolean_124 = null;
            Private___intnl_SystemBoolean_127 = null;
            Private___intnl_SystemBoolean_126 = null;
            Private___intnl_UnityEngineTransform_2 = null;
            Private___intnl_UnityEngineTexture_0 = null;
            Private___0_tournament__param = null;
            Private___gintnl_SystemCharArray_4 = null;
            Private___const_SystemSingle_2 = null;
            Private___intnl_UnityEngineColor_0 = null;
            Private_shouldBlahaj = null;
            Private_saoToggleProps = null;
            Private___intnl_SystemBoolean_89 = null;
            Private___intnl_SystemBoolean_99 = null;
            Private___intnl_SystemBoolean_19 = null;
            Private___intnl_SystemBoolean_29 = null;
            Private___intnl_SystemBoolean_39 = null;
            Private___intnl_SystemBoolean_49 = null;
            Private___intnl_SystemBoolean_59 = null;
            Private___intnl_SystemBoolean_69 = null;
            Private___intnl_SystemBoolean_79 = null;
            Private_saoCueSkins = null;
            Private___0_active__param = null;
            Private___intnl_UnityEngineGameObject_0 = null;
            Private___lcl_playerId_SystemInt32_0 = null;
            Private___intnl_SystemBoolean_84 = null;
            Private___intnl_SystemBoolean_94 = null;
            Private___intnl_SystemBoolean_14 = null;
            Private___intnl_SystemBoolean_24 = null;
            Private___intnl_SystemBoolean_34 = null;
            Private___intnl_SystemBoolean_44 = null;
            Private___intnl_SystemBoolean_54 = null;
            Private___intnl_SystemBoolean_64 = null;
            Private___intnl_SystemBoolean_74 = null;
            Private___const_SystemInt32_13 = null;
            Private___const_SystemInt32_33 = null;
            Private___const_SystemInt32_23 = null;
            Private___lcl_hours_SystemSingle_0 = null;
            Private___intnl_UnityEngineComponentArray_1 = null;
            Private___intnl_SystemInt32_14 = null;
            Private___intnl_SystemInt32_34 = null;
            Private___intnl_SystemInt32_24 = null;
            Private___intnl_SystemInt32_44 = null;
            Private___lcl_saoCamerasRoot_UnityEngineTransform_0 = null;
            Private___intnl_UnityEngineTransform_131 = null;
            Private___intnl_UnityEngineTransform_121 = null;
            Private___intnl_UnityEngineTransform_111 = null;
            Private___intnl_UnityEngineTransform_101 = null;
            Private___intnl_SystemInt32_19 = null;
            Private___intnl_SystemInt32_39 = null;
            Private___intnl_SystemInt32_29 = null;
            Private___intnl_SystemInt32_49 = null;
            Private_SAO_COLOR_LOCKED = null;
            Private___const_SystemString_164 = null;
            Private___const_SystemString_174 = null;
            Private___const_SystemString_144 = null;
            Private___const_SystemString_154 = null;
            Private___const_SystemString_124 = null;
            Private___const_SystemString_134 = null;
            Private___const_SystemString_104 = null;
            Private___const_SystemString_114 = null;
            Private___const_SystemString_184 = null;
            Private___const_SystemString_194 = null;
            Private_activeYoutubeSearchAttempts = null;
            Private___intnl_TMProTextMeshProUGUI_8 = null;
            Private___intnl_SystemSingle_1 = null;
            Private___intnl_UnityEngineMaterialArray_0 = null;
            Private_worldUpdate = null;
            Private___intnl_TMProTextMeshProUGUI_5 = null;
            Private___const_SystemChar_1 = null;
            Private___intnl_SystemObject_1 = null;
            Private_inOwner = null;
            Private_cueSkinAllowed = null;
            Private___const_SystemString_246 = null;
            Private___const_SystemString_256 = null;
            Private___const_SystemString_226 = null;
            Private___const_SystemString_236 = null;
            Private___const_SystemString_206 = null;
            Private___const_SystemString_216 = null;
            Private_nameColorMap = null;
            Private_propsEnabled = null;
            Private___0___0_isTournamentRunning__ret = null;
            Private___intnl_UnityEngineColor_8 = null;
            Private___const_SystemString_7 = null;
            Private___0_skin__param = null;
            Private___gintnl_SystemCharArray_3 = null;
            Private___const_SystemSingle_1 = null;
            Private___intnl_UnityEngineTransform_69 = null;
            Private___intnl_UnityEngineTransform_68 = null;
            Private___intnl_UnityEngineTransform_63 = null;
            Private___intnl_UnityEngineTransform_62 = null;
            Private___intnl_UnityEngineTransform_61 = null;
            Private___intnl_UnityEngineTransform_60 = null;
            Private___intnl_UnityEngineTransform_67 = null;
            Private___intnl_UnityEngineTransform_66 = null;
            Private___intnl_UnityEngineTransform_65 = null;
            Private___intnl_UnityEngineTransform_64 = null;
            Private___lcl_saoPlayerSettings_UnityEngineTransform_0 = null;
            Private___gintnl_SystemUInt32_91 = null;
            Private___gintnl_SystemUInt32_81 = null;
            Private___gintnl_SystemUInt32_51 = null;
            Private___gintnl_SystemUInt32_41 = null;
            Private___gintnl_SystemUInt32_71 = null;
            Private___gintnl_SystemUInt32_61 = null;
            Private___gintnl_SystemUInt32_11 = null;
            Private___gintnl_SystemUInt32_31 = null;
            Private___gintnl_SystemUInt32_21 = null;
            Private___3_value__param = null;
            Private___intnl_SystemBoolean_87 = null;
            Private___intnl_SystemBoolean_97 = null;
            Private___intnl_SystemBoolean_17 = null;
            Private___intnl_SystemBoolean_27 = null;
            Private___intnl_SystemBoolean_37 = null;
            Private___intnl_SystemBoolean_47 = null;
            Private___intnl_SystemBoolean_57 = null;
            Private___intnl_SystemBoolean_67 = null;
            Private___intnl_SystemBoolean_77 = null;
            Private_popcat = null;
            Private___const_SystemInt32_10 = null;
            Private___const_SystemInt32_30 = null;
            Private___const_SystemInt32_20 = null;
            Private_chat = null;
            Private___intnl_SystemInt32_11 = null;
            Private___intnl_SystemInt32_31 = null;
            Private___intnl_SystemInt32_21 = null;
            Private___intnl_SystemInt32_51 = null;
            Private___intnl_SystemInt32_41 = null;
            Private_saoRunSpeedSlider = null;
            Private_VERSION = null;
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
            Private_saoSaveLoadInput = null;
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
            Private___intnl_TMProTextMeshProUGUI_11 = null;
            Private___intnl_TMProTextMeshProUGUI_10 = null;
            Private___intnl_TMProTextMeshProUGUI_13 = null;
            Private___intnl_TMProTextMeshProUGUI_12 = null;
            Private___intnl_TMProTextMeshProUGUI_15 = null;
            Private___intnl_TMProTextMeshProUGUI_14 = null;
            Private___intnl_TMProTextMeshProUGUI_17 = null;
            Private___intnl_TMProTextMeshProUGUI_16 = null;
            Private___intnl_TMProTextMeshProUGUI_19 = null;
            Private___intnl_TMProTextMeshProUGUI_18 = null;
            Private___intnl_VRCUdonUdonBehaviour_38 = null;
            Private___intnl_SystemInt64_1 = null;
            Private___intnl_SystemInt64_0 = null;
            Private___intnl_TMProTextMeshProUGUI_6 = null;
            Private___lcl_utcNow_SystemDateTime_0 = null;
            Private___intnl_VRCUdonUdonBehaviour_4 = null;
            Private___intnl_returnJump_SystemUInt32_0 = null;
            Private___intnl_UnityEngineTransform_7 = null;
            Private___intnl_UnityEngineColor_10 = null;
            Private___intnl_UnityEngineColor_7 = null;
            Private___const_SystemString_4 = null;
            Private___const_UnityEngineKeyCode_0 = null;
            Private___gintnl_SystemUInt32_99 = null;
            Private___gintnl_SystemUInt32_89 = null;
            Private___gintnl_SystemUInt32_59 = null;
            Private___gintnl_SystemUInt32_49 = null;
            Private___gintnl_SystemUInt32_79 = null;
            Private___gintnl_SystemUInt32_69 = null;
            Private___gintnl_SystemUInt32_19 = null;
            Private___gintnl_SystemUInt32_39 = null;
            Private___gintnl_SystemUInt32_29 = null;
            Private___const_SystemSingle_4 = null;
            Private___intnl_UnityEngineTransform_39 = null;
            Private___intnl_UnityEngineTransform_38 = null;
            Private___intnl_UnityEngineTransform_33 = null;
            Private___intnl_UnityEngineTransform_32 = null;
            Private___intnl_UnityEngineTransform_31 = null;
            Private___intnl_UnityEngineTransform_30 = null;
            Private___intnl_UnityEngineTransform_37 = null;
            Private___intnl_UnityEngineTransform_36 = null;
            Private___intnl_UnityEngineTransform_35 = null;
            Private___intnl_UnityEngineTransform_34 = null;
            Private___const_SystemInt32_18 = null;
            Private___const_SystemInt32_38 = null;
            Private___const_SystemInt32_28 = null;
            Private___0_physicsMode___param = null;
            Private___gintnl_SystemUInt32_92 = null;
            Private___gintnl_SystemUInt32_82 = null;
            Private___gintnl_SystemUInt32_52 = null;
            Private___gintnl_SystemUInt32_42 = null;
            Private___gintnl_SystemUInt32_72 = null;
            Private___gintnl_SystemUInt32_62 = null;
            Private___gintnl_SystemUInt32_12 = null;
            Private___gintnl_SystemUInt32_32 = null;
            Private___gintnl_SystemUInt32_22 = null;
            Private_saoWalkSpeedSlider = null;
            Private___intnl_UnityEngineTransform_124 = null;
            Private___intnl_UnityEngineTransform_114 = null;
            Private___intnl_UnityEngineTransform_104 = null;
            Private___intnl_UnityEngineTransform_89 = null;
            Private___intnl_UnityEngineTransform_88 = null;
            Private___intnl_UnityEngineTransform_83 = null;
            Private___intnl_UnityEngineTransform_82 = null;
            Private___intnl_UnityEngineTransform_81 = null;
            Private___intnl_UnityEngineTransform_80 = null;
            Private___intnl_UnityEngineTransform_87 = null;
            Private___intnl_UnityEngineTransform_86 = null;
            Private___intnl_UnityEngineTransform_85 = null;
            Private___intnl_UnityEngineTransform_84 = null;
            Private___lcl_i_SystemInt32_8 = null;
            Private___lcl_i_SystemInt32_1 = null;
            Private___lcl_i_SystemInt32_0 = null;
            Private___lcl_i_SystemInt32_3 = null;
            Private___lcl_i_SystemInt32_2 = null;
            Private___lcl_i_SystemInt32_5 = null;
            Private___lcl_i_SystemInt32_4 = null;
            Private___lcl_i_SystemInt32_7 = null;
            Private___lcl_i_SystemInt32_6 = null;
            Private_shouldPing = null;
            Private___const_SystemInt32_15 = null;
            Private___const_SystemInt32_35 = null;
            Private___const_SystemInt32_25 = null;
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = null;
            Private___const_SystemString_163 = null;
            Private___const_SystemString_173 = null;
            Private___const_SystemString_143 = null;
            Private___const_SystemString_153 = null;
            Private___const_SystemString_123 = null;
            Private___const_SystemString_133 = null;
            Private___const_SystemString_103 = null;
            Private___const_SystemString_113 = null;
            Private___const_SystemString_183 = null;
            Private___const_SystemString_193 = null;
            Private_inLocalVersion = null;
            Private___intnl_SystemSingle_4 = null;
            Private___1__intnlparam = null;
            Private___intnl_SystemObject_4 = null;
            Private_saoTogglePens = null;
            Private_tournamentDate = null;
            Private___intnl_TMProTextMeshProUGUI_21 = null;
            Private___intnl_TMProTextMeshProUGUI_20 = null;
            Private___intnl_TMProTextMeshProUGUI_23 = null;
            Private___intnl_TMProTextMeshProUGUI_22 = null;
            Private___intnl_TMProTextMeshProUGUI_25 = null;
            Private___intnl_TMProTextMeshProUGUI_24 = null;
            Private___intnl_TMProTextMeshProUGUI_27 = null;
            Private___intnl_TMProTextMeshProUGUI_26 = null;
            Private___intnl_TMProTextMeshProUGUI_29 = null;
            Private___intnl_TMProTextMeshProUGUI_28 = null;
            Private___const_SystemString_263 = null;
            Private___const_SystemString_243 = null;
            Private___const_SystemString_253 = null;
            Private___const_SystemString_223 = null;
            Private___const_SystemString_233 = null;
            Private___const_SystemString_203 = null;
            Private___const_SystemString_213 = null;
            Private_shouldToaster = null;
            Private___const_UnityEngineSpace_0 = null;
            Private___intnl_VRCUdonUdonBehaviour_3 = null;
            Private___intnl_SystemBoolean_109 = null;
            Private___intnl_SystemBoolean_108 = null;
            Private___intnl_SystemBoolean_101 = null;
            Private___intnl_SystemBoolean_100 = null;
            Private___intnl_SystemBoolean_103 = null;
            Private___intnl_SystemBoolean_102 = null;
            Private___intnl_SystemBoolean_105 = null;
            Private___intnl_SystemBoolean_104 = null;
            Private___intnl_SystemBoolean_107 = null;
            Private___intnl_SystemBoolean_106 = null;
            Private___intnl_UnityEngineTransform_4 = null;
            Private___0___0_canUseTableSkin__ret = null;
            Private___gintnl_SystemCharArray_6 = null;
            Private___intnl_UnityEngineColor_2 = null;
            Private___const_SystemString_9 = null;
            Private___intnl_UnityEngineTexture2DArray_0 = null;
            Private___intnl_UnityEngineTransform_9 = null;
            Private___intnl_SystemBoolean_82 = null;
            Private___intnl_SystemBoolean_92 = null;
            Private___intnl_SystemBoolean_12 = null;
            Private___intnl_SystemBoolean_22 = null;
            Private___intnl_SystemBoolean_32 = null;
            Private___intnl_SystemBoolean_42 = null;
            Private___intnl_SystemBoolean_52 = null;
            Private___intnl_SystemBoolean_62 = null;
            Private___intnl_SystemBoolean_72 = null;
            Private_saoToggleTableTimer = null;
            Private___gintnl_SystemUInt32_97 = null;
            Private___gintnl_SystemUInt32_87 = null;
            Private___gintnl_SystemUInt32_57 = null;
            Private___gintnl_SystemUInt32_47 = null;
            Private___gintnl_SystemUInt32_77 = null;
            Private___gintnl_SystemUInt32_67 = null;
            Private___gintnl_SystemUInt32_17 = null;
            Private___gintnl_SystemUInt32_37 = null;
            Private___gintnl_SystemUInt32_27 = null;
            Private___intnl_SystemInt32_16 = null;
            Private___intnl_SystemInt32_36 = null;
            Private___intnl_SystemInt32_26 = null;
            Private___intnl_SystemInt32_46 = null;
            Private___intnl_UnityEngineTransform_133 = null;
            Private___intnl_UnityEngineTransform_123 = null;
            Private___intnl_UnityEngineTransform_113 = null;
            Private___intnl_UnityEngineTransform_103 = null;
            Private___refl_typename = null;
            Private___gintnl_SystemObjectArray_0 = null;
            Private___const_SystemString_166 = null;
            Private___const_SystemString_176 = null;
            Private___const_SystemString_146 = null;
            Private___const_SystemString_156 = null;
            Private___const_SystemString_126 = null;
            Private___const_SystemString_136 = null;
            Private___const_SystemString_106 = null;
            Private___const_SystemString_116 = null;
            Private___const_SystemString_186 = null;
            Private___const_SystemString_196 = null;
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
            Private_tableButtonToSkin = null;
            Private___intnl_SystemDateTime_0 = null;
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
            Private___intnl_SystemGuid_1 = null;
            Private___intnl_SystemSingle_3 = null;
            Private___intnl_TMProTextMeshProUGUI_3 = null;
            Private___intnl_SystemObject_3 = null;
            Private___const_SystemString_264 = null;
            Private___const_SystemString_244 = null;
            Private___const_SystemString_254 = null;
            Private___const_SystemString_224 = null;
            Private___const_SystemString_234 = null;
            Private___const_SystemString_204 = null;
            Private___const_SystemString_214 = null;
            Private___lcl_saoWorldSettings_UnityEngineTransform_0 = null;
            Private___lcl_targetID_SystemInt64_0 = null;
            Private___const_SystemString_1 = null;
            Private___intnl_UnityEngineTransform_1 = null;
            Private___gintnl_SystemCharArray_5 = null;
            Private___const_SystemSingle_3 = null;
            Private___intnl_SystemDouble_0 = null;
            Private___lcl_idValue_SystemObject_0 = null;
            Private___intnl_UnityEngineColor_1 = null;
            Private___lcl_saoTableSkinsRoot_UnityEngineTransform_0 = null;
            Private___intnl_SystemBoolean_85 = null;
            Private___intnl_SystemBoolean_95 = null;
            Private___intnl_SystemBoolean_15 = null;
            Private___intnl_SystemBoolean_25 = null;
            Private___intnl_SystemBoolean_35 = null;
            Private___intnl_SystemBoolean_45 = null;
            Private___intnl_SystemBoolean_55 = null;
            Private___intnl_SystemBoolean_65 = null;
            Private___intnl_SystemBoolean_75 = null;
            Private_previewCue = null;
            Private___const_SystemInt32_12 = null;
            Private___const_SystemInt32_32 = null;
            Private___const_SystemInt32_22 = null;
            Private___0_tableTimer__param = null;
            Private___2_value__param = null;
            Private___intnl_SystemInt32_13 = null;
            Private___intnl_SystemInt32_33 = null;
            Private___intnl_SystemInt32_23 = null;
            Private___intnl_SystemInt32_43 = null;
            Private___lcl_cueId_SystemInt32_0 = null;
            Private___intnl_SystemInt32_18 = null;
            Private___intnl_SystemInt32_38 = null;
            Private___intnl_SystemInt32_28 = null;
            Private___intnl_SystemInt32_48 = null;
            Private___const_SystemString_165 = null;
            Private___const_SystemString_175 = null;
            Private___const_SystemString_145 = null;
            Private___const_SystemString_155 = null;
            Private___const_SystemString_125 = null;
            Private___const_SystemString_135 = null;
            Private___const_SystemString_105 = null;
            Private___const_SystemString_115 = null;
            Private___const_SystemString_185 = null;
            Private___const_SystemString_195 = null;
            Private_shouldPopcat = null;
            Private___intnl_SystemByte_0 = null;
            Private___0_mode__param = null;
            Private_saoTableModels = null;
            Private_saoTogglePlayer = null;
            Private___intnl_TMProTextMeshProUGUI_4 = null;
            Private___const_SystemChar_0 = null;
            Private___lcl_ch_SystemChar_0 = null;
            Private___intnl_VRCUdonUdonBehaviour_6 = null;
            Private___const_SystemString_249 = null;
            Private___const_SystemString_259 = null;
            Private___const_SystemString_229 = null;
            Private___const_SystemString_239 = null;
            Private___const_SystemString_209 = null;
            Private___const_SystemString_219 = null;
            Private_outColor = null;
            Private___intnl_UnityEngineColor_9 = null;
            Private___const_SystemString_6 = null;
            Private___gintnl_SystemCharArray_0 = null;
            Private_outSetting = null;
            Private___intnl_UnityEngineTransform_59 = null;
            Private___intnl_UnityEngineTransform_58 = null;
            Private___intnl_UnityEngineTransform_53 = null;
            Private___intnl_UnityEngineTransform_52 = null;
            Private___intnl_UnityEngineTransform_51 = null;
            Private___intnl_UnityEngineTransform_50 = null;
            Private___intnl_UnityEngineTransform_57 = null;
            Private___intnl_UnityEngineTransform_56 = null;
            Private___intnl_UnityEngineTransform_55 = null;
            Private___intnl_UnityEngineTransform_54 = null;
            Private___0___0_getPenSocialSetting__ret = null;
            Private___gintnl_SystemUInt32_90 = null;
            Private___gintnl_SystemUInt32_80 = null;
            Private___gintnl_SystemUInt32_50 = null;
            Private___gintnl_SystemUInt32_40 = null;
            Private___gintnl_SystemUInt32_70 = null;
            Private___gintnl_SystemUInt32_60 = null;
            Private___gintnl_SystemUInt32_10 = null;
            Private___gintnl_SystemUInt32_30 = null;
            Private___gintnl_SystemUInt32_20 = null;
            Private___0___0_canUseCueSkin__ret = null;
            Private___intnl_UnityEngineTransform_126 = null;
            Private___intnl_UnityEngineTransform_116 = null;
            Private___intnl_UnityEngineTransform_106 = null;
            Private___const_SystemInt32_17 = null;
            Private___const_SystemInt32_37 = null;
            Private___const_SystemInt32_27 = null;
            Private___intnl_UnityEngineTexture2D_0 = null;
            Private___intnl_SystemInt32_10 = null;
            Private___intnl_SystemInt32_30 = null;
            Private___intnl_SystemInt32_20 = null;
            Private___intnl_SystemInt32_50 = null;
            Private___intnl_SystemInt32_40 = null;
            Private_tournamentRefs = null;
            Private_saoStrafeSpeedSlider = null;
            Private___const_SystemString_168 = null;
            Private___const_SystemString_178 = null;
            Private___const_SystemString_148 = null;
            Private___const_SystemString_158 = null;
            Private___const_SystemString_128 = null;
            Private___const_SystemString_138 = null;
            Private___const_SystemString_108 = null;
            Private___const_SystemString_118 = null;
            Private___const_SystemString_188 = null;
            Private___const_SystemString_198 = null;
            Private_saoToggleBallShadow = null;
            Private___this_UnityEngineGameObject_0 = null;
            Private___1_value__param = null;
            Private_saoToggleLegacyPhysics = null;
            Private_blahaj = null;
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
            Private___gintnl_SystemUInt32_100 = null;
            Private___gintnl_SystemUInt32_101 = null;
            Private___gintnl_SystemUInt32_102 = null;
            Private___gintnl_SystemUInt32_103 = null;
            Private_saoLoliLifterSlider = null;
            Private___intnl_SystemObject_6 = null;
            Private_INITIALIZED = null;
            Private___const_SystemString_261 = null;
            Private___const_SystemString_241 = null;
            Private___const_SystemString_251 = null;
            Private___const_SystemString_221 = null;
            Private___const_SystemString_231 = null;
            Private___const_SystemString_201 = null;
            Private___const_SystemString_211 = null;
            Private_selectedCueSkin = null;
            Private___intnl_VRCUdonUdonBehaviour_5 = null;
            Private___0_hasPendingRequest__ret = null;
            Private___intnl_UnityEngineTransform_6 = null;
            Private_inRemoteVersion = null;
            Private_activeYoutubeSearch = null;
            Private___intnl_UnityEngineColor_4 = null;
            Private___gintnl_SystemUInt32_98 = null;
            Private___gintnl_SystemUInt32_88 = null;
            Private___gintnl_SystemUInt32_58 = null;
            Private___gintnl_SystemUInt32_48 = null;
            Private___gintnl_SystemUInt32_78 = null;
            Private___gintnl_SystemUInt32_68 = null;
            Private___gintnl_SystemUInt32_18 = null;
            Private___gintnl_SystemUInt32_38 = null;
            Private___gintnl_SystemUInt32_28 = null;
            Private_selectedTableSkin = null;
            Private_DEPENDENCIES = null;
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
            Private___intnl_UnityEngineTransform_29 = null;
            Private___intnl_UnityEngineTransform_28 = null;
            Private___intnl_UnityEngineTransform_23 = null;
            Private___intnl_UnityEngineTransform_22 = null;
            Private___intnl_UnityEngineTransform_21 = null;
            Private___intnl_UnityEngineTransform_20 = null;
            Private___intnl_UnityEngineTransform_27 = null;
            Private___intnl_UnityEngineTransform_26 = null;
            Private___intnl_UnityEngineTransform_25 = null;
            Private___intnl_UnityEngineTransform_24 = null;
            Private___gintnl_SystemUInt32_95 = null;
            Private___gintnl_SystemUInt32_85 = null;
            Private___gintnl_SystemUInt32_55 = null;
            Private___gintnl_SystemUInt32_45 = null;
            Private___gintnl_SystemUInt32_75 = null;
            Private___gintnl_SystemUInt32_65 = null;
            Private___gintnl_SystemUInt32_15 = null;
            Private___gintnl_SystemUInt32_35 = null;
            Private___gintnl_SystemUInt32_25 = null;
            Private___0__SelectCueSkinContributor__ret = null;
            Private_tableSkinAllowed = null;
            Private___intnl_UnityEngineTransform_125 = null;
            Private___intnl_UnityEngineTransform_115 = null;
            Private___intnl_UnityEngineTransform_105 = null;
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
            Private___lcl_udonBehaviours_UnityEngineComponentArray_0 = null;
            Private_lastPoll = null;
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
            Private___intnl_UnityEngineTransform_128 = null;
            Private___intnl_UnityEngineTransform_118 = null;
            Private___intnl_UnityEngineTransform_108 = null;
            Private___const_SystemString_160 = null;
            Private___const_SystemString_170 = null;
            Private___const_SystemString_140 = null;
            Private___const_SystemString_150 = null;
            Private___const_SystemString_120 = null;
            Private___const_SystemString_130 = null;
            Private___const_SystemString_100 = null;
            Private___const_SystemString_110 = null;
            Private___const_SystemString_180 = null;
            Private___const_SystemString_190 = null;
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
            Private_saoToggleUSColors = null;
            Private___0___0_onChatCommand__ret = null;
            Private___intnl_TMProTextMeshProUGUI_1 = null;
            Private___intnl_SystemObject_5 = null;
            Private___intnl_TMProTextMeshProUGUI_57 = null;
            Private___intnl_TMProTextMeshProUGUI_58 = null;
            Private___const_SystemString_262 = null;
            Private___const_SystemString_242 = null;
            Private___const_SystemString_252 = null;
            Private___const_SystemString_222 = null;
            Private___const_SystemString_232 = null;
            Private___const_SystemString_202 = null;
            Private___const_SystemString_212 = null;
            Private_saoJumpImpulseSlider = null;
            Private___intnl_VRCUdonUdonBehaviour_0 = null;
            Private_saoMenu = null;
            Private___const_SystemString_3 = null;
            Private___this_VRCUdonUdonBehaviour_3 = null;
            Private___this_VRCUdonUdonBehaviour_2 = null;
            Private___this_VRCUdonUdonBehaviour_1 = null;
            Private___this_VRCUdonUdonBehaviour_0 = null;
            Private___this_VRCUdonUdonBehaviour_4 = null;
            Private_saoTableSkins = null;
            Private___intnl_SystemBoolean_119 = null;
            Private___intnl_SystemBoolean_118 = null;
            Private___intnl_SystemBoolean_111 = null;
            Private___intnl_SystemBoolean_110 = null;
            Private___intnl_SystemBoolean_113 = null;
            Private___intnl_SystemBoolean_112 = null;
            Private___intnl_SystemBoolean_115 = null;
            Private___intnl_SystemBoolean_114 = null;
            Private___intnl_SystemBoolean_117 = null;
            Private___intnl_SystemBoolean_116 = null;
            Private___intnl_UnityEngineTransform_3 = null;
            Private___intnl_UnityEngineColor_3 = null;
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
            Private___intnl_UnityEngineTransform_8 = null;
        }

        #region Getter / Setters AstroUdonVariables  of PoolParlorModule

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

        internal VRC.Udon.UdonBehaviour hologramSystem
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hologramSystem != null)
                {
                    return Private_hologramSystem.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_hologramSystem != null)
                {
                    Private_hologramSystem.Value = value;
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_96
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_96 != null)
                {
                    return Private___gintnl_SystemUInt32_96.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_96 != null)
                    {
                        Private___gintnl_SystemUInt32_96.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_86
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_86 != null)
                {
                    return Private___gintnl_SystemUInt32_86.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_86 != null)
                    {
                        Private___gintnl_SystemUInt32_86.Value = value.Value;
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

        internal int? __lcl_tableCount_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_tableCount_SystemInt32_0 != null)
                {
                    return Private___lcl_tableCount_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_tableCount_SystemInt32_0 != null)
                    {
                        Private___lcl_tableCount_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __1_accept__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_accept__param != null)
                {
                    return Private___1_accept__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_accept__param != null)
                    {
                        Private___1_accept__param.Value = value.Value;
                    }
                }
            }
        }

        internal int? selectedTableModel
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_selectedTableModel != null)
                {
                    return Private_selectedTableModel.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_selectedTableModel != null)
                    {
                        Private_selectedTableModel.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __lcl_saoTableModelsRoot_UnityEngineTransform_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_saoTableModelsRoot_UnityEngineTransform_0 != null)
                {
                    return Private___lcl_saoTableModelsRoot_UnityEngineTransform_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_saoTableModelsRoot_UnityEngineTransform_0 != null)
                {
                    Private___lcl_saoTableModelsRoot_UnityEngineTransform_0.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_130
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_130 != null)
                {
                    return Private___intnl_UnityEngineTransform_130.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_130 != null)
                {
                    Private___intnl_UnityEngineTransform_130.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_120
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_120 != null)
                {
                    return Private___intnl_UnityEngineTransform_120.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_120 != null)
                {
                    Private___intnl_UnityEngineTransform_120.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_110
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_110 != null)
                {
                    return Private___intnl_UnityEngineTransform_110.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_110 != null)
                {
                    Private___intnl_UnityEngineTransform_110.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_100
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_100 != null)
                {
                    return Private___intnl_UnityEngineTransform_100.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_100 != null)
                {
                    Private___intnl_UnityEngineTransform_100.Value = value;
                }
            }
        }

        internal string __const_SystemString_167
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_167 != null)
                {
                    return Private___const_SystemString_167.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_167 != null)
                {
                    Private___const_SystemString_167.Value = value;
                }
            }
        }

        internal string __const_SystemString_177
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_177 != null)
                {
                    return Private___const_SystemString_177.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_177 != null)
                {
                    Private___const_SystemString_177.Value = value;
                }
            }
        }

        internal string __const_SystemString_147
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_147 != null)
                {
                    return Private___const_SystemString_147.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_147 != null)
                {
                    Private___const_SystemString_147.Value = value;
                }
            }
        }

        internal string __const_SystemString_157
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_157 != null)
                {
                    return Private___const_SystemString_157.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_157 != null)
                {
                    Private___const_SystemString_157.Value = value;
                }
            }
        }

        internal string __const_SystemString_127
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_127 != null)
                {
                    return Private___const_SystemString_127.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_127 != null)
                {
                    Private___const_SystemString_127.Value = value;
                }
            }
        }

        internal string __const_SystemString_137
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_137 != null)
                {
                    return Private___const_SystemString_137.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_137 != null)
                {
                    Private___const_SystemString_137.Value = value;
                }
            }
        }

        internal string __const_SystemString_107
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_107 != null)
                {
                    return Private___const_SystemString_107.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_107 != null)
                {
                    Private___const_SystemString_107.Value = value;
                }
            }
        }

        internal string __const_SystemString_117
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_117 != null)
                {
                    return Private___const_SystemString_117.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_117 != null)
                {
                    Private___const_SystemString_117.Value = value;
                }
            }
        }

        internal string __const_SystemString_187
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_187 != null)
                {
                    return Private___const_SystemString_187.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_187 != null)
                {
                    Private___const_SystemString_187.Value = value;
                }
            }
        }

        internal string __const_SystemString_197
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_197 != null)
                {
                    return Private___const_SystemString_197.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_197 != null)
                {
                    Private___const_SystemString_197.Value = value;
                }
            }
        }

        internal UnityEngine.Material __intnl_UnityEngineMaterial_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineMaterial_0 != null)
                {
                    return Private___intnl_UnityEngineMaterial_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineMaterial_0 != null)
                {
                    Private___intnl_UnityEngineMaterial_0.Value = value;
                }
            }
        }

        internal bool? __0__SelectTableSkinContributor__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0__SelectTableSkinContributor__ret != null)
                {
                    return Private___0__SelectTableSkinContributor__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0__SelectTableSkinContributor__ret != null)
                    {
                        Private___0__SelectTableSkinContributor__ret.Value = value.Value;
                    }
                }
            }
        }

        internal System.DateTimeOffset? __intnl_SystemDateTimeOffset_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDateTimeOffset_0 != null)
                {
                    return Private___intnl_SystemDateTimeOffset_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDateTimeOffset_0 != null)
                    {
                        Private___intnl_SystemDateTimeOffset_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject ping
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ping != null)
                {
                    return Private_ping.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ping != null)
                {
                    Private_ping.Value = value;
                }
            }
        }

        internal bool? __2_active__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_active__param != null)
                {
                    return Private___2_active__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_active__param != null)
                    {
                        Private___2_active__param.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_9 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_9 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_9.Value = value;
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

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_2 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_2 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_2.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_0
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

        internal int? __1_id__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_id__param != null)
                {
                    return Private___1_id__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_id__param != null)
                    {
                        Private___1_id__param.Value = value.Value;
                    }
                }
            }
        }

        internal bool? outCanUse
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outCanUse != null)
                {
                    return Private_outCanUse.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_outCanUse != null)
                    {
                        Private_outCanUse.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_60
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_60 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_60.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_60 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_60.Value = value;
                }
            }
        }

        internal string __const_SystemString_247
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_247 != null)
                {
                    return Private___const_SystemString_247.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_247 != null)
                {
                    Private___const_SystemString_247.Value = value;
                }
            }
        }

        internal string __const_SystemString_257
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_257 != null)
                {
                    return Private___const_SystemString_257.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_257 != null)
                {
                    Private___const_SystemString_257.Value = value;
                }
            }
        }

        internal string __const_SystemString_227
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_227 != null)
                {
                    return Private___const_SystemString_227.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_227 != null)
                {
                    Private___const_SystemString_227.Value = value;
                }
            }
        }

        internal string __const_SystemString_237
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_237 != null)
                {
                    return Private___const_SystemString_237.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_237 != null)
                {
                    Private___const_SystemString_237.Value = value;
                }
            }
        }

        internal string __const_SystemString_207
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_207 != null)
                {
                    return Private___const_SystemString_207.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_207 != null)
                {
                    Private___const_SystemString_207.Value = value;
                }
            }
        }

        internal string __const_SystemString_217
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_217 != null)
                {
                    return Private___const_SystemString_217.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_217 != null)
                {
                    Private___const_SystemString_217.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour liftModule
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_liftModule != null)
                {
                    return Private_liftModule.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_liftModule != null)
                {
                    Private_liftModule.Value = value;
                }
            }
        }

        internal bool? __0_accept__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_accept__param != null)
                {
                    return Private___0_accept__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_accept__param != null)
                    {
                        Private___0_accept__param.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_id__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_id__param != null)
                {
                    return Private___0_id__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_id__param != null)
                    {
                        Private___0_id__param.Value = value.Value;
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

        internal int? __3_id__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_id__param != null)
                {
                    return Private___3_id__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_id__param != null)
                    {
                        Private___3_id__param.Value = value.Value;
                    }
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

        internal bool? __0_shadowsDisabled__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_shadowsDisabled__param != null)
                {
                    return Private___0_shadowsDisabled__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_shadowsDisabled__param != null)
                    {
                        Private___0_shadowsDisabled__param.Value = value.Value;
                    }
                }
            }
        }

        internal char[] __gintnl_SystemCharArray_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemCharArray_2 != null)
                {
                    return Private___gintnl_SystemCharArray_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemCharArray_2 != null)
                {
                    Private___gintnl_SystemCharArray_2.Value = value;
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

        internal int? __2_id__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_id__param != null)
                {
                    return Private___2_id__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_id__param != null)
                    {
                        Private___2_id__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_79
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_79 != null)
                {
                    return Private___intnl_UnityEngineTransform_79.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_79 != null)
                {
                    Private___intnl_UnityEngineTransform_79.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_78
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_78 != null)
                {
                    return Private___intnl_UnityEngineTransform_78.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_78 != null)
                {
                    Private___intnl_UnityEngineTransform_78.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_73
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_73 != null)
                {
                    return Private___intnl_UnityEngineTransform_73.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_73 != null)
                {
                    Private___intnl_UnityEngineTransform_73.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_72
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_72 != null)
                {
                    return Private___intnl_UnityEngineTransform_72.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_72 != null)
                {
                    Private___intnl_UnityEngineTransform_72.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_71
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_71 != null)
                {
                    return Private___intnl_UnityEngineTransform_71.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_71 != null)
                {
                    Private___intnl_UnityEngineTransform_71.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_70
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_70 != null)
                {
                    return Private___intnl_UnityEngineTransform_70.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_70 != null)
                {
                    Private___intnl_UnityEngineTransform_70.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_77
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_77 != null)
                {
                    return Private___intnl_UnityEngineTransform_77.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_77 != null)
                {
                    Private___intnl_UnityEngineTransform_77.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_76
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_76 != null)
                {
                    return Private___intnl_UnityEngineTransform_76.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_76 != null)
                {
                    Private___intnl_UnityEngineTransform_76.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_75
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_75 != null)
                {
                    return Private___intnl_UnityEngineTransform_75.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_75 != null)
                {
                    Private___intnl_UnityEngineTransform_75.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_74
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_74 != null)
                {
                    return Private___intnl_UnityEngineTransform_74.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_74 != null)
                {
                    Private___intnl_UnityEngineTransform_74.Value = value;
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

        internal TMPro.TextMeshProUGUI saoToggleCamera
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoToggleCamera != null)
                {
                    return Private_saoToggleCamera.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoToggleCamera != null)
                {
                    Private_saoToggleCamera.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_15 != null)
                {
                    return Private___intnl_SystemObject_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_15 != null)
                {
                    Private___intnl_SystemObject_15.Value = value;
                }
            }
        }

        internal UnityEngine.Texture2D[] __intnl_SystemObject_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_18 != null)
                {
                    return Private___intnl_SystemObject_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_18 != null)
                {
                    Private___intnl_SystemObject_18.Value = value;
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

        internal TMPro.TextMeshProUGUI[] saoCameras
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoCameras != null)
                {
                    return Private_saoCameras.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoCameras != null)
                {
                    Private_saoCameras.Value = value;
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

        internal int? __lcl_cueSkinId_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_cueSkinId_SystemInt32_0 != null)
                {
                    return Private___lcl_cueSkinId_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_cueSkinId_SystemInt32_0 != null)
                    {
                        Private___lcl_cueSkinId_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_value__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_value__param != null)
                {
                    return Private___0_value__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_value__param != null)
                    {
                        Private___0_value__param.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_96
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_96 != null)
                {
                    return Private___const_SystemString_96.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_96 != null)
                {
                    Private___const_SystemString_96.Value = value;
                }
            }
        }

        internal string __const_SystemString_97
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_97 != null)
                {
                    return Private___const_SystemString_97.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_97 != null)
                {
                    Private___const_SystemString_97.Value = value;
                }
            }
        }

        internal string __const_SystemString_94
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_94 != null)
                {
                    return Private___const_SystemString_94.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_94 != null)
                {
                    Private___const_SystemString_94.Value = value;
                }
            }
        }

        internal string __const_SystemString_95
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_95 != null)
                {
                    return Private___const_SystemString_95.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_95 != null)
                {
                    Private___const_SystemString_95.Value = value;
                }
            }
        }

        internal string __const_SystemString_92
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_92 != null)
                {
                    return Private___const_SystemString_92.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_92 != null)
                {
                    Private___const_SystemString_92.Value = value;
                }
            }
        }

        internal string __const_SystemString_93
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_93 != null)
                {
                    return Private___const_SystemString_93.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_93 != null)
                {
                    Private___const_SystemString_93.Value = value;
                }
            }
        }

        internal string __const_SystemString_90
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_90 != null)
                {
                    return Private___const_SystemString_90.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_90 != null)
                {
                    Private___const_SystemString_90.Value = value;
                }
            }
        }

        internal string __const_SystemString_91
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_91 != null)
                {
                    return Private___const_SystemString_91.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_91 != null)
                {
                    Private___const_SystemString_91.Value = value;
                }
            }
        }

        internal string __const_SystemString_98
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_98 != null)
                {
                    return Private___const_SystemString_98.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_98 != null)
                {
                    Private___const_SystemString_98.Value = value;
                }
            }
        }

        internal string __const_SystemString_99
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_99 != null)
                {
                    return Private___const_SystemString_99.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_99 != null)
                {
                    Private___const_SystemString_99.Value = value;
                }
            }
        }

        internal int? __0_newPhysicsMode__param
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

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_20 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_20 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_20.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_25 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_25 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_25.Value = value;
                }
            }
        }

        internal int? __lcl_cueCount_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_cueCount_SystemInt32_0 != null)
                {
                    return Private___lcl_cueCount_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_cueCount_SystemInt32_0 != null)
                    {
                        Private___lcl_cueCount_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_7 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_7 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_7.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI saoToggleHologram
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoToggleHologram != null)
                {
                    return Private_saoToggleHologram.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoToggleHologram != null)
                {
                    Private_saoToggleHologram.Value = value;
                }
            }
        }

        internal int[] cueButtonToSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueButtonToSkin != null)
                {
                    return Private_cueButtonToSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cueButtonToSkin != null)
                {
                    Private_cueButtonToSkin.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_7 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_7 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_7.Value = value;
                }
            }
        }

        internal string __const_SystemString_248
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_248 != null)
                {
                    return Private___const_SystemString_248.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_248 != null)
                {
                    Private___const_SystemString_248.Value = value;
                }
            }
        }

        internal string __const_SystemString_258
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_258 != null)
                {
                    return Private___const_SystemString_258.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_258 != null)
                {
                    Private___const_SystemString_258.Value = value;
                }
            }
        }

        internal string __const_SystemString_228
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_228 != null)
                {
                    return Private___const_SystemString_228.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_228 != null)
                {
                    Private___const_SystemString_228.Value = value;
                }
            }
        }

        internal string __const_SystemString_238
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_238 != null)
                {
                    return Private___const_SystemString_238.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_238 != null)
                {
                    Private___const_SystemString_238.Value = value;
                }
            }
        }

        internal string __const_SystemString_208
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_208 != null)
                {
                    return Private___const_SystemString_208.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_208 != null)
                {
                    Private___const_SystemString_208.Value = value;
                }
            }
        }

        internal string __const_SystemString_218
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_218 != null)
                {
                    return Private___const_SystemString_218.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_218 != null)
                {
                    Private___const_SystemString_218.Value = value;
                }
            }
        }

        internal int? __lcl_tableId_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_tableId_SystemInt32_0 != null)
                {
                    return Private___lcl_tableId_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_tableId_SystemInt32_0 != null)
                    {
                        Private___lcl_tableId_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_usColors__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_usColors__param != null)
                {
                    return Private___0_usColors__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_usColors__param != null)
                    {
                        Private___0_usColors__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __intnl_UnityEngineColor_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_6 != null)
                {
                    return Private___intnl_UnityEngineColor_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_6 != null)
                    {
                        Private___intnl_UnityEngineColor_6.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __1_enabled__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_enabled__param != null)
                {
                    return Private___1_enabled__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_enabled__param != null)
                    {
                        Private___1_enabled__param.Value = value.Value;
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

        internal int? __1_skin__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_skin__param != null)
                {
                    return Private___1_skin__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_skin__param != null)
                    {
                        Private___1_skin__param.Value = value.Value;
                    }
                }
            }
        }

        internal int? selectedCamera
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_selectedCamera != null)
                {
                    return Private_selectedCamera.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_selectedCamera != null)
                    {
                        Private_selectedCamera.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_49
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_49 != null)
                {
                    return Private___intnl_UnityEngineTransform_49.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_49 != null)
                {
                    Private___intnl_UnityEngineTransform_49.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_48
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_48 != null)
                {
                    return Private___intnl_UnityEngineTransform_48.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_48 != null)
                {
                    Private___intnl_UnityEngineTransform_48.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_43
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_43 != null)
                {
                    return Private___intnl_UnityEngineTransform_43.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_43 != null)
                {
                    Private___intnl_UnityEngineTransform_43.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_42
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_42 != null)
                {
                    return Private___intnl_UnityEngineTransform_42.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_42 != null)
                {
                    Private___intnl_UnityEngineTransform_42.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_41
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_41 != null)
                {
                    return Private___intnl_UnityEngineTransform_41.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_41 != null)
                {
                    Private___intnl_UnityEngineTransform_41.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_40
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_40 != null)
                {
                    return Private___intnl_UnityEngineTransform_40.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_40 != null)
                {
                    Private___intnl_UnityEngineTransform_40.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_47
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_47 != null)
                {
                    return Private___intnl_UnityEngineTransform_47.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_47 != null)
                {
                    Private___intnl_UnityEngineTransform_47.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_46
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_46 != null)
                {
                    return Private___intnl_UnityEngineTransform_46.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_46 != null)
                {
                    Private___intnl_UnityEngineTransform_46.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_45
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_45 != null)
                {
                    return Private___intnl_UnityEngineTransform_45.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_45 != null)
                {
                    Private___intnl_UnityEngineTransform_45.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_44
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_44 != null)
                {
                    return Private___intnl_UnityEngineTransform_44.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_44 != null)
                {
                    Private___intnl_UnityEngineTransform_44.Value = value;
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

        internal uint? __gintnl_SystemUInt32_93
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_93 != null)
                {
                    return Private___gintnl_SystemUInt32_93.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_93 != null)
                    {
                        Private___gintnl_SystemUInt32_93.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_83
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_83 != null)
                {
                    return Private___gintnl_SystemUInt32_83.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_83 != null)
                    {
                        Private___gintnl_SystemUInt32_83.Value = value.Value;
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

        internal int? inMode
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inMode != null)
                {
                    return Private_inMode.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inMode != null)
                    {
                        Private_inMode.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_tableSkinId_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_tableSkinId_SystemInt32_0 != null)
                {
                    return Private___lcl_tableSkinId_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_tableSkinId_SystemInt32_0 != null)
                    {
                        Private___lcl_tableSkinId_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? isPolling
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_isPolling != null)
                {
                    return Private_isPolling.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_isPolling != null)
                    {
                        Private_isPolling.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_127
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_127 != null)
                {
                    return Private___intnl_UnityEngineTransform_127.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_127 != null)
                {
                    Private___intnl_UnityEngineTransform_127.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_117
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_117 != null)
                {
                    return Private___intnl_UnityEngineTransform_117.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_117 != null)
                {
                    Private___intnl_UnityEngineTransform_117.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_107
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_107 != null)
                {
                    return Private___intnl_UnityEngineTransform_107.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_107 != null)
                {
                    Private___intnl_UnityEngineTransform_107.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour metaverse
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_metaverse != null)
                {
                    return Private_metaverse.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_metaverse != null)
                {
                    Private_metaverse.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_99
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_99 != null)
                {
                    return Private___intnl_UnityEngineTransform_99.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_99 != null)
                {
                    Private___intnl_UnityEngineTransform_99.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_98
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_98 != null)
                {
                    return Private___intnl_UnityEngineTransform_98.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_98 != null)
                {
                    Private___intnl_UnityEngineTransform_98.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_93
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_93 != null)
                {
                    return Private___intnl_UnityEngineTransform_93.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_93 != null)
                {
                    Private___intnl_UnityEngineTransform_93.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_92
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_92 != null)
                {
                    return Private___intnl_UnityEngineTransform_92.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_92 != null)
                {
                    Private___intnl_UnityEngineTransform_92.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_91
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_91 != null)
                {
                    return Private___intnl_UnityEngineTransform_91.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_91 != null)
                {
                    Private___intnl_UnityEngineTransform_91.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_90
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_90 != null)
                {
                    return Private___intnl_UnityEngineTransform_90.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_90 != null)
                {
                    Private___intnl_UnityEngineTransform_90.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_97
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_97 != null)
                {
                    return Private___intnl_UnityEngineTransform_97.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_97 != null)
                {
                    Private___intnl_UnityEngineTransform_97.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_96
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_96 != null)
                {
                    return Private___intnl_UnityEngineTransform_96.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_96 != null)
                {
                    Private___intnl_UnityEngineTransform_96.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_95
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_95 != null)
                {
                    return Private___intnl_UnityEngineTransform_95.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_95 != null)
                {
                    Private___intnl_UnityEngineTransform_95.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_94
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_94 != null)
                {
                    return Private___intnl_UnityEngineTransform_94.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_94 != null)
                {
                    Private___intnl_UnityEngineTransform_94.Value = value;
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

        internal int? physicsMode
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_physicsMode != null)
                {
                    return Private_physicsMode.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_physicsMode != null)
                    {
                        Private_physicsMode.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_162
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_162 != null)
                {
                    return Private___const_SystemString_162.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_162 != null)
                {
                    Private___const_SystemString_162.Value = value;
                }
            }
        }

        internal string __const_SystemString_172
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_172 != null)
                {
                    return Private___const_SystemString_172.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_172 != null)
                {
                    Private___const_SystemString_172.Value = value;
                }
            }
        }

        internal string __const_SystemString_142
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_142 != null)
                {
                    return Private___const_SystemString_142.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_142 != null)
                {
                    Private___const_SystemString_142.Value = value;
                }
            }
        }

        internal string __const_SystemString_152
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_152 != null)
                {
                    return Private___const_SystemString_152.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_152 != null)
                {
                    Private___const_SystemString_152.Value = value;
                }
            }
        }

        internal string __const_SystemString_122
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_122 != null)
                {
                    return Private___const_SystemString_122.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_122 != null)
                {
                    Private___const_SystemString_122.Value = value;
                }
            }
        }

        internal string __const_SystemString_132
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_132 != null)
                {
                    return Private___const_SystemString_132.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_132 != null)
                {
                    Private___const_SystemString_132.Value = value;
                }
            }
        }

        internal string __const_SystemString_102
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_102 != null)
                {
                    return Private___const_SystemString_102.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_102 != null)
                {
                    Private___const_SystemString_102.Value = value;
                }
            }
        }

        internal string __const_SystemString_112
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_112 != null)
                {
                    return Private___const_SystemString_112.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_112 != null)
                {
                    Private___const_SystemString_112.Value = value;
                }
            }
        }

        internal string __const_SystemString_182
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_182 != null)
                {
                    return Private___const_SystemString_182.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_182 != null)
                {
                    Private___const_SystemString_182.Value = value;
                }
            }
        }

        internal string __const_SystemString_192
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_192 != null)
                {
                    return Private___const_SystemString_192.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_192 != null)
                {
                    Private___const_SystemString_192.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] tables
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tables != null)
                {
                    return Private_tables.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tables != null)
                {
                    Private_tables.Value = value;
                }
            }
        }

        internal UnityEngine.MeshRenderer __lcl_renderer_UnityEngineMeshRenderer_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_renderer_UnityEngineMeshRenderer_0 != null)
                {
                    return Private___lcl_renderer_UnityEngineMeshRenderer_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_renderer_UnityEngineMeshRenderer_0 != null)
                {
                    Private___lcl_renderer_UnityEngineMeshRenderer_0.Value = value;
                }
            }
        }

        internal System.TimeSpan? __intnl_SystemTimeSpan_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemTimeSpan_0 != null)
                {
                    return Private___intnl_SystemTimeSpan_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemTimeSpan_0 != null)
                    {
                        Private___intnl_SystemTimeSpan_0.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_169
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_169 != null)
                {
                    return Private___const_SystemString_169.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_169 != null)
                {
                    Private___const_SystemString_169.Value = value;
                }
            }
        }

        internal string __const_SystemString_179
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_179 != null)
                {
                    return Private___const_SystemString_179.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_179 != null)
                {
                    Private___const_SystemString_179.Value = value;
                }
            }
        }

        internal string __const_SystemString_149
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_149 != null)
                {
                    return Private___const_SystemString_149.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_149 != null)
                {
                    Private___const_SystemString_149.Value = value;
                }
            }
        }

        internal string __const_SystemString_159
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_159 != null)
                {
                    return Private___const_SystemString_159.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_159 != null)
                {
                    Private___const_SystemString_159.Value = value;
                }
            }
        }

        internal string __const_SystemString_129
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_129 != null)
                {
                    return Private___const_SystemString_129.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_129 != null)
                {
                    Private___const_SystemString_129.Value = value;
                }
            }
        }

        internal string __const_SystemString_139
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_139 != null)
                {
                    return Private___const_SystemString_139.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_139 != null)
                {
                    Private___const_SystemString_139.Value = value;
                }
            }
        }

        internal string __const_SystemString_109
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_109 != null)
                {
                    return Private___const_SystemString_109.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_109 != null)
                {
                    Private___const_SystemString_109.Value = value;
                }
            }
        }

        internal string __const_SystemString_119
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_119 != null)
                {
                    return Private___const_SystemString_119.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_119 != null)
                {
                    Private___const_SystemString_119.Value = value;
                }
            }
        }

        internal string __const_SystemString_189
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_189 != null)
                {
                    return Private___const_SystemString_189.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_189 != null)
                {
                    Private___const_SystemString_189.Value = value;
                }
            }
        }

        internal string __const_SystemString_199
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_199 != null)
                {
                    return Private___const_SystemString_199.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_199 != null)
                {
                    Private___const_SystemString_199.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour modModule
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_modModule != null)
                {
                    return Private_modModule.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_modModule != null)
                {
                    Private_modModule.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __lcl_saoTableSettings_UnityEngineTransform_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_saoTableSettings_UnityEngineTransform_0 != null)
                {
                    return Private___lcl_saoTableSettings_UnityEngineTransform_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_saoTableSettings_UnityEngineTransform_0 != null)
                {
                    Private___lcl_saoTableSettings_UnityEngineTransform_0.Value = value;
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

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_7 != null)
                {
                    return Private___intnl_SystemObject_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_7 != null)
                {
                    Private___intnl_SystemObject_7.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject toaster
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_toaster != null)
                {
                    return Private_toaster.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_toaster != null)
                {
                    Private_toaster.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_31
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_31 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_31.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_31 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_31.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_30
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_30 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_30.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_30 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_30.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_33
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_33 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_33.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_33 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_33.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_32 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_32 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_32.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_35
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_35 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_35.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_35 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_35.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_34
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_34 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_34.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_34 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_34.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_37
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_37 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_37.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_37 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_37.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_36
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_36 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_36.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_36 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_36.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_39
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_39 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_39.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_39 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_39.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_38
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_38 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_38.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_38 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_38.Value = value;
                }
            }
        }

        internal string __const_SystemString_260
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_260 != null)
                {
                    return Private___const_SystemString_260.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_260 != null)
                {
                    Private___const_SystemString_260.Value = value;
                }
            }
        }

        internal string __const_SystemString_240
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_240 != null)
                {
                    return Private___const_SystemString_240.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_240 != null)
                {
                    Private___const_SystemString_240.Value = value;
                }
            }
        }

        internal string __const_SystemString_250
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_250 != null)
                {
                    return Private___const_SystemString_250.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_250 != null)
                {
                    Private___const_SystemString_250.Value = value;
                }
            }
        }

        internal string __const_SystemString_220
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_220 != null)
                {
                    return Private___const_SystemString_220.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_220 != null)
                {
                    Private___const_SystemString_220.Value = value;
                }
            }
        }

        internal string __const_SystemString_230
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_230 != null)
                {
                    return Private___const_SystemString_230.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_230 != null)
                {
                    Private___const_SystemString_230.Value = value;
                }
            }
        }

        internal string __const_SystemString_200
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_200 != null)
                {
                    return Private___const_SystemString_200.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_200 != null)
                {
                    Private___const_SystemString_200.Value = value;
                }
            }
        }

        internal string __const_SystemString_210
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_210 != null)
                {
                    return Private___const_SystemString_210.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_210 != null)
                {
                    Private___const_SystemString_210.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_19 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_19 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_19.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_2 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_2 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_2.Value = value;
                }
            }
        }

        internal UnityEngine.Color? SAO_COLOR_ENABLED
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_SAO_COLOR_ENABLED != null)
                {
                    return Private_SAO_COLOR_ENABLED.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_SAO_COLOR_ENABLED != null)
                    {
                        Private_SAO_COLOR_ENABLED.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __1_active__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_active__param != null)
                {
                    return Private___1_active__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_active__param != null)
                    {
                        Private___1_active__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_5 != null)
                {
                    return Private___intnl_UnityEngineTransform_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_5 != null)
                {
                    Private___intnl_UnityEngineTransform_5.Value = value;
                }
            }
        }

        internal int? inSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inSkin != null)
                {
                    return Private_inSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inSkin != null)
                    {
                        Private_inSkin.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __intnl_UnityEngineColor_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_5 != null)
                {
                    return Private___intnl_UnityEngineColor_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_5 != null)
                    {
                        Private___intnl_UnityEngineColor_5.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour decoder
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_decoder != null)
                {
                    return Private_decoder.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_decoder != null)
                {
                    Private_decoder.Value = value;
                }
            }
        }

        internal string __2_owner__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_owner__param != null)
                {
                    return Private___2_owner__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_owner__param != null)
                {
                    Private___2_owner__param.Value = value;
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

        internal float? __4_value__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_value__param != null)
                {
                    return Private___4_value__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_value__param != null)
                    {
                        Private___4_value__param.Value = value.Value;
                    }
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

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_19 != null)
                {
                    return Private___intnl_UnityEngineTransform_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_19 != null)
                {
                    Private___intnl_UnityEngineTransform_19.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_18 != null)
                {
                    return Private___intnl_UnityEngineTransform_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_18 != null)
                {
                    Private___intnl_UnityEngineTransform_18.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_13 != null)
                {
                    return Private___intnl_UnityEngineTransform_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_13 != null)
                {
                    Private___intnl_UnityEngineTransform_13.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_12 != null)
                {
                    return Private___intnl_UnityEngineTransform_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_12 != null)
                {
                    Private___intnl_UnityEngineTransform_12.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_11 != null)
                {
                    return Private___intnl_UnityEngineTransform_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_11 != null)
                {
                    Private___intnl_UnityEngineTransform_11.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_10 != null)
                {
                    return Private___intnl_UnityEngineTransform_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_10 != null)
                {
                    Private___intnl_UnityEngineTransform_10.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_17 != null)
                {
                    return Private___intnl_UnityEngineTransform_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_17 != null)
                {
                    Private___intnl_UnityEngineTransform_17.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_16 != null)
                {
                    return Private___intnl_UnityEngineTransform_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_16 != null)
                {
                    Private___intnl_UnityEngineTransform_16.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_15 != null)
                {
                    return Private___intnl_UnityEngineTransform_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_15 != null)
                {
                    Private___intnl_UnityEngineTransform_15.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_14 != null)
                {
                    return Private___intnl_UnityEngineTransform_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_14 != null)
                {
                    Private___intnl_UnityEngineTransform_14.Value = value;
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_94
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_94 != null)
                {
                    return Private___gintnl_SystemUInt32_94.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_94 != null)
                    {
                        Private___gintnl_SystemUInt32_94.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_84
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_84 != null)
                {
                    return Private___gintnl_SystemUInt32_84.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_84 != null)
                    {
                        Private___gintnl_SystemUInt32_84.Value = value.Value;
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

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_122
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_122 != null)
                {
                    return Private___intnl_UnityEngineTransform_122.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_122 != null)
                {
                    Private___intnl_UnityEngineTransform_122.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_112
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_112 != null)
                {
                    return Private___intnl_UnityEngineTransform_112.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_112 != null)
                {
                    Private___intnl_UnityEngineTransform_112.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_102
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_102 != null)
                {
                    return Private___intnl_UnityEngineTransform_102.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_102 != null)
                {
                    Private___intnl_UnityEngineTransform_102.Value = value;
                }
            }
        }

        internal bool? outSuccessful
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outSuccessful != null)
                {
                    return Private_outSuccessful.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_outSuccessful != null)
                    {
                        Private_outSuccessful.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_129
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_129 != null)
                {
                    return Private___intnl_UnityEngineTransform_129.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_129 != null)
                {
                    Private___intnl_UnityEngineTransform_129.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_119
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_119 != null)
                {
                    return Private___intnl_UnityEngineTransform_119.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_119 != null)
                {
                    Private___intnl_UnityEngineTransform_119.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_109
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_109 != null)
                {
                    return Private___intnl_UnityEngineTransform_109.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_109 != null)
                {
                    Private___intnl_UnityEngineTransform_109.Value = value;
                }
            }
        }

        internal string __const_SystemString_161
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_161 != null)
                {
                    return Private___const_SystemString_161.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_161 != null)
                {
                    Private___const_SystemString_161.Value = value;
                }
            }
        }

        internal string __const_SystemString_171
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_171 != null)
                {
                    return Private___const_SystemString_171.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_171 != null)
                {
                    Private___const_SystemString_171.Value = value;
                }
            }
        }

        internal string __const_SystemString_141
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_141 != null)
                {
                    return Private___const_SystemString_141.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_141 != null)
                {
                    Private___const_SystemString_141.Value = value;
                }
            }
        }

        internal string __const_SystemString_151
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_151 != null)
                {
                    return Private___const_SystemString_151.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_151 != null)
                {
                    Private___const_SystemString_151.Value = value;
                }
            }
        }

        internal string __const_SystemString_121
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_121 != null)
                {
                    return Private___const_SystemString_121.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_121 != null)
                {
                    Private___const_SystemString_121.Value = value;
                }
            }
        }

        internal string __const_SystemString_131
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_131 != null)
                {
                    return Private___const_SystemString_131.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_131 != null)
                {
                    Private___const_SystemString_131.Value = value;
                }
            }
        }

        internal string __const_SystemString_101
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_101 != null)
                {
                    return Private___const_SystemString_101.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_101 != null)
                {
                    Private___const_SystemString_101.Value = value;
                }
            }
        }

        internal string __const_SystemString_111
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_111 != null)
                {
                    return Private___const_SystemString_111.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_111 != null)
                {
                    Private___const_SystemString_111.Value = value;
                }
            }
        }

        internal string __const_SystemString_181
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_181 != null)
                {
                    return Private___const_SystemString_181.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_181 != null)
                {
                    Private___const_SystemString_181.Value = value;
                }
            }
        }

        internal string __const_SystemString_191
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_191 != null)
                {
                    return Private___const_SystemString_191.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_191 != null)
                {
                    Private___const_SystemString_191.Value = value;
                }
            }
        }

        internal UnityEngine.Color? SAO_COLOR_DISABLED
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_SAO_COLOR_DISABLED != null)
                {
                    return Private_SAO_COLOR_DISABLED.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_SAO_COLOR_DISABLED != null)
                    {
                        Private_SAO_COLOR_DISABLED.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject[] props
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_props != null)
                {
                    return Private_props.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_props != null)
                {
                    Private_props.Value = value;
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

        internal string[] moderators
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_moderators != null)
                {
                    return Private_moderators.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_moderators != null)
                {
                    Private_moderators.Value = value;
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

        internal VRC.Udon.UdonBehaviour penModule
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_penModule != null)
                {
                    return Private_penModule.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_penModule != null)
                {
                    Private_penModule.Value = value;
                }
            }
        }

        internal System.Guid? __intnl_SystemGuid_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemGuid_0 != null)
                {
                    return Private___intnl_SystemGuid_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemGuid_0 != null)
                    {
                        Private___intnl_SystemGuid_0.Value = value.Value;
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

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_0 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_0 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_0.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __lcl_saoCueSkinsRoot_UnityEngineTransform_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_saoCueSkinsRoot_UnityEngineTransform_0 != null)
                {
                    return Private___lcl_saoCueSkinsRoot_UnityEngineTransform_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_saoCueSkinsRoot_UnityEngineTransform_0 != null)
                {
                    Private___lcl_saoCueSkinsRoot_UnityEngineTransform_0.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_2 != null)
                {
                    return Private___intnl_SystemObject_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_2 != null)
                {
                    Private___intnl_SystemObject_2.Value = value;
                }
            }
        }

        internal string __0___0_getNameColor__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_getNameColor__ret != null)
                {
                    return Private___0___0_getNameColor__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0___0_getNameColor__ret != null)
                {
                    Private___0___0_getNameColor__ret.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __lcl_objectsModule_VRCUdonUdonBehaviour_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_objectsModule_VRCUdonUdonBehaviour_0 != null)
                {
                    return Private___lcl_objectsModule_VRCUdonUdonBehaviour_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_objectsModule_VRCUdonUdonBehaviour_0 != null)
                {
                    Private___lcl_objectsModule_VRCUdonUdonBehaviour_0.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_41
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_41 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_41.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_41 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_41.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_40
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_40 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_40.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_40 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_40.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_43
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_43 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_43.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_43 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_43.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_42
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_42 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_42.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_42 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_42.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_45
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_45 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_45.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_45 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_45.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_44
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_44 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_44.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_44 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_44.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_47
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_47 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_47.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_47 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_47.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_46
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_46 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_46.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_46 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_46.Value = value;
                }
            }
        }

        internal string __const_SystemString_245
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_245 != null)
                {
                    return Private___const_SystemString_245.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_245 != null)
                {
                    Private___const_SystemString_245.Value = value;
                }
            }
        }

        internal string __const_SystemString_255
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_255 != null)
                {
                    return Private___const_SystemString_255.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_255 != null)
                {
                    Private___const_SystemString_255.Value = value;
                }
            }
        }

        internal string __const_SystemString_225
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_225 != null)
                {
                    return Private___const_SystemString_225.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_225 != null)
                {
                    Private___const_SystemString_225.Value = value;
                }
            }
        }

        internal string __const_SystemString_235
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_235 != null)
                {
                    return Private___const_SystemString_235.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_235 != null)
                {
                    Private___const_SystemString_235.Value = value;
                }
            }
        }

        internal string __const_SystemString_205
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_205 != null)
                {
                    return Private___const_SystemString_205.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_205 != null)
                {
                    Private___const_SystemString_205.Value = value;
                }
            }
        }

        internal string __const_SystemString_215
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_215 != null)
                {
                    return Private___const_SystemString_215.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_215 != null)
                {
                    Private___const_SystemString_215.Value = value;
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

        internal bool? __intnl_SystemBoolean_121
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_121 != null)
                {
                    return Private___intnl_SystemBoolean_121.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_121 != null)
                    {
                        Private___intnl_SystemBoolean_121.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_120
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_120 != null)
                {
                    return Private___intnl_SystemBoolean_120.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_120 != null)
                    {
                        Private___intnl_SystemBoolean_120.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_123
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_123 != null)
                {
                    return Private___intnl_SystemBoolean_123.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_123 != null)
                    {
                        Private___intnl_SystemBoolean_123.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_122
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_122 != null)
                {
                    return Private___intnl_SystemBoolean_122.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_122 != null)
                    {
                        Private___intnl_SystemBoolean_122.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_125
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_125 != null)
                {
                    return Private___intnl_SystemBoolean_125.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_125 != null)
                    {
                        Private___intnl_SystemBoolean_125.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_124
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_124 != null)
                {
                    return Private___intnl_SystemBoolean_124.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_124 != null)
                    {
                        Private___intnl_SystemBoolean_124.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_127
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_127 != null)
                {
                    return Private___intnl_SystemBoolean_127.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_127 != null)
                    {
                        Private___intnl_SystemBoolean_127.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_126
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_126 != null)
                {
                    return Private___intnl_SystemBoolean_126.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_126 != null)
                    {
                        Private___intnl_SystemBoolean_126.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_2 != null)
                {
                    return Private___intnl_UnityEngineTransform_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_2 != null)
                {
                    Private___intnl_UnityEngineTransform_2.Value = value;
                }
            }
        }

        internal UnityEngine.Texture2D __intnl_UnityEngineTexture_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTexture_0 != null)
                {
                    return Private___intnl_UnityEngineTexture_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTexture_0 != null)
                {
                    Private___intnl_UnityEngineTexture_0.Value = value;
                }
            }
        }

        internal System.DateTime? __0_tournament__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_tournament__param != null)
                {
                    return Private___0_tournament__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_tournament__param != null)
                    {
                        Private___0_tournament__param.Value = value.Value;
                    }
                }
            }
        }

        internal char[] __gintnl_SystemCharArray_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemCharArray_4 != null)
                {
                    return Private___gintnl_SystemCharArray_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemCharArray_4 != null)
                {
                    Private___gintnl_SystemCharArray_4.Value = value;
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

        internal UnityEngine.Color? __intnl_UnityEngineColor_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_0 != null)
                {
                    return Private___intnl_UnityEngineColor_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_0 != null)
                    {
                        Private___intnl_UnityEngineColor_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? shouldBlahaj
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_shouldBlahaj != null)
                {
                    return Private_shouldBlahaj.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_shouldBlahaj != null)
                    {
                        Private_shouldBlahaj.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI saoToggleProps
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoToggleProps != null)
                {
                    return Private_saoToggleProps.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoToggleProps != null)
                {
                    Private_saoToggleProps.Value = value;
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

        internal TMPro.TextMeshProUGUI[] saoCueSkins
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoCueSkins != null)
                {
                    return Private_saoCueSkins.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoCueSkins != null)
                {
                    Private_saoCueSkins.Value = value;
                }
            }
        }

        internal bool? __0_active__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_active__param != null)
                {
                    return Private___0_active__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_active__param != null)
                    {
                        Private___0_active__param.Value = value.Value;
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

        internal int? __lcl_playerId_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_playerId_SystemInt32_0 != null)
                {
                    return Private___lcl_playerId_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_playerId_SystemInt32_0 != null)
                    {
                        Private___lcl_playerId_SystemInt32_0.Value = value.Value;
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

        internal float? __lcl_hours_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_hours_SystemSingle_0 != null)
                {
                    return Private___lcl_hours_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_hours_SystemSingle_0 != null)
                    {
                        Private___lcl_hours_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __intnl_UnityEngineComponentArray_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponentArray_1 != null)
                {
                    return Private___intnl_UnityEngineComponentArray_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponentArray_1 != null)
                {
                    Private___intnl_UnityEngineComponentArray_1.Value = value;
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

        internal UnityEngine.RectTransform __lcl_saoCamerasRoot_UnityEngineTransform_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_saoCamerasRoot_UnityEngineTransform_0 != null)
                {
                    return Private___lcl_saoCamerasRoot_UnityEngineTransform_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_saoCamerasRoot_UnityEngineTransform_0 != null)
                {
                    Private___lcl_saoCamerasRoot_UnityEngineTransform_0.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_131
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_131 != null)
                {
                    return Private___intnl_UnityEngineTransform_131.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_131 != null)
                {
                    Private___intnl_UnityEngineTransform_131.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_121
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_121 != null)
                {
                    return Private___intnl_UnityEngineTransform_121.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_121 != null)
                {
                    Private___intnl_UnityEngineTransform_121.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_111
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_111 != null)
                {
                    return Private___intnl_UnityEngineTransform_111.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_111 != null)
                {
                    Private___intnl_UnityEngineTransform_111.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_101
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_101 != null)
                {
                    return Private___intnl_UnityEngineTransform_101.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_101 != null)
                {
                    Private___intnl_UnityEngineTransform_101.Value = value;
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

        internal UnityEngine.Color? SAO_COLOR_LOCKED
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_SAO_COLOR_LOCKED != null)
                {
                    return Private_SAO_COLOR_LOCKED.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_SAO_COLOR_LOCKED != null)
                    {
                        Private_SAO_COLOR_LOCKED.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_164
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_164 != null)
                {
                    return Private___const_SystemString_164.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_164 != null)
                {
                    Private___const_SystemString_164.Value = value;
                }
            }
        }

        internal string __const_SystemString_174
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_174 != null)
                {
                    return Private___const_SystemString_174.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_174 != null)
                {
                    Private___const_SystemString_174.Value = value;
                }
            }
        }

        internal string __const_SystemString_144
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_144 != null)
                {
                    return Private___const_SystemString_144.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_144 != null)
                {
                    Private___const_SystemString_144.Value = value;
                }
            }
        }

        internal string __const_SystemString_154
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_154 != null)
                {
                    return Private___const_SystemString_154.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_154 != null)
                {
                    Private___const_SystemString_154.Value = value;
                }
            }
        }

        internal string __const_SystemString_124
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_124 != null)
                {
                    return Private___const_SystemString_124.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_124 != null)
                {
                    Private___const_SystemString_124.Value = value;
                }
            }
        }

        internal string __const_SystemString_134
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_134 != null)
                {
                    return Private___const_SystemString_134.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_134 != null)
                {
                    Private___const_SystemString_134.Value = value;
                }
            }
        }

        internal string __const_SystemString_104
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_104 != null)
                {
                    return Private___const_SystemString_104.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_104 != null)
                {
                    Private___const_SystemString_104.Value = value;
                }
            }
        }

        internal string __const_SystemString_114
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_114 != null)
                {
                    return Private___const_SystemString_114.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_114 != null)
                {
                    Private___const_SystemString_114.Value = value;
                }
            }
        }

        internal string __const_SystemString_184
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_184 != null)
                {
                    return Private___const_SystemString_184.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_184 != null)
                {
                    Private___const_SystemString_184.Value = value;
                }
            }
        }

        internal string __const_SystemString_194
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_194 != null)
                {
                    return Private___const_SystemString_194.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_194 != null)
                {
                    Private___const_SystemString_194.Value = value;
                }
            }
        }

        internal int? activeYoutubeSearchAttempts
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_activeYoutubeSearchAttempts != null)
                {
                    return Private_activeYoutubeSearchAttempts.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_activeYoutubeSearchAttempts != null)
                    {
                        Private_activeYoutubeSearchAttempts.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_8 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_8 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_8.Value = value;
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

        internal UnityEngine.Material[] __intnl_UnityEngineMaterialArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineMaterialArray_0 != null)
                {
                    return Private___intnl_UnityEngineMaterialArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineMaterialArray_0 != null)
                {
                    Private___intnl_UnityEngineMaterialArray_0.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour worldUpdate
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_worldUpdate != null)
                {
                    return Private_worldUpdate.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_worldUpdate != null)
                {
                    Private_worldUpdate.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_5 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_5 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_5.Value = value;
                }
            }
        }

        internal char? __const_SystemChar_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemChar_1 != null)
                {
                    return Private___const_SystemChar_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemChar_1 != null)
                    {
                        Private___const_SystemChar_1.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_1
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

        internal string inOwner
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inOwner != null)
                {
                    return Private_inOwner.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_inOwner != null)
                {
                    Private_inOwner.Value = value;
                }
            }
        }

        internal System.Object[] cueSkinAllowed
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cueSkinAllowed != null)
                {
                    return Private_cueSkinAllowed.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cueSkinAllowed != null)
                {
                    Private_cueSkinAllowed.Value = value;
                }
            }
        }

        internal string __const_SystemString_246
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_246 != null)
                {
                    return Private___const_SystemString_246.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_246 != null)
                {
                    Private___const_SystemString_246.Value = value;
                }
            }
        }

        internal string __const_SystemString_256
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_256 != null)
                {
                    return Private___const_SystemString_256.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_256 != null)
                {
                    Private___const_SystemString_256.Value = value;
                }
            }
        }

        internal string __const_SystemString_226
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_226 != null)
                {
                    return Private___const_SystemString_226.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_226 != null)
                {
                    Private___const_SystemString_226.Value = value;
                }
            }
        }

        internal string __const_SystemString_236
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_236 != null)
                {
                    return Private___const_SystemString_236.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_236 != null)
                {
                    Private___const_SystemString_236.Value = value;
                }
            }
        }

        internal string __const_SystemString_206
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_206 != null)
                {
                    return Private___const_SystemString_206.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_206 != null)
                {
                    Private___const_SystemString_206.Value = value;
                }
            }
        }

        internal string __const_SystemString_216
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_216 != null)
                {
                    return Private___const_SystemString_216.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_216 != null)
                {
                    Private___const_SystemString_216.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour nameColorMap
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_nameColorMap != null)
                {
                    return Private_nameColorMap.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_nameColorMap != null)
                {
                    Private_nameColorMap.Value = value;
                }
            }
        }

        internal bool? propsEnabled
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_propsEnabled != null)
                {
                    return Private_propsEnabled.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_propsEnabled != null)
                    {
                        Private_propsEnabled.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0___0_isTournamentRunning__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_isTournamentRunning__ret != null)
                {
                    return Private___0___0_isTournamentRunning__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_isTournamentRunning__ret != null)
                    {
                        Private___0___0_isTournamentRunning__ret.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __intnl_UnityEngineColor_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_8 != null)
                {
                    return Private___intnl_UnityEngineColor_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_8 != null)
                    {
                        Private___intnl_UnityEngineColor_8.Value = value.Value;
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

        internal int? __0_skin__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_skin__param != null)
                {
                    return Private___0_skin__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_skin__param != null)
                    {
                        Private___0_skin__param.Value = value.Value;
                    }
                }
            }
        }

        internal char[] __gintnl_SystemCharArray_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemCharArray_3 != null)
                {
                    return Private___gintnl_SystemCharArray_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemCharArray_3 != null)
                {
                    Private___gintnl_SystemCharArray_3.Value = value;
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

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_69
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_69 != null)
                {
                    return Private___intnl_UnityEngineTransform_69.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_69 != null)
                {
                    Private___intnl_UnityEngineTransform_69.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_68
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_68 != null)
                {
                    return Private___intnl_UnityEngineTransform_68.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_68 != null)
                {
                    Private___intnl_UnityEngineTransform_68.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_63
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_63 != null)
                {
                    return Private___intnl_UnityEngineTransform_63.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_63 != null)
                {
                    Private___intnl_UnityEngineTransform_63.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_62
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_62 != null)
                {
                    return Private___intnl_UnityEngineTransform_62.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_62 != null)
                {
                    Private___intnl_UnityEngineTransform_62.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_61
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_61 != null)
                {
                    return Private___intnl_UnityEngineTransform_61.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_61 != null)
                {
                    Private___intnl_UnityEngineTransform_61.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_60
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_60 != null)
                {
                    return Private___intnl_UnityEngineTransform_60.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_60 != null)
                {
                    Private___intnl_UnityEngineTransform_60.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_67
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_67 != null)
                {
                    return Private___intnl_UnityEngineTransform_67.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_67 != null)
                {
                    Private___intnl_UnityEngineTransform_67.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_66
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_66 != null)
                {
                    return Private___intnl_UnityEngineTransform_66.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_66 != null)
                {
                    Private___intnl_UnityEngineTransform_66.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_65
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_65 != null)
                {
                    return Private___intnl_UnityEngineTransform_65.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_65 != null)
                {
                    Private___intnl_UnityEngineTransform_65.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_64 != null)
                {
                    return Private___intnl_UnityEngineTransform_64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_64 != null)
                {
                    Private___intnl_UnityEngineTransform_64.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __lcl_saoPlayerSettings_UnityEngineTransform_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_saoPlayerSettings_UnityEngineTransform_0 != null)
                {
                    return Private___lcl_saoPlayerSettings_UnityEngineTransform_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_saoPlayerSettings_UnityEngineTransform_0 != null)
                {
                    Private___lcl_saoPlayerSettings_UnityEngineTransform_0.Value = value;
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_91
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_91 != null)
                {
                    return Private___gintnl_SystemUInt32_91.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_91 != null)
                    {
                        Private___gintnl_SystemUInt32_91.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_81
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_81 != null)
                {
                    return Private___gintnl_SystemUInt32_81.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_81 != null)
                    {
                        Private___gintnl_SystemUInt32_81.Value = value.Value;
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

        internal float? __3_value__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_value__param != null)
                {
                    return Private___3_value__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_value__param != null)
                    {
                        Private___3_value__param.Value = value.Value;
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

        internal UnityEngine.GameObject popcat
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_popcat != null)
                {
                    return Private_popcat.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_popcat != null)
                {
                    Private_popcat.Value = value;
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

        internal VRC.Udon.UdonBehaviour chat
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_chat != null)
                {
                    return Private_chat.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_chat != null)
                {
                    Private_chat.Value = value;
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

        internal UnityEngine.UI.Slider saoRunSpeedSlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoRunSpeedSlider != null)
                {
                    return Private_saoRunSpeedSlider.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoRunSpeedSlider != null)
                {
                    Private_saoRunSpeedSlider.Value = value;
                }
            }
        }

        internal string VERSION
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_VERSION != null)
                {
                    return Private_VERSION.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_VERSION != null)
                {
                    Private_VERSION.Value = value;
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

        internal UnityEngine.UI.InputField saoSaveLoadInput
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoSaveLoadInput != null)
                {
                    return Private_saoSaveLoadInput.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoSaveLoadInput != null)
                {
                    Private_saoSaveLoadInput.Value = value;
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

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_11 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_11 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_11.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_10 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_10 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_10.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_13 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_13 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_13.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_12 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_12 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_12.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_15 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_15 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_15.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_14 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_14 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_14.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_17 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_17 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_17.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_16 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_16 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_16.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_19 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_19 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_19.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_18 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_18 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_18.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_38
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_38 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_38.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_38 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_38.Value = value;
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

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_6 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_6 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_6.Value = value;
                }
            }
        }

        internal System.DateTime? __lcl_utcNow_SystemDateTime_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_utcNow_SystemDateTime_0 != null)
                {
                    return Private___lcl_utcNow_SystemDateTime_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_utcNow_SystemDateTime_0 != null)
                    {
                        Private___lcl_utcNow_SystemDateTime_0.Value = value.Value;
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

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_7 != null)
                {
                    return Private___intnl_UnityEngineTransform_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_7 != null)
                {
                    Private___intnl_UnityEngineTransform_7.Value = value;
                }
            }
        }

        internal UnityEngine.Color? __intnl_UnityEngineColor_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_10 != null)
                {
                    return Private___intnl_UnityEngineColor_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_10 != null)
                    {
                        Private___intnl_UnityEngineColor_10.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __intnl_UnityEngineColor_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_7 != null)
                {
                    return Private___intnl_UnityEngineColor_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_7 != null)
                    {
                        Private___intnl_UnityEngineColor_7.Value = value.Value;
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

        internal uint? __gintnl_SystemUInt32_99
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_99 != null)
                {
                    return Private___gintnl_SystemUInt32_99.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_99 != null)
                    {
                        Private___gintnl_SystemUInt32_99.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_89
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_89 != null)
                {
                    return Private___gintnl_SystemUInt32_89.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_89 != null)
                    {
                        Private___gintnl_SystemUInt32_89.Value = value.Value;
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

        internal uint? __gintnl_SystemUInt32_79
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_79 != null)
                {
                    return Private___gintnl_SystemUInt32_79.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_79 != null)
                    {
                        Private___gintnl_SystemUInt32_79.Value = value.Value;
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

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_39
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_39 != null)
                {
                    return Private___intnl_UnityEngineTransform_39.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_39 != null)
                {
                    Private___intnl_UnityEngineTransform_39.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_38
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_38 != null)
                {
                    return Private___intnl_UnityEngineTransform_38.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_38 != null)
                {
                    Private___intnl_UnityEngineTransform_38.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_33
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_33 != null)
                {
                    return Private___intnl_UnityEngineTransform_33.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_33 != null)
                {
                    Private___intnl_UnityEngineTransform_33.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_32 != null)
                {
                    return Private___intnl_UnityEngineTransform_32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_32 != null)
                {
                    Private___intnl_UnityEngineTransform_32.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_31
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_31 != null)
                {
                    return Private___intnl_UnityEngineTransform_31.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_31 != null)
                {
                    Private___intnl_UnityEngineTransform_31.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_30
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_30 != null)
                {
                    return Private___intnl_UnityEngineTransform_30.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_30 != null)
                {
                    Private___intnl_UnityEngineTransform_30.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_37
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_37 != null)
                {
                    return Private___intnl_UnityEngineTransform_37.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_37 != null)
                {
                    Private___intnl_UnityEngineTransform_37.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_36
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_36 != null)
                {
                    return Private___intnl_UnityEngineTransform_36.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_36 != null)
                {
                    Private___intnl_UnityEngineTransform_36.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_35
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_35 != null)
                {
                    return Private___intnl_UnityEngineTransform_35.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_35 != null)
                {
                    Private___intnl_UnityEngineTransform_35.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_34
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_34 != null)
                {
                    return Private___intnl_UnityEngineTransform_34.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_34 != null)
                {
                    Private___intnl_UnityEngineTransform_34.Value = value;
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

        internal int? __0_physicsMode___param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_physicsMode___param != null)
                {
                    return Private___0_physicsMode___param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_physicsMode___param != null)
                    {
                        Private___0_physicsMode___param.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_92
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_92 != null)
                {
                    return Private___gintnl_SystemUInt32_92.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_92 != null)
                    {
                        Private___gintnl_SystemUInt32_92.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_82
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_82 != null)
                {
                    return Private___gintnl_SystemUInt32_82.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_82 != null)
                    {
                        Private___gintnl_SystemUInt32_82.Value = value.Value;
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

        internal UnityEngine.UI.Slider saoWalkSpeedSlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoWalkSpeedSlider != null)
                {
                    return Private_saoWalkSpeedSlider.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoWalkSpeedSlider != null)
                {
                    Private_saoWalkSpeedSlider.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_124
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_124 != null)
                {
                    return Private___intnl_UnityEngineTransform_124.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_124 != null)
                {
                    Private___intnl_UnityEngineTransform_124.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_114
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_114 != null)
                {
                    return Private___intnl_UnityEngineTransform_114.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_114 != null)
                {
                    Private___intnl_UnityEngineTransform_114.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_104
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_104 != null)
                {
                    return Private___intnl_UnityEngineTransform_104.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_104 != null)
                {
                    Private___intnl_UnityEngineTransform_104.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_89
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_89 != null)
                {
                    return Private___intnl_UnityEngineTransform_89.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_89 != null)
                {
                    Private___intnl_UnityEngineTransform_89.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_88
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_88 != null)
                {
                    return Private___intnl_UnityEngineTransform_88.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_88 != null)
                {
                    Private___intnl_UnityEngineTransform_88.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_83
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_83 != null)
                {
                    return Private___intnl_UnityEngineTransform_83.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_83 != null)
                {
                    Private___intnl_UnityEngineTransform_83.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_82
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_82 != null)
                {
                    return Private___intnl_UnityEngineTransform_82.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_82 != null)
                {
                    Private___intnl_UnityEngineTransform_82.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_81
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_81 != null)
                {
                    return Private___intnl_UnityEngineTransform_81.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_81 != null)
                {
                    Private___intnl_UnityEngineTransform_81.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_80
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_80 != null)
                {
                    return Private___intnl_UnityEngineTransform_80.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_80 != null)
                {
                    Private___intnl_UnityEngineTransform_80.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_87
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_87 != null)
                {
                    return Private___intnl_UnityEngineTransform_87.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_87 != null)
                {
                    Private___intnl_UnityEngineTransform_87.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_86
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_86 != null)
                {
                    return Private___intnl_UnityEngineTransform_86.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_86 != null)
                {
                    Private___intnl_UnityEngineTransform_86.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_85
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_85 != null)
                {
                    return Private___intnl_UnityEngineTransform_85.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_85 != null)
                {
                    Private___intnl_UnityEngineTransform_85.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_84
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_84 != null)
                {
                    return Private___intnl_UnityEngineTransform_84.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_84 != null)
                {
                    Private___intnl_UnityEngineTransform_84.Value = value;
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

        internal bool? shouldPing
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_shouldPing != null)
                {
                    return Private_shouldPing.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_shouldPing != null)
                    {
                        Private_shouldPing.Value = value.Value;
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

        internal string __const_SystemString_163
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_163 != null)
                {
                    return Private___const_SystemString_163.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_163 != null)
                {
                    Private___const_SystemString_163.Value = value;
                }
            }
        }

        internal string __const_SystemString_173
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_173 != null)
                {
                    return Private___const_SystemString_173.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_173 != null)
                {
                    Private___const_SystemString_173.Value = value;
                }
            }
        }

        internal string __const_SystemString_143
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_143 != null)
                {
                    return Private___const_SystemString_143.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_143 != null)
                {
                    Private___const_SystemString_143.Value = value;
                }
            }
        }

        internal string __const_SystemString_153
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_153 != null)
                {
                    return Private___const_SystemString_153.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_153 != null)
                {
                    Private___const_SystemString_153.Value = value;
                }
            }
        }

        internal string __const_SystemString_123
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_123 != null)
                {
                    return Private___const_SystemString_123.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_123 != null)
                {
                    Private___const_SystemString_123.Value = value;
                }
            }
        }

        internal string __const_SystemString_133
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_133 != null)
                {
                    return Private___const_SystemString_133.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_133 != null)
                {
                    Private___const_SystemString_133.Value = value;
                }
            }
        }

        internal string __const_SystemString_103
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_103 != null)
                {
                    return Private___const_SystemString_103.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_103 != null)
                {
                    Private___const_SystemString_103.Value = value;
                }
            }
        }

        internal string __const_SystemString_113
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_113 != null)
                {
                    return Private___const_SystemString_113.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_113 != null)
                {
                    Private___const_SystemString_113.Value = value;
                }
            }
        }

        internal string __const_SystemString_183
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_183 != null)
                {
                    return Private___const_SystemString_183.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_183 != null)
                {
                    Private___const_SystemString_183.Value = value;
                }
            }
        }

        internal string __const_SystemString_193
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_193 != null)
                {
                    return Private___const_SystemString_193.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_193 != null)
                {
                    Private___const_SystemString_193.Value = value;
                }
            }
        }

        internal int? inLocalVersion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inLocalVersion != null)
                {
                    return Private_inLocalVersion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inLocalVersion != null)
                    {
                        Private_inLocalVersion.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_4 != null)
                {
                    return Private___intnl_SystemObject_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_4 != null)
                {
                    Private___intnl_SystemObject_4.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI saoTogglePens
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoTogglePens != null)
                {
                    return Private_saoTogglePens.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoTogglePens != null)
                {
                    Private_saoTogglePens.Value = value;
                }
            }
        }

        internal System.DateTime? tournamentDate
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tournamentDate != null)
                {
                    return Private_tournamentDate.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_tournamentDate != null)
                    {
                        Private_tournamentDate.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_21 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_21 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_21.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_20 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_20 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_20.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_23 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_23 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_23.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_22 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_22 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_22.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_25 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_25 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_25.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_24
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_24 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_24.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_24 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_24.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_27
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_27 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_27.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_27 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_27.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_26
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_26 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_26.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_26 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_26.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_29
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_29 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_29.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_29 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_29.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_28
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_28 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_28.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_28 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_28.Value = value;
                }
            }
        }

        internal string __const_SystemString_263
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_263 != null)
                {
                    return Private___const_SystemString_263.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_263 != null)
                {
                    Private___const_SystemString_263.Value = value;
                }
            }
        }

        internal string __const_SystemString_243
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_243 != null)
                {
                    return Private___const_SystemString_243.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_243 != null)
                {
                    Private___const_SystemString_243.Value = value;
                }
            }
        }

        internal string __const_SystemString_253
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_253 != null)
                {
                    return Private___const_SystemString_253.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_253 != null)
                {
                    Private___const_SystemString_253.Value = value;
                }
            }
        }

        internal string __const_SystemString_223
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_223 != null)
                {
                    return Private___const_SystemString_223.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_223 != null)
                {
                    Private___const_SystemString_223.Value = value;
                }
            }
        }

        internal string __const_SystemString_233
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_233 != null)
                {
                    return Private___const_SystemString_233.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_233 != null)
                {
                    Private___const_SystemString_233.Value = value;
                }
            }
        }

        internal string __const_SystemString_203
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_203 != null)
                {
                    return Private___const_SystemString_203.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_203 != null)
                {
                    Private___const_SystemString_203.Value = value;
                }
            }
        }

        internal string __const_SystemString_213
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_213 != null)
                {
                    return Private___const_SystemString_213.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_213 != null)
                {
                    Private___const_SystemString_213.Value = value;
                }
            }
        }

        internal bool? shouldToaster
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_shouldToaster != null)
                {
                    return Private_shouldToaster.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_shouldToaster != null)
                    {
                        Private_shouldToaster.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Space? __const_UnityEngineSpace_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_UnityEngineSpace_0 != null)
                {
                    return Private___const_UnityEngineSpace_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_UnityEngineSpace_0 != null)
                    {
                        Private___const_UnityEngineSpace_0.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_3 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_3 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_3.Value = value;
                }
            }
        }

        internal bool? __intnl_SystemBoolean_109
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_109 != null)
                {
                    return Private___intnl_SystemBoolean_109.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_109 != null)
                    {
                        Private___intnl_SystemBoolean_109.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_108
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_108 != null)
                {
                    return Private___intnl_SystemBoolean_108.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_108 != null)
                    {
                        Private___intnl_SystemBoolean_108.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_101
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_101 != null)
                {
                    return Private___intnl_SystemBoolean_101.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_101 != null)
                    {
                        Private___intnl_SystemBoolean_101.Value = value.Value;
                    }
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

        internal bool? __intnl_SystemBoolean_103
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_103 != null)
                {
                    return Private___intnl_SystemBoolean_103.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_103 != null)
                    {
                        Private___intnl_SystemBoolean_103.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_102
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_102 != null)
                {
                    return Private___intnl_SystemBoolean_102.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_102 != null)
                    {
                        Private___intnl_SystemBoolean_102.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_105
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_105 != null)
                {
                    return Private___intnl_SystemBoolean_105.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_105 != null)
                    {
                        Private___intnl_SystemBoolean_105.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_104
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_104 != null)
                {
                    return Private___intnl_SystemBoolean_104.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_104 != null)
                    {
                        Private___intnl_SystemBoolean_104.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_107
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_107 != null)
                {
                    return Private___intnl_SystemBoolean_107.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_107 != null)
                    {
                        Private___intnl_SystemBoolean_107.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_106
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_106 != null)
                {
                    return Private___intnl_SystemBoolean_106.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_106 != null)
                    {
                        Private___intnl_SystemBoolean_106.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_4 != null)
                {
                    return Private___intnl_UnityEngineTransform_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_4 != null)
                {
                    Private___intnl_UnityEngineTransform_4.Value = value;
                }
            }
        }

        internal bool? __0___0_canUseTableSkin__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_canUseTableSkin__ret != null)
                {
                    return Private___0___0_canUseTableSkin__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_canUseTableSkin__ret != null)
                    {
                        Private___0___0_canUseTableSkin__ret.Value = value.Value;
                    }
                }
            }
        }

        internal char[] __gintnl_SystemCharArray_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemCharArray_6 != null)
                {
                    return Private___gintnl_SystemCharArray_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemCharArray_6 != null)
                {
                    Private___gintnl_SystemCharArray_6.Value = value;
                }
            }
        }

        internal UnityEngine.Color? __intnl_UnityEngineColor_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_2 != null)
                {
                    return Private___intnl_UnityEngineColor_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_2 != null)
                    {
                        Private___intnl_UnityEngineColor_2.Value = value.Value;
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

        internal UnityEngine.Texture2D[] __intnl_UnityEngineTexture2DArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTexture2DArray_0 != null)
                {
                    return Private___intnl_UnityEngineTexture2DArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTexture2DArray_0 != null)
                {
                    Private___intnl_UnityEngineTexture2DArray_0.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_9 != null)
                {
                    return Private___intnl_UnityEngineTransform_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_9 != null)
                {
                    Private___intnl_UnityEngineTransform_9.Value = value;
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

        internal TMPro.TextMeshProUGUI saoToggleTableTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoToggleTableTimer != null)
                {
                    return Private_saoToggleTableTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoToggleTableTimer != null)
                {
                    Private_saoToggleTableTimer.Value = value;
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_97
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_97 != null)
                {
                    return Private___gintnl_SystemUInt32_97.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_97 != null)
                    {
                        Private___gintnl_SystemUInt32_97.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_87
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_87 != null)
                {
                    return Private___gintnl_SystemUInt32_87.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_87 != null)
                    {
                        Private___gintnl_SystemUInt32_87.Value = value.Value;
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

        internal UnityEngine.Transform __intnl_UnityEngineTransform_133
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_133 != null)
                {
                    return Private___intnl_UnityEngineTransform_133.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_133 != null)
                {
                    Private___intnl_UnityEngineTransform_133.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_123
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_123 != null)
                {
                    return Private___intnl_UnityEngineTransform_123.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_123 != null)
                {
                    Private___intnl_UnityEngineTransform_123.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_113
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_113 != null)
                {
                    return Private___intnl_UnityEngineTransform_113.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_113 != null)
                {
                    Private___intnl_UnityEngineTransform_113.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_103
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_103 != null)
                {
                    return Private___intnl_UnityEngineTransform_103.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_103 != null)
                {
                    Private___intnl_UnityEngineTransform_103.Value = value;
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

        internal string __const_SystemString_166
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_166 != null)
                {
                    return Private___const_SystemString_166.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_166 != null)
                {
                    Private___const_SystemString_166.Value = value;
                }
            }
        }

        internal string __const_SystemString_176
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_176 != null)
                {
                    return Private___const_SystemString_176.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_176 != null)
                {
                    Private___const_SystemString_176.Value = value;
                }
            }
        }

        internal string __const_SystemString_146
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_146 != null)
                {
                    return Private___const_SystemString_146.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_146 != null)
                {
                    Private___const_SystemString_146.Value = value;
                }
            }
        }

        internal string __const_SystemString_156
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_156 != null)
                {
                    return Private___const_SystemString_156.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_156 != null)
                {
                    Private___const_SystemString_156.Value = value;
                }
            }
        }

        internal string __const_SystemString_126
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_126 != null)
                {
                    return Private___const_SystemString_126.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_126 != null)
                {
                    Private___const_SystemString_126.Value = value;
                }
            }
        }

        internal string __const_SystemString_136
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_136 != null)
                {
                    return Private___const_SystemString_136.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_136 != null)
                {
                    Private___const_SystemString_136.Value = value;
                }
            }
        }

        internal string __const_SystemString_106
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_106 != null)
                {
                    return Private___const_SystemString_106.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_106 != null)
                {
                    Private___const_SystemString_106.Value = value;
                }
            }
        }

        internal string __const_SystemString_116
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_116 != null)
                {
                    return Private___const_SystemString_116.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_116 != null)
                {
                    Private___const_SystemString_116.Value = value;
                }
            }
        }

        internal string __const_SystemString_186
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_186 != null)
                {
                    return Private___const_SystemString_186.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_186 != null)
                {
                    Private___const_SystemString_186.Value = value;
                }
            }
        }

        internal string __const_SystemString_196
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_196 != null)
                {
                    return Private___const_SystemString_196.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_196 != null)
                {
                    Private___const_SystemString_196.Value = value;
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

        internal int[] tableButtonToSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableButtonToSkin != null)
                {
                    return Private_tableButtonToSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tableButtonToSkin != null)
                {
                    Private_tableButtonToSkin.Value = value;
                }
            }
        }

        internal System.DateTime? __intnl_SystemDateTime_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemDateTime_0 != null)
                {
                    return Private___intnl_SystemDateTime_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemDateTime_0 != null)
                    {
                        Private___intnl_SystemDateTime_0.Value = value.Value;
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

        internal System.Guid? __intnl_SystemGuid_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemGuid_1 != null)
                {
                    return Private___intnl_SystemGuid_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemGuid_1 != null)
                    {
                        Private___intnl_SystemGuid_1.Value = value.Value;
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

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_3 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_3 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_3.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_3 != null)
                {
                    return Private___intnl_SystemObject_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_3 != null)
                {
                    Private___intnl_SystemObject_3.Value = value;
                }
            }
        }

        internal string __const_SystemString_264
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_264 != null)
                {
                    return Private___const_SystemString_264.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_264 != null)
                {
                    Private___const_SystemString_264.Value = value;
                }
            }
        }

        internal string __const_SystemString_244
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_244 != null)
                {
                    return Private___const_SystemString_244.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_244 != null)
                {
                    Private___const_SystemString_244.Value = value;
                }
            }
        }

        internal string __const_SystemString_254
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_254 != null)
                {
                    return Private___const_SystemString_254.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_254 != null)
                {
                    Private___const_SystemString_254.Value = value;
                }
            }
        }

        internal string __const_SystemString_224
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_224 != null)
                {
                    return Private___const_SystemString_224.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_224 != null)
                {
                    Private___const_SystemString_224.Value = value;
                }
            }
        }

        internal string __const_SystemString_234
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_234 != null)
                {
                    return Private___const_SystemString_234.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_234 != null)
                {
                    Private___const_SystemString_234.Value = value;
                }
            }
        }

        internal string __const_SystemString_204
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_204 != null)
                {
                    return Private___const_SystemString_204.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_204 != null)
                {
                    Private___const_SystemString_204.Value = value;
                }
            }
        }

        internal string __const_SystemString_214
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_214 != null)
                {
                    return Private___const_SystemString_214.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_214 != null)
                {
                    Private___const_SystemString_214.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __lcl_saoWorldSettings_UnityEngineTransform_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_saoWorldSettings_UnityEngineTransform_0 != null)
                {
                    return Private___lcl_saoWorldSettings_UnityEngineTransform_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_saoWorldSettings_UnityEngineTransform_0 != null)
                {
                    Private___lcl_saoWorldSettings_UnityEngineTransform_0.Value = value;
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

        internal char[] __gintnl_SystemCharArray_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemCharArray_5 != null)
                {
                    return Private___gintnl_SystemCharArray_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemCharArray_5 != null)
                {
                    Private___gintnl_SystemCharArray_5.Value = value;
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

        internal UnityEngine.Color? __intnl_UnityEngineColor_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_1 != null)
                {
                    return Private___intnl_UnityEngineColor_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_1 != null)
                    {
                        Private___intnl_UnityEngineColor_1.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __lcl_saoTableSkinsRoot_UnityEngineTransform_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_saoTableSkinsRoot_UnityEngineTransform_0 != null)
                {
                    return Private___lcl_saoTableSkinsRoot_UnityEngineTransform_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_saoTableSkinsRoot_UnityEngineTransform_0 != null)
                {
                    Private___lcl_saoTableSkinsRoot_UnityEngineTransform_0.Value = value;
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

        internal UnityEngine.GameObject previewCue
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_previewCue != null)
                {
                    return Private_previewCue.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_previewCue != null)
                {
                    Private_previewCue.Value = value;
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

        internal bool? __0_tableTimer__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_tableTimer__param != null)
                {
                    return Private___0_tableTimer__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_tableTimer__param != null)
                    {
                        Private___0_tableTimer__param.Value = value.Value;
                    }
                }
            }
        }

        internal float? __2_value__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_value__param != null)
                {
                    return Private___2_value__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_value__param != null)
                    {
                        Private___2_value__param.Value = value.Value;
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

        internal int? __lcl_cueId_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_cueId_SystemInt32_0 != null)
                {
                    return Private___lcl_cueId_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_cueId_SystemInt32_0 != null)
                    {
                        Private___lcl_cueId_SystemInt32_0.Value = value.Value;
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

        internal string __const_SystemString_165
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_165 != null)
                {
                    return Private___const_SystemString_165.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_165 != null)
                {
                    Private___const_SystemString_165.Value = value;
                }
            }
        }

        internal string __const_SystemString_175
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_175 != null)
                {
                    return Private___const_SystemString_175.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_175 != null)
                {
                    Private___const_SystemString_175.Value = value;
                }
            }
        }

        internal string __const_SystemString_145
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_145 != null)
                {
                    return Private___const_SystemString_145.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_145 != null)
                {
                    Private___const_SystemString_145.Value = value;
                }
            }
        }

        internal string __const_SystemString_155
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_155 != null)
                {
                    return Private___const_SystemString_155.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_155 != null)
                {
                    Private___const_SystemString_155.Value = value;
                }
            }
        }

        internal string __const_SystemString_125
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_125 != null)
                {
                    return Private___const_SystemString_125.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_125 != null)
                {
                    Private___const_SystemString_125.Value = value;
                }
            }
        }

        internal string __const_SystemString_135
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_135 != null)
                {
                    return Private___const_SystemString_135.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_135 != null)
                {
                    Private___const_SystemString_135.Value = value;
                }
            }
        }

        internal string __const_SystemString_105
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_105 != null)
                {
                    return Private___const_SystemString_105.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_105 != null)
                {
                    Private___const_SystemString_105.Value = value;
                }
            }
        }

        internal string __const_SystemString_115
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_115 != null)
                {
                    return Private___const_SystemString_115.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_115 != null)
                {
                    Private___const_SystemString_115.Value = value;
                }
            }
        }

        internal string __const_SystemString_185
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_185 != null)
                {
                    return Private___const_SystemString_185.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_185 != null)
                {
                    Private___const_SystemString_185.Value = value;
                }
            }
        }

        internal string __const_SystemString_195
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_195 != null)
                {
                    return Private___const_SystemString_195.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_195 != null)
                {
                    Private___const_SystemString_195.Value = value;
                }
            }
        }

        internal bool? shouldPopcat
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_shouldPopcat != null)
                {
                    return Private_shouldPopcat.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_shouldPopcat != null)
                    {
                        Private_shouldPopcat.Value = value.Value;
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

        internal int? __0_mode__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mode__param != null)
                {
                    return Private___0_mode__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mode__param != null)
                    {
                        Private___0_mode__param.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI[] saoTableModels
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoTableModels != null)
                {
                    return Private_saoTableModels.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoTableModels != null)
                {
                    Private_saoTableModels.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI saoTogglePlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoTogglePlayer != null)
                {
                    return Private_saoTogglePlayer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoTogglePlayer != null)
                {
                    Private_saoTogglePlayer.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_4 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_4 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_4.Value = value;
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

        internal char? __lcl_ch_SystemChar_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_ch_SystemChar_0 != null)
                {
                    return Private___lcl_ch_SystemChar_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_ch_SystemChar_0 != null)
                    {
                        Private___lcl_ch_SystemChar_0.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_VRCUdonUdonBehaviour_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_VRCUdonUdonBehaviour_6 != null)
                {
                    return Private___intnl_VRCUdonUdonBehaviour_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_VRCUdonUdonBehaviour_6 != null)
                {
                    Private___intnl_VRCUdonUdonBehaviour_6.Value = value;
                }
            }
        }

        internal string __const_SystemString_249
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_249 != null)
                {
                    return Private___const_SystemString_249.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_249 != null)
                {
                    Private___const_SystemString_249.Value = value;
                }
            }
        }

        internal string __const_SystemString_259
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_259 != null)
                {
                    return Private___const_SystemString_259.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_259 != null)
                {
                    Private___const_SystemString_259.Value = value;
                }
            }
        }

        internal string __const_SystemString_229
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_229 != null)
                {
                    return Private___const_SystemString_229.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_229 != null)
                {
                    Private___const_SystemString_229.Value = value;
                }
            }
        }

        internal string __const_SystemString_239
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_239 != null)
                {
                    return Private___const_SystemString_239.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_239 != null)
                {
                    Private___const_SystemString_239.Value = value;
                }
            }
        }

        internal string __const_SystemString_209
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_209 != null)
                {
                    return Private___const_SystemString_209.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_209 != null)
                {
                    Private___const_SystemString_209.Value = value;
                }
            }
        }

        internal string __const_SystemString_219
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_219 != null)
                {
                    return Private___const_SystemString_219.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_219 != null)
                {
                    Private___const_SystemString_219.Value = value;
                }
            }
        }

        internal string outColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outColor != null)
                {
                    return Private_outColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_outColor != null)
                {
                    Private_outColor.Value = value;
                }
            }
        }

        internal UnityEngine.Color? __intnl_UnityEngineColor_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_9 != null)
                {
                    return Private___intnl_UnityEngineColor_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_9 != null)
                    {
                        Private___intnl_UnityEngineColor_9.Value = value.Value;
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

        internal int? outSetting
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_outSetting != null)
                {
                    return Private_outSetting.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_outSetting != null)
                    {
                        Private_outSetting.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_59
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_59 != null)
                {
                    return Private___intnl_UnityEngineTransform_59.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_59 != null)
                {
                    Private___intnl_UnityEngineTransform_59.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_58
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_58 != null)
                {
                    return Private___intnl_UnityEngineTransform_58.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_58 != null)
                {
                    Private___intnl_UnityEngineTransform_58.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_53
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_53 != null)
                {
                    return Private___intnl_UnityEngineTransform_53.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_53 != null)
                {
                    Private___intnl_UnityEngineTransform_53.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_52
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_52 != null)
                {
                    return Private___intnl_UnityEngineTransform_52.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_52 != null)
                {
                    Private___intnl_UnityEngineTransform_52.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_51
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_51 != null)
                {
                    return Private___intnl_UnityEngineTransform_51.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_51 != null)
                {
                    Private___intnl_UnityEngineTransform_51.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_50
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_50 != null)
                {
                    return Private___intnl_UnityEngineTransform_50.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_50 != null)
                {
                    Private___intnl_UnityEngineTransform_50.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_57
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_57 != null)
                {
                    return Private___intnl_UnityEngineTransform_57.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_57 != null)
                {
                    Private___intnl_UnityEngineTransform_57.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_56
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_56 != null)
                {
                    return Private___intnl_UnityEngineTransform_56.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_56 != null)
                {
                    Private___intnl_UnityEngineTransform_56.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_55
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_55 != null)
                {
                    return Private___intnl_UnityEngineTransform_55.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_55 != null)
                {
                    Private___intnl_UnityEngineTransform_55.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_54
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_54 != null)
                {
                    return Private___intnl_UnityEngineTransform_54.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_54 != null)
                {
                    Private___intnl_UnityEngineTransform_54.Value = value;
                }
            }
        }

        internal int? __0___0_getPenSocialSetting__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_getPenSocialSetting__ret != null)
                {
                    return Private___0___0_getPenSocialSetting__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_getPenSocialSetting__ret != null)
                    {
                        Private___0___0_getPenSocialSetting__ret.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_90
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_90 != null)
                {
                    return Private___gintnl_SystemUInt32_90.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_90 != null)
                    {
                        Private___gintnl_SystemUInt32_90.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_80
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_80 != null)
                {
                    return Private___gintnl_SystemUInt32_80.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_80 != null)
                    {
                        Private___gintnl_SystemUInt32_80.Value = value.Value;
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

        internal bool? __0___0_canUseCueSkin__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_canUseCueSkin__ret != null)
                {
                    return Private___0___0_canUseCueSkin__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_canUseCueSkin__ret != null)
                    {
                        Private___0___0_canUseCueSkin__ret.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_126
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_126 != null)
                {
                    return Private___intnl_UnityEngineTransform_126.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_126 != null)
                {
                    Private___intnl_UnityEngineTransform_126.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_116
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_116 != null)
                {
                    return Private___intnl_UnityEngineTransform_116.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_116 != null)
                {
                    Private___intnl_UnityEngineTransform_116.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_106
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_106 != null)
                {
                    return Private___intnl_UnityEngineTransform_106.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_106 != null)
                {
                    Private___intnl_UnityEngineTransform_106.Value = value;
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

        internal UnityEngine.Texture2D __intnl_UnityEngineTexture2D_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTexture2D_0 != null)
                {
                    return Private___intnl_UnityEngineTexture2D_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTexture2D_0 != null)
                {
                    Private___intnl_UnityEngineTexture2D_0.Value = value;
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

        internal string[] tournamentRefs
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tournamentRefs != null)
                {
                    return Private_tournamentRefs.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tournamentRefs != null)
                {
                    Private_tournamentRefs.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Slider saoStrafeSpeedSlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoStrafeSpeedSlider != null)
                {
                    return Private_saoStrafeSpeedSlider.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoStrafeSpeedSlider != null)
                {
                    Private_saoStrafeSpeedSlider.Value = value;
                }
            }
        }

        internal string __const_SystemString_168
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_168 != null)
                {
                    return Private___const_SystemString_168.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_168 != null)
                {
                    Private___const_SystemString_168.Value = value;
                }
            }
        }

        internal string __const_SystemString_178
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_178 != null)
                {
                    return Private___const_SystemString_178.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_178 != null)
                {
                    Private___const_SystemString_178.Value = value;
                }
            }
        }

        internal string __const_SystemString_148
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_148 != null)
                {
                    return Private___const_SystemString_148.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_148 != null)
                {
                    Private___const_SystemString_148.Value = value;
                }
            }
        }

        internal string __const_SystemString_158
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_158 != null)
                {
                    return Private___const_SystemString_158.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_158 != null)
                {
                    Private___const_SystemString_158.Value = value;
                }
            }
        }

        internal string __const_SystemString_128
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_128 != null)
                {
                    return Private___const_SystemString_128.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_128 != null)
                {
                    Private___const_SystemString_128.Value = value;
                }
            }
        }

        internal string __const_SystemString_138
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_138 != null)
                {
                    return Private___const_SystemString_138.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_138 != null)
                {
                    Private___const_SystemString_138.Value = value;
                }
            }
        }

        internal string __const_SystemString_108
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_108 != null)
                {
                    return Private___const_SystemString_108.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_108 != null)
                {
                    Private___const_SystemString_108.Value = value;
                }
            }
        }

        internal string __const_SystemString_118
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_118 != null)
                {
                    return Private___const_SystemString_118.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_118 != null)
                {
                    Private___const_SystemString_118.Value = value;
                }
            }
        }

        internal string __const_SystemString_188
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_188 != null)
                {
                    return Private___const_SystemString_188.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_188 != null)
                {
                    Private___const_SystemString_188.Value = value;
                }
            }
        }

        internal string __const_SystemString_198
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_198 != null)
                {
                    return Private___const_SystemString_198.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_198 != null)
                {
                    Private___const_SystemString_198.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI saoToggleBallShadow
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoToggleBallShadow != null)
                {
                    return Private_saoToggleBallShadow.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoToggleBallShadow != null)
                {
                    Private_saoToggleBallShadow.Value = value;
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

        internal float? __1_value__param
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

        internal TMPro.TextMeshProUGUI saoToggleLegacyPhysics
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoToggleLegacyPhysics != null)
                {
                    return Private_saoToggleLegacyPhysics.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoToggleLegacyPhysics != null)
                {
                    Private_saoToggleLegacyPhysics.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject blahaj
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_blahaj != null)
                {
                    return Private_blahaj.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_blahaj != null)
                {
                    Private_blahaj.Value = value;
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

        internal uint? __gintnl_SystemUInt32_100
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_100 != null)
                {
                    return Private___gintnl_SystemUInt32_100.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_100 != null)
                    {
                        Private___gintnl_SystemUInt32_100.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_101
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_101 != null)
                {
                    return Private___gintnl_SystemUInt32_101.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_101 != null)
                    {
                        Private___gintnl_SystemUInt32_101.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_102
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_102 != null)
                {
                    return Private___gintnl_SystemUInt32_102.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_102 != null)
                    {
                        Private___gintnl_SystemUInt32_102.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_103
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_103 != null)
                {
                    return Private___gintnl_SystemUInt32_103.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_103 != null)
                    {
                        Private___gintnl_SystemUInt32_103.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Slider saoLoliLifterSlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoLoliLifterSlider != null)
                {
                    return Private_saoLoliLifterSlider.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoLoliLifterSlider != null)
                {
                    Private_saoLoliLifterSlider.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_6 != null)
                {
                    return Private___intnl_SystemObject_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_6 != null)
                {
                    Private___intnl_SystemObject_6.Value = value;
                }
            }
        }

        internal bool? INITIALIZED
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_INITIALIZED != null)
                {
                    return Private_INITIALIZED.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_INITIALIZED != null)
                    {
                        Private_INITIALIZED.Value = value.Value;
                    }
                }
            }
        }

        internal string __const_SystemString_261
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_261 != null)
                {
                    return Private___const_SystemString_261.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_261 != null)
                {
                    Private___const_SystemString_261.Value = value;
                }
            }
        }

        internal string __const_SystemString_241
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_241 != null)
                {
                    return Private___const_SystemString_241.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_241 != null)
                {
                    Private___const_SystemString_241.Value = value;
                }
            }
        }

        internal string __const_SystemString_251
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_251 != null)
                {
                    return Private___const_SystemString_251.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_251 != null)
                {
                    Private___const_SystemString_251.Value = value;
                }
            }
        }

        internal string __const_SystemString_221
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_221 != null)
                {
                    return Private___const_SystemString_221.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_221 != null)
                {
                    Private___const_SystemString_221.Value = value;
                }
            }
        }

        internal string __const_SystemString_231
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_231 != null)
                {
                    return Private___const_SystemString_231.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_231 != null)
                {
                    Private___const_SystemString_231.Value = value;
                }
            }
        }

        internal string __const_SystemString_201
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_201 != null)
                {
                    return Private___const_SystemString_201.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_201 != null)
                {
                    Private___const_SystemString_201.Value = value;
                }
            }
        }

        internal string __const_SystemString_211
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_211 != null)
                {
                    return Private___const_SystemString_211.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_211 != null)
                {
                    Private___const_SystemString_211.Value = value;
                }
            }
        }

        internal int? selectedCueSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_selectedCueSkin != null)
                {
                    return Private_selectedCueSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_selectedCueSkin != null)
                    {
                        Private_selectedCueSkin.Value = value.Value;
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

        internal bool? __0_hasPendingRequest__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_hasPendingRequest__ret != null)
                {
                    return Private___0_hasPendingRequest__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_hasPendingRequest__ret != null)
                    {
                        Private___0_hasPendingRequest__ret.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_6 != null)
                {
                    return Private___intnl_UnityEngineTransform_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_6 != null)
                {
                    Private___intnl_UnityEngineTransform_6.Value = value;
                }
            }
        }

        internal int? inRemoteVersion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_inRemoteVersion != null)
                {
                    return Private_inRemoteVersion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_inRemoteVersion != null)
                    {
                        Private_inRemoteVersion.Value = value.Value;
                    }
                }
            }
        }

        internal System.Guid? activeYoutubeSearch
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_activeYoutubeSearch != null)
                {
                    return Private_activeYoutubeSearch.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_activeYoutubeSearch != null)
                    {
                        Private_activeYoutubeSearch.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? __intnl_UnityEngineColor_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_4 != null)
                {
                    return Private___intnl_UnityEngineColor_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_4 != null)
                    {
                        Private___intnl_UnityEngineColor_4.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_98
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_98 != null)
                {
                    return Private___gintnl_SystemUInt32_98.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_98 != null)
                    {
                        Private___gintnl_SystemUInt32_98.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_88
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_88 != null)
                {
                    return Private___gintnl_SystemUInt32_88.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_88 != null)
                    {
                        Private___gintnl_SystemUInt32_88.Value = value.Value;
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

        internal int? selectedTableSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_selectedTableSkin != null)
                {
                    return Private_selectedTableSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_selectedTableSkin != null)
                    {
                        Private_selectedTableSkin.Value = value.Value;
                    }
                }
            }
        }

        internal string[] DEPENDENCIES
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_DEPENDENCIES != null)
                {
                    return Private_DEPENDENCIES.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_DEPENDENCIES != null)
                {
                    Private_DEPENDENCIES.Value = value;
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

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_29
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_29 != null)
                {
                    return Private___intnl_UnityEngineTransform_29.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_29 != null)
                {
                    Private___intnl_UnityEngineTransform_29.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_28
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_28 != null)
                {
                    return Private___intnl_UnityEngineTransform_28.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_28 != null)
                {
                    Private___intnl_UnityEngineTransform_28.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_23
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_23 != null)
                {
                    return Private___intnl_UnityEngineTransform_23.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_23 != null)
                {
                    Private___intnl_UnityEngineTransform_23.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_22
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_22 != null)
                {
                    return Private___intnl_UnityEngineTransform_22.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_22 != null)
                {
                    Private___intnl_UnityEngineTransform_22.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_21
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_21 != null)
                {
                    return Private___intnl_UnityEngineTransform_21.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_21 != null)
                {
                    Private___intnl_UnityEngineTransform_21.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_20
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_20 != null)
                {
                    return Private___intnl_UnityEngineTransform_20.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_20 != null)
                {
                    Private___intnl_UnityEngineTransform_20.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_27
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_27 != null)
                {
                    return Private___intnl_UnityEngineTransform_27.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_27 != null)
                {
                    Private___intnl_UnityEngineTransform_27.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_26
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_26 != null)
                {
                    return Private___intnl_UnityEngineTransform_26.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_26 != null)
                {
                    Private___intnl_UnityEngineTransform_26.Value = value;
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_25
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_25 != null)
                {
                    return Private___intnl_UnityEngineTransform_25.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_25 != null)
                {
                    Private___intnl_UnityEngineTransform_25.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_24
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_24 != null)
                {
                    return Private___intnl_UnityEngineTransform_24.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_24 != null)
                {
                    Private___intnl_UnityEngineTransform_24.Value = value;
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_95
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_95 != null)
                {
                    return Private___gintnl_SystemUInt32_95.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_95 != null)
                    {
                        Private___gintnl_SystemUInt32_95.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_85
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_85 != null)
                {
                    return Private___gintnl_SystemUInt32_85.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_85 != null)
                    {
                        Private___gintnl_SystemUInt32_85.Value = value.Value;
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

        internal bool? __0__SelectCueSkinContributor__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0__SelectCueSkinContributor__ret != null)
                {
                    return Private___0__SelectCueSkinContributor__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0__SelectCueSkinContributor__ret != null)
                    {
                        Private___0__SelectCueSkinContributor__ret.Value = value.Value;
                    }
                }
            }
        }

        internal System.Object[] tableSkinAllowed
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tableSkinAllowed != null)
                {
                    return Private_tableSkinAllowed.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tableSkinAllowed != null)
                {
                    Private_tableSkinAllowed.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_125
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_125 != null)
                {
                    return Private___intnl_UnityEngineTransform_125.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_125 != null)
                {
                    Private___intnl_UnityEngineTransform_125.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_115
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_115 != null)
                {
                    return Private___intnl_UnityEngineTransform_115.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_115 != null)
                {
                    Private___intnl_UnityEngineTransform_115.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_105
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_105 != null)
                {
                    return Private___intnl_UnityEngineTransform_105.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_105 != null)
                {
                    Private___intnl_UnityEngineTransform_105.Value = value;
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

        internal float? lastPoll
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lastPoll != null)
                {
                    return Private_lastPoll.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lastPoll != null)
                    {
                        Private_lastPoll.Value = value.Value;
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

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_128
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_128 != null)
                {
                    return Private___intnl_UnityEngineTransform_128.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_128 != null)
                {
                    Private___intnl_UnityEngineTransform_128.Value = value;
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_118
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_118 != null)
                {
                    return Private___intnl_UnityEngineTransform_118.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_118 != null)
                {
                    Private___intnl_UnityEngineTransform_118.Value = value;
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_108
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_108 != null)
                {
                    return Private___intnl_UnityEngineTransform_108.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_108 != null)
                {
                    Private___intnl_UnityEngineTransform_108.Value = value;
                }
            }
        }

        internal string __const_SystemString_160
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_160 != null)
                {
                    return Private___const_SystemString_160.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_160 != null)
                {
                    Private___const_SystemString_160.Value = value;
                }
            }
        }

        internal string __const_SystemString_170
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_170 != null)
                {
                    return Private___const_SystemString_170.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_170 != null)
                {
                    Private___const_SystemString_170.Value = value;
                }
            }
        }

        internal string __const_SystemString_140
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_140 != null)
                {
                    return Private___const_SystemString_140.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_140 != null)
                {
                    Private___const_SystemString_140.Value = value;
                }
            }
        }

        internal string __const_SystemString_150
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_150 != null)
                {
                    return Private___const_SystemString_150.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_150 != null)
                {
                    Private___const_SystemString_150.Value = value;
                }
            }
        }

        internal string __const_SystemString_120
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_120 != null)
                {
                    return Private___const_SystemString_120.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_120 != null)
                {
                    Private___const_SystemString_120.Value = value;
                }
            }
        }

        internal string __const_SystemString_130
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_130 != null)
                {
                    return Private___const_SystemString_130.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_130 != null)
                {
                    Private___const_SystemString_130.Value = value;
                }
            }
        }

        internal string __const_SystemString_100
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_100 != null)
                {
                    return Private___const_SystemString_100.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_100 != null)
                {
                    Private___const_SystemString_100.Value = value;
                }
            }
        }

        internal string __const_SystemString_110
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_110 != null)
                {
                    return Private___const_SystemString_110.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_110 != null)
                {
                    Private___const_SystemString_110.Value = value;
                }
            }
        }

        internal string __const_SystemString_180
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_180 != null)
                {
                    return Private___const_SystemString_180.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_180 != null)
                {
                    Private___const_SystemString_180.Value = value;
                }
            }
        }

        internal string __const_SystemString_190
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_190 != null)
                {
                    return Private___const_SystemString_190.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_190 != null)
                {
                    Private___const_SystemString_190.Value = value;
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

        internal TMPro.TextMeshProUGUI saoToggleUSColors
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoToggleUSColors != null)
                {
                    return Private_saoToggleUSColors.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoToggleUSColors != null)
                {
                    Private_saoToggleUSColors.Value = value;
                }
            }
        }

        internal bool? __0___0_onChatCommand__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_onChatCommand__ret != null)
                {
                    return Private___0___0_onChatCommand__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_onChatCommand__ret != null)
                    {
                        Private___0___0_onChatCommand__ret.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_1 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_1 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_1.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_5 != null)
                {
                    return Private___intnl_SystemObject_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_5 != null)
                {
                    Private___intnl_SystemObject_5.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_57
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_57 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_57.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_57 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_57.Value = value;
                }
            }
        }

        internal TMPro.TextMeshProUGUI __intnl_TMProTextMeshProUGUI_58
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_TMProTextMeshProUGUI_58 != null)
                {
                    return Private___intnl_TMProTextMeshProUGUI_58.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_TMProTextMeshProUGUI_58 != null)
                {
                    Private___intnl_TMProTextMeshProUGUI_58.Value = value;
                }
            }
        }

        internal string __const_SystemString_262
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_262 != null)
                {
                    return Private___const_SystemString_262.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_262 != null)
                {
                    Private___const_SystemString_262.Value = value;
                }
            }
        }

        internal string __const_SystemString_242
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_242 != null)
                {
                    return Private___const_SystemString_242.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_242 != null)
                {
                    Private___const_SystemString_242.Value = value;
                }
            }
        }

        internal string __const_SystemString_252
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_252 != null)
                {
                    return Private___const_SystemString_252.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_252 != null)
                {
                    Private___const_SystemString_252.Value = value;
                }
            }
        }

        internal string __const_SystemString_222
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_222 != null)
                {
                    return Private___const_SystemString_222.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_222 != null)
                {
                    Private___const_SystemString_222.Value = value;
                }
            }
        }

        internal string __const_SystemString_232
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_232 != null)
                {
                    return Private___const_SystemString_232.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_232 != null)
                {
                    Private___const_SystemString_232.Value = value;
                }
            }
        }

        internal string __const_SystemString_202
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_202 != null)
                {
                    return Private___const_SystemString_202.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_202 != null)
                {
                    Private___const_SystemString_202.Value = value;
                }
            }
        }

        internal string __const_SystemString_212
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemString_212 != null)
                {
                    return Private___const_SystemString_212.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___const_SystemString_212 != null)
                {
                    Private___const_SystemString_212.Value = value;
                }
            }
        }

        internal UnityEngine.UI.Slider saoJumpImpulseSlider
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoJumpImpulseSlider != null)
                {
                    return Private_saoJumpImpulseSlider.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoJumpImpulseSlider != null)
                {
                    Private_saoJumpImpulseSlider.Value = value;
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

        internal UnityEngine.GameObject saoMenu
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoMenu != null)
                {
                    return Private_saoMenu.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoMenu != null)
                {
                    Private_saoMenu.Value = value;
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

        internal TMPro.TextMeshProUGUI[] saoTableSkins
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saoTableSkins != null)
                {
                    return Private_saoTableSkins.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saoTableSkins != null)
                {
                    Private_saoTableSkins.Value = value;
                }
            }
        }

        internal bool? __intnl_SystemBoolean_119
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_119 != null)
                {
                    return Private___intnl_SystemBoolean_119.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_119 != null)
                    {
                        Private___intnl_SystemBoolean_119.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_118
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_118 != null)
                {
                    return Private___intnl_SystemBoolean_118.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_118 != null)
                    {
                        Private___intnl_SystemBoolean_118.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_111
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_111 != null)
                {
                    return Private___intnl_SystemBoolean_111.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_111 != null)
                    {
                        Private___intnl_SystemBoolean_111.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_110
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_110 != null)
                {
                    return Private___intnl_SystemBoolean_110.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_110 != null)
                    {
                        Private___intnl_SystemBoolean_110.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_113
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_113 != null)
                {
                    return Private___intnl_SystemBoolean_113.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_113 != null)
                    {
                        Private___intnl_SystemBoolean_113.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_112
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_112 != null)
                {
                    return Private___intnl_SystemBoolean_112.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_112 != null)
                    {
                        Private___intnl_SystemBoolean_112.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_115
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_115 != null)
                {
                    return Private___intnl_SystemBoolean_115.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_115 != null)
                    {
                        Private___intnl_SystemBoolean_115.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_114
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_114 != null)
                {
                    return Private___intnl_SystemBoolean_114.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_114 != null)
                    {
                        Private___intnl_SystemBoolean_114.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_117
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_117 != null)
                {
                    return Private___intnl_SystemBoolean_117.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_117 != null)
                    {
                        Private___intnl_SystemBoolean_117.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_116
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_116 != null)
                {
                    return Private___intnl_SystemBoolean_116.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_116 != null)
                    {
                        Private___intnl_SystemBoolean_116.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_3 != null)
                {
                    return Private___intnl_UnityEngineTransform_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_3 != null)
                {
                    Private___intnl_UnityEngineTransform_3.Value = value;
                }
            }
        }

        internal UnityEngine.Color? __intnl_UnityEngineColor_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineColor_3 != null)
                {
                    return Private___intnl_UnityEngineColor_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineColor_3 != null)
                    {
                        Private___intnl_UnityEngineColor_3.Value = value.Value;
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

        internal UnityEngine.RectTransform __intnl_UnityEngineTransform_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_8 != null)
                {
                    return Private___intnl_UnityEngineTransform_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_8 != null)
                {
                    Private___intnl_UnityEngineTransform_8.Value = value;
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of PoolParlorModule

        #region AstroUdonVariables  of PoolParlorModule

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_83 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_93 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_63 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_73 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_hologramSystem { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_96 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_86 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private___intnl_SystemInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___const_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_tableCount_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___1_accept__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_selectedTableModel { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___lcl_saoTableModelsRoot_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_130 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_120 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_110 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_100 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_167 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_177 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_147 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_157 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_127 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_137 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_107 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_117 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_187 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_197 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Material> Private___intnl_UnityEngineMaterial_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0__SelectTableSkinContributor__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.DateTimeOffset> Private___intnl_SystemDateTimeOffset_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_ping { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___2_active__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___1_id__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_outCanUse { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_247 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_257 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_227 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_237 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_207 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_217 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_liftModule { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_accept__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_id__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___3_id__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_shadowsDisabled__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___2_id__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_79 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_78 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_73 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_72 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_71 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_70 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_77 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_76 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_75 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_74 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_86 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_96 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_66 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_76 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saoToggleCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Texture2D[]> Private___intnl_SystemObject_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI[]> Private_saoCameras { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private___lcl_cueSkinId_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___0_value__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_96 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_97 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_94 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_95 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_92 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_93 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_90 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_91 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_98 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_99 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_newPhysicsMode__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_cueCount_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saoToggleHologram { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int[]> Private_cueButtonToSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_248 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_258 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_228 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_238 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_208 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_218 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_tableId_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_usColors__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___1_enabled__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___1_skin__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_selectedCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_93 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_83 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_73 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_63 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_inMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_tableSkinId_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_isPolling { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_127 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_117 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_107 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_metaverse { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_99 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_98 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_93 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_92 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_91 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_90 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_97 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_96 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_95 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_94 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_physicsMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_162 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_172 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_142 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_152 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_122 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_132 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_102 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_112 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_182 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_192 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private_tables { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.MeshRenderer> Private___lcl_renderer_UnityEngineMeshRenderer_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.TimeSpan> Private___intnl_SystemTimeSpan_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_169 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_179 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_149 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_159 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_129 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_139 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_109 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_119 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_189 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_199 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_modModule { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___lcl_saoTableSettings_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_enabled__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_toaster { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_260 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_240 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_250 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_220 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_230 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_200 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_210 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private_SAO_COLOR_ENABLED { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___1_active__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_inSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_decoder { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___2_owner__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___4_value__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_81 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_91 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_61 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_71 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_94 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_84 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int> Private___intnl_SystemInt32_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_122 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_112 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_102 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_outSuccessful { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_129 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_119 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_109 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_161 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_171 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_141 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_151 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_121 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_131 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_101 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_111 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_181 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_191 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private_SAO_COLOR_DISABLED { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject[]> Private_props { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string[]> Private_moderators { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_penModule { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Guid> Private___intnl_SystemGuid_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___lcl_saoCueSkinsRoot_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___0___0_getNameColor__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_objectsModule_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_245 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_255 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_225 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_235 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_205 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_215 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_121 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_120 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_123 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_122 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_125 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_124 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_127 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_126 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Texture2D> Private___intnl_UnityEngineTexture_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.DateTime> Private___0_tournament__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_shouldBlahaj { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saoToggleProps { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_89 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_99 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_69 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_79 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI[]> Private_saoCueSkins { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_active__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_playerId_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_84 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_94 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_74 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_hours_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___intnl_UnityEngineComponentArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___lcl_saoCamerasRoot_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_131 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_121 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_111 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_101 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private_SAO_COLOR_LOCKED { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_164 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_174 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_144 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_154 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_124 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_134 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_104 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_114 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_184 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_194 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_activeYoutubeSearchAttempts { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Material[]> Private___intnl_UnityEngineMaterialArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_worldUpdate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char> Private___const_SystemChar_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private_inOwner { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Object[]> Private_cueSkinAllowed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_246 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_256 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_226 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_236 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_206 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_216 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_nameColorMap { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_propsEnabled { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0___0_isTournamentRunning__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_skin__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_69 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_68 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_63 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_62 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_61 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_67 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_66 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_65 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___lcl_saoPlayerSettings_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_91 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_81 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_71 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_61 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___3_value__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_87 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_97 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_67 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_77 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_popcat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_chat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Slider> Private_saoRunSpeedSlider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private_VERSION { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.UI.InputField> Private_saoSaveLoadInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___intnl_SystemInt64_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___intnl_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.DateTime> Private___lcl_utcNow_SystemDateTime_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.KeyCode> Private___const_UnityEngineKeyCode_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_99 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_89 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_79 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_69 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_physicsMode___param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_92 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_82 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_72 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_62 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Slider> Private_saoWalkSpeedSlider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_124 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_114 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_104 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_89 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_88 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_83 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_82 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_81 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_80 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_87 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_86 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_85 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_84 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_shouldPing { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_behaviour_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_163 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_173 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_143 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_153 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_123 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_133 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_103 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_113 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_183 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_193 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_inLocalVersion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___1__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saoTogglePens { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.DateTime> Private_tournamentDate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_263 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_243 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_253 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_223 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_233 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_203 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_213 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_shouldToaster { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Space> Private___const_UnityEngineSpace_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_109 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_108 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_101 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_100 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_103 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_102 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_105 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_104 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_107 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_106 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0___0_canUseTableSkin__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Texture2D[]> Private___intnl_UnityEngineTexture2DArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_82 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_92 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_62 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_72 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saoToggleTableTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_97 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_87 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_77 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_67 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_133 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_123 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_113 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_103 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Object[]> Private___gintnl_SystemObjectArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_166 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_176 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_146 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_156 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_126 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_136 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_106 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_116 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_186 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_196 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<int[]> Private_tableButtonToSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.DateTime> Private___intnl_SystemDateTime_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<System.Guid> Private___intnl_SystemGuid_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_264 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_244 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_254 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_224 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_234 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_204 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_214 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___lcl_saoWorldSettings_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_targetID_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<double> Private___intnl_SystemDouble_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_idValue_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___lcl_saoTableSkinsRoot_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_85 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_95 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_65 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_75 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_previewCue { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_tableTimer__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___2_value__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_cueId_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_165 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_175 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_145 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_155 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_125 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_135 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_105 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_115 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_185 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_195 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_shouldPopcat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<byte> Private___intnl_SystemByte_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_mode__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI[]> Private_saoTableModels { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saoTogglePlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char> Private___const_SystemChar_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char> Private___lcl_ch_SystemChar_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_249 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_259 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_229 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_239 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_209 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_219 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private_outColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_outSetting { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0___0_getPenSocialSetting__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_90 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_80 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_70 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_60 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0___0_canUseCueSkin__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_126 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_116 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_106 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Texture2D> Private___intnl_UnityEngineTexture2D_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string[]> Private_tournamentRefs { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Slider> Private_saoStrafeSpeedSlider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_168 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_178 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_148 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_158 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_128 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_138 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_108 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_118 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_188 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_198 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saoToggleBallShadow { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___this_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___1_value__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saoToggleLegacyPhysics { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_blahaj { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_100 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_101 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_102 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_103 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Slider> Private_saoLoliLifterSlider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_INITIALIZED { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_261 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_241 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_251 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_221 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_231 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_201 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_211 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_selectedCueSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_hasPendingRequest__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_inRemoteVersion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Guid> Private_activeYoutubeSearch { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_98 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_88 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_78 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_68 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_selectedTableSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string[]> Private_DEPENDENCIES { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_95 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_85 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_75 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_65 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0__SelectCueSkinContributor__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Object[]> Private_tableSkinAllowed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_125 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_115 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_105 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.Component[]> Private___lcl_udonBehaviours_UnityEngineComponentArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private_lastPoll { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_128 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_118 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_108 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_160 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_170 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_140 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_150 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_120 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_130 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_100 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_110 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_180 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_190 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saoToggleUSColors { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0___0_onChatCommand__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_262 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_242 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_252 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_222 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_232 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_202 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_212 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.UI.Slider> Private_saoJumpImpulseSlider { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_saoMenu { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<TMPro.TextMeshProUGUI[]> Private_saoTableSkins { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_119 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_118 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_111 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_110 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_113 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_112 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_115 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_114 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_117 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_116 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.RectTransform> Private___intnl_UnityEngineTransform_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of PoolParlorModule
    }
}