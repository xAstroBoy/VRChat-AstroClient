using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using IntPtr = System.IntPtr;
using Object = Il2CppSystem.Object;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.GeoLocator
{
    [RegisterComponent]
    public class DrinkingNight_NormalPlusReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public DrinkingNight_NormalPlusReader(IntPtr ptr) : base(ptr)
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
                var obj = gameObject.FindUdonEvent("_LoadList");
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
            Private___1_mp_nameSeparator_String = new AstroUdonVariable<string>(WhitelistSystem, "__1_mp_nameSeparator_String");
            Private___0_intnl_VRCSDKBaseVRCPlayerApiArray = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(WhitelistSystem, "__0_intnl_VRCSDKBaseVRCPlayerApiArray");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__3_const_intnl_SystemString");
            Private___3_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__3_const_intnl_exitJumpLoc_UInt32");
            Private___1_mp_doNotSplitNamesWithSpaces_Boolean = new AstroUdonVariable<bool>(WhitelistSystem, "__1_mp_doNotSplitNamesWithSpaces_Boolean");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__0_const_intnl_SystemBoolean");
            Private___0_allPlayers_VRCPlayerApiArray = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(WhitelistSystem, "__0_allPlayers_VRCPlayerApiArray");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__1_const_intnl_SystemInt32");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__1_intnl_SystemInt32");
            Private___1_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__1_intnl_SystemString");
            Private___1_i_Int32 = new AstroUdonVariable<int>(WhitelistSystem, "__1_i_Int32");
            Private___0_i_Int32 = new AstroUdonVariable<int>(WhitelistSystem, "__0_i_Int32");
            Private___2_i_Int32 = new AstroUdonVariable<int>(WhitelistSystem, "__2_i_Int32");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__0_const_intnl_SystemString");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(WhitelistSystem, "__1_intnl_SystemSingle");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__5_intnl_SystemBoolean");
            Private___5_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__5_intnl_SystemInt32");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(WhitelistSystem, "__1_intnl_VRCSDKBaseVRCPlayerApi");
            Private___5_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__5_intnl_SystemString");
            Private___5_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__5_const_intnl_exitJumpLoc_UInt32");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__1_const_intnl_SystemString");
            Private_TAG_COLOUR_START = new AstroUdonVariable<string>(WhitelistSystem, "TAG_COLOUR_START");
            Private___2_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__2_const_intnl_exitJumpLoc_UInt32");
            Private___0_name_String = new AstroUdonVariable<string>(WhitelistSystem, "__0_name_String");
            Private___1_intnl_SystemByte = new AstroUdonVariable<byte>(WhitelistSystem, "__1_intnl_SystemByte");
            Private___7_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__7_const_intnl_exitJumpLoc_UInt32");
            Private___0_intnl_UnityEngineUITextArray = new AstroUdonVariable<UnityEngine.UI.Text[]>(WhitelistSystem, "__0_intnl_UnityEngineUITextArray");
            Private_textColour = new AstroUdonVariable<UnityEngine.Color>(WhitelistSystem, "textColour");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(WhitelistSystem, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__4_intnl_SystemBoolean");
            Private___0_const_intnl_SystemStringSplitOptions = new AstroUdonVariable<System.StringSplitOptions>(WhitelistSystem, "__0_const_intnl_SystemStringSplitOptions");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(WhitelistSystem, "__refl_const_intnl_udonTypeName");
            Private___0_mp_doNotSplitNamesWithSpaces_Boolean = new AstroUdonVariable<bool>(WhitelistSystem, "__0_mp_doNotSplitNamesWithSpaces_Boolean");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__1_intnl_SystemBoolean");
            Private_TAG_SIZE_START = new AstroUdonVariable<string>(WhitelistSystem, "TAG_SIZE_START");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__4_const_intnl_SystemString");
            Private_TAG_BOLD_START = new AstroUdonVariable<string>(WhitelistSystem, "TAG_BOLD_START");
            Private___10_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__10_intnl_SystemString");
            Private_listSize = new AstroUdonVariable<float>(WhitelistSystem, "listSize");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__2_intnl_SystemInt32");
            Private___4_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__4_const_intnl_exitJumpLoc_UInt32");
            Private___2_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__2_intnl_SystemString");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(WhitelistSystem, "__2_intnl_SystemSingle");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__3_intnl_SystemBoolean");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(WhitelistSystem, "__0_intnl_returnValSymbol_Boolean");
            Private___9_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__9_intnl_SystemString");
            Private___6_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__6_const_intnl_exitJumpLoc_UInt32");
            Private_TAG_BOLD_END = new AstroUdonVariable<string>(WhitelistSystem, "TAG_BOLD_END");
            Private___6_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__6_intnl_SystemInt32");
            Private___6_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__6_intnl_SystemString");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__0_intnl_SystemBoolean");
            Private___2_mp_doNotSplitNamesWithSpaces_Boolean = new AstroUdonVariable<bool>(WhitelistSystem, "__2_mp_doNotSplitNamesWithSpaces_Boolean");
            Private___0_intnl_returnValSymbol_VRCPlayerApiArray = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(WhitelistSystem, "__0_intnl_returnValSymbol_VRCPlayerApiArray");
            Private___0_userList_String = new AstroUdonVariable<string>(WhitelistSystem, "__0_userList_String");
            Private___0_intnl_UnityEngineUIText = new AstroUdonVariable<UnityEngine.UI.Text>(WhitelistSystem, "__0_intnl_UnityEngineUIText");
            Private__usernames = new AstroUdonVariable<string[]>(WhitelistSystem, "_usernames");
            Private___8_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__8_const_intnl_exitJumpLoc_UInt32");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__0_intnl_returnTarget_UInt32");
            Private___0_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__0_intnl_SystemString");
            Private___0_mp_c_Color = new AstroUdonVariable<UnityEngine.Color>(WhitelistSystem, "__0_mp_c_Color");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__0_const_intnl_SystemUInt32");
            Private___0_const_intnl_SystemStringComparison = new AstroUdonVariable<System.StringComparison>(WhitelistSystem, "__0_const_intnl_SystemStringComparison");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(WhitelistSystem, "__0_intnl_SystemSingle");
            Private___12_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__12_intnl_SystemString");
            Private___0_mp_f_Single = new AstroUdonVariable<float>(WhitelistSystem, "__0_mp_f_Single");
            Private___0_mp_nameSeparator_String = new AstroUdonVariable<string>(WhitelistSystem, "__0_mp_nameSeparator_String");
            Private___4_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__4_intnl_SystemInt32");
            Private_textMeshes = new AstroUdonVariable<UnityEngine.UI.Text[]>(WhitelistSystem, "textMeshes");
            Private___4_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__4_intnl_SystemString");
            Private_TAG_SIZE_END = new AstroUdonVariable<string>(WhitelistSystem, "TAG_SIZE_END");
            Private___0_players_VRCPlayerApiArray = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]>(WhitelistSystem, "__0_players_VRCPlayerApiArray");
            Private___11_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__11_intnl_SystemString");
            Private___0_intnl_returnValSymbol_Byte = new AstroUdonVariable<byte>(WhitelistSystem, "__0_intnl_returnValSymbol_Byte");
            Private___0_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(WhitelistSystem, "__0_intnl_VRCSDKBaseVRCPlayerApi");
            Private_SPLITTER = new AstroUdonVariable<string[]>(WhitelistSystem, "SPLITTER");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__3_intnl_SystemInt32");
            Private___0_mp_username_String = new AstroUdonVariable<string>(WhitelistSystem, "__0_mp_username_String");
            Private___3_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__3_intnl_SystemString");
            Private___0_intnl_SystemByte = new AstroUdonVariable<byte>(WhitelistSystem, "__0_intnl_SystemByte");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(WhitelistSystem, "__3_intnl_SystemSingle");
            Private_userList = new AstroUdonVariable<UnityEngine.TextAsset>(WhitelistSystem, "userList");
            Private___7_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__7_intnl_SystemInt32");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__1_const_intnl_SystemBoolean");
            Private___0_intnl_UnityEngineColor = new AstroUdonVariable<UnityEngine.Color>(WhitelistSystem, "__0_intnl_UnityEngineColor");
            Private___7_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__7_intnl_SystemString");
            Private___0_mp_index_Int32 = new AstroUdonVariable<int>(WhitelistSystem, "__0_mp_index_Int32");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(WhitelistSystem, "__2_intnl_SystemBoolean");
            Private___0_intnl_returnValSymbol_String = new AstroUdonVariable<string>(WhitelistSystem, "__0_intnl_returnValSymbol_String");
            Private_boldText = new AstroUdonVariable<bool>(WhitelistSystem, "boldText");
            Private___8_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__8_intnl_SystemString");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(WhitelistSystem, "__2_const_intnl_SystemString");
            Private_TAG_COLOUR_END = new AstroUdonVariable<string>(WhitelistSystem, "TAG_COLOUR_END");
            Private___2_intnl_returnValSymbol_String = new AstroUdonVariable<string>(WhitelistSystem, "__2_intnl_returnValSymbol_String");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(WhitelistSystem, "__0_const_intnl_SystemInt32");
            Private___1_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(WhitelistSystem, "__1_const_intnl_exitJumpLoc_UInt32");
            Private___1_intnl_returnValSymbol_String = new AstroUdonVariable<string>(WhitelistSystem, "__1_intnl_returnValSymbol_String");
            Private_onlineColour = new AstroUdonVariable<UnityEngine.Color>(WhitelistSystem, "onlineColour");
        }

        private void Cleanup_WhitelistSystem()
        {
            Private___1_mp_nameSeparator_String = null;
            Private___0_intnl_VRCSDKBaseVRCPlayerApiArray = null;
            Private___3_const_intnl_SystemString = null;
            Private___3_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_mp_doNotSplitNamesWithSpaces_Boolean = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___0_allPlayers_VRCPlayerApiArray = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___1_intnl_SystemInt32 = null;
            Private___1_intnl_SystemString = null;
            Private___1_i_Int32 = null;
            Private___0_i_Int32 = null;
            Private___2_i_Int32 = null;
            Private___0_const_intnl_SystemString = null;
            Private___1_intnl_SystemSingle = null;
            Private___5_intnl_SystemBoolean = null;
            Private___5_intnl_SystemInt32 = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___5_intnl_SystemString = null;
            Private___5_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_const_intnl_SystemString = null;
            Private_TAG_COLOUR_START = null;
            Private___2_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_name_String = null;
            Private___1_intnl_SystemByte = null;
            Private___7_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_intnl_UnityEngineUITextArray = null;
            Private_textColour = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemStringSplitOptions = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private___0_mp_doNotSplitNamesWithSpaces_Boolean = null;
            Private___1_intnl_SystemBoolean = null;
            Private_TAG_SIZE_START = null;
            Private___4_const_intnl_SystemString = null;
            Private_TAG_BOLD_START = null;
            Private___10_intnl_SystemString = null;
            Private_listSize = null;
            Private___2_intnl_SystemInt32 = null;
            Private___4_const_intnl_exitJumpLoc_UInt32 = null;
            Private___2_intnl_SystemString = null;
            Private___2_intnl_SystemSingle = null;
            Private___3_intnl_SystemBoolean = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___9_intnl_SystemString = null;
            Private___6_const_intnl_exitJumpLoc_UInt32 = null;
            Private_TAG_BOLD_END = null;
            Private___6_intnl_SystemInt32 = null;
            Private___6_intnl_SystemString = null;
            Private___0_intnl_SystemBoolean = null;
            Private___2_mp_doNotSplitNamesWithSpaces_Boolean = null;
            Private___0_intnl_returnValSymbol_VRCPlayerApiArray = null;
            Private___0_userList_String = null;
            Private___0_intnl_UnityEngineUIText = null;
            Private__usernames = null;
            Private___8_const_intnl_exitJumpLoc_UInt32 = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___0_intnl_SystemString = null;
            Private___0_mp_c_Color = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private___0_const_intnl_SystemStringComparison = null;
            Private___0_intnl_SystemSingle = null;
            Private___12_intnl_SystemString = null;
            Private___0_mp_f_Single = null;
            Private___0_mp_nameSeparator_String = null;
            Private___4_intnl_SystemInt32 = null;
            Private_textMeshes = null;
            Private___4_intnl_SystemString = null;
            Private_TAG_SIZE_END = null;
            Private___0_players_VRCPlayerApiArray = null;
            Private___11_intnl_SystemString = null;
            Private___0_intnl_returnValSymbol_Byte = null;
            Private___0_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private_SPLITTER = null;
            Private___3_intnl_SystemInt32 = null;
            Private___0_mp_username_String = null;
            Private___3_intnl_SystemString = null;
            Private___0_intnl_SystemByte = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___3_intnl_SystemSingle = null;
            Private_userList = null;
            Private___7_intnl_SystemInt32 = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private___0_intnl_UnityEngineColor = null;
            Private___7_intnl_SystemString = null;
            Private___0_mp_index_Int32 = null;
            Private___2_intnl_SystemBoolean = null;
            Private___0_intnl_returnValSymbol_String = null;
            Private_boldText = null;
            Private___8_intnl_SystemString = null;
            Private___2_const_intnl_SystemString = null;
            Private_TAG_COLOUR_END = null;
            Private___2_intnl_returnValSymbol_String = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___1_const_intnl_exitJumpLoc_UInt32 = null;
            Private___1_intnl_returnValSymbol_String = null;
            Private_onlineColour = null;
        }

        #region Getter / Setters AstroUdonVariables  of WhitelistSystem

        internal string __1_mp_nameSeparator_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_nameSeparator_String != null)
                {
                    return Private___1_mp_nameSeparator_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_mp_nameSeparator_String != null)
                {
                    Private___1_mp_nameSeparator_String.Value = value;
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

        internal bool? __1_mp_doNotSplitNamesWithSpaces_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_mp_doNotSplitNamesWithSpaces_Boolean != null)
                {
                    return Private___1_mp_doNotSplitNamesWithSpaces_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_mp_doNotSplitNamesWithSpaces_Boolean != null)
                    {
                        Private___1_mp_doNotSplitNamesWithSpaces_Boolean.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi[] __0_allPlayers_VRCPlayerApiArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_allPlayers_VRCPlayerApiArray != null)
                {
                    return Private___0_allPlayers_VRCPlayerApiArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_allPlayers_VRCPlayerApiArray != null)
                {
                    Private___0_allPlayers_VRCPlayerApiArray.Value = value;
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

        internal string TAG_COLOUR_START
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_TAG_COLOUR_START != null)
                {
                    return Private_TAG_COLOUR_START.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_TAG_COLOUR_START != null)
                {
                    Private_TAG_COLOUR_START.Value = value;
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

        internal string __0_name_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_name_String != null)
                {
                    return Private___0_name_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_name_String != null)
                {
                    Private___0_name_String.Value = value;
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

        internal UnityEngine.UI.Text[] __0_intnl_UnityEngineUITextArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineUITextArray != null)
                {
                    return Private___0_intnl_UnityEngineUITextArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineUITextArray != null)
                {
                    Private___0_intnl_UnityEngineUITextArray.Value = value;
                }
            }
        }

        internal UnityEngine.Color? textColour
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_textColour != null)
                {
                    return Private_textColour.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_textColour != null)
                    {
                        Private_textColour.Value = value.Value;
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

        internal bool? __0_mp_doNotSplitNamesWithSpaces_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_doNotSplitNamesWithSpaces_Boolean != null)
                {
                    return Private___0_mp_doNotSplitNamesWithSpaces_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_doNotSplitNamesWithSpaces_Boolean != null)
                    {
                        Private___0_mp_doNotSplitNamesWithSpaces_Boolean.Value = value.Value;
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

        internal string TAG_SIZE_START
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_TAG_SIZE_START != null)
                {
                    return Private_TAG_SIZE_START.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_TAG_SIZE_START != null)
                {
                    Private_TAG_SIZE_START.Value = value;
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

        internal string TAG_BOLD_START
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_TAG_BOLD_START != null)
                {
                    return Private_TAG_BOLD_START.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_TAG_BOLD_START != null)
                {
                    Private_TAG_BOLD_START.Value = value;
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

        internal float? listSize
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_listSize != null)
                {
                    return Private_listSize.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_listSize != null)
                    {
                        Private_listSize.Value = value.Value;
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

        internal string TAG_BOLD_END
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_TAG_BOLD_END != null)
                {
                    return Private_TAG_BOLD_END.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_TAG_BOLD_END != null)
                {
                    Private_TAG_BOLD_END.Value = value;
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

        internal bool? __2_mp_doNotSplitNamesWithSpaces_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_mp_doNotSplitNamesWithSpaces_Boolean != null)
                {
                    return Private___2_mp_doNotSplitNamesWithSpaces_Boolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___2_mp_doNotSplitNamesWithSpaces_Boolean != null)
                    {
                        Private___2_mp_doNotSplitNamesWithSpaces_Boolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi[] __0_intnl_returnValSymbol_VRCPlayerApiArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_VRCPlayerApiArray != null)
                {
                    return Private___0_intnl_returnValSymbol_VRCPlayerApiArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_returnValSymbol_VRCPlayerApiArray != null)
                {
                    Private___0_intnl_returnValSymbol_VRCPlayerApiArray.Value = value;
                }
            }
        }

        internal string __0_userList_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_userList_String != null)
                {
                    return Private___0_userList_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_userList_String != null)
                {
                    Private___0_userList_String.Value = value;
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

        internal string[] _usernames
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__usernames != null)
                {
                    return Private__usernames.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private__usernames != null)
                {
                    Private__usernames.Value = value;
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

        internal UnityEngine.Color? __0_mp_c_Color
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_c_Color != null)
                {
                    return Private___0_mp_c_Color.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_c_Color != null)
                    {
                        Private___0_mp_c_Color.Value = value.Value;
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

        internal float? __0_mp_f_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_f_Single != null)
                {
                    return Private___0_mp_f_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_f_Single != null)
                    {
                        Private___0_mp_f_Single.Value = value.Value;
                    }
                }
            }
        }

        internal string __0_mp_nameSeparator_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_nameSeparator_String != null)
                {
                    return Private___0_mp_nameSeparator_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_nameSeparator_String != null)
                {
                    Private___0_mp_nameSeparator_String.Value = value;
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

        internal UnityEngine.UI.Text[] textMeshes
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_textMeshes != null)
                {
                    return Private_textMeshes.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_textMeshes != null)
                {
                    Private_textMeshes.Value = value;
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

        internal string TAG_SIZE_END
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_TAG_SIZE_END != null)
                {
                    return Private_TAG_SIZE_END.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_TAG_SIZE_END != null)
                {
                    Private_TAG_SIZE_END.Value = value;
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

        internal byte? __0_intnl_returnValSymbol_Byte
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_returnValSymbol_Byte != null)
                {
                    return Private___0_intnl_returnValSymbol_Byte.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_returnValSymbol_Byte != null)
                    {
                        Private___0_intnl_returnValSymbol_Byte.Value = value.Value;
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

        internal string[] SPLITTER
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_SPLITTER != null)
                {
                    return Private_SPLITTER.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_SPLITTER != null)
                {
                    Private_SPLITTER.Value = value;
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

        internal string __0_mp_username_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_username_String != null)
                {
                    return Private___0_mp_username_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_mp_username_String != null)
                {
                    Private___0_mp_username_String.Value = value;
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

        internal UnityEngine.TextAsset userList
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_userList != null)
                {
                    return Private_userList.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_userList != null)
                {
                    Private_userList.Value = value;
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

        internal bool? boldText
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_boldText != null)
                {
                    return Private_boldText.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_boldText != null)
                    {
                        Private_boldText.Value = value.Value;
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

        internal string TAG_COLOUR_END
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_TAG_COLOUR_END != null)
                {
                    return Private_TAG_COLOUR_END.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_TAG_COLOUR_END != null)
                {
                    Private_TAG_COLOUR_END.Value = value;
                }
            }
        }

        internal string __2_intnl_returnValSymbol_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_returnValSymbol_String != null)
                {
                    return Private___2_intnl_returnValSymbol_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_returnValSymbol_String != null)
                {
                    Private___2_intnl_returnValSymbol_String.Value = value;
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

        internal string __1_intnl_returnValSymbol_String
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_returnValSymbol_String != null)
                {
                    return Private___1_intnl_returnValSymbol_String.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_returnValSymbol_String != null)
                {
                    Private___1_intnl_returnValSymbol_String.Value = value;
                }
            }
        }

        internal UnityEngine.Color? onlineColour
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_onlineColour != null)
                {
                    return Private_onlineColour.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_onlineColour != null)
                    {
                        Private_onlineColour.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of WhitelistSystem

        #region AstroUdonVariables  of WhitelistSystem

        private AstroUdonVariable<string> Private___1_mp_nameSeparator_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private___0_intnl_VRCSDKBaseVRCPlayerApiArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___3_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_mp_doNotSplitNamesWithSpaces_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private___0_allPlayers_VRCPlayerApiArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_i_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___5_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___5_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_TAG_COLOUR_START { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___2_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_name_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___1_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___7_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text[]> Private___0_intnl_UnityEngineUITextArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_textColour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.StringSplitOptions> Private___0_const_intnl_SystemStringSplitOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_mp_doNotSplitNamesWithSpaces_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_TAG_SIZE_START { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_TAG_BOLD_START { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___10_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_listSize { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___4_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___9_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___6_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_TAG_BOLD_END { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___6_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_mp_doNotSplitNamesWithSpaces_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private___0_intnl_returnValSymbol_VRCPlayerApiArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_userList_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text> Private___0_intnl_UnityEngineUIText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private__usernames { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___8_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___0_mp_c_Color { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.StringComparison> Private___0_const_intnl_SystemStringComparison { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___12_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_f_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_nameSeparator_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___4_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.UI.Text[]> Private_textMeshes { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_TAG_SIZE_END { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi[]> Private___0_players_VRCPlayerApiArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___11_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_intnl_returnValSymbol_Byte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private_SPLITTER { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_mp_username_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<byte> Private___0_intnl_SystemByte { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.TextAsset> Private_userList { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___7_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private___0_intnl_UnityEngineColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_index_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_intnl_returnValSymbol_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private_boldText { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_TAG_COLOUR_END { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_intnl_returnValSymbol_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___1_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_intnl_returnValSymbol_String { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Color> Private_onlineColour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion AstroUdonVariables  of WhitelistSystem

    }
}