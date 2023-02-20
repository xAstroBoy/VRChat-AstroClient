using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.WorldModifications.WorldsIds;
using AstroClient.xAstroBoy.Utility;
using Il2CppSystem.Collections.Generic;
using System;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using Object = Il2CppSystem.Object;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PoolParlor
{
    [RegisterComponent]
    public class PoolParlor_NetworkingManagerReader_One : MonoBehaviour
    {
        //Behaviour NetworkingManager EventKeys
        //Event Key : __0__Init
        //Event Key : __0__AuthorizeUsers
        //Event Key : _AuthorizeAll
        //Event Key : _onOwnershipRequest
        //Event Key : _onOwnershipTransferred
        //

        private List<Object> AntiGarbageCollection = new();

        public PoolParlor_NetworkingManagerReader_One(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal bool ForceGuidelineOn { get; set; } = false;

        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PoolParlor))
            {
                var one = gameObject.FindUdonEvent("__0__AuthorizeUsers");
                if (one != null)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                    NetworkingManager = one.UdonBehaviour.ToRawUdonBehaviour();
                    Initialize_NetworkingManager();
                    Two = NetworkingManager.udonBehaviour.GetOrAddComponent<PoolParlor_NetworkingManagerReader_Two>();
                }
                else
                {
                    Log.Error("Can't Find Networking Manager 1 behaviour, Unable to Add Reader Component, did the author update the world?");
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
            Cleanup_NetworkingManager();
            ClientEventActions.OnRoomLeft -= OnRoomLeft;
        }

        private RawUdonBehaviour NetworkingManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        internal PoolParlor_NetworkingManagerReader_Two Two { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } = null;

        private void Initialize_NetworkingManager()
        {
            Private___const_SystemInt64_0 = new AstroUdonVariable<long>(NetworkingManager, "__const_SystemInt64_0");
            Private___gintnl_SystemObjectArray_1 = new AstroUdonVariable<System.Object[]>(NetworkingManager, "__gintnl_SystemObjectArray_1");
            Private___const_SystemString_0 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_0");
            Private___intnl_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(NetworkingManager, "__intnl_UnityEngineTransform_0");
            Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_4");
            Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_1");
            Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_0");
            Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_3");
            Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(NetworkingManager, "__gintnl_SystemUInt32_2");
            Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(NetworkingManager, "__const_SystemBoolean_0");
            Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(NetworkingManager, "__const_SystemBoolean_1");
            Private___const_SystemString_5 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_5");
            Private_metaverse = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "metaverse");
            Private___const_SystemString_16 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_16");
            Private___const_SystemString_17 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_17");
            Private___const_SystemString_14 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_14");
            Private___const_SystemString_15 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_15");
            Private___const_SystemString_12 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_12");
            Private___const_SystemString_13 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_13");
            Private___const_SystemString_10 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_10");
            Private___const_SystemString_11 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_11");
            Private___const_SystemString_18 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_18");
            Private___const_SystemString_19 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_19");
            Private___refl_typeid = new AstroUdonVariable<long>(NetworkingManager, "__refl_typeid");
            Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__const_SystemUInt32_0");
            Private___intnl_UnityEngineComponent_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__intnl_UnityEngineComponent_0");
            Private___gintnl_SystemObjectArray_3 = new AstroUdonVariable<System.Object[]>(NetworkingManager, "__gintnl_SystemObjectArray_3");
            Private___0__intnlparam = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__0__intnlparam");
            Private___0_allUsersOffline__ret = new AstroUdonVariable<bool>(NetworkingManager, "__0_allUsersOffline__ret");
            Private___0_table___param = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__0_table___param");
            Private___0_moduleType___param = new AstroUdonVariable<string>(NetworkingManager, "__0_moduleType___param");
            Private___const_SystemString_2 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_2");
            Private___intnl_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(NetworkingManager, "__intnl_UnityEngineGameObject_0");
            Private___intnl_UnityEngineComponentArray_0 = new AstroUdonVariable<UnityEngine.Component[]>(NetworkingManager, "__intnl_UnityEngineComponentArray_0");
            Private___const_SystemString_7 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_7");
            Private___intnl_SystemInt64_0 = new AstroUdonVariable<long>(NetworkingManager, "__intnl_SystemInt64_0");
            Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(NetworkingManager, "__intnl_returnJump_SystemUInt32_0");
            Private___const_SystemString_4 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_4");
            Private_moduleType = new AstroUdonVariable<string>(NetworkingManager, "moduleType");
            Private___lcl_i_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__lcl_i_SystemInt32_0");
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "__lcl_behaviour_VRCUdonUdonBehaviour_0");
            Private___1__intnlparam = new AstroUdonVariable<UnityEngine.Transform>(NetworkingManager, "__1__intnlparam");
            Private___const_SystemString_9 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_9");
            Private_table = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(NetworkingManager, "table");
            Private___refl_typename = new AstroUdonVariable<string>(NetworkingManager, "__refl_typename");
            Private___gintnl_SystemObjectArray_0 = new AstroUdonVariable<System.Object[]>(NetworkingManager, "__gintnl_SystemObjectArray_0");
            Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_1");
            Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_0");
            Private___intnl_SystemInt32_3 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_3");
            Private___intnl_SystemInt32_2 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_2");
            Private___intnl_SystemInt32_5 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_5");
            Private___intnl_SystemInt32_4 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_4");
            Private___intnl_SystemInt32_7 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_7");
            Private___intnl_SystemInt32_6 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_6");
            Private___intnl_SystemInt32_9 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_9");
            Private___intnl_SystemInt32_8 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_8");
            Private___lcl_targetID_SystemInt64_0 = new AstroUdonVariable<long>(NetworkingManager, "__lcl_targetID_SystemInt64_0");
            Private___const_SystemString_1 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_1");
            Private___lcl_idValue_SystemObject_0 = new AstroUdonVariable<long>(NetworkingManager, "__lcl_idValue_SystemObject_0");
            Private___const_SystemString_6 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_6");
            Private___0___0_isAuthorizedUser__ret = new AstroUdonVariable<bool>(NetworkingManager, "__0___0_isAuthorizedUser__ret");
            Private___intnl_SystemInt32_10 = new AstroUdonVariable<int>(NetworkingManager, "__intnl_SystemInt32_10");
            Private___const_SystemString_22 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_22");
            Private___const_SystemString_20 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_20");
            Private___const_SystemString_21 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_21");
            Private___const_SystemInt32_1 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_1");
            Private___const_SystemInt32_0 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_0");
            Private___const_SystemInt32_3 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_3");
            Private___const_SystemInt32_2 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_2");
            Private___const_SystemInt32_5 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_5");
            Private___const_SystemInt32_4 = new AstroUdonVariable<int>(NetworkingManager, "__const_SystemInt32_4");
            Private___gintnl_SystemObjectArray_2 = new AstroUdonVariable<System.Object[]>(NetworkingManager, "__gintnl_SystemObjectArray_2");
            Private___lcl_udonBehaviours_UnityEngineComponentArray_0 = new AstroUdonVariable<UnityEngine.Component[]>(NetworkingManager, "__lcl_udonBehaviours_UnityEngineComponentArray_0");
            Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_8");
            Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_9");
            Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_0");
            Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_1");
            Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_2");
            Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_3");
            Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_4");
            Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_5");
            Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_6");
            Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(NetworkingManager, "__intnl_SystemBoolean_7");
            Private___const_SystemString_3 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_3");
            Private___0__onOwnershipRequest__ret = new AstroUdonVariable<bool>(NetworkingManager, "__0__onOwnershipRequest__ret");
            Private___const_SystemString_8 = new AstroUdonVariable<string>(NetworkingManager, "__const_SystemString_8");
        }

        private void Cleanup_NetworkingManager()
        {
            Private___const_SystemInt64_0 = null;
            Private___gintnl_SystemObjectArray_1 = null;
            Private___const_SystemString_0 = null;
            Private___intnl_UnityEngineTransform_0 = null;
            Private___gintnl_SystemUInt32_4 = null;
            Private___gintnl_SystemUInt32_1 = null;
            Private___gintnl_SystemUInt32_0 = null;
            Private___gintnl_SystemUInt32_3 = null;
            Private___gintnl_SystemUInt32_2 = null;
            Private___const_SystemBoolean_0 = null;
            Private___const_SystemBoolean_1 = null;
            Private___const_SystemString_5 = null;
            Private_metaverse = null;
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
            Private___refl_typeid = null;
            Private___const_SystemUInt32_0 = null;
            Private___intnl_UnityEngineComponent_0 = null;
            Private___gintnl_SystemObjectArray_3 = null;
            Private___0__intnlparam = null;
            Private___0_allUsersOffline__ret = null;
            Private___0_table___param = null;
            Private___0_moduleType___param = null;
            Private___const_SystemString_2 = null;
            Private___intnl_UnityEngineGameObject_0 = null;
            Private___intnl_UnityEngineComponentArray_0 = null;
            Private___const_SystemString_7 = null;
            Private___intnl_SystemInt64_0 = null;
            Private___intnl_returnJump_SystemUInt32_0 = null;
            Private___const_SystemString_4 = null;
            Private_moduleType = null;
            Private___lcl_i_SystemInt32_0 = null;
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = null;
            Private___1__intnlparam = null;
            Private___const_SystemString_9 = null;
            Private_table = null;
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
            Private___lcl_targetID_SystemInt64_0 = null;
            Private___const_SystemString_1 = null;
            Private___lcl_idValue_SystemObject_0 = null;
            Private___const_SystemString_6 = null;
            Private___0___0_isAuthorizedUser__ret = null;
            Private___intnl_SystemInt32_10 = null;
            Private___const_SystemString_22 = null;
            Private___const_SystemString_20 = null;
            Private___const_SystemString_21 = null;
            Private___const_SystemInt32_1 = null;
            Private___const_SystemInt32_0 = null;
            Private___const_SystemInt32_3 = null;
            Private___const_SystemInt32_2 = null;
            Private___const_SystemInt32_5 = null;
            Private___const_SystemInt32_4 = null;
            Private___gintnl_SystemObjectArray_2 = null;
            Private___lcl_udonBehaviours_UnityEngineComponentArray_0 = null;
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
            Private___const_SystemString_3 = null;
            Private___0__onOwnershipRequest__ret = null;
            Private___const_SystemString_8 = null;
        }

        #region Getter / Setters AstroUdonVariables  of NetworkingManager

        internal long? __const_SystemInt64_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt64_0 != null)
                {
                    return Private___const_SystemInt64_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt64_0 != null)
                    {
                        Private___const_SystemInt64_0.Value = value.Value;
                    }
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

        internal VRC.Udon.UdonBehaviour metaverse
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_metaverse != null)
                {
                    return Private_metaverse.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_metaverse != null)
                {
                    Private_metaverse.Value = value;
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

        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineComponent_0
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

        internal System.Object[] __gintnl_SystemObjectArray_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemObjectArray_3 != null)
                {
                    return Private___gintnl_SystemObjectArray_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemObjectArray_3 != null)
                {
                    Private___gintnl_SystemObjectArray_3.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0__intnlparam
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

        internal bool? __0_allUsersOffline__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_allUsersOffline__ret != null)
                {
                    return Private___0_allUsersOffline__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_allUsersOffline__ret != null)
                    {
                        Private___0_allUsersOffline__ret.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_table___param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_table___param != null)
                {
                    return Private___0_table___param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_table___param != null)
                {
                    Private___0_table___param.Value = value;
                }
            }
        }

        internal string __0_moduleType___param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_moduleType___param != null)
                {
                    return Private___0_moduleType___param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_moduleType___param != null)
                {
                    Private___0_moduleType___param.Value = value;
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

        internal UnityEngine.Component[] __intnl_UnityEngineComponentArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponentArray_0 != null)
                {
                    return Private___intnl_UnityEngineComponentArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponentArray_0 != null)
                {
                    Private___intnl_UnityEngineComponentArray_0.Value = value;
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

        internal long? __intnl_SystemInt64_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt64_0 != null)
                {
                    return Private___intnl_SystemInt64_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt64_0 != null)
                    {
                        Private___intnl_SystemInt64_0.Value = value.Value;
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

        internal string moduleType
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_moduleType != null)
                {
                    return Private_moduleType.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_moduleType != null)
                {
                    Private_moduleType.Value = value;
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

        internal VRC.Udon.UdonBehaviour __lcl_behaviour_VRCUdonUdonBehaviour_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_0 != null)
                {
                    return Private___lcl_behaviour_VRCUdonUdonBehaviour_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_0 != null)
                {
                    Private___lcl_behaviour_VRCUdonUdonBehaviour_0.Value = value;
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

        internal VRC.Udon.UdonBehaviour table
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_table != null)
                {
                    return Private_table.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_table != null)
                {
                    Private_table.Value = value;
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

        internal long? __lcl_targetID_SystemInt64_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_targetID_SystemInt64_0 != null)
                {
                    return Private___lcl_targetID_SystemInt64_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_targetID_SystemInt64_0 != null)
                    {
                        Private___lcl_targetID_SystemInt64_0.Value = value.Value;
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

        internal long? __lcl_idValue_SystemObject_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_idValue_SystemObject_0 != null)
                {
                    return Private___lcl_idValue_SystemObject_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_idValue_SystemObject_0 != null)
                    {
                        Private___lcl_idValue_SystemObject_0.Value = value.Value;
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

        internal bool? __0___0_isAuthorizedUser__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_isAuthorizedUser__ret != null)
                {
                    return Private___0___0_isAuthorizedUser__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_isAuthorizedUser__ret != null)
                    {
                        Private___0___0_isAuthorizedUser__ret.Value = value.Value;
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

        internal System.Object[] __gintnl_SystemObjectArray_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemObjectArray_2 != null)
                {
                    return Private___gintnl_SystemObjectArray_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___gintnl_SystemObjectArray_2 != null)
                {
                    Private___gintnl_SystemObjectArray_2.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __lcl_udonBehaviours_UnityEngineComponentArray_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_udonBehaviours_UnityEngineComponentArray_0 != null)
                {
                    return Private___lcl_udonBehaviours_UnityEngineComponentArray_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_udonBehaviours_UnityEngineComponentArray_0 != null)
                {
                    Private___lcl_udonBehaviours_UnityEngineComponentArray_0.Value = value;
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

        internal bool? __0__onOwnershipRequest__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0__onOwnershipRequest__ret != null)
                {
                    return Private___0__onOwnershipRequest__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0__onOwnershipRequest__ret != null)
                    {
                        Private___0__onOwnershipRequest__ret.Value = value.Value;
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

        #endregion Getter / Setters AstroUdonVariables  of NetworkingManager

        #region AstroUdonVariables  of NetworkingManager

        private AstroUdonVariable<long> Private___const_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Object[]> Private___gintnl_SystemObjectArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___const_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___const_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_metaverse { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineComponent_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Object[]> Private___gintnl_SystemObjectArray_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_allUsersOffline__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_table___param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___0_moduleType___param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___intnl_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___intnl_UnityEngineComponentArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___intnl_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private_moduleType { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___lcl_i_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_behaviour_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___1__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_table { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<long> Private___lcl_targetID_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_idValue_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0___0_isAuthorizedUser__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<System.Object[]> Private___gintnl_SystemObjectArray_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___lcl_udonBehaviours_UnityEngineComponentArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0__onOwnershipRequest__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of NetworkingManager
    }
}