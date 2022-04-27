using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Tools.UdonSearcher;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AstroClient.AstroMonos.Components.Cheats.PatronCrackers;

using AstroClient.Tools.UdonEditor;
using ClientAttributes;
using UnhollowerBaseLib.Attributes;
using IntPtr = System.IntPtr;

[RegisterComponent]
public class ImageRenderCameraReader : MonoBehaviour
{
    private readonly Il2CppSystem.Collections.Generic.List<Object> AntiGarbageCollection = new();

    public ImageRenderCameraReader(IntPtr ptr) : base(ptr)
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

                    ClientEventActions.Event_OnRoomLeft += OnRoomLeft;

                }
                else
                {

                    ClientEventActions.Event_OnRoomLeft -= OnRoomLeft;

                }
            }
            _HasSubscribed = value;
        }
    }

    private void OnRoomLeft()
    {
        Destroy(this);
    }

    private RawUdonBehaviour RenderCameraEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

    internal void Start()
    {
        var cam = UdonSearch.FindUdonEvent(this.gameObject, "ReadPictureStep");
        if (cam != null)
        {
            RenderCameraEvent = cam.RawItem;
        }
        if (RenderCameraEvent != null)
        {
            HasSubscribed = true;
            Initialize_RenderCameraEvent();
        }
        if (RenderCameraEvent == null)
        {
            Destroy(this);
        }
    }

    private void OnDestroy()
    {
        Cleanup_RenderCameraEvent();
        HasSubscribed = false;
    }

    private void Initialize_RenderCameraEvent()
    {
        Private___3_intnl_interpolatedStr_String = new AstroUdonVariable<string>(RenderCameraEvent, "__3_intnl_interpolatedStr_String");
        Private_renderTexture = new AstroUdonVariable<UnityEngine.CustomRenderTexture>(RenderCameraEvent, "renderTexture");
        Private___0_intnl_interpolatedStr_String = new AstroUdonVariable<string>(RenderCameraEvent, "__0_intnl_interpolatedStr_String");
        Private___12_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__12_intnl_SystemInt32");
        Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__3_const_intnl_SystemString");
        Private___6_const_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__6_const_intnl_SystemInt32");
        Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__3_const_intnl_exitJumpLoc_UInt32");
        Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(RenderCameraEvent, "__0_const_intnl_SystemBoolean");
        Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__1_const_intnl_SystemInt32");
        Private_byteCache = new AstroUdonVariable<byte[]>(RenderCameraEvent, "byteCache");
        Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__1_intnl_SystemInt32");
        Private___15_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__15_intnl_SystemSingle");
        Private_lastIndex = new AstroUdonVariable<bool>(RenderCameraEvent, "lastIndex");
        Private___1_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__1_intnl_SystemString");
        Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(RenderCameraEvent, "__0_const_intnl_VRCUdonCommonEnumsEventTiming");
        Private___15_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__15_intnl_SystemString");
        Private___0_h_Int32 = new AstroUdonVariable<int>(RenderCameraEvent, "__0_h_Int32");
        Private___0_b_Int32 = new AstroUdonVariable<int>(RenderCameraEvent, "__0_b_Int32");
        Private___0_w_Int32 = new AstroUdonVariable<int>(RenderCameraEvent, "__0_w_Int32");
        Private_hasRun = new AstroUdonVariable<bool>(RenderCameraEvent, "hasRun");
        Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__0_const_intnl_SystemString");
        Private___21_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__21_intnl_SystemSingle");
        Private___7_intnl_SystemByte = new AstroUdonVariable<byte>(RenderCameraEvent, "__7_intnl_SystemByte");
        Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__1_intnl_SystemSingle");
        Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(RenderCameraEvent, "__5_intnl_SystemBoolean");
        Private___10_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__10_const_intnl_exitJumpLoc_UInt32");
        Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__5_intnl_SystemInt32");
        Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__0_const_intnl_exitJumpLoc_UInt32");
        Private_dataLength = new AstroUdonVariable<int>(RenderCameraEvent, "dataLength");
        Private___20_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__20_intnl_SystemString");
        Private___5_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__5_intnl_SystemString");
        Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__6_const_intnl_SystemString");
        Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__5_const_intnl_exitJumpLoc_UInt32");
        Private___2_intnl_SystemByte = new AstroUdonVariable<byte>(RenderCameraEvent, "__2_intnl_SystemByte");
        Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__1_const_intnl_SystemString");
        Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__4_const_intnl_SystemInt32");
        Private_currentOutputString = new AstroUdonVariable<string>(RenderCameraEvent, "currentOutputString");
        Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__5_intnl_SystemSingle");
        Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__2_const_intnl_exitJumpLoc_UInt32");
        Private___0_mp_picture_Texture2D = new AstroUdonVariable<UnityEngine.Texture2D>(RenderCameraEvent, "__0_mp_picture_Texture2D");
        Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__14_const_intnl_SystemString");
        Private___0_firstColor_Color = new AstroUdonVariable<UnityEngine.Color>(RenderCameraEvent, "__0_firstColor_Color");
        Private___19_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__19_intnl_SystemSingle");
        Private___1_intnl_SystemByte = new AstroUdonVariable<byte>(RenderCameraEvent, "__1_intnl_SystemByte");
        Private_colors = new AstroUdonVariable<UnityEngine.Color[]>(RenderCameraEvent, "colors");
        Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__7_const_intnl_exitJumpLoc_UInt32");
        Private___28_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__28_intnl_SystemString");
        Private___2_intnl_interpolatedStr_String = new AstroUdonVariable<string>(RenderCameraEvent, "__2_intnl_interpolatedStr_String");
        Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__7_const_intnl_SystemString");
        Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__15_const_intnl_SystemString");
        Private___27_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__27_intnl_SystemSingle");
        Private___5_const_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__5_const_intnl_SystemInt32");
        Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(RenderCameraEvent, "__refl_const_intnl_udonTypeID");
        Private_callbackEventName = new AstroUdonVariable<string>(RenderCameraEvent, "callbackEventName");
        Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(RenderCameraEvent, "__4_intnl_SystemBoolean");
        Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__11_intnl_SystemSingle");
        Private_loggerText = new AstroUdonVariable<TMPro.TextMeshProUGUI>(RenderCameraEvent, "loggerText");
        Private___4_intnl_SystemByte = new AstroUdonVariable<byte>(RenderCameraEvent, "__4_intnl_SystemByte");
        Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(RenderCameraEvent, "__refl_const_intnl_udonTypeName");
        Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(RenderCameraEvent, "__1_intnl_SystemBoolean");
        Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__17_const_intnl_SystemString");
        Private___11_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__11_intnl_SystemInt32");
        Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__4_const_intnl_SystemString");
        Private___10_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__10_intnl_SystemString");
        Private___20_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__20_const_intnl_SystemString");
        Private___0_intnl_UnityEngineTextureFormat = new AstroUdonVariable<UnityEngine.TextureFormat>(RenderCameraEvent, "__0_intnl_UnityEngineTextureFormat");
        Private___0_c_Color = new AstroUdonVariable<UnityEngine.Color>(RenderCameraEvent, "__0_c_Color");
        Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__2_intnl_SystemInt32");
        Private___26_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__26_intnl_SystemSingle");
        Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__4_const_intnl_exitJumpLoc_UInt32");
        Private___2_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__2_intnl_SystemString");
        Private___21_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__21_const_intnl_SystemString");
        Private___23_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__23_intnl_SystemString");
        Private___9_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__9_const_intnl_exitJumpLoc_UInt32");
        Private___0_mp_bytes_ByteArray = new AstroUdonVariable<byte[]>(RenderCameraEvent, "__0_mp_bytes_ByteArray");
        Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__9_intnl_SystemInt32");
        Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__2_intnl_SystemSingle");
        Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__5_const_intnl_SystemString");
        Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(RenderCameraEvent, "__3_intnl_SystemBoolean");
        Private___9_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__9_intnl_SystemString");
        Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__6_const_intnl_exitJumpLoc_UInt32");
        Private___18_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__18_intnl_SystemString");
        Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__6_intnl_SystemInt32");
        Private___0_intnl_SystemByteArray = new AstroUdonVariable<byte[]>(RenderCameraEvent, "__0_intnl_SystemByteArray");
        Private___17_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__17_intnl_SystemSingle");
        Private___0_intnl_UnityEngineRect = new AstroUdonVariable<UnityEngine.Rect>(RenderCameraEvent, "__0_intnl_UnityEngineRect");
        Private___6_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__6_intnl_SystemString");
        Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(RenderCameraEvent, "__0_intnl_SystemBoolean");
        Private_byteIndex = new AstroUdonVariable<int>(RenderCameraEvent, "byteIndex");
        Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__9_intnl_SystemSingle");
        Private_callBackOnFinish = new AstroUdonVariable<bool>(RenderCameraEvent, "callBackOnFinish");
        Private___22_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__22_intnl_SystemString");
        Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__12_const_intnl_SystemString");
        Private___0_this_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(RenderCameraEvent, "__0_this_intnl_UnityEngineGameObject");
        Private___23_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__23_intnl_SystemSingle");
        Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__8_const_intnl_SystemString");
        Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__6_intnl_SystemSingle");
        Private___24_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__24_intnl_SystemSingle");
        Private___24_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__24_intnl_SystemString");
        Private___16_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__16_intnl_SystemSingle");
        Private___21_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__21_intnl_SystemString");
        Private___13_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__13_intnl_SystemString");
        Private___5_intnl_interpolatedStr_String = new AstroUdonVariable<string>(RenderCameraEvent, "__5_intnl_interpolatedStr_String");
        Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__8_const_intnl_exitJumpLoc_UInt32");
        Private___22_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__22_intnl_SystemSingle");
        Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__9_const_intnl_SystemString");
        Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__0_intnl_SystemInt32");
        Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__0_intnl_returnTarget_UInt32");
        Private___0_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__0_intnl_SystemString");
        Private_empty = new AstroUdonVariable<string>(RenderCameraEvent, "empty");
        Private___10_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__10_intnl_SystemInt32");
        Private_pedestalReady = new AstroUdonVariable<bool>(RenderCameraEvent, "pedestalReady");
        Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__0_const_intnl_SystemUInt32");
        Private_stopwatch = new AstroUdonVariable<System.Diagnostics.Stopwatch>(RenderCameraEvent, "stopwatch");
        Private___13_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__13_intnl_SystemInt32");
        Private___3_intnl_SystemByte = new AstroUdonVariable<byte>(RenderCameraEvent, "__3_intnl_SystemByte");
        Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__0_intnl_SystemSingle");
        Private___29_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__29_intnl_SystemString");
        Private___12_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__12_intnl_SystemString");
        Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__18_const_intnl_SystemString");
        Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__13_intnl_SystemSingle");
        Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__4_intnl_SystemInt32");
        Private_outputToText = new AstroUdonVariable<bool>(RenderCameraEvent, "outputToText");
        Private_colorBytes = new AstroUdonVariable<byte[]>(RenderCameraEvent, "colorBytes");
        Private___6_intnl_SystemByte = new AstroUdonVariable<byte>(RenderCameraEvent, "__6_intnl_SystemByte");
        Private___14_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__14_intnl_SystemSingle");
        Private___4_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__4_intnl_SystemString");
        Private___14_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__14_intnl_SystemString");
        Private___19_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__19_const_intnl_SystemString");
        Private___0_mp_text_String = new AstroUdonVariable<string>(RenderCameraEvent, "__0_mp_text_String");
        Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(RenderCameraEvent, "__6_intnl_SystemBoolean");
        Private___20_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__20_intnl_SystemSingle");
        Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__4_intnl_SystemSingle");
        Private___11_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__11_intnl_SystemString");
        Private___5_intnl_SystemByte = new AstroUdonVariable<byte>(RenderCameraEvent, "__5_intnl_SystemByte");
        Private___27_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__27_intnl_SystemString");
        Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__12_intnl_SystemSingle");
        Private_donorInput = new AstroUdonVariable<UnityEngine.Texture2D>(RenderCameraEvent, "donorInput");
        Private___0_this_intnl_ReadRenderTexture = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__0_this_intnl_ReadRenderTexture");
        Private___0_intnl_SystemInt64 = new AstroUdonVariable<long>(RenderCameraEvent, "__0_intnl_SystemInt64");
        Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__3_intnl_SystemInt32");
        Private_callbackBehaviour = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "callbackBehaviour");
        Private___11_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__11_const_intnl_exitJumpLoc_UInt32");
        Private___1_intnl_interpolatedStr_String = new AstroUdonVariable<string>(RenderCameraEvent, "__1_intnl_interpolatedStr_String");
        Private___3_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__3_intnl_SystemString");
        Private___8_intnl_SystemByte = new AstroUdonVariable<byte>(RenderCameraEvent, "__8_intnl_SystemByte");
        Private_renderQuad = new AstroUdonVariable<UnityEngine.GameObject>(RenderCameraEvent, "renderQuad");
        Private___0_intnl_SystemByte = new AstroUdonVariable<byte>(RenderCameraEvent, "__0_intnl_SystemByte");
        Private___4_intnl_interpolatedStr_String = new AstroUdonVariable<string>(RenderCameraEvent, "__4_intnl_interpolatedStr_String");
        Private___19_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__19_intnl_SystemString");
        Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__2_const_intnl_SystemInt32");
        Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__3_intnl_SystemSingle");
        Private___26_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__26_intnl_SystemString");
        Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__10_const_intnl_SystemString");
        Private_index = new AstroUdonVariable<int>(RenderCameraEvent, "index");
        Private___18_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__18_intnl_SystemSingle");
        Private_outputText = new AstroUdonVariable<TMPro.TextMeshProUGUI>(RenderCameraEvent, "outputText");
        Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__7_intnl_SystemInt32");
        Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(RenderCameraEvent, "__1_const_intnl_SystemBoolean");
        Private___7_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__7_intnl_SystemString");
        Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__11_const_intnl_SystemString");
        Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__16_const_intnl_SystemString");
        Private___0_intnl_UnityEngineTexture2D = new AstroUdonVariable<UnityEngine.Texture2D>(RenderCameraEvent, "__0_intnl_UnityEngineTexture2D");
        Private_stepLength = new AstroUdonVariable<int>(RenderCameraEvent, "stepLength");
        Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(RenderCameraEvent, "__2_intnl_SystemBoolean");
        Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__10_intnl_SystemSingle");
        Private___25_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__25_intnl_SystemSingle");
        Private___0_step_Int32 = new AstroUdonVariable<int>(RenderCameraEvent, "__0_step_Int32");
        Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__3_const_intnl_SystemInt32");
        Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__7_intnl_SystemSingle");
        Private___25_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__25_intnl_SystemString");
        Private___17_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__17_intnl_SystemString");
        Private___0_intnl_returnValSymbol_String = new AstroUdonVariable<string>(RenderCameraEvent, "__0_intnl_returnValSymbol_String");
        Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__13_const_intnl_SystemString");
        Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__8_intnl_SystemInt32");
        Private___8_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__8_intnl_SystemString");
        Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__2_const_intnl_SystemString");
        Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(RenderCameraEvent, "__0_const_intnl_SystemInt32");
        Private___0_intnl_SystemChar = new AstroUdonVariable<char>(RenderCameraEvent, "__0_intnl_SystemChar");
        Private_debugLogger = new AstroUdonVariable<bool>(RenderCameraEvent, "debugLogger");
        Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(RenderCameraEvent, "__1_const_intnl_exitJumpLoc_UInt32");
        Private___22_const_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__22_const_intnl_SystemString");
        Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(RenderCameraEvent, "__8_intnl_SystemSingle");
        Private___16_intnl_SystemString = new AstroUdonVariable<string>(RenderCameraEvent, "__16_intnl_SystemString");
        Private_renderCamera = new AstroUdonVariable<UnityEngine.Camera>(RenderCameraEvent, "renderCamera");
    }

    private void Cleanup_RenderCameraEvent()
    {
        Private___3_intnl_interpolatedStr_String = null;
        Private_renderTexture = null;
        Private___0_intnl_interpolatedStr_String = null;
        Private___12_intnl_SystemInt32 = null;
        Private___3_const_intnl_SystemString = null;
        Private___6_const_intnl_SystemInt32 = null;
        Private___3_const_intnl_exitJumpLoc_UInt32 = null;
        Private___0_const_intnl_SystemBoolean = null;
        Private___1_const_intnl_SystemInt32 = null;
        Private_byteCache = null;
        Private___1_intnl_SystemInt32 = null;
        Private___15_intnl_SystemSingle = null;
        Private_lastIndex = null;
        Private___1_intnl_SystemString = null;
        Private___0_const_intnl_VRCUdonCommonEnumsEventTiming = null;
        Private___15_intnl_SystemString = null;
        Private___0_h_Int32 = null;
        Private___0_b_Int32 = null;
        Private___0_w_Int32 = null;
        Private_hasRun = null;
        Private___0_const_intnl_SystemString = null;
        Private___21_intnl_SystemSingle = null;
        Private___7_intnl_SystemByte = null;
        Private___1_intnl_SystemSingle = null;
        Private___5_intnl_SystemBoolean = null;
        Private___10_const_intnl_exitJumpLoc_UInt32 = null;
        Private___5_intnl_SystemInt32 = null;
        Private___0_const_intnl_exitJumpLoc_UInt32 = null;
        Private_dataLength = null;
        Private___20_intnl_SystemString = null;
        Private___5_intnl_SystemString = null;
        Private___6_const_intnl_SystemString = null;
        Private___5_const_intnl_exitJumpLoc_UInt32 = null;
        Private___2_intnl_SystemByte = null;
        Private___1_const_intnl_SystemString = null;
        Private___4_const_intnl_SystemInt32 = null;
        Private_currentOutputString = null;
        Private___5_intnl_SystemSingle = null;
        Private___2_const_intnl_exitJumpLoc_UInt32 = null;
        Private___0_mp_picture_Texture2D = null;
        Private___14_const_intnl_SystemString = null;
        Private___0_firstColor_Color = null;
        Private___19_intnl_SystemSingle = null;
        Private___1_intnl_SystemByte = null;
        Private_colors = null;
        Private___7_const_intnl_exitJumpLoc_UInt32 = null;
        Private___28_intnl_SystemString = null;
        Private___2_intnl_interpolatedStr_String = null;
        Private___7_const_intnl_SystemString = null;
        Private___15_const_intnl_SystemString = null;
        Private___27_intnl_SystemSingle = null;
        Private___5_const_intnl_SystemInt32 = null;
        Private___refl_const_intnl_udonTypeID = null;
        Private_callbackEventName = null;
        Private___4_intnl_SystemBoolean = null;
        Private___11_intnl_SystemSingle = null;
        Private_loggerText = null;
        Private___4_intnl_SystemByte = null;
        Private___refl_const_intnl_udonTypeName = null;
        Private___1_intnl_SystemBoolean = null;
        Private___17_const_intnl_SystemString = null;
        Private___11_intnl_SystemInt32 = null;
        Private___4_const_intnl_SystemString = null;
        Private___10_intnl_SystemString = null;
        Private___20_const_intnl_SystemString = null;
        Private___0_intnl_UnityEngineTextureFormat = null;
        Private___0_c_Color = null;
        Private___2_intnl_SystemInt32 = null;
        Private___26_intnl_SystemSingle = null;
        Private___4_const_intnl_exitJumpLoc_UInt32 = null;
        Private___2_intnl_SystemString = null;
        Private___21_const_intnl_SystemString = null;
        Private___23_intnl_SystemString = null;
        Private___9_const_intnl_exitJumpLoc_UInt32 = null;
        Private___0_mp_bytes_ByteArray = null;
        Private___9_intnl_SystemInt32 = null;
        Private___2_intnl_SystemSingle = null;
        Private___5_const_intnl_SystemString = null;
        Private___3_intnl_SystemBoolean = null;
        Private___9_intnl_SystemString = null;
        Private___6_const_intnl_exitJumpLoc_UInt32 = null;
        Private___18_intnl_SystemString = null;
        Private___6_intnl_SystemInt32 = null;
        Private___0_intnl_SystemByteArray = null;
        Private___17_intnl_SystemSingle = null;
        Private___0_intnl_UnityEngineRect = null;
        Private___6_intnl_SystemString = null;
        Private___0_intnl_SystemBoolean = null;
        Private_byteIndex = null;
        Private___9_intnl_SystemSingle = null;
        Private_callBackOnFinish = null;
        Private___22_intnl_SystemString = null;
        Private___12_const_intnl_SystemString = null;
        Private___0_this_intnl_UnityEngineGameObject = null;
        Private___23_intnl_SystemSingle = null;
        Private___8_const_intnl_SystemString = null;
        Private___6_intnl_SystemSingle = null;
        Private___24_intnl_SystemSingle = null;
        Private___24_intnl_SystemString = null;
        Private___16_intnl_SystemSingle = null;
        Private___21_intnl_SystemString = null;
        Private___13_intnl_SystemString = null;
        Private___5_intnl_interpolatedStr_String = null;
        Private___8_const_intnl_exitJumpLoc_UInt32 = null;
        Private___22_intnl_SystemSingle = null;
        Private___9_const_intnl_SystemString = null;
        Private___0_intnl_SystemInt32 = null;
        Private___0_intnl_returnTarget_UInt32 = null;
        Private___0_intnl_SystemString = null;
        Private_empty = null;
        Private___10_intnl_SystemInt32 = null;
        Private_pedestalReady = null;
        Private___0_const_intnl_SystemUInt32 = null;
        Private_stopwatch = null;
        Private___13_intnl_SystemInt32 = null;
        Private___3_intnl_SystemByte = null;
        Private___0_intnl_SystemSingle = null;
        Private___29_intnl_SystemString = null;
        Private___12_intnl_SystemString = null;
        Private___18_const_intnl_SystemString = null;
        Private___13_intnl_SystemSingle = null;
        Private___4_intnl_SystemInt32 = null;
        Private_outputToText = null;
        Private_colorBytes = null;
        Private___6_intnl_SystemByte = null;
        Private___14_intnl_SystemSingle = null;
        Private___4_intnl_SystemString = null;
        Private___14_intnl_SystemString = null;
        Private___19_const_intnl_SystemString = null;
        Private___0_mp_text_String = null;
        Private___6_intnl_SystemBoolean = null;
        Private___20_intnl_SystemSingle = null;
        Private___4_intnl_SystemSingle = null;
        Private___11_intnl_SystemString = null;
        Private___5_intnl_SystemByte = null;
        Private___27_intnl_SystemString = null;
        Private___12_intnl_SystemSingle = null;
        Private_donorInput = null;
        Private___0_this_intnl_ReadRenderTexture = null;
        Private___0_intnl_SystemInt64 = null;
        Private___3_intnl_SystemInt32 = null;
        Private_callbackBehaviour = null;
        Private___11_const_intnl_exitJumpLoc_UInt32 = null;
        Private___1_intnl_interpolatedStr_String = null;
        Private___3_intnl_SystemString = null;
        Private___8_intnl_SystemByte = null;
        Private_renderQuad = null;
        Private___0_intnl_SystemByte = null;
        Private___4_intnl_interpolatedStr_String = null;
        Private___19_intnl_SystemString = null;
        Private___2_const_intnl_SystemInt32 = null;
        Private___3_intnl_SystemSingle = null;
        Private___26_intnl_SystemString = null;
        Private___10_const_intnl_SystemString = null;
        Private_index = null;
        Private___18_intnl_SystemSingle = null;
        Private_outputText = null;
        Private___7_intnl_SystemInt32 = null;
        Private___1_const_intnl_SystemBoolean = null;
        Private___7_intnl_SystemString = null;
        Private___11_const_intnl_SystemString = null;
        Private___16_const_intnl_SystemString = null;
        Private___0_intnl_UnityEngineTexture2D = null;
        Private_stepLength = null;
        Private___2_intnl_SystemBoolean = null;
        Private___10_intnl_SystemSingle = null;
        Private___25_intnl_SystemSingle = null;
        Private___0_step_Int32 = null;
        Private___3_const_intnl_SystemInt32 = null;
        Private___7_intnl_SystemSingle = null;
        Private___25_intnl_SystemString = null;
        Private___17_intnl_SystemString = null;
        Private___0_intnl_returnValSymbol_String = null;
        Private___13_const_intnl_SystemString = null;
        Private___8_intnl_SystemInt32 = null;
        Private___8_intnl_SystemString = null;
        Private___2_const_intnl_SystemString = null;
        Private___0_const_intnl_SystemInt32 = null;
        Private___0_intnl_SystemChar = null;
        Private_debugLogger = null;
        Private___1_const_intnl_exitJumpLoc_UInt32 = null;
        Private___22_const_intnl_SystemString = null;
        Private___8_intnl_SystemSingle = null;
        Private___16_intnl_SystemString = null;
        Private_renderCamera = null;
    }

    #region Getter / Setters AstroUdonVariables  of RenderCameraEvent

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

    internal UnityEngine.CustomRenderTexture renderTexture
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_renderTexture != null)
            {
                return Private_renderTexture.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_renderTexture != null)
            {
                Private_renderTexture.Value = value;
            }
        }
    }

    internal string __0_intnl_interpolatedStr_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_interpolatedStr_String != null)
            {
                return Private___0_intnl_interpolatedStr_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_interpolatedStr_String != null)
            {
                Private___0_intnl_interpolatedStr_String.Value = value;
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

    internal byte[] byteCache
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_byteCache != null)
            {
                return Private_byteCache.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_byteCache != null)
            {
                Private_byteCache.Value = value;
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

    internal bool? lastIndex
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_lastIndex != null)
            {
                return Private_lastIndex.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_lastIndex != null)
                {
                    Private_lastIndex.Value = value.Value;
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

    internal int? __0_h_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_h_Int32 != null)
            {
                return Private___0_h_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_h_Int32 != null)
                {
                    Private___0_h_Int32.Value = value.Value;
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

    internal int? __0_w_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_w_Int32 != null)
            {
                return Private___0_w_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_w_Int32 != null)
                {
                    Private___0_w_Int32.Value = value.Value;
                }
            }
        }
    }

    internal bool? hasRun
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_hasRun != null)
            {
                return Private_hasRun.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_hasRun != null)
                {
                    Private_hasRun.Value = value.Value;
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

    internal byte? __7_intnl_SystemByte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___7_intnl_SystemByte != null)
            {
                return Private___7_intnl_SystemByte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___7_intnl_SystemByte != null)
                {
                    Private___7_intnl_SystemByte.Value = value.Value;
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

    internal int? dataLength
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_dataLength != null)
            {
                return Private_dataLength.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_dataLength != null)
                {
                    Private_dataLength.Value = value.Value;
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

    internal byte? __2_intnl_SystemByte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___2_intnl_SystemByte != null)
            {
                return Private___2_intnl_SystemByte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___2_intnl_SystemByte != null)
                {
                    Private___2_intnl_SystemByte.Value = value.Value;
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

    internal string currentOutputString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_currentOutputString != null)
            {
                return Private_currentOutputString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_currentOutputString != null)
            {
                Private_currentOutputString.Value = value;
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

    internal UnityEngine.Texture2D __0_mp_picture_Texture2D
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_picture_Texture2D != null)
            {
                return Private___0_mp_picture_Texture2D.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_picture_Texture2D != null)
            {
                Private___0_mp_picture_Texture2D.Value = value;
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

    internal UnityEngine.Color? __0_firstColor_Color
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_firstColor_Color != null)
            {
                return Private___0_firstColor_Color.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_firstColor_Color != null)
                {
                    Private___0_firstColor_Color.Value = value.Value;
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

    internal byte? __1_intnl_SystemByte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___1_intnl_SystemByte != null)
            {
                return Private___1_intnl_SystemByte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___1_intnl_SystemByte != null)
                {
                    Private___1_intnl_SystemByte.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Color[] colors
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_colors != null)
            {
                return Private_colors.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_colors != null)
            {
                Private_colors.Value = value;
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

    internal string __28_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___28_intnl_SystemString != null)
            {
                return Private___28_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___28_intnl_SystemString != null)
            {
                Private___28_intnl_SystemString.Value = value;
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

    internal string callbackEventName
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_callbackEventName != null)
            {
                return Private_callbackEventName.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_callbackEventName != null)
            {
                Private_callbackEventName.Value = value;
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

    internal TMPro.TextMeshProUGUI loggerText
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_loggerText != null)
            {
                return Private_loggerText.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_loggerText != null)
            {
                Private_loggerText.Value = value;
            }
        }
    }

    internal byte? __4_intnl_SystemByte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___4_intnl_SystemByte != null)
            {
                return Private___4_intnl_SystemByte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___4_intnl_SystemByte != null)
                {
                    Private___4_intnl_SystemByte.Value = value.Value;
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

    internal UnityEngine.TextureFormat? __0_intnl_UnityEngineTextureFormat
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_UnityEngineTextureFormat != null)
            {
                return Private___0_intnl_UnityEngineTextureFormat.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_intnl_UnityEngineTextureFormat != null)
                {
                    Private___0_intnl_UnityEngineTextureFormat.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.Color? __0_c_Color
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_c_Color != null)
            {
                return Private___0_c_Color.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_c_Color != null)
                {
                    Private___0_c_Color.Value = value.Value;
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

    internal byte[] __0_mp_bytes_ByteArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_bytes_ByteArray != null)
            {
                return Private___0_mp_bytes_ByteArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_bytes_ByteArray != null)
            {
                Private___0_mp_bytes_ByteArray.Value = value;
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

    internal byte[] __0_intnl_SystemByteArray
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_SystemByteArray != null)
            {
                return Private___0_intnl_SystemByteArray.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_SystemByteArray != null)
            {
                Private___0_intnl_SystemByteArray.Value = value;
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

    internal int? byteIndex
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_byteIndex != null)
            {
                return Private_byteIndex.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_byteIndex != null)
                {
                    Private_byteIndex.Value = value.Value;
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

    internal bool? callBackOnFinish
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_callBackOnFinish != null)
            {
                return Private_callBackOnFinish.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_callBackOnFinish != null)
                {
                    Private_callBackOnFinish.Value = value.Value;
                }
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

    internal string empty
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_empty != null)
            {
                return Private_empty.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_empty != null)
            {
                Private_empty.Value = value;
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

    internal bool? pedestalReady
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_pedestalReady != null)
            {
                return Private_pedestalReady.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_pedestalReady != null)
                {
                    Private_pedestalReady.Value = value.Value;
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

    internal System.Diagnostics.Stopwatch stopwatch
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_stopwatch != null)
            {
                return Private_stopwatch.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_stopwatch != null)
            {
                Private_stopwatch.Value = value;
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

    internal byte? __3_intnl_SystemByte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___3_intnl_SystemByte != null)
            {
                return Private___3_intnl_SystemByte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___3_intnl_SystemByte != null)
                {
                    Private___3_intnl_SystemByte.Value = value.Value;
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

    internal string __29_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___29_intnl_SystemString != null)
            {
                return Private___29_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___29_intnl_SystemString != null)
            {
                Private___29_intnl_SystemString.Value = value;
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

    internal bool? outputToText
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_outputToText != null)
            {
                return Private_outputToText.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_outputToText != null)
                {
                    Private_outputToText.Value = value.Value;
                }
            }
        }
    }

    internal byte[] colorBytes
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_colorBytes != null)
            {
                return Private_colorBytes.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_colorBytes != null)
            {
                Private_colorBytes.Value = value;
            }
        }
    }

    internal byte? __6_intnl_SystemByte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___6_intnl_SystemByte != null)
            {
                return Private___6_intnl_SystemByte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___6_intnl_SystemByte != null)
                {
                    Private___6_intnl_SystemByte.Value = value.Value;
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

    internal string __0_mp_text_String
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_mp_text_String != null)
            {
                return Private___0_mp_text_String.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_mp_text_String != null)
            {
                Private___0_mp_text_String.Value = value;
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

    internal byte? __5_intnl_SystemByte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___5_intnl_SystemByte != null)
            {
                return Private___5_intnl_SystemByte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___5_intnl_SystemByte != null)
                {
                    Private___5_intnl_SystemByte.Value = value.Value;
                }
            }
        }
    }

    internal string __27_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___27_intnl_SystemString != null)
            {
                return Private___27_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___27_intnl_SystemString != null)
            {
                Private___27_intnl_SystemString.Value = value;
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

    internal UnityEngine.Texture2D donorInput
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_donorInput != null)
            {
                return Private_donorInput.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_donorInput != null)
            {
                Private_donorInput.Value = value;
            }
        }
    }

    internal VRC.Udon.UdonBehaviour __0_this_intnl_ReadRenderTexture
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_this_intnl_ReadRenderTexture != null)
            {
                return Private___0_this_intnl_ReadRenderTexture.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_this_intnl_ReadRenderTexture != null)
            {
                Private___0_this_intnl_ReadRenderTexture.Value = value;
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

    internal VRC.Udon.UdonBehaviour callbackBehaviour
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_callbackBehaviour != null)
            {
                return Private_callbackBehaviour.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_callbackBehaviour != null)
            {
                Private_callbackBehaviour.Value = value;
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

    internal byte? __8_intnl_SystemByte
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___8_intnl_SystemByte != null)
            {
                return Private___8_intnl_SystemByte.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___8_intnl_SystemByte != null)
                {
                    Private___8_intnl_SystemByte.Value = value.Value;
                }
            }
        }
    }

    internal UnityEngine.GameObject renderQuad
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_renderQuad != null)
            {
                return Private_renderQuad.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_renderQuad != null)
            {
                Private_renderQuad.Value = value;
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

    internal string __26_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___26_intnl_SystemString != null)
            {
                return Private___26_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___26_intnl_SystemString != null)
            {
                Private___26_intnl_SystemString.Value = value;
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

    internal int? index
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_index != null)
            {
                return Private_index.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_index != null)
                {
                    Private_index.Value = value.Value;
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

    internal TMPro.TextMeshProUGUI outputText
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_outputText != null)
            {
                return Private_outputText.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_outputText != null)
            {
                Private_outputText.Value = value;
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

    internal UnityEngine.Texture2D __0_intnl_UnityEngineTexture2D
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_intnl_UnityEngineTexture2D != null)
            {
                return Private___0_intnl_UnityEngineTexture2D.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_intnl_UnityEngineTexture2D != null)
            {
                Private___0_intnl_UnityEngineTexture2D.Value = value;
            }
        }
    }

    internal int? stepLength
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_stepLength != null)
            {
                return Private_stepLength.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_stepLength != null)
                {
                    Private_stepLength.Value = value.Value;
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

    internal int? __0_step_Int32
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_step_Int32 != null)
            {
                return Private___0_step_Int32.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_step_Int32 != null)
                {
                    Private___0_step_Int32.Value = value.Value;
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

    internal string __25_intnl_SystemString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___25_intnl_SystemString != null)
            {
                return Private___25_intnl_SystemString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___25_intnl_SystemString != null)
            {
                Private___25_intnl_SystemString.Value = value;
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

    internal bool? debugLogger
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_debugLogger != null)
            {
                return Private_debugLogger.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_debugLogger != null)
                {
                    Private_debugLogger.Value = value.Value;
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

    internal UnityEngine.Camera renderCamera
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_renderCamera != null)
            {
                return Private_renderCamera.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_renderCamera != null)
            {
                Private_renderCamera.Value = value;
            }
        }
    }

    #endregion Getter / Setters AstroUdonVariables  of RenderCameraEvent

    #region AstroUdonVariables  of RenderCameraEvent

    private AstroUdonVariable<string> Private___3_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.CustomRenderTexture> Private_renderTexture { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___12_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___6_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte[]> Private_byteCache { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___15_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_lastIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___0_const_intnl_VRCUdonCommonEnumsEventTiming { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___15_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_h_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_b_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_w_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_hasRun { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___21_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___7_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___10_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_dataLength { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___20_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___2_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private_currentOutputString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private___0_mp_picture_Texture2D { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private___0_firstColor_Color { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___19_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___1_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color[]> Private_colors { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___28_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___27_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___5_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private_callbackEventName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___11_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_loggerText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___4_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___11_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___10_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___20_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.TextureFormat> Private___0_intnl_UnityEngineTextureFormat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color> Private___0_c_Color { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___26_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___21_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___23_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___9_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte[]> Private___0_mp_bytes_ByteArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___9_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___18_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte[]> Private___0_intnl_SystemByteArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___17_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Rect> Private___0_intnl_UnityEngineRect { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___6_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_byteIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_callBackOnFinish { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___22_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___0_this_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___23_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___24_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___24_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___16_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___21_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___13_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___5_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___22_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private_empty { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___10_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_pedestalReady { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<System.Diagnostics.Stopwatch> Private_stopwatch { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___13_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___3_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___29_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___12_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___13_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_outputToText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte[]> Private_colorBytes { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___6_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___14_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___14_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___19_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_mp_text_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___20_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___11_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___5_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___27_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___12_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private_donorInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_ReadRenderTexture { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___0_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_callbackBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___11_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___1_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___8_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private_renderQuad { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___0_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___4_intnl_interpolatedStr_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___19_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___26_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_index { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___18_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_outputText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___7_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private___0_intnl_UnityEngineTexture2D { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_stepLength { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___25_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_step_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___25_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___17_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_intnl_returnValSymbol_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___8_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___0_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_debugLogger { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___22_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___16_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Camera> Private_renderCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

    #endregion AstroUdonVariables  of RenderCameraEvent

    // Use this for initialization
}