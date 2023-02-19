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

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.MakiMaki.QuickDraws
{
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class QuickDraws_CustomizationReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public QuickDraws_CustomizationReader(IntPtr ptr) : base(ptr)
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
            Cleanup_Customizer();
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal RawUdonBehaviour Customizer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private UdonBehaviour_Cached RefreshPatronSystem { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.QuickDraws))
            {
                var obj = gameObject.FindUdonEvent("_NextPen");
                if (obj != null)
                {
                    Customizer = obj.RawItem;
                    RefreshPatronSystem = obj.UdonBehaviour.FindUdonEvent("_start");
                    Initialize_Customizer();
                    // after this just set the patron tier and call the behaviour _start event and say fuck it lol
                    HasSubscribed = true;
                    __6_intnl_SystemBoolean = false;
                    __8_intnl_SystemBoolean = true;
                    __1_intnl_SystemObject = int.MaxValue;
                    __6_intnl_SystemInt32 = int.MaxValue;
                    __7_intnl_SystemBoolean = true;

                    RefreshPatronSystem.Invoke(); // call it and everything gets unlocked for free LMAO

                }
                else
                {
                    Log.Error("Can't Find Customization behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }

        private void Initialize_Customizer()
        {
            Private__penCount = new AstroUdonVariable<int>(Customizer, "_penCount");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__3_const_intnl_SystemString");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Customizer, "__3_const_intnl_exitJumpLoc_UInt32");
            Private_saveButtonTextButton = new AstroUdonVariable<UnityEngine.UI.Button>(Customizer, "saveButtonTextButton");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__0_const_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(Customizer, "__1_intnl_UnityEngineTransform");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__1_const_intnl_SystemInt32");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__1_intnl_SystemInt32");
            Private___1_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__1_intnl_SystemString");
            Private___0_i_Int32 = new AstroUdonVariable<int>(Customizer, "__0_i_Int32");
            Private_penNameText = new AstroUdonVariable<TMPro.TextMeshProUGUI>(Customizer, "penNameText");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__0_const_intnl_SystemString");
            Private_penParent = new AstroUdonVariable<UnityEngine.Transform>(Customizer, "penParent");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__5_intnl_SystemBoolean");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Customizer, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___5_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__5_intnl_SystemString");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__6_const_intnl_SystemString");
            Private__penNames = new AstroUdonVariable<string[]>(Customizer, "_penNames");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__1_const_intnl_SystemString");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__4_const_intnl_SystemInt32");
            Private_permissionManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customizer, "permissionManager");
            Private___0_isChosen_Boolean = new AstroUdonVariable<bool>(Customizer, "__0_isChosen_Boolean");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Customizer, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__7_intnl_SystemBoolean");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__7_const_intnl_SystemString");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(Customizer, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__4_intnl_SystemBoolean");
            Private_messageText = new AstroUdonVariable<TMPro.TextMeshProUGUI>(Customizer, "messageText");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(Customizer, "__refl_const_intnl_udonTypeName");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__1_intnl_SystemBoolean");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__4_const_intnl_SystemString");
            Private_saveButtonText = new AstroUdonVariable<TMPro.TextMeshProUGUI>(Customizer, "saveButtonText");
            Private___0_intnl_UnityEngineMeshFilter = new AstroUdonVariable<UnityEngine.MeshFilter>(Customizer, "__0_intnl_UnityEngineMeshFilter");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__2_intnl_SystemInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Customizer, "__4_const_intnl_exitJumpLoc_UInt32");
            Private___2_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__2_intnl_SystemString");
            Private_audioManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(Customizer, "audioManager");
            Private___0_intnl_UnityEngineMesh = new AstroUdonVariable<UnityEngine.Mesh>(Customizer, "__0_intnl_UnityEngineMesh");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__3_intnl_SystemBoolean");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__6_intnl_SystemInt32");
            Private___0_authTier_Int32 = new AstroUdonVariable<int>(Customizer, "__0_authTier_Int32");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__0_intnl_SystemBoolean");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__8_const_intnl_SystemString");
            Private__chosenPen = new AstroUdonVariable<int>(Customizer, "_chosenPen");
            Private__penTiers = new AstroUdonVariable<int[]>(Customizer, "_penTiers");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__9_const_intnl_SystemString");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(Customizer, "__0_intnl_returnTarget_UInt32");
            Private_meshFilter = new AstroUdonVariable<UnityEngine.MeshFilter>(Customizer, "meshFilter");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__0_intnl_SystemString");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(Customizer, "__0_const_intnl_SystemUInt32");
            Private__currentPen = new AstroUdonVariable<int>(Customizer, "_currentPen");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__9_intnl_SystemBoolean");
            Private___5_intnl_UnityEngineMeshFilter = new AstroUdonVariable<UnityEngine.MeshFilter>(Customizer, "__5_intnl_UnityEngineMeshFilter");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__4_intnl_SystemInt32");
            Private___4_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__4_intnl_SystemString");
            Private__penMeshes = new AstroUdonVariable<UnityEngine.MeshFilter[]>(Customizer, "_penMeshes");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__6_intnl_SystemBoolean");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__3_intnl_SystemInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__8_intnl_SystemBoolean");
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__3_intnl_SystemString");
            Private___1_intnl_SystemObject = new AstroUdonVariable<int>(Customizer, "__1_intnl_SystemObject");
            Private___2_intnl_UnityEngineMeshFilter = new AstroUdonVariable<UnityEngine.MeshFilter>(Customizer, "__2_intnl_UnityEngineMeshFilter");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__2_const_intnl_SystemInt32");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__10_const_intnl_SystemString");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__7_intnl_SystemInt32");
            Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(Customizer, "__0_intnl_UnityEngineTransform");
            Private___0_mp_index_Int32 = new AstroUdonVariable<int>(Customizer, "__0_mp_index_Int32");
            Private___1_intnl_UnityEngineMeshFilter = new AstroUdonVariable<UnityEngine.MeshFilter>(Customizer, "__1_intnl_UnityEngineMeshFilter");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(Customizer, "__2_intnl_SystemBoolean");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__3_const_intnl_SystemInt32");
            Private___8_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__8_intnl_SystemInt32");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(Customizer, "__2_const_intnl_SystemString");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(Customizer, "__0_const_intnl_SystemInt32");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(Customizer, "__1_const_intnl_exitJumpLoc_UInt32");
            Private_saveButton = new AstroUdonVariable<UnityEngine.UI.Button>(Customizer, "saveButton");
            Private___0_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(Customizer, "__0_intnl_returnValSymbol_Int32");
        }

        private void Cleanup_Customizer()
        {
            Private__penCount = null;
            Private___3_const_intnl_SystemString = null;
            Private___3_const_intnl_exitJumpLoc_UInt32 = null;
            Private_saveButtonTextButton = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineTransform = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___1_intnl_SystemInt32 = null;
            Private___1_intnl_SystemString = null;
            Private___0_i_Int32 = null;
            Private_penNameText = null;
            Private___0_const_intnl_SystemString = null;
            Private_penParent = null;
            Private___5_intnl_SystemBoolean = null;
            Private___5_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___5_intnl_SystemString = null;
            Private___6_const_intnl_SystemString = null;
            Private__penNames = null;
            Private___1_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemInt32 = null;
            Private_permissionManager = null;
            Private___0_isChosen_Boolean = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private___7_intnl_SystemBoolean = null;
            Private___7_const_intnl_SystemString = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private_messageText = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___1_intnl_SystemBoolean = null;
            Private___4_const_intnl_SystemString = null;
            Private_saveButtonText = null;
            Private___0_intnl_UnityEngineMeshFilter = null;
            Private___2_intnl_SystemInt32 = null;
            Private___4_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_intnl_SystemString = null;
            Private_audioManager = null;
            Private___0_intnl_UnityEngineMesh = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___6_intnl_SystemInt32 = null;
            Private___0_authTier_Int32 = null;
            Private___0_intnl_SystemBoolean = null;
            Private___8_const_intnl_SystemString = null;
            Private__chosenPen = null;
            Private__penTiers = null;
            Private___9_const_intnl_SystemString = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private_meshFilter = null;
            Private___0_intnl_SystemString = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private__currentPen = null;
            Private___9_intnl_SystemBoolean = null;
            Private___5_intnl_UnityEngineMeshFilter = null;
            Private___4_intnl_SystemInt32 = null;
            Private___4_intnl_SystemString = null;
            Private__penMeshes = null;
            Private___6_intnl_SystemBoolean = null;
            Private___3_intnl_SystemInt32 = null;
            Private___8_intnl_SystemBoolean = null;
            Private___3_intnl_SystemString = null;
            Private___1_intnl_SystemObject = null;
            Private___2_intnl_UnityEngineMeshFilter = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___10_const_intnl_SystemString = null;
            Private___7_intnl_SystemInt32 = null;
            Private___0_intnl_UnityEngineTransform = null;
            Private___0_mp_index_Int32 = null;
            Private___1_intnl_UnityEngineMeshFilter = null;
            Private___2_intnl_SystemBoolean = null;
            Private___3_const_intnl_SystemInt32 = null;
            Private___8_intnl_SystemInt32 = null;
            Private___2_const_intnl_SystemString = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
            Private_saveButton = null;
            Private___0_intnl_returnValSymbol_Int32 = null;
        }

        #region Getter / Setters AstroUdonVariables  of Customizer

        internal int? _penCount
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__penCount != null)
                {
                    return Private__penCount.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__penCount != null)
                    {
                        Private__penCount.Value = value.Value;
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

        internal UnityEngine.UI.Button saveButtonTextButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saveButtonTextButton != null)
                {
                    return Private_saveButtonTextButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saveButtonTextButton != null)
                {
                    Private_saveButtonTextButton.Value = value;
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

        internal TMPro.TextMeshProUGUI penNameText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_penNameText != null)
                {
                    return Private_penNameText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_penNameText != null)
                {
                    Private_penNameText.Value = value;
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

        internal UnityEngine.Transform penParent
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_penParent != null)
                {
                    return Private_penParent.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_penParent != null)
                {
                    Private_penParent.Value = value;
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

        internal string[] _penNames
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__penNames != null)
                {
                    return Private__penNames.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__penNames != null)
                {
                    Private__penNames.Value = value;
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

        internal bool? __0_isChosen_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_isChosen_Boolean != null)
                {
                    return Private___0_isChosen_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_isChosen_Boolean != null)
                    {
                        Private___0_isChosen_Boolean.Value = value.Value;
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

        internal TMPro.TextMeshProUGUI messageText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_messageText != null)
                {
                    return Private_messageText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_messageText != null)
                {
                    Private_messageText.Value = value;
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

        internal TMPro.TextMeshProUGUI saveButtonText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saveButtonText != null)
                {
                    return Private_saveButtonText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saveButtonText != null)
                {
                    Private_saveButtonText.Value = value;
                }
            }
        }

        internal UnityEngine.MeshFilter __0_intnl_UnityEngineMeshFilter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineMeshFilter != null)
                {
                    return Private___0_intnl_UnityEngineMeshFilter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineMeshFilter != null)
                {
                    Private___0_intnl_UnityEngineMeshFilter.Value = value;
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

        internal VRC.Udon.UdonBehaviour audioManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_audioManager != null)
                {
                    return Private_audioManager.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_audioManager != null)
                {
                    Private_audioManager.Value = value;
                }
            }
        }

        internal UnityEngine.Mesh __0_intnl_UnityEngineMesh
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineMesh != null)
                {
                    return Private___0_intnl_UnityEngineMesh.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineMesh != null)
                {
                    Private___0_intnl_UnityEngineMesh.Value = value;
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

        internal int? __0_authTier_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_authTier_Int32 != null)
                {
                    return Private___0_authTier_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_authTier_Int32 != null)
                    {
                        Private___0_authTier_Int32.Value = value.Value;
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

        internal int? _chosenPen
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__chosenPen != null)
                {
                    return Private__chosenPen.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__chosenPen != null)
                    {
                        Private__chosenPen.Value = value.Value;
                    }
                }
            }
        }

        internal int[] _penTiers
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__penTiers != null)
                {
                    return Private__penTiers.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__penTiers != null)
                {
                    Private__penTiers.Value = value;
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

        internal UnityEngine.MeshFilter meshFilter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_meshFilter != null)
                {
                    return Private_meshFilter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_meshFilter != null)
                {
                    Private_meshFilter.Value = value;
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

        internal int? _currentPen
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__currentPen != null)
                {
                    return Private__currentPen.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__currentPen != null)
                    {
                        Private__currentPen.Value = value.Value;
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

        internal UnityEngine.MeshFilter __5_intnl_UnityEngineMeshFilter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5_intnl_UnityEngineMeshFilter != null)
                {
                    return Private___5_intnl_UnityEngineMeshFilter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5_intnl_UnityEngineMeshFilter != null)
                {
                    Private___5_intnl_UnityEngineMeshFilter.Value = value;
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

        internal UnityEngine.MeshFilter[] _penMeshes
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__penMeshes != null)
                {
                    return Private__penMeshes.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__penMeshes != null)
                {
                    Private__penMeshes.Value = value;
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

        internal int? __1_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemObject != null)
                {
                    return Private___1_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_SystemObject != null)
                    {
                        Private___1_intnl_SystemObject.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.MeshFilter __2_intnl_UnityEngineMeshFilter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_UnityEngineMeshFilter != null)
                {
                    return Private___2_intnl_UnityEngineMeshFilter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_UnityEngineMeshFilter != null)
                {
                    Private___2_intnl_UnityEngineMeshFilter.Value = value;
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

        internal int? __0_mp_index_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_index_Int32 != null)
                {
                    return Private___0_mp_index_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_index_Int32 != null)
                    {
                        Private___0_mp_index_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.MeshFilter __1_intnl_UnityEngineMeshFilter
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineMeshFilter != null)
                {
                    return Private___1_intnl_UnityEngineMeshFilter.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_UnityEngineMeshFilter != null)
                {
                    Private___1_intnl_UnityEngineMeshFilter.Value = value;
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

        internal UnityEngine.UI.Button saveButton
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_saveButton != null)
                {
                    return Private_saveButton.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_saveButton != null)
                {
                    Private_saveButton.Value = value;
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

        #endregion Getter / Setters AstroUdonVariables  of Customizer

        #region AstroUdonVariables  of Customizer

        private AstroUdonVariable<int> Private__penCount { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private_saveButtonTextButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___1_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_penNameText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_penParent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private__penNames { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_permissionManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_isChosen_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_messageText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<TMPro.TextMeshProUGUI> Private_saveButtonText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.MeshFilter> Private___0_intnl_UnityEngineMeshFilter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_audioManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Mesh> Private___0_intnl_UnityEngineMesh { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_authTier_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__chosenPen { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int[]> Private__penTiers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.MeshFilter> Private_meshFilter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__currentPen { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.MeshFilter> Private___5_intnl_UnityEngineMeshFilter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.MeshFilter[]> Private__penMeshes { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.MeshFilter> Private___2_intnl_UnityEngineMeshFilter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.MeshFilter> Private___1_intnl_UnityEngineMeshFilter { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___8_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Button> Private_saveButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of Customizer

    }
}