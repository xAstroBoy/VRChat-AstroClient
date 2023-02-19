using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.MakiMaki
{
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class MakiMaki_CustomizationReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public MakiMaki_CustomizationReader(IntPtr ptr) : base(ptr)
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

        private string GetWorldUdonEvent()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.GeoLocator))
            {
                return "GetLocalPin";
            }
            if (WorldUtils.WorldID.Equals(WorldIds.Maki_Tanks))
            {
                return "__0_GetHat";
            }

            return null;
        }


        private UdonBehaviour_Cached RefreshPatronSystem  { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private RawUdonBehaviour Customization { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.GeoLocator) || WorldUtils.WorldID.Equals(WorldIds.Maki_Tanks))
            {
                var keytosearch = GetWorldUdonEvent();
                var obj = gameObject.FindUdonEvent(keytosearch);
                if (obj != null)
                {
                    Customization = obj.RawItem;
                    RefreshPatronSystem = obj.UdonBehaviour.FindUdonEvent("_start");
                    Initialize_Customization();
                    // after this just set the patron tier and call the behaviour _start event and say fuck it lol
                    HasSubscribed = true;
                    __0_tier__param = int.MaxValue;
                    _authorizedTier = int.MaxValue; 
                    RefreshPatronSystem.Invoke(); // call it and everything gets unlocked for free LMAO

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

        private void OnDestroy()
        {
            HasSubscribed = false;
            Cleanup_Customization();
        }

        
private void Initialize_Customization()
{
Private___intnl_SystemBoolean_13 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_13");
Private___intnl_UnityEngineMaterial_1 = new AstroUdonVariable<UnityEngine.Material>(Customization,  "__intnl_UnityEngineMaterial_1");
Private___intnl_UnityEngineMaterial_0 = new AstroUdonVariable<UnityEngine.Material>(Customization,  "__intnl_UnityEngineMaterial_0");
Private___intnl_UnityEngineMaterial_2 = new AstroUdonVariable<UnityEngine.Material>(Customization,  "__intnl_UnityEngineMaterial_2");
Private___intnl_SystemString_1 = new AstroUdonVariable<string>(Customization,  "__intnl_SystemString_1");
Private___intnl_SystemSingle_0 = new AstroUdonVariable<float>(Customization,  "__intnl_SystemSingle_0");
Private___intnl_SystemObject_0 = new AstroUdonVariable<int>(Customization,  "__intnl_SystemObject_0");
Private_pinMesh = new AstroUdonVariable<UnityEngine.MeshRenderer>(Customization,  "pinMesh");
Private_hats = new AstroUdonVariable<UnityEngine.GameObject[]>(Customization,  "hats");
Private___const_SystemString_0 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_0");
Private___intnl_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(Customization,  "__intnl_UnityEngineTransform_0");
Private___const_SystemSingle_0 = new AstroUdonVariable<float>(Customization,  "__const_SystemSingle_0");
Private___intnl_SystemBoolean_16 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_16");
Private_hatTier = new AstroUdonVariable<int[]>(Customization,  "hatTier");
Private___gintnl_SystemUInt32Array_0 = new AstroUdonVariable<uint[]>(Customization,  "__gintnl_SystemUInt32Array_0");
Private___intnl_SystemSingle_8 = new AstroUdonVariable<float>(Customization,  "__intnl_SystemSingle_8");
Private___gintnl_SystemUInt32_5 = new AstroUdonVariable<uint>(Customization,  "__gintnl_SystemUInt32_5");
Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(Customization,  "__gintnl_SystemUInt32_4");
Private___gintnl_SystemUInt32_7 = new AstroUdonVariable<uint>(Customization,  "__gintnl_SystemUInt32_7");
Private___gintnl_SystemUInt32_6 = new AstroUdonVariable<uint>(Customization,  "__gintnl_SystemUInt32_6");
Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(Customization,  "__gintnl_SystemUInt32_1");
Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(Customization,  "__gintnl_SystemUInt32_0");
Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(Customization,  "__gintnl_SystemUInt32_3");
Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(Customization,  "__gintnl_SystemUInt32_2");
Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(Customization,  "__const_SystemBoolean_0");
Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(Customization,  "__const_SystemBoolean_1");
Private___const_SystemString_5 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_5");
Private_greenSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(Customization,  "greenSlider");
Private___intnl_UnityEngineObject_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "__intnl_UnityEngineObject_2");
Private___intnl_UnityEngineObject_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "__intnl_UnityEngineObject_0");
Private_permissionManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "permissionManager");
Private___const_SystemString_16 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_16");
Private___const_SystemString_17 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_17");
Private___const_SystemString_14 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_14");
Private___const_SystemString_15 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_15");
Private___const_SystemString_12 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_12");
Private___const_SystemString_13 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_13");
Private___const_SystemString_10 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_10");
Private___const_SystemString_11 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_11");
Private___const_SystemString_18 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_18");
Private___const_SystemString_19 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_19");
Private___intnl_SystemSingle_7 = new AstroUdonVariable<float>(Customization,  "__intnl_SystemSingle_7");
Private___lcl_color_UnityEngineColor_2 = new AstroUdonVariable<UnityEngine.Color>(Customization,  "__lcl_color_UnityEngineColor_2");
Private___intnl_VRCSDKBaseVRCPlayerApi_0 = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(Customization,  "__intnl_VRCSDKBaseVRCPlayerApi_0");
Private___refl_typeid = new AstroUdonVariable<long>(Customization,  "__refl_typeid");
Private___intnl_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "__intnl_VRCUdonUdonBehaviour_2");
Private___1_color__param = new AstroUdonVariable<UnityEngine.Color>(Customization,  "__1_color__param");
Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(Customization,  "__const_SystemUInt32_0");
Private___intnl_SystemBoolean_11 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_11");
Private___0_tier__param = new AstroUdonVariable<int>(Customization,  "__0_tier__param");
Private___intnl_SystemString_3 = new AstroUdonVariable<string>(Customization,  "__intnl_SystemString_3");
Private_line = new AstroUdonVariable<UnityEngine.LineRenderer>(Customization,  "line");
Private_hatName = new AstroUdonVariable<UnityEngine.UI.Text>(Customization,  "hatName");
Private___intnl_SystemSingle_2 = new AstroUdonVariable<float>(Customization,  "__intnl_SystemSingle_2");
Private___lcl_color_UnityEngineColor_1 = new AstroUdonVariable<UnityEngine.Color>(Customization,  "__lcl_color_UnityEngineColor_1");
Private___intnl_SystemObject_2 = new AstroUdonVariable<UnityEngine.Color>(Customization,  "__intnl_SystemObject_2");
Private___intnl_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "__intnl_VRCUdonUdonBehaviour_1");
Private___const_SystemString_2 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_2");
Private___intnl_UnityEngineColor_0 = new AstroUdonVariable<UnityEngine.Color>(Customization,  "__intnl_UnityEngineColor_0");
Private___intnl_UnityEngineGameObject_3 = new AstroUdonVariable<UnityEngine.GameObject>(Customization,  "__intnl_UnityEngineGameObject_3");
Private___intnl_UnityEngineGameObject_2 = new AstroUdonVariable<UnityEngine.GameObject>(Customization,  "__intnl_UnityEngineGameObject_2");
Private___intnl_UnityEngineGameObject_1 = new AstroUdonVariable<UnityEngine.GameObject>(Customization,  "__intnl_UnityEngineGameObject_1");
Private___intnl_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(Customization,  "__intnl_UnityEngineGameObject_0");
Private___intnl_UnityEngineGameObject_5 = new AstroUdonVariable<UnityEngine.GameObject>(Customization,  "__intnl_UnityEngineGameObject_5");
Private___intnl_UnityEngineGameObject_4 = new AstroUdonVariable<UnityEngine.GameObject>(Customization,  "__intnl_UnityEngineGameObject_4");
Private___intnl_SystemBoolean_14 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_14");
Private__localPin = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "_localPin");
Private_hatParent = new AstroUdonVariable<UnityEngine.Transform>(Customization,  "hatParent");
Private___intnl_SystemString_0 = new AstroUdonVariable<string>(Customization,  "__intnl_SystemString_0");
Private___intnl_SystemSingle_1 = new AstroUdonVariable<float>(Customization,  "__intnl_SystemSingle_1");
Private___intnl_SystemObject_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "__intnl_SystemObject_1");
Private___const_SystemString_7 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_7");
Private___const_SystemSingle_1 = new AstroUdonVariable<float>(Customization,  "__const_SystemSingle_1");
Private___const_VRCUdonCommonEnumsEventTiming_0 = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(Customization,  "__const_VRCUdonCommonEnumsEventTiming_0");
Private_currentHat = new AstroUdonVariable<int>(Customization,  "currentHat");
Private_mapManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "mapManager");
Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(Customization,  "__intnl_returnJump_SystemUInt32_0");
Private___0_color__param = new AstroUdonVariable<UnityEngine.Color>(Customization,  "__0_color__param");
Private___const_SystemString_4 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_4");
Private___intnl_SystemUInt32_0 = new AstroUdonVariable<uint>(Customization,  "__intnl_SystemUInt32_0");
Private___lcl_i_SystemInt32_1 = new AstroUdonVariable<int>(Customization,  "__lcl_i_SystemInt32_1");
Private___lcl_i_SystemInt32_0 = new AstroUdonVariable<int>(Customization,  "__lcl_i_SystemInt32_0");
Private___intnl_SystemString_5 = new AstroUdonVariable<string>(Customization,  "__intnl_SystemString_5");
Private___intnl_SystemSingle_4 = new AstroUdonVariable<float>(Customization,  "__intnl_SystemSingle_4");
Private_redSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(Customization,  "redSlider");
Private___intnl_VRCUdonUdonBehaviour_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "__intnl_VRCUdonUdonBehaviour_3");
Private_patreonMessageColor = new AstroUdonVariable<UnityEngine.UI.Text>(Customization,  "patreonMessageColor");
Private___const_SystemString_9 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_9");
Private___intnl_SystemBoolean_12 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_12");
Private___refl_typename = new AstroUdonVariable<string>(Customization,  "__refl_typename");
Private_blueSlider = new AstroUdonVariable<UnityEngine.UI.Slider>(Customization,  "blueSlider");
Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(Customization,  "__intnl_SystemInt32_1");
Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(Customization,  "__intnl_SystemInt32_0");
Private___intnl_SystemInt32_3 = new AstroUdonVariable<int>(Customization,  "__intnl_SystemInt32_3");
Private___intnl_SystemInt32_2 = new AstroUdonVariable<int>(Customization,  "__intnl_SystemInt32_2");
Private___intnl_SystemInt32_5 = new AstroUdonVariable<int>(Customization,  "__intnl_SystemInt32_5");
Private___intnl_SystemInt32_4 = new AstroUdonVariable<int>(Customization,  "__intnl_SystemInt32_4");
Private___intnl_SystemInt32_6 = new AstroUdonVariable<int>(Customization,  "__intnl_SystemInt32_6");
Private___intnl_SystemString_2 = new AstroUdonVariable<string>(Customization,  "__intnl_SystemString_2");
Private___intnl_SystemSingle_3 = new AstroUdonVariable<float>(Customization,  "__intnl_SystemSingle_3");
Private___const_SystemString_1 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_1");
Private_patreonMessageHat = new AstroUdonVariable<UnityEngine.UI.Text>(Customization,  "patreonMessageHat");
Private___intnl_SystemBoolean_15 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_15");
Private__authorizedTier = new AstroUdonVariable<int>(Customization,  "_authorizedTier");
Private___const_SystemString_6 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_6");
Private___intnl_SystemSingle_6 = new AstroUdonVariable<float>(Customization,  "__intnl_SystemSingle_6");
Private___intnl_SystemBoolean_10 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_10");
Private___const_SystemInt32_1 = new AstroUdonVariable<int>(Customization,  "__const_SystemInt32_1");
Private___const_SystemInt32_0 = new AstroUdonVariable<int>(Customization,  "__const_SystemInt32_0");
Private___const_SystemInt32_3 = new AstroUdonVariable<int>(Customization,  "__const_SystemInt32_3");
Private___const_SystemInt32_2 = new AstroUdonVariable<int>(Customization,  "__const_SystemInt32_2");
Private___const_SystemInt32_4 = new AstroUdonVariable<int>(Customization,  "__const_SystemInt32_4");
Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_8");
Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_9");
Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_0");
Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_1");
Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_2");
Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_3");
Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_4");
Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_5");
Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_6");
Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(Customization,  "__intnl_SystemBoolean_7");
Private___intnl_SystemString_4 = new AstroUdonVariable<string>(Customization,  "__intnl_SystemString_4");
Private___intnl_SystemSingle_5 = new AstroUdonVariable<float>(Customization,  "__intnl_SystemSingle_5");
Private___lcl_color_UnityEngineColor_0 = new AstroUdonVariable<UnityEngine.Color>(Customization,  "__lcl_color_UnityEngineColor_0");
Private___lcl_hatCount_SystemInt32_0 = new AstroUdonVariable<int>(Customization,  "__lcl_hatCount_SystemInt32_0");
Private_pinLabel = new AstroUdonVariable<TMPro.TextMeshProUGUI>(Customization,  "pinLabel");
Private___intnl_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "__intnl_VRCUdonUdonBehaviour_0");
Private___const_SystemString_3 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_3");
Private___this_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "__this_VRCUdonUdonBehaviour_1");
Private___this_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customization,  "__this_VRCUdonUdonBehaviour_0");
Private___const_SystemString_8 = new AstroUdonVariable<string>(Customization,  "__const_SystemString_8");
}


