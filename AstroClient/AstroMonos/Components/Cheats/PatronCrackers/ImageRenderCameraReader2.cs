using System.Linq;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.ClientActions;
using AstroClient.Tools.UdonSearcher;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC.Udon;
using Object = UnityEngine.Object;

namespace AstroClient.AstroMonos.Components.Cheats.PatronCrackers;

using AstroClient.Tools.UdonEditor;
using ClientAttributes;
using UnhollowerBaseLib.Attributes;
using IntPtr = System.IntPtr;

[RegisterComponent]
public class ImageRenderCameraReader2 : MonoBehaviour
{
    private readonly Il2CppSystem.Collections.Generic.List<Object> AntiGarbageCollection = new();

    public ImageRenderCameraReader2(IntPtr ptr) : base(ptr)
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
                    ClientEventActions.Udon_SendCustomEvent += UdonSendCustomEvent;
                }
                else
                {
                    ClientEventActions.OnRoomLeft -= OnRoomLeft;
                    ClientEventActions.Udon_SendCustomEvent -= UdonSendCustomEvent;

                }
            }
            _HasSubscribed = value;
        }
    }

    private void UdonSendCustomEvent(UdonBehaviour arg1, string arg2)
    {
        if (arg1 != null)
        {
            if (arg1.gameObject.name == gameObject.name)
            {
                HijackUdon();
            }
        }
    }
    private string PatchList(string list, string FieldName)
    {
        if (list.IsNotNullOrEmptyOrWhiteSpace())
        {
            bool HasBeenModified = false;
            var result = list.ReadLines().ToList();
            if (result != null && result.Count != 0)
            {
                if (!result.Contains(PlayerSpooferUtils.Original_DisplayName))
                {
                    Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in {FieldName}..");
                    result.Insert(0, PlayerSpooferUtils.Original_DisplayName);
                    result.Insert(result.Count, PlayerSpooferUtils.Original_DisplayName);
                    HasBeenModified = true;
                }
                if (GameInstances.LocalPlayer != null)
                {
                    if (!result.Contains(GameInstances.LocalPlayer.displayName))
                    {
                        Log.Debug($"Adding {PlayerSpooferUtils.Original_DisplayName} in {FieldName}..");
                        result.Insert(1, GameInstances.LocalPlayer.displayName);
                        result.Insert(result.Count, GameInstances.LocalPlayer.displayName);
                        HasBeenModified = true;
                    }
                }
            }
            if (HasBeenModified)
            {
                return string.Join("\n", result); ;
            }
        }
        return list;
    }

    private void OnRoomLeft()
    {
        Destroy(this);
    }

    private RawUdonBehaviour RenderCameraEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

    internal void Start()
    {
        var cam = UdonSearch.FindUdonEvent(this.gameObject, "_ReadPictureStep");
        if (cam != null)
        {
            RenderCameraEvent = cam.RawItem;
        }
        if (RenderCameraEvent != null)
        {
            HasSubscribed = true;
            Initialize_RenderCameraEvent();
            HijackUdon();
        }
        if (RenderCameraEvent == null)
        {
            Destroy(this);
        }
    }

    internal void HijackUdon()
    {
        if (__intnl_SystemString_15 != null)
        {
            var patch = PatchList(__intnl_SystemString_15, "__intnl_SystemString_15");
            __intnl_SystemString_15 = patch;

        }

        if (outputString != null)
        {
            var patch = PatchList(outputString, "outputString");
            outputString = patch;

        }


    }

    private void OnDestroy()
    {
        Cleanup_RenderCameraEvent();
        HasSubscribed = false;
    }

    private void Initialize_RenderCameraEvent()
    {
        Private___intnl_SystemBoolean_13 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_13");
        Private___intnl_SystemBoolean_23 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_23");
        Private___gintnl_SystemUInt32_16 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_16");
        Private___gintnl_SystemUInt32_26 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_26");
        Private___intnl_SystemInt32_15 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_15");
        Private___intnl_SystemInt32_35 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_35");
        Private___intnl_SystemInt32_25 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_25");
        Private___intnl_SystemInt32_55 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_55");
        Private___intnl_SystemInt32_45 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_45");
        Private_nextAvatar = new AstroUdonVariable<string>(RenderCameraEvent, "nextAvatar");
        Private_charIndex = new AstroUdonVariable<int>(RenderCameraEvent, "charIndex");
        Private_avatarCounter = new AstroUdonVariable<int>(RenderCameraEvent, "avatarCounter");
        Private_renderTexture = new AstroUdonVariable<UnityEngine.CustomRenderTexture>(RenderCameraEvent, "renderTexture");
        Private___gintnl_SystemObjectArray_1 = new AstroUdonVariable<System.Object[]>(RenderCameraEvent, "__gintnl_SystemObjectArray_1");
        Private___intnl_UnityEngineMaterial_0 = new AstroUdonVariable<UnityEngine.Material>(RenderCameraEvent, "__intnl_UnityEngineMaterial_0");
        Private___intnl_UnityEngineObject_12 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__intnl_UnityEngineObject_12");
        Private___const_SystemByte_1 = new AstroUdonVariable<byte>(RenderCameraEvent, "__const_SystemByte_1");
        Private___intnl_SystemSingle_0 = new AstroUdonVariable<float>(RenderCameraEvent, "__intnl_SystemSingle_0");
        Private___intnl_SystemChar_1 = new AstroUdonVariable<char>(RenderCameraEvent, "__intnl_SystemChar_1");
        Private_pedestalMaterial = new AstroUdonVariable<UnityEngine.Material>(RenderCameraEvent, "pedestalMaterial");
        Private___const_SystemString_0 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_0");
        Private___intnl_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(RenderCameraEvent, "__intnl_UnityEngineTransform_0");
        Private___lcl_value_SystemByte_0 = new AstroUdonVariable<byte>(RenderCameraEvent, "__lcl_value_SystemByte_0");
        Private___const_SystemSingle_0 = new AstroUdonVariable<float>(RenderCameraEvent, "__const_SystemSingle_0");
        Private_hasRun = new AstroUdonVariable<bool>(RenderCameraEvent, "hasRun");
        Private___lcl_isNew_UnityEngineColor32_0 = new AstroUdonVariable<UnityEngine.Color32>(RenderCameraEvent, "__lcl_isNew_UnityEngineColor32_0");
        Private_dataMode = new AstroUdonVariable<int>(RenderCameraEvent, "dataMode");
        Private___intnl_SystemBoolean_16 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_16");
        Private___intnl_SystemBoolean_26 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_26");
        Private_debugTMP = new AstroUdonVariable<bool>(RenderCameraEvent, "debugTMP");
        Private___const_SystemInt32_11 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_11");
        Private___const_SystemInt32_21 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_21");
        Private___intnl_SystemInt32_12 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_12");
        Private___intnl_SystemInt32_32 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_32");
        Private___intnl_SystemInt32_22 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_22");
        Private___intnl_SystemInt32_52 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_52");
        Private___intnl_SystemInt32_42 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_42");
        Private___lcl_now_SystemDateTime_0 = new AstroUdonVariable<System.DateTime>(RenderCameraEvent, "__lcl_now_SystemDateTime_0");
        Private___intnl_SystemString_9 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_9");
        Private___lcl_idColor_UnityEngineColor32_0 = new AstroUdonVariable<UnityEngine.Color32>(RenderCameraEvent, "__lcl_idColor_UnityEngineColor32_0");
        Private___intnl_SystemByte_3 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_3");
        Private___gintnl_SystemUInt32_9 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_9");
        Private___gintnl_SystemUInt32_8 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_8");
        Private___gintnl_SystemUInt32_5 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_5");
        Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_4");
        Private___gintnl_SystemUInt32_7 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_7");
        Private___gintnl_SystemUInt32_6 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_6");
        Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_1");
        Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_0");
        Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_3");
        Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_2");
        Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(RenderCameraEvent, "__const_SystemBoolean_0");
        Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(RenderCameraEvent, "__const_SystemBoolean_1");
        Private___const_SystemByte_2 = new AstroUdonVariable<byte>(RenderCameraEvent, "__const_SystemByte_2");
        Private_dataLength = new AstroUdonVariable<int>(RenderCameraEvent, "dataLength");
        Private___intnl_UnityEngineMeshRenderer_0 = new AstroUdonVariable<UnityEngine.MeshRenderer>(RenderCameraEvent, "__intnl_UnityEngineMeshRenderer_0");
        Private___intnl_UnityEngineMeshRenderer_1 = new AstroUdonVariable<UnityEngine.MeshRenderer>(RenderCameraEvent, "__intnl_UnityEngineMeshRenderer_1");
        Private___const_SystemString_5 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_5");
        Private___intnl_UnityEngineColor32_0 = new AstroUdonVariable<UnityEngine.Color32>(RenderCameraEvent, "__intnl_UnityEngineColor32_0");
        Private___const_SystemInt32_19 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_19");
        Private___gintnl_SystemUInt32_13 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_13");
        Private___gintnl_SystemUInt32_23 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_23");
        Private___intnl_UnityEngineObject_8 = new AstroUdonVariable<UnityEngine.CustomRenderTexture>(RenderCameraEvent, "__intnl_UnityEngineObject_8");
        Private___intnl_UnityEngineObject_4 = new AstroUdonVariable<UnityEngine.MeshRenderer>(RenderCameraEvent, "__intnl_UnityEngineObject_4");
        Private___intnl_UnityEngineObject_2 = new AstroUdonVariable<UnityEngine.Texture2D>(RenderCameraEvent, "__intnl_UnityEngineObject_2");
        Private___intnl_UnityEngineObject_0 = new AstroUdonVariable<UnityEngine.Transform>(RenderCameraEvent, "__intnl_UnityEngineObject_0");
        Private___const_SystemInt32_16 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_16");
        Private_decodeSpeedUTF8 = new AstroUdonVariable<int>(RenderCameraEvent, "decodeSpeedUTF8");
        Private___intnl_SystemString_6 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_6");
        Private___const_SystemString_16 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_16");
        Private___const_SystemString_17 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_17");
        Private___const_SystemString_14 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_14");
        Private___const_SystemString_15 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_15");
        Private___const_SystemString_12 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_12");
        Private___const_SystemString_13 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_13");
        Private___const_SystemString_10 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_10");
        Private___const_SystemString_11 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_11");
        Private___const_SystemString_18 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_18");
        Private___const_SystemString_19 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_19");
        Private___intnl_SystemByte_4 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_4");
        Private_color = new AstroUdonVariable<UnityEngine.Color32>(RenderCameraEvent, "color");
        Private_pixelIndex = new AstroUdonVariable<int>(RenderCameraEvent, "pixelIndex");
        Private___intnl_UnityEngineObject_14 = new AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal>(RenderCameraEvent, "__intnl_UnityEngineObject_14");
        Private___refl_typeid = new AstroUdonVariable<long>(RenderCameraEvent, "__refl_typeid");
        Private_lastInput = new AstroUdonVariable<UnityEngine.Texture2D>(RenderCameraEvent, "lastInput");
        Private_colors = new AstroUdonVariable<UnityEngine.Color32[]>(RenderCameraEvent, "colors");
        Private_autoFillTMP = new AstroUdonVariable<bool>(RenderCameraEvent, "autoFillTMP");
        Private___lcl_toIterate_SystemInt32_0 = new AstroUdonVariable<int>(RenderCameraEvent, "__lcl_toIterate_SystemInt32_0");
        Private___lcl_toIterate_SystemInt32_1 = new AstroUdonVariable<int>(RenderCameraEvent, "__lcl_toIterate_SystemInt32_1");
        Private___lcl_toIterate_SystemInt32_2 = new AstroUdonVariable<int>(RenderCameraEvent, "__lcl_toIterate_SystemInt32_2");
        Private_bytesCount = new AstroUdonVariable<int>(RenderCameraEvent, "bytesCount");
        Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(RenderCameraEvent, "__const_SystemUInt32_0");
        Private___intnl_UnityEngineComponent_0 = new AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal>(RenderCameraEvent, "__intnl_UnityEngineComponent_0");
        Private___intnl_SystemBoolean_11 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_11");
        Private___intnl_SystemBoolean_21 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_21");
        Private_callbackEventName = new AstroUdonVariable<string>(RenderCameraEvent, "callbackEventName");
        Private___intnl_UnityEngineColor32_3 = new AstroUdonVariable<UnityEngine.Color32>(RenderCameraEvent, "__intnl_UnityEngineColor32_3");
        Private___gintnl_SystemUInt32_14 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_14");
        Private___gintnl_SystemUInt32_24 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_24");
        Private___intnl_SystemInt32_17 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_17");
        Private___intnl_SystemInt32_37 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_37");
        Private___intnl_SystemInt32_27 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_27");
        Private___intnl_SystemInt32_57 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_57");
        Private___intnl_SystemInt32_47 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_47");
        Private___intnl_SystemString_3 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_3");
        Private___0__intnlparam = new AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal>(RenderCameraEvent, "__0__intnlparam");
        Private___const_SystemString_2 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_2");
        Private___const_SystemSingle_2 = new AstroUdonVariable<float>(RenderCameraEvent, "__const_SystemSingle_2");
        Private___intnl_SystemBoolean_19 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_19");
        Private___intnl_UnityEngineGameObject_1 = new AstroUdonVariable<UnityEngine.GameObject>(RenderCameraEvent, "__intnl_UnityEngineGameObject_1");
        Private___intnl_SystemBoolean_14 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_14");
        Private___intnl_SystemBoolean_24 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_24");
        Private___const_SystemInt32_13 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_13");
        Private___const_SystemInt32_23 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_23");
        Private_pedestalTexture = new AstroUdonVariable<UnityEngine.Texture2D>(RenderCameraEvent, "pedestalTexture");
        Private___0_text__param = new AstroUdonVariable<string>(RenderCameraEvent, "__0_text__param");
        Private___intnl_SystemInt32_14 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_14");
        Private___intnl_SystemInt32_34 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_34");
        Private___intnl_SystemInt32_24 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_24");
        Private___intnl_SystemInt32_54 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_54");
        Private___intnl_SystemInt32_44 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_44");
        Private_pedestal = new AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal>(RenderCameraEvent, "pedestal");
        Private_currentTry = new AstroUdonVariable<int>(RenderCameraEvent, "currentTry");
        Private___lcl_maxDataLength_SystemInt32_0 = new AstroUdonVariable<int>(RenderCameraEvent, "__lcl_maxDataLength_SystemInt32_0");
        Private___intnl_SystemInt32_19 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_19");
        Private___intnl_SystemInt32_39 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_39");
        Private___intnl_SystemInt32_29 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_29");
        Private___intnl_SystemInt32_59 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_59");
        Private___intnl_SystemInt32_49 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_49");
        Private___intnl_SystemString_0 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_0");
        Private___intnl_SystemByte_1 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_1");
        Private___const_SystemByte_0 = new AstroUdonVariable<byte>(RenderCameraEvent, "__const_SystemByte_0");
        Private___0_picture__param = new AstroUdonVariable<UnityEngine.Texture2D>(RenderCameraEvent, "__0_picture__param");
        Private___intnl_UnityEngineRect_0 = new AstroUdonVariable<UnityEngine.Rect>(RenderCameraEvent, "__intnl_UnityEngineRect_0");
        Private___intnl_SystemSingle_1 = new AstroUdonVariable<float>(RenderCameraEvent, "__intnl_SystemSingle_1");
        Private___lcl_headerInfo_UnityEngineColor32_0 = new AstroUdonVariable<UnityEngine.Color32>(RenderCameraEvent, "__lcl_headerInfo_UnityEngineColor32_0");
        Private__utf8Chars = new AstroUdonVariable<string[]>(RenderCameraEvent, "_utf8Chars");
        Private___intnl_SystemChar_0 = new AstroUdonVariable<char>(RenderCameraEvent, "__intnl_SystemChar_0");
        Private___const_SystemString_7 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_7");
        Private_linkedAvatars = new AstroUdonVariable<string[]>(RenderCameraEvent, "linkedAvatars");
        Private___const_SystemSingle_1 = new AstroUdonVariable<float>(RenderCameraEvent, "__const_SystemSingle_1");
        Private_byteIndex = new AstroUdonVariable<int>(RenderCameraEvent, "byteIndex");
        Private___gintnl_SystemUInt32_11 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_11");
        Private___gintnl_SystemUInt32_21 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_21");
        Private___intnl_SystemBoolean_17 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_17");
        Private___intnl_SystemBoolean_27 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_27");
        Private_callBackOnFinish = new AstroUdonVariable<bool>(RenderCameraEvent, "callBackOnFinish");
        Private___const_SystemInt32_10 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_10");
        Private___const_SystemInt32_20 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_20");
        Private___const_VRCUdonCommonEnumsEventTiming_0 = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(RenderCameraEvent, "__const_VRCUdonCommonEnumsEventTiming_0");
        Private___intnl_SystemInt32_11 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_11");
        Private___intnl_SystemInt32_31 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_31");
        Private___intnl_SystemInt32_21 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_21");
        Private___intnl_SystemInt32_51 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_51");
        Private___intnl_SystemInt32_41 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_41");
        Private___lcl_temp_SystemByteArray_0 = new AstroUdonVariable<byte[]>(RenderCameraEvent, "__lcl_temp_SystemByteArray_0");
        Private___intnl_SystemString_8 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_8");
        Private___intnl_SystemByte_9 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_9");
        Private_debugLogging = new AstroUdonVariable<bool>(RenderCameraEvent, "debugLogging");
        Private___const_SystemString_34 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_34");
        Private___const_SystemString_32 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_32");
        Private___const_SystemString_33 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_33");
        Private___const_SystemString_30 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_30");
        Private___const_SystemString_31 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_31");
        Private___intnl_SystemByte_2 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_2");
        Private_transferSpeed = new AstroUdonVariable<int>(RenderCameraEvent, "transferSpeed");
        Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(RenderCameraEvent, "__intnl_returnJump_SystemUInt32_0");
        Private_character = new AstroUdonVariable<int>(RenderCameraEvent, "character");
        Private_avatarBytes = new AstroUdonVariable<byte[]>(RenderCameraEvent, "avatarBytes");
        Private___const_SystemString_4 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_4");
        Private_imageMode = new AstroUdonVariable<int>(RenderCameraEvent, "imageMode");
        Private___gintnl_SystemUInt32_19 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_19");
        Private___gintnl_SystemUInt32_29 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_29");
        Private___intnl_UnityEngineColor32_1 = new AstroUdonVariable<UnityEngine.Color32>(RenderCameraEvent, "__intnl_UnityEngineColor32_1");
        Private___const_SystemInt32_18 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_18");
        Private___gintnl_SystemUInt32_12 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_12");
        Private___gintnl_SystemUInt32_22 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_22");
        Private___lcl_child_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(RenderCameraEvent, "__lcl_child_UnityEngineTransform_0");
        Private___lcl_i_SystemInt32_1 = new AstroUdonVariable<int>(RenderCameraEvent, "__lcl_i_SystemInt32_1");
        Private___lcl_i_SystemInt32_0 = new AstroUdonVariable<int>(RenderCameraEvent, "__lcl_i_SystemInt32_0");
        Private___const_SystemInt32_15 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_15");
        Private_charCounter = new AstroUdonVariable<byte>(RenderCameraEvent, "charCounter");
        Private_patronMode = new AstroUdonVariable<bool>(RenderCameraEvent, "patronMode");
        Private___intnl_SystemByte_17 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_17");
        Private___intnl_SystemByte_16 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_16");
        Private___intnl_SystemByte_15 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_15");
        Private___intnl_SystemByte_14 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_14");
        Private___intnl_SystemByte_13 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_13");
        Private___intnl_SystemByte_12 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_12");
        Private___intnl_SystemByte_11 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_11");
        Private___intnl_SystemByte_10 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_10");
        Private___intnl_SystemString_5 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_5");
        Private___intnl_SystemByte_7 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_7");
        Private___1__intnlparam = new AstroUdonVariable<UnityEngine.Transform>(RenderCameraEvent, "__1__intnlparam");
        Private___intnl_UnityEngineObject_15 = new AstroUdonVariable<UnityEngine.GameObject>(RenderCameraEvent, "__intnl_UnityEngineObject_15");
        Private_pedestalReady = new AstroUdonVariable<bool>(RenderCameraEvent, "pedestalReady");
        Private_frameSkip = new AstroUdonVariable<bool>(RenderCameraEvent, "frameSkip");
        Private_outputBytes = new AstroUdonVariable<byte[]>(RenderCameraEvent, "outputBytes");
        Private___0_IsSame__ret = new AstroUdonVariable<bool>(RenderCameraEvent, "__0_IsSame__ret");
        Private___const_SystemString_9 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_9");
        Private___intnl_UnityEngineTextureFormat_0 = new AstroUdonVariable<UnityEngine.TextureFormat>(RenderCameraEvent, "__intnl_UnityEngineTextureFormat_0");
        Private___intnl_SystemBoolean_12 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_12");
        Private___intnl_SystemBoolean_22 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_22");
        Private___gintnl_SystemUInt32_17 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_17");
        Private___gintnl_SystemUInt32_27 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_27");
        Private___intnl_SystemInt32_16 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_16");
        Private___intnl_SystemInt32_36 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_36");
        Private___intnl_SystemInt32_26 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_26");
        Private___intnl_SystemInt32_56 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_56");
        Private___intnl_SystemInt32_46 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_46");
        Private___refl_typename = new AstroUdonVariable<string>(RenderCameraEvent, "__refl_typename");
        Private___gintnl_SystemObjectArray_0 = new AstroUdonVariable<System.Object[]>(RenderCameraEvent, "__gintnl_SystemObjectArray_0");
        Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_1");
        Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_0");
        Private___intnl_SystemInt32_3 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_3");
        Private___intnl_SystemInt32_2 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_2");
        Private___intnl_SystemInt32_5 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_5");
        Private___intnl_SystemInt32_4 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_4");
        Private___intnl_SystemInt32_7 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_7");
        Private___intnl_SystemInt32_6 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_6");
        Private___intnl_SystemInt32_9 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_9");
        Private___intnl_SystemInt32_8 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_8");
        Private_outputToText = new AstroUdonVariable<bool>(RenderCameraEvent, "outputToText");
        Private_pedestalClone = new AstroUdonVariable<UnityEngine.Transform>(RenderCameraEvent, "pedestalClone");
        Private___this_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(RenderCameraEvent, "__this_UnityEngineTransform_0");
        Private___const_SystemString_1 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_1");
        Private___intnl_SystemString_19 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_19");
        Private___intnl_SystemString_14 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_14");
        Private___intnl_SystemString_15 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_15");
        Private___intnl_SystemString_12 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_12");
        Private___intnl_SystemString_13 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_13");
        Private___intnl_SystemString_10 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_10");
        Private___intnl_SystemString_11 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_11");
        Private___intnl_SystemBoolean_15 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_15");
        Private___intnl_SystemBoolean_25 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_25");
        Private___const_SystemInt32_12 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_12");
        Private___const_SystemInt32_22 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_22");
        Private___intnl_SystemInt32_13 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_13");
        Private___intnl_SystemInt32_33 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_33");
        Private___intnl_SystemInt32_23 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_23");
        Private___intnl_SystemInt32_53 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_53");
        Private___intnl_SystemInt32_43 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_43");
        Private_waitForNew = new AstroUdonVariable<bool>(RenderCameraEvent, "waitForNew");
        Private___intnl_SystemInt32_18 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_18");
        Private___intnl_SystemInt32_38 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_38");
        Private___intnl_SystemInt32_28 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_28");
        Private___intnl_SystemInt32_58 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_58");
        Private___intnl_SystemInt32_48 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_48");
        Private_donorInput = new AstroUdonVariable<UnityEngine.Texture2D>(RenderCameraEvent, "donorInput");
        Private_callbackBehaviour = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "callbackBehaviour");
        Private___lcl_textLength_SystemInt32_0 = new AstroUdonVariable<int>(RenderCameraEvent, "__lcl_textLength_SystemInt32_0");
        Private___intnl_SystemByte_0 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_0");
        Private___const_SystemByte_3 = new AstroUdonVariable<byte>(RenderCameraEvent, "__const_SystemByte_3");
        Private___const_SystemString_6 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_6");
        Private___gintnl_SystemUInt32_10 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_10");
        Private___gintnl_SystemUInt32_30 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_30");
        Private___gintnl_SystemUInt32_20 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_20");
        Private___const_SystemInt32_17 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_17");
        Private___intnl_SystemInt32_10 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_10");
        Private___intnl_SystemInt32_30 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_30");
        Private___intnl_SystemInt32_20 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_20");
        Private___intnl_SystemInt32_50 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_50");
        Private___intnl_SystemInt32_40 = new AstroUdonVariable<int>(RenderCameraEvent, "__intnl_SystemInt32_40");
        Private___intnl_SystemString_7 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_7");
        Private___intnl_SystemByte_8 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_8");
        Private___const_SystemString_26 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_26");
        Private___const_SystemString_27 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_27");
        Private___const_SystemString_24 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_24");
        Private___const_SystemString_25 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_25");
        Private___const_SystemString_22 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_22");
        Private___const_SystemString_23 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_23");
        Private___const_SystemString_20 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_20");
        Private___const_SystemString_21 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_21");
        Private___const_SystemString_28 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_28");
        Private___const_SystemString_29 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_29");
        Private___intnl_SystemByte_5 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_5");
        Private_frameCounter = new AstroUdonVariable<int>(RenderCameraEvent, "frameCounter");
        Private___gintnl_SystemUInt32_18 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_18");
        Private___gintnl_SystemUInt32_28 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_28");
        Private___intnl_SystemBoolean_10 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_10");
        Private___intnl_SystemBoolean_20 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_20");
        Private___intnl_UnityEngineColor32_2 = new AstroUdonVariable<UnityEngine.Color32>(RenderCameraEvent, "__intnl_UnityEngineColor32_2");
        Private___gintnl_SystemUInt32_15 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_15");
        Private___gintnl_SystemUInt32_25 = new AstroUdonVariable<uint>(RenderCameraEvent, "__gintnl_SystemUInt32_25");
        Private_outputString = new AstroUdonVariable<string>(RenderCameraEvent, "outputString");
        Private_decodeSpeedUTF16 = new AstroUdonVariable<int>(RenderCameraEvent, "decodeSpeedUTF16");
        Private___const_SystemInt32_9 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_9");
        Private___const_SystemInt32_8 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_8");
        Private___const_SystemInt32_1 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_1");
        Private___const_SystemInt32_0 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_0");
        Private___const_SystemInt32_3 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_3");
        Private___const_SystemInt32_2 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_2");
        Private___const_SystemInt32_5 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_5");
        Private___const_SystemInt32_4 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_4");
        Private___const_SystemInt32_7 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_7");
        Private___const_SystemInt32_6 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_6");
        Private___const_SystemInt32_14 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_14");
        Private___const_SystemInt32_24 = new AstroUdonVariable<int>(RenderCameraEvent, "__const_SystemInt32_24");
        Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_8");
        Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_9");
        Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_0");
        Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_1");
        Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_2");
        Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_3");
        Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_4");
        Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_5");
        Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_6");
        Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_7");
        Private___intnl_SystemString_4 = new AstroUdonVariable<string>(RenderCameraEvent, "__intnl_SystemString_4");
        Private_renderQuadRenderer = new AstroUdonVariable<UnityEngine.MeshRenderer>(RenderCameraEvent, "renderQuadRenderer");
        Private_avatarPedestal = new AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal>(RenderCameraEvent, "avatarPedestal");
        Private___intnl_SystemByte_6 = new AstroUdonVariable<byte>(RenderCameraEvent, "__intnl_SystemByte_6");
        Private_pedestalAssetsReady = new AstroUdonVariable<bool>(RenderCameraEvent, "pedestalAssetsReady");
        Private_decodeIndex = new AstroUdonVariable<int>(RenderCameraEvent, "decodeIndex");
        Private_maxIndex = new AstroUdonVariable<int>(RenderCameraEvent, "maxIndex");
        Private___const_SystemString_3 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_3");
        Private___this_VRCUdonUdonBehaviour_8 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__this_VRCUdonUdonBehaviour_8");
        Private___this_VRCUdonUdonBehaviour_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__this_VRCUdonUdonBehaviour_3");
        Private___this_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__this_VRCUdonUdonBehaviour_2");
        Private___this_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__this_VRCUdonUdonBehaviour_1");
        Private___this_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__this_VRCUdonUdonBehaviour_0");
        Private___this_VRCUdonUdonBehaviour_7 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__this_VRCUdonUdonBehaviour_7");
        Private___this_VRCUdonUdonBehaviour_6 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__this_VRCUdonUdonBehaviour_6");
        Private___this_VRCUdonUdonBehaviour_5 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__this_VRCUdonUdonBehaviour_5");
        Private___this_VRCUdonUdonBehaviour_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(RenderCameraEvent, "__this_VRCUdonUdonBehaviour_4");
        Private___const_SystemString_8 = new AstroUdonVariable<string>(RenderCameraEvent, "__const_SystemString_8");
        Private___intnl_SystemBoolean_18 = new AstroUdonVariable<bool>(RenderCameraEvent, "__intnl_SystemBoolean_18");
        Private_renderCamera = new AstroUdonVariable<UnityEngine.Camera>(RenderCameraEvent, "renderCamera");
    }

    private void Cleanup_RenderCameraEvent()
    {
        Private___intnl_SystemBoolean_13 = null;
        Private___intnl_SystemBoolean_23 = null;
        Private___gintnl_SystemUInt32_16 = null;
        Private___gintnl_SystemUInt32_26 = null;
        Private___intnl_SystemInt32_15 = null;
        Private___intnl_SystemInt32_35 = null;
        Private___intnl_SystemInt32_25 = null;
        Private___intnl_SystemInt32_55 = null;
        Private___intnl_SystemInt32_45 = null;
        Private_nextAvatar = null;
        Private_charIndex = null;
        Private_avatarCounter = null;
        Private_renderTexture = null;
        Private___gintnl_SystemObjectArray_1 = null;
        Private___intnl_UnityEngineMaterial_0 = null;
        Private___intnl_UnityEngineObject_12 = null;
        Private___const_SystemByte_1 = null;
        Private___intnl_SystemSingle_0 = null;
        Private___intnl_SystemChar_1 = null;
        Private_pedestalMaterial = null;
        Private___const_SystemString_0 = null;
        Private___intnl_UnityEngineTransform_0 = null;
        Private___lcl_value_SystemByte_0 = null;
        Private___const_SystemSingle_0 = null;
        Private_hasRun = null;
        Private___lcl_isNew_UnityEngineColor32_0 = null;
        Private_dataMode = null;
        Private___intnl_SystemBoolean_16 = null;
        Private___intnl_SystemBoolean_26 = null;
        Private_debugTMP = null;
        Private___const_SystemInt32_11 = null;
        Private___const_SystemInt32_21 = null;
        Private___intnl_SystemInt32_12 = null;
        Private___intnl_SystemInt32_32 = null;
        Private___intnl_SystemInt32_22 = null;
        Private___intnl_SystemInt32_52 = null;
        Private___intnl_SystemInt32_42 = null;
        Private___lcl_now_SystemDateTime_0 = null;
        Private___intnl_SystemString_9 = null;
        Private___lcl_idColor_UnityEngineColor32_0 = null;
        Private___intnl_SystemByte_3 = null;
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
        Private_dataLength = null;
        Private___intnl_UnityEngineMeshRenderer_0 = null;
        Private___intnl_UnityEngineMeshRenderer_1 = null;
        Private___const_SystemString_5 = null;
        Private___intnl_UnityEngineColor32_0 = null;
        Private___const_SystemInt32_19 = null;
        Private___gintnl_SystemUInt32_13 = null;
        Private___gintnl_SystemUInt32_23 = null;
        Private___intnl_UnityEngineObject_8 = null;
        Private___intnl_UnityEngineObject_4 = null;
        Private___intnl_UnityEngineObject_2 = null;
        Private___intnl_UnityEngineObject_0 = null;
        Private___const_SystemInt32_16 = null;
        Private_decodeSpeedUTF8 = null;
        Private___intnl_SystemString_6 = null;
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
        Private_color = null;
        Private_pixelIndex = null;
        Private___intnl_UnityEngineObject_14 = null;
        Private___refl_typeid = null;
        Private_lastInput = null;
        Private_colors = null;
        Private_autoFillTMP = null;
        Private___lcl_toIterate_SystemInt32_0 = null;
        Private___lcl_toIterate_SystemInt32_1 = null;
        Private___lcl_toIterate_SystemInt32_2 = null;
        Private_bytesCount = null;
        Private___const_SystemUInt32_0 = null;
        Private___intnl_UnityEngineComponent_0 = null;
        Private___intnl_SystemBoolean_11 = null;
        Private___intnl_SystemBoolean_21 = null;
        Private_callbackEventName = null;
        Private___intnl_UnityEngineColor32_3 = null;
        Private___gintnl_SystemUInt32_14 = null;
        Private___gintnl_SystemUInt32_24 = null;
        Private___intnl_SystemInt32_17 = null;
        Private___intnl_SystemInt32_37 = null;
        Private___intnl_SystemInt32_27 = null;
        Private___intnl_SystemInt32_57 = null;
        Private___intnl_SystemInt32_47 = null;
        Private___intnl_SystemString_3 = null;
        Private___0__intnlparam = null;
        Private___const_SystemString_2 = null;
        Private___const_SystemSingle_2 = null;
        Private___intnl_SystemBoolean_19 = null;
        Private___intnl_UnityEngineGameObject_1 = null;
        Private___intnl_SystemBoolean_14 = null;
        Private___intnl_SystemBoolean_24 = null;
        Private___const_SystemInt32_13 = null;
        Private___const_SystemInt32_23 = null;
        Private_pedestalTexture = null;
        Private___0_text__param = null;
        Private___intnl_SystemInt32_14 = null;
        Private___intnl_SystemInt32_34 = null;
        Private___intnl_SystemInt32_24 = null;
        Private___intnl_SystemInt32_54 = null;
        Private___intnl_SystemInt32_44 = null;
        Private_pedestal = null;
        Private_currentTry = null;
        Private___lcl_maxDataLength_SystemInt32_0 = null;
        Private___intnl_SystemInt32_19 = null;
        Private___intnl_SystemInt32_39 = null;
        Private___intnl_SystemInt32_29 = null;
        Private___intnl_SystemInt32_59 = null;
        Private___intnl_SystemInt32_49 = null;
        Private___intnl_SystemString_0 = null;
        Private___intnl_SystemByte_1 = null;
        Private___const_SystemByte_0 = null;
        Private___0_picture__param = null;
        Private___intnl_UnityEngineRect_0 = null;
        Private___intnl_SystemSingle_1 = null;
        Private___lcl_headerInfo_UnityEngineColor32_0 = null;
        Private__utf8Chars = null;
        Private___intnl_SystemChar_0 = null;
        Private___const_SystemString_7 = null;
        Private_linkedAvatars = null;
        Private___const_SystemSingle_1 = null;
        Private_byteIndex = null;
        Private___gintnl_SystemUInt32_11 = null;
        Private___gintnl_SystemUInt32_21 = null;
        Private___intnl_SystemBoolean_17 = null;
        Private___intnl_SystemBoolean_27 = null;
        Private_callBackOnFinish = null;
        Private___const_SystemInt32_10 = null;
        Private___const_SystemInt32_20 = null;
        Private___const_VRCUdonCommonEnumsEventTiming_0 = null;
        Private___intnl_SystemInt32_11 = null;
        Private___intnl_SystemInt32_31 = null;
        Private___intnl_SystemInt32_21 = null;
        Private___intnl_SystemInt32_51 = null;
        Private___intnl_SystemInt32_41 = null;
        Private___lcl_temp_SystemByteArray_0 = null;
        Private___intnl_SystemString_8 = null;
        Private___intnl_SystemByte_9 = null;
        Private_debugLogging = null;
        Private___const_SystemString_34 = null;
        Private___const_SystemString_32 = null;
        Private___const_SystemString_33 = null;
        Private___const_SystemString_30 = null;
        Private___const_SystemString_31 = null;
        Private___intnl_SystemByte_2 = null;
        Private_transferSpeed = null;
        Private___intnl_returnJump_SystemUInt32_0 = null;
        Private_character = null;
        Private_avatarBytes = null;
        Private___const_SystemString_4 = null;
        Private_imageMode = null;
        Private___gintnl_SystemUInt32_19 = null;
        Private___gintnl_SystemUInt32_29 = null;
        Private___intnl_UnityEngineColor32_1 = null;
        Private___const_SystemInt32_18 = null;
        Private___gintnl_SystemUInt32_12 = null;
        Private___gintnl_SystemUInt32_22 = null;
        Private___lcl_child_UnityEngineTransform_0 = null;
        Private___lcl_i_SystemInt32_1 = null;
        Private___lcl_i_SystemInt32_0 = null;
        Private___const_SystemInt32_15 = null;
        Private_charCounter = null;
        Private_patronMode = null;
        Private___intnl_SystemByte_17 = null;
        Private___intnl_SystemByte_16 = null;
        Private___intnl_SystemByte_15 = null;
        Private___intnl_SystemByte_14 = null;
        Private___intnl_SystemByte_13 = null;
        Private___intnl_SystemByte_12 = null;
        Private___intnl_SystemByte_11 = null;
        Private___intnl_SystemByte_10 = null;
        Private___intnl_SystemString_5 = null;
        Private___intnl_SystemByte_7 = null;
        Private___1__intnlparam = null;
        Private___intnl_UnityEngineObject_15 = null;
        Private_pedestalReady = null;
        Private_frameSkip = null;
        Private_outputBytes = null;
        Private___0_IsSame__ret = null;
        Private___const_SystemString_9 = null;
        Private___intnl_UnityEngineTextureFormat_0 = null;
        Private___intnl_SystemBoolean_12 = null;
        Private___intnl_SystemBoolean_22 = null;
        Private___gintnl_SystemUInt32_17 = null;
        Private___gintnl_SystemUInt32_27 = null;
        Private___intnl_SystemInt32_16 = null;
        Private___intnl_SystemInt32_36 = null;
        Private___intnl_SystemInt32_26 = null;
        Private___intnl_SystemInt32_56 = null;
        Private___intnl_SystemInt32_46 = null;
        Private___refl_typename = null;
        Private___gintnl_SystemObjectArray_0 = null;
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
        Private_outputToText = null;
        Private_pedestalClone = null;
        Private___this_UnityEngineTransform_0 = null;
        Private___const_SystemString_1 = null;
        Private___intnl_SystemString_19 = null;
        Private___intnl_SystemString_14 = null;
        Private___intnl_SystemString_15 = null;
        Private___intnl_SystemString_12 = null;
        Private___intnl_SystemString_13 = null;
        Private___intnl_SystemString_10 = null;
        Private___intnl_SystemString_11 = null;
        Private___intnl_SystemBoolean_15 = null;
        Private___intnl_SystemBoolean_25 = null;
        Private___const_SystemInt32_12 = null;
        Private___const_SystemInt32_22 = null;
        Private___intnl_SystemInt32_13 = null;
        Private___intnl_SystemInt32_33 = null;
        Private___intnl_SystemInt32_23 = null;
        Private___intnl_SystemInt32_53 = null;
        Private___intnl_SystemInt32_43 = null;
        Private_waitForNew = null;
        Private___intnl_SystemInt32_18 = null;
        Private___intnl_SystemInt32_38 = null;
        Private___intnl_SystemInt32_28 = null;
        Private___intnl_SystemInt32_58 = null;
        Private___intnl_SystemInt32_48 = null;
        Private_donorInput = null;
        Private_callbackBehaviour = null;
        Private___lcl_textLength_SystemInt32_0 = null;
        Private___intnl_SystemByte_0 = null;
        Private___const_SystemByte_3 = null;
        Private___const_SystemString_6 = null;
        Private___gintnl_SystemUInt32_10 = null;
        Private___gintnl_SystemUInt32_30 = null;
        Private___gintnl_SystemUInt32_20 = null;
        Private___const_SystemInt32_17 = null;
        Private___intnl_SystemInt32_10 = null;
        Private___intnl_SystemInt32_30 = null;
        Private___intnl_SystemInt32_20 = null;
        Private___intnl_SystemInt32_50 = null;
        Private___intnl_SystemInt32_40 = null;
        Private___intnl_SystemString_7 = null;
        Private___intnl_SystemByte_8 = null;
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
        Private_frameCounter = null;
        Private___gintnl_SystemUInt32_18 = null;
        Private___gintnl_SystemUInt32_28 = null;
        Private___intnl_SystemBoolean_10 = null;
        Private___intnl_SystemBoolean_20 = null;
        Private___intnl_UnityEngineColor32_2 = null;
        Private___gintnl_SystemUInt32_15 = null;
        Private___gintnl_SystemUInt32_25 = null;
        Private_outputString = null;
        Private_decodeSpeedUTF16 = null;
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
        Private___const_SystemInt32_24 = null;
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
        Private___intnl_SystemString_4 = null;
        Private_renderQuadRenderer = null;
        Private_avatarPedestal = null;
        Private___intnl_SystemByte_6 = null;
        Private_pedestalAssetsReady = null;
        Private_decodeIndex = null;
        Private_maxIndex = null;
        Private___const_SystemString_3 = null;
        Private___this_VRCUdonUdonBehaviour_8 = null;
        Private___this_VRCUdonUdonBehaviour_3 = null;
        Private___this_VRCUdonUdonBehaviour_2 = null;
        Private___this_VRCUdonUdonBehaviour_1 = null;
        Private___this_VRCUdonUdonBehaviour_0 = null;
        Private___this_VRCUdonUdonBehaviour_7 = null;
        Private___this_VRCUdonUdonBehaviour_6 = null;
        Private___this_VRCUdonUdonBehaviour_5 = null;
        Private___this_VRCUdonUdonBehaviour_4 = null;
        Private___const_SystemString_8 = null;
        Private___intnl_SystemBoolean_18 = null;
        Private_renderCamera = null;
    }

    #region Getter / Setters AstroUdonVariables  of RenderCameraEvent

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

    internal int? __intnl_SystemInt32_55
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_55 != null)
            {
                return Private___intnl_SystemInt32_55.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_55 != null)
                {
                    Private___intnl_SystemInt32_55.Value = value.Value;
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

    internal string nextAvatar
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_nextAvatar != null)
            {
                return Private_nextAvatar.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_nextAvatar != null)
            {
                Private_nextAvatar.Value = value;
            }
        }
    }

    internal int? charIndex
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_charIndex != null)
            {
                return Private_charIndex.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_charIndex != null)
                {
                    Private_charIndex.Value = value.Value;
                }
            }
        }
    }

    internal int? avatarCounter
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_avatarCounter != null)
            {
                return Private_avatarCounter.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_avatarCounter != null)
                {
                    Private_avatarCounter.Value = value.Value;
                }
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

    internal VRC.Udon.UdonBehaviour __intnl_UnityEngineObject_12
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

    internal UnityEngine.Material pedestalMaterial
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_pedestalMaterial != null)
            {
                return Private_pedestalMaterial.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_pedestalMaterial != null)
            {
                Private_pedestalMaterial.Value = value;
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

    internal byte? __lcl_value_SystemByte_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_value_SystemByte_0 != null)
            {
                return Private___lcl_value_SystemByte_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_value_SystemByte_0 != null)
                {
                    Private___lcl_value_SystemByte_0.Value = value.Value;
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

    internal UnityEngine.Color32? __lcl_isNew_UnityEngineColor32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_isNew_UnityEngineColor32_0 != null)
            {
                return Private___lcl_isNew_UnityEngineColor32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {

                if (Private___lcl_isNew_UnityEngineColor32_0 != null)
                {
                    Private___lcl_isNew_UnityEngineColor32_0.Value = value.Value;
                }
            }
        }
    }

    internal int? dataMode
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_dataMode != null)
            {
                return Private_dataMode.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_dataMode != null)
                {
                    Private_dataMode.Value = value.Value;
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

    internal bool? debugTMP
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_debugTMP != null)
            {
                return Private_debugTMP.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_debugTMP != null)
                {
                    Private_debugTMP.Value = value.Value;
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

    internal System.DateTime? __lcl_now_SystemDateTime_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_now_SystemDateTime_0 != null)
            {
                return Private___lcl_now_SystemDateTime_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {

                if (Private___lcl_now_SystemDateTime_0 != null)
                {
                    Private___lcl_now_SystemDateTime_0.Value = value.Value;
                }
            }
        }
    }

    internal string __intnl_SystemString_9
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_9 != null)
            {
                return Private___intnl_SystemString_9.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_9 != null)
            {
                Private___intnl_SystemString_9.Value = value;
            }
        }
    }

    internal UnityEngine.Color32? __lcl_idColor_UnityEngineColor32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_idColor_UnityEngineColor32_0 != null)
            {
                return Private___lcl_idColor_UnityEngineColor32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_idColor_UnityEngineColor32_0 != null)
                {
                    Private___lcl_idColor_UnityEngineColor32_0.Value = value.Value;
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

    internal UnityEngine.MeshRenderer __intnl_UnityEngineMeshRenderer_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineMeshRenderer_0 != null)
            {
                return Private___intnl_UnityEngineMeshRenderer_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_UnityEngineMeshRenderer_0 != null)
            {
                Private___intnl_UnityEngineMeshRenderer_0.Value = value;
            }
        }
    }

    internal UnityEngine.MeshRenderer __intnl_UnityEngineMeshRenderer_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineMeshRenderer_1 != null)
            {
                return Private___intnl_UnityEngineMeshRenderer_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_UnityEngineMeshRenderer_1 != null)
            {
                Private___intnl_UnityEngineMeshRenderer_1.Value = value;
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

    internal UnityEngine.Color32? __intnl_UnityEngineColor32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineColor32_0 != null)
            {
                return Private___intnl_UnityEngineColor32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {

                if (Private___intnl_UnityEngineColor32_0 != null)
                {
                    Private___intnl_UnityEngineColor32_0.Value = value.Value;
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

    internal UnityEngine.CustomRenderTexture __intnl_UnityEngineObject_8
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

    internal UnityEngine.MeshRenderer __intnl_UnityEngineObject_4
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

    internal UnityEngine.Texture2D __intnl_UnityEngineObject_2
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

    internal UnityEngine.Transform __intnl_UnityEngineObject_0
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

    internal int? decodeSpeedUTF8
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_decodeSpeedUTF8 != null)
            {
                return Private_decodeSpeedUTF8.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_decodeSpeedUTF8 != null)
                {
                    Private_decodeSpeedUTF8.Value = value.Value;
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

    internal UnityEngine.Color32? color
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_color != null)
            {
                return Private_color.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {

                if (Private_color != null)
                {
                    Private_color.Value = value.Value;
                }
            }
        }
    }

    internal int? pixelIndex
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_pixelIndex != null)
            {
                return Private_pixelIndex.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_pixelIndex != null)
                {
                    Private_pixelIndex.Value = value.Value;
                }
            }
        }
    }

    internal VRC.SDK3.Components.VRCAvatarPedestal __intnl_UnityEngineObject_14
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineObject_14 != null)
            {
                return Private___intnl_UnityEngineObject_14.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_UnityEngineObject_14 != null)
            {
                Private___intnl_UnityEngineObject_14.Value = value;
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

    internal UnityEngine.Texture2D lastInput
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_lastInput != null)
            {
                return Private_lastInput.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_lastInput != null)
            {
                Private_lastInput.Value = value;
            }
        }
    }

    internal UnityEngine.Color32[] colors
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

    internal bool? autoFillTMP
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_autoFillTMP != null)
            {
                return Private_autoFillTMP.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_autoFillTMP != null)
                {
                    Private_autoFillTMP.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_toIterate_SystemInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_toIterate_SystemInt32_0 != null)
            {
                return Private___lcl_toIterate_SystemInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_toIterate_SystemInt32_0 != null)
                {
                    Private___lcl_toIterate_SystemInt32_0.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_toIterate_SystemInt32_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_toIterate_SystemInt32_1 != null)
            {
                return Private___lcl_toIterate_SystemInt32_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_toIterate_SystemInt32_1 != null)
                {
                    Private___lcl_toIterate_SystemInt32_1.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_toIterate_SystemInt32_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_toIterate_SystemInt32_2 != null)
            {
                return Private___lcl_toIterate_SystemInt32_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_toIterate_SystemInt32_2 != null)
                {
                    Private___lcl_toIterate_SystemInt32_2.Value = value.Value;
                }
            }
        }
    }

    internal int? bytesCount
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_bytesCount != null)
            {
                return Private_bytesCount.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_bytesCount != null)
                {
                    Private_bytesCount.Value = value.Value;
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

    internal VRC.SDK3.Components.VRCAvatarPedestal __intnl_UnityEngineComponent_0
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

    internal UnityEngine.Color32? __intnl_UnityEngineColor32_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineColor32_3 != null)
            {
                return Private___intnl_UnityEngineColor32_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {

                if (Private___intnl_UnityEngineColor32_3 != null)
                {
                    Private___intnl_UnityEngineColor32_3.Value = value.Value;
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

    internal int? __intnl_SystemInt32_57
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_57 != null)
            {
                return Private___intnl_SystemInt32_57.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_57 != null)
                {
                    Private___intnl_SystemInt32_57.Value = value.Value;
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

    internal string __intnl_SystemString_3
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_3 != null)
            {
                return Private___intnl_SystemString_3.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_3 != null)
            {
                Private___intnl_SystemString_3.Value = value;
            }
        }
    }

    internal VRC.SDK3.Components.VRCAvatarPedestal __0__intnlparam
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

    internal UnityEngine.Texture2D pedestalTexture
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_pedestalTexture != null)
            {
                return Private_pedestalTexture.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_pedestalTexture != null)
            {
                Private_pedestalTexture.Value = value;
            }
        }
    }

    internal string __0_text__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_text__param != null)
            {
                return Private___0_text__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_text__param != null)
            {
                Private___0_text__param.Value = value;
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

    internal int? __intnl_SystemInt32_54
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_54 != null)
            {
                return Private___intnl_SystemInt32_54.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_54 != null)
                {
                    Private___intnl_SystemInt32_54.Value = value.Value;
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

    internal int? currentTry
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_currentTry != null)
            {
                return Private_currentTry.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_currentTry != null)
                {
                    Private_currentTry.Value = value.Value;
                }
            }
        }
    }

    internal int? __lcl_maxDataLength_SystemInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_maxDataLength_SystemInt32_0 != null)
            {
                return Private___lcl_maxDataLength_SystemInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_maxDataLength_SystemInt32_0 != null)
                {
                    Private___lcl_maxDataLength_SystemInt32_0.Value = value.Value;
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

    internal int? __intnl_SystemInt32_59
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_59 != null)
            {
                return Private___intnl_SystemInt32_59.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_59 != null)
                {
                    Private___intnl_SystemInt32_59.Value = value.Value;
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

    internal UnityEngine.Texture2D __0_picture__param
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_picture__param != null)
            {
                return Private___0_picture__param.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___0_picture__param != null)
            {
                Private___0_picture__param.Value = value;
            }
        }
    }

    internal UnityEngine.Rect? __intnl_UnityEngineRect_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineRect_0 != null)
            {
                return Private___intnl_UnityEngineRect_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_UnityEngineRect_0 != null)
                {
                    Private___intnl_UnityEngineRect_0.Value = value.Value;
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

    internal UnityEngine.Color32? __lcl_headerInfo_UnityEngineColor32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_headerInfo_UnityEngineColor32_0 != null)
            {
                return Private___lcl_headerInfo_UnityEngineColor32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {

                if (Private___lcl_headerInfo_UnityEngineColor32_0 != null)
                {
                    Private___lcl_headerInfo_UnityEngineColor32_0.Value = value.Value;
                }
            }
        }
    }

    internal string[] _utf8Chars
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private__utf8Chars != null)
            {
                return Private__utf8Chars.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private__utf8Chars != null)
            {
                Private__utf8Chars.Value = value;
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

    internal string[] linkedAvatars
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_linkedAvatars != null)
            {
                return Private_linkedAvatars.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_linkedAvatars != null)
            {
                Private_linkedAvatars.Value = value;
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

    internal byte[] __lcl_temp_SystemByteArray_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_temp_SystemByteArray_0 != null)
            {
                return Private___lcl_temp_SystemByteArray_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___lcl_temp_SystemByteArray_0 != null)
            {
                Private___lcl_temp_SystemByteArray_0.Value = value;
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

    internal bool? debugLogging
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_debugLogging != null)
            {
                return Private_debugLogging.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_debugLogging != null)
                {
                    Private_debugLogging.Value = value.Value;
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

    internal int? transferSpeed
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_transferSpeed != null)
            {
                return Private_transferSpeed.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_transferSpeed != null)
                {
                    Private_transferSpeed.Value = value.Value;
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

    internal int? character
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_character != null)
            {
                return Private_character.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_character != null)
                {
                    Private_character.Value = value.Value;
                }
            }
        }
    }

    internal byte[] avatarBytes
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_avatarBytes != null)
            {
                return Private_avatarBytes.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_avatarBytes != null)
            {
                Private_avatarBytes.Value = value;
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

    internal int? imageMode
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_imageMode != null)
            {
                return Private_imageMode.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_imageMode != null)
                {
                    Private_imageMode.Value = value.Value;
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

    internal UnityEngine.Color32? __intnl_UnityEngineColor32_1
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineColor32_1 != null)
            {
                return Private___intnl_UnityEngineColor32_1.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {

                if (Private___intnl_UnityEngineColor32_1 != null)
                {
                    Private___intnl_UnityEngineColor32_1.Value = value.Value;
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

    internal UnityEngine.Transform __lcl_child_UnityEngineTransform_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_child_UnityEngineTransform_0 != null)
            {
                return Private___lcl_child_UnityEngineTransform_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___lcl_child_UnityEngineTransform_0 != null)
            {
                Private___lcl_child_UnityEngineTransform_0.Value = value;
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

    internal byte? charCounter
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_charCounter != null)
            {
                return Private_charCounter.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_charCounter != null)
                {
                    Private_charCounter.Value = value.Value;
                }
            }
        }
    }

    internal bool? patronMode
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_patronMode != null)
            {
                return Private_patronMode.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_patronMode != null)
                {
                    Private_patronMode.Value = value.Value;
                }
            }
        }
    }

    internal byte? __intnl_SystemByte_17
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemByte_17 != null)
            {
                return Private___intnl_SystemByte_17.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemByte_17 != null)
                {
                    Private___intnl_SystemByte_17.Value = value.Value;
                }
            }
        }
    }

    internal byte? __intnl_SystemByte_16
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemByte_16 != null)
            {
                return Private___intnl_SystemByte_16.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemByte_16 != null)
                {
                    Private___intnl_SystemByte_16.Value = value.Value;
                }
            }
        }
    }

    internal byte? __intnl_SystemByte_15
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemByte_15 != null)
            {
                return Private___intnl_SystemByte_15.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemByte_15 != null)
                {
                    Private___intnl_SystemByte_15.Value = value.Value;
                }
            }
        }
    }

    internal byte? __intnl_SystemByte_14
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemByte_14 != null)
            {
                return Private___intnl_SystemByte_14.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemByte_14 != null)
                {
                    Private___intnl_SystemByte_14.Value = value.Value;
                }
            }
        }
    }

    internal byte? __intnl_SystemByte_13
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemByte_13 != null)
            {
                return Private___intnl_SystemByte_13.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemByte_13 != null)
                {
                    Private___intnl_SystemByte_13.Value = value.Value;
                }
            }
        }
    }

    internal byte? __intnl_SystemByte_12
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemByte_12 != null)
            {
                return Private___intnl_SystemByte_12.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemByte_12 != null)
                {
                    Private___intnl_SystemByte_12.Value = value.Value;
                }
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

    internal string __intnl_SystemString_5
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_5 != null)
            {
                return Private___intnl_SystemString_5.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_5 != null)
            {
                Private___intnl_SystemString_5.Value = value;
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

    internal UnityEngine.GameObject __intnl_UnityEngineObject_15
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineObject_15 != null)
            {
                return Private___intnl_UnityEngineObject_15.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_UnityEngineObject_15 != null)
            {
                Private___intnl_UnityEngineObject_15.Value = value;
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

    internal bool? frameSkip
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_frameSkip != null)
            {
                return Private_frameSkip.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_frameSkip != null)
                {
                    Private_frameSkip.Value = value.Value;
                }
            }
        }
    }

    internal byte[] outputBytes
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_outputBytes != null)
            {
                return Private_outputBytes.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_outputBytes != null)
            {
                Private_outputBytes.Value = value;
            }
        }
    }

    internal bool? __0_IsSame__ret
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___0_IsSame__ret != null)
            {
                return Private___0_IsSame__ret.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___0_IsSame__ret != null)
                {
                    Private___0_IsSame__ret.Value = value.Value;
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

    internal UnityEngine.TextureFormat? __intnl_UnityEngineTextureFormat_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineTextureFormat_0 != null)
            {
                return Private___intnl_UnityEngineTextureFormat_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {

                if (Private___intnl_UnityEngineTextureFormat_0 != null)
                {
                    Private___intnl_UnityEngineTextureFormat_0.Value = value.Value;
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

    internal int? __intnl_SystemInt32_56
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_56 != null)
            {
                return Private___intnl_SystemInt32_56.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_56 != null)
                {
                    Private___intnl_SystemInt32_56.Value = value.Value;
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

    internal UnityEngine.Transform pedestalClone
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_pedestalClone != null)
            {
                return Private_pedestalClone.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_pedestalClone != null)
            {
                Private_pedestalClone.Value = value;
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

    internal string __intnl_SystemString_19
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_19 != null)
            {
                return Private___intnl_SystemString_19.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_19 != null)
            {
                Private___intnl_SystemString_19.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_14
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_14 != null)
            {
                return Private___intnl_SystemString_14.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_14 != null)
            {
                Private___intnl_SystemString_14.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_15
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_15 != null)
            {
                return Private___intnl_SystemString_15.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_15 != null)
            {
                Private___intnl_SystemString_15.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_12
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_12 != null)
            {
                return Private___intnl_SystemString_12.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_12 != null)
            {
                Private___intnl_SystemString_12.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_13
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_13 != null)
            {
                return Private___intnl_SystemString_13.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_13 != null)
            {
                Private___intnl_SystemString_13.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_10
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_10 != null)
            {
                return Private___intnl_SystemString_10.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_10 != null)
            {
                Private___intnl_SystemString_10.Value = value;
            }
        }
    }

    internal string __intnl_SystemString_11
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_11 != null)
            {
                return Private___intnl_SystemString_11.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_11 != null)
            {
                Private___intnl_SystemString_11.Value = value;
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

    internal bool? waitForNew
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_waitForNew != null)
            {
                return Private_waitForNew.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_waitForNew != null)
                {
                    Private_waitForNew.Value = value.Value;
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

    internal int? __intnl_SystemInt32_58
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemInt32_58 != null)
            {
                return Private___intnl_SystemInt32_58.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_SystemInt32_58 != null)
                {
                    Private___intnl_SystemInt32_58.Value = value.Value;
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

    internal int? __lcl_textLength_SystemInt32_0
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___lcl_textLength_SystemInt32_0 != null)
            {
                return Private___lcl_textLength_SystemInt32_0.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___lcl_textLength_SystemInt32_0 != null)
                {
                    Private___lcl_textLength_SystemInt32_0.Value = value.Value;
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

    internal int? frameCounter
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_frameCounter != null)
            {
                return Private_frameCounter.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_frameCounter != null)
                {
                    Private_frameCounter.Value = value.Value;
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

    internal UnityEngine.Color32? __intnl_UnityEngineColor32_2
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_UnityEngineColor32_2 != null)
            {
                return Private___intnl_UnityEngineColor32_2.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private___intnl_UnityEngineColor32_2 != null)
                {
                    Private___intnl_UnityEngineColor32_2.Value = value.Value;
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

    internal string outputString
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_outputString != null)
            {
                return Private_outputString.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_outputString != null)
            {
                Private_outputString.Value = value;
            }
        }
    }

    internal int? decodeSpeedUTF16
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_decodeSpeedUTF16 != null)
            {
                return Private_decodeSpeedUTF16.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_decodeSpeedUTF16 != null)
                {
                    Private_decodeSpeedUTF16.Value = value.Value;
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

    internal string __intnl_SystemString_4
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private___intnl_SystemString_4 != null)
            {
                return Private___intnl_SystemString_4.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private___intnl_SystemString_4 != null)
            {
                Private___intnl_SystemString_4.Value = value;
            }
        }
    }

    internal UnityEngine.MeshRenderer renderQuadRenderer
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_renderQuadRenderer != null)
            {
                return Private_renderQuadRenderer.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_renderQuadRenderer != null)
            {
                Private_renderQuadRenderer.Value = value;
            }
        }
    }

    internal VRC.SDK3.Components.VRCAvatarPedestal avatarPedestal
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_avatarPedestal != null)
            {
                return Private_avatarPedestal.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (Private_avatarPedestal != null)
            {
                Private_avatarPedestal.Value = value;
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

    internal bool? pedestalAssetsReady
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_pedestalAssetsReady != null)
            {
                return Private_pedestalAssetsReady.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_pedestalAssetsReady != null)
                {
                    Private_pedestalAssetsReady.Value = value.Value;
                }
            }
        }
    }

    internal int? decodeIndex
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_decodeIndex != null)
            {
                return Private_decodeIndex.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_decodeIndex != null)
                {
                    Private_decodeIndex.Value = value.Value;
                }
            }
        }
    }

    internal int? maxIndex
    {
        [HideFromIl2Cpp]
        get
        {
            if (Private_maxIndex != null)
            {
                return Private_maxIndex.Value;
            }

            return null;
        }
        [HideFromIl2Cpp]
        set
        {
            if (value.HasValue)
            {
                if (Private_maxIndex != null)
                {
                    Private_maxIndex.Value = value.Value;
                }
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

    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_35 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_55 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_45 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private_nextAvatar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_charIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_avatarCounter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.CustomRenderTexture> Private_renderTexture { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<System.Object[]> Private___gintnl_SystemObjectArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Material> Private___intnl_UnityEngineMaterial_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineObject_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___const_SystemByte_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___intnl_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___intnl_SystemChar_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Material> Private_pedestalMaterial { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___lcl_value_SystemByte_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___const_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_hasRun { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color32> Private___lcl_isNew_UnityEngineColor32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_dataMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_debugTMP { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_52 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_42 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<System.DateTime> Private___lcl_now_SystemDateTime_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color32> Private___lcl_idColor_UnityEngineColor32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
    private AstroUdonVariable<int> Private_dataLength { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.MeshRenderer> Private___intnl_UnityEngineMeshRenderer_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.MeshRenderer> Private___intnl_UnityEngineMeshRenderer_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color32> Private___intnl_UnityEngineColor32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.CustomRenderTexture> Private___intnl_UnityEngineObject_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.MeshRenderer> Private___intnl_UnityEngineObject_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private___intnl_UnityEngineObject_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_decodeSpeedUTF8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
    private AstroUdonVariable<UnityEngine.Color32> Private_color { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_pixelIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal> Private___intnl_UnityEngineObject_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private_lastInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color32[]> Private_colors { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_autoFillTMP { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_toIterate_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_toIterate_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_toIterate_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_bytesCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal> Private___intnl_UnityEngineComponent_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private_callbackEventName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color32> Private___intnl_UnityEngineColor32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_37 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_57 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_47 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal> Private___0__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___const_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineGameObject_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private_pedestalTexture { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___0_text__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_54 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_44 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal> Private_pedestal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_currentTry { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_maxDataLength_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_39 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_59 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_49 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___const_SystemByte_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private___0_picture__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Rect> Private___intnl_UnityEngineRect_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___intnl_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color32> Private___lcl_headerInfo_UnityEngineColor32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private__utf8Chars { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<char> Private___intnl_SystemChar_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string[]> Private_linkedAvatars { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<float> Private___const_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_byteIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_callBackOnFinish { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___const_VRCUdonCommonEnumsEventTiming_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_51 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_41 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte[]> Private___lcl_temp_SystemByteArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_debugLogging { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_34 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_31 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_transferSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_character { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte[]> Private_avatarBytes { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_imageMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_29 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color32> Private___intnl_UnityEngineColor32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___lcl_child_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_i_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_i_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private_charCounter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_patronMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___1__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineObject_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_pedestalReady { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_frameSkip { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte[]> Private_outputBytes { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___0_IsSame__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.TextureFormat> Private___intnl_UnityEngineTextureFormat_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_27 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_36 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_26 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_56 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_46 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<System.Object[]> Private___gintnl_SystemObjectArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
    private AstroUdonVariable<bool> Private_outputToText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private_pedestalClone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Transform> Private___this_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_33 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_23 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_53 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_43 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_waitForNew { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_38 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_58 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_48 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Texture2D> Private_donorInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_callbackBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___lcl_textLength_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___const_SystemByte_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___const_SystemInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_30 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_50 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private___intnl_SystemInt32_40 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___intnl_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
    private AstroUdonVariable<int> Private_frameCounter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_28 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Color32> Private___intnl_UnityEngineColor32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_25 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private_outputString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_decodeSpeedUTF16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
    private AstroUdonVariable<int> Private___const_SystemInt32_24 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
    private AstroUdonVariable<string> Private___intnl_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.MeshRenderer> Private_renderQuadRenderer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.SDK3.Components.VRCAvatarPedestal> Private_avatarPedestal { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<byte> Private___intnl_SystemByte_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private_pedestalAssetsReady { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_decodeIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<int> Private_maxIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<bool> Private___intnl_SystemBoolean_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    private AstroUdonVariable<UnityEngine.Camera> Private_renderCamera { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
    #endregion AstroUdonVariables  of RenderCameraEvent

    // Use this for initialization
}