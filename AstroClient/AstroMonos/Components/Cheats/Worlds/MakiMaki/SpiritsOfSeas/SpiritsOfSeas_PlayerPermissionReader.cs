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

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.MakiMaki.SpiritsOfSeas
{
    using IntPtr = System.IntPtr;

    [RegisterComponent]
    public class SpiritsOfSeas_PlayerPermissionReader : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SpiritsOfSeas_PlayerPermissionReader(IntPtr ptr) : base(ptr)
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
            if (WorldUtils.WorldID.Equals(WorldIds.SpiritsOfTheSea))
            {
                var obj = gameObject.FindUdonEvent("_GetAuthTier");
                if (obj != null)
                {
                    PermissionManager = obj.RawItem;
                    Initialize_PermissionManager();
                    HasSubscribed = true;
                    ForceHightTier();
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
            __0__GetAuthTier__ret = int.MaxValue;
            __0___0_IsNameMatch__ret = true;
        }

        private void Initialize_PermissionManager()
        {
            Private___intnl_SystemString_1 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_1");
            Private___const_SystemString_0 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_0");
            Private___intnl_SystemString_9 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_9");
            Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(PermissionManager, "__gintnl_SystemUInt32_4");
            Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(PermissionManager, "__gintnl_SystemUInt32_1");
            Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(PermissionManager, "__gintnl_SystemUInt32_0");
            Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(PermissionManager, "__gintnl_SystemUInt32_3");
            Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(PermissionManager, "__gintnl_SystemUInt32_2");
            Private___const_SystemString_5 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_5");
            Private___gintnl_SystemCharArray_1 = new AstroUdonVariable<char[]>(PermissionManager, "__gintnl_SystemCharArray_1");
            Private___lcl_line_SystemString_0 = new AstroUdonVariable<string>(PermissionManager, "__lcl_line_SystemString_0");
            Private___intnl_SystemString_6 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_6");
            Private___const_SystemString_10 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_10");
            Private___const_SystemString_11 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_11");
            Private___intnl_VRCSDKBaseVRCPlayerApi_0 = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(PermissionManager, "__intnl_VRCSDKBaseVRCPlayerApi_0");
            Private___refl_typeid = new AstroUdonVariable<long>(PermissionManager, "__refl_typeid");
            Private___lcl_t3Index_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t3Index_SystemInt32_0");
            Private___intnl_SystemStringArray_12 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_12");
            Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(PermissionManager, "__const_SystemUInt32_0");
            Private__authTier = new AstroUdonVariable<int>(PermissionManager, "_authTier");
            Private___lcl_t2Count_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t2Count_SystemInt32_0");
            Private___lcl_t5Index_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t5Index_SystemInt32_0");
            Private___lcl_lineArr_SystemStringArray_0 = new AstroUdonVariable<string[]>(PermissionManager, "__lcl_lineArr_SystemStringArray_0");
            Private___intnl_SystemString_3 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_3");
            Private__authPlayers = new AstroUdonVariable<System.Object[]>(PermissionManager, "_authPlayers");
            Private___lcl_patreons_SystemStringArray_0 = new AstroUdonVariable<string[]>(PermissionManager, "__lcl_patreons_SystemStringArray_0");
            Private___const_SystemString_2 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_2");
            Private_eventName = new AstroUdonVariable<string>(PermissionManager, "eventName");
            Private___0___0_IsNameMatch__ret = new AstroUdonVariable<bool>(PermissionManager, "__0___0_IsNameMatch__ret");
            Private___0_name1__param = new AstroUdonVariable<string>(PermissionManager, "__0_name1__param");
            Private___0_name2__param = new AstroUdonVariable<string>(PermissionManager, "__0_name2__param");
            Private_targetBehaviour = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PermissionManager, "targetBehaviour");
            Private___intnl_SystemString_0 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_0");
            Private___const_SystemChar_1 = new AstroUdonVariable<char>(PermissionManager, "__const_SystemChar_1");
            Private___const_SystemString_7 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_7");
            Private___intnl_SystemString_8 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_8");
            Private___lcl_t1Count_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t1Count_SystemInt32_0");
            Private___lcl_t4Count_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t4Count_SystemInt32_0");
            Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(PermissionManager, "__intnl_returnJump_SystemUInt32_0");
            Private___0__GetAuthTier__ret = new AstroUdonVariable<int>(PermissionManager, "__0__GetAuthTier__ret");
            Private___const_SystemString_4 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_4");
            Private___intnl_SystemString_5 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_5");
            Private___intnl_SystemStringArray_9 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_9");
            Private___intnl_SystemStringArray_8 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_8");
            Private___intnl_SystemStringArray_3 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_3");
            Private___intnl_SystemStringArray_2 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_2");
            Private___intnl_SystemStringArray_1 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_1");
            Private___intnl_SystemStringArray_0 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_0");
            Private___intnl_SystemStringArray_7 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_7");
            Private___intnl_SystemStringArray_6 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_6");
            Private___intnl_SystemStringArray_5 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_5");
            Private___intnl_SystemStringArray_4 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_4");
            Private___const_SystemString_9 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_9");
            Private___intnl_SystemStringArray_11 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_11");
            Private___refl_typename = new AstroUdonVariable<string>(PermissionManager, "__refl_typename");
            Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(PermissionManager, "__intnl_SystemInt32_1");
            Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__intnl_SystemInt32_0");
            Private___intnl_SystemString_2 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_2");
            Private___lcl_t3Count_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t3Count_SystemInt32_0");
            Private___const_SystemString_1 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_1");
            Private___lcl_t2Index_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t2Index_SystemInt32_0");
            Private___intnl_SystemString_12 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_12");
            Private___intnl_SystemString_13 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_13");
            Private___lcl_localPlayer_SystemString_0 = new AstroUdonVariable<string>(PermissionManager, "__lcl_localPlayer_SystemString_0");
            Private___lcl_t4Index_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t4Index_SystemInt32_0");
            Private___const_SystemChar_0 = new AstroUdonVariable<char>(PermissionManager, "__const_SystemChar_0");
            Private___const_SystemString_6 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_6");
            Private___gintnl_SystemCharArray_0 = new AstroUdonVariable<char[]>(PermissionManager, "__gintnl_SystemCharArray_0");
            Private___intnl_SystemString_7 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_7");
            Private___lcl_t1Index_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t1Index_SystemInt32_0");
            Private___0_players__param = new AstroUdonVariable<string>(PermissionManager, "__0_players__param");
            Private___const_SystemInt32_1 = new AstroUdonVariable<int>(PermissionManager, "__const_SystemInt32_1");
            Private___const_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__const_SystemInt32_0");
            Private___const_SystemInt32_3 = new AstroUdonVariable<int>(PermissionManager, "__const_SystemInt32_3");
            Private___const_SystemInt32_2 = new AstroUdonVariable<int>(PermissionManager, "__const_SystemInt32_2");
            Private___const_SystemInt32_5 = new AstroUdonVariable<int>(PermissionManager, "__const_SystemInt32_5");
            Private___const_SystemInt32_4 = new AstroUdonVariable<int>(PermissionManager, "__const_SystemInt32_4");
            Private___lcl_t5Count_SystemInt32_0 = new AstroUdonVariable<int>(PermissionManager, "__lcl_t5Count_SystemInt32_0");
            Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(PermissionManager, "__intnl_SystemBoolean_0");
            Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(PermissionManager, "__intnl_SystemBoolean_1");
            Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(PermissionManager, "__intnl_SystemBoolean_2");
            Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(PermissionManager, "__intnl_SystemBoolean_3");
            Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(PermissionManager, "__intnl_SystemBoolean_4");
            Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(PermissionManager, "__intnl_SystemBoolean_5");
            Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(PermissionManager, "__intnl_SystemBoolean_6");
            Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(PermissionManager, "__intnl_SystemBoolean_7");
            Private___intnl_SystemString_4 = new AstroUdonVariable<string>(PermissionManager, "__intnl_SystemString_4");
            Private___const_SystemString_3 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_3");
            Private___const_SystemString_8 = new AstroUdonVariable<string>(PermissionManager, "__const_SystemString_8");
            Private___intnl_SystemStringArray_10 = new AstroUdonVariable<string[]>(PermissionManager, "__intnl_SystemStringArray_10");
        }

        private void Cleanup_PermissionManager()
        {
            Private___intnl_SystemString_1 = null;
            Private___const_SystemString_0 = null;
            Private___intnl_SystemString_9 = null;
            Private___gintnl_SystemUInt32_4 = null;
            Private___gintnl_SystemUInt32_1 = null;
            Private___gintnl_SystemUInt32_0 = null;
            Private___gintnl_SystemUInt32_3 = null;
            Private___gintnl_SystemUInt32_2 = null;
            Private___const_SystemString_5 = null;
            Private___gintnl_SystemCharArray_1 = null;
            Private___lcl_line_SystemString_0 = null;
            Private___intnl_SystemString_6 = null;
            Private___const_SystemString_10 = null;
            Private___const_SystemString_11 = null;
            Private___intnl_VRCSDKBaseVRCPlayerApi_0 = null;
            Private___refl_typeid = null;
            Private___lcl_t3Index_SystemInt32_0 = null;
            Private___intnl_SystemStringArray_12 = null;
            Private___const_SystemUInt32_0 = null;
            Private__authTier = null;
            Private___lcl_t2Count_SystemInt32_0 = null;
            Private___lcl_t5Index_SystemInt32_0 = null;
            Private___lcl_lineArr_SystemStringArray_0 = null;
            Private___intnl_SystemString_3 = null;
            Private__authPlayers = null;
            Private___lcl_patreons_SystemStringArray_0 = null;
            Private___const_SystemString_2 = null;
            Private_eventName = null;
            Private___0___0_IsNameMatch__ret = null;
            Private___0_name1__param = null;
            Private___0_name2__param = null;
            Private_targetBehaviour = null;
            Private___intnl_SystemString_0 = null;
            Private___const_SystemChar_1 = null;
            Private___const_SystemString_7 = null;
            Private___intnl_SystemString_8 = null;
            Private___lcl_t1Count_SystemInt32_0 = null;
            Private___lcl_t4Count_SystemInt32_0 = null;
            Private___intnl_returnJump_SystemUInt32_0 = null;
            Private___0__GetAuthTier__ret = null;
            Private___const_SystemString_4 = null;
            Private___intnl_SystemString_5 = null;
            Private___intnl_SystemStringArray_9 = null;
            Private___intnl_SystemStringArray_8 = null;
            Private___intnl_SystemStringArray_3 = null;
            Private___intnl_SystemStringArray_2 = null;
            Private___intnl_SystemStringArray_1 = null;
            Private___intnl_SystemStringArray_0 = null;
            Private___intnl_SystemStringArray_7 = null;
            Private___intnl_SystemStringArray_6 = null;
            Private___intnl_SystemStringArray_5 = null;
            Private___intnl_SystemStringArray_4 = null;
            Private___const_SystemString_9 = null;
            Private___intnl_SystemStringArray_11 = null;
            Private___refl_typename = null;
            Private___intnl_SystemInt32_1 = null;
            Private___intnl_SystemInt32_0 = null;
            Private___intnl_SystemString_2 = null;
            Private___lcl_t3Count_SystemInt32_0 = null;
            Private___const_SystemString_1 = null;
            Private___lcl_t2Index_SystemInt32_0 = null;
            Private___intnl_SystemString_12 = null;
            Private___intnl_SystemString_13 = null;
            Private___lcl_localPlayer_SystemString_0 = null;
            Private___lcl_t4Index_SystemInt32_0 = null;
            Private___const_SystemChar_0 = null;
            Private___const_SystemString_6 = null;
            Private___gintnl_SystemCharArray_0 = null;
            Private___intnl_SystemString_7 = null;
            Private___lcl_t1Index_SystemInt32_0 = null;
            Private___0_players__param = null;
            Private___const_SystemInt32_1 = null;
            Private___const_SystemInt32_0 = null;
            Private___const_SystemInt32_3 = null;
            Private___const_SystemInt32_2 = null;
            Private___const_SystemInt32_5 = null;
            Private___const_SystemInt32_4 = null;
            Private___lcl_t5Count_SystemInt32_0 = null;
            Private___intnl_SystemBoolean_0 = null;
            Private___intnl_SystemBoolean_1 = null;
            Private___intnl_SystemBoolean_2 = null;
            Private___intnl_SystemBoolean_3 = null;
            Private___intnl_SystemBoolean_4 = null;
            Private___intnl_SystemBoolean_5 = null;
            Private___intnl_SystemBoolean_6 = null;
            Private___intnl_SystemBoolean_7 = null;
            Private___intnl_SystemString_4 = null;
            Private___const_SystemString_3 = null;
            Private___const_SystemString_8 = null;
            Private___intnl_SystemStringArray_10 = null;
        }

        #region Getter / Setters AstroUdonVariables  of PermissionManager

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

        internal char[] __gintnl_SystemCharArray_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemCharArray_1 != null)
                {
                    return Private___gintnl_SystemCharArray_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemCharArray_1 != null)
                {
                    Private___gintnl_SystemCharArray_1.Value = value;
                }
            }
        }

        internal string __lcl_line_SystemString_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_line_SystemString_0 != null)
                {
                    return Private___lcl_line_SystemString_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_line_SystemString_0 != null)
                {
                    Private___lcl_line_SystemString_0.Value = value;
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

        internal int? __lcl_t3Index_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t3Index_SystemInt32_0 != null)
                {
                    return Private___lcl_t3Index_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t3Index_SystemInt32_0 != null)
                    {
                        Private___lcl_t3Index_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal string[] __intnl_SystemStringArray_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_12 != null)
                {
                    return Private___intnl_SystemStringArray_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_12 != null)
                {
                    Private___intnl_SystemStringArray_12.Value = value;
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

        internal int? __lcl_t2Count_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t2Count_SystemInt32_0 != null)
                {
                    return Private___lcl_t2Count_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t2Count_SystemInt32_0 != null)
                    {
                        Private___lcl_t2Count_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_t5Index_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t5Index_SystemInt32_0 != null)
                {
                    return Private___lcl_t5Index_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t5Index_SystemInt32_0 != null)
                    {
                        Private___lcl_t5Index_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal string[] __lcl_lineArr_SystemStringArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_lineArr_SystemStringArray_0 != null)
                {
                    return Private___lcl_lineArr_SystemStringArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_lineArr_SystemStringArray_0 != null)
                {
                    Private___lcl_lineArr_SystemStringArray_0.Value = value;
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

        internal string[] __lcl_patreons_SystemStringArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_patreons_SystemStringArray_0 != null)
                {
                    return Private___lcl_patreons_SystemStringArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_patreons_SystemStringArray_0 != null)
                {
                    Private___lcl_patreons_SystemStringArray_0.Value = value;
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

        internal bool? __0___0_IsNameMatch__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_IsNameMatch__ret != null)
                {
                    return Private___0___0_IsNameMatch__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_IsNameMatch__ret != null)
                    {
                        Private___0___0_IsNameMatch__ret.Value = value.Value;
                    }
                }
            }
        }

        internal string __0_name1__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_name1__param != null)
                {
                    return Private___0_name1__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_name1__param != null)
                {
                    Private___0_name1__param.Value = value;
                }
            }
        }

        internal string __0_name2__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_name2__param != null)
                {
                    return Private___0_name2__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_name2__param != null)
                {
                    Private___0_name2__param.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour targetBehaviour
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_targetBehaviour != null)
                {
                    return Private_targetBehaviour.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_targetBehaviour != null)
                {
                    Private_targetBehaviour.Value = value;
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

        internal char? __const_SystemChar_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemChar_1 != null)
                {
                    return Private___const_SystemChar_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemChar_1 != null)
                    {
                        Private___const_SystemChar_1.Value = value.Value;
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

        internal int? __lcl_t1Count_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t1Count_SystemInt32_0 != null)
                {
                    return Private___lcl_t1Count_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t1Count_SystemInt32_0 != null)
                    {
                        Private___lcl_t1Count_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal int? __lcl_t4Count_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t4Count_SystemInt32_0 != null)
                {
                    return Private___lcl_t4Count_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t4Count_SystemInt32_0 != null)
                    {
                        Private___lcl_t4Count_SystemInt32_0.Value = value.Value;
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

        internal int? __0__GetAuthTier__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0__GetAuthTier__ret != null)
                {
                    return Private___0__GetAuthTier__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0__GetAuthTier__ret != null)
                    {
                        Private___0__GetAuthTier__ret.Value = value.Value;
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

        internal string[] __intnl_SystemStringArray_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_9 != null)
                {
                    return Private___intnl_SystemStringArray_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_9 != null)
                {
                    Private___intnl_SystemStringArray_9.Value = value;
                }
            }
        }

        internal string[] __intnl_SystemStringArray_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_8 != null)
                {
                    return Private___intnl_SystemStringArray_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_8 != null)
                {
                    Private___intnl_SystemStringArray_8.Value = value;
                }
            }
        }

        internal string[] __intnl_SystemStringArray_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_3 != null)
                {
                    return Private___intnl_SystemStringArray_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_3 != null)
                {
                    Private___intnl_SystemStringArray_3.Value = value;
                }
            }
        }

        internal string[] __intnl_SystemStringArray_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_2 != null)
                {
                    return Private___intnl_SystemStringArray_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_2 != null)
                {
                    Private___intnl_SystemStringArray_2.Value = value;
                }
            }
        }

        internal string[] __intnl_SystemStringArray_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_1 != null)
                {
                    return Private___intnl_SystemStringArray_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_1 != null)
                {
                    Private___intnl_SystemStringArray_1.Value = value;
                }
            }
        }

        internal string[] __intnl_SystemStringArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_0 != null)
                {
                    return Private___intnl_SystemStringArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_0 != null)
                {
                    Private___intnl_SystemStringArray_0.Value = value;
                }
            }
        }

        internal string[] __intnl_SystemStringArray_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_7 != null)
                {
                    return Private___intnl_SystemStringArray_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_7 != null)
                {
                    Private___intnl_SystemStringArray_7.Value = value;
                }
            }
        }

        internal string[] __intnl_SystemStringArray_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_6 != null)
                {
                    return Private___intnl_SystemStringArray_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_6 != null)
                {
                    Private___intnl_SystemStringArray_6.Value = value;
                }
            }
        }

        internal string[] __intnl_SystemStringArray_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_5 != null)
                {
                    return Private___intnl_SystemStringArray_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_5 != null)
                {
                    Private___intnl_SystemStringArray_5.Value = value;
                }
            }
        }

        internal string[] __intnl_SystemStringArray_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_4 != null)
                {
                    return Private___intnl_SystemStringArray_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_4 != null)
                {
                    Private___intnl_SystemStringArray_4.Value = value;
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

        internal string[] __intnl_SystemStringArray_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_11 != null)
                {
                    return Private___intnl_SystemStringArray_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_11 != null)
                {
                    Private___intnl_SystemStringArray_11.Value = value;
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

        internal int? __lcl_t3Count_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t3Count_SystemInt32_0 != null)
                {
                    return Private___lcl_t3Count_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t3Count_SystemInt32_0 != null)
                    {
                        Private___lcl_t3Count_SystemInt32_0.Value = value.Value;
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

        internal int? __lcl_t2Index_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t2Index_SystemInt32_0 != null)
                {
                    return Private___lcl_t2Index_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t2Index_SystemInt32_0 != null)
                    {
                        Private___lcl_t2Index_SystemInt32_0.Value = value.Value;
                    }
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

        internal string __lcl_localPlayer_SystemString_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_localPlayer_SystemString_0 != null)
                {
                    return Private___lcl_localPlayer_SystemString_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_localPlayer_SystemString_0 != null)
                {
                    Private___lcl_localPlayer_SystemString_0.Value = value;
                }
            }
        }

        internal int? __lcl_t4Index_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t4Index_SystemInt32_0 != null)
                {
                    return Private___lcl_t4Index_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t4Index_SystemInt32_0 != null)
                    {
                        Private___lcl_t4Index_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal char? __const_SystemChar_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemChar_0 != null)
                {
                    return Private___const_SystemChar_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemChar_0 != null)
                    {
                        Private___const_SystemChar_0.Value = value.Value;
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

        internal char[] __gintnl_SystemCharArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemCharArray_0 != null)
                {
                    return Private___gintnl_SystemCharArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemCharArray_0 != null)
                {
                    Private___gintnl_SystemCharArray_0.Value = value;
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

        internal int? __lcl_t1Index_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t1Index_SystemInt32_0 != null)
                {
                    return Private___lcl_t1Index_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t1Index_SystemInt32_0 != null)
                    {
                        Private___lcl_t1Index_SystemInt32_0.Value = value.Value;
                    }
                }
            }
        }

        internal string __0_players__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_players__param != null)
                {
                    return Private___0_players__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_players__param != null)
                {
                    Private___0_players__param.Value = value;
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

        internal int? __lcl_t5Count_SystemInt32_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_t5Count_SystemInt32_0 != null)
                {
                    return Private___lcl_t5Count_SystemInt32_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_t5Count_SystemInt32_0 != null)
                    {
                        Private___lcl_t5Count_SystemInt32_0.Value = value.Value;
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

        internal string[] __intnl_SystemStringArray_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemStringArray_10 != null)
                {
                    return Private___intnl_SystemStringArray_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_SystemStringArray_10 != null)
                {
                    Private___intnl_SystemStringArray_10.Value = value;
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of PermissionManager

        #region AstroUdonVariables  of PermissionManager

        private AstroUdonVariable<string> Private___intnl_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___lcl_line_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___intnl_VRCSDKBaseVRCPlayerApi_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t3Index_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private__authTier { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t2Count_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t5Index_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___lcl_lineArr_SystemStringArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<System.Object[]> Private__authPlayers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___lcl_patreons_SystemStringArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private_eventName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0___0_IsNameMatch__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_name1__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_name2__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_targetBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___const_SystemChar_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t1Count_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t4Count_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0__GetAuthTier__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___intnl_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t3Count_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t2Index_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___lcl_localPlayer_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t4Index_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char> Private___const_SystemChar_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<char[]> Private___gintnl_SystemCharArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t1Index_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_players__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___const_SystemInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___lcl_t5Count_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___intnl_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string[]> Private___intnl_SystemStringArray_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of PermissionManager
    }
}