private void Cleanup_Customization()
{
Private___intnl_SystemBoolean_13 = null;
Private___intnl_UnityEngineMaterial_1 = null;
Private___intnl_UnityEngineMaterial_0 = null;
Private___intnl_UnityEngineMaterial_2 = null;
Private___intnl_SystemString_1 = null;
Private___intnl_SystemSingle_0 = null;
Private___intnl_SystemObject_0 = null;
Private_pinMesh = null;
Private_hats = null;
Private___const_SystemString_0 = null;
Private___intnl_UnityEngineTransform_0 = null;
Private___const_SystemSingle_0 = null;
Private___intnl_SystemBoolean_16 = null;
Private_hatTier = null;
Private___gintnl_SystemUInt32Array_0 = null;
Private___intnl_SystemSingle_8 = null;
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
Private___const_SystemString_5 = null;
Private_greenSlider = null;
Private___intnl_UnityEngineObject_2 = null;
Private___intnl_UnityEngineObject_0 = null;
Private_permissionManager = null;
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
Private___lcl_color_UnityEngineColor_2 = null;
Private___intnl_VRCSDKBaseVRCPlayerApi_0 = null;
Private___refl_typeid = null;
Private___intnl_VRCUdonUdonBehaviour_2 = null;
Private___1_color__param = null;
Private___const_SystemUInt32_0 = null;
Private___intnl_SystemBoolean_11 = null;
Private___0_tier__param = null;
Private___intnl_SystemString_3 = null;
Private_line = null;
Private_hatName = null;
Private___intnl_SystemSingle_2 = null;
Private___lcl_color_UnityEngineColor_1 = null;
Private___intnl_SystemObject_2 = null;
Private___intnl_VRCUdonUdonBehaviour_1 = null;
Private___const_SystemString_2 = null;
Private___intnl_UnityEngineColor_0 = null;
Private___intnl_UnityEngineGameObject_3 = null;
Private___intnl_UnityEngineGameObject_2 = null;
Private___intnl_UnityEngineGameObject_1 = null;
Private___intnl_UnityEngineGameObject_0 = null;
Private___intnl_UnityEngineGameObject_5 = null;
Private___intnl_UnityEngineGameObject_4 = null;
Private___intnl_SystemBoolean_14 = null;
Private__localPin = null;
Private_hatParent = null;
Private___intnl_SystemString_0 = null;
Private___intnl_SystemSingle_1 = null;
Private___intnl_SystemObject_1 = null;
Private___const_SystemString_7 = null;
Private___const_SystemSingle_1 = null;
Private___const_VRCUdonCommonEnumsEventTiming_0 = null;
Private_currentHat = null;
Private_mapManager = null;
Private___intnl_returnJump_SystemUInt32_0 = null;
Private___0_color__param = null;
Private___const_SystemString_4 = null;
Private___intnl_SystemUInt32_0 = null;
Private___lcl_i_SystemInt32_1 = null;
Private___lcl_i_SystemInt32_0 = null;
Private___intnl_SystemString_5 = null;
Private___intnl_SystemSingle_4 = null;
Private_redSlider = null;
Private___intnl_VRCUdonUdonBehaviour_3 = null;
Private_patreonMessageColor = null;
Private___const_SystemString_9 = null;
Private___intnl_SystemBoolean_12 = null;
Private___refl_typename = null;
Private_blueSlider = null;
Private___intnl_SystemInt32_1 = null;
Private___intnl_SystemInt32_0 = null;
Private___intnl_SystemInt32_3 = null;
Private___intnl_SystemInt32_2 = null;
Private___intnl_SystemInt32_5 = null;
Private___intnl_SystemInt32_4 = null;
Private___intnl_SystemInt32_6 = null;
Private___intnl_SystemString_2 = null;
Private___intnl_SystemSingle_3 = null;
Private___const_SystemString_1 = null;
Private_patreonMessageHat = null;
Private___intnl_SystemBoolean_15 = null;
Private__authorizedTier = null;
Private___const_SystemString_6 = null;
Private___intnl_SystemSingle_6 = null;
Private___intnl_SystemBoolean_10 = null;
Private___const_SystemInt32_1 = null;
Private___const_SystemInt32_0 = null;
Private___const_SystemInt32_3 = null;
Private___const_SystemInt32_2 = null;
Private___const_SystemInt32_4 = null;
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
Private___intnl_SystemSingle_5 = null;
Private___lcl_color_UnityEngineColor_0 = null;
Private___lcl_hatCount_SystemInt32_0 = null;
Private_pinLabel = null;
Private___intnl_VRCUdonUdonBehaviour_0 = null;
Private___const_SystemString_3 = null;
Private___this_VRCUdonUdonBehaviour_1 = null;
Private___this_VRCUdonUdonBehaviour_0 = null;
Private___const_SystemString_8 = null;
}

       #region Getter / Setters AstroUdonVariables  of Customization                                                                                                                                        
                                                                                                                                                                              
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.Material __intnl_UnityEngineMaterial_1                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___intnl_UnityEngineMaterial_1 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___intnl_UnityEngineMaterial_1.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private___intnl_UnityEngineMaterial_1 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___intnl_UnityEngineMaterial_1.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.Material __intnl_UnityEngineMaterial_2                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___intnl_UnityEngineMaterial_2 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___intnl_UnityEngineMaterial_2.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private___intnl_UnityEngineMaterial_2 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___intnl_UnityEngineMaterial_2.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.MeshRenderer pinMesh                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_pinMesh != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_pinMesh.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_pinMesh != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_pinMesh.Value = value;                                                                                                                    
                    }                                                                                                                                                         
            }                                                                                                                                                                 
        }                                                                                                                                                                     
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.GameObject[] hats                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_hats != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_hats.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_hats != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_hats.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal int[] hatTier                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_hatTier != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_hatTier.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_hatTier != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_hatTier.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.UI.Slider greenSlider                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_greenSlider != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_greenSlider.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_greenSlider != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_greenSlider.Value = value;                                                                                                                    
                    }                                                                                                                                                         
            }                                                                                                                                                                 
        }                                                                                                                                                                     
                                                                                                                                                                              

                                                                                                                                                                              
        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineObject_2                                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineObject_0                                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal VRC.Udon.UdonBehaviour permissionManager                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_permissionManager != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_permissionManager.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_permissionManager != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_permissionManager.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.Color? __lcl_color_UnityEngineColor_2                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___lcl_color_UnityEngineColor_2 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___lcl_color_UnityEngineColor_2.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private___lcl_color_UnityEngineColor_2 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___lcl_color_UnityEngineColor_2.Value = value.Value;                                                                                                                    
                    }                                                                                                                                                         
                }                                                                                                                                                             
            }                                                                                                                                                                 
        }                                                                                                                                                                     
                                                                                                                                                                              

                                                                                                                                                                              
        internal VRC.SDKBase.VRCPlayerApi __intnl_VRCSDKBaseVRCPlayerApi_0                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___intnl_VRCSDKBaseVRCPlayerApi_0 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___intnl_VRCSDKBaseVRCPlayerApi_0.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private___intnl_VRCSDKBaseVRCPlayerApi_0 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___intnl_VRCSDKBaseVRCPlayerApi_0.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.Color? __1_color__param                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___1_color__param != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___1_color__param.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private___1_color__param != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___1_color__param.Value = value.Value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal int? __0_tier__param                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___0_tier__param != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___0_tier__param.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private___0_tier__param != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___0_tier__param.Value = value.Value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.LineRenderer line                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_line != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_line.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_line != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_line.Value = value;                                                                                                                    
                    }                                                                                                                                                         
            }                                                                                                                                                                 
        }                                                                                                                                                                     
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.UI.Text hatName                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_hatName != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_hatName.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_hatName != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_hatName.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.Color? __lcl_color_UnityEngineColor_1                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___lcl_color_UnityEngineColor_1 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___lcl_color_UnityEngineColor_1.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private___lcl_color_UnityEngineColor_1 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___lcl_color_UnityEngineColor_1.Value = value.Value;                                                                                                                    
                    }                                                                                                                                                         
                }                                                                                                                                                             
            }                                                                                                                                                                 
        }                                                                                                                                                                     
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.Color? __intnl_SystemObject_2                                                                                                                                    
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
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private___intnl_SystemObject_2 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___intnl_SystemObject_2.Value = value.Value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.GameObject __intnl_UnityEngineGameObject_3                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___intnl_UnityEngineGameObject_3 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___intnl_UnityEngineGameObject_3.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private___intnl_UnityEngineGameObject_3 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___intnl_UnityEngineGameObject_3.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.GameObject __intnl_UnityEngineGameObject_4                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___intnl_UnityEngineGameObject_4 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___intnl_UnityEngineGameObject_4.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private___intnl_UnityEngineGameObject_4 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___intnl_UnityEngineGameObject_4.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal VRC.Udon.UdonBehaviour _localPin                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private__localPin != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private__localPin.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private__localPin != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private__localPin.Value = value;                                                                                                                    
                    }                                                                                                                                                         
            }                                                                                                                                                                 
        }                                                                                                                                                                     
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.Transform hatParent                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_hatParent != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_hatParent.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_hatParent != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_hatParent.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal int? currentHat                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_currentHat != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_currentHat.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private_currentHat != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_currentHat.Value = value.Value;                                                                                                                    
                    }                                                                                                                                                         
                }                                                                                                                                                             
            }                                                                                                                                                                 
        }                                                                                                                                                                     
                                                                                                                                                                              

                                                                                                                                                                              
        internal VRC.Udon.UdonBehaviour mapManager                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_mapManager != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_mapManager.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_mapManager != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_mapManager.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.Color? __0_color__param                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___0_color__param != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___0_color__param.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private___0_color__param != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___0_color__param.Value = value.Value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.UI.Slider redSlider                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_redSlider != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_redSlider.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_redSlider != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_redSlider.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.UI.Text patreonMessageColor                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_patreonMessageColor != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_patreonMessageColor.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_patreonMessageColor != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_patreonMessageColor.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.UI.Slider blueSlider                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_blueSlider != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_blueSlider.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_blueSlider != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_blueSlider.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal string __intnl_SystemString_2                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___intnl_SystemString_2 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___intnl_SystemString_2.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private___intnl_SystemString_2 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___intnl_SystemString_2.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.UI.Text patreonMessageHat                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_patreonMessageHat != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_patreonMessageHat.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_patreonMessageHat != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_patreonMessageHat.Value = value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal int? _authorizedTier                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private__authorizedTier != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private__authorizedTier.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private__authorizedTier != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private__authorizedTier.Value = value.Value;                                                                                                                    
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
                                                                                                                                                                              

                                                                                                                                                                              
        internal UnityEngine.Color? __lcl_color_UnityEngineColor_0                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___lcl_color_UnityEngineColor_0 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___lcl_color_UnityEngineColor_0.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private___lcl_color_UnityEngineColor_0 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___lcl_color_UnityEngineColor_0.Value = value.Value;                                                                                                                    
                    }                                                                                                                                                         
                }                                                                                                                                                             
            }                                                                                                                                                                 
        }                                                                                                                                                                     
                                                                                                                                                                              

                                                                                                                                                                              
        internal int? __lcl_hatCount_SystemInt32_0                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private___lcl_hatCount_SystemInt32_0 != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private___lcl_hatCount_SystemInt32_0.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                if (value.HasValue)                                                                                                                                           
                {                                                                                                                                                             
                    if (Private___lcl_hatCount_SystemInt32_0 != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private___lcl_hatCount_SystemInt32_0.Value = value.Value;                                                                                                                    
                    }                                                                                                                                                         
                }                                                                                                                                                             
            }                                                                                                                                                                 
        }                                                                                                                                                                     
                                                                                                                                                                              

                                                                                                                                                                              
        internal TMPro.TextMeshProUGUI pinLabel                                                                                                                                    
        {                                                                                                                                                                     
            [HideFromIl2Cpp]                                                                                                                                                  
            get                                                                                                                                                               
            {                                                                                                                                                                 
                if (Private_pinLabel != null)                                                                                                                                    
                {                                                                                                                                                             
                    return Private_pinLabel.Value;                                                                                                                               
                }                                                                                                                                                             
                                                                                                                                                                              
                return null;                                                                                                                                                  
            }                                                                                                                                                                 
            [HideFromIl2Cpp]                                                                                                                                                  
            set                                                                                                                                                               
            {                                                                                                                                                                 
                    if (Private_pinLabel != null)                                                                                                                                
                    {                                                                                                                                                         
                        Private_pinLabel.Value = value;                                                                                                                    
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
                                                                                                                                                                              

     #endregion Getter / Setters AstroUdonVariables  of Customization                                                                                                                                        
       #region  AstroUdonVariables  of Customization                                                                                                                                        
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_13 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Material>  Private___intnl_UnityEngineMaterial_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Material>  Private___intnl_UnityEngineMaterial_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Material>  Private___intnl_UnityEngineMaterial_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___intnl_SystemString_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___intnl_SystemSingle_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___intnl_SystemObject_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.MeshRenderer>  Private_pinMesh {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.GameObject[]>  Private_hats {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Transform>  Private___intnl_UnityEngineTransform_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___const_SystemSingle_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_16 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int[]>  Private_hatTier {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint[]>  Private___gintnl_SystemUInt32Array_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___intnl_SystemSingle_8 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___gintnl_SystemUInt32_5 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___gintnl_SystemUInt32_4 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___gintnl_SystemUInt32_7 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___gintnl_SystemUInt32_6 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___gintnl_SystemUInt32_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___gintnl_SystemUInt32_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___gintnl_SystemUInt32_3 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___gintnl_SystemUInt32_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___const_SystemBoolean_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___const_SystemBoolean_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_5 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.UI.Slider>  Private_greenSlider {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private___intnl_UnityEngineObject_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private___intnl_UnityEngineObject_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private_permissionManager {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_16 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_17 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_14 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_15 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_12 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_13 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_10 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_11 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_18 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_19 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___intnl_SystemSingle_7 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Color>  Private___lcl_color_UnityEngineColor_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>  Private___intnl_VRCSDKBaseVRCPlayerApi_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<long>  Private___refl_typeid {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private___intnl_VRCUdonUdonBehaviour_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Color>  Private___1_color__param {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___const_SystemUInt32_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_11 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___0_tier__param {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___intnl_SystemString_3 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.LineRenderer>  Private_line {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.UI.Text>  Private_hatName {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___intnl_SystemSingle_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Color>  Private___lcl_color_UnityEngineColor_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Color>  Private___intnl_SystemObject_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private___intnl_VRCUdonUdonBehaviour_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Color>  Private___intnl_UnityEngineColor_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.GameObject>  Private___intnl_UnityEngineGameObject_3 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.GameObject>  Private___intnl_UnityEngineGameObject_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.GameObject>  Private___intnl_UnityEngineGameObject_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.GameObject>  Private___intnl_UnityEngineGameObject_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.GameObject>  Private___intnl_UnityEngineGameObject_5 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.GameObject>  Private___intnl_UnityEngineGameObject_4 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_14 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private__localPin {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Transform>  Private_hatParent {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___intnl_SystemString_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___intnl_SystemSingle_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private___intnl_SystemObject_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_7 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___const_SystemSingle_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>  Private___const_VRCUdonCommonEnumsEventTiming_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private_currentHat {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private_mapManager {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___intnl_returnJump_SystemUInt32_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Color>  Private___0_color__param {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_4 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<uint>  Private___intnl_SystemUInt32_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___lcl_i_SystemInt32_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___lcl_i_SystemInt32_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___intnl_SystemString_5 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___intnl_SystemSingle_4 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.UI.Slider>  Private_redSlider {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private___intnl_VRCUdonUdonBehaviour_3 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.UI.Text>  Private_patreonMessageColor {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_9 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_12 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___refl_typename {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.UI.Slider>  Private_blueSlider {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___intnl_SystemInt32_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___intnl_SystemInt32_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___intnl_SystemInt32_3 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___intnl_SystemInt32_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___intnl_SystemInt32_5 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___intnl_SystemInt32_4 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___intnl_SystemInt32_6 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___intnl_SystemString_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___intnl_SystemSingle_3 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.UI.Text>  Private_patreonMessageHat {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_15 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private__authorizedTier {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_6 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___intnl_SystemSingle_6 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_10 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___const_SystemInt32_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___const_SystemInt32_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___const_SystemInt32_3 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___const_SystemInt32_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___const_SystemInt32_4 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_8 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_9 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_2 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_3 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_4 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_5 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_6 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<bool>  Private___intnl_SystemBoolean_7 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___intnl_SystemString_4 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<float>  Private___intnl_SystemSingle_5 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<UnityEngine.Color>  Private___lcl_color_UnityEngineColor_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<int>  Private___lcl_hatCount_SystemInt32_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<TMPro.TextMeshProUGUI>  Private_pinLabel {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private___intnl_VRCUdonUdonBehaviour_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_3 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private___this_VRCUdonUdonBehaviour_1 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<VRC.Udon.UdonBehaviour>  Private___this_VRCUdonUdonBehaviour_0 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
private AstroUdonVariable<string>  Private___const_SystemString_8 {  [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = null;
     #endregion AstroUdonVariables  of Customization                                                                                                                                        

    }
}