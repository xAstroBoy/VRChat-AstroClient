using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
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
    public class QuickDraws_PlayerPermissionReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public QuickDraws_PlayerPermissionReader(IntPtr ptr) : base(ptr)
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
            Cleanup_PermissionManager();
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal RawUdonBehaviour PermissionManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.QuickDraws))
            {
                var obj = gameObject.FindUdonEvent("_GetAuthTier");
                if (obj != null)
                {
                    PermissionManager = obj.RawItem;
                    Initialize_PermissionManager();
                    HasSubscribed = true;
                    InvokeRepeating(nameof(ForceHightTier), 0.01f, 0.01f);
                }
                else
                {
                    Log.Error("Can't Find PlayerPermissionManager behaviour, Unable to Add Reader Component, did the author update the world?");
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
            _authTier = int.MaxValue;
        }

        private void Initialize_PermissionManager()
        {
            Private___7_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PermissionManager, "__7_intnl_SystemStringArray");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__3_const_intnl_SystemString");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PermissionManager, "__3_const_intnl_exitJumpLoc_UInt32");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__1_const_intnl_SystemInt32");
            Private___0_t1Count_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t1Count_Int32");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__1_intnl_SystemInt32");
            Private___0_t3Index_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t3Index_Int32");
            Private___1_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__1_intnl_SystemString");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__0_const_intnl_SystemString");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__5_intnl_SystemBoolean");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PermissionManager, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___5_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__5_intnl_SystemString");
            Private___0_t3Count_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t3Count_Int32");
            Private___1_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PermissionManager, "__1_intnl_SystemStringArray");
            Private___1_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PermissionManager, "__1_const_intnl_SystemCharArray");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__6_const_intnl_SystemString");
            Private___0_mp_name2_String = new AstroUdonVariable<string>(PermissionManager, "__0_mp_name2_String");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__1_const_intnl_SystemString");
            Private___4_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__4_const_intnl_SystemInt32");
            Private___8_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PermissionManager, "__8_intnl_SystemStringArray");
            Private___0_const_intnl_SystemChar = new AstroUdonVariable<char>(PermissionManager, "__0_const_intnl_SystemChar");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PermissionManager, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___0_mp_name1_String = new AstroUdonVariable<string>(PermissionManager, "__0_mp_name1_String");
            Private___0_t4Index_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t4Index_Int32");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__7_intnl_SystemBoolean");
            Private___3_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PermissionManager, "__3_intnl_SystemStringArray");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__7_const_intnl_SystemString");
            Private__authTier = new AstroUdonVariable<int>(PermissionManager, "_authTier");
            Private___5_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__5_const_intnl_SystemInt32");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(PermissionManager, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__4_intnl_SystemBoolean");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(PermissionManager, "__refl_const_intnl_udonTypeName");
            Private___1_const_intnl_SystemChar = new AstroUdonVariable<char>(PermissionManager, "__1_const_intnl_SystemChar");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__1_intnl_SystemBoolean");
            Private___0_patreons_StringArray = new AstroUdonVariable<string[]>(PermissionManager, "__0_patreons_StringArray");
            Private__authPlayers = new AstroUdonVariable<System.Object[]>(PermissionManager, "_authPlayers");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__4_const_intnl_SystemString");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__2_intnl_SystemInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PermissionManager, "__4_const_intnl_exitJumpLoc_UInt32");
            Private_eventName = new AstroUdonVariable<string>(PermissionManager, "eventName");
            Private___2_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__2_intnl_SystemString");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__3_intnl_SystemBoolean");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(PermissionManager, "__0_intnl_returnValSymbol_Boolean");
            Private___0_t2Count_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t2Count_Int32");
            Private___0_lineArr_StringArray = new AstroUdonVariable<string[]>(PermissionManager, "__0_lineArr_StringArray");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__6_intnl_SystemInt32");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__0_intnl_SystemBoolean");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__8_const_intnl_SystemString");
            Private___0_line_String = new AstroUdonVariable<string>(PermissionManager, "__0_line_String");
            Private___0_t5Index_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t5Index_Int32");
            Private___0_const_intnl_SystemCharArray = new AstroUdonVariable<char[]>(PermissionManager, "__0_const_intnl_SystemCharArray");
            Private___9_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__9_const_intnl_SystemString");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(PermissionManager, "__0_intnl_returnTarget_UInt32");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__0_intnl_SystemString");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(PermissionManager, "__0_const_intnl_SystemUInt32");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__9_intnl_SystemBoolean");
            Private___4_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PermissionManager, "__4_intnl_SystemStringArray");
            Private___6_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PermissionManager, "__6_intnl_SystemStringArray");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__4_intnl_SystemInt32");
            Private___4_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__4_intnl_SystemString");
            Private___0_mp_players_String = new AstroUdonVariable<string>(PermissionManager, "__0_mp_players_String");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__6_intnl_SystemBoolean");
            Private___0_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PermissionManager, "__0_intnl_VRCSDKBaseVRCPlayerApi");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__3_intnl_SystemInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__8_intnl_SystemBoolean");
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__3_intnl_SystemString");
            Private___0_t1Index_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t1Index_Int32");
            Private___0_t5Count_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t5Count_Int32");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__2_const_intnl_SystemInt32");
            Private___10_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__10_const_intnl_SystemString");
            Private___11_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__11_const_intnl_SystemString");
            Private___0_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PermissionManager, "__0_intnl_SystemStringArray");
            Private___2_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PermissionManager, "__2_intnl_SystemStringArray");
            Private___0_localPlayer_String = new AstroUdonVariable<string>(PermissionManager, "__0_localPlayer_String");
            Private___0_t2Index_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t2Index_Int32");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(PermissionManager, "__2_intnl_SystemBoolean");
            Private___3_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__3_const_intnl_SystemInt32");
            Private___0_t4Count_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_t4Count_Int32");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(PermissionManager, "__2_const_intnl_SystemString");
            Private___5_intnl_SystemStringArray = new AstroUdonVariable<string[]>(PermissionManager, "__5_intnl_SystemStringArray");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(PermissionManager, "__0_const_intnl_SystemInt32");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(PermissionManager, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___0_intnl_returnValSymbol_Int32 = new AstroUdonVariable<int>(PermissionManager, "__0_intnl_returnValSymbol_Int32");
        }

        private void Cleanup_PermissionManager()
        {
            Private___7_intnl_SystemStringArray = null;
            Private___3_const_intnl_SystemString = null;
            Private___3_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___0_t1Count_Int32 = null;
            Private___1_intnl_SystemInt32 = null;
            Private___0_t3Index_Int32 = null;
            Private___1_intnl_SystemString = null;
            Private___0_const_intnl_SystemString = null;
            Private___5_intnl_SystemBoolean = null;
            Private___5_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___5_intnl_SystemString = null;
            Private___0_t3Count_Int32 = null;
            Private___1_intnl_SystemStringArray = null;
            Private___1_const_intnl_SystemCharArray = null;
            Private___6_const_intnl_SystemString = null;
            Private___0_mp_name2_String = null;
            Private___1_const_intnl_SystemString = null;
            Private___4_const_intnl_SystemInt32 = null;
            Private___8_intnl_SystemStringArray = null;
            Private___0_const_intnl_SystemChar = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_mp_name1_String = null;
            Private___0_t4Index_Int32 = null;
            Private___7_intnl_SystemBoolean = null;
            Private___3_intnl_SystemStringArray = null;
            Private___7_const_intnl_SystemString = null;
            Private__authTier = null;
            Private___5_const_intnl_SystemInt32 = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___1_const_intnl_SystemChar = null;
            Private___1_intnl_SystemBoolean = null;
            Private___0_patreons_StringArray = null;
            Private__authPlayers = null;
            Private___4_const_intnl_SystemString = null;
            Private___2_intnl_SystemInt32 = null;
            Private___4_const_intnl_exitJumpLoc_UInt32 = null;
            Private_eventName = null;
            Private___2_intnl_SystemString = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___0_t2Count_Int32 = null;
            Private___0_lineArr_StringArray = null;
            Private___6_intnl_SystemInt32 = null;
            Private___0_intnl_SystemBoolean = null;
            Private___8_const_intnl_SystemString = null;
            Private___0_line_String = null;
            Private___0_t5Index_Int32 = null;
            Private___0_const_intnl_SystemCharArray = null;
            Private___9_const_intnl_SystemString = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___0_intnl_SystemString = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private___9_intnl_SystemBoolean = null;
            Private___4_intnl_SystemStringArray = null;
            Private___6_intnl_SystemStringArray = null;
            Private___4_intnl_SystemInt32 = null;
            Private___4_intnl_SystemString = null;
            Private___0_mp_players_String = null;
            Private___6_intnl_SystemBoolean = null;
            Private___0_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___3_intnl_SystemInt32 = null;
            Private___8_intnl_SystemBoolean = null;
            Private___3_intnl_SystemString = null;
            Private___0_t1Index_Int32 = null;
            Private___0_t5Count_Int32 = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___10_const_intnl_SystemString = null;
            Private___11_const_intnl_SystemString = null;
            Private___0_intnl_SystemStringArray = null;
            Private___2_intnl_SystemStringArray = null;
            Private___0_localPlayer_String = null;
            Private___0_t2Index_Int32 = null;
            Private___2_intnl_SystemBoolean = null;
            Private___3_const_intnl_SystemInt32 = null;
            Private___0_t4Count_Int32 = null;
            Private___2_const_intnl_SystemString = null;
            Private___5_intnl_SystemStringArray = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_intnl_returnValSymbol_Int32 = null;
        }

        #region Getter / Setters AstroUdonVariables  of PermissionManager

        internal string[] __7_intnl_SystemStringArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___7_intnl_SystemStringArray != null)
                {
                    return Private___7_intnl_SystemStringArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___7_intnl_SystemStringArray != null)
                {
                    Private___7_intnl_SystemStringArray.Value = value;
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

        internal int? __0_t1Count_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t1Count_Int32 != null)
                {
                    return Private___0_t1Count_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t1Count_Int32 != null)
                    {
                        Private___0_t1Count_Int32.Value = value.Value;
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

        internal int? __0_t3Index_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t3Index_Int32 != null)
                {
                    return Private___0_t3Index_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t3Index_Int32 != null)
                    {
                        Private___0_t3Index_Int32.Value = value.Value;
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

        internal int? __0_t3Count_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t3Count_Int32 != null)
                {
                    return Private___0_t3Count_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t3Count_Int32 != null)
                    {
                        Private___0_t3Count_Int32.Value = value.Value;
                    }
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

        internal string __0_mp_name2_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_name2_String != null)
                {
                    return Private___0_mp_name2_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_name2_String != null)
                {
                    Private___0_mp_name2_String.Value = value;
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

        internal string[] __8_intnl_SystemStringArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___8_intnl_SystemStringArray != null)
                {
                    return Private___8_intnl_SystemStringArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___8_intnl_SystemStringArray != null)
                {
                    Private___8_intnl_SystemStringArray.Value = value;
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

        internal string __0_mp_name1_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_name1_String != null)
                {
                    return Private___0_mp_name1_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_name1_String != null)
                {
                    Private___0_mp_name1_String.Value = value;
                }
            }
        }

        internal int? __0_t4Index_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t4Index_Int32 != null)
                {
                    return Private___0_t4Index_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t4Index_Int32 != null)
                    {
                        Private___0_t4Index_Int32.Value = value.Value;
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

        internal int? _authTier
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__authTier != null)
                {
                    return Private__authTier.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__authTier != null)
                    {
                        Private__authTier.Value = value.Value;
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

        internal string[] __0_patreons_StringArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_patreons_StringArray != null)
                {
                    return Private___0_patreons_StringArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_patreons_StringArray != null)
                {
                    Private___0_patreons_StringArray.Value = value;
                }
            }
        }

        internal System.Object[] _authPlayers
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__authPlayers != null)
                {
                    return Private__authPlayers.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__authPlayers != null)
                {
                    Private__authPlayers.Value = value;
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

        internal string eventName
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_eventName != null)
                {
                    return Private_eventName.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_eventName != null)
                {
                    Private_eventName.Value = value;
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

        internal int? __0_t2Count_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t2Count_Int32 != null)
                {
                    return Private___0_t2Count_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t2Count_Int32 != null)
                    {
                        Private___0_t2Count_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal string[] __0_lineArr_StringArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_lineArr_StringArray != null)
                {
                    return Private___0_lineArr_StringArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_lineArr_StringArray != null)
                {
                    Private___0_lineArr_StringArray.Value = value;
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

        internal string __0_line_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_line_String != null)
                {
                    return Private___0_line_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_line_String != null)
                {
                    Private___0_line_String.Value = value;
                }
            }
        }

        internal int? __0_t5Index_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t5Index_Int32 != null)
                {
                    return Private___0_t5Index_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t5Index_Int32 != null)
                    {
                        Private___0_t5Index_Int32.Value = value.Value;
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

        internal string __0_mp_players_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_players_String != null)
                {
                    return Private___0_mp_players_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_players_String != null)
                {
                    Private___0_mp_players_String.Value = value;
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

        internal int? __0_t1Index_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t1Index_Int32 != null)
                {
                    return Private___0_t1Index_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t1Index_Int32 != null)
                    {
                        Private___0_t1Index_Int32.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_t5Count_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t5Count_Int32 != null)
                {
                    return Private___0_t5Count_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t5Count_Int32 != null)
                    {
                        Private___0_t5Count_Int32.Value = value.Value;
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

        internal string __0_localPlayer_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_localPlayer_String != null)
                {
                    return Private___0_localPlayer_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_localPlayer_String != null)
                {
                    Private___0_localPlayer_String.Value = value;
                }
            }
        }

        internal int? __0_t2Index_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t2Index_Int32 != null)
                {
                    return Private___0_t2Index_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t2Index_Int32 != null)
                    {
                        Private___0_t2Index_Int32.Value = value.Value;
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

        internal int? __0_t4Count_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_t4Count_Int32 != null)
                {
                    return Private___0_t4Count_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_t4Count_Int32 != null)
                    {
                        Private___0_t4Count_Int32.Value = value.Value;
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

        #endregion Getter / Setters AstroUdonVariables  of PermissionManager

        #region AstroUdonVariables  of PermissionManager

        private AstroUdonVariable<string[]> Private___7_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t1Count_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t3Index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t3Count_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___1_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___1_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_name2_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___8_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___0_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_name1_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t4Index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___3_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__authTier { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___1_const_intnl_SystemChar { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___0_patreons_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.Object[]> Private__authPlayers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_eventName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t2Count_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___0_lineArr_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_line_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t5Index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___0_const_intnl_SystemCharArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___4_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___6_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_players_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t1Index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t5Count_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___0_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___2_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_localPlayer_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t2Index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_t4Count_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___5_intnl_SystemStringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_returnValSymbol_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of PermissionManager
    }
}