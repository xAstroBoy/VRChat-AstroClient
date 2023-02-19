using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.JarWorlds.AmongUS
{
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class AmongUS_PatronCreditsReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public AmongUS_PatronCreditsReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
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

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        private RawUdonBehaviour PatronCredits { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private UdonBehaviour_Cached ForceRestart { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.AmongUS))
            {
                var obj = gameObject.FindUdonEvent("GetPatronTier");
                if (obj != null)
                {
                    PatronCredits = obj.RawItem;
                    ForceRestart = obj.gameObject.FindUdonEvent("_start");
                    Initialize_PatronCredits();
                    HasSubscribed = true;
                    ////ForceHightTier();
                    //InvokeRepeating(nameof(ForceHightTier), 0.01f, 0.01f);
                    //ForceRestart.InvokeBehaviour();

                }
                else
                {
                    Log.Error("Can't Find Customizer behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }
        private void ForceHightTier()
        {
            //__0_currentTier_Int32 = 3;
            //__0_newTier_Int32 = 3;
            //__0_tier_Int32 = 3;
            //__0_intnl_returnValSymbol_Int32 = 3;
            //localPlayerIsPatron = true;
            if (!__10_const_intnl_SystemString.isMatchWholeWord(GameInstances.CurrentUser.GetDisplayName()))
            {
                __10_const_intnl_SystemString = GameInstances.CurrentUser.GetDisplayName();
                ForceRestart.Invoke();
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
            Private_waitingToListPatrons = new AstroUdonVariable<bool>(PatronCredits, "waitingToListPatrons");
            Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__23_intnl_SystemBoolean");
            Private___15_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__15_intnl_SystemInt32");
            Private___0_intnl_VRCSDKBaseVRCPlayerApiArray = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(PatronCredits, "__0_intnl_VRCSDKBaseVRCPlayerApiArray");
            Private___1_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatronCredits, "__1_intnl_UnityEngineGameObject");
            Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__12_intnl_SystemInt32");
            Private___52_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__52_intnl_SystemBoolean");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__3_const_intnl_SystemString");
            Private_mainFlairToggle = new AstroUdonVariable<UnityEngine.UI.Toggle>(PatronCredits, "mainFlairToggle");
            Private___6_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__6_const_intnl_SystemInt32");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__3_const_intnl_exitJumpLoc_UInt32");
            Private___26_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__26_intnl_SystemBoolean");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__0_const_intnl_SystemBoolean");
            Private___41_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__41_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__1_intnl_UnityEngineTransform");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__1_const_intnl_SystemInt32");
            Private_frameTime = new AstroUdonVariable<float>(PatronCredits, "frameTime");
            Private___29_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__29_intnl_SystemSingle");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__1_intnl_SystemInt32");
            Private___15_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__15_intnl_SystemSingle");
            Private_tierColors = new AstroUdonVariable<UnityEngine.Color[]>(PatronCredits, "tierColors");
            Private___33_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__33_intnl_SystemSingle");
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
            Private_textureTransferCamera = new AstroUdonVariable<UnityEngine.Camera>(PatronCredits, "textureTransferCamera");
            Private___2_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "__2_intnl_VRCSDKBaseVRCPlayerApi");
            Private___34_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__34_intnl_SystemSingle");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__0_const_intnl_SystemString");
            Private_tierColorHexCodes = new AstroUdonVariable<string[]>(PatronCredits, "tierColorHexCodes");
            Private___21_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__21_intnl_SystemSingle");
            Private___42_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__42_intnl_SystemBoolean");
            Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__0_const_intnl_SystemSingle");
            Private___29_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__29_intnl_SystemBoolean");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__1_intnl_SystemSingle");
            Private___7_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__7_const_intnl_SystemInt32");
            Private___0_outputBytes_ByteArray = new AstroUdonVariable<byte[]>(PatronCredits, "__0_outputBytes_ByteArray");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__5_intnl_SystemBoolean");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__15_intnl_SystemBoolean");
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "__1_intnl_VRCSDKBaseVRCPlayerApi");
            Private___32_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__32_intnl_SystemSingle");
            Private___20_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__20_intnl_SystemString");
            Private___5_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__5_intnl_SystemString");
            Private___34_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__34_intnl_SystemBoolean");
            Private___2_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__2_intnl_UnityEngineTransform");
            Private___1_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__1_intnl_SystemStringArray");
            Private___1_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatronCredits, "__1_const_intnl_SystemCharArray");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__6_const_intnl_SystemString");
            Private___0_isPresent_Boolean = new AstroUdonVariable<bool>(PatronCredits, "__0_isPresent_Boolean");
            Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__21_intnl_SystemBoolean");
            Private_contentSizeFitter = new AstroUdonVariable<UnityEngine.UI.ContentSizeFitter>(PatronCredits, "contentSizeFitter");
            Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__5_const_intnl_exitJumpLoc_UInt32");
            Private_seperatorString = new AstroUdonVariable<string>(PatronCredits, "seperatorString");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__13_intnl_SystemBoolean");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__1_const_intnl_SystemString");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__4_const_intnl_SystemInt32");
            Private___64_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__64_intnl_SystemBoolean");
            Private___0_const_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__0_const_intnl_SystemChar");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__5_intnl_SystemSingle");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___18_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__18_intnl_SystemInt32");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__16_intnl_SystemBoolean");
            Private_outputColors = new AstroUdonVariable<UnityEngine.Color[]>(PatronCredits, "outputColors");
            Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__14_const_intnl_SystemString");
            Private___0_success_Boolean = new AstroUdonVariable<bool>(PatronCredits, "__0_success_Boolean");
            Private___19_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__19_intnl_SystemSingle");
            Private_frame = new AstroUdonVariable<UnityEngine.RectTransform>(PatronCredits, "frame");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__7_intnl_SystemBoolean");
            Private___20_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__20_intnl_SystemInt32");
            Private___3_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__3_intnl_SystemStringArray");
            Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__22_intnl_SystemBoolean");
            Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__7_const_intnl_exitJumpLoc_UInt32");
            Private___23_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__23_intnl_SystemInt32");
            Private_SCROLL_SYNC_DELAY = new AstroUdonVariable<float>(PatronCredits, "SCROLL_SYNC_DELAY");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__7_const_intnl_SystemString");
            Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__15_const_intnl_SystemString");
            Private___0_patronListText_String = new AstroUdonVariable<string>(PatronCredits, "__0_patronListText_String");
            Private___27_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__27_intnl_SystemSingle");
            Private___5_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__5_const_intnl_SystemInt32");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(PatronCredits, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__4_intnl_SystemBoolean");
            Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__11_intnl_SystemSingle");
            Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__19_intnl_SystemBoolean");
            Private___0_time_Single = new AstroUdonVariable<float>(PatronCredits, "__0_time_Single");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(PatronCredits, "__refl_const_intnl_udonTypeName");
            Private___1_const_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__1_const_intnl_SystemChar");
            Private___0_meshRenderer_MeshRenderer = new AstroUdonVariable<UnityEngine.MeshRenderer>(PatronCredits, "__0_meshRenderer_MeshRenderer");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__1_intnl_SystemBoolean");
            Private___38_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__38_intnl_SystemBoolean");
            Private___31_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__31_intnl_SystemInt32");
            Private___14_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__14_intnl_SystemInt32");
            Private___30_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__30_intnl_SystemSingle");
            Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__17_const_intnl_SystemString");
            Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__11_intnl_SystemInt32");
            Private___17_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__17_intnl_SystemInt32");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__4_const_intnl_SystemString");
            Private___0_byte0_Byte = new AstroUdonVariable<byte>(PatronCredits, "__0_byte0_Byte");
            Private___0_byte1_Byte = new AstroUdonVariable<byte>(PatronCredits, "__0_byte1_Byte");
            Private___10_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__10_intnl_SystemString");
            Private___68_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__68_intnl_SystemBoolean");
            Private_localPlayerIsPatron = new AstroUdonVariable<bool>(PatronCredits, "localPlayerIsPatron");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__11_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__2_intnl_SystemInt32");
            Private___26_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__26_intnl_SystemSingle");
            Private___0_imageTransform_Transform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__0_imageTransform_Transform");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__4_const_intnl_exitJumpLoc_UInt32");
            Private___30_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__30_intnl_SystemBoolean");
            Private___26_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__26_intnl_SystemInt32");
            Private___54_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__54_intnl_SystemBoolean");
            Private___2_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__2_intnl_SystemString");
            Private_pedestal = new AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal>(PatronCredits, "pedestal");
            Private___3_intnl_UnityEngineUIText = new AstroUdonVariable<UnityEngine.UI.Text>(PatronCredits, "__3_intnl_UnityEngineUIText");
            Private___60_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__60_intnl_SystemBoolean");
            Private___37_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__37_intnl_SystemBoolean");
            Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__9_intnl_SystemInt32");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__2_intnl_SystemSingle");
            Private_startBufferTime = new AstroUdonVariable<float>(PatronCredits, "startBufferTime");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__3_intnl_SystemBoolean");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__12_intnl_SystemBoolean");
            Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__6_const_intnl_exitJumpLoc_UInt32");
            Private_presentPatronCountText = new AstroUdonVariable<UnityEngine.UI.Text>(PatronCredits, "presentPatronCountText");
            Private___67_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__67_intnl_SystemBoolean");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__6_intnl_SystemInt32");
            Private___1_intnl_UnityEngineVector2 = new AstroUdonVariable<UnityEngine.Vector2>(PatronCredits, "__1_intnl_UnityEngineVector2");
            Private_textLoadingPlaceholder = new AstroUdonVariable<UnityEngine.GameObject>(PatronCredits, "textLoadingPlaceholder");
            Private___44_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__44_intnl_SystemBoolean");
            Private___17_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__17_intnl_SystemSingle");
            Private___0_intnl_UnityEngineRect = new AstroUdonVariable<UnityEngine.Rect>(PatronCredits, "__0_intnl_UnityEngineRect");
            Private___0_this_intnl_PatreonCredits = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PatronCredits, "__0_this_intnl_PatreonCredits");
            Private___6_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__6_intnl_SystemString");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__0_intnl_SystemBoolean");
            Private___0_patronName_String = new AstroUdonVariable<string>(PatronCredits, "__0_patronName_String");
            Private___0_newTier_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_newTier_Int32");
            Private_timeOffset = new AstroUdonVariable<float>(PatronCredits, "timeOffset");
            Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__9_intnl_SystemSingle");
            Private___0_intnl_UnityEngineVector2 = new AstroUdonVariable<UnityEngine.Vector2>(PatronCredits, "__0_intnl_UnityEngineVector2");
            Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__12_const_intnl_SystemString");
            Private___0_this_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatronCredits, "__0_this_intnl_UnityEngineGameObject");
            Private___35_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__35_intnl_SystemSingle");
            Private___23_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__23_intnl_SystemSingle");
            Private___0_mp_input_String = new AstroUdonVariable<string>(PatronCredits, "__0_mp_input_String");
            Private___0_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(PatronCredits, "__0_intnl_UnityEngineGameObject");
            Private___2_intnl_UnityEngineUIText = new AstroUdonVariable<UnityEngine.UI.Text>(PatronCredits, "__2_intnl_UnityEngineUIText");
            Private___0_outputString_String = new AstroUdonVariable<string>(PatronCredits, "__0_outputString_String");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__8_const_intnl_SystemString");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__6_intnl_SystemSingle");
            Private_fadeTime = new AstroUdonVariable<float>(PatronCredits, "fadeTime");
            Private___24_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__24_intnl_SystemSingle");
            Private_presentPatronText = new AstroUdonVariable<UnityEngine.UI.Text>(PatronCredits, "presentPatronText");
            Private___58_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__58_intnl_SystemBoolean");
            Private_onPlayerJoinedPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "onPlayerJoinedPlayer");
            Private___1_intnl_UnityEngineUIText = new AstroUdonVariable<UnityEngine.UI.Text>(PatronCredits, "__1_intnl_UnityEngineUIText");
            Private___16_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__16_intnl_SystemSingle");
            Private___0_scrollPercent_Single = new AstroUdonVariable<float>(PatronCredits, "__0_scrollPercent_Single");
            Private___0_outputChars_CharArray = new AstroUdonVariable<char[]>(PatronCredits, "__0_outputChars_CharArray");
            Private___0_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatronCredits, "__0_intnl_SystemCharArray");
            Private___2_intnl_UnityEngineRect = new AstroUdonVariable<UnityEngine.Rect>(PatronCredits, "__2_intnl_UnityEngineRect");
            Private___0_intnl_UnityEngineUIText = new AstroUdonVariable<UnityEngine.UI.Text>(PatronCredits, "__0_intnl_UnityEngineUIText");
            Private___21_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__21_intnl_SystemString");
            Private___13_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__13_intnl_SystemString");
            Private___29_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__29_intnl_SystemInt32");
            Private___35_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__35_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineRect = new AstroUdonVariable<UnityEngine.Rect>(PatronCredits, "__1_intnl_UnityEngineRect");
            Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__8_const_intnl_exitJumpLoc_UInt32");
            Private___50_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__50_intnl_SystemBoolean");
            Private___22_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__22_intnl_SystemSingle");
            Private___0_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatronCredits, "__0_const_intnl_SystemCharArray");
            Private___24_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__24_intnl_SystemBoolean");
            Private_doScrollingAnimation = new AstroUdonVariable<bool>(PatronCredits, "doScrollingAnimation");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__0_intnl_returnTarget_UInt32");
            Private___0_const_intnl_UnityEngineUIContentSizeFitterFitMode = new AstroUdonVariable<UnityEngine.UI.ContentSizeFitter.FitMode>(PatronCredits, "__0_const_intnl_UnityEngineUIContentSizeFitterFitMode");
            Private___48_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__48_intnl_SystemBoolean");
            Private___30_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__30_intnl_SystemInt32");
            Private___65_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__65_intnl_SystemBoolean");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__0_intnl_SystemString");
            Private___33_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__33_intnl_SystemBoolean");
            Private___57_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__57_intnl_SystemBoolean");
            Private___0_mp_playerName_String = new AstroUdonVariable<string>(PatronCredits, "__0_mp_playerName_String");
            Private___0_rowString_String = new AstroUdonVariable<string>(PatronCredits, "__0_rowString_String");
            Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__10_intnl_SystemInt32");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(PatronCredits, "__0_const_intnl_SystemUInt32");
            Private___0_pedestalTransform_Transform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__0_pedestalTransform_Transform");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__9_intnl_SystemBoolean");
            Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__13_intnl_SystemInt32");
            Private___0_fadePercent_Single = new AstroUdonVariable<float>(PatronCredits, "__0_fadePercent_Single");
            Private___63_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__63_intnl_SystemBoolean");
            Private___36_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__36_intnl_SystemBoolean");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__0_intnl_SystemSingle");
            Private___12_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__12_intnl_SystemString");
            Private___0_currentTier_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_currentTier_Int32");
            Private___40_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__40_intnl_SystemBoolean");
            Private___25_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__25_intnl_SystemInt32");
            Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__18_const_intnl_SystemString");
            Private___4_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__4_intnl_SystemStringArray");
            Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__13_intnl_SystemSingle");
            Private___6_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__6_intnl_SystemStringArray");
            Private___66_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__66_intnl_SystemBoolean");
            Private___22_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__22_intnl_SystemInt32");
            Private___0_mp_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PatronCredits, "__0_mp_player_VRCPlayerApi");
            Private___28_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__28_intnl_SystemSingle");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__4_intnl_SystemInt32");
            Private___0_scrollTime_Single = new AstroUdonVariable<float>(PatronCredits, "__0_scrollTime_Single");
            Private___14_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__14_intnl_SystemSingle");
            Private___47_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__47_intnl_SystemBoolean");
            Private___4_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__4_intnl_SystemString");
            Private___4_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__4_intnl_UnityEngineTransform");
            Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__19_const_intnl_SystemString");
            Private___31_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__31_intnl_SystemSingle");
            Private___39_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__39_intnl_SystemBoolean");
            Private___0_players_VRCPlayerApiArray = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(PatronCredits, "__0_players_VRCPlayerApiArray");
            Private_textureTransferInput = new AstroUdonVariable<UnityEngine.UI.RawImage>(PatronCredits, "textureTransferInput");
            Private___28_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__28_intnl_SystemBoolean");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__6_intnl_SystemBoolean");
            Private_CONTENT_FIX_TIME = new AstroUdonVariable<float>(PatronCredits, "CONTENT_FIX_TIME");
            Private___20_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__20_intnl_SystemSingle");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__4_intnl_SystemSingle");
            Private___0_patronRows_StringArray = new AstroUdonVariable<string[]>(PatronCredits, "__0_patronRows_StringArray");
            Private___0_contentHeight_Single = new AstroUdonVariable<float>(PatronCredits, "__0_contentHeight_Single");
            Private___11_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__11_intnl_SystemString");
            Private___16_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__16_intnl_SystemInt32");
            Private___0_frameHeight_Single = new AstroUdonVariable<float>(PatronCredits, "__0_frameHeight_Single");
            Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__12_intnl_SystemSingle");
            Private_contentFixed = new AstroUdonVariable<bool>(PatronCredits, "contentFixed");
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
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__3_intnl_SystemString");
            Private___0_presentPatronString_String = new AstroUdonVariable<string>(PatronCredits, "__0_presentPatronString_String");
            Private___61_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__61_intnl_SystemBoolean");
            Private___1_const_intnl_UnityEngineUIContentSizeFitterFitMode = new AstroUdonVariable<UnityEngine.UI.ContentSizeFitter.FitMode>(PatronCredits, "__1_const_intnl_UnityEngineUIContentSizeFitterFitMode");
            Private___0_intnl_SystemByte = new AstroUdonVariable<byte>(PatronCredits, "__0_intnl_SystemByte");
            Private___2_const_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__2_const_intnl_SystemChar");
            Private___53_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__53_intnl_SystemBoolean");
            Private___27_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__27_intnl_SystemBoolean");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__3_intnl_SystemSingle");
            Private___0_tier_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_tier_Int32");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__10_const_intnl_SystemString");
            Private___32_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__32_intnl_SystemBoolean");
            Private_transferTexture = new AstroUdonVariable<UnityEngine.Texture2D>(PatronCredits, "transferTexture");
            Private___56_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__56_intnl_SystemBoolean");
            Private___18_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__18_intnl_SystemSingle");
            Private___45_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__45_intnl_SystemBoolean");
            Private___28_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__28_intnl_SystemInt32");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__7_intnl_SystemInt32");
            Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__0_intnl_UnityEngineTransform");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__1_const_intnl_SystemBoolean");
            Private___0_presentPatronCount_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_presentPatronCount_Int32");
            Private___0_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(PatronCredits, "__0_intnl_UnityEngineColor");
            Private___7_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__7_intnl_SystemString");
            Private_tierTexts = new AstroUdonVariable<UnityEngine.UI.Text[]>(PatronCredits, "tierTexts");
            Private___62_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__62_intnl_SystemBoolean");
            Private_content = new AstroUdonVariable<UnityEngine.RectTransform>(PatronCredits, "content");
            Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__11_const_intnl_SystemString");
            Private___0_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__0_intnl_SystemStringArray");
            Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__16_const_intnl_SystemString");
            Private___2_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__2_intnl_SystemStringArray");
            Private___43_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__43_intnl_SystemBoolean");
            Private_MAX_PLAYERS = new AstroUdonVariable<int>(PatronCredits, "MAX_PLAYERS");
            Private___5_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__5_intnl_UnityEngineTransform");
            Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__18_intnl_SystemBoolean");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__2_intnl_SystemBoolean");
            Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__10_intnl_SystemSingle");
            Private___25_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__25_intnl_SystemSingle");
            Private___3_const_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__3_const_intnl_SystemChar");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__3_const_intnl_SystemInt32");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__7_intnl_SystemSingle");
            Private___59_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__59_intnl_SystemBoolean");
            Private___46_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__46_intnl_SystemBoolean");
            Private___0_intnl_returnValSymbol_String = new AstroUdonVariable<string>(PatronCredits, "__0_intnl_returnValSymbol_String");
            Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__13_const_intnl_SystemString");
            Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__8_intnl_SystemInt32");
            Private___19_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__19_intnl_SystemInt32");
            Private___2_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PatronCredits, "__2_const_intnl_SystemCharArray");
            Private___24_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__24_intnl_SystemInt32");
            Private___8_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__8_intnl_SystemString");
            Private_canvasGroupFadeAnimator = new AstroUdonVariable<UnityEngine.Animator>(PatronCredits, "canvasGroupFadeAnimator");
            Private___3_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(PatronCredits, "__3_intnl_UnityEngineTransform");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__10_intnl_SystemBoolean");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(PatronCredits, "__2_const_intnl_SystemString");
            Private___21_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__21_intnl_SystemInt32");
            Private___27_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__27_intnl_SystemInt32");
            Private___5_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PatronCredits, "__5_intnl_SystemStringArray");
            Private___51_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__51_intnl_SystemBoolean");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PatronCredits, "__0_const_intnl_SystemInt32");
            Private___0_intnl_SystemChar = new AstroUdonVariable<char>(PatronCredits, "__0_intnl_SystemChar");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PatronCredits, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___25_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__25_intnl_SystemBoolean");
            Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(PatronCredits, "__8_intnl_SystemSingle");
            Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__17_intnl_SystemBoolean");
            Private___49_intnl_SystemBoolean = new AstroUdonVariable<bool>(PatronCredits, "__49_intnl_SystemBoolean");
            Private___0_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(PatronCredits, "__0_intnl_returnValSymbol_Int32");
            Private___0_intnl_UnityEngineMaterial = new AstroUdonVariable<UnityEngine.Material>(PatronCredits, "__0_intnl_UnityEngineMaterial");
        }

        private void Cleanup_PatronCredits()
        {
            Private_retries = null;
            Private_waitingToListPatrons = null;
            Private___23_intnl_SystemBoolean = null;
            Private___15_intnl_SystemInt32 = null;
            Private___0_intnl_VRCSDKBaseVRCPlayerApiArray = null;
            Private___1_intnl_UnityEngineGameObject = null;
            Private___12_intnl_SystemInt32 = null;
            Private___52_intnl_SystemBoolean = null;
            Private___3_const_intnl_SystemString = null;
            Private_mainFlairToggle = null;
            Private___6_const_intnl_SystemInt32 = null;
            Private___3_const_intnl_exitJumpLoc_UInt32 = null;
            Private___26_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___41_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineTransform = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private_frameTime = null;
            Private___29_intnl_SystemSingle = null;
            Private___1_intnl_SystemInt32 = null;
            Private___15_intnl_SystemSingle = null;
            Private_tierColors = null;
            Private___33_intnl_SystemSingle = null;
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
            Private_textureTransferCamera = null;
            Private___2_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___34_intnl_SystemSingle = null;
            Private___0_const_intnl_SystemString = null;
            Private_tierColorHexCodes = null;
            Private___21_intnl_SystemSingle = null;
            Private___42_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemSingle = null;
            Private___29_intnl_SystemBoolean = null;
            Private___1_intnl_SystemSingle = null;
            Private___7_const_intnl_SystemInt32 = null;
            Private___0_outputBytes_ByteArray = null;
            Private___5_intnl_SystemBoolean = null;
            Private___5_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___15_intnl_SystemBoolean = null;
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___32_intnl_SystemSingle = null;
            Private___20_intnl_SystemString = null;
            Private___5_intnl_SystemString = null;
            Private___34_intnl_SystemBoolean = null;
            Private___2_intnl_UnityEngineTransform = null;
            Private___1_intnl_SystemStringArray = null;
            Private___1_const_intnl_SystemCharArray = null;
            Private___6_const_intnl_SystemString = null;
            Private___0_isPresent_Boolean = null;
            Private___21_intnl_SystemBoolean = null;
            Private_contentSizeFitter = null;
            Private___5_const_intnl_exitJumpLoc_UInt32 = null;
            Private_seperatorString = null;
            Private___13_intnl_SystemBoolean = null;
            Private___1_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemInt32 = null;
            Private___64_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemChar = null;
            Private___5_intnl_SystemSingle = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private___18_intnl_SystemInt32 = null;
            Private___16_intnl_SystemBoolean = null;
            Private_outputColors = null;
            Private___14_const_intnl_SystemString = null;
            Private___0_success_Boolean = null;
            Private___19_intnl_SystemSingle = null;
            Private_frame = null;
            Private___7_intnl_SystemBoolean = null;
            Private___20_intnl_SystemInt32 = null;
            Private___3_intnl_SystemStringArray = null;
            Private___22_intnl_SystemBoolean = null;
            Private___7_const_intnl_exitJumpLoc_UInt32 = null;
            Private___23_intnl_SystemInt32 = null;
            Private_SCROLL_SYNC_DELAY = null;
            Private___7_const_intnl_SystemString = null;
            Private___15_const_intnl_SystemString = null;
            Private___0_patronListText_String = null;
            Private___27_intnl_SystemSingle = null;
            Private___5_const_intnl_SystemInt32 = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private___11_intnl_SystemSingle = null;
            Private___19_intnl_SystemBoolean = null;
            Private___0_time_Single = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___1_const_intnl_SystemChar = null;
            Private___0_meshRenderer_MeshRenderer = null;
            Private___1_intnl_SystemBoolean = null;
            Private___38_intnl_SystemBoolean = null;
            Private___31_intnl_SystemInt32 = null;
            Private___14_intnl_SystemInt32 = null;
            Private___30_intnl_SystemSingle = null;
            Private___17_const_intnl_SystemString = null;
            Private___11_intnl_SystemInt32 = null;
            Private___17_intnl_SystemInt32 = null;
            Private___4_const_intnl_SystemString = null;
            Private___0_byte0_Byte = null;
            Private___0_byte1_Byte = null;
            Private___10_intnl_SystemString = null;
            Private___68_intnl_SystemBoolean = null;
            Private_localPlayerIsPatron = null;
            Private___11_intnl_SystemBoolean = null;
            Private___2_intnl_SystemInt32 = null;
            Private___26_intnl_SystemSingle = null;
            Private___0_imageTransform_Transform = null;
            Private___4_const_intnl_exitJumpLoc_UInt32 = null;
            Private___30_intnl_SystemBoolean = null;
            Private___26_intnl_SystemInt32 = null;
            Private___54_intnl_SystemBoolean = null;
            Private___2_intnl_SystemString = null;
            Private_pedestal = null;
            Private___3_intnl_UnityEngineUIText = null;
            Private___60_intnl_SystemBoolean = null;
            Private___37_intnl_SystemBoolean = null;
            Private___9_intnl_SystemInt32 = null;
            Private___2_intnl_SystemSingle = null;
            Private_startBufferTime = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___12_intnl_SystemBoolean = null;
            Private___6_const_intnl_exitJumpLoc_UInt32 = null;
            Private_presentPatronCountText = null;
            Private___67_intnl_SystemBoolean = null;
            Private___6_intnl_SystemInt32 = null;
            Private___1_intnl_UnityEngineVector2 = null;
            Private_textLoadingPlaceholder = null;
            Private___44_intnl_SystemBoolean = null;
            Private___17_intnl_SystemSingle = null;
            Private___0_intnl_UnityEngineRect = null;
            Private___0_this_intnl_PatreonCredits = null;
            Private___6_intnl_SystemString = null;
            Private___0_intnl_SystemBoolean = null;
            Private___0_patronName_String = null;
            Private___0_newTier_Int32 = null;
            Private_timeOffset = null;
            Private___9_intnl_SystemSingle = null;
            Private___0_intnl_UnityEngineVector2 = null;
            Private___12_const_intnl_SystemString = null;
            Private___0_this_intnl_UnityEngineGameObject = null;
            Private___35_intnl_SystemSingle = null;
            Private___23_intnl_SystemSingle = null;
            Private___0_mp_input_String = null;
            Private___0_intnl_UnityEngineGameObject = null;
            Private___2_intnl_UnityEngineUIText = null;
            Private___0_outputString_String = null;
            Private___8_const_intnl_SystemString = null;
            Private___6_intnl_SystemSingle = null;
            Private_fadeTime = null;
            Private___24_intnl_SystemSingle = null;
            Private_presentPatronText = null;
            Private___58_intnl_SystemBoolean = null;
            Private_onPlayerJoinedPlayer = null;
            Private___1_intnl_UnityEngineUIText = null;
            Private___16_intnl_SystemSingle = null;
            Private___0_scrollPercent_Single = null;
            Private___0_outputChars_CharArray = null;
            Private___0_intnl_SystemCharArray = null;
            Private___2_intnl_UnityEngineRect = null;
            Private___0_intnl_UnityEngineUIText = null;
            Private___21_intnl_SystemString = null;
            Private___13_intnl_SystemString = null;
            Private___29_intnl_SystemInt32 = null;
            Private___35_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineRect = null;
            Private___8_const_intnl_exitJumpLoc_UInt32 = null;
            Private___50_intnl_SystemBoolean = null;
            Private___22_intnl_SystemSingle = null;
            Private___0_const_intnl_SystemCharArray = null;
            Private___24_intnl_SystemBoolean = null;
            Private_doScrollingAnimation = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___0_const_intnl_UnityEngineUIContentSizeFitterFitMode = null;
            Private___48_intnl_SystemBoolean = null;
            Private___30_intnl_SystemInt32 = null;
            Private___65_intnl_SystemBoolean = null;
            Private___0_intnl_SystemString = null;
            Private___33_intnl_SystemBoolean = null;
            Private___57_intnl_SystemBoolean = null;
            Private___0_mp_playerName_String = null;
            Private___0_rowString_String = null;
            Private___10_intnl_SystemInt32 = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private___0_pedestalTransform_Transform = null;
            Private___9_intnl_SystemBoolean = null;
            Private___13_intnl_SystemInt32 = null;
            Private___0_fadePercent_Single = null;
            Private___63_intnl_SystemBoolean = null;
            Private___36_intnl_SystemBoolean = null;
            Private___0_intnl_SystemSingle = null;
            Private___12_intnl_SystemString = null;
            Private___0_currentTier_Int32 = null;
            Private___40_intnl_SystemBoolean = null;
            Private___25_intnl_SystemInt32 = null;
            Private___18_const_intnl_SystemString = null;
            Private___4_intnl_SystemStringArray = null;
            Private___13_intnl_SystemSingle = null;
            Private___6_intnl_SystemStringArray = null;
            Private___66_intnl_SystemBoolean = null;
            Private___22_intnl_SystemInt32 = null;
            Private___0_mp_player_VRCPlayerApi = null;
            Private___28_intnl_SystemSingle = null;
            Private___4_intnl_SystemInt32 = null;
            Private___0_scrollTime_Single = null;
            Private___14_intnl_SystemSingle = null;
            Private___47_intnl_SystemBoolean = null;
            Private___4_intnl_SystemString = null;
            Private___4_intnl_UnityEngineTransform = null;
            Private___19_const_intnl_SystemString = null;
            Private___31_intnl_SystemSingle = null;
            Private___39_intnl_SystemBoolean = null;
            Private___0_players_VRCPlayerApiArray = null;
            Private_textureTransferInput = null;
            Private___28_intnl_SystemBoolean = null;
            Private___6_intnl_SystemBoolean = null;
            Private_CONTENT_FIX_TIME = null;
            Private___20_intnl_SystemSingle = null;
            Private___4_intnl_SystemSingle = null;
            Private___0_patronRows_StringArray = null;
            Private___0_contentHeight_Single = null;
            Private___11_intnl_SystemString = null;
            Private___16_intnl_SystemInt32 = null;
            Private___0_frameHeight_Single = null;
            Private___12_intnl_SystemSingle = null;
            Private_contentFixed = null;
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
            Private___3_intnl_SystemString = null;
            Private___0_presentPatronString_String = null;
            Private___61_intnl_SystemBoolean = null;
            Private___1_const_intnl_UnityEngineUIContentSizeFitterFitMode = null;
            Private___0_intnl_SystemByte = null;
            Private___2_const_intnl_SystemChar = null;
            Private___53_intnl_SystemBoolean = null;
            Private___27_intnl_SystemBoolean = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___3_intnl_SystemSingle = null;
            Private___0_tier_Int32 = null;
            Private___10_const_intnl_SystemString = null;
            Private___32_intnl_SystemBoolean = null;
            Private_transferTexture = null;
            Private___56_intnl_SystemBoolean = null;
            Private___18_intnl_SystemSingle = null;
            Private___45_intnl_SystemBoolean = null;
            Private___28_intnl_SystemInt32 = null;
            Private___7_intnl_SystemInt32 = null;
            Private___0_intnl_UnityEngineTransform = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private___0_presentPatronCount_Int32 = null;
            Private___0_intnl_UnityEngineColor = null;
            Private___7_intnl_SystemString = null;
            Private_tierTexts = null;
            Private___62_intnl_SystemBoolean = null;
            Private_content = null;
            Private___11_const_intnl_SystemString = null;
            Private___0_intnl_SystemStringArray = null;
            Private___16_const_intnl_SystemString = null;
            Private___2_intnl_SystemStringArray = null;
            Private___43_intnl_SystemBoolean = null;
            Private_MAX_PLAYERS = null;
            Private___5_intnl_UnityEngineTransform = null;
            Private___18_intnl_SystemBoolean = null;
            Private___2_intnl_SystemBoolean = null;
            Private___10_intnl_SystemSingle = null;
            Private___25_intnl_SystemSingle = null;
            Private___3_const_intnl_SystemChar = null;
            Private___3_const_intnl_SystemInt32 = null;
            Private___7_intnl_SystemSingle = null;
            Private___59_intnl_SystemBoolean = null;
            Private___46_intnl_SystemBoolean = null;
            Private___0_intnl_returnValSymbol_String = null;
            Private___13_const_intnl_SystemString = null;
            Private___8_intnl_SystemInt32 = null;
            Private___19_intnl_SystemInt32 = null;
            Private___2_const_intnl_SystemCharArray = null;
            Private___24_intnl_SystemInt32 = null;
            Private___8_intnl_SystemString = null;
            Private_canvasGroupFadeAnimator = null;
            Private___3_intnl_UnityEngineTransform = null;
            Private___10_intnl_SystemBoolean = null;
            Private___2_const_intnl_SystemString = null;
            Private___21_intnl_SystemInt32 = null;
            Private___27_intnl_SystemInt32 = null;
            Private___5_intnl_SystemStringArray = null;
            Private___51_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___0_intnl_SystemChar = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
            Private___25_intnl_SystemBoolean = null;
            Private___8_intnl_SystemSingle = null;
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

        internal bool? waitingToListPatrons
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_waitingToListPatrons != null)
                {
                    return Private_waitingToListPatrons.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_waitingToListPatrons != null)
                    {
                        Private_waitingToListPatrons.Value = value.Value;
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

        internal UnityEngine.UI.Toggle mainFlairToggle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_mainFlairToggle != null)
                {
                    return Private_mainFlairToggle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_mainFlairToggle != null)
                {
                    Private_mainFlairToggle.Value = value;
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

        internal float? frameTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_frameTime != null)
                {
                    return Private_frameTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_frameTime != null)
                    {
                        Private_frameTime.Value = value.Value;
                    }
                }
            }
        }

        internal float? __29_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___29_intnl_SystemSingle != null)
                {
                    return Private___29_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___29_intnl_SystemSingle != null)
                    {
                        Private___29_intnl_SystemSingle.Value = value.Value;
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

        internal float? __33_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___33_intnl_SystemSingle != null)
                {
                    return Private___33_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___33_intnl_SystemSingle != null)
                    {
                        Private___33_intnl_SystemSingle.Value = value.Value;
                    }
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

        internal float? __34_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___34_intnl_SystemSingle != null)
                {
                    return Private___34_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___34_intnl_SystemSingle != null)
                    {
                        Private___34_intnl_SystemSingle.Value = value.Value;
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

        internal string[] tierColorHexCodes
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tierColorHexCodes != null)
                {
                    return Private_tierColorHexCodes.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tierColorHexCodes != null)
                {
                    Private_tierColorHexCodes.Value = value;
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

        internal float? __32_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___32_intnl_SystemSingle != null)
                {
                    return Private___32_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___32_intnl_SystemSingle != null)
                    {
                        Private___32_intnl_SystemSingle.Value = value.Value;
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

        internal UnityEngine.UI.ContentSizeFitter contentSizeFitter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_contentSizeFitter != null)
                {
                    return Private_contentSizeFitter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_contentSizeFitter != null)
                {
                    Private_contentSizeFitter.Value = value;
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

        internal string seperatorString
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_seperatorString != null)
                {
                    return Private_seperatorString.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_seperatorString != null)
                {
                    Private_seperatorString.Value = value;
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

        internal UnityEngine.RectTransform frame
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_frame != null)
                {
                    return Private_frame.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_frame != null)
                {
                    Private_frame.Value = value;
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

        internal float? SCROLL_SYNC_DELAY
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_SCROLL_SYNC_DELAY != null)
                {
                    return Private_SCROLL_SYNC_DELAY.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_SCROLL_SYNC_DELAY != null)
                    {
                        Private_SCROLL_SYNC_DELAY.Value = value.Value;
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

        internal string __0_patronListText_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_patronListText_String != null)
                {
                    return Private___0_patronListText_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_patronListText_String != null)
                {
                    Private___0_patronListText_String.Value = value;
                }
            }
        }

        internal float? __27_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___27_intnl_SystemSingle != null)
                {
                    return Private___27_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___27_intnl_SystemSingle != null)
                    {
                        Private___27_intnl_SystemSingle.Value = value.Value;
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

        internal float? __0_time_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_time_Single != null)
                {
                    return Private___0_time_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_time_Single != null)
                    {
                        Private___0_time_Single.Value = value.Value;
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

        internal float? __30_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___30_intnl_SystemSingle != null)
                {
                    return Private___30_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___30_intnl_SystemSingle != null)
                    {
                        Private___30_intnl_SystemSingle.Value = value.Value;
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

        internal float? __26_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___26_intnl_SystemSingle != null)
                {
                    return Private___26_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___26_intnl_SystemSingle != null)
                    {
                        Private___26_intnl_SystemSingle.Value = value.Value;
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

        internal UnityEngine.UI.Text __3_intnl_UnityEngineUIText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_UnityEngineUIText != null)
                {
                    return Private___3_intnl_UnityEngineUIText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_UnityEngineUIText != null)
                {
                    Private___3_intnl_UnityEngineUIText.Value = value;
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

        internal float? startBufferTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_startBufferTime != null)
                {
                    return Private_startBufferTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_startBufferTime != null)
                    {
                        Private_startBufferTime.Value = value.Value;
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

        internal UnityEngine.UI.Text presentPatronCountText
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

        internal UnityEngine.Vector2? __1_intnl_UnityEngineVector2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineVector2 != null)
                {
                    return Private___1_intnl_UnityEngineVector2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_UnityEngineVector2 != null)
                    {
                        Private___1_intnl_UnityEngineVector2.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject textLoadingPlaceholder
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_textLoadingPlaceholder != null)
                {
                    return Private_textLoadingPlaceholder.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_textLoadingPlaceholder != null)
                {
                    Private_textLoadingPlaceholder.Value = value;
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

        internal float? timeOffset
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_timeOffset != null)
                {
                    return Private_timeOffset.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_timeOffset != null)
                    {
                        Private_timeOffset.Value = value.Value;
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

        internal UnityEngine.Vector2? __0_intnl_UnityEngineVector2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineVector2 != null)
                {
                    return Private___0_intnl_UnityEngineVector2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_UnityEngineVector2 != null)
                    {
                        Private___0_intnl_UnityEngineVector2.Value = value.Value;
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

        internal float? __35_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___35_intnl_SystemSingle != null)
                {
                    return Private___35_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___35_intnl_SystemSingle != null)
                    {
                        Private___35_intnl_SystemSingle.Value = value.Value;
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

        internal UnityEngine.UI.Text __2_intnl_UnityEngineUIText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineUIText != null)
                {
                    return Private___2_intnl_UnityEngineUIText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineUIText != null)
                {
                    Private___2_intnl_UnityEngineUIText.Value = value;
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

        internal float? fadeTime
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_fadeTime != null)
                {
                    return Private_fadeTime.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_fadeTime != null)
                    {
                        Private_fadeTime.Value = value.Value;
                    }
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

        internal UnityEngine.UI.Text presentPatronText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_presentPatronText != null)
                {
                    return Private_presentPatronText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_presentPatronText != null)
                {
                    Private_presentPatronText.Value = value;
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

        internal UnityEngine.UI.Text __1_intnl_UnityEngineUIText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineUIText != null)
                {
                    return Private___1_intnl_UnityEngineUIText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineUIText != null)
                {
                    Private___1_intnl_UnityEngineUIText.Value = value;
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

        internal float? __0_scrollPercent_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_scrollPercent_Single != null)
                {
                    return Private___0_scrollPercent_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_scrollPercent_Single != null)
                    {
                        Private___0_scrollPercent_Single.Value = value.Value;
                    }
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

        internal UnityEngine.Rect? __2_intnl_UnityEngineRect
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineRect != null)
                {
                    return Private___2_intnl_UnityEngineRect.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_UnityEngineRect != null)
                    {
                        Private___2_intnl_UnityEngineRect.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Text __0_intnl_UnityEngineUIText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineUIText != null)
                {
                    return Private___0_intnl_UnityEngineUIText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineUIText != null)
                {
                    Private___0_intnl_UnityEngineUIText.Value = value;
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

        internal UnityEngine.Rect? __1_intnl_UnityEngineRect
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineRect != null)
                {
                    return Private___1_intnl_UnityEngineRect.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_UnityEngineRect != null)
                    {
                        Private___1_intnl_UnityEngineRect.Value = value.Value;
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

        internal bool? doScrollingAnimation
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_doScrollingAnimation != null)
                {
                    return Private_doScrollingAnimation.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_doScrollingAnimation != null)
                    {
                        Private_doScrollingAnimation.Value = value.Value;
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

        internal UnityEngine.UI.ContentSizeFitter.FitMode? __0_const_intnl_UnityEngineUIContentSizeFitterFitMode
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_UnityEngineUIContentSizeFitterFitMode != null)
                {
                    return Private___0_const_intnl_UnityEngineUIContentSizeFitterFitMode.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_UnityEngineUIContentSizeFitterFitMode != null)
                    {
                        Private___0_const_intnl_UnityEngineUIContentSizeFitterFitMode.Value = value.Value;
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

        internal float? __0_fadePercent_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_fadePercent_Single != null)
                {
                    return Private___0_fadePercent_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_fadePercent_Single != null)
                    {
                        Private___0_fadePercent_Single.Value = value.Value;
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

        internal string[] __6_intnl_SystemStringArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_intnl_SystemStringArray != null)
                {
                    return Private___6_intnl_SystemStringArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___6_intnl_SystemStringArray != null)
                {
                    Private___6_intnl_SystemStringArray.Value = value;
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

        internal float? __28_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___28_intnl_SystemSingle != null)
                {
                    return Private___28_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___28_intnl_SystemSingle != null)
                    {
                        Private___28_intnl_SystemSingle.Value = value.Value;
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

        internal float? __0_scrollTime_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_scrollTime_Single != null)
                {
                    return Private___0_scrollTime_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_scrollTime_Single != null)
                    {
                        Private___0_scrollTime_Single.Value = value.Value;
                    }
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

        internal float? __31_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___31_intnl_SystemSingle != null)
                {
                    return Private___31_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___31_intnl_SystemSingle != null)
                    {
                        Private___31_intnl_SystemSingle.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi[] __0_players_VRCPlayerApiArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_players_VRCPlayerApiArray != null)
                {
                    return Private___0_players_VRCPlayerApiArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_players_VRCPlayerApiArray != null)
                {
                    Private___0_players_VRCPlayerApiArray.Value = value;
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

        internal float? CONTENT_FIX_TIME
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_CONTENT_FIX_TIME != null)
                {
                    return Private_CONTENT_FIX_TIME.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_CONTENT_FIX_TIME != null)
                    {
                        Private_CONTENT_FIX_TIME.Value = value.Value;
                    }
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

        internal float? __0_contentHeight_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_contentHeight_Single != null)
                {
                    return Private___0_contentHeight_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_contentHeight_Single != null)
                    {
                        Private___0_contentHeight_Single.Value = value.Value;
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

        internal float? __0_frameHeight_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_frameHeight_Single != null)
                {
                    return Private___0_frameHeight_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_frameHeight_Single != null)
                    {
                        Private___0_frameHeight_Single.Value = value.Value;
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

        internal bool? contentFixed
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_contentFixed != null)
                {
                    return Private_contentFixed.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_contentFixed != null)
                    {
                        Private_contentFixed.Value = value.Value;
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

        internal string __0_presentPatronString_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_presentPatronString_String != null)
                {
                    return Private___0_presentPatronString_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_presentPatronString_String != null)
                {
                    Private___0_presentPatronString_String.Value = value;
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

        internal UnityEngine.UI.ContentSizeFitter.FitMode? __1_const_intnl_UnityEngineUIContentSizeFitterFitMode
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_UnityEngineUIContentSizeFitterFitMode != null)
                {
                    return Private___1_const_intnl_UnityEngineUIContentSizeFitterFitMode.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_UnityEngineUIContentSizeFitterFitMode != null)
                    {
                        Private___1_const_intnl_UnityEngineUIContentSizeFitterFitMode.Value = value.Value;
                    }
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

        internal UnityEngine.UI.Text[] tierTexts
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_tierTexts != null)
                {
                    return Private_tierTexts.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_tierTexts != null)
                {
                    Private_tierTexts.Value = value;
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

        internal UnityEngine.RectTransform content
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_content != null)
                {
                    return Private_content.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_content != null)
                {
                    Private_content.Value = value;
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

        internal int? MAX_PLAYERS
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_MAX_PLAYERS != null)
                {
                    return Private_MAX_PLAYERS.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_MAX_PLAYERS != null)
                    {
                        Private_MAX_PLAYERS.Value = value.Value;
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

        internal UnityEngine.Animator canvasGroupFadeAnimator
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_canvasGroupFadeAnimator != null)
                {
                    return Private_canvasGroupFadeAnimator.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_canvasGroupFadeAnimator != null)
                {
                    Private_canvasGroupFadeAnimator.Value = value;
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

        internal string[] __5_intnl_SystemStringArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_SystemStringArray != null)
                {
                    return Private___5_intnl_SystemStringArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_SystemStringArray != null)
                {
                    Private___5_intnl_SystemStringArray.Value = value;
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
        private AstroUdonVariable<bool> Private_waitingToListPatrons { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___15_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private___0_intnl_VRCSDKBaseVRCPlayerApiArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___1_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___12_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___52_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Toggle> Private_mainFlairToggle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___26_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___41_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___1_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_frameTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___29_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___15_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color[]> Private_tierColors { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___33_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
        private AstroUdonVariable<UnityEngine.Camera> Private_textureTransferCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___2_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___34_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private_tierColorHexCodes { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___21_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___42_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___29_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte[]> Private___0_outputBytes_ByteArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___32_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___20_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___34_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___2_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___1_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___1_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_isPresent_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.ContentSizeFitter> Private_contentSizeFitter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_seperatorString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___64_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___0_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___18_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color[]> Private_outputColors { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_success_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___19_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private_frame { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___20_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___3_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___23_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_SCROLL_SYNC_DELAY { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_patronListText_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___27_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___11_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_time_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___1_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.MeshRenderer> Private___0_meshRenderer_MeshRenderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___38_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___31_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___14_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___30_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___11_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___17_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_byte0_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_byte1_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___68_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_localPlayerIsPatron { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___26_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_imageTransform_Transform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___30_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___26_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___54_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal> Private_pedestal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private___3_intnl_UnityEngineUIText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___60_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___37_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_startBufferTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private_presentPatronCountText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___67_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector2> Private___1_intnl_UnityEngineVector2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_textLoadingPlaceholder { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___44_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___17_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Rect> Private___0_intnl_UnityEngineRect { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_PatreonCredits { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_patronName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_newTier_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_timeOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector2> Private___0_intnl_UnityEngineVector2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_this_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___35_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___23_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_input_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private___2_intnl_UnityEngineUIText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_outputString_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_fadeTime { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___24_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private_presentPatronText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___58_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private_onPlayerJoinedPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private___1_intnl_UnityEngineUIText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___16_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_scrollPercent_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___0_outputChars_CharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___0_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Rect> Private___2_intnl_UnityEngineRect { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private___0_intnl_UnityEngineUIText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___21_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___29_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___35_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Rect> Private___1_intnl_UnityEngineRect { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___50_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___22_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___0_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___24_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_doScrollingAnimation { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.ContentSizeFitter.FitMode> Private___0_const_intnl_UnityEngineUIContentSizeFitterFitMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___48_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___30_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___65_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___33_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___57_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_playerName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_rowString_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___10_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_pedestalTransform_Transform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___13_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_fadePercent_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___63_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___36_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_currentTier_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___40_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___25_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___4_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___13_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___6_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___66_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___22_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_mp_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___28_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_scrollTime_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___14_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___47_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___4_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___19_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___31_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___39_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private___0_players_VRCPlayerApiArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.RawImage> Private_textureTransferInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___28_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_CONTENT_FIX_TIME { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___20_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___0_patronRows_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_contentHeight_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___16_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_frameHeight_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___12_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_contentFixed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
        private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_presentPatronString_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___61_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.ContentSizeFitter.FitMode> Private___1_const_intnl_UnityEngineUIContentSizeFitterFitMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___2_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___53_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___27_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_tier_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___32_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Texture2D> Private_transferTexture { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___56_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___18_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___45_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___28_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_presentPatronCount_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___0_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text[]> Private_tierTexts { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___62_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.RectTransform> Private_content { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___0_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___2_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___43_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_MAX_PLAYERS { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___5_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___25_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___3_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___59_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___46_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_returnValSymbol_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___19_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___2_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___24_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Animator> Private_canvasGroupFadeAnimator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___3_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___21_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___27_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___5_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___51_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___0_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___25_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___49_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Material> Private___0_intnl_UnityEngineMaterial { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of PatronCredits

    }
}