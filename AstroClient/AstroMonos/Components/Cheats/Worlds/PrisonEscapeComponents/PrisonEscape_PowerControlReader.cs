using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class PrisonEscape_PowerControlReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_PowerControlReader(IntPtr ptr) : base(ptr)
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
                var obj = gameObject.FindUdonEvent("_TurnOffPower");
                if (obj != null)
                {
                    PowerControlBehaviour = obj.RawItem;
                    TurnPower_Off_Event = obj;
                    TurnPower_On_Event = obj.UdonBehaviour.FindUdonEvent("_TurnOnPower");
                    ResetPowerEvent = obj.UdonBehaviour.FindUdonEvent("_Reset");
                    Initialize_PowerControlBehaviour();
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

        internal void OnDestroy()
        {
            Cleanup_PowerControlBehaviour();
            HasSubscribed = false;
        }

        internal void TurnPowerOff()
        {
            TurnPower_Off_Event.InvokeBehaviour();
        }

        internal void TurnPowerOn()
        {
            TurnPower_On_Event.InvokeBehaviour();
        }

        internal void Reset()
        {
            ResetPowerEvent.InvokeBehaviour();
        }

        private UdonBehaviour_Cached ResetPowerEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private UdonBehaviour_Cached TurnPower_Off_Event { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private UdonBehaviour_Cached TurnPower_On_Event { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private RawUdonBehaviour PowerControlBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_PowerControlBehaviour()
        {
            Private_powerOn = new AstroUdonVariable<bool>(PowerControlBehaviour, "powerOn");
            Private_uiBackgrounds = new AstroUdonVariable<UnityEngine.UI.Image[]>(PowerControlBehaviour, "uiBackgrounds");
            Private_litBackgroundColor = new AstroUdonVariable<UnityEngine.Color>(PowerControlBehaviour, "litBackgroundColor");
            Private___lcl_pData_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__lcl_pData_VRCUdonUdonBehaviour_0");
            Private_darkSewer = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "darkSewer");
            Private___intnl_SystemObject_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_SystemObject_0");
            Private_uiImages = new AstroUdonVariable<UnityEngine.UI.Image[]>(PowerControlBehaviour, "uiImages");
            Private___const_SystemString_0 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_0");
            Private___intnl_UnityEngineUIImage_0 = new AstroUdonVariable<UnityEngine.UI.Image>(PowerControlBehaviour, "__intnl_UnityEngineUIImage_0");
            Private___intnl_SystemObject_10 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_SystemObject_10");
            Private_cachedPowerOn = new AstroUdonVariable<bool>(PowerControlBehaviour, "cachedPowerOn");
            Private_uiTexts = new AstroUdonVariable<TMPro.TextMeshProUGUI[]>(PowerControlBehaviour, "uiTexts");
            Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(PowerControlBehaviour, "__gintnl_SystemUInt32_4");
            Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(PowerControlBehaviour, "__gintnl_SystemUInt32_1");
            Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(PowerControlBehaviour, "__gintnl_SystemUInt32_0");
            Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(PowerControlBehaviour, "__gintnl_SystemUInt32_3");
            Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(PowerControlBehaviour, "__gintnl_SystemUInt32_2");
            Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__const_SystemBoolean_0");
            Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__const_SystemBoolean_1");
            Private___intnl_VRCUdonUdonBehaviour_7 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_VRCUdonUdonBehaviour_7");
            Private___const_SystemString_5 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_5");
            Private_darkSpawn = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "darkSpawn");
            Private___intnl_UnityEngineObject_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_UnityEngineObject_0");
            Private___0__TurnOffPower__ret = new AstroUdonVariable<bool>(PowerControlBehaviour, "__0__TurnOffPower__ret");
            Private___const_SystemString_14 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_14");
            Private___const_SystemString_12 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_12");
            Private___const_SystemString_13 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_13");
            Private___const_SystemString_10 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_10");
            Private___const_SystemString_11 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_11");
            Private___intnl_VRCSDKBaseVRCPlayerApi_0 = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PowerControlBehaviour, "__intnl_VRCSDKBaseVRCPlayerApi_0");
            Private___refl_typeid = new AstroUdonVariable<long>(PowerControlBehaviour, "__refl_typeid");
            Private___intnl_SystemObject_7 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_SystemObject_7");
            Private___intnl_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_VRCUdonUdonBehaviour_2");
            Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(PowerControlBehaviour, "__const_SystemUInt32_0");
            Private_powerBoxEnableDelay = new AstroUdonVariable<float>(PowerControlBehaviour, "powerBoxEnableDelay");
            Private___intnl_SystemBoolean_11 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_11");
            Private___intnl_TMProTextMeshProUGUI_0 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PowerControlBehaviour, "__intnl_TMProTextMeshProUGUI_0");
            Private___intnl_SystemObject_2 = new AstroUdonVariable<UnityEngine.AudioSource>(PowerControlBehaviour, "__intnl_SystemObject_2");
            Private___intnl_SystemObject_9 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_SystemObject_9");
            Private___intnl_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_VRCUdonUdonBehaviour_1");
            Private___const_SystemString_2 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_2");
            Private_litSpawn = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "litSpawn");
            Private___intnl_UnityEngineColor_0 = new AstroUdonVariable<UnityEngine.Color>(PowerControlBehaviour, "__intnl_UnityEngineColor_0");
            Private___intnl_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "__intnl_UnityEngineGameObject_0");
            Private_litPrison = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "litPrison");
            Private_darkUIColor = new AstroUdonVariable<UnityEngine.Color>(PowerControlBehaviour, "darkUIColor");
            Private___intnl_SystemObject_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_SystemObject_1");
            Private_hasTurnedOff = new AstroUdonVariable<bool>(PowerControlBehaviour, "hasTurnedOff");
            Private___intnl_UnityEngineAudioSource_0 = new AstroUdonVariable<UnityEngine.AudioSource>(PowerControlBehaviour, "__intnl_UnityEngineAudioSource_0");
            Private___const_SystemString_7 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_7");
            Private_darkAmbientColor = new AstroUdonVariable<UnityEngine.Color>(PowerControlBehaviour, "darkAmbientColor");
            Private___lcl_bg_UnityEngineUIImage_0 = new AstroUdonVariable<UnityEngine.UI.Image>(PowerControlBehaviour, "__lcl_bg_UnityEngineUIImage_0");
            Private___const_VRCUdonCommonEnumsEventTiming_0 = new AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming>(PowerControlBehaviour, "__const_VRCUdonCommonEnumsEventTiming_0");
            Private___intnl_VRCUdonUdonBehaviour_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_VRCUdonUdonBehaviour_4");
            Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(PowerControlBehaviour, "__intnl_returnJump_SystemUInt32_0");
            Private_powerBoxButton = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "powerBoxButton");
            Private___const_SystemString_4 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_4");
            Private_litUIColor = new AstroUdonVariable<UnityEngine.Color>(PowerControlBehaviour, "litUIColor");
            Private___lcl_image_UnityEngineUIImage_0 = new AstroUdonVariable<UnityEngine.UI.Image>(PowerControlBehaviour, "__lcl_image_UnityEngineUIImage_0");
            Private___intnl_SystemObject_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_SystemObject_4");
            Private___intnl_VRCUdonUdonBehaviour_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_VRCUdonUdonBehaviour_3");
            Private___const_SystemString_9 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_9");
            Private___intnl_SystemBoolean_12 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_12");
            Private___lcl_alive_SystemBoolean_0 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__lcl_alive_SystemBoolean_0");
            Private___refl_typename = new AstroUdonVariable<string>(PowerControlBehaviour, "__refl_typename");
            Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(PowerControlBehaviour, "__intnl_SystemInt32_1");
            Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(PowerControlBehaviour, "__intnl_SystemInt32_0");
            Private_powerIcon = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "powerIcon");
            Private___intnl_SystemObject_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_SystemObject_3");
            Private___const_SystemString_1 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_1");
            Private___intnl_UnityEngineColor_1 = new AstroUdonVariable<UnityEngine.Color>(PowerControlBehaviour, "__intnl_UnityEngineColor_1");
            Private___intnl_VRCUdonUdonBehaviour_6 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_VRCUdonUdonBehaviour_6");
            Private___const_SystemString_6 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_6");
            Private_darkEffects = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "darkEffects");
            Private_litAmbientColor = new AstroUdonVariable<UnityEngine.Color>(PowerControlBehaviour, "litAmbientColor");
            Private___lcl_text_TMProTextMeshProUGUI_0 = new AstroUdonVariable<TMPro.TextMeshProUGUI>(PowerControlBehaviour, "__lcl_text_TMProTextMeshProUGUI_0");
            Private___this_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "__this_UnityEngineGameObject_0");
            Private___intnl_SystemObject_6 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_SystemObject_6");
            Private_darkPrison = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "darkPrison");
            Private___intnl_VRCUdonUdonBehaviour_5 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_VRCUdonUdonBehaviour_5");
            Private___intnl_SystemBoolean_10 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_10");
            Private_fuseBoxAnim = new AstroUdonVariable<UnityEngine.Animator>(PowerControlBehaviour, "fuseBoxAnim");
            Private_gameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "gameManager");
            Private___const_SystemInt32_1 = new AstroUdonVariable<int>(PowerControlBehaviour, "__const_SystemInt32_1");
            Private___const_SystemInt32_0 = new AstroUdonVariable<int>(PowerControlBehaviour, "__const_SystemInt32_0");
            Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_8");
            Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_9");
            Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_0");
            Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_1");
            Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_2");
            Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_3");
            Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_4");
            Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_5");
            Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_6");
            Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemBoolean_7");
            Private___intnl_SystemObject_5 = new AstroUdonVariable<bool>(PowerControlBehaviour, "__intnl_SystemObject_5");
            Private___intnl_SystemObject_8 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_SystemObject_8");
            Private_litSewer = new AstroUdonVariable<UnityEngine.GameObject>(PowerControlBehaviour, "litSewer");
            Private___intnl_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__intnl_VRCUdonUdonBehaviour_0");
            Private___const_SystemString_3 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_3");
            Private___this_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__this_VRCUdonUdonBehaviour_2");
            Private___this_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__this_VRCUdonUdonBehaviour_1");
            Private___this_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PowerControlBehaviour, "__this_VRCUdonUdonBehaviour_0");
            Private___const_SystemString_8 = new AstroUdonVariable<string>(PowerControlBehaviour, "__const_SystemString_8");
            Private_darkBackgroundColor = new AstroUdonVariable<UnityEngine.Color>(PowerControlBehaviour, "darkBackgroundColor");
        }

        private void Cleanup_PowerControlBehaviour()
        {
            Private_powerOn = null;
            Private_uiBackgrounds = null;
            Private_litBackgroundColor = null;
            Private___lcl_pData_VRCUdonUdonBehaviour_0 = null;
            Private_darkSewer = null;
            Private___intnl_SystemObject_0 = null;
            Private_uiImages = null;
            Private___const_SystemString_0 = null;
            Private___intnl_UnityEngineUIImage_0 = null;
            Private___intnl_SystemObject_10 = null;
            Private_cachedPowerOn = null;
            Private_uiTexts = null;
            Private___gintnl_SystemUInt32_4 = null;
            Private___gintnl_SystemUInt32_1 = null;
            Private___gintnl_SystemUInt32_0 = null;
            Private___gintnl_SystemUInt32_3 = null;
            Private___gintnl_SystemUInt32_2 = null;
            Private___const_SystemBoolean_0 = null;
            Private___const_SystemBoolean_1 = null;
            Private___intnl_VRCUdonUdonBehaviour_7 = null;
            Private___const_SystemString_5 = null;
            Private_darkSpawn = null;
            Private___intnl_UnityEngineObject_0 = null;
            Private___0__TurnOffPower__ret = null;
            Private___const_SystemString_14 = null;
            Private___const_SystemString_12 = null;
            Private___const_SystemString_13 = null;
            Private___const_SystemString_10 = null;
            Private___const_SystemString_11 = null;
            Private___intnl_VRCSDKBaseVRCPlayerApi_0 = null;
            Private___refl_typeid = null;
            Private___intnl_SystemObject_7 = null;
            Private___intnl_VRCUdonUdonBehaviour_2 = null;
            Private___const_SystemUInt32_0 = null;
            Private_powerBoxEnableDelay = null;
            Private___intnl_SystemBoolean_11 = null;
            Private___intnl_TMProTextMeshProUGUI_0 = null;
            Private___intnl_SystemObject_2 = null;
            Private___intnl_SystemObject_9 = null;
            Private___intnl_VRCUdonUdonBehaviour_1 = null;
            Private___const_SystemString_2 = null;
            Private_litSpawn = null;
            Private___intnl_UnityEngineColor_0 = null;
            Private___intnl_UnityEngineGameObject_0 = null;
            Private_litPrison = null;
            Private_darkUIColor = null;
            Private___intnl_SystemObject_1 = null;
            Private_hasTurnedOff = null;
            Private___intnl_UnityEngineAudioSource_0 = null;
            Private___const_SystemString_7 = null;
            Private_darkAmbientColor = null;
            Private___lcl_bg_UnityEngineUIImage_0 = null;
            Private___const_VRCUdonCommonEnumsEventTiming_0 = null;
            Private___intnl_VRCUdonUdonBehaviour_4 = null;
            Private___intnl_returnJump_SystemUInt32_0 = null;
            Private_powerBoxButton = null;
            Private___const_SystemString_4 = null;
            Private_litUIColor = null;
            Private___lcl_image_UnityEngineUIImage_0 = null;
            Private___intnl_SystemObject_4 = null;
            Private___intnl_VRCUdonUdonBehaviour_3 = null;
            Private___const_SystemString_9 = null;
            Private___intnl_SystemBoolean_12 = null;
            Private___lcl_alive_SystemBoolean_0 = null;
            Private___refl_typename = null;
            Private___intnl_SystemInt32_1 = null;
            Private___intnl_SystemInt32_0 = null;
            Private_powerIcon = null;
            Private___intnl_SystemObject_3 = null;
            Private___const_SystemString_1 = null;
            Private___intnl_UnityEngineColor_1 = null;
            Private___intnl_VRCUdonUdonBehaviour_6 = null;
            Private___const_SystemString_6 = null;
            Private_darkEffects = null;
            Private_litAmbientColor = null;
            Private___lcl_text_TMProTextMeshProUGUI_0 = null;
            Private___this_UnityEngineGameObject_0 = null;
            Private___intnl_SystemObject_6 = null;
            Private_darkPrison = null;
            Private___intnl_VRCUdonUdonBehaviour_5 = null;
            Private___intnl_SystemBoolean_10 = null;
            Private_fuseBoxAnim = null;
            Private_gameManager = null;
            Private___const_SystemInt32_1 = null;
            Private___const_SystemInt32_0 = null;
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
            Private___intnl_SystemObject_5 = null;
            Private___intnl_SystemObject_8 = null;
            Private_litSewer = null;
            Private___intnl_VRCUdonUdonBehaviour_0 = null;
            Private___const_SystemString_3 = null;
            Private___this_VRCUdonUdonBehaviour_2 = null;
            Private___this_VRCUdonUdonBehaviour_1 = null;
            Private___this_VRCUdonUdonBehaviour_0 = null;
            Private___const_SystemString_8 = null;
            Private_darkBackgroundColor = null;
        }

        #region Getter / Setters AstroUdonVariables  of PowerControlBehaviour

        internal bool? powerOn
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_powerOn != null)
                {
                    return Private_powerOn.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_powerOn != null)
                    {
                        Private_powerOn.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Image[] uiBackgrounds
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_uiBackgrounds != null)
                {
                    return Private_uiBackgrounds.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_uiBackgrounds != null)
                {
                    Private_uiBackgrounds.Value = value;
                }
            }
        }

        internal UnityEngine.Color? litBackgroundColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_litBackgroundColor != null)
                {
                    return Private_litBackgroundColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_litBackgroundColor != null)
                    {
                        Private_litBackgroundColor.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __lcl_pData_VRCUdonUdonBehaviour_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_pData_VRCUdonUdonBehaviour_0 != null)
                {
                    return Private___lcl_pData_VRCUdonUdonBehaviour_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_pData_VRCUdonUdonBehaviour_0 != null)
                {
                    Private___lcl_pData_VRCUdonUdonBehaviour_0.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject darkSewer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_darkSewer != null)
                {
                    return Private_darkSewer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_darkSewer != null)
                {
                    Private_darkSewer.Value = value;
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

        internal UnityEngine.UI.Image[] uiImages
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_uiImages != null)
                {
                    return Private_uiImages.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_uiImages != null)
                {
                    Private_uiImages.Value = value;
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

        internal UnityEngine.UI.Image __intnl_UnityEngineUIImage_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineUIImage_0 != null)
                {
                    return Private___intnl_UnityEngineUIImage_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineUIImage_0 != null)
                {
                    Private___intnl_UnityEngineUIImage_0.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_10 != null)
                {
                    return Private___intnl_SystemObject_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_10 != null)
                {
                    Private___intnl_SystemObject_10.Value = value;
                }
            }
        }

        internal bool? cachedPowerOn
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cachedPowerOn != null)
                {
                    return Private_cachedPowerOn.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cachedPowerOn != null)
                    {
                        Private_cachedPowerOn.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI[] uiTexts
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_uiTexts != null)
                {
                    return Private_uiTexts.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_uiTexts != null)
                {
                    Private_uiTexts.Value = value;
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

        internal UnityEngine.GameObject darkSpawn
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_darkSpawn != null)
                {
                    return Private_darkSpawn.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_darkSpawn != null)
                {
                    Private_darkSpawn.Value = value;
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

        internal bool? __0__TurnOffPower__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0__TurnOffPower__ret != null)
                {
                    return Private___0__TurnOffPower__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0__TurnOffPower__ret != null)
                    {
                        Private___0__TurnOffPower__ret.Value = value.Value;
                    }
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

        internal float? powerBoxEnableDelay
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_powerBoxEnableDelay != null)
                {
                    return Private_powerBoxEnableDelay.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_powerBoxEnableDelay != null)
                    {
                        Private_powerBoxEnableDelay.Value = value.Value;
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

        internal UnityEngine.AudioSource __intnl_SystemObject_2
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

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_9 != null)
                {
                    return Private___intnl_SystemObject_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_9 != null)
                {
                    Private___intnl_SystemObject_9.Value = value;
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

        internal UnityEngine.GameObject litSpawn
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_litSpawn != null)
                {
                    return Private_litSpawn.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_litSpawn != null)
                {
                    Private_litSpawn.Value = value;
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

        internal UnityEngine.GameObject litPrison
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_litPrison != null)
                {
                    return Private_litPrison.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_litPrison != null)
                {
                    Private_litPrison.Value = value;
                }
            }
        }

        internal UnityEngine.Color? darkUIColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_darkUIColor != null)
                {
                    return Private_darkUIColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_darkUIColor != null)
                    {
                        Private_darkUIColor.Value = value.Value;
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

        internal bool? hasTurnedOff
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hasTurnedOff != null)
                {
                    return Private_hasTurnedOff.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hasTurnedOff != null)
                    {
                        Private_hasTurnedOff.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioSource __intnl_UnityEngineAudioSource_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineAudioSource_0 != null)
                {
                    return Private___intnl_UnityEngineAudioSource_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineAudioSource_0 != null)
                {
                    Private___intnl_UnityEngineAudioSource_0.Value = value;
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

        internal UnityEngine.Color? darkAmbientColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_darkAmbientColor != null)
                {
                    return Private_darkAmbientColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_darkAmbientColor != null)
                    {
                        Private_darkAmbientColor.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Image __lcl_bg_UnityEngineUIImage_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_bg_UnityEngineUIImage_0 != null)
                {
                    return Private___lcl_bg_UnityEngineUIImage_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_bg_UnityEngineUIImage_0 != null)
                {
                    Private___lcl_bg_UnityEngineUIImage_0.Value = value;
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

        internal VRC.Udon.UdonBehaviour powerBoxButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_powerBoxButton != null)
                {
                    return Private_powerBoxButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_powerBoxButton != null)
                {
                    Private_powerBoxButton.Value = value;
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

        internal UnityEngine.Color? litUIColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_litUIColor != null)
                {
                    return Private_litUIColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_litUIColor != null)
                    {
                        Private_litUIColor.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.UI.Image __lcl_image_UnityEngineUIImage_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_image_UnityEngineUIImage_0 != null)
                {
                    return Private___lcl_image_UnityEngineUIImage_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_image_UnityEngineUIImage_0 != null)
                {
                    Private___lcl_image_UnityEngineUIImage_0.Value = value;
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

        internal bool? __lcl_alive_SystemBoolean_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_alive_SystemBoolean_0 != null)
                {
                    return Private___lcl_alive_SystemBoolean_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_alive_SystemBoolean_0 != null)
                    {
                        Private___lcl_alive_SystemBoolean_0.Value = value.Value;
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

        internal UnityEngine.GameObject powerIcon
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_powerIcon != null)
                {
                    return Private_powerIcon.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_powerIcon != null)
                {
                    Private_powerIcon.Value = value;
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

        internal UnityEngine.GameObject darkEffects
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_darkEffects != null)
                {
                    return Private_darkEffects.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_darkEffects != null)
                {
                    Private_darkEffects.Value = value;
                }
            }
        }

        internal UnityEngine.Color? litAmbientColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_litAmbientColor != null)
                {
                    return Private_litAmbientColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_litAmbientColor != null)
                    {
                        Private_litAmbientColor.Value = value.Value;
                    }
                }
            }
        }

        internal TMPro.TextMeshProUGUI __lcl_text_TMProTextMeshProUGUI_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_text_TMProTextMeshProUGUI_0 != null)
                {
                    return Private___lcl_text_TMProTextMeshProUGUI_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_text_TMProTextMeshProUGUI_0 != null)
                {
                    Private___lcl_text_TMProTextMeshProUGUI_0.Value = value;
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

        internal UnityEngine.GameObject darkPrison
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_darkPrison != null)
                {
                    return Private_darkPrison.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_darkPrison != null)
                {
                    Private_darkPrison.Value = value;
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

        internal UnityEngine.Animator fuseBoxAnim
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_fuseBoxAnim != null)
                {
                    return Private_fuseBoxAnim.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_fuseBoxAnim != null)
                {
                    Private_fuseBoxAnim.Value = value;
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

        internal bool? __intnl_SystemObject_5
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
                if (value.HasValue)
                {
                    if (Private___intnl_SystemObject_5 != null)
                    {
                        Private___intnl_SystemObject_5.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_SystemObject_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemObject_8 != null)
                {
                    return Private___intnl_SystemObject_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemObject_8 != null)
                {
                    Private___intnl_SystemObject_8.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject litSewer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_litSewer != null)
                {
                    return Private_litSewer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_litSewer != null)
                {
                    Private_litSewer.Value = value;
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

        internal UnityEngine.Color? darkBackgroundColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_darkBackgroundColor != null)
                {
                    return Private_darkBackgroundColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_darkBackgroundColor != null)
                    {
                        Private_darkBackgroundColor.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of PowerControlBehaviour

        #region AstroUdonVariables  of PowerControlBehaviour

        private AstroUdonVariable<bool> Private_powerOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image[]> Private_uiBackgrounds { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_litBackgroundColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_pData_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_darkSewer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image[]> Private_uiImages { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private___intnl_UnityEngineUIImage_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_cachedPowerOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI[]> Private_uiTexts { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___const_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___const_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_darkSpawn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0__TurnOffPower__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___intnl_VRCSDKBaseVRCPlayerApi_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_powerBoxEnableDelay { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___intnl_TMProTextMeshProUGUI_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioSource> Private___intnl_SystemObject_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_litSpawn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_litPrison { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_darkUIColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_hasTurnedOff { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioSource> Private___intnl_UnityEngineAudioSource_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_darkAmbientColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private___lcl_bg_UnityEngineUIImage_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.Common.Enums.EventTiming> Private___const_VRCUdonCommonEnumsEventTiming_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_powerBoxButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_litUIColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Image> Private___lcl_image_UnityEngineUIImage_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___lcl_alive_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_powerIcon { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___intnl_UnityEngineColor_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_darkEffects { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_litAmbientColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private___lcl_text_TMProTextMeshProUGUI_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___this_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_darkPrison { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Animator> Private_fuseBoxAnim { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
        private AstroUdonVariable<bool> Private___intnl_SystemObject_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_SystemObject_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_litSewer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_darkBackgroundColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of PowerControlBehaviour
    }
}