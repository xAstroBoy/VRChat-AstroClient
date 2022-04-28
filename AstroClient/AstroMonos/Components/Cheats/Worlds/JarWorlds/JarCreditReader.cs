using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds;

using IntPtr = System.IntPtr;

// Stupid il2cpp
[RegisterComponent]
public class JarCreditReader : MonoBehaviour
{
    private List<Object> AntiGarbageCollection = new();

    public JarCreditReader(IntPtr ptr) : base(ptr)
    {
        AntiGarbageCollection.Add(this);
    }

    private void OnRoomLeft()
    {
        Destroy(this);
    }

    private UdonBehaviour_Cached RetrySystem { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

    private RawUdonBehaviour PatronCredits { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

    internal void Start()
    {
        RetrySystem = gameObject.FindUdonEvent("_Retry");
        if (RetrySystem != null)
        {
            PatronCredits = RetrySystem.RawItem;
            this.gameObject.AddToWorldUtilsMenu(); // TO TEST
            Initialize_PatronCredits();
            HasSubscribed = true;
        }
        if (RetrySystem == null)
        {
            Log.Error("Can't Find PatronControl behaviour, Unable to Add Reader Component, did the author update the world?");
            Destroy(this);
        }
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


    private void OnDestroy()
    {
        HasSubscribed = false;
        Cleanup_PatronCredits();
    }

    private void Initialize_PatronCredits()
    {
        Private_retries = new AstroUdonVariable<int>(PatronCredits, "retries");
        Private___6_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__6_intnl_UnityEngineTransform");
        Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__23_intnl_SystemBoolean");
        Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingDataType>(PatronCredits, "__0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType");
        Private___15_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__15_intnl_SystemInt32");
        Private___0_intnl_VRCSDKBaseVRCPlayerApiArray = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(PatronCredits, "__0_intnl_VRCSDKBaseVRCPlayerApiArray");
        Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__12_intnl_SystemInt32");
        Private___52_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__52_intnl_SystemBoolean");
        Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__3_const_intnl_SystemString");
        Private___6_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__6_const_intnl_SystemInt32");
        Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__3_const_intnl_exitJumpLoc_UInt32");
        Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__26_intnl_SystemBoolean");
        Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__0_const_intnl_SystemBoolean");
        Private___41_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__41_intnl_SystemBoolean");
        Private___1_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__1_intnl_UnityEngineTransform");
        Private___3_const_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__3_const_intnl_SystemSingle");
        Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__1_const_intnl_SystemInt32");
        Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__1_intnl_SystemInt32");
        Private_tierColors = new AstroUdonVariable<UnityEngine.Color[]>(PatronCredits, "tierColors");
        Private___1_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__1_intnl_SystemString");
        Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(PatronCredits, "__0_const_intnl_VRCUdonCommonEnumsEventTiming");
        Private___1_i_Int32 = new AstroUdonVariable<int>(PatronCredits, "__1_i_Int32");
        Private___1_p_Int32 = new AstroUdonVariable<int>(PatronCredits, "__1_p_Int32");
        Private___1_t_Int32 = new AstroUdonVariable<int>(PatronCredits, "__1_t_Int32");
        Private___0_i_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_i_Int32");
        Private___0_c_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_c_Int32");
        Private___0_b_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_b_Int32");
        Private___0_p_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_p_Int32");
        Private___0_t_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_t_Int32");
        Private___3_i_Int32 = new AstroUdonVariable<int>(PatronCredits, "__3_i_Int32");
        Private___2_i_Int32 = new AstroUdonVariable<int>(PatronCredits, "__2_i_Int32");
        Private_notPresentFlairObjects = new AstroUdonVariable<UnityEngine.GameObject>(PatronCredits, "notPresentFlairObjects");
        Private_textureTransferCamera = new AstroUdonVariable<UnityEngine.Camera>(PatronCredits, "textureTransferCamera");
        Private___2_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "__2_intnl_VRCSDKBaseVRCPlayerApi");
        Private___0_headTracking_TrackingData = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingData>(PatronCredits, "__0_headTracking_TrackingData");
        Private_presentObjects = new AstroUdonVariable<UnityEngine.GameObject>(PatronCredits, "presentObjects");
        Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__0_const_intnl_SystemString");
        Private___42_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__42_intnl_SystemBoolean");
        Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__0_const_intnl_SystemSingle");
        Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__29_intnl_SystemBoolean");
        Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__1_intnl_SystemSingle");
        Private___0_shouldRefreshPortrait_Boolean = new AstroUdonVariable<bool>(PatronCredits, "__0_shouldRefreshPortrait_Boolean");
        Private___7_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__7_const_intnl_SystemInt32");
        Private_PLAYER_COUNT = new AstroUdonVariable<int>(PatronCredits, "PLAYER_COUNT");
        Private___0_outputBytes_ByteArray = new AstroUdonVariable<byte[]>(PatronCredits, "__0_outputBytes_ByteArray");
        Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__5_intnl_SystemBoolean");
        Private_patronNameText = new AstroUdonVariable<UnityEngine.UI.Text>(PatronCredits, "patronNameText");
        Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__5_intnl_SystemInt32");
        Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__0_const_intnl_exitJumpLoc_UInt32");
        Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__15_intnl_SystemBoolean");
        Private___1_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "__1_intnl_VRCSDKBaseVRCPlayerApi");
        Private_checkingPlayer = new AstroUdonVariable<int>(PatronCredits, "checkingPlayer");
        Private___5_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__5_intnl_SystemString");
        Private___34_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__34_intnl_SystemBoolean");
        Private___2_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__2_intnl_UnityEngineTransform");
        Private___1_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__1_intnl_SystemStringArray");
        Private___1_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatronCredits, "__1_const_intnl_SystemCharArray");
        Private_currentPortraitPlayerID = new AstroUdonVariable<int>(PatronCredits, "currentPortraitPlayerID");
        Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__6_const_intnl_SystemString");
        Private___0_isPresent_Boolean = new AstroUdonVariable<bool>(PatronCredits, "__0_isPresent_Boolean");
        Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__21_intnl_SystemBoolean");
        Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__5_const_intnl_exitJumpLoc_UInt32");
        Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__13_intnl_SystemBoolean");
        Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__1_const_intnl_SystemString");
        Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__4_const_intnl_SystemInt32");
        Private___1_const_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__1_const_intnl_SystemSingle");
        Private___0_const_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__0_const_intnl_SystemChar");
        Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__5_intnl_SystemSingle");
        Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__2_const_intnl_exitJumpLoc_UInt32");
        Private___18_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__18_intnl_SystemInt32");
        Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__16_intnl_SystemBoolean");
        Private_outputColors = new AstroUdonVariable<UnityEngine.Color[]>(PatronCredits, "outputColors");
        Private___0_patronsPresent_Boolean = new AstroUdonVariable<bool>(PatronCredits, "__0_patronsPresent_Boolean");
        Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__14_const_intnl_SystemString");
        Private___9_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__9_intnl_UnityEngineVector3");
        Private___0_success_Boolean = new AstroUdonVariable<bool>(PatronCredits, "__0_success_Boolean");
        Private_portraitCamera = new AstroUdonVariable<UnityEngine.Camera>(PatronCredits, "portraitCamera");
        Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__7_intnl_SystemBoolean");
        Private___20_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__20_intnl_SystemInt32");
        Private___3_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__3_intnl_SystemStringArray");
        Private_loadingObjects = new AstroUdonVariable<UnityEngine.GameObject>(PatronCredits, "loadingObjects");
        Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__22_intnl_SystemBoolean");
        Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__7_const_intnl_exitJumpLoc_UInt32");
        Private___8_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__8_intnl_UnityEngineVector3");
        Private___23_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__23_intnl_SystemInt32");
        Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__7_const_intnl_SystemString");
        Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__15_const_intnl_SystemString");
        Private___5_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__5_const_intnl_SystemInt32");
        Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(PatronCredits, "__refl_const_intnl_udonTypeID");
        Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__4_intnl_SystemBoolean");
        Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__11_intnl_SystemSingle");
        Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__19_intnl_SystemBoolean");
        Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(PatronCredits, "__refl_const_intnl_udonTypeName");
        Private___1_const_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__1_const_intnl_SystemChar");
        Private___0_meshRenderer_MeshRenderer = new AstroUdonVariable<UnityEngine.MeshRenderer>(PatronCredits, "__0_meshRenderer_MeshRenderer");
        Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__1_intnl_SystemBoolean");
        Private___38_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__38_intnl_SystemBoolean");
        Private___14_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__14_intnl_SystemInt32");
        Private___7_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__7_intnl_UnityEngineVector3");
        Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__17_const_intnl_SystemString");
        Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__11_intnl_SystemInt32");
        Private___17_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__17_intnl_SystemInt32");
        Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__4_const_intnl_SystemString");
        Private___0_byte0_Byte = new AstroUdonVariable<byte>(PatronCredits, "__0_byte0_Byte");
        Private___0_byte1_Byte = new AstroUdonVariable<byte>(PatronCredits, "__0_byte1_Byte");
        Private___10_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__10_intnl_SystemString");
        Private_localPlayerIsPatron = new AstroUdonVariable<bool>(PatronCredits, "localPlayerIsPatron");
        Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__11_intnl_SystemBoolean");
        Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__2_intnl_SystemInt32");
        Private___0_imageTransform_Transform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__0_imageTransform_Transform");
        Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__4_const_intnl_exitJumpLoc_UInt32");
        Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__30_intnl_SystemBoolean");
        Private___26_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__26_intnl_SystemInt32");
        Private___54_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__54_intnl_SystemBoolean");
        Private___2_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__2_intnl_SystemString");
        Private_players = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(PatronCredits, "players");
        Private_lastPortraitPlayerID = new AstroUdonVariable<int>(PatronCredits, "lastPortraitPlayerID");
        Private_pedestal = new AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal>(PatronCredits, "pedestal");
        Private___37_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__37_intnl_SystemBoolean");
        Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__9_intnl_SystemInt32");
        Private___6_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__6_intnl_UnityEngineVector3");
        Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__2_intnl_SystemSingle");
        Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__5_const_intnl_SystemString");
        Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__3_intnl_SystemBoolean");
        Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__12_intnl_SystemBoolean");
        Private___9_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__9_intnl_SystemString");
        Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__6_const_intnl_exitJumpLoc_UInt32");
        Private_presentPatronCountText = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PatronCredits, "presentPatronCountText");
        Private___5_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__5_intnl_UnityEngineVector3");
        Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__6_intnl_SystemInt32");
        Private_currentPortraitTier = new AstroUdonVariable<int>(PatronCredits, "currentPortraitTier");
        Private___44_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__44_intnl_SystemBoolean");
        Private___0_intnl_UnityEngineRect = new AstroUdonVariable<UnityEngine.Rect>(PatronCredits, "__0_intnl_UnityEngineRect");
        Private___0_this_intnl_PatreonCredits = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatronCredits, "__0_this_intnl_PatreonCredits");
        Private___6_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__6_intnl_SystemString");
        Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__0_intnl_SystemBoolean");
        Private___4_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__4_intnl_UnityEngineVector3");
        Private___0_patronName_String = new AstroUdonVariable<string>(PatronCredits, "__0_patronName_String");
        Private___0_newTier_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_newTier_Int32");
        Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__9_intnl_SystemSingle");
        Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__12_const_intnl_SystemString");
        Private___0_mp_input_String = new AstroUdonVariable<string>(PatronCredits, "__0_mp_input_String");
        Private___0_outputString_String = new AstroUdonVariable<string>(PatronCredits, "__0_outputString_String");
        Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__8_const_intnl_SystemString");
        Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__6_intnl_SystemSingle");
        Private_notPresentObjects = new AstroUdonVariable<UnityEngine.GameObject>(PatronCredits, "notPresentObjects");
        Private___0_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(PatronCredits, "__0_intnl_UnityEngineQuaternion");
        Private_onPlayerJoinedPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "onPlayerJoinedPlayer");
        Private___0_outputChars_CharArray = new AstroUdonVariable<char[]>(PatronCredits, "__0_outputChars_CharArray");
        Private___0_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatronCredits, "__0_intnl_SystemCharArray");
        Private_tierNames = new AstroUdonVariable<string[]>(PatronCredits, "tierNames");
        Private___29_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__29_intnl_SystemInt32");
        Private___35_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__35_intnl_SystemBoolean");
        Private___50_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__50_intnl_SystemBoolean");
        Private___0_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatronCredits, "__0_const_intnl_SystemCharArray");
        Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__24_intnl_SystemBoolean");
        Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__0_intnl_SystemInt32");
        Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__0_intnl_returnTarget_UInt32");
        Private___48_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__48_intnl_SystemBoolean");
        Private___0_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__0_intnl_SystemString");
        Private___33_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__33_intnl_SystemBoolean");
        Private___0_mp_playerName_String = new AstroUdonVariable<string>(PatronCredits, "__0_mp_playerName_String");
        Private___0_rowString_String = new AstroUdonVariable<string>(PatronCredits, "__0_rowString_String");
        Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__10_intnl_SystemInt32");
        Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(PatronCredits, "__0_const_intnl_SystemUInt32");
        Private_nextCyclePortraitTime = new AstroUdonVariable<float>(PatronCredits, "nextCyclePortraitTime");
        Private___10_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__10_intnl_UnityEngineVector3");
        Private___0_pedestalTransform_Transform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__0_pedestalTransform_Transform");
        Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__9_intnl_SystemBoolean");
        Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__13_intnl_SystemInt32");
        Private___36_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__36_intnl_SystemBoolean");
        Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__0_intnl_SystemSingle");
        Private_playerTiers = new AstroUdonVariable<int[]>(PatronCredits, "playerTiers");
        Private___12_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__12_intnl_SystemString");
        Private___0_currentTier_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_currentTier_Int32");
        Private___40_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__40_intnl_SystemBoolean");
        Private___25_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__25_intnl_SystemInt32");
        Private___4_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__4_intnl_SystemStringArray");
        Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__13_intnl_SystemSingle");
        Private___22_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__22_intnl_SystemInt32");
        Private___0_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "__0_mp_player_VRCPlayerApi");
        Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__4_intnl_SystemInt32");
        Private_currentPortraitPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "currentPortraitPlayer");
        Private___14_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__14_intnl_SystemSingle");
        Private___3_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__3_intnl_UnityEngineVector3");
        Private___47_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__47_intnl_SystemBoolean");
        Private___4_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__4_intnl_SystemString");
        Private___4_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__4_intnl_UnityEngineTransform");
        Private___39_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__39_intnl_SystemBoolean");
        Private_textureTransferInput = new AstroUdonVariable<UnityEngine.UI.RawImage>(PatronCredits, "textureTransferInput");
        Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__28_intnl_SystemBoolean");
        Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__6_intnl_SystemBoolean");
        Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__4_intnl_SystemSingle");
        Private___0_patronRows_StringArray = new AstroUdonVariable<string[]>(PatronCredits, "__0_patronRows_StringArray");
        Private___11_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__11_intnl_SystemString");
        Private___16_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__16_intnl_SystemInt32");
        Private___0_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "__0_intnl_VRCSDKBaseVRCPlayerApi");
        Private___4_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "__4_intnl_VRCSDKBaseVRCPlayerApi");
        Private_patronTierText = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PatronCredits, "patronTierText");
        Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__12_intnl_SystemSingle");
        Private___0_tierStrings_StringArray = new AstroUdonVariable<string[]>(PatronCredits, "__0_tierStrings_StringArray");
        Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__14_intnl_SystemBoolean");
        Private___0_texture_Texture = new AstroUdonVariable<UnityEngine.Texture2D>(PatronCredits, "__0_texture_Texture");
        Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__3_intnl_SystemInt32");
        Private_RETRY_DELAY = new AstroUdonVariable<int>(PatronCredits, "RETRY_DELAY");
        Private___31_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__31_intnl_SystemBoolean");
        Private_patronData = new AstroUdonVariable<System.Object[]>(PatronCredits, "patronData");
        Private___55_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__55_intnl_SystemBoolean");
        Private___0_texture2D_Texture2D = new AstroUdonVariable<UnityEngine.Texture2D>(PatronCredits, "__0_texture2D_Texture2D");
        Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__8_intnl_SystemBoolean");
        Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__20_intnl_SystemBoolean");
        Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__2_intnl_UnityEngineVector3");
        Private___3_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__3_intnl_SystemString");
        Private___7_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__7_intnl_UnityEngineTransform");
        Private___0_intnl_SystemByte = new AstroUdonVariable<byte>(PatronCredits, "__0_intnl_SystemByte");
        Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__1_intnl_UnityEngineVector3");
        Private___2_const_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__2_const_intnl_SystemChar");
        Private___53_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__53_intnl_SystemBoolean");
        Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__27_intnl_SystemBoolean");
        Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__2_const_intnl_SystemInt32");
        Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__3_intnl_SystemSingle");
        Private___0_tier_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_tier_Int32");
        Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__0_intnl_UnityEngineVector3");
        Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__10_const_intnl_SystemString");
        Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__32_intnl_SystemBoolean");
        Private_transferTexture = new AstroUdonVariable<UnityEngine.Texture2D>(PatronCredits, "transferTexture");
        Private___45_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__45_intnl_SystemBoolean");
        Private___28_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__28_intnl_SystemInt32");
        Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__7_intnl_SystemInt32");
        Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__0_intnl_UnityEngineTransform");
        Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__1_const_intnl_SystemBoolean");
        Private___0_presentPatronCount_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_presentPatronCount_Int32");
        Private___0_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(PatronCredits, "__0_intnl_UnityEngineColor");
        Private___7_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__7_intnl_SystemString");
        Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__11_const_intnl_SystemString");
        Private___0_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__0_intnl_SystemStringArray");
        Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__16_const_intnl_SystemString");
        Private_cyclePortraitInterval = new AstroUdonVariable<float>(PatronCredits, "cyclePortraitInterval");
        Private___2_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__2_intnl_SystemStringArray");
        Private___43_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__43_intnl_SystemBoolean");
        Private___5_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__5_intnl_UnityEngineTransform");
        Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__18_intnl_SystemBoolean");
        Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__2_intnl_SystemBoolean");
        Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__10_intnl_SystemSingle");
        Private___11_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(PatronCredits, "__11_intnl_UnityEngineVector3");
        Private___3_const_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__3_const_intnl_SystemChar");
        Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__3_const_intnl_SystemInt32");
        Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__7_intnl_SystemSingle");
        Private___0_isValidTrackingData_Boolean = new AstroUdonVariable<bool>(PatronCredits, "__0_isValidTrackingData_Boolean");
        Private___46_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__46_intnl_SystemBoolean");
        Private___0_intnl_returnValSymbol_String = new AstroUdonVariable<string>(PatronCredits, "__0_intnl_returnValSymbol_String");
        Private_refreshPortraitTime = new AstroUdonVariable<float>(PatronCredits, "refreshPortraitTime");
        Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__13_const_intnl_SystemString");
        Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__8_intnl_SystemInt32");
        Private___19_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__19_intnl_SystemInt32");
        Private___2_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatronCredits, "__2_const_intnl_SystemCharArray");
        Private___24_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__24_intnl_SystemInt32");
        Private___8_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__8_intnl_SystemString");
        Private___3_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__3_intnl_UnityEngineTransform");
        Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__10_intnl_SystemBoolean");
        Private___2_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(PatronCredits, "__2_intnl_UnityEngineColor");
        Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__2_const_intnl_SystemString");
        Private___21_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__21_intnl_SystemInt32");
        Private___27_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__27_intnl_SystemInt32");
        Private___2_const_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__2_const_intnl_SystemSingle");
        Private___51_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__51_intnl_SystemBoolean");
        Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__0_const_intnl_SystemInt32");
        Private___0_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__0_intnl_SystemChar");
        Private_patronPresentFlairObjects = new AstroUdonVariable<UnityEngine.GameObject>(PatronCredits, "patronPresentFlairObjects");
        Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__1_const_intnl_exitJumpLoc_UInt32");
        Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__25_intnl_SystemBoolean");
        Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__8_intnl_SystemSingle");
        Private___1_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(PatronCredits, "__1_intnl_UnityEngineColor");
        Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__17_intnl_SystemBoolean");
        Private___49_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__49_intnl_SystemBoolean");
        Private___0_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_intnl_returnValSymbol_Int32");
        Private___0_intnl_UnityEngineMaterial = new AstroUdonVariable<UnityEngine.Material>(PatronCredits, "__0_intnl_UnityEngineMaterial");
    }

    private void Cleanup_PatronCredits()
    {
        Private_retries = null;
        Private___6_intnl_UnityEngineTransform = null;
        Private___23_intnl_SystemBoolean = null;
        Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType = null;
        Private___15_intnl_SystemInt32 = null;
        Private___0_intnl_VRCSDKBaseVRCPlayerApiArray = null;
        Private___12_intnl_SystemInt32 = null;
        Private___52_intnl_SystemBoolean = null;
        Private___3_const_intnl_SystemString = null;
        Private___6_const_intnl_SystemInt32 = null;
        Private___3_const_intnl_exitJumpLoc_UInt32 = null;
        Private___26_intnl_SystemBoolean = null;
        Private___0_const_intnl_SystemBoolean = null;
        Private___41_intnl_SystemBoolean = null;
        Private___1_intnl_UnityEngineTransform = null;
        Private___3_const_intnl_SystemSingle = null;
        Private___1_const_intnl_SystemInt32 = null;
        Private___1_intnl_SystemInt32 = null;
        Private_tierColors = null;
        Private___1_intnl_SystemString = null;
        Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = null;
        Private___1_i_Int32 = null;
        Private___1_p_Int32 = null;
        Private___1_t_Int32 = null;
        Private___0_i_Int32 = null;
        Private___0_c_Int32 = null;
        Private___0_b_Int32 = null;
        Private___0_p_Int32 = null;
        Private___0_t_Int32 = null;
        Private___3_i_Int32 = null;
        Private___2_i_Int32 = null;
        Private_notPresentFlairObjects = null;
        Private_textureTransferCamera = null;
        Private___2_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private___0_headTracking_TrackingData = null;
        Private_presentObjects = null;
        Private___0_const_intnl_SystemString = null;
        Private___42_intnl_SystemBoolean = null;
        Private___0_const_intnl_SystemSingle = null;
        Private___29_intnl_SystemBoolean = null;
        Private___1_intnl_SystemSingle = null;
        Private___0_shouldRefreshPortrait_Boolean = null;
        Private___7_const_intnl_SystemInt32 = null;
        Private_PLAYER_COUNT = null;
        Private___0_outputBytes_ByteArray = null;
        Private___5_intnl_SystemBoolean = null;
        Private_patronNameText = null;
        Private___5_intnl_SystemInt32 = null;
        Private___0_const_intnl_exitJumpLoc_UInt32 = null;
        Private___15_intnl_SystemBoolean = null;
        Private___1_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private_checkingPlayer = null;
        Private___5_intnl_SystemString = null;
        Private___34_intnl_SystemBoolean = null;
        Private___2_intnl_UnityEngineTransform = null;
        Private___1_intnl_SystemStringArray = null;
        Private___1_const_intnl_SystemCharArray = null;
        Private_currentPortraitPlayerID = null;
        Private___6_const_intnl_SystemString = null;
        Private___0_isPresent_Boolean = null;
        Private___21_intnl_SystemBoolean = null;
        Private___5_const_intnl_exitJumpLoc_UInt32 = null;
        Private___13_intnl_SystemBoolean = null;
        Private___1_const_intnl_SystemString = null;
        Private___4_const_intnl_SystemInt32 = null;
        Private___1_const_intnl_SystemSingle = null;
        Private___0_const_intnl_SystemChar = null;
        Private___5_intnl_SystemSingle = null;
        Private___2_const_intnl_exitJumpLoc_UInt32 = null;
        Private___18_intnl_SystemInt32 = null;
        Private___16_intnl_SystemBoolean = null;
        Private_outputColors = null;
        Private___0_patronsPresent_Boolean = null;
        Private___14_const_intnl_SystemString = null;
        Private___9_intnl_UnityEngineVector3 = null;
        Private___0_success_Boolean = null;
        Private_portraitCamera = null;
        Private___7_intnl_SystemBoolean = null;
        Private___20_intnl_SystemInt32 = null;
        Private___3_intnl_SystemStringArray = null;
        Private_loadingObjects = null;
        Private___22_intnl_SystemBoolean = null;
        Private___7_const_intnl_exitJumpLoc_UInt32 = null;
        Private___8_intnl_UnityEngineVector3 = null;
        Private___23_intnl_SystemInt32 = null;
        Private___7_const_intnl_SystemString = null;
        Private___15_const_intnl_SystemString = null;
        Private___5_const_intnl_SystemInt32 = null;
        Private___refl_const_intnl_udonTypeID = null;
        Private___4_intnl_SystemBoolean = null;
        Private___11_intnl_SystemSingle = null;
        Private___19_intnl_SystemBoolean = null;
        Private___refl_const_intnl_udonTypeName = null;
        Private___1_const_intnl_SystemChar = null;
        Private___0_meshRenderer_MeshRenderer = null;
        Private___1_intnl_SystemBoolean = null;
        Private___38_intnl_SystemBoolean = null;
        Private___14_intnl_SystemInt32 = null;
        Private___7_intnl_UnityEngineVector3 = null;
        Private___17_const_intnl_SystemString = null;
        Private___11_intnl_SystemInt32 = null;
        Private___17_intnl_SystemInt32 = null;
        Private___4_const_intnl_SystemString = null;
        Private___0_byte0_Byte = null;
        Private___0_byte1_Byte = null;
        Private___10_intnl_SystemString = null;
        Private_localPlayerIsPatron = null;
        Private___11_intnl_SystemBoolean = null;
        Private___2_intnl_SystemInt32 = null;
        Private___0_imageTransform_Transform = null;
        Private___4_const_intnl_exitJumpLoc_UInt32 = null;
        Private___30_intnl_SystemBoolean = null;
        Private___26_intnl_SystemInt32 = null;
        Private___54_intnl_SystemBoolean = null;
        Private___2_intnl_SystemString = null;
        Private_players = null;
        Private_lastPortraitPlayerID = null;
        Private_pedestal = null;
        Private___37_intnl_SystemBoolean = null;
        Private___9_intnl_SystemInt32 = null;
        Private___6_intnl_UnityEngineVector3 = null;
        Private___2_intnl_SystemSingle = null;
        Private___5_const_intnl_SystemString = null;
        Private___3_intnl_SystemBoolean = null;
        Private___12_intnl_SystemBoolean = null;
        Private___9_intnl_SystemString = null;
        Private___6_const_intnl_exitJumpLoc_UInt32 = null;
        Private_presentPatronCountText = null;
        Private___5_intnl_UnityEngineVector3 = null;
        Private___6_intnl_SystemInt32 = null;
        Private_currentPortraitTier = null;
        Private___44_intnl_SystemBoolean = null;
        Private___0_intnl_UnityEngineRect = null;
        Private___0_this_intnl_PatreonCredits = null;
        Private___6_intnl_SystemString = null;
        Private___0_intnl_SystemBoolean = null;
        Private___4_intnl_UnityEngineVector3 = null;
        Private___0_patronName_String = null;
        Private___0_newTier_Int32 = null;
        Private___9_intnl_SystemSingle = null;
        Private___12_const_intnl_SystemString = null;
        Private___0_mp_input_String = null;
        Private___0_outputString_String = null;
        Private___8_const_intnl_SystemString = null;
        Private___6_intnl_SystemSingle = null;
        Private_notPresentObjects = null;
        Private___0_intnl_UnityEngineQuaternion = null;
        Private_onPlayerJoinedPlayer = null;
        Private___0_outputChars_CharArray = null;
        Private___0_intnl_SystemCharArray = null;
        Private_tierNames = null;
        Private___29_intnl_SystemInt32 = null;
        Private___35_intnl_SystemBoolean = null;
        Private___50_intnl_SystemBoolean = null;
        Private___0_const_intnl_SystemCharArray = null;
        Private___24_intnl_SystemBoolean = null;
        Private___0_intnl_SystemInt32 = null;
        Private___0_intnl_returnTarget_UInt32 = null;
        Private___48_intnl_SystemBoolean = null;
        Private___0_intnl_SystemString = null;
        Private___33_intnl_SystemBoolean = null;
        Private___0_mp_playerName_String = null;
        Private___0_rowString_String = null;
        Private___10_intnl_SystemInt32 = null;
        Private___0_const_intnl_SystemUInt32 = null;
        Private_nextCyclePortraitTime = null;
        Private___10_intnl_UnityEngineVector3 = null;
        Private___0_pedestalTransform_Transform = null;
        Private___9_intnl_SystemBoolean = null;
        Private___13_intnl_SystemInt32 = null;
        Private___36_intnl_SystemBoolean = null;
        Private___0_intnl_SystemSingle = null;
        Private_playerTiers = null;
        Private___12_intnl_SystemString = null;
        Private___0_currentTier_Int32 = null;
        Private___40_intnl_SystemBoolean = null;
        Private___25_intnl_SystemInt32 = null;
        Private___4_intnl_SystemStringArray = null;
        Private___13_intnl_SystemSingle = null;
        Private___22_intnl_SystemInt32 = null;
        Private___0_mp_player_VRCPlayerApi = null;
        Private___4_intnl_SystemInt32 = null;
        Private_currentPortraitPlayer = null;
        Private___14_intnl_SystemSingle = null;
        Private___3_intnl_UnityEngineVector3 = null;
        Private___47_intnl_SystemBoolean = null;
        Private___4_intnl_SystemString = null;
        Private___4_intnl_UnityEngineTransform = null;
        Private___39_intnl_SystemBoolean = null;
        Private_textureTransferInput = null;
        Private___28_intnl_SystemBoolean = null;
        Private___6_intnl_SystemBoolean = null;
        Private___4_intnl_SystemSingle = null;
        Private___0_patronRows_StringArray = null;
        Private___11_intnl_SystemString = null;
        Private___16_intnl_SystemInt32 = null;
        Private___0_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private___4_intnl_VRCSDKBaseVRCPlayerApi = null;
        Private_patronTierText = null;
        Private___12_intnl_SystemSingle = null;
        Private___0_tierStrings_StringArray = null;
        Private___14_intnl_SystemBoolean = null;
        Private___0_texture_Texture = null;
        Private___3_intnl_SystemInt32 = null;
        Private_RETRY_DELAY = null;
        Private___31_intnl_SystemBoolean = null;
        Private_patronData = null;
        Private___55_intnl_SystemBoolean = null;
        Private___0_texture2D_Texture2D = null;
        Private___8_intnl_SystemBoolean = null;
        Private___20_intnl_SystemBoolean = null;
        Private___2_intnl_UnityEngineVector3 = null;
        Private___3_intnl_SystemString = null;
        Private___7_intnl_UnityEngineTransform = null;
        Private___0_intnl_SystemByte = null;
        Private___1_intnl_UnityEngineVector3 = null;
        Private___2_const_intnl_SystemChar = null;
        Private___53_intnl_SystemBoolean = null;
        Private___27_intnl_SystemBoolean = null;
        Private___2_const_intnl_SystemInt32 = null;
        Private___3_intnl_SystemSingle = null;
        Private___0_tier_Int32 = null;
        Private___0_intnl_UnityEngineVector3 = null;
        Private___10_const_intnl_SystemString = null;
        Private___32_intnl_SystemBoolean = null;
        Private_transferTexture = null;
        Private___45_intnl_SystemBoolean = null;
        Private___28_intnl_SystemInt32 = null;
        Private___7_intnl_SystemInt32 = null;
        Private___0_intnl_UnityEngineTransform = null;
        Private___1_const_intnl_SystemBoolean = null;
        Private___0_presentPatronCount_Int32 = null;
        Private___0_intnl_UnityEngineColor = null;
        Private___7_intnl_SystemString = null;
        Private___11_const_intnl_SystemString = null;
        Private___0_intnl_SystemStringArray = null;
        Private___16_const_intnl_SystemString = null;
        Private_cyclePortraitInterval = null;
        Private___2_intnl_SystemStringArray = null;
        Private___43_intnl_SystemBoolean = null;
        Private___5_intnl_UnityEngineTransform = null;
        Private___18_intnl_SystemBoolean = null;
        Private___2_intnl_SystemBoolean = null;
        Private___10_intnl_SystemSingle = null;
        Private___11_intnl_UnityEngineVector3 = null;
        Private___3_const_intnl_SystemChar = null;
        Private___3_const_intnl_SystemInt32 = null;
        Private___7_intnl_SystemSingle = null;
        Private___0_isValidTrackingData_Boolean = null;
        Private___46_intnl_SystemBoolean = null;
        Private___0_intnl_returnValSymbol_String = null;
        Private_refreshPortraitTime = null;
        Private___13_const_intnl_SystemString = null;
        Private___8_intnl_SystemInt32 = null;
        Private___19_intnl_SystemInt32 = null;
        Private___2_const_intnl_SystemCharArray = null;
        Private___24_intnl_SystemInt32 = null;
        Private___8_intnl_SystemString = null;
        Private___3_intnl_UnityEngineTransform = null;
        Private___10_intnl_SystemBoolean = null;
        Private___2_intnl_UnityEngineColor = null;
        Private___2_const_intnl_SystemString = null;
        Private___21_intnl_SystemInt32 = null;
        Private___27_intnl_SystemInt32 = null;
        Private___2_const_intnl_SystemSingle = null;
        Private___51_intnl_SystemBoolean = null;
        Private___0_const_intnl_SystemInt32 = null;
        Private___0_intnl_SystemChar = null;
        Private_patronPresentFlairObjects = null;
        Private___1_const_intnl_exitJumpLoc_UInt32 = null;
        Private___25_intnl_SystemBoolean = null;
        Private___8_intnl_SystemSingle = null;
        Private___1_intnl_UnityEngineColor = null;
        Private___17_intnl_SystemBoolean = null;
        Private___49_intnl_SystemBoolean = null;
        Private___0_intnl_returnValSymbol_Int32 = null;
        Private___0_intnl_UnityEngineMaterial = null;
    }

    #region Getter / Setters AstroUdonVariables  of PatronCredits

    internal int? retries
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_retries != null)
            {
                return Private_retries.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_retries != null)
                {
                    Private_retries.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Transform __6_intnl_UnityEngineTransform
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

    internal VRC.SDKBase.VRCPlayerApi.TrackingDataType? __0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType != null)
            {
                return Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType != null)
                {
                    Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType.Value = value.Value;
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

    internal VRC.SDKBase.VRCPlayerApi[] __0_intnl_VRCSDKBaseVRCPlayerApiArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_VRCSDKBaseVRCPlayerApiArray != null)
            {
                return Private___0_intnl_VRCSDKBaseVRCPlayerApiArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_VRCSDKBaseVRCPlayerApiArray != null)
            {
                Private___0_intnl_VRCSDKBaseVRCPlayerApiArray.Value = value;
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

    internal float? __3_const_intnl_SystemSingle
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_const_intnl_SystemSingle != null)
            {
                return Private___3_const_intnl_SystemSingle.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_const_intnl_SystemSingle != null)
                {
                    Private___3_const_intnl_SystemSingle.Value = value.Value;
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

    internal UnityEngine.Color[] tierColors
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_tierColors != null)
            {
                return Private_tierColors.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_tierColors != null)
            {
                Private_tierColors.Value = value;
            }
        }
    }

    internal string __1_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemString != null)
            {
                return Private___1_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_intnl_SystemString != null)
            {
                Private___1_intnl_SystemString.Value = value;
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

    internal int? __1_p_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_p_Int32 != null)
            {
                return Private___1_p_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_p_Int32 != null)
                {
                    Private___1_p_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __1_t_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_t_Int32 != null)
            {
                return Private___1_t_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_t_Int32 != null)
                {
                    Private___1_t_Int32.Value = value.Value;
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

    internal int? __0_c_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_c_Int32 != null)
            {
                return Private___0_c_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_c_Int32 != null)
                {
                    Private___0_c_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __0_b_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_b_Int32 != null)
            {
                return Private___0_b_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_b_Int32 != null)
                {
                    Private___0_b_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __0_p_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_p_Int32 != null)
            {
                return Private___0_p_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_p_Int32 != null)
                {
                    Private___0_p_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __0_t_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_t_Int32 != null)
            {
                return Private___0_t_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_t_Int32 != null)
                {
                    Private___0_t_Int32.Value = value.Value;
                }
            }
        }
    }

    internal int? __3_i_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_i_Int32 != null)
            {
                return Private___3_i_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_i_Int32 != null)
                {
                    Private___3_i_Int32.Value = value.Value;
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

    internal UnityEngine.GameObject notPresentFlairObjects
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_notPresentFlairObjects != null)
            {
                return Private_notPresentFlairObjects.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_notPresentFlairObjects != null)
            {
                Private_notPresentFlairObjects.Value = value;
            }
        }
    }

    internal UnityEngine.Camera textureTransferCamera
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_textureTransferCamera != null)
            {
                return Private_textureTransferCamera.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_textureTransferCamera != null)
            {
                Private_textureTransferCamera.Value = value;
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi __2_intnl_VRCSDKBaseVRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                return Private___2_intnl_VRCSDKBaseVRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                Private___2_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
            }
        }
    }

    internal VRC.SDKBase.VRCPlayerApi.TrackingData? __0_headTracking_TrackingData
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_headTracking_TrackingData != null)
            {
                return Private___0_headTracking_TrackingData.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_headTracking_TrackingData != null)
                {
                    Private___0_headTracking_TrackingData.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject presentObjects
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_presentObjects != null)
            {
                return Private_presentObjects.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_presentObjects != null)
            {
                Private_presentObjects.Value = value;
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

    internal bool? __0_shouldRefreshPortrait_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_shouldRefreshPortrait_Boolean != null)
            {
                return Private___0_shouldRefreshPortrait_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_shouldRefreshPortrait_Boolean != null)
                {
                    Private___0_shouldRefreshPortrait_Boolean.Value = value.Value;
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

    internal int? PLAYER_COUNT
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_PLAYER_COUNT != null)
            {
                return Private_PLAYER_COUNT.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_PLAYER_COUNT != null)
                {
                    Private_PLAYER_COUNT.Value = value.Value;
                }
            }
        }
    }

    internal byte[] __0_outputBytes_ByteArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_outputBytes_ByteArray != null)
            {
                return Private___0_outputBytes_ByteArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_outputBytes_ByteArray != null)
            {
                Private___0_outputBytes_ByteArray.Value = value;
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

    internal UnityEngine.UI.Text patronNameText
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_patronNameText != null)
            {
                return Private_patronNameText.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_patronNameText != null)
            {
                Private_patronNameText.Value = value;
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

    internal int? checkingPlayer
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_checkingPlayer != null)
            {
                return Private_checkingPlayer.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_checkingPlayer != null)
                {
                    Private_checkingPlayer.Value = value.Value;
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

    internal string[] __1_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemStringArray != null)
            {
                return Private___1_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_intnl_SystemStringArray != null)
            {
                Private___1_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal char[] __1_const_intnl_SystemCharArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_const_intnl_SystemCharArray != null)
            {
                return Private___1_const_intnl_SystemCharArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___1_const_intnl_SystemCharArray != null)
            {
                Private___1_const_intnl_SystemCharArray.Value = value;
            }
        }
    }

    internal int? currentPortraitPlayerID
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_currentPortraitPlayerID != null)
            {
                return Private_currentPortraitPlayerID.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_currentPortraitPlayerID != null)
                {
                    Private_currentPortraitPlayerID.Value = value.Value;
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

    internal bool? __0_isPresent_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_isPresent_Boolean != null)
            {
                return Private___0_isPresent_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_isPresent_Boolean != null)
                {
                    Private___0_isPresent_Boolean.Value = value.Value;
                }
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

    internal char? __0_const_intnl_SystemChar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemChar != null)
            {
                return Private___0_const_intnl_SystemChar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_const_intnl_SystemChar != null)
                {
                    Private___0_const_intnl_SystemChar.Value = value.Value;
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

    internal UnityEngine.Color[] outputColors
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_outputColors != null)
            {
                return Private_outputColors.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_outputColors != null)
            {
                Private_outputColors.Value = value;
            }
        }
    }

    internal bool? __0_patronsPresent_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_patronsPresent_Boolean != null)
            {
                return Private___0_patronsPresent_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_patronsPresent_Boolean != null)
                {
                    Private___0_patronsPresent_Boolean.Value = value.Value;
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

    internal UnityEngine.Vector3? __9_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___9_intnl_UnityEngineVector3 != null)
            {
                return Private___9_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___9_intnl_UnityEngineVector3 != null)
                {
                    Private___9_intnl_UnityEngineVector3.Value = value.Value;
                }
            }
        }
    }

    internal bool? __0_success_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_success_Boolean != null)
            {
                return Private___0_success_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_success_Boolean != null)
                {
                    Private___0_success_Boolean.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Camera portraitCamera
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_portraitCamera != null)
            {
                return Private_portraitCamera.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_portraitCamera != null)
            {
                Private_portraitCamera.Value = value;
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

    internal string[] __3_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_SystemStringArray != null)
            {
                return Private___3_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___3_intnl_SystemStringArray != null)
            {
                Private___3_intnl_SystemStringArray.Value = value;
            }
        }
    }

    internal UnityEngine.GameObject loadingObjects
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_loadingObjects != null)
            {
                return Private_loadingObjects.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_loadingObjects != null)
            {
                Private_loadingObjects.Value = value;
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

    internal UnityEngine.Vector3? __8_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___8_intnl_UnityEngineVector3 != null)
            {
                return Private___8_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___8_intnl_UnityEngineVector3 != null)
                {
                    Private___8_intnl_UnityEngineVector3.Value = value.Value;
                }
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

    internal char? __1_const_intnl_SystemChar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_const_intnl_SystemChar != null)
            {
                return Private___1_const_intnl_SystemChar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_const_intnl_SystemChar != null)
                {
                    Private___1_const_intnl_SystemChar.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.MeshRenderer __0_meshRenderer_MeshRenderer
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_meshRenderer_MeshRenderer != null)
            {
                return Private___0_meshRenderer_MeshRenderer.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_meshRenderer_MeshRenderer != null)
            {
                Private___0_meshRenderer_MeshRenderer.Value = value;
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

    internal UnityEngine.Vector3? __7_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_intnl_UnityEngineVector3 != null)
            {
                return Private___7_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___7_intnl_UnityEngineVector3 != null)
                {
                    Private___7_intnl_UnityEngineVector3.Value = value.Value;
                }
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

    internal byte? __0_byte0_Byte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_byte0_Byte != null)
            {
                return Private___0_byte0_Byte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_byte0_Byte != null)
                {
                    Private___0_byte0_Byte.Value = value.Value;
                }
            }
        }
    }

    internal byte? __0_byte1_Byte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_byte1_Byte != null)
            {
                return Private___0_byte1_Byte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_byte1_Byte != null)
                {
                    Private___0_byte1_Byte.Value = value.Value;
                }
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

    internal bool? localPlayerIsPatron
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_localPlayerIsPatron != null)
            {
                return Private_localPlayerIsPatron.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_localPlayerIsPatron != null)
                {
                    Private_localPlayerIsPatron.Value = value.Value;
                }
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

    internal UnityEngine.Transform __0_imageTransform_Transform
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_imageTransform_Transform != null)
            {
                return Private___0_imageTransform_Transform.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_imageTransform_Transform != null)
            {
                Private___0_imageTransform_Transform.Value = value;
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

    internal VRC.SDKBase.VRCPlayerApi[] players
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

    internal int? lastPortraitPlayerID
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_lastPortraitPlayerID != null)
            {
                return Private_lastPortraitPlayerID.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_lastPortraitPlayerID != null)
                {
                    Private_lastPortraitPlayerID.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDK3.Components.VRCAvatarPedestal pedestal
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_pedestal != null)
            {
                return Private_pedestal.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_pedestal != null)
            {
                Private_pedestal.Value = value;
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

    internal UnityEngine.Vector3? __6_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_intnl_UnityEngineVector3 != null)
            {
                return Private___6_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___6_intnl_UnityEngineVector3 != null)
                {
                    Private___6_intnl_UnityEngineVector3.Value = value.Value;
                }
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

    internal TMPro.TextMeshProUGUI presentPatronCountText
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_presentPatronCountText != null)
            {
                return Private_presentPatronCountText.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_presentPatronCountText != null)
            {
                Private_presentPatronCountText.Value = value;
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

    internal int? currentPortraitTier
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_currentPortraitTier != null)
            {
                return Private_currentPortraitTier.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_currentPortraitTier != null)
                {
                    Private_currentPortraitTier.Value = value.Value;
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

    internal UnityEngine.Rect? __0_intnl_UnityEngineRect
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_UnityEngineRect != null)
            {
                return Private___0_intnl_UnityEngineRect.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_UnityEngineRect != null)
                {
                    Private___0_intnl_UnityEngineRect.Value = value.Value;
                }
            }

        }
    }

    internal VRC.Udon.UdonBehaviour __0_this_intnl_PatreonCredits
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_this_intnl_PatreonCredits != null)
            {
                return Private___0_this_intnl_PatreonCredits.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_this_intnl_PatreonCredits != null)
            {
                Private___0_this_intnl_PatreonCredits.Value = value;
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

    internal string __0_patronName_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_patronName_String != null)
            {
                return Private___0_patronName_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_patronName_String != null)
            {
                Private___0_patronName_String.Value = value;
            }
        }
    }

    internal int? __0_newTier_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_newTier_Int32 != null)
            {
                return Private___0_newTier_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_newTier_Int32 != null)
                {
                    Private___0_newTier_Int32.Value = value.Value;
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

    internal string __0_mp_input_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_input_String != null)
            {
                return Private___0_mp_input_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_input_String != null)
            {
                Private___0_mp_input_String.Value = value;
            }
        }
    }

    internal string __0_outputString_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_outputString_String != null)
            {
                return Private___0_outputString_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_outputString_String != null)
            {
                Private___0_outputString_String.Value = value;
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

    internal UnityEngine.GameObject notPresentObjects
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_notPresentObjects != null)
            {
                return Private_notPresentObjects.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_notPresentObjects != null)
            {
                Private_notPresentObjects.Value = value;
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

    internal char[] __0_outputChars_CharArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_outputChars_CharArray != null)
            {
                return Private___0_outputChars_CharArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_outputChars_CharArray != null)
            {
                Private___0_outputChars_CharArray.Value = value;
            }
        }
    }

    internal char[] __0_intnl_SystemCharArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemCharArray != null)
            {
                return Private___0_intnl_SystemCharArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_SystemCharArray != null)
            {
                Private___0_intnl_SystemCharArray.Value = value;
            }
        }
    }

    internal string[] tierNames
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_tierNames != null)
            {
                return Private_tierNames.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_tierNames != null)
            {
                Private_tierNames.Value = value;
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

    internal char[] __0_const_intnl_SystemCharArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_const_intnl_SystemCharArray != null)
            {
                return Private___0_const_intnl_SystemCharArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_const_intnl_SystemCharArray != null)
            {
                Private___0_const_intnl_SystemCharArray.Value = value;
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

    internal string __0_mp_playerName_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_playerName_String != null)
            {
                return Private___0_mp_playerName_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_playerName_String != null)
            {
                Private___0_mp_playerName_String.Value = value;
            }
        }
    }

    internal string __0_rowString_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_rowString_String != null)
            {
                return Private___0_rowString_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_rowString_String != null)
            {
                Private___0_rowString_String.Value = value;
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

    internal float? nextCyclePortraitTime
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_nextCyclePortraitTime != null)
            {
                return Private_nextCyclePortraitTime.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_nextCyclePortraitTime != null)
                {
                    Private_nextCyclePortraitTime.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Vector3? __10_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___10_intnl_UnityEngineVector3 != null)
            {
                return Private___10_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___10_intnl_UnityEngineVector3 != null)
                {
                    Private___10_intnl_UnityEngineVector3.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Transform __0_pedestalTransform_Transform
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_pedestalTransform_Transform != null)
            {
                return Private___0_pedestalTransform_Transform.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_pedestalTransform_Transform != null)
            {
                Private___0_pedestalTransform_Transform.Value = value;
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

    internal int[] playerTiers
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_playerTiers != null)
            {
                return Private_playerTiers.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_playerTiers != null)
            {
                Private_playerTiers.Value = value;
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

    internal int? __0_currentTier_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_currentTier_Int32 != null)
            {
                return Private___0_currentTier_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_currentTier_Int32 != null)
                {
                    Private___0_currentTier_Int32.Value = value.Value;
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

    internal string[] __4_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_SystemStringArray != null)
            {
                return Private___4_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___4_intnl_SystemStringArray != null)
            {
                Private___4_intnl_SystemStringArray.Value = value;
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

    internal VRC.SDKBase.VRCPlayerApi __0_mp_player_VRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_player_VRCPlayerApi != null)
            {
                return Private___0_mp_player_VRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_player_VRCPlayerApi != null)
            {
                Private___0_mp_player_VRCPlayerApi.Value = value;
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

    internal VRC.SDKBase.VRCPlayerApi currentPortraitPlayer
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_currentPortraitPlayer != null)
            {
                return Private_currentPortraitPlayer.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_currentPortraitPlayer != null)
            {
                Private_currentPortraitPlayer.Value = value;
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

    internal UnityEngine.UI.RawImage textureTransferInput
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_textureTransferInput != null)
            {
                return Private_textureTransferInput.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_textureTransferInput != null)
            {
                Private_textureTransferInput.Value = value;
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

    internal string[] __0_patronRows_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_patronRows_StringArray != null)
            {
                return Private___0_patronRows_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_patronRows_StringArray != null)
            {
                Private___0_patronRows_StringArray.Value = value;
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

    internal VRC.SDKBase.VRCPlayerApi __0_intnl_VRCSDKBaseVRCPlayerApi
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                return Private___0_intnl_VRCSDKBaseVRCPlayerApi.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_VRCSDKBaseVRCPlayerApi != null)
            {
                Private___0_intnl_VRCSDKBaseVRCPlayerApi.Value = value;
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

    internal TMPro.TextMeshProUGUI patronTierText
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_patronTierText != null)
            {
                return Private_patronTierText.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_patronTierText != null)
            {
                Private_patronTierText.Value = value;
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

    internal string[] __0_tierStrings_StringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_tierStrings_StringArray != null)
            {
                return Private___0_tierStrings_StringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_tierStrings_StringArray != null)
            {
                Private___0_tierStrings_StringArray.Value = value;
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

    internal UnityEngine.Texture2D __0_texture_Texture
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_texture_Texture != null)
            {
                return Private___0_texture_Texture.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_texture_Texture != null)
            {
                Private___0_texture_Texture.Value = value;
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

    internal int? RETRY_DELAY
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_RETRY_DELAY != null)
            {
                return Private_RETRY_DELAY.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_RETRY_DELAY != null)
                {
                    Private_RETRY_DELAY.Value = value.Value;
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

    internal System.Object[] patronData
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_patronData != null)
            {
                return Private_patronData.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_patronData != null)
            {
                Private_patronData.Value = value;
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

    internal UnityEngine.Texture2D __0_texture2D_Texture2D
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_texture2D_Texture2D != null)
            {
                return Private___0_texture2D_Texture2D.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_texture2D_Texture2D != null)
            {
                Private___0_texture2D_Texture2D.Value = value;
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

    internal UnityEngine.Transform __7_intnl_UnityEngineTransform
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

    internal byte? __0_intnl_SystemByte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemByte != null)
            {
                return Private___0_intnl_SystemByte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_SystemByte != null)
                {
                    Private___0_intnl_SystemByte.Value = value.Value;
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

    internal char? __2_const_intnl_SystemChar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_const_intnl_SystemChar != null)
            {
                return Private___2_const_intnl_SystemChar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_const_intnl_SystemChar != null)
                {
                    Private___2_const_intnl_SystemChar.Value = value.Value;
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

    internal int? __0_tier_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_tier_Int32 != null)
            {
                return Private___0_tier_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_tier_Int32 != null)
                {
                    Private___0_tier_Int32.Value = value.Value;
                }
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

    internal UnityEngine.Texture2D transferTexture
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_transferTexture != null)
            {
                return Private_transferTexture.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_transferTexture != null)
            {
                Private_transferTexture.Value = value;
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

    internal UnityEngine.Transform __0_intnl_UnityEngineTransform
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

    internal int? __0_presentPatronCount_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_presentPatronCount_Int32 != null)
            {
                return Private___0_presentPatronCount_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_presentPatronCount_Int32 != null)
                {
                    Private___0_presentPatronCount_Int32.Value = value.Value;
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

    internal string[] __0_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemStringArray != null)
            {
                return Private___0_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_SystemStringArray != null)
            {
                Private___0_intnl_SystemStringArray.Value = value;
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

    internal float? cyclePortraitInterval
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_cyclePortraitInterval != null)
            {
                return Private_cyclePortraitInterval.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_cyclePortraitInterval != null)
                {
                    Private_cyclePortraitInterval.Value = value.Value;
                }
            }
        }
    }

    internal string[] __2_intnl_SystemStringArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_SystemStringArray != null)
            {
                return Private___2_intnl_SystemStringArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_intnl_SystemStringArray != null)
            {
                Private___2_intnl_SystemStringArray.Value = value;
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

    internal UnityEngine.Transform __5_intnl_UnityEngineTransform
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

    internal UnityEngine.Vector3? __11_intnl_UnityEngineVector3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___11_intnl_UnityEngineVector3 != null)
            {
                return Private___11_intnl_UnityEngineVector3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___11_intnl_UnityEngineVector3 != null)
                {
                    Private___11_intnl_UnityEngineVector3.Value = value.Value;
                }
            }
        }
    }

    internal char? __3_const_intnl_SystemChar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_const_intnl_SystemChar != null)
            {
                return Private___3_const_intnl_SystemChar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_const_intnl_SystemChar != null)
                {
                    Private___3_const_intnl_SystemChar.Value = value.Value;
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

    internal bool? __0_isValidTrackingData_Boolean
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_isValidTrackingData_Boolean != null)
            {
                return Private___0_isValidTrackingData_Boolean.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_isValidTrackingData_Boolean != null)
                {
                    Private___0_isValidTrackingData_Boolean.Value = value.Value;
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

    internal string __0_intnl_returnValSymbol_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_returnValSymbol_String != null)
            {
                return Private___0_intnl_returnValSymbol_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_returnValSymbol_String != null)
            {
                Private___0_intnl_returnValSymbol_String.Value = value;
            }
        }
    }

    internal float? refreshPortraitTime
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_refreshPortraitTime != null)
            {
                return Private_refreshPortraitTime.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_refreshPortraitTime != null)
                {
                    Private_refreshPortraitTime.Value = value.Value;
                }
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

    internal char[] __2_const_intnl_SystemCharArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_const_intnl_SystemCharArray != null)
            {
                return Private___2_const_intnl_SystemCharArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___2_const_intnl_SystemCharArray != null)
            {
                Private___2_const_intnl_SystemCharArray.Value = value;
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

    internal UnityEngine.Transform __3_intnl_UnityEngineTransform
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

    internal UnityEngine.Color? __2_intnl_UnityEngineColor
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_UnityEngineColor != null)
            {
                return Private___2_intnl_UnityEngineColor.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_intnl_UnityEngineColor != null)
                {
                    Private___2_intnl_UnityEngineColor.Value = value.Value;
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

    internal float? __2_const_intnl_SystemSingle
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_const_intnl_SystemSingle != null)
            {
                return Private___2_const_intnl_SystemSingle.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_const_intnl_SystemSingle != null)
                {
                    Private___2_const_intnl_SystemSingle.Value = value.Value;
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

    internal char? __0_intnl_SystemChar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemChar != null)
            {
                return Private___0_intnl_SystemChar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_SystemChar != null)
                {
                    Private___0_intnl_SystemChar.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject patronPresentFlairObjects
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_patronPresentFlairObjects != null)
            {
                return Private_patronPresentFlairObjects.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_patronPresentFlairObjects != null)
            {
                Private_patronPresentFlairObjects.Value = value;
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

    internal UnityEngine.Color? __1_intnl_UnityEngineColor
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_UnityEngineColor != null)
            {
                return Private___1_intnl_UnityEngineColor.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_intnl_UnityEngineColor != null)
                {
                    Private___1_intnl_UnityEngineColor.Value = value.Value;
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

    internal UnityEngine.Material __0_intnl_UnityEngineMaterial
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_UnityEngineMaterial != null)
            {
                return Private___0_intnl_UnityEngineMaterial.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_UnityEngineMaterial != null)
            {
                Private___0_intnl_UnityEngineMaterial.Value = value;
            }
        }
    }

    #endregion Getter / Setters AstroUdonVariables  of PatronCredits

    #region AstroUdonVariables  of PatronCredits

    private AstroUdonVariable<int> Private_retries { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___6_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingDataType> Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___15_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private___0_intnl_VRCSDKBaseVRCPlayerApiArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___12_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___52_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___6_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___26_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___41_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___1_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___3_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color[]> Private_tierColors { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___0_const_intnl_VRCUdonCommonEnumsEventTiming { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_p_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_t_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_c_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_b_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_p_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_t_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private_notPresentFlairObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Camera> Private_textureTransferCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___2_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingData> Private___0_headTracking_TrackingData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private_presentObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___42_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___29_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_shouldRefreshPortrait_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___7_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_PLAYER_COUNT { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte[]> Private___0_outputBytes_ByteArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.UI.Text> Private_patronNameText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_checkingPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___34_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___2_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___1_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___1_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_currentPortraitPlayerID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_isPresent_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___1_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___0_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___18_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color[]> Private_outputColors { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_patronsPresent_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___9_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_success_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Camera> Private_portraitCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___20_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___3_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private_loadingObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___8_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___23_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___5_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___11_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___1_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.MeshRenderer> Private___0_meshRenderer_MeshRenderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___38_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___14_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___7_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___11_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___17_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___0_byte0_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___0_byte1_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___10_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_localPlayerIsPatron { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___0_imageTransform_Transform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___30_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___26_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___54_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private_players { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_lastPortraitPlayerID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal> Private_pedestal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___37_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___6_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___9_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_presentPatronCountText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___5_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_currentPortraitTier { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___44_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Rect> Private___0_intnl_UnityEngineRect { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_PatreonCredits { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___6_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___4_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_patronName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_newTier_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_mp_input_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_outputString_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private_notPresentObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Quaternion> Private___0_intnl_UnityEngineQuaternion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_onPlayerJoinedPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___0_outputChars_CharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___0_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_tierNames { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___29_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___35_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___50_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___0_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___24_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___48_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___33_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_mp_playerName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_rowString_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___10_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private_nextCyclePortraitTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___10_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___0_pedestalTransform_Transform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___13_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___36_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int[]> Private_playerTiers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___12_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_currentTier_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___40_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___25_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___4_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___13_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___22_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_currentPortraitPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___14_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___3_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___47_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___4_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___39_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.UI.RawImage> Private_textureTransferInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___28_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_patronRows_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___11_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___16_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___4_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_patronTierText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___12_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_tierStrings_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private___0_texture_Texture { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_RETRY_DELAY { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___31_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<System.Object[]> Private_patronData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___55_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private___0_texture2D_Texture2D { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___20_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___2_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___7_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___0_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___2_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___53_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___27_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_tier_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___32_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private_transferTexture { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___45_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___28_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_presentPatronCount_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private___0_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___7_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___0_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private_cyclePortraitInterval { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private___2_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___43_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___5_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Vector3> Private___11_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___3_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_isValidTrackingData_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___46_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_returnValSymbol_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private_refreshPortraitTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___19_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char[]> Private___2_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___24_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___8_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___3_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private___2_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___21_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___27_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___2_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___51_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___0_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private_patronPresentFlairObjects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___25_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private___1_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___49_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Material> Private___0_intnl_UnityEngineMaterial { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    #endregion AstroUdonVariables  of PatronCredits

}