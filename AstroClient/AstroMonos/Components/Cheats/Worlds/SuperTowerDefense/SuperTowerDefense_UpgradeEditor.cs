using AstroClient.ClientActions;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class SuperTowerDefense_UpgradeEditor : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_UpgradeEditor(IntPtr ptr) : base(ptr)
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

        private void OnDestroy()
        {
            HasSubscribed = false;
            Cleanup_Upgrader();
            Cleanup_Upgrader2();
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal RawUdonBehaviour Upgrader { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal RawUdonBehaviour Upgrader2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("PlayWhack");
                if (obj != null)
                {
                    Upgrader = obj.RawItem;
                    HasSubscribed = true;
                    Initialize_Upgrader();
                    var obj2 = gameObject.FindUdonEvent("SetController");
                    if (obj2 != null)
                    {
                        Upgrader = obj2.UdonBehaviour.ToRawUdonBehaviour();
                        HasSubscribed = true;
                        Initialize_Upgrader2();
                    }

                    InvokeRepeating(nameof(KeepItFree), 0.01f, 0.01f);
                }
                else
                {
                    Log.Error("Can't Find CurrentTower behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }

        private void KeepItFree()
        {
            if (!WorldModifications.WorldHacks.SuperTowerDefense.MakeUpgradesFree) return;
            __4_intnl_SystemInt32 = 0;
            cost = 0;
            livesCost = 0;
            
        }


        private void Initialize_Upgrader2()
        {
            Private___0_const_intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(Upgrader2, "__0_const_intnl_SystemBoolean");
            Private___0_const_intnl_SystemString_2 = new AstroUdonVariable<string>(Upgrader2, "__0_const_intnl_SystemString");
            Private_controller = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Upgrader2, "controller");
            Private___0_const_intnl_SystemSingle_2 = new AstroUdonVariable<float>(Upgrader2, "__0_const_intnl_SystemSingle");
            Private___1_intnl_SystemSingle_2 = new AstroUdonVariable<float>(Upgrader2, "__1_intnl_SystemSingle");
            Private___0_const_intnl_exitJumpLoc_UInt32_2 = new AstroUdonVariable<uint>(Upgrader2, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___refl_const_intnl_udonTypeID_2 = new AstroUdonVariable<long>(Upgrader2, "__refl_const_intnl_udonTypeID");
            Private___refl_const_intnl_udonTypeName_2 = new AstroUdonVariable<string>(Upgrader2, "__refl_const_intnl_udonTypeName");
            Private___1_intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(Upgrader2, "__1_intnl_SystemBoolean");
            Private_Outline = new AstroUdonVariable<UnityEngine.GameObject>(Upgrader2, "Outline");
            Private_lastWhack = new AstroUdonVariable<float>(Upgrader2, "lastWhack");
            Private_CanvasRotationPoint = new AstroUdonVariable<UnityEngine.Transform>(Upgrader2, "CanvasRotationPoint");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(Upgrader2, "__0_intnl_returnValSymbol_Boolean");
            Private___0_intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(Upgrader2, "__0_intnl_SystemBoolean");
            Private_Particle0 = new AstroUdonVariable<UnityEngine.ParticleSystem>(Upgrader2, "Particle0");
            Private_Particle1 = new AstroUdonVariable<UnityEngine.ParticleSystem>(Upgrader2, "Particle1");
            Private___0_intnl_SystemInt32_2 = new AstroUdonVariable<int>(Upgrader2, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32_2 = new AstroUdonVariable<uint>(Upgrader2, "__0_intnl_returnTarget_UInt32");
            Private___0_const_intnl_SystemUInt32_2 = new AstroUdonVariable<uint>(Upgrader2, "__0_const_intnl_SystemUInt32");
            Private___0_intnl_SystemSingle_2 = new AstroUdonVariable<float>(Upgrader2, "__0_intnl_SystemSingle");
            Private___0_mp_controller_UdonSharpBehaviour = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Upgrader2, "__0_mp_controller_UdonSharpBehaviour");
            Private___1_const_intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(Upgrader2, "__1_const_intnl_SystemBoolean");
            Private_Sound = new AstroUdonVariable<UnityEngine.AudioClip>(Upgrader2, "Sound");
            Private_WhackCount = new AstroUdonVariable<int>(Upgrader2, "WhackCount");
            Private_Shown = new AstroUdonVariable<bool>(Upgrader2, "Shown");
            Private___0_const_intnl_SystemInt32_2 = new AstroUdonVariable<int>(Upgrader2, "__0_const_intnl_SystemInt32");
        }

        private void Cleanup_Upgrader2()
        {
            Private___0_const_intnl_SystemBoolean_2 = null;
            Private___0_const_intnl_SystemString_2 = null;
            Private_controller = null;
            Private___0_const_intnl_SystemSingle_2 = null;
            Private___1_intnl_SystemSingle_2 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32_2 = null;
            Private___refl_const_intnl_udonTypeID_2 = null;
            Private___refl_const_intnl_udonTypeName_2 = null;
            Private___1_intnl_SystemBoolean_2 = null;
            Private_Outline = null;
            Private_lastWhack = null;
            Private_CanvasRotationPoint = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___0_intnl_SystemBoolean_2 = null;
            Private_Particle0 = null;
            Private_Particle1 = null;
            Private___0_intnl_SystemInt32_2 = null;
            Private___0_intnl_returnTarget_UInt32_2 = null;
            Private___0_const_intnl_SystemUInt32_2 = null;
            Private___0_intnl_SystemSingle_2 = null;
            Private___0_mp_controller_UdonSharpBehaviour = null;
            Private___1_const_intnl_SystemBoolean_2 = null;
            Private_Sound = null;
            Private_WhackCount = null;
            Private_Shown = null;
            Private___0_const_intnl_SystemInt32_2 = null;
        }

        #region Getter / Setters AstroUdonVariables  of Upgrader2

        internal bool? __0_const_intnl_SystemBoolean_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemBoolean_2 != null)
                {
                    return Private___0_const_intnl_SystemBoolean_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemBoolean_2 != null)
                    {
                        Private___0_const_intnl_SystemBoolean_2.Value = value.Value;
                    }
                }
            }
        }

        internal string __0_const_intnl_SystemString_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemString_2 != null)
                {
                    return Private___0_const_intnl_SystemString_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_const_intnl_SystemString_2 != null)
                {
                    Private___0_const_intnl_SystemString_2.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour controller
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_controller != null)
                {
                    return Private_controller.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_controller != null)
                {
                    Private_controller.Value = value;
                }
            }
        }

        internal float? __0_const_intnl_SystemSingle_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemSingle_2 != null)
                {
                    return Private___0_const_intnl_SystemSingle_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemSingle_2 != null)
                    {
                        Private___0_const_intnl_SystemSingle_2.Value = value.Value;
                    }
                }
            }
        }

        internal float? __1_intnl_SystemSingle_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemSingle_2 != null)
                {
                    return Private___1_intnl_SystemSingle_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemSingle_2 != null)
                    {
                        Private___1_intnl_SystemSingle_2.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_const_intnl_exitJumpLoc_UInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_exitJumpLoc_UInt32_2 != null)
                {
                    return Private___0_const_intnl_exitJumpLoc_UInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_exitJumpLoc_UInt32_2 != null)
                    {
                        Private___0_const_intnl_exitJumpLoc_UInt32_2.Value = value.Value;
                    }
                }
            }
        }

        internal long? __refl_const_intnl_udonTypeID_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___refl_const_intnl_udonTypeID_2 != null)
                {
                    return Private___refl_const_intnl_udonTypeID_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___refl_const_intnl_udonTypeID_2 != null)
                    {
                        Private___refl_const_intnl_udonTypeID_2.Value = value.Value;
                    }
                }
            }
        }

        internal string __refl_const_intnl_udonTypeName_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___refl_const_intnl_udonTypeName_2 != null)
                {
                    return Private___refl_const_intnl_udonTypeName_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___refl_const_intnl_udonTypeName_2 != null)
                {
                    Private___refl_const_intnl_udonTypeName_2.Value = value;
                }
            }
        }

        internal bool? __1_intnl_SystemBoolean_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemBoolean_2 != null)
                {
                    return Private___1_intnl_SystemBoolean_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemBoolean_2 != null)
                    {
                        Private___1_intnl_SystemBoolean_2.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject Outline
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Outline != null)
                {
                    return Private_Outline.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_Outline != null)
                {
                    Private_Outline.Value = value;
                }
            }
        }

        internal float? lastWhack
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lastWhack != null)
                {
                    return Private_lastWhack.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lastWhack != null)
                    {
                        Private_lastWhack.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform CanvasRotationPoint
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_CanvasRotationPoint != null)
                {
                    return Private_CanvasRotationPoint.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_CanvasRotationPoint != null)
                {
                    Private_CanvasRotationPoint.Value = value;
                }
            }
        }

        internal bool? __0_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___0_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___0_intnl_returnValSymbol_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __0_intnl_SystemBoolean_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemBoolean_2 != null)
                {
                    return Private___0_intnl_SystemBoolean_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemBoolean_2 != null)
                    {
                        Private___0_intnl_SystemBoolean_2.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.ParticleSystem Particle0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Particle0 != null)
                {
                    return Private_Particle0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_Particle0 != null)
                {
                    Private_Particle0.Value = value;
                }
            }
        }

        internal UnityEngine.ParticleSystem Particle1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Particle1 != null)
                {
                    return Private_Particle1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_Particle1 != null)
                {
                    Private_Particle1.Value = value;
                }
            }
        }

        internal int? __0_intnl_SystemInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemInt32_2 != null)
                {
                    return Private___0_intnl_SystemInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemInt32_2 != null)
                    {
                        Private___0_intnl_SystemInt32_2.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_intnl_returnTarget_UInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnTarget_UInt32_2 != null)
                {
                    return Private___0_intnl_returnTarget_UInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnTarget_UInt32_2 != null)
                    {
                        Private___0_intnl_returnTarget_UInt32_2.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __0_const_intnl_SystemUInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemUInt32_2 != null)
                {
                    return Private___0_const_intnl_SystemUInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemUInt32_2 != null)
                    {
                        Private___0_const_intnl_SystemUInt32_2.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_intnl_SystemSingle_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemSingle_2 != null)
                {
                    return Private___0_intnl_SystemSingle_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemSingle_2 != null)
                    {
                        Private___0_intnl_SystemSingle_2.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_mp_controller_UdonSharpBehaviour
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_controller_UdonSharpBehaviour != null)
                {
                    return Private___0_mp_controller_UdonSharpBehaviour.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_controller_UdonSharpBehaviour != null)
                {
                    Private___0_mp_controller_UdonSharpBehaviour.Value = value;
                }
            }
        }

        internal bool? __1_const_intnl_SystemBoolean_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_SystemBoolean_2 != null)
                {
                    return Private___1_const_intnl_SystemBoolean_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_SystemBoolean_2 != null)
                    {
                        Private___1_const_intnl_SystemBoolean_2.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioClip Sound
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Sound != null)
                {
                    return Private_Sound.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_Sound != null)
                {
                    Private_Sound.Value = value;
                }
            }
        }

        internal int? WhackCount
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_WhackCount != null)
                {
                    return Private_WhackCount.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_WhackCount != null)
                    {
                        Private_WhackCount.Value = value.Value;
                    }
                }
            }
        }

        internal bool? Shown
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Shown != null)
                {
                    return Private_Shown.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_Shown != null)
                    {
                        Private_Shown.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_const_intnl_SystemInt32_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemInt32_2 != null)
                {
                    return Private___0_const_intnl_SystemInt32_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemInt32_2 != null)
                    {
                        Private___0_const_intnl_SystemInt32_2.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of Upgrader2

        #region AstroUdonVariables  of Upgrader2

        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_controller { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private_Outline { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_lastWhack { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_CanvasRotationPoint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.ParticleSystem> Private_Particle0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.ParticleSystem> Private_Particle1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_mp_controller_UdonSharpBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_Sound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_WhackCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_Shown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of Upgrader2

        private void Initialize_Upgrader()

        {
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__3_const_intnl_SystemString");
            Private___6_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__6_const_intnl_SystemInt32");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Upgrader, "__3_const_intnl_exitJumpLoc_UInt32");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__0_const_intnl_SystemBoolean");
            Private___3_const_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__3_const_intnl_SystemSingle");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__1_const_intnl_SystemInt32");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__1_intnl_SystemInt32");
            Private___15_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__15_intnl_SystemSingle");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__0_const_intnl_SystemString");
            Private___21_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__21_intnl_SystemSingle");
            Private___0_const_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__0_const_intnl_SystemSingle");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__1_intnl_SystemSingle");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__5_intnl_SystemBoolean");
            Private_flashLivesCostTimer = new AstroUdonVariable<float>(Upgrader, "flashLivesCostTimer");
            Private_Bank = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Upgrader, "Bank");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Upgrader, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__15_intnl_SystemBoolean");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__6_const_intnl_SystemString");
            Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Upgrader, "__5_const_intnl_exitJumpLoc_UInt32");
            Private___6_const_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__6_const_intnl_SystemSingle");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__13_intnl_SystemBoolean");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__1_const_intnl_SystemString");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__4_const_intnl_SystemInt32");
            Private_towerInteractable = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Upgrader, "towerInteractable");
            Private_LivesCostText = new AstroUdonVariable<TMPro.TextMeshPro>(Upgrader, "LivesCostText");
            Private___1_const_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__1_const_intnl_SystemSingle");
            Private___0_const_intnl_SystemChar = new AstroUdonVariable<char>(Upgrader, "__0_const_intnl_SystemChar");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__5_intnl_SystemSingle");
            Private___0_intnl_InteractableBase = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Upgrader, "__0_intnl_InteractableBase");
            Private_HealthController = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Upgrader, "HealthController");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Upgrader, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__16_intnl_SystemBoolean");
            Private___14_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__14_const_intnl_SystemString");
            Private___19_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__19_intnl_SystemSingle");
            Private___0_mp_flashLivesCost_Boolean = new AstroUdonVariable<bool>(Upgrader, "__0_mp_flashLivesCost_Boolean");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__7_intnl_SystemBoolean");
            Private___1_intnl_SystemInt64 = new AstroUdonVariable<long>(Upgrader, "__1_intnl_SystemInt64");
            Private___0_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(Upgrader, "__0_intnl_UnityEngineComponentArray");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__7_const_intnl_SystemString");
            Private___15_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__15_const_intnl_SystemString");
            Private___7_const_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__7_const_intnl_SystemSingle");
            Private___5_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__5_const_intnl_SystemInt32");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(Upgrader, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__4_intnl_SystemBoolean");
            Private___11_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__11_intnl_SystemSingle");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(Upgrader, "__refl_const_intnl_udonTypeName");
            Private_cost = new AstroUdonVariable<int>(Upgrader, "cost");
            Private___0_intnl_SystemObject = new AstroUdonVariable<long>(Upgrader, "__0_intnl_SystemObject");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__1_intnl_SystemBoolean");
            Private___17_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__17_const_intnl_SystemString");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__4_const_intnl_SystemString");
            Private___4_const_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__4_const_intnl_SystemSingle");
            Private_flashCostTimer = new AstroUdonVariable<float>(Upgrader, "flashCostTimer");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__11_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__2_intnl_SystemInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Upgrader, "__4_const_intnl_exitJumpLoc_UInt32");
            Private___9_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__9_intnl_SystemInt32");
            Private___6_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Upgrader, "__6_intnl_UnityEngineVector3");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__2_intnl_SystemSingle");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__3_intnl_SystemBoolean");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__12_intnl_SystemBoolean");
            Private___5_const_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__5_const_intnl_SystemSingle");
            Private___5_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Upgrader, "__5_intnl_UnityEngineVector3");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__6_intnl_SystemInt32");
            Private___17_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__17_intnl_SystemSingle");
            Private_livesCost = new AstroUdonVariable<int>(Upgrader, "livesCost");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__0_intnl_SystemBoolean");
            Private___4_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Upgrader, "__4_intnl_UnityEngineVector3");
            Private___9_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__9_intnl_SystemSingle");
            Private___12_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__12_const_intnl_SystemString");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__8_const_intnl_SystemString");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__6_intnl_SystemSingle");
            Private_HeaderText = new AstroUdonVariable<TMPro.TextMeshPro>(Upgrader, "HeaderText");
            Private_DescriptionText = new AstroUdonVariable<TMPro.TextMeshPro>(Upgrader, "DescriptionText");
            Private___16_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__16_intnl_SystemSingle");
            Private___2_intnl_SystemInt64 = new AstroUdonVariable<long>(Upgrader, "__2_intnl_SystemInt64");
            Private_audioSource = new AstroUdonVariable<UnityEngine.AudioSource>(Upgrader, "audioSource");
            Private___0_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(Upgrader, "__0_const_intnl_SystemCharArray");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__9_const_intnl_SystemString");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(Upgrader, "__0_intnl_returnTarget_UInt32");
            Private_CostText = new AstroUdonVariable<TMPro.TextMeshPro>(Upgrader, "CostText");
            Private_ErrorSound = new AstroUdonVariable<UnityEngine.AudioClip>(Upgrader, "ErrorSound");
            Private___0_mp_time_Single = new AstroUdonVariable<float>(Upgrader, "__0_mp_time_Single");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(Upgrader, "__0_const_intnl_SystemUInt32");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__9_intnl_SystemBoolean");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__0_intnl_SystemSingle");
            Private___18_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__18_const_intnl_SystemString");
            Private___13_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__13_intnl_SystemSingle");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__4_intnl_SystemInt32");
            Private___14_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__14_intnl_SystemSingle");
            Private___3_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Upgrader, "__3_intnl_UnityEngineVector3");
            Private___1_intnl_InteractableBase = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Upgrader, "__1_intnl_InteractableBase");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__6_intnl_SystemBoolean");
            Private___20_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__20_intnl_SystemSingle");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__4_intnl_SystemSingle");
            Private___2_const_intnl_SystemInt64 = new AstroUdonVariable<long>(Upgrader, "__2_const_intnl_SystemInt64");
            Private_CantAffordColor = new AstroUdonVariable<UnityEngine.Color>(Upgrader, "CantAffordColor");
            Private___12_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__12_intnl_SystemSingle");
            Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__14_intnl_SystemBoolean");
            Private___0_intnl_SystemInt64 = new AstroUdonVariable<long>(Upgrader, "__0_intnl_SystemInt64");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__3_intnl_SystemInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__8_intnl_SystemBoolean");
            Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Upgrader, "__2_intnl_UnityEngineVector3");
            Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Upgrader, "__1_intnl_UnityEngineVector3");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__3_intnl_SystemSingle");
            Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(Upgrader, "__0_intnl_UnityEngineVector3");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__10_const_intnl_SystemString");
            Private___0_mp_flashMoneyCost_Boolean = new AstroUdonVariable<bool>(Upgrader, "__0_mp_flashMoneyCost_Boolean");
            Private___18_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__18_intnl_SystemSingle");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__7_intnl_SystemInt32");
            Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(Upgrader, "__0_intnl_UnityEngineTransform");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__1_const_intnl_SystemBoolean");
            Private_AffordColor = new AstroUdonVariable<UnityEngine.Color>(Upgrader, "AffordColor");
            Private___0_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Upgrader, "__0_intnl_UnityEngineColor");
            Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__11_const_intnl_SystemString");
            Private___16_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__16_const_intnl_SystemString");
            Private___0_const_intnl_SystemInt64 = new AstroUdonVariable<long>(Upgrader, "__0_const_intnl_SystemInt64");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__2_intnl_SystemBoolean");
            Private___10_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__10_intnl_SystemSingle");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__3_const_intnl_SystemInt32");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__7_intnl_SystemSingle");
            Private_NameText = new AstroUdonVariable<TMPro.TextMeshPro>(Upgrader, "NameText");
            Private___0_this_intnl_InteractableTowerUpgrade = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Upgrader, "__0_this_intnl_InteractableTowerUpgrade");
            Private___13_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__13_const_intnl_SystemString");
            Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__8_intnl_SystemInt32");
            Private___3_intnl_SystemInt64 = new AstroUdonVariable<long>(Upgrader, "__3_intnl_SystemInt64");
            Private___0_mp_x_Single = new AstroUdonVariable<float>(Upgrader, "__0_mp_x_Single");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(Upgrader, "__10_intnl_SystemBoolean");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(Upgrader, "__2_const_intnl_SystemString");
            Private___0_intnl_returnValSymbol_Single = new AstroUdonVariable<float>(Upgrader, "__0_intnl_returnValSymbol_Single");
            Private___1_const_intnl_SystemInt64 = new AstroUdonVariable<long>(Upgrader, "__1_const_intnl_SystemInt64");
            Private___2_const_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__2_const_intnl_SystemSingle");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Upgrader, "__0_const_intnl_SystemInt32");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Upgrader, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___8_intnl_SystemSingle = new AstroUdonVariable<float>(Upgrader, "__8_intnl_SystemSingle");
            Private___1_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(Upgrader, "__1_intnl_UnityEngineColor");
            Private___0_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Upgrader, "__0_intnl_UnityEngineComponent");
        }

        private void Cleanup_Upgrader()
        {
            Private___3_const_intnl_SystemString = null;
            Private___6_const_intnl_SystemInt32 = null;
            Private___3_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___3_const_intnl_SystemSingle = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___1_intnl_SystemInt32 = null;
            Private___15_intnl_SystemSingle = null;
            Private___0_const_intnl_SystemString = null;
            Private___21_intnl_SystemSingle = null;
            Private___0_const_intnl_SystemSingle = null;
            Private___1_intnl_SystemSingle = null;
            Private___5_intnl_SystemBoolean = null;
            Private_flashLivesCostTimer = null;
            Private_Bank = null;
            Private___5_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___15_intnl_SystemBoolean = null;
            Private___6_const_intnl_SystemString = null;
            Private___5_const_intnl_exitJumpLoc_UInt32 = null;
            Private___6_const_intnl_SystemSingle = null;
            Private___13_intnl_SystemBoolean = null;
            Private___1_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemInt32 = null;
            Private_towerInteractable = null;
            Private_LivesCostText = null;
            Private___1_const_intnl_SystemSingle = null;
            Private___0_const_intnl_SystemChar = null;
            Private___5_intnl_SystemSingle = null;
            Private___0_intnl_InteractableBase = null;
            Private_HealthController = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private___16_intnl_SystemBoolean = null;
            Private___14_const_intnl_SystemString = null;
            Private___19_intnl_SystemSingle = null;
            Private___0_mp_flashLivesCost_Boolean = null;
            Private___7_intnl_SystemBoolean = null;
            Private___1_intnl_SystemInt64 = null;
            Private___0_intnl_UnityEngineComponentArray = null;
            Private___7_const_intnl_SystemString = null;
            Private___15_const_intnl_SystemString = null;
            Private___7_const_intnl_SystemSingle = null;
            Private___5_const_intnl_SystemInt32 = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private___11_intnl_SystemSingle = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private_cost = null;
            Private___0_intnl_SystemObject = null;
            Private___1_intnl_SystemBoolean = null;
            Private___17_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemSingle = null;
            Private_flashCostTimer = null;
            Private___11_intnl_SystemBoolean = null;
            Private___2_intnl_SystemInt32 = null;
            Private___4_const_intnl_exitJumpLoc_UInt32 = null;
            Private___9_intnl_SystemInt32 = null;
            Private___6_intnl_UnityEngineVector3 = null;
            Private___2_intnl_SystemSingle = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___12_intnl_SystemBoolean = null;
            Private___5_const_intnl_SystemSingle = null;
            Private___5_intnl_UnityEngineVector3 = null;
            Private___6_intnl_SystemInt32 = null;
            Private___17_intnl_SystemSingle = null;
            Private_livesCost = null;
            Private___0_intnl_SystemBoolean = null;
            Private___4_intnl_UnityEngineVector3 = null;
            Private___9_intnl_SystemSingle = null;
            Private___12_const_intnl_SystemString = null;
            Private___8_const_intnl_SystemString = null;
            Private___6_intnl_SystemSingle = null;
            Private_HeaderText = null;
            Private_DescriptionText = null;
            Private___16_intnl_SystemSingle = null;
            Private___2_intnl_SystemInt64 = null;
            Private_audioSource = null;
            Private___0_const_intnl_SystemCharArray = null;
            Private___9_const_intnl_SystemString = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private_CostText = null;
            Private_ErrorSound = null;
            Private___0_mp_time_Single = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private___9_intnl_SystemBoolean = null;
            Private___0_intnl_SystemSingle = null;
            Private___18_const_intnl_SystemString = null;
            Private___13_intnl_SystemSingle = null;
            Private___4_intnl_SystemInt32 = null;
            Private___14_intnl_SystemSingle = null;
            Private___3_intnl_UnityEngineVector3 = null;
            Private___1_intnl_InteractableBase = null;
            Private___6_intnl_SystemBoolean = null;
            Private___20_intnl_SystemSingle = null;
            Private___4_intnl_SystemSingle = null;
            Private___2_const_intnl_SystemInt64 = null;
            Private_CantAffordColor = null;
            Private___12_intnl_SystemSingle = null;
            Private___14_intnl_SystemBoolean = null;
            Private___0_intnl_SystemInt64 = null;
            Private___3_intnl_SystemInt32 = null;
            Private___8_intnl_SystemBoolean = null;
            Private___2_intnl_UnityEngineVector3 = null;
            Private___1_intnl_UnityEngineVector3 = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___3_intnl_SystemSingle = null;
            Private___0_intnl_UnityEngineVector3 = null;
            Private___10_const_intnl_SystemString = null;
            Private___0_mp_flashMoneyCost_Boolean = null;
            Private___18_intnl_SystemSingle = null;
            Private___7_intnl_SystemInt32 = null;
            Private___0_intnl_UnityEngineTransform = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private_AffordColor = null;
            Private___0_intnl_UnityEngineColor = null;
            Private___11_const_intnl_SystemString = null;
            Private___16_const_intnl_SystemString = null;
            Private___0_const_intnl_SystemInt64 = null;
            Private___2_intnl_SystemBoolean = null;
            Private___10_intnl_SystemSingle = null;
            Private___3_const_intnl_SystemInt32 = null;
            Private___7_intnl_SystemSingle = null;
            Private_NameText = null;
            Private___0_this_intnl_InteractableTowerUpgrade = null;
            Private___13_const_intnl_SystemString = null;
            Private___8_intnl_SystemInt32 = null;
            Private___3_intnl_SystemInt64 = null;
            Private___0_mp_x_Single = null;
            Private___10_intnl_SystemBoolean = null;
            Private___2_const_intnl_SystemString = null;
            Private___0_intnl_returnValSymbol_Single = null;
            Private___1_const_intnl_SystemInt64 = null;
            Private___2_const_intnl_SystemSingle = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
            Private___8_intnl_SystemSingle = null;
            Private___1_intnl_UnityEngineColor = null;
            Private___0_intnl_UnityEngineComponent = null;
        }

        #region Getter / Setters AstroUdonVariables  of Upgrader

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

        internal float? flashLivesCostTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_flashLivesCostTimer != null)
                {
                    return Private_flashLivesCostTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_flashLivesCostTimer != null)
                    {
                        Private_flashLivesCostTimer.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour Bank
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Bank != null)
                {
                    return Private_Bank.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_Bank != null)
                {
                    Private_Bank.Value = value;
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

        internal float? __6_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___6_const_intnl_SystemSingle != null)
                {
                    return Private___6_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___6_const_intnl_SystemSingle != null)
                    {
                        Private___6_const_intnl_SystemSingle.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour towerInteractable
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_towerInteractable != null)
                {
                    return Private_towerInteractable.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_towerInteractable != null)
                {
                    Private_towerInteractable.Value = value;
                }
            }
        }

        internal TMPro.TextMeshPro LivesCostText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_LivesCostText != null)
                {
                    return Private_LivesCostText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_LivesCostText != null)
                {
                    Private_LivesCostText.Value = value;
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

        internal VRC.Udon.UdonBehaviour __0_intnl_InteractableBase
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_InteractableBase != null)
                {
                    return Private___0_intnl_InteractableBase.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_InteractableBase != null)
                {
                    Private___0_intnl_InteractableBase.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour HealthController
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_HealthController != null)
                {
                    return Private_HealthController.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_HealthController != null)
                {
                    Private_HealthController.Value = value;
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

        internal bool? __0_mp_flashLivesCost_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_flashLivesCost_Boolean != null)
                {
                    return Private___0_mp_flashLivesCost_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_flashLivesCost_Boolean != null)
                    {
                        Private___0_mp_flashLivesCost_Boolean.Value = value.Value;
                    }
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

        internal long? __1_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemInt64 != null)
                {
                    return Private___1_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemInt64 != null)
                    {
                        Private___1_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Component[] __0_intnl_UnityEngineComponentArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineComponentArray != null)
                {
                    return Private___0_intnl_UnityEngineComponentArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineComponentArray != null)
                {
                    Private___0_intnl_UnityEngineComponentArray.Value = value;
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

        internal float? __7_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_const_intnl_SystemSingle != null)
                {
                    return Private___7_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___7_const_intnl_SystemSingle != null)
                    {
                        Private___7_const_intnl_SystemSingle.Value = value.Value;
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

        internal int? cost
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cost != null)
                {
                    return Private_cost.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cost != null)
                    {
                        Private_cost.Value = value.Value;
                    }
                }
            }
        }

        internal long? __0_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemObject != null)
                {
                    return Private___0_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_SystemObject != null)
                    {
                        Private___0_intnl_SystemObject.Value = value.Value;
                    }
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

        internal float? __4_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4_const_intnl_SystemSingle != null)
                {
                    return Private___4_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___4_const_intnl_SystemSingle != null)
                    {
                        Private___4_const_intnl_SystemSingle.Value = value.Value;
                    }
                }
            }
        }

        internal float? flashCostTimer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_flashCostTimer != null)
                {
                    return Private_flashCostTimer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_flashCostTimer != null)
                    {
                        Private_flashCostTimer.Value = value.Value;
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

        internal float? __5_const_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_const_intnl_SystemSingle != null)
                {
                    return Private___5_const_intnl_SystemSingle.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___5_const_intnl_SystemSingle != null)
                    {
                        Private___5_const_intnl_SystemSingle.Value = value.Value;
                    }
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

        internal int? livesCost
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_livesCost != null)
                {
                    return Private_livesCost.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_livesCost != null)
                    {
                        Private_livesCost.Value = value.Value;
                    }
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

        internal TMPro.TextMeshPro HeaderText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_HeaderText != null)
                {
                    return Private_HeaderText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_HeaderText != null)
                {
                    Private_HeaderText.Value = value;
                }
            }
        }

        internal TMPro.TextMeshPro DescriptionText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_DescriptionText != null)
                {
                    return Private_DescriptionText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_DescriptionText != null)
                {
                    Private_DescriptionText.Value = value;
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

        internal long? __2_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemInt64 != null)
                {
                    return Private___2_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_intnl_SystemInt64 != null)
                    {
                        Private___2_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.AudioSource audioSource
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_audioSource != null)
                {
                    return Private_audioSource.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_audioSource != null)
                {
                    Private_audioSource.Value = value;
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

        internal TMPro.TextMeshPro CostText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_CostText != null)
                {
                    return Private_CostText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_CostText != null)
                {
                    Private_CostText.Value = value;
                }
            }
        }

        internal UnityEngine.AudioClip ErrorSound
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ErrorSound != null)
                {
                    return Private_ErrorSound.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_ErrorSound != null)
                {
                    Private_ErrorSound.Value = value;
                }
            }
        }

        internal float? __0_mp_time_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_time_Single != null)
                {
                    return Private___0_mp_time_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_time_Single != null)
                    {
                        Private___0_mp_time_Single.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __1_intnl_InteractableBase
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_InteractableBase != null)
                {
                    return Private___1_intnl_InteractableBase.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_InteractableBase != null)
                {
                    Private___1_intnl_InteractableBase.Value = value;
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

        internal long? __2_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_const_intnl_SystemInt64 != null)
                {
                    return Private___2_const_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_const_intnl_SystemInt64 != null)
                    {
                        Private___2_const_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Color? CantAffordColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_CantAffordColor != null)
                {
                    return Private_CantAffordColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_CantAffordColor != null)
                    {
                        Private_CantAffordColor.Value = value.Value;
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

        internal bool? __0_mp_flashMoneyCost_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_flashMoneyCost_Boolean != null)
                {
                    return Private___0_mp_flashMoneyCost_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_flashMoneyCost_Boolean != null)
                    {
                        Private___0_mp_flashMoneyCost_Boolean.Value = value.Value;
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

        internal UnityEngine.Color? AffordColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_AffordColor != null)
                {
                    return Private_AffordColor.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_AffordColor != null)
                    {
                        Private_AffordColor.Value = value.Value;
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

        internal long? __0_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemInt64 != null)
                {
                    return Private___0_const_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemInt64 != null)
                    {
                        Private___0_const_intnl_SystemInt64.Value = value.Value;
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

        internal TMPro.TextMeshPro NameText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_NameText != null)
                {
                    return Private_NameText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_NameText != null)
                {
                    Private_NameText.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_this_intnl_InteractableTowerUpgrade
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_InteractableTowerUpgrade != null)
                {
                    return Private___0_this_intnl_InteractableTowerUpgrade.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_InteractableTowerUpgrade != null)
                {
                    Private___0_this_intnl_InteractableTowerUpgrade.Value = value;
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

        internal long? __3_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemInt64 != null)
                {
                    return Private___3_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___3_intnl_SystemInt64 != null)
                    {
                        Private___3_intnl_SystemInt64.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_mp_x_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_x_Single != null)
                {
                    return Private___0_mp_x_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_x_Single != null)
                    {
                        Private___0_mp_x_Single.Value = value.Value;
                    }
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

        internal float? __0_intnl_returnValSymbol_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_Single != null)
                {
                    return Private___0_intnl_returnValSymbol_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_Single != null)
                    {
                        Private___0_intnl_returnValSymbol_Single.Value = value.Value;
                    }
                }
            }
        }

        internal long? __1_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_SystemInt64 != null)
                {
                    return Private___1_const_intnl_SystemInt64.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_SystemInt64 != null)
                    {
                        Private___1_const_intnl_SystemInt64.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __0_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineComponent != null)
                {
                    return Private___0_intnl_UnityEngineComponent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineComponent != null)
                {
                    Private___0_intnl_UnityEngineComponent.Value = value;
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of Upgrader

        #region AstroUdonVariables  of Upgrader

        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___15_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___21_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_flashLivesCostTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_Bank { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_towerInteractable { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshPro> Private_LivesCostText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___0_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_InteractableBase { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_HealthController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___14_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___19_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_flashLivesCost_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___1_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___0_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___15_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___11_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_cost { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___17_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_flashCostTimer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___9_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___6_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___5_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___17_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_livesCost { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___4_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___9_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshPro> Private_HeaderText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshPro> Private_DescriptionText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___16_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___2_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioSource> Private_audioSource { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___0_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshPro> Private_CostText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.AudioClip> Private_ErrorSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_time_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___18_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___13_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___14_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___3_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_InteractableBase { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___20_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___2_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_CantAffordColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___12_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___2_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_flashMoneyCost_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___18_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_AffordColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___0_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___16_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___10_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshPro> Private_NameText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_this_intnl_InteractableTowerUpgrade { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___13_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___3_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_x_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_returnValSymbol_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___1_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_const_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___8_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___1_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of Upgrader
    }
}