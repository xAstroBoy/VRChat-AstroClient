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
using IntPtr = System.IntPtr;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.DreamWaves
{

    [RegisterComponent]
    public class DreamWaves_WhiteListManagerReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public DreamWaves_WhiteListManagerReader(IntPtr ptr) : base(ptr)
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

        private RawUdonBehaviour WhitelistSystem { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.DreamWaves))
            {
                var obj = gameObject.FindUdonEvent("_IsWhitelisted");
                if (obj != null)
                {
                    WhitelistSystem = obj.UdonBehaviour.ToRawUdonBehaviour();
                    Initialize_WhitelistSystem();
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
            Cleanup_WhitelistSystem();
        }

        private void Initialize_WhitelistSystem()
        {
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__0_const_intnl_SystemBoolean");
            Private__listNames = new AstroUdonVariable<string[]>(WhitelistSystem, "_listNames");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__1_const_intnl_SystemInt32");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__1_intnl_SystemInt32");
            Private___1_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__1_intnl_SystemString");
            Private___1_i_Int32 = new AstroUdonVariable<int>(WhitelistSystem, "__1_i_Int32");
            Private___0_i_Int32 = new AstroUdonVariable<int>(WhitelistSystem, "__0_i_Int32");
            Private___2_i_Int32 = new AstroUdonVariable<int>(WhitelistSystem, "__2_i_Int32");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__0_const_intnl_SystemString");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__5_intnl_SystemBoolean");
            Private___0_intnl_UnityEngineTextAsset = new AstroUdonVariable<UnityEngine.TextAsset>(WhitelistSystem, "__0_intnl_UnityEngineTextAsset");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__0_const_intnl_exitJumpLoc_UInt32");
            Private__hasStarted = new AstroUdonVariable<bool>(WhitelistSystem, "_hasStarted");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__1_const_intnl_SystemString");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__2_const_intnl_exitJumpLoc_UInt32");
            Private_whitelists = new AstroUdonVariable<UnityEngine.TextAsset[]>(WhitelistSystem, "whitelists");
            Private___1_const_intnl_SystemStringComparison = new AstroUdonVariable<System.StringComparison>(WhitelistSystem, "__1_const_intnl_SystemStringComparison");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(WhitelistSystem, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__4_intnl_SystemBoolean");
            Private___0_const_intnl_SystemStringSplitOptions = new AstroUdonVariable<System.StringSplitOptions>(WhitelistSystem, "__0_const_intnl_SystemStringSplitOptions");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(WhitelistSystem, "__refl_const_intnl_udonTypeName");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__1_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__2_intnl_SystemInt32");
            Private___2_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__2_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__3_intnl_SystemBoolean");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(WhitelistSystem, "__0_intnl_returnValSymbol_Boolean");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__6_intnl_SystemInt32");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__0_intnl_SystemBoolean");
            Private___0_stringComparison_StringComparison = new AstroUdonVariable<System.StringComparison>(WhitelistSystem, "__0_stringComparison_StringComparison");
            Private___0_mp_listName_String = new AstroUdonVariable<string>(WhitelistSystem, "__0_mp_listName_String");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__0_intnl_returnTarget_UInt32");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__0_intnl_SystemString");
            Private___0_mp_playerName_String = new AstroUdonVariable<string>(WhitelistSystem, "__0_mp_playerName_String");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__0_const_intnl_SystemUInt32");
            Private___0_const_intnl_SystemStringComparison = new AstroUdonVariable<System.StringComparison>(WhitelistSystem, "__0_const_intnl_SystemStringComparison");
            Private___0_intnl_SystemBooleanArray = new AstroUdonVariable<bool[]>(WhitelistSystem, "__0_intnl_SystemBooleanArray");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__4_intnl_SystemInt32");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__6_intnl_SystemBoolean");
            Private___0_mp_textAsset_TextAsset = new AstroUdonVariable<UnityEngine.TextAsset>(WhitelistSystem, "__0_mp_textAsset_TextAsset");
            Private___1_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(WhitelistSystem, "__1_intnl_returnValSymbol_Boolean");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__3_intnl_SystemInt32");
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__3_intnl_SystemString");
            Private_ignoreCase = new AstroUdonVariable<bool>(WhitelistSystem, "ignoreCase");
            Private__onLists = new AstroUdonVariable<bool[]>(WhitelistSystem, "_onLists");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__2_const_intnl_SystemInt32");
            Private___0_lines_StringArray = new AstroUdonVariable<string[]>(WhitelistSystem, "__0_lines_StringArray");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__7_intnl_SystemInt32");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__1_const_intnl_SystemBoolean");
            Private_LINE_SPLITTER = new AstroUdonVariable<string[]>(WhitelistSystem, "LINE_SPLITTER");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__2_intnl_SystemBoolean");
            Private__localPlayer = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(WhitelistSystem, "_localPlayer");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__2_const_intnl_SystemString");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__0_const_intnl_SystemInt32");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__1_const_intnl_exitJumpLoc_UInt32");
        }

        private void Cleanup_WhitelistSystem()
        {
            Private___0_const_intnl_SystemBoolean = null;
            Private__listNames = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___1_intnl_SystemInt32 = null;
            Private___1_intnl_SystemString = null;
            Private___1_i_Int32 = null;
            Private___0_i_Int32 = null;
            Private___2_i_Int32 = null;
            Private___0_const_intnl_SystemString = null;
            Private___5_intnl_SystemBoolean = null;
            Private___0_intnl_UnityEngineTextAsset = null;
            Private___5_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private__hasStarted = null;
            Private___1_const_intnl_SystemString = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private_whitelists = null;
            Private___1_const_intnl_SystemStringComparison = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemStringSplitOptions = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___1_intnl_SystemBoolean = null;
            Private___2_intnl_SystemInt32 = null;
            Private___2_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___6_intnl_SystemInt32 = null;
            Private___0_intnl_SystemBoolean = null;
            Private___0_stringComparison_StringComparison = null;
            Private___0_mp_listName_String = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___0_intnl_SystemString = null;
            Private___0_mp_playerName_String = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private___0_const_intnl_SystemStringComparison = null;
            Private___0_intnl_SystemBooleanArray = null;
            Private___4_intnl_SystemInt32 = null;
            Private___6_intnl_SystemBoolean = null;
            Private___0_mp_textAsset_TextAsset = null;
            Private___1_intnl_returnValSymbol_Boolean = null;
            Private___3_intnl_SystemInt32 = null;
            Private___3_intnl_SystemString = null;
            Private_ignoreCase = null;
            Private__onLists = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___0_lines_StringArray = null;
            Private___7_intnl_SystemInt32 = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private_LINE_SPLITTER = null;
            Private___2_intnl_SystemBoolean = null;
            Private__localPlayer = null;
            Private___2_const_intnl_SystemString = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
        }

        #region Getter / Setters AstroUdonVariables  of WhitelistSystem

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

        internal string[] _listNames
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__listNames != null)
                {
                    return Private__listNames.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__listNames != null)
                {
                    Private__listNames.Value = value;
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

        internal UnityEngine.TextAsset __0_intnl_UnityEngineTextAsset
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineTextAsset != null)
                {
                    return Private___0_intnl_UnityEngineTextAsset.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineTextAsset != null)
                {
                    Private___0_intnl_UnityEngineTextAsset.Value = value;
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

        internal bool? _hasStarted
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__hasStarted != null)
                {
                    return Private__hasStarted.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private__hasStarted != null)
                    {
                        Private__hasStarted.Value = value.Value;
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

        internal UnityEngine.TextAsset[] whitelists
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_whitelists != null)
                {
                    return Private_whitelists.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_whitelists != null)
                {
                    Private_whitelists.Value = value;
                }
            }
        }

        internal System.StringComparison? __1_const_intnl_SystemStringComparison
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_const_intnl_SystemStringComparison != null)
                {
                    return Private___1_const_intnl_SystemStringComparison.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_const_intnl_SystemStringComparison != null)
                    {
                        Private___1_const_intnl_SystemStringComparison.Value = value.Value;
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

        internal System.StringSplitOptions? __0_const_intnl_SystemStringSplitOptions
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemStringSplitOptions != null)
                {
                    return Private___0_const_intnl_SystemStringSplitOptions.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemStringSplitOptions != null)
                    {
                        Private___0_const_intnl_SystemStringSplitOptions.Value = value.Value;
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

        internal System.StringComparison? __0_stringComparison_StringComparison
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_stringComparison_StringComparison != null)
                {
                    return Private___0_stringComparison_StringComparison.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_stringComparison_StringComparison != null)
                    {
                        Private___0_stringComparison_StringComparison.Value = value.Value;
                    }
                }
            }
        }

        internal string __0_mp_listName_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_listName_String != null)
                {
                    return Private___0_mp_listName_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_listName_String != null)
                {
                    Private___0_mp_listName_String.Value = value;
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

        internal System.StringComparison? __0_const_intnl_SystemStringComparison
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_SystemStringComparison != null)
                {
                    return Private___0_const_intnl_SystemStringComparison.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_SystemStringComparison != null)
                    {
                        Private___0_const_intnl_SystemStringComparison.Value = value.Value;
                    }
                }
            }
        }

        internal bool[] __0_intnl_SystemBooleanArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_SystemBooleanArray != null)
                {
                    return Private___0_intnl_SystemBooleanArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_SystemBooleanArray != null)
                {
                    Private___0_intnl_SystemBooleanArray.Value = value;
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

        internal UnityEngine.TextAsset __0_mp_textAsset_TextAsset
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_textAsset_TextAsset != null)
                {
                    return Private___0_mp_textAsset_TextAsset.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_textAsset_TextAsset != null)
                {
                    Private___0_mp_textAsset_TextAsset.Value = value;
                }
            }
        }

        internal bool? __1_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_returnValSymbol_Boolean != null)
                {
                    return Private___1_intnl_returnValSymbol_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_returnValSymbol_Boolean != null)
                    {
                        Private___1_intnl_returnValSymbol_Boolean.Value = value.Value;
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

        internal bool? ignoreCase
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_ignoreCase != null)
                {
                    return Private_ignoreCase.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_ignoreCase != null)
                    {
                        Private_ignoreCase.Value = value.Value;
                    }
                }
            }
        }

        internal bool[] _onLists
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__onLists != null)
                {
                    return Private__onLists.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__onLists != null)
                {
                    Private__onLists.Value = value;
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

        internal string[] __0_lines_StringArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_lines_StringArray != null)
                {
                    return Private___0_lines_StringArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_lines_StringArray != null)
                {
                    Private___0_lines_StringArray.Value = value;
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

        internal string[] LINE_SPLITTER
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_LINE_SPLITTER != null)
                {
                    return Private_LINE_SPLITTER.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_LINE_SPLITTER != null)
                {
                    Private_LINE_SPLITTER.Value = value;
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

        internal VRC.SDKBase.VRCPlayerApi _localPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__localPlayer != null)
                {
                    return Private__localPlayer.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__localPlayer != null)
                {
                    Private__localPlayer.Value = value;
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

        #endregion Getter / Setters AstroUdonVariables  of WhitelistSystem

        #region AstroUdonVariables  of WhitelistSystem

        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private__listNames { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.TextAsset> Private___0_intnl_UnityEngineTextAsset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private__hasStarted { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.TextAsset[]> Private_whitelists { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.StringComparison> Private___1_const_intnl_SystemStringComparison { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.StringSplitOptions> Private___0_const_intnl_SystemStringSplitOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.StringComparison> Private___0_stringComparison_StringComparison { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_listName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_playerName_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.StringComparison> Private___0_const_intnl_SystemStringComparison { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool[]> Private___0_intnl_SystemBooleanArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.TextAsset> Private___0_mp_textAsset_TextAsset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_ignoreCase { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool[]> Private__onLists { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___0_lines_StringArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private_LINE_SPLITTER { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private__localPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of WhitelistSystem
    }
}