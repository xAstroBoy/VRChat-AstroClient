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
    public class PoolParlor_CueReader : MonoBehaviour
    {
        //Behaviour intl.cue-0/1 EventKeys
        //Event Key : _start
        //Event Key : _onDeserialization
        //Event Key : _onOwnershipRequest
        //Event Key : __0__SetAuthorizedOwners
        //Event Key : __0__Enable
        //Event Key : __0__Disable
        //Event Key : _fixedUpdate
        //Event Key : __0__IsOwnershipTransferAllowed
        //Event Key : _OnPrimaryPickup
        //Event Key : _OnPrimaryDrop
        //Event Key : _OnPrimaryUseDown
        //Event Key : _OnPrimaryUseUp
        //Event Key : _OnSecondaryPickup
        //Event Key : _OnSecondaryDrop
        //Event Key : _OnSecondaryUseDown
        //Event Key : _OnSecondaryUseUp
        //Event Key : _GetDesktopMarker
        //Event Key : _GetCuetip
        //Event Key : _GetHolder

        private List<Object> AntiGarbageCollection = new();

        public PoolParlor_CueReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PoolParlor))
            {
                var obj = gameObject.FindUdonEvent("_onOwnershipRequest");
                if (obj != null)
                {
                    ClientEventActions.OnRoomLeft += OnRoomLeft;
                    PoolCue = obj.RawItem;
                    Initialize_PoolCue();
                }
                else
                {
                    Log.Error("Can't Find BilliardsModule behaviour, Unable to Add Reader Component, did the author update the world?");
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
            ClientEventActions.OnRoomLeft -= OnRoomLeft;
            Cleanup_PoolCue();
        }

        private RawUdonBehaviour PoolCue { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private void Initialize_PoolCue()
        {
            Private___const_SystemSingle_8 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_8");
            Private___intnl_SystemBoolean_13 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_13");
            Private___gintnl_SystemUInt32_16 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_16");
            Private___const_SystemInt64_2 = new AstroUdonVariable<long>(PoolCue, "__const_SystemInt64_2");
            Private___const_SystemInt64_1 = new AstroUdonVariable<long>(PoolCue, "__const_SystemInt64_1");
            Private___const_SystemInt64_0 = new AstroUdonVariable<long>(PoolCue, "__const_SystemInt64_0");
            Private_cuetipDistance = new AstroUdonVariable<float>(PoolCue, "cuetipDistance");
            Private___intnl_SystemSingle_0 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_0");
            Private___lcl_targetID_SystemInt64_1 = new AstroUdonVariable<long>(PoolCue, "__lcl_targetID_SystemInt64_1");
            Private___const_SystemString_0 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_0");
            Private___intnl_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_0");
            Private___const_SystemSingle_0 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_0");
            Private___lcl_idValue_SystemObject_1 = new AstroUdonVariable<long>(PoolCue, "__lcl_idValue_SystemObject_1");
            Private___intnl_UnityEngineVector3_6 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_6");
            Private___intnl_SystemBoolean_16 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_16");
            Private___0___0__IsOwnershipTransferAllowed__ret = new AstroUdonVariable<bool>(PoolCue, "__0___0__IsOwnershipTransferAllowed__ret");
            Private___0_cueSkin__param = new AstroUdonVariable<int>(PoolCue, "__0_cueSkin__param");
            Private___intnl_SystemSingle_10 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_10");
            Private___intnl_SystemSingle_11 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_11");
            Private___intnl_SystemSingle_12 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_12");
            Private___lcl_bodyRotation_UnityEngineVector3_1 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__lcl_bodyRotation_UnityEngineVector3_1");
            Private___lcl_bodyRotation_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__lcl_bodyRotation_UnityEngineVector3_0");
            Private___intnl_SystemSingle_8 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_8");
            Private___gintnl_SystemUInt32_9 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_9");
            Private___gintnl_SystemUInt32_8 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_8");
            Private___gintnl_SystemUInt32_5 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_5");
            Private___gintnl_SystemUInt32_4 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_4");
            Private___gintnl_SystemUInt32_7 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_7");
            Private___gintnl_SystemUInt32_6 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_6");
            Private___gintnl_SystemUInt32_1 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_1");
            Private___gintnl_SystemUInt32_0 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_0");
            Private___gintnl_SystemUInt32_3 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_3");
            Private___gintnl_SystemUInt32_2 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_2");
            Private___const_SystemBoolean_0 = new AstroUdonVariable<bool>(PoolCue, "__const_SystemBoolean_0");
            Private___const_SystemBoolean_1 = new AstroUdonVariable<bool>(PoolCue, "__const_SystemBoolean_1");
            Private_primaryLocked = new AstroUdonVariable<bool>(PoolCue, "primaryLocked");
            Private___const_SystemString_5 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_5");
            Private_holderIsDesktop = new AstroUdonVariable<bool>(PoolCue, "holderIsDesktop");
            Private___const_SystemSingle_7 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_7");
            Private___intnl_UnityEngineComponent_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__intnl_UnityEngineComponent_3");
            Private_primary = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "primary");
            Private___intnl_UnityEngineVector3_5 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_5");
            Private___gintnl_SystemUInt32_13 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_13");
            Private___3__intnlparam = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__3__intnlparam");
            Private_secondaryOffset = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "secondaryOffset");
            Private_secondary = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "secondary");
            Private___const_SystemString_16 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_16");
            Private___const_SystemString_17 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_17");
            Private___const_SystemString_14 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_14");
            Private___const_SystemString_15 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_15");
            Private___const_SystemString_12 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_12");
            Private___const_SystemString_13 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_13");
            Private___const_SystemString_10 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_10");
            Private___const_SystemString_11 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_11");
            Private___const_SystemString_18 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_18");
            Private___const_SystemString_19 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_19");
            Private___intnl_SystemSingle_7 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_7");
            Private___refl_typeid = new AstroUdonVariable<long>(PoolCue, "__refl_typeid");
            Private___1_shouldReset__param = new AstroUdonVariable<bool>(PoolCue, "__1_shouldReset__param");
            Private___intnl_UnityEngineTransform_5 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_5");
            Private___const_SystemUInt32_0 = new AstroUdonVariable<uint>(PoolCue, "__const_SystemUInt32_0");
            Private___intnl_SystemBoolean_11 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_11");
            Private___intnl_UnityEngineTransform_12 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_12");
            Private___intnl_UnityEngineTransform_11 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_11");
            Private___intnl_UnityEngineTransform_16 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_16");
            Private___intnl_UnityEngineTransform_15 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_15");
            Private___gintnl_SystemUInt32_14 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_14");
            Private_primaryLockDir = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "primaryLockDir");
            Private_body = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "body");
            Private___0__intnlparam = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__0__intnlparam");
            Private___intnl_SystemSingle_2 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_2");
            Private_secondaryHolding = new AstroUdonVariable<bool>(PoolCue, "secondaryHolding");
            Private___const_SystemString_2 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_2");
            Private___intnl_UnityEngineTransform_2 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_2");
            Private_origPrimaryPosition = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "origPrimaryPosition");
            Private___const_SystemSingle_2 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_2");
            Private___intnl_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_0");
            Private___const_SystemSingle_9 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_9");
            Private___intnl_SystemBoolean_14 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_14");
            Private___intnl_UnityEngineComponentArray_1 = new AstroUdonVariable<UnityEngine.Component[]>(PoolCue, "__intnl_UnityEngineComponentArray_1");
            Private___intnl_UnityEngineComponentArray_0 = new AstroUdonVariable<UnityEngine.Component[]>(PoolCue, "__intnl_UnityEngineComponentArray_0");
            Private___intnl_UnityEngineComponentArray_2 = new AstroUdonVariable<UnityEngine.Component[]>(PoolCue, "__intnl_UnityEngineComponentArray_2");
            Private_gripSize = new AstroUdonVariable<float>(PoolCue, "gripSize");
            Private_desktop = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "desktop");
            Private___intnl_SystemSingle_1 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_1");
            Private_primaryHolding = new AstroUdonVariable<bool>(PoolCue, "primaryHolding");
            Private___lcl_targetID_SystemInt64_2 = new AstroUdonVariable<long>(PoolCue, "__lcl_targetID_SystemInt64_2");
            Private___const_SystemString_7 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_7");
            Private___4__intnlparam = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__4__intnlparam");
            Private_secondaryLockPos = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "secondaryLockPos");
            Private___intnl_UnityEngineVector3_8 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_8");
            Private___const_SystemSingle_1 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_1");
            Private___intnl_UnityEngineVector3_7 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_7");
            Private___gintnl_SystemUInt32_11 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_11");
            Private___intnl_SystemBoolean_17 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_17");
            Private___intnl_SystemInt32_11 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_11");
            Private_syncedHolderIsDesktop = new AstroUdonVariable<bool>(PoolCue, "syncedHolderIsDesktop");
            Private___lcl_distance_SystemSingle_0 = new AstroUdonVariable<float>(PoolCue, "__lcl_distance_SystemSingle_0");
            Private___intnl_UnityEngineVector3_10 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_10");
            Private___intnl_UnityEngineVector3_11 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_11");
            Private___intnl_UnityEngineVector3_12 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_12");
            Private___intnl_UnityEngineVector3_13 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_13");
            Private___intnl_UnityEngineVector3_14 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_14");
            Private___intnl_UnityEngineVector3_15 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_15");
            Private___intnl_UnityEngineVector3_16 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_16");
            Private___intnl_UnityEngineVector3_17 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_17");
            Private___intnl_UnityEngineVector3_18 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_18");
            Private___intnl_SystemSingle_9 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_9");
            Private___intnl_SystemInt64_2 = new AstroUdonVariable<long>(PoolCue, "__intnl_SystemInt64_2");
            Private___intnl_SystemInt64_1 = new AstroUdonVariable<long>(PoolCue, "__intnl_SystemInt64_1");
            Private___intnl_SystemInt64_0 = new AstroUdonVariable<long>(PoolCue, "__intnl_SystemInt64_0");
            Private___intnl_returnJump_SystemUInt32_0 = new AstroUdonVariable<uint>(PoolCue, "__intnl_returnJump_SystemUInt32_0");
            Private___const_SystemString_4 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_4");
            Private___gintnl_SystemUInt32_19 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_19");
            Private___const_SystemSingle_4 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_4");
            Private___intnl_UnityEngineComponent_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__intnl_UnityEngineComponent_2");
            Private_desktopController = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "desktopController");
            Private___gintnl_SystemUInt32_12 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_12");
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__lcl_behaviour_VRCUdonUdonBehaviour_0");
            Private___lcl_udonBehaviours_UnityEngineComponentArray_1 = new AstroUdonVariable<UnityEngine.Component[]>(PoolCue, "__lcl_udonBehaviours_UnityEngineComponentArray_1");
            Private___0_input__param = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__0_input__param");
            Private___intnl_SystemSingle_4 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_4");
            Private___1__intnlparam = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__1__intnlparam");
            Private_cuetip = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "cuetip");
            Private___intnl_UnityEngineTransform_4 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_4");
            Private___const_SystemString_9 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_9");
            Private___intnl_UnityEngineVector3_2 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_2");
            Private___0_minX__param = new AstroUdonVariable<float>(PoolCue, "__0_minX__param");
            Private_table = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "table");
            Private___intnl_SystemBoolean_12 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_12");
            Private___gintnl_SystemUInt32_17 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_17");
            Private_lagPrimaryPosition = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "lagPrimaryPosition");
            Private___refl_typename = new AstroUdonVariable<string>(PoolCue, "__refl_typename");
            Private_primaryController = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "primaryController");
            Private___lcl_udonBehaviours_UnityEngineComponentArray_2 = new AstroUdonVariable<UnityEngine.Component[]>(PoolCue, "__lcl_udonBehaviours_UnityEngineComponentArray_2");
            Private___intnl_SystemInt32_1 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_1");
            Private___intnl_SystemInt32_0 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_0");
            Private___intnl_SystemInt32_3 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_3");
            Private___intnl_SystemInt32_2 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_2");
            Private___intnl_SystemInt32_5 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_5");
            Private___intnl_SystemInt32_4 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_4");
            Private___intnl_SystemInt32_7 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_7");
            Private___intnl_SystemInt32_6 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_6");
            Private___intnl_SystemInt32_9 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_9");
            Private___intnl_SystemInt32_8 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_8");
            Private___lcl_position_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__lcl_position_UnityEngineVector3_0");
            Private___intnl_SystemSingle_3 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_3");
            Private___lcl_rotation_SystemSingle_1 = new AstroUdonVariable<float>(PoolCue, "__lcl_rotation_SystemSingle_1");
            Private___lcl_rotation_SystemSingle_0 = new AstroUdonVariable<float>(PoolCue, "__lcl_rotation_SystemSingle_0");
            Private___this_UnityEngineTransform_0 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__this_UnityEngineTransform_0");
            Private_syncedCueSkin = new AstroUdonVariable<int>(PoolCue, "syncedCueSkin");
            Private___lcl_targetID_SystemInt64_0 = new AstroUdonVariable<long>(PoolCue, "__lcl_targetID_SystemInt64_0");
            Private___const_SystemString_1 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_1");
            Private___intnl_UnityEngineTransform_1 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_1");
            Private_activeCueSkin = new AstroUdonVariable<int>(PoolCue, "activeCueSkin");
            Private___const_SystemSingle_3 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_3");
            Private___lcl_idValue_SystemObject_0 = new AstroUdonVariable<long>(PoolCue, "__lcl_idValue_SystemObject_0");
            Private___0_minZ__param = new AstroUdonVariable<float>(PoolCue, "__0_minZ__param");
            Private___5__intnlparam = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__5__intnlparam");
            Private___intnl_UnityEngineVector3_1 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_1");
            Private___intnl_SystemBoolean_15 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_15");
            Private_secondaryController = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "secondaryController");
            Private___lcl_delta_UnityEngineVector3_0 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__lcl_delta_UnityEngineVector3_0");
            Private___0_minY__param = new AstroUdonVariable<float>(PoolCue, "__0_minY__param");
            Private___0___0_clamp__ret = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__0___0_clamp__ret");
            Private___const_SystemString_6 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_6");
            Private___intnl_UnityEngineVector3_9 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_9");
            Private___const_SystemSingle_6 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_6");
            Private___intnl_UnityEngineVector3_4 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_4");
            Private___gintnl_SystemUInt32_10 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_10");
            Private___lcl_behaviour_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__lcl_behaviour_VRCUdonUdonBehaviour_2");
            Private___intnl_SystemInt32_10 = new AstroUdonVariable<int>(PoolCue, "__intnl_SystemInt32_10");
            Private___0_maxX__param = new AstroUdonVariable<float>(PoolCue, "__0_maxX__param");
            Private___this_UnityEngineGameObject_0 = new AstroUdonVariable<UnityEngine.GameObject>(PoolCue, "__this_UnityEngineGameObject_0");
            Private___const_SystemString_22 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_22");
            Private___const_SystemString_20 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_20");
            Private___const_SystemString_21 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_21");
            Private___intnl_SystemSingle_6 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_6");
            Private_secondaryLocked = new AstroUdonVariable<bool>(PoolCue, "secondaryLocked");
            Private___const_UnityEngineQuaternion_0 = new AstroUdonVariable<UnityEngine.Quaternion>(PoolCue, "__const_UnityEngineQuaternion_0");
            Private___intnl_UnityEngineTransform_6 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_6");
            Private___gintnl_SystemUInt32_18 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_18");
            Private_primaryLockPos = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "primaryLockPos");
            Private___const_SystemSingle_5 = new AstroUdonVariable<float>(PoolCue, "__const_SystemSingle_5");
            Private___2__intnlparam = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__2__intnlparam");
            Private___intnl_UnityEngineComponent_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__intnl_UnityEngineComponent_1");
            Private___intnl_SystemBoolean_10 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_10");
            Private___intnl_UnityEngineQuaternion_0 = new AstroUdonVariable<UnityEngine.Quaternion>(PoolCue, "__intnl_UnityEngineQuaternion_0");
            Private___intnl_UnityEngineQuaternion_1 = new AstroUdonVariable<UnityEngine.Quaternion>(PoolCue, "__intnl_UnityEngineQuaternion_1");
            Private___intnl_UnityEngineQuaternion_2 = new AstroUdonVariable<UnityEngine.Quaternion>(PoolCue, "__intnl_UnityEngineQuaternion_2");
            Private___gintnl_SystemUInt32_15 = new AstroUdonVariable<uint>(PoolCue, "__gintnl_SystemUInt32_15");
            Private_lagSecondaryPosition = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "lagSecondaryPosition");
            Private___const_SystemInt32_1 = new AstroUdonVariable<int>(PoolCue, "__const_SystemInt32_1");
            Private___const_SystemInt32_0 = new AstroUdonVariable<int>(PoolCue, "__const_SystemInt32_0");
            Private___const_SystemInt32_3 = new AstroUdonVariable<int>(PoolCue, "__const_SystemInt32_3");
            Private___const_SystemInt32_2 = new AstroUdonVariable<int>(PoolCue, "__const_SystemInt32_2");
            Private___0_shouldReset__param = new AstroUdonVariable<bool>(PoolCue, "__0_shouldReset__param");
            Private___0_maxZ__param = new AstroUdonVariable<float>(PoolCue, "__0_maxZ__param");
            Private___lcl_behaviour_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__lcl_behaviour_VRCUdonUdonBehaviour_1");
            Private___lcl_udonBehaviours_UnityEngineComponentArray_0 = new AstroUdonVariable<UnityEngine.Component[]>(PoolCue, "__lcl_udonBehaviours_UnityEngineComponentArray_0");
            Private___intnl_SystemBoolean_8 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_8");
            Private___intnl_SystemBoolean_9 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_9");
            Private___intnl_SystemBoolean_0 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_0");
            Private___intnl_SystemBoolean_1 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_1");
            Private___intnl_SystemBoolean_2 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_2");
            Private___intnl_SystemBoolean_3 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_3");
            Private___intnl_SystemBoolean_4 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_4");
            Private___intnl_SystemBoolean_5 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_5");
            Private___intnl_SystemBoolean_6 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_6");
            Private___intnl_SystemBoolean_7 = new AstroUdonVariable<bool>(PoolCue, "__intnl_SystemBoolean_7");
            Private___intnl_SystemSingle_5 = new AstroUdonVariable<float>(PoolCue, "__intnl_SystemSingle_5");
            Private_origSecondaryPosition = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "origSecondaryPosition");
            Private___0_maxY__param = new AstroUdonVariable<float>(PoolCue, "__0_maxY__param");
            Private___const_SystemString_3 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_3");
            Private___this_VRCUdonUdonBehaviour_9 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_9");
            Private___this_VRCUdonUdonBehaviour_8 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_8");
            Private___this_VRCUdonUdonBehaviour_3 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_3");
            Private___this_VRCUdonUdonBehaviour_2 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_2");
            Private___this_VRCUdonUdonBehaviour_1 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_1");
            Private___this_VRCUdonUdonBehaviour_0 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_0");
            Private___this_VRCUdonUdonBehaviour_7 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_7");
            Private___this_VRCUdonUdonBehaviour_6 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_6");
            Private___this_VRCUdonUdonBehaviour_5 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_5");
            Private___this_VRCUdonUdonBehaviour_4 = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(PoolCue, "__this_VRCUdonUdonBehaviour_4");
            Private___intnl_UnityEngineTransform_3 = new AstroUdonVariable<UnityEngine.Transform>(PoolCue, "__intnl_UnityEngineTransform_3");
            Private___lcl_idValue_SystemObject_2 = new AstroUdonVariable<long>(PoolCue, "__lcl_idValue_SystemObject_2");
            Private___0__onOwnershipRequest__ret = new AstroUdonVariable<bool>(PoolCue, "__0__onOwnershipRequest__ret");
            Private___const_SystemString_8 = new AstroUdonVariable<string>(PoolCue, "__const_SystemString_8");
            Private___intnl_UnityEngineVector3_3 = new AstroUdonVariable<UnityEngine.Vector3>(PoolCue, "__intnl_UnityEngineVector3_3");
        }

        private void Cleanup_PoolCue()
        {
            Private___const_SystemSingle_8 = null;
            Private___intnl_SystemBoolean_13 = null;
            Private___gintnl_SystemUInt32_16 = null;
            Private___const_SystemInt64_2 = null;
            Private___const_SystemInt64_1 = null;
            Private___const_SystemInt64_0 = null;
            Private_cuetipDistance = null;
            Private___intnl_SystemSingle_0 = null;
            Private___lcl_targetID_SystemInt64_1 = null;
            Private___const_SystemString_0 = null;
            Private___intnl_UnityEngineTransform_0 = null;
            Private___const_SystemSingle_0 = null;
            Private___lcl_idValue_SystemObject_1 = null;
            Private___intnl_UnityEngineVector3_6 = null;
            Private___intnl_SystemBoolean_16 = null;
            Private___0___0__IsOwnershipTransferAllowed__ret = null;
            Private___0_cueSkin__param = null;
            Private___intnl_SystemSingle_10 = null;
            Private___intnl_SystemSingle_11 = null;
            Private___intnl_SystemSingle_12 = null;
            Private___lcl_bodyRotation_UnityEngineVector3_1 = null;
            Private___lcl_bodyRotation_UnityEngineVector3_0 = null;
            Private___intnl_SystemSingle_8 = null;
            Private___gintnl_SystemUInt32_9 = null;
            Private___gintnl_SystemUInt32_8 = null;
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
            Private_primaryLocked = null;
            Private___const_SystemString_5 = null;
            Private_holderIsDesktop = null;
            Private___const_SystemSingle_7 = null;
            Private___intnl_UnityEngineComponent_3 = null;
            Private_primary = null;
            Private___intnl_UnityEngineVector3_5 = null;
            Private___gintnl_SystemUInt32_13 = null;
            Private___3__intnlparam = null;
            Private_secondaryOffset = null;
            Private_secondary = null;
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
            Private___refl_typeid = null;
            Private___1_shouldReset__param = null;
            Private___intnl_UnityEngineTransform_5 = null;
            Private___const_SystemUInt32_0 = null;
            Private___intnl_SystemBoolean_11 = null;
            Private___intnl_UnityEngineTransform_12 = null;
            Private___intnl_UnityEngineTransform_11 = null;
            Private___intnl_UnityEngineTransform_16 = null;
            Private___intnl_UnityEngineTransform_15 = null;
            Private___gintnl_SystemUInt32_14 = null;
            Private_primaryLockDir = null;
            Private_body = null;
            Private___0__intnlparam = null;
            Private___intnl_SystemSingle_2 = null;
            Private_secondaryHolding = null;
            Private___const_SystemString_2 = null;
            Private___intnl_UnityEngineTransform_2 = null;
            Private_origPrimaryPosition = null;
            Private___const_SystemSingle_2 = null;
            Private___intnl_UnityEngineVector3_0 = null;
            Private___const_SystemSingle_9 = null;
            Private___intnl_SystemBoolean_14 = null;
            Private___intnl_UnityEngineComponentArray_1 = null;
            Private___intnl_UnityEngineComponentArray_0 = null;
            Private___intnl_UnityEngineComponentArray_2 = null;
            Private_gripSize = null;
            Private_desktop = null;
            Private___intnl_SystemSingle_1 = null;
            Private_primaryHolding = null;
            Private___lcl_targetID_SystemInt64_2 = null;
            Private___const_SystemString_7 = null;
            Private___4__intnlparam = null;
            Private_secondaryLockPos = null;
            Private___intnl_UnityEngineVector3_8 = null;
            Private___const_SystemSingle_1 = null;
            Private___intnl_UnityEngineVector3_7 = null;
            Private___gintnl_SystemUInt32_11 = null;
            Private___intnl_SystemBoolean_17 = null;
            Private___intnl_SystemInt32_11 = null;
            Private_syncedHolderIsDesktop = null;
            Private___lcl_distance_SystemSingle_0 = null;
            Private___intnl_UnityEngineVector3_10 = null;
            Private___intnl_UnityEngineVector3_11 = null;
            Private___intnl_UnityEngineVector3_12 = null;
            Private___intnl_UnityEngineVector3_13 = null;
            Private___intnl_UnityEngineVector3_14 = null;
            Private___intnl_UnityEngineVector3_15 = null;
            Private___intnl_UnityEngineVector3_16 = null;
            Private___intnl_UnityEngineVector3_17 = null;
            Private___intnl_UnityEngineVector3_18 = null;
            Private___intnl_SystemSingle_9 = null;
            Private___intnl_SystemInt64_2 = null;
            Private___intnl_SystemInt64_1 = null;
            Private___intnl_SystemInt64_0 = null;
            Private___intnl_returnJump_SystemUInt32_0 = null;
            Private___const_SystemString_4 = null;
            Private___gintnl_SystemUInt32_19 = null;
            Private___const_SystemSingle_4 = null;
            Private___intnl_UnityEngineComponent_2 = null;
            Private_desktopController = null;
            Private___gintnl_SystemUInt32_12 = null;
            Private___lcl_behaviour_VRCUdonUdonBehaviour_0 = null;
            Private___lcl_udonBehaviours_UnityEngineComponentArray_1 = null;
            Private___0_input__param = null;
            Private___intnl_SystemSingle_4 = null;
            Private___1__intnlparam = null;
            Private_cuetip = null;
            Private___intnl_UnityEngineTransform_4 = null;
            Private___const_SystemString_9 = null;
            Private___intnl_UnityEngineVector3_2 = null;
            Private___0_minX__param = null;
            Private_table = null;
            Private___intnl_SystemBoolean_12 = null;
            Private___gintnl_SystemUInt32_17 = null;
            Private_lagPrimaryPosition = null;
            Private___refl_typename = null;
            Private_primaryController = null;
            Private___lcl_udonBehaviours_UnityEngineComponentArray_2 = null;
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
            Private___lcl_position_UnityEngineVector3_0 = null;
            Private___intnl_SystemSingle_3 = null;
            Private___lcl_rotation_SystemSingle_1 = null;
            Private___lcl_rotation_SystemSingle_0 = null;
            Private___this_UnityEngineTransform_0 = null;
            Private_syncedCueSkin = null;
            Private___lcl_targetID_SystemInt64_0 = null;
            Private___const_SystemString_1 = null;
            Private___intnl_UnityEngineTransform_1 = null;
            Private_activeCueSkin = null;
            Private___const_SystemSingle_3 = null;
            Private___lcl_idValue_SystemObject_0 = null;
            Private___0_minZ__param = null;
            Private___5__intnlparam = null;
            Private___intnl_UnityEngineVector3_1 = null;
            Private___intnl_SystemBoolean_15 = null;
            Private_secondaryController = null;
            Private___lcl_delta_UnityEngineVector3_0 = null;
            Private___0_minY__param = null;
            Private___0___0_clamp__ret = null;
            Private___const_SystemString_6 = null;
            Private___intnl_UnityEngineVector3_9 = null;
            Private___const_SystemSingle_6 = null;
            Private___intnl_UnityEngineVector3_4 = null;
            Private___gintnl_SystemUInt32_10 = null;
            Private___lcl_behaviour_VRCUdonUdonBehaviour_2 = null;
            Private___intnl_SystemInt32_10 = null;
            Private___0_maxX__param = null;
            Private___this_UnityEngineGameObject_0 = null;
            Private___const_SystemString_22 = null;
            Private___const_SystemString_20 = null;
            Private___const_SystemString_21 = null;
            Private___intnl_SystemSingle_6 = null;
            Private_secondaryLocked = null;
            Private___const_UnityEngineQuaternion_0 = null;
            Private___intnl_UnityEngineTransform_6 = null;
            Private___gintnl_SystemUInt32_18 = null;
            Private_primaryLockPos = null;
            Private___const_SystemSingle_5 = null;
            Private___2__intnlparam = null;
            Private___intnl_UnityEngineComponent_1 = null;
            Private___intnl_SystemBoolean_10 = null;
            Private___intnl_UnityEngineQuaternion_0 = null;
            Private___intnl_UnityEngineQuaternion_1 = null;
            Private___intnl_UnityEngineQuaternion_2 = null;
            Private___gintnl_SystemUInt32_15 = null;
            Private_lagSecondaryPosition = null;
            Private___const_SystemInt32_1 = null;
            Private___const_SystemInt32_0 = null;
            Private___const_SystemInt32_3 = null;
            Private___const_SystemInt32_2 = null;
            Private___0_shouldReset__param = null;
            Private___0_maxZ__param = null;
            Private___lcl_behaviour_VRCUdonUdonBehaviour_1 = null;
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
            Private___intnl_SystemSingle_5 = null;
            Private_origSecondaryPosition = null;
            Private___0_maxY__param = null;
            Private___const_SystemString_3 = null;
            Private___this_VRCUdonUdonBehaviour_9 = null;
            Private___this_VRCUdonUdonBehaviour_8 = null;
            Private___this_VRCUdonUdonBehaviour_3 = null;
            Private___this_VRCUdonUdonBehaviour_2 = null;
            Private___this_VRCUdonUdonBehaviour_1 = null;
            Private___this_VRCUdonUdonBehaviour_0 = null;
            Private___this_VRCUdonUdonBehaviour_7 = null;
            Private___this_VRCUdonUdonBehaviour_6 = null;
            Private___this_VRCUdonUdonBehaviour_5 = null;
            Private___this_VRCUdonUdonBehaviour_4 = null;
            Private___intnl_UnityEngineTransform_3 = null;
            Private___lcl_idValue_SystemObject_2 = null;
            Private___0__onOwnershipRequest__ret = null;
            Private___const_SystemString_8 = null;
            Private___intnl_UnityEngineVector3_3 = null;
        }

        #region Getter / Setters AstroUdonVariables  of PoolCue

        internal float? __const_SystemSingle_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_8 != null)
                {
                    return Private___const_SystemSingle_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_8 != null)
                    {
                        Private___const_SystemSingle_8.Value = value.Value;
                    }
                }
            }
        }

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

        internal uint? __gintnl_SystemUInt32_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_16 != null)
                {
                    return Private___gintnl_SystemUInt32_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_16 != null)
                    {
                        Private___gintnl_SystemUInt32_16.Value = value.Value;
                    }
                }
            }
        }

        internal long? __const_SystemInt64_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt64_2 != null)
                {
                    return Private___const_SystemInt64_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt64_2 != null)
                    {
                        Private___const_SystemInt64_2.Value = value.Value;
                    }
                }
            }
        }

        internal long? __const_SystemInt64_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemInt64_1 != null)
                {
                    return Private___const_SystemInt64_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemInt64_1 != null)
                    {
                        Private___const_SystemInt64_1.Value = value.Value;
                    }
                }
            }
        }

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

        internal float? cuetipDistance
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cuetipDistance != null)
                {
                    return Private_cuetipDistance.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_cuetipDistance != null)
                    {
                        Private_cuetipDistance.Value = value.Value;
                    }
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

        internal long? __lcl_targetID_SystemInt64_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_targetID_SystemInt64_1 != null)
                {
                    return Private___lcl_targetID_SystemInt64_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_targetID_SystemInt64_1 != null)
                    {
                        Private___lcl_targetID_SystemInt64_1.Value = value.Value;
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

        internal long? __lcl_idValue_SystemObject_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_idValue_SystemObject_1 != null)
                {
                    return Private___lcl_idValue_SystemObject_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_idValue_SystemObject_1 != null)
                    {
                        Private___lcl_idValue_SystemObject_1.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_6 != null)
                {
                    return Private___intnl_UnityEngineVector3_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_6 != null)
                    {
                        Private___intnl_UnityEngineVector3_6.Value = value.Value;
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

        internal bool? __0___0__IsOwnershipTransferAllowed__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0__IsOwnershipTransferAllowed__ret != null)
                {
                    return Private___0___0__IsOwnershipTransferAllowed__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0__IsOwnershipTransferAllowed__ret != null)
                    {
                        Private___0___0__IsOwnershipTransferAllowed__ret.Value = value.Value;
                    }
                }
            }
        }

        internal int? __0_cueSkin__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_cueSkin__param != null)
                {
                    return Private___0_cueSkin__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_cueSkin__param != null)
                    {
                        Private___0_cueSkin__param.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_10 != null)
                {
                    return Private___intnl_SystemSingle_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_10 != null)
                    {
                        Private___intnl_SystemSingle_10.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_11 != null)
                {
                    return Private___intnl_SystemSingle_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_11 != null)
                    {
                        Private___intnl_SystemSingle_11.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_12 != null)
                {
                    return Private___intnl_SystemSingle_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_12 != null)
                    {
                        Private___intnl_SystemSingle_12.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __lcl_bodyRotation_UnityEngineVector3_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_bodyRotation_UnityEngineVector3_1 != null)
                {
                    return Private___lcl_bodyRotation_UnityEngineVector3_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_bodyRotation_UnityEngineVector3_1 != null)
                    {
                        Private___lcl_bodyRotation_UnityEngineVector3_1.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __lcl_bodyRotation_UnityEngineVector3_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_bodyRotation_UnityEngineVector3_0 != null)
                {
                    return Private___lcl_bodyRotation_UnityEngineVector3_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_bodyRotation_UnityEngineVector3_0 != null)
                    {
                        Private___lcl_bodyRotation_UnityEngineVector3_0.Value = value.Value;
                    }
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

        internal uint? __gintnl_SystemUInt32_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_9 != null)
                {
                    return Private___gintnl_SystemUInt32_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_9 != null)
                    {
                        Private___gintnl_SystemUInt32_9.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_8 != null)
                {
                    return Private___gintnl_SystemUInt32_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_8 != null)
                    {
                        Private___gintnl_SystemUInt32_8.Value = value.Value;
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

        internal bool? primaryLocked
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primaryLocked != null)
                {
                    return Private_primaryLocked.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_primaryLocked != null)
                    {
                        Private_primaryLocked.Value = value.Value;
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

        internal bool? holderIsDesktop
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_holderIsDesktop != null)
                {
                    return Private_holderIsDesktop.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_holderIsDesktop != null)
                    {
                        Private_holderIsDesktop.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_7 != null)
                {
                    return Private___const_SystemSingle_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_7 != null)
                    {
                        Private___const_SystemSingle_7.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineComponent_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponent_3 != null)
                {
                    return Private___intnl_UnityEngineComponent_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponent_3 != null)
                {
                    Private___intnl_UnityEngineComponent_3.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject primary
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primary != null)
                {
                    return Private_primary.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_primary != null)
                {
                    Private_primary.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_5 != null)
                {
                    return Private___intnl_UnityEngineVector3_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_5 != null)
                    {
                        Private___intnl_UnityEngineVector3_5.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_13 != null)
                {
                    return Private___gintnl_SystemUInt32_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_13 != null)
                    {
                        Private___gintnl_SystemUInt32_13.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __3__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3__intnlparam != null)
                {
                    return Private___3__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3__intnlparam != null)
                {
                    Private___3__intnlparam.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? secondaryOffset
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondaryOffset != null)
                {
                    return Private_secondaryOffset.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_secondaryOffset != null)
                    {
                        Private_secondaryOffset.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject secondary
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondary != null)
                {
                    return Private_secondary.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_secondary != null)
                {
                    Private_secondary.Value = value;
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

        internal bool? __1_shouldReset__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_shouldReset__param != null)
                {
                    return Private___1_shouldReset__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_shouldReset__param != null)
                    {
                        Private___1_shouldReset__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_5 != null)
                {
                    return Private___intnl_UnityEngineTransform_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_5 != null)
                {
                    Private___intnl_UnityEngineTransform_5.Value = value;
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

        internal UnityEngine.Transform __intnl_UnityEngineTransform_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_12 != null)
                {
                    return Private___intnl_UnityEngineTransform_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_12 != null)
                {
                    Private___intnl_UnityEngineTransform_12.Value = value;
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_11 != null)
                {
                    return Private___intnl_UnityEngineTransform_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_11 != null)
                {
                    Private___intnl_UnityEngineTransform_11.Value = value;
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_16 != null)
                {
                    return Private___intnl_UnityEngineTransform_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_16 != null)
                {
                    Private___intnl_UnityEngineTransform_16.Value = value;
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_15 != null)
                {
                    return Private___intnl_UnityEngineTransform_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_15 != null)
                {
                    Private___intnl_UnityEngineTransform_15.Value = value;
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_14 != null)
                {
                    return Private___gintnl_SystemUInt32_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_14 != null)
                    {
                        Private___gintnl_SystemUInt32_14.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? primaryLockDir
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primaryLockDir != null)
                {
                    return Private_primaryLockDir.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_primaryLockDir != null)
                    {
                        Private_primaryLockDir.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject body
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_body != null)
                {
                    return Private_body.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_body != null)
                {
                    Private_body.Value = value;
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

        internal bool? secondaryHolding
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondaryHolding != null)
                {
                    return Private_secondaryHolding.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_secondaryHolding != null)
                    {
                        Private_secondaryHolding.Value = value.Value;
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

        internal UnityEngine.Transform __intnl_UnityEngineTransform_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_2 != null)
                {
                    return Private___intnl_UnityEngineTransform_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_2 != null)
                {
                    Private___intnl_UnityEngineTransform_2.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? origPrimaryPosition
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_origPrimaryPosition != null)
                {
                    return Private_origPrimaryPosition.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_origPrimaryPosition != null)
                    {
                        Private_origPrimaryPosition.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_2 != null)
                {
                    return Private___const_SystemSingle_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_2 != null)
                    {
                        Private___const_SystemSingle_2.Value = value.Value;
                    }
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

        internal float? __const_SystemSingle_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_9 != null)
                {
                    return Private___const_SystemSingle_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_9 != null)
                    {
                        Private___const_SystemSingle_9.Value = value.Value;
                    }
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

        internal UnityEngine.Component[] __intnl_UnityEngineComponentArray_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponentArray_1 != null)
                {
                    return Private___intnl_UnityEngineComponentArray_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponentArray_1 != null)
                {
                    Private___intnl_UnityEngineComponentArray_1.Value = value;
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

        internal UnityEngine.Component[] __intnl_UnityEngineComponentArray_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponentArray_2 != null)
                {
                    return Private___intnl_UnityEngineComponentArray_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponentArray_2 != null)
                {
                    Private___intnl_UnityEngineComponentArray_2.Value = value;
                }
            }
        }

        internal float? gripSize
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_gripSize != null)
                {
                    return Private_gripSize.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_gripSize != null)
                    {
                        Private_gripSize.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject desktop
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_desktop != null)
                {
                    return Private_desktop.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_desktop != null)
                {
                    Private_desktop.Value = value;
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

        internal bool? primaryHolding
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primaryHolding != null)
                {
                    return Private_primaryHolding.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_primaryHolding != null)
                    {
                        Private_primaryHolding.Value = value.Value;
                    }
                }
            }
        }

        internal long? __lcl_targetID_SystemInt64_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_targetID_SystemInt64_2 != null)
                {
                    return Private___lcl_targetID_SystemInt64_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_targetID_SystemInt64_2 != null)
                    {
                        Private___lcl_targetID_SystemInt64_2.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __4__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___4__intnlparam != null)
                {
                    return Private___4__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___4__intnlparam != null)
                {
                    Private___4__intnlparam.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? secondaryLockPos
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondaryLockPos != null)
                {
                    return Private_secondaryLockPos.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_secondaryLockPos != null)
                    {
                        Private_secondaryLockPos.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_8 != null)
                {
                    return Private___intnl_UnityEngineVector3_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_8 != null)
                    {
                        Private___intnl_UnityEngineVector3_8.Value = value.Value;
                    }
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

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_7 != null)
                {
                    return Private___intnl_UnityEngineVector3_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_7 != null)
                    {
                        Private___intnl_UnityEngineVector3_7.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_11 != null)
                {
                    return Private___gintnl_SystemUInt32_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_11 != null)
                    {
                        Private___gintnl_SystemUInt32_11.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __intnl_SystemBoolean_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemBoolean_17 != null)
                {
                    return Private___intnl_SystemBoolean_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemBoolean_17 != null)
                    {
                        Private___intnl_SystemBoolean_17.Value = value.Value;
                    }
                }
            }
        }

        internal int? __intnl_SystemInt32_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt32_11 != null)
                {
                    return Private___intnl_SystemInt32_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt32_11 != null)
                    {
                        Private___intnl_SystemInt32_11.Value = value.Value;
                    }
                }
            }
        }

        internal bool? syncedHolderIsDesktop
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_syncedHolderIsDesktop != null)
                {
                    return Private_syncedHolderIsDesktop.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_syncedHolderIsDesktop != null)
                    {
                        Private_syncedHolderIsDesktop.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_distance_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_distance_SystemSingle_0 != null)
                {
                    return Private___lcl_distance_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_distance_SystemSingle_0 != null)
                    {
                        Private___lcl_distance_SystemSingle_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_10 != null)
                {
                    return Private___intnl_UnityEngineVector3_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_10 != null)
                    {
                        Private___intnl_UnityEngineVector3_10.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_11
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_11 != null)
                {
                    return Private___intnl_UnityEngineVector3_11.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_11 != null)
                    {
                        Private___intnl_UnityEngineVector3_11.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_12 != null)
                {
                    return Private___intnl_UnityEngineVector3_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_12 != null)
                    {
                        Private___intnl_UnityEngineVector3_12.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_13
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_13 != null)
                {
                    return Private___intnl_UnityEngineVector3_13.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_13 != null)
                    {
                        Private___intnl_UnityEngineVector3_13.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_14
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_14 != null)
                {
                    return Private___intnl_UnityEngineVector3_14.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_14 != null)
                    {
                        Private___intnl_UnityEngineVector3_14.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_15 != null)
                {
                    return Private___intnl_UnityEngineVector3_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_15 != null)
                    {
                        Private___intnl_UnityEngineVector3_15.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_16
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_16 != null)
                {
                    return Private___intnl_UnityEngineVector3_16.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_16 != null)
                    {
                        Private___intnl_UnityEngineVector3_16.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_17 != null)
                {
                    return Private___intnl_UnityEngineVector3_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_17 != null)
                    {
                        Private___intnl_UnityEngineVector3_17.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_18 != null)
                {
                    return Private___intnl_UnityEngineVector3_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_18 != null)
                    {
                        Private___intnl_UnityEngineVector3_18.Value = value.Value;
                    }
                }
            }
        }

        internal float? __intnl_SystemSingle_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemSingle_9 != null)
                {
                    return Private___intnl_SystemSingle_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemSingle_9 != null)
                    {
                        Private___intnl_SystemSingle_9.Value = value.Value;
                    }
                }
            }
        }

        internal long? __intnl_SystemInt64_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt64_2 != null)
                {
                    return Private___intnl_SystemInt64_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt64_2 != null)
                    {
                        Private___intnl_SystemInt64_2.Value = value.Value;
                    }
                }
            }
        }

        internal long? __intnl_SystemInt64_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_SystemInt64_1 != null)
                {
                    return Private___intnl_SystemInt64_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_SystemInt64_1 != null)
                    {
                        Private___intnl_SystemInt64_1.Value = value.Value;
                    }
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

        internal uint? __gintnl_SystemUInt32_19
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_19 != null)
                {
                    return Private___gintnl_SystemUInt32_19.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_19 != null)
                    {
                        Private___gintnl_SystemUInt32_19.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_4 != null)
                {
                    return Private___const_SystemSingle_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_4 != null)
                    {
                        Private___const_SystemSingle_4.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineComponent_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponent_2 != null)
                {
                    return Private___intnl_UnityEngineComponent_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponent_2 != null)
                {
                    Private___intnl_UnityEngineComponent_2.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour desktopController
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_desktopController != null)
                {
                    return Private_desktopController.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_desktopController != null)
                {
                    Private_desktopController.Value = value;
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_12
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_12 != null)
                {
                    return Private___gintnl_SystemUInt32_12.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_12 != null)
                    {
                        Private___gintnl_SystemUInt32_12.Value = value.Value;
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

        internal UnityEngine.Component[] __lcl_udonBehaviours_UnityEngineComponentArray_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_udonBehaviours_UnityEngineComponentArray_1 != null)
                {
                    return Private___lcl_udonBehaviours_UnityEngineComponentArray_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_udonBehaviours_UnityEngineComponentArray_1 != null)
                {
                    Private___lcl_udonBehaviours_UnityEngineComponentArray_1.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __0_input__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_input__param != null)
                {
                    return Private___0_input__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_input__param != null)
                    {
                        Private___0_input__param.Value = value.Value;
                    }
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

        internal UnityEngine.GameObject cuetip
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_cuetip != null)
                {
                    return Private_cuetip.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_cuetip != null)
                {
                    Private_cuetip.Value = value;
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_4 != null)
                {
                    return Private___intnl_UnityEngineTransform_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_4 != null)
                {
                    Private___intnl_UnityEngineTransform_4.Value = value;
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

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_2 != null)
                {
                    return Private___intnl_UnityEngineVector3_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_2 != null)
                    {
                        Private___intnl_UnityEngineVector3_2.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_minX__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_minX__param != null)
                {
                    return Private___0_minX__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_minX__param != null)
                    {
                        Private___0_minX__param.Value = value.Value;
                    }
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

        internal uint? __gintnl_SystemUInt32_17
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_17 != null)
                {
                    return Private___gintnl_SystemUInt32_17.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_17 != null)
                    {
                        Private___gintnl_SystemUInt32_17.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? lagPrimaryPosition
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lagPrimaryPosition != null)
                {
                    return Private_lagPrimaryPosition.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lagPrimaryPosition != null)
                    {
                        Private_lagPrimaryPosition.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour primaryController
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primaryController != null)
                {
                    return Private_primaryController.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_primaryController != null)
                {
                    Private_primaryController.Value = value;
                }
            }
        }

        internal UnityEngine.Component[] __lcl_udonBehaviours_UnityEngineComponentArray_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_udonBehaviours_UnityEngineComponentArray_2 != null)
                {
                    return Private___lcl_udonBehaviours_UnityEngineComponentArray_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_udonBehaviours_UnityEngineComponentArray_2 != null)
                {
                    Private___lcl_udonBehaviours_UnityEngineComponentArray_2.Value = value;
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

        internal UnityEngine.Vector3? __lcl_position_UnityEngineVector3_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_position_UnityEngineVector3_0 != null)
                {
                    return Private___lcl_position_UnityEngineVector3_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_position_UnityEngineVector3_0 != null)
                    {
                        Private___lcl_position_UnityEngineVector3_0.Value = value.Value;
                    }
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

        internal float? __lcl_rotation_SystemSingle_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_rotation_SystemSingle_1 != null)
                {
                    return Private___lcl_rotation_SystemSingle_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_rotation_SystemSingle_1 != null)
                    {
                        Private___lcl_rotation_SystemSingle_1.Value = value.Value;
                    }
                }
            }
        }

        internal float? __lcl_rotation_SystemSingle_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_rotation_SystemSingle_0 != null)
                {
                    return Private___lcl_rotation_SystemSingle_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_rotation_SystemSingle_0 != null)
                    {
                        Private___lcl_rotation_SystemSingle_0.Value = value.Value;
                    }
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

        internal int? syncedCueSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_syncedCueSkin != null)
                {
                    return Private_syncedCueSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_syncedCueSkin != null)
                    {
                        Private_syncedCueSkin.Value = value.Value;
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

        internal UnityEngine.Transform __intnl_UnityEngineTransform_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_1 != null)
                {
                    return Private___intnl_UnityEngineTransform_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_1 != null)
                {
                    Private___intnl_UnityEngineTransform_1.Value = value;
                }
            }
        }

        internal int? activeCueSkin
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_activeCueSkin != null)
                {
                    return Private_activeCueSkin.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_activeCueSkin != null)
                    {
                        Private_activeCueSkin.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_3 != null)
                {
                    return Private___const_SystemSingle_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_3 != null)
                    {
                        Private___const_SystemSingle_3.Value = value.Value;
                    }
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

        internal float? __0_minZ__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_minZ__param != null)
                {
                    return Private___0_minZ__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_minZ__param != null)
                    {
                        Private___0_minZ__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __5__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___5__intnlparam != null)
                {
                    return Private___5__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___5__intnlparam != null)
                {
                    Private___5__intnlparam.Value = value;
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

        internal VRC.Udon.UdonBehaviour secondaryController
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondaryController != null)
                {
                    return Private_secondaryController.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_secondaryController != null)
                {
                    Private_secondaryController.Value = value;
                }
            }
        }

        internal UnityEngine.Vector3? __lcl_delta_UnityEngineVector3_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_delta_UnityEngineVector3_0 != null)
                {
                    return Private___lcl_delta_UnityEngineVector3_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_delta_UnityEngineVector3_0 != null)
                    {
                        Private___lcl_delta_UnityEngineVector3_0.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_minY__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_minY__param != null)
                {
                    return Private___0_minY__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_minY__param != null)
                    {
                        Private___0_minY__param.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0___0_clamp__ret
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0___0_clamp__ret != null)
                {
                    return Private___0___0_clamp__ret.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0___0_clamp__ret != null)
                    {
                        Private___0___0_clamp__ret.Value = value.Value;
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

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_9 != null)
                {
                    return Private___intnl_UnityEngineVector3_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_9 != null)
                    {
                        Private___intnl_UnityEngineVector3_9.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_6 != null)
                {
                    return Private___const_SystemSingle_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_6 != null)
                    {
                        Private___const_SystemSingle_6.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_4 != null)
                {
                    return Private___intnl_UnityEngineVector3_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_4 != null)
                    {
                        Private___intnl_UnityEngineVector3_4.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_10
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_10 != null)
                {
                    return Private___gintnl_SystemUInt32_10.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_10 != null)
                    {
                        Private___gintnl_SystemUInt32_10.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __lcl_behaviour_VRCUdonUdonBehaviour_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_2 != null)
                {
                    return Private___lcl_behaviour_VRCUdonUdonBehaviour_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_2 != null)
                {
                    Private___lcl_behaviour_VRCUdonUdonBehaviour_2.Value = value;
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

        internal float? __0_maxX__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_maxX__param != null)
                {
                    return Private___0_maxX__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_maxX__param != null)
                    {
                        Private___0_maxX__param.Value = value.Value;
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

        internal bool? secondaryLocked
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_secondaryLocked != null)
                {
                    return Private_secondaryLocked.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_secondaryLocked != null)
                    {
                        Private_secondaryLocked.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Quaternion? __const_UnityEngineQuaternion_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_UnityEngineQuaternion_0 != null)
                {
                    return Private___const_UnityEngineQuaternion_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_UnityEngineQuaternion_0 != null)
                    {
                        Private___const_UnityEngineQuaternion_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_6 != null)
                {
                    return Private___intnl_UnityEngineTransform_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_6 != null)
                {
                    Private___intnl_UnityEngineTransform_6.Value = value;
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_18
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_18 != null)
                {
                    return Private___gintnl_SystemUInt32_18.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_18 != null)
                    {
                        Private___gintnl_SystemUInt32_18.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? primaryLockPos
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_primaryLockPos != null)
                {
                    return Private_primaryLockPos.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_primaryLockPos != null)
                    {
                        Private_primaryLockPos.Value = value.Value;
                    }
                }
            }
        }

        internal float? __const_SystemSingle_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___const_SystemSingle_5 != null)
                {
                    return Private___const_SystemSingle_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___const_SystemSingle_5 != null)
                    {
                        Private___const_SystemSingle_5.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __2__intnlparam
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2__intnlparam != null)
                {
                    return Private___2__intnlparam.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2__intnlparam != null)
                {
                    Private___2__intnlparam.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __intnl_UnityEngineComponent_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineComponent_1 != null)
                {
                    return Private___intnl_UnityEngineComponent_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineComponent_1 != null)
                {
                    Private___intnl_UnityEngineComponent_1.Value = value;
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

        internal UnityEngine.Quaternion? __intnl_UnityEngineQuaternion_0
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineQuaternion_0 != null)
                {
                    return Private___intnl_UnityEngineQuaternion_0.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineQuaternion_0 != null)
                    {
                        Private___intnl_UnityEngineQuaternion_0.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Quaternion? __intnl_UnityEngineQuaternion_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineQuaternion_1 != null)
                {
                    return Private___intnl_UnityEngineQuaternion_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineQuaternion_1 != null)
                    {
                        Private___intnl_UnityEngineQuaternion_1.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Quaternion? __intnl_UnityEngineQuaternion_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineQuaternion_2 != null)
                {
                    return Private___intnl_UnityEngineQuaternion_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineQuaternion_2 != null)
                    {
                        Private___intnl_UnityEngineQuaternion_2.Value = value.Value;
                    }
                }
            }
        }

        internal uint? __gintnl_SystemUInt32_15
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___gintnl_SystemUInt32_15 != null)
                {
                    return Private___gintnl_SystemUInt32_15.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___gintnl_SystemUInt32_15 != null)
                    {
                        Private___gintnl_SystemUInt32_15.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? lagSecondaryPosition
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_lagSecondaryPosition != null)
                {
                    return Private_lagSecondaryPosition.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_lagSecondaryPosition != null)
                    {
                        Private_lagSecondaryPosition.Value = value.Value;
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

        internal bool? __0_shouldReset__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_shouldReset__param != null)
                {
                    return Private___0_shouldReset__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_shouldReset__param != null)
                    {
                        Private___0_shouldReset__param.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_maxZ__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_maxZ__param != null)
                {
                    return Private___0_maxZ__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_maxZ__param != null)
                    {
                        Private___0_maxZ__param.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __lcl_behaviour_VRCUdonUdonBehaviour_1
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_1 != null)
                {
                    return Private___lcl_behaviour_VRCUdonUdonBehaviour_1.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___lcl_behaviour_VRCUdonUdonBehaviour_1 != null)
                {
                    Private___lcl_behaviour_VRCUdonUdonBehaviour_1.Value = value;
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

        internal UnityEngine.Vector3? origSecondaryPosition
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_origSecondaryPosition != null)
                {
                    return Private_origSecondaryPosition.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_origSecondaryPosition != null)
                    {
                        Private_origSecondaryPosition.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_maxY__param
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_maxY__param != null)
                {
                    return Private___0_maxY__param.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_maxY__param != null)
                    {
                        Private___0_maxY__param.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_9
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_9 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_9.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_9 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_9.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_8
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_8 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_8.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_8 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_8.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_3 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_3 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_3.Value = value;
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

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_7
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_7 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_7.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_7 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_7.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_6
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_6 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_6.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_6 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_6.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_5
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_5 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_5.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_5 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_5.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __this_VRCUdonUdonBehaviour_4
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___this_VRCUdonUdonBehaviour_4 != null)
                {
                    return Private___this_VRCUdonUdonBehaviour_4.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___this_VRCUdonUdonBehaviour_4 != null)
                {
                    Private___this_VRCUdonUdonBehaviour_4.Value = value;
                }
            }
        }

        internal UnityEngine.Transform __intnl_UnityEngineTransform_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineTransform_3 != null)
                {
                    return Private___intnl_UnityEngineTransform_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___intnl_UnityEngineTransform_3 != null)
                {
                    Private___intnl_UnityEngineTransform_3.Value = value;
                }
            }
        }

        internal long? __lcl_idValue_SystemObject_2
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___lcl_idValue_SystemObject_2 != null)
                {
                    return Private___lcl_idValue_SystemObject_2.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___lcl_idValue_SystemObject_2 != null)
                    {
                        Private___lcl_idValue_SystemObject_2.Value = value.Value;
                    }
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

        internal UnityEngine.Vector3? __intnl_UnityEngineVector3_3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___intnl_UnityEngineVector3_3 != null)
                {
                    return Private___intnl_UnityEngineVector3_3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___intnl_UnityEngineVector3_3 != null)
                    {
                        Private___intnl_UnityEngineVector3_3.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters AstroUdonVariables  of PoolCue

        #region AstroUdonVariables  of PoolCue

        private AstroUdonVariable<float> Private___const_SystemSingle_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___const_SystemInt64_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___const_SystemInt64_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___const_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private_cuetipDistance { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_targetID_SystemInt64_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_idValue_SystemObject_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0___0__IsOwnershipTransferAllowed__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___0_cueSkin__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___lcl_bodyRotation_UnityEngineVector3_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___lcl_bodyRotation_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___const_SystemBoolean_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___const_SystemBoolean_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_primaryLocked { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_holderIsDesktop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineComponent_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_primary { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___3__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_secondaryOffset { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_secondary { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<float> Private___intnl_SystemSingle_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___refl_typeid { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___1_shouldReset__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___const_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_primaryLockDir { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_secondaryHolding { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_origPrimaryPosition { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___intnl_UnityEngineComponentArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___intnl_UnityEngineComponentArray_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___intnl_UnityEngineComponentArray_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private_gripSize { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_desktop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_primaryHolding { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_targetID_SystemInt64_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___4__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_secondaryLockPos { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_syncedHolderIsDesktop { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_distance_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_11 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_13 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_14 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_16 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___intnl_SystemInt64_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___intnl_SystemInt64_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___intnl_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___intnl_returnJump_SystemUInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_19 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineComponent_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_desktopController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_behaviour_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___lcl_udonBehaviours_UnityEngineComponentArray_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___0_input__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___1__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private_cuetip { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___0_minX__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_table { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_12 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_17 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_lagPrimaryPosition { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___refl_typename { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_primaryController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Component[]> Private___lcl_udonBehaviours_UnityEngineComponentArray_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<UnityEngine.Vector3> Private___lcl_position_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_rotation_SystemSingle_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___lcl_rotation_SystemSingle_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___this_UnityEngineTransform_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_syncedCueSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_targetID_SystemInt64_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private_activeCueSkin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_idValue_SystemObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___0_minZ__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___5__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_secondaryController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___lcl_delta_UnityEngineVector3_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___0_minY__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___0___0_clamp__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_behaviour_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___intnl_SystemInt32_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___0_maxX__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.GameObject> Private___this_UnityEngineGameObject_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_22 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_20 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_21 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___intnl_SystemSingle_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private_secondaryLocked { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Quaternion> Private___const_UnityEngineQuaternion_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_18 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_primaryLockPos { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___const_SystemSingle_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2__intnlparam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___intnl_UnityEngineComponent_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___intnl_SystemBoolean_10 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Quaternion> Private___intnl_UnityEngineQuaternion_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Quaternion> Private___intnl_UnityEngineQuaternion_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Quaternion> Private___intnl_UnityEngineQuaternion_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<uint> Private___gintnl_SystemUInt32_15 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_lagSecondaryPosition { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<int> Private___const_SystemInt32_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0_shouldReset__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___0_maxZ__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___lcl_behaviour_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

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

        private AstroUdonVariable<float> Private___intnl_SystemSingle_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private_origSecondaryPosition { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<float> Private___0_maxY__param { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_9 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_0 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_7 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_6 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_5 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___this_VRCUdonUdonBehaviour_4 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Transform> Private___intnl_UnityEngineTransform_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<long> Private___lcl_idValue_SystemObject_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<bool> Private___0__onOwnershipRequest__ret { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<string> Private___const_SystemString_8 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private AstroUdonVariable<UnityEngine.Vector3> Private___intnl_UnityEngineVector3_3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        #endregion AstroUdonVariables  of PoolCue
    }
}