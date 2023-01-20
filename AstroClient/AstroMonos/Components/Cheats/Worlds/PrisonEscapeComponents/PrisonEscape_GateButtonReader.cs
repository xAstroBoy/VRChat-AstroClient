using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;
using AstroClient.Tools.UdonSearcher;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    // TODO: Bind UdonBehaviour with this section
    // TODO: I HIGHLY RECCOMEND TO RENAME THIS VARIABLE BEFORE PASTING!
    // TODO: READER FOR UDONBEHAVIOUR Gate Button!

    //Behaviour Gate Button EventKeys
    //Event Key : _interact
    //Event Key : _Interact
    //Event Key : _Enable
    //Event Key : _Disable
    //Event Key : _PowerOff
    //Event Key : _PowerOn
    //

    [RegisterComponent]
    public class PrisonEscape_GateButtonReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_GateButtonReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private RawUdonBehaviour GateButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        public void Start()
        {
            GateButton = UdonSearch.FindUdonEvent("Gate Button", "_Enable").RawItem;
            Initialize_GateButton();
        }

        private void Initialize_GateButton()
        {
            Private___intnl_SystemSingle_0 = new AstroUdonVariable<float>(GateButton, "__intnl_SystemSingle_0");
            Private___const_SystemString_0 = new AstroUdonVariable<string>(GateButton, "__const_SystemString_0");
            Private___const_SystemSingle_0 = new AstroUdonVariable<float>(GateButton, "__const_SystemSingle_0");
            Private_disabledMat = new AstroUdonVariable<UnityEngine.Material>(GateButton, "disabledMat");
            Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(GateButton, "__gintnl_SystemUInt32_0");
            Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(GateButton, "__const_SystemBoolean_0");
            Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(GateButton, "__const_SystemBoolean_1");
            Private___const_SystemString_5 = new AstroUdonVariable<string>(GateButton, "__const_SystemString_5");
            Private___refl_typeid = new AstroUdonVariable<long>(GateButton, "__refl_typeid");
            Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(GateButton, "__const_SystemUInt32_0");
            Private___const_UnityEngineQueryTriggerInteraction_0 = new AstroUdonVariable<UnityEngine.QueryTriggerInteraction>(GateButton, "__const_UnityEngineQueryTriggerInteraction_0");
            Private_powered = new AstroUdonVariable<bool>(GateButton, "powered");
            Private___const_SystemString_2 = new AstroUdonVariable<string>(GateButton, "__const_SystemString_2");
            Private___intnl_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(GateButton, "__intnl_UnityEngineVector3_0");
            Private___lcl_hit_UnityEngineRaycastHit_0 = new AstroUdonVariable<UnityEngine.RaycastHit>(GateButton, "__lcl_hit_UnityEngineRaycastHit_0");
            Private___intnl_SystemSingle_1 = new AstroUdonVariable<float>(GateButton, "__intnl_SystemSingle_1");
            Private___const_SystemString_7 = new AstroUdonVariable<string>(GateButton, "__const_SystemString_7");
            Private___const_SystemSingle_1 = new AstroUdonVariable<float>(GateButton, "__const_SystemSingle_1");
            Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(GateButton, "__intnl_returnJump_SystemUInt32_0");
            Private___const_SystemString_4 = new AstroUdonVariable<string>(GateButton, "__const_SystemString_4");
            Private___lcl_playerPos_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(GateButton, "__lcl_playerPos_UnityEngineVector3_0");
            Private___refl_typename = new AstroUdonVariable<string>(GateButton, "__refl_typename");
            Private_gateControl = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GateButton, "gateControl");
            Private___this_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(GateButton, "__this_UnityEngineTransform_0");
            Private_useSound = new AstroUdonVariable<UnityEngine.AudioSource>(GateButton, "useSound");
            Private___const_SystemString_1 = new AstroUdonVariable<string>(GateButton, "__const_SystemString_1");
            Private___intnl_UnityEngineVector3_1 = new AstroUdonVariable<UnityEngine.Vector3>(GateButton, "__intnl_UnityEngineVector3_1");
            Private___const_SystemString_6 = new AstroUdonVariable<string>(GateButton, "__const_SystemString_6");
            Private___lcl_dir_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(GateButton, "__lcl_dir_UnityEngineVector3_0");
            Private___this_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(GateButton, "__this_UnityEngineGameObject_0");
            Private_enabledMat = new AstroUdonVariable<UnityEngine.Material>(GateButton, "enabledMat");
            Private_gameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(GateButton, "gameManager");
            Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(GateButton, "__intnl_SystemBoolean_0");
            Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(GateButton, "__intnl_SystemBoolean_1");
            Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(GateButton, "__intnl_SystemBoolean_2");
            Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(GateButton, "__intnl_SystemBoolean_3");
            Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(GateButton, "__intnl_SystemBoolean_4");
            Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(GateButton, "__intnl_SystemBoolean_5");
            Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(GateButton, "__intnl_SystemBoolean_6");
            Private___const_SystemString_3 = new AstroUdonVariable<string>(GateButton, "__const_SystemString_3");
            Private_hitLayerMask = new AstroUdonVariable<int>(GateButton, "hitLayerMask");
            Private___const_SystemString_8 = new AstroUdonVariable<string>(GateButton, "__const_SystemString_8");
        }

        private void Cleanup_GateButton()
        {
            Private___intnl_SystemSingle_0 = null;
            Private___const_SystemString_0 = null;
            Private___const_SystemSingle_0 = null;
            Private_disabledMat = null;
            Private___gintnl_SystemUInt32_0 = null;
            Private___const_SystemBoolean_0 = null;
            Private___const_SystemBoolean_1 = null;
            Private___const_SystemString_5 = null;
            Private___refl_typeid = null;
            Private___const_SystemUInt32_0 = null;
            Private___const_UnityEngineQueryTriggerInteraction_0 = null;
            Private_powered = null;
            Private___const_SystemString_2 = null;
            Private___intnl_UnityEngineVector3_0 = null;
            Private___lcl_hit_UnityEngineRaycastHit_0 = null;
            Private___intnl_SystemSingle_1 = null;
            Private___const_SystemString_7 = null;
            Private___const_SystemSingle_1 = null;
            Private___intnl_returnJump_SystemUInt32_0 = null;
            Private___const_SystemString_4 = null;
            Private___lcl_playerPos_UnityEngineVector3_0 = null;
            Private___refl_typename = null;
            Private_gateControl = null;
            Private___this_UnityEngineTransform_0 = null;
            Private_useSound = null;
            Private___const_SystemString_1 = null;
            Private___intnl_UnityEngineVector3_1 = null;
            Private___const_SystemString_6 = null;
            Private___lcl_dir_UnityEngineVector3_0 = null;
            Private___this_UnityEngineGameObject_0 = null;
            Private_enabledMat = null;
            Private_gameManager = null;
            Private___intnl_SystemBoolean_0 = null;
            Private___intnl_SystemBoolean_1 = null;
            Private___intnl_SystemBoolean_2 = null;
            Private___intnl_SystemBoolean_3 = null;
            Private___intnl_SystemBoolean_4 = null;
            Private___intnl_SystemBoolean_5 = null;
            Private___intnl_SystemBoolean_6 = null;
            Private___const_SystemString_3 = null;
            Private_hitLayerMask = null;
            Private___const_SystemString_8 = null;
        }

        #region Getter / Setters AstroUdonVariables  of GateButton

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

        internal UnityEngine.Material disabledMat
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_disabledMat != null)
                {
                    return Private_disabledMat.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_disabledMat != null)
                {
                    Private_disabledMat.Value = value;
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

        internal UnityEngine.QueryTriggerInteraction? __const_UnityEngineQueryTriggerInteraction_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_UnityEngineQueryTriggerInteraction_0 != null)
                {
                    return Private___const_UnityEngineQueryTriggerInteraction_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_UnityEngineQueryTriggerInteraction_0 != null)
                    {
                        Private___const_UnityEngineQueryTriggerInteraction_0.Value = value.Value;
                    }
                }
            }
        }

        internal bool? powered
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_powered != null)
                {
                    return Private_powered.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_powered != null)
                    {
                        Private_powered.Value = value.Value;
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

        internal UnityEngine.RaycastHit? __lcl_hit_UnityEngineRaycastHit_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_hit_UnityEngineRaycastHit_0 != null)
                {
                    return Private___lcl_hit_UnityEngineRaycastHit_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_hit_UnityEngineRaycastHit_0 != null)
                    {
                        Private___lcl_hit_UnityEngineRaycastHit_0.Value = value.Value;
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

        internal UnityEngine.Vector3? __lcl_playerPos_UnityEngineVector3_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_playerPos_UnityEngineVector3_0 != null)
                {
                    return Private___lcl_playerPos_UnityEngineVector3_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_playerPos_UnityEngineVector3_0 != null)
                    {
                        Private___lcl_playerPos_UnityEngineVector3_0.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour gateControl
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gateControl != null)
                {
                    return Private_gateControl.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_gateControl != null)
                {
                    Private_gateControl.Value = value;
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

        internal UnityEngine.AudioSource useSound
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_useSound != null)
                {
                    return Private_useSound.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_useSound != null)
                {
                    Private_useSound.Value = value;
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

        internal UnityEngine.Vector3? __lcl_dir_UnityEngineVector3_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_dir_UnityEngineVector3_0 != null)
                {
                    return Private___lcl_dir_UnityEngineVector3_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_dir_UnityEngineVector3_0 != null)
                    {
                        Private___lcl_dir_UnityEngineVector3_0.Value = value.Value;
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

        internal UnityEngine.Material enabledMat
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_enabledMat != null)
                {
                    return Private_enabledMat.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_enabledMat != null)
                {
                    Private_enabledMat.Value = value;
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

        internal int? hitLayerMask
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_hitLayerMask != null)
                {
                    return Private_hitLayerMask.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_hitLayerMask != null)
                    {
                        Private_hitLayerMask.Value = value.Value;
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

        #endregion Getter / Setters AstroUdonVariables  of GateButton

        #region AstroUdonVariables  of GateButton

        private AstroUdonVariable<float> Private___intnl_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Material> Private_disabledMat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___const_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___const_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.QueryTriggerInteraction> Private___const_UnityEngineQueryTriggerInteraction_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_powered { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.RaycastHit> Private___lcl_hit_UnityEngineRaycastHit_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___lcl_playerPos_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gateControl { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___this_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.AudioSource> Private_useSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___lcl_dir_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___this_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Material> Private_enabledMat { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_hitLayerMask { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of GateButton

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

        private void OnDestroy()
        {
            HasSubscribed = false;
        }
    }
}