namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using WorldModifications.WorldsIds;
    using xAstroBoy;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;

    [RegisterComponent]
    public class PrisonEscape_HitboxReader : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_HitboxReader(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private GameObject _Root;

        internal GameObject Root
        {
            get
            {
                if (_Root == null)
                {
                    return _Root = HitBox.transform.FindObject("Root").gameObject;
                }
                return _Root;
            }
        }

        private GameObject _Visual;

        internal GameObject Visual
        {
            get
            {
                if (_Visual == null)
                {
                    return _Visual = Root.FindObject("Visual").gameObject;
                }
                return _Visual;
            }
        }

        private CapsuleCollider _HitBoxCollider;

        internal CapsuleCollider HitBoxCollider
        {
            get
            {
                if (_HitBoxCollider == null)
                {
                    return _HitBoxCollider = Root.GetComponent<CapsuleCollider>();
                }
                return _HitBoxCollider;
            }
        }

        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.PrisonEscape))
            {
                var obj = gameObject.FindUdonEvent("_Damage");
                if (obj != null)
                {
                    HitBox = obj.UdonBehaviour.ToRawUdonBehaviour();
                    Initialize_HitBox();
                }
                else
                {
                    Log.Error("Can't Find Player Data behaviour, Unable to Add Reader Component, did the author update the world?");
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
            Cleanup_HitBox();
        }

        private bool _EnableVisual { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal bool EnableDebugVisual
        {
            [HideFromIl2Cpp]
            get
            {
                return _EnableVisual;
            }
            [HideFromIl2Cpp]
            set
            {
                _EnableVisual = value;
                Visual.SetActive(value);
            }
        }

        private void OnDisable()
        {
        }

        private void OnEnable()
        {
            if (EnableDebugVisual)
            {
                Visual.SetActive(true);
            }
            else
            {
                Visual.SetActive(false);
            }
        }

        internal bool isBeingUsed
        {
            get
            {
                if (__0_intnl_UnityEngineGameObjectArray == null)
                {
                    return false;
                }

                if (__0_intnl_UnityEngineGameObjectArray != null)
                {
                    if (__0_intnl_UnityEngineGameObjectArray.Length != 0)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        internal static RawUdonBehaviour HitBox { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        #region Getter / Setters UdonVariables  of HitBox

        internal bool? __23_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___23_intnl_SystemBoolean != null)
                {
                    return Private___23_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___23_intnl_SystemBoolean != null)
                    {
                        Private___23_intnl_SystemBoolean.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi.TrackingDataType? __0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType != null)
                {
                    return Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType != null)
                    {
                        Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Vector3? __0_pos_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_pos_Vector3 != null)
                {
                    return Private___0_pos_Vector3.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_pos_Vector3 != null)
                    {
                        Private___0_pos_Vector3.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __0_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_PlayerData != null)
                {
                    return Private___0_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_PlayerData != null)
                {
                    Private___0_intnl_PlayerData.Value = value;
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

        internal UnityEngine.Quaternion? __1_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_UnityEngineQuaternion != null)
                {
                    return Private___1_intnl_UnityEngineQuaternion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_intnl_UnityEngineQuaternion != null)
                    {
                        Private___1_intnl_UnityEngineQuaternion.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __0_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_PlayerObjectPool != null)
                {
                    return Private___0_intnl_PlayerObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_PlayerObjectPool != null)
                {
                    Private___0_intnl_PlayerObjectPool.Value = value;
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

        internal VRC.Udon.UdonBehaviour __2_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___2_intnl_SystemObject != null)
                {
                    return Private___2_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___2_intnl_SystemObject != null)
                {
                    Private___2_intnl_SystemObject.Value = value;
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

        internal float? minHeight
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_minHeight != null)
                {
                    return Private_minHeight.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_minHeight != null)
                    {
                        Private_minHeight.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.Transform __0_this_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_this_intnl_UnityEngineTransform != null)
                {
                    return Private___0_this_intnl_UnityEngineTransform.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_this_intnl_UnityEngineTransform != null)
                {
                    Private___0_this_intnl_UnityEngineTransform.Value = value;
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

        internal int? poolIndex
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_poolIndex != null)
                {
                    return Private_poolIndex.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_poolIndex != null)
                    {
                        Private_poolIndex.Value = value.Value;
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

        internal bool? __21_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___21_intnl_SystemBoolean != null)
                {
                    return Private___21_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___21_intnl_SystemBoolean != null)
                    {
                        Private___21_intnl_SystemBoolean.Value = value.Value;
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

        internal UnityEngine.GameObject __0_parentObj_GameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_parentObj_GameObject != null)
                {
                    return Private___0_parentObj_GameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_parentObj_GameObject != null)
                {
                    Private___0_parentObj_GameObject.Value = value;
                }
            }
        }

        internal int[] __1_intnl_SystemInt32Array
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_SystemInt32Array != null)
                {
                    return Private___1_intnl_SystemInt32Array.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_SystemInt32Array != null)
                {
                    Private___1_intnl_SystemInt32Array.Value = value;
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

        internal bool? __22_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___22_intnl_SystemBoolean != null)
                {
                    return Private___22_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___22_intnl_SystemBoolean != null)
                    {
                        Private___22_intnl_SystemBoolean.Value = value.Value;
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

        internal float? __1_height_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_height_Single != null)
                {
                    return Private___1_height_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___1_height_Single != null)
                    {
                        Private___1_height_Single.Value = value.Value;
                    }
                }
            }
        }

        internal bool? __19_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___19_intnl_SystemBoolean != null)
                {
                    return Private___19_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___19_intnl_SystemBoolean != null)
                    {
                        Private___19_intnl_SystemBoolean.Value = value.Value;
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

        internal UnityEngine.Transform Udon_Root
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Root != null)
                {
                    return Private_Root.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_Root != null)
                {
                    Private_Root.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __0_intnl_SystemObject
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
                if (Private___0_intnl_SystemObject != null)
                {
                    Private___0_intnl_SystemObject.Value = value;
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

        internal float? __0_mp_headHeight_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_headHeight_Single != null)
                {
                    return Private___0_mp_headHeight_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_headHeight_Single != null)
                    {
                        Private___0_mp_headHeight_Single.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi.TrackingData? __0_headData_TrackingData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_headData_TrackingData != null)
                {
                    return Private___0_headData_TrackingData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_headData_TrackingData != null)
                    {
                        Private___0_headData_TrackingData.Value = value.Value;
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

        internal float? maxHeight
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_maxHeight != null)
                {
                    return Private_maxHeight.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_maxHeight != null)
                    {
                        Private_maxHeight.Value = value.Value;
                    }
                }
            }
        }

        internal UnityEngine.GameObject[] __0_intnl_UnityEngineGameObjectArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineGameObjectArray != null)
                {
                    return Private___0_intnl_UnityEngineGameObjectArray.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineGameObjectArray != null)
                {
                    Private___0_intnl_UnityEngineGameObjectArray.Value = value;
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

        internal UnityEngine.Transform Head
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_Head != null)
                {
                    return Private_Head.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_Head != null)
                {
                    Private_Head.Value = value;
                }
            }
        }

        internal VRC.Udon.UdonBehaviour __1_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_PlayerData != null)
                {
                    return Private___1_intnl_PlayerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_PlayerData != null)
                {
                    Private___1_intnl_PlayerData.Value = value;
                }
            }
        }

        internal int[] __3_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___3_intnl_SystemObject != null)
                {
                    return Private___3_intnl_SystemObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___3_intnl_SystemObject != null)
                {
                    Private___3_intnl_SystemObject.Value = value;
                }
            }
        }

        internal UnityEngine.GameObject __0_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineGameObject != null)
                {
                    return Private___0_intnl_UnityEngineGameObject.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_intnl_UnityEngineGameObject != null)
                {
                    Private___0_intnl_UnityEngineGameObject.Value = value;
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

        internal UnityEngine.Quaternion? __0_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_UnityEngineQuaternion != null)
                {
                    return Private___0_intnl_UnityEngineQuaternion.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_UnityEngineQuaternion != null)
                    {
                        Private___0_intnl_UnityEngineQuaternion.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.Udon.UdonBehaviour playerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_playerData != null)
                {
                    return Private_playerData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private_playerData != null)
                {
                    Private_playerData.Value = value;
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

        internal float? __0_height_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_height_Single != null)
                {
                    return Private___0_height_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_height_Single != null)
                    {
                        Private___0_height_Single.Value = value.Value;
                    }
                }
            }
        }

        internal float? __0_mp_playerHeight_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_playerHeight_Single != null)
                {
                    return Private___0_mp_playerHeight_Single.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_playerHeight_Single != null)
                    {
                        Private___0_mp_playerHeight_Single.Value = value.Value;
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

        internal float? leeway
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private_leeway != null)
                {
                    return Private_leeway.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private_leeway != null)
                    {
                        Private_leeway.Value = value.Value;
                    }
                }
            }
        }

        internal VRC.SDKBase.VRCPlayerApi.TrackingData? __0_intnl_VRCSDKBaseVRCPlayerApiTrackingData
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_intnl_VRCSDKBaseVRCPlayerApiTrackingData != null)
                {
                    return Private___0_intnl_VRCSDKBaseVRCPlayerApiTrackingData.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_intnl_VRCSDKBaseVRCPlayerApiTrackingData != null)
                    {
                        Private___0_intnl_VRCSDKBaseVRCPlayerApiTrackingData.Value = value.Value;
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

        internal int? __0_mp_damage_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_mp_damage_Int32 != null)
                {
                    return Private___0_mp_damage_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_mp_damage_Int32 != null)
                    {
                        Private___0_mp_damage_Int32.Value = value.Value;
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

        internal VRC.SDKBase.VRCPlayerApi __0_player_VRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_player_VRCPlayerApi != null)
                {
                    return Private___0_player_VRCPlayerApi.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___0_player_VRCPlayerApi != null)
                {
                    Private___0_player_VRCPlayerApi.Value = value;
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

        internal VRC.SDK3.Components.VRCObjectPool __1_intnl_VRCSDK3ComponentsVRCObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    return Private___1_intnl_VRCSDK3ComponentsVRCObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_VRCSDK3ComponentsVRCObjectPool != null)
                {
                    Private___1_intnl_VRCSDK3ComponentsVRCObjectPool.Value = value;
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

        internal bool? __20_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___20_intnl_SystemBoolean != null)
                {
                    return Private___20_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___20_intnl_SystemBoolean != null)
                    {
                        Private___20_intnl_SystemBoolean.Value = value.Value;
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

        internal VRC.SDK3.Components.VRCObjectPool __1_intnl_SystemObject
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
                if (Private___1_intnl_SystemObject != null)
                {
                    Private___1_intnl_SystemObject.Value = value;
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

        internal bool? __18_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___18_intnl_SystemBoolean != null)
                {
                    return Private___18_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___18_intnl_SystemBoolean != null)
                    {
                        Private___18_intnl_SystemBoolean.Value = value.Value;
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

        internal VRC.Udon.UdonBehaviour __1_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___1_intnl_PlayerObjectPool != null)
                {
                    return Private___1_intnl_PlayerObjectPool.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (Private___1_intnl_PlayerObjectPool != null)
                {
                    Private___1_intnl_PlayerObjectPool.Value = value;
                }
            }
        }

        internal bool? __17_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___17_intnl_SystemBoolean != null)
                {
                    return Private___17_intnl_SystemBoolean.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___17_intnl_SystemBoolean != null)
                    {
                        Private___17_intnl_SystemBoolean.Value = value.Value;
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

        internal int? __0_playerId_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private___0_playerId_Int32 != null)
                {
                    return Private___0_playerId_Int32.Value;
                }

                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (value.HasValue)
                {
                    if (Private___0_playerId_Int32 != null)
                    {
                        Private___0_playerId_Int32.Value = value.Value;
                    }
                }
            }
        }

        #endregion Getter / Setters UdonVariables  of HitBox



        internal void Initialize_HitBox()
        {
            Private___23_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__23_intnl_SystemBoolean");
            Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingDataType>(HitBox, "__0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType");
            Private___0_pos_Vector3 = new AstroUdonVariable<UnityEngine.Vector3>(HitBox, "__0_pos_Vector3");
            Private___3_const_intnl_SystemString = new AstroUdonVariable<string>(HitBox, "__3_const_intnl_SystemString");
            Private___0_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(HitBox, "__0_intnl_PlayerData");
            Private___0_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__0_const_intnl_SystemBoolean");
            Private___1_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(HitBox, "__1_intnl_UnityEngineQuaternion");
            Private___1_const_intnl_SystemInt32 = new AstroUdonVariable<int>(HitBox, "__1_const_intnl_SystemInt32");
            Private___0_intnl_PlayerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(HitBox, "__0_intnl_PlayerObjectPool");
            Private___1_intnl_SystemInt32 = new AstroUdonVariable<int>(HitBox, "__1_intnl_SystemInt32");
            Private___2_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(HitBox, "__2_intnl_SystemObject");
            Private___0_const_intnl_SystemString = new AstroUdonVariable<string>(HitBox, "__0_const_intnl_SystemString");
            Private___1_intnl_SystemSingle = new AstroUdonVariable<float>(HitBox, "__1_intnl_SystemSingle");
            Private_minHeight = new AstroUdonVariable<float>(HitBox, "minHeight");
            Private___0_this_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(HitBox, "__0_this_intnl_UnityEngineTransform");
            Private___5_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__5_intnl_SystemBoolean");
            Private___0_const_intnl_exitJumpLoc_UInt32 = new AstroUdonVariable<uint>(HitBox, "__0_const_intnl_exitJumpLoc_UInt32");
            Private___15_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__15_intnl_SystemBoolean");
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(HitBox, "__1_intnl_VRCSDKBaseVRCPlayerApi");
            Private_poolIndex = new AstroUdonVariable<int>(HitBox, "poolIndex");
            Private___6_const_intnl_SystemString = new AstroUdonVariable<string>(HitBox, "__6_const_intnl_SystemString");
            Private___21_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__21_intnl_SystemBoolean");
            Private___13_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__13_intnl_SystemBoolean");
            Private___1_const_intnl_SystemString = new AstroUdonVariable<string>(HitBox, "__1_const_intnl_SystemString");
            Private___5_intnl_SystemSingle = new AstroUdonVariable<float>(HitBox, "__5_intnl_SystemSingle");
            Private___0_parentObj_GameObject = new AstroUdonVariable<UnityEngine.GameObject>(HitBox, "__0_parentObj_GameObject");
            Private___1_intnl_SystemInt32Array = new AstroUdonVariable<int[]>(HitBox, "__1_intnl_SystemInt32Array");
            Private___16_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__16_intnl_SystemBoolean");
            Private___7_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__7_intnl_SystemBoolean");
            Private___1_intnl_SystemInt64 = new AstroUdonVariable<long>(HitBox, "__1_intnl_SystemInt64");
            Private___22_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__22_intnl_SystemBoolean");
            Private___0_intnl_UnityEngineComponentArray = new AstroUdonVariable<UnityEngine.Component[]>(HitBox, "__0_intnl_UnityEngineComponentArray");
            Private___7_const_intnl_SystemString = new AstroUdonVariable<string>(HitBox, "__7_const_intnl_SystemString");
            Private___refl_const_intnl_udonTypeID = new AstroUdonVariable<long>(HitBox, "__refl_const_intnl_udonTypeID");
            Private___4_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__4_intnl_SystemBoolean");
            Private___1_height_Single = new AstroUdonVariable<float>(HitBox, "__1_height_Single");
            Private___19_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__19_intnl_SystemBoolean");
            Private___refl_const_intnl_udonTypeName = new AstroUdonVariable<string>(HitBox, "__refl_const_intnl_udonTypeName");
            Private_Root = new AstroUdonVariable<UnityEngine.Transform>(HitBox, "Root");
            Private___0_intnl_SystemObject = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(HitBox, "__0_intnl_SystemObject");
            Private___1_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__1_intnl_SystemBoolean");
            Private___4_const_intnl_SystemString = new AstroUdonVariable<string>(HitBox, "__4_const_intnl_SystemString");
            Private___11_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__11_intnl_SystemBoolean");
            Private___2_intnl_SystemInt32 = new AstroUdonVariable<int>(HitBox, "__2_intnl_SystemInt32");
            Private___2_intnl_SystemSingle = new AstroUdonVariable<float>(HitBox, "__2_intnl_SystemSingle");
            Private___0_mp_headHeight_Single = new AstroUdonVariable<float>(HitBox, "__0_mp_headHeight_Single");
            Private___5_const_intnl_SystemString = new AstroUdonVariable<string>(HitBox, "__5_const_intnl_SystemString");
            Private___3_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__3_intnl_SystemBoolean");
            Private___0_headData_TrackingData = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingData>(HitBox, "__0_headData_TrackingData");
            Private___0_intnl_returnValSymbol_Boolean = new AstroUdonVariable<bool>(HitBox, "__0_intnl_returnValSymbol_Boolean");
            Private___12_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__12_intnl_SystemBoolean");
            Private_maxHeight = new AstroUdonVariable<float>(HitBox, "maxHeight");
            Private___0_intnl_UnityEngineGameObjectArray = new AstroUdonVariable<UnityEngine.GameObject[]>(HitBox, "__0_intnl_UnityEngineGameObjectArray");
            Private___0_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__0_intnl_SystemBoolean");
            Private_Head = new AstroUdonVariable<UnityEngine.Transform>(HitBox, "Head");
            Private___1_intnl_PlayerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(HitBox, "__1_intnl_PlayerData");
            Private___3_intnl_SystemObject = new AstroUdonVariable<int[]>(HitBox, "__3_intnl_SystemObject");
            Private___0_intnl_UnityEngineGameObject = new AstroUdonVariable<UnityEngine.GameObject>(HitBox, "__0_intnl_UnityEngineGameObject");
            Private___8_const_intnl_SystemString = new AstroUdonVariable<string>(HitBox, "__8_const_intnl_SystemString");
            Private___6_intnl_SystemSingle = new AstroUdonVariable<float>(HitBox, "__6_intnl_SystemSingle");
            Private___0_intnl_UnityEngineQuaternion = new AstroUdonVariable<UnityEngine.Quaternion>(HitBox, "__0_intnl_UnityEngineQuaternion");
            Private_playerData = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(HitBox, "playerData");
            Private___0_intnl_SystemInt32 = new AstroUdonVariable<int>(HitBox, "__0_intnl_SystemInt32");
            Private___0_intnl_returnTarget_UInt32 = new AstroUdonVariable<uint>(HitBox, "__0_intnl_returnTarget_UInt32");
            Private___0_height_Single = new AstroUdonVariable<float>(HitBox, "__0_height_Single");
            Private___0_mp_playerHeight_Single = new AstroUdonVariable<float>(HitBox, "__0_mp_playerHeight_Single");
            Private___0_const_intnl_SystemUInt32 = new AstroUdonVariable<uint>(HitBox, "__0_const_intnl_SystemUInt32");
            Private___9_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__9_intnl_SystemBoolean");
            Private_leeway = new AstroUdonVariable<float>(HitBox, "leeway");
            Private___0_intnl_VRCSDKBaseVRCPlayerApiTrackingData = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingData>(HitBox, "__0_intnl_VRCSDKBaseVRCPlayerApiTrackingData");
            Private___0_intnl_SystemSingle = new AstroUdonVariable<float>(HitBox, "__0_intnl_SystemSingle");
            Private___0_mp_damage_Int32 = new AstroUdonVariable<int>(HitBox, "__0_mp_damage_Int32");
            Private___3_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(HitBox, "__3_intnl_UnityEngineVector3");
            Private___6_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__6_intnl_SystemBoolean");
            Private___0_player_VRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(HitBox, "__0_player_VRCPlayerApi");
            Private___4_intnl_SystemSingle = new AstroUdonVariable<float>(HitBox, "__4_intnl_SystemSingle");
            Private___1_intnl_VRCSDK3ComponentsVRCObjectPool = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(HitBox, "__1_intnl_VRCSDK3ComponentsVRCObjectPool");
            Private___0_intnl_VRCSDKBaseVRCPlayerApi = new AstroUdonVariable<VRC.SDKBase.VRCPlayerApi>(HitBox, "__0_intnl_VRCSDKBaseVRCPlayerApi");
            Private___14_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__14_intnl_SystemBoolean");
            Private___0_intnl_SystemInt64 = new AstroUdonVariable<long>(HitBox, "__0_intnl_SystemInt64");
            Private___3_intnl_SystemInt32 = new AstroUdonVariable<int>(HitBox, "__3_intnl_SystemInt32");
            Private___8_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__8_intnl_SystemBoolean");
            Private___20_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__20_intnl_SystemBoolean");
            Private___2_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(HitBox, "__2_intnl_UnityEngineVector3");
            Private___1_intnl_SystemObject = new AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool>(HitBox, "__1_intnl_SystemObject");
            Private___1_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(HitBox, "__1_intnl_UnityEngineVector3");
            Private___2_const_intnl_SystemInt32 = new AstroUdonVariable<int>(HitBox, "__2_const_intnl_SystemInt32");
            Private___3_intnl_SystemSingle = new AstroUdonVariable<float>(HitBox, "__3_intnl_SystemSingle");
            Private___0_intnl_UnityEngineVector3 = new AstroUdonVariable<UnityEngine.Vector3>(HitBox, "__0_intnl_UnityEngineVector3");
            Private___0_intnl_UnityEngineTransform = new AstroUdonVariable<UnityEngine.Transform>(HitBox, "__0_intnl_UnityEngineTransform");
            Private___1_const_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__1_const_intnl_SystemBoolean");
            Private___0_const_intnl_SystemInt64 = new AstroUdonVariable<long>(HitBox, "__0_const_intnl_SystemInt64");
            Private___18_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__18_intnl_SystemBoolean");
            Private___2_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__2_intnl_SystemBoolean");
            Private___7_intnl_SystemSingle = new AstroUdonVariable<float>(HitBox, "__7_intnl_SystemSingle");
            Private_gameManager = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(HitBox, "gameManager");
            Private___10_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__10_intnl_SystemBoolean");
            Private___2_const_intnl_SystemString = new AstroUdonVariable<string>(HitBox, "__2_const_intnl_SystemString");
            Private___0_intnl_returnValSymbol_Single = new AstroUdonVariable<float>(HitBox, "__0_intnl_returnValSymbol_Single");
            Private___1_const_intnl_SystemInt64 = new AstroUdonVariable<long>(HitBox, "__1_const_intnl_SystemInt64");
            Private___0_const_intnl_SystemInt32 = new AstroUdonVariable<int>(HitBox, "__0_const_intnl_SystemInt32");
            Private___1_intnl_PlayerObjectPool = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(HitBox, "__1_intnl_PlayerObjectPool");
            Private___17_intnl_SystemBoolean = new AstroUdonVariable<bool>(HitBox, "__17_intnl_SystemBoolean");
            Private___0_intnl_UnityEngineComponent = new AstroUdonVariable<VRC.Udon.UdonBehaviour>(HitBox, "__0_intnl_UnityEngineComponent");
            Private___0_playerId_Int32 = new AstroUdonVariable<int>(HitBox, "__0_playerId_Int32");
        }

        internal void Cleanup_HitBox()
        {
            Private___23_intnl_SystemBoolean = null;
            Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType = null;
            Private___0_pos_Vector3 = null;
            Private___3_const_intnl_SystemString = null;
            Private___0_intnl_PlayerData = null;
            Private___0_const_intnl_SystemBoolean = null;
            Private___1_intnl_UnityEngineQuaternion = null;
            Private___1_const_intnl_SystemInt32 = null;
            Private___0_intnl_PlayerObjectPool = null;
            Private___1_intnl_SystemInt32 = null;
            Private___2_intnl_SystemObject = null;
            Private___0_const_intnl_SystemString = null;
            Private___1_intnl_SystemSingle = null;
            Private_minHeight = null;
            Private___0_this_intnl_UnityEngineTransform = null;
            Private___5_intnl_SystemBoolean = null;
            Private___0_const_intnl_exitJumpLoc_UInt32 = null;
            Private___15_intnl_SystemBoolean = null;
            Private___1_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private_poolIndex = null;
            Private___6_const_intnl_SystemString = null;
            Private___21_intnl_SystemBoolean = null;
            Private___13_intnl_SystemBoolean = null;
            Private___1_const_intnl_SystemString = null;
            Private___5_intnl_SystemSingle = null;
            Private___0_parentObj_GameObject = null;
            Private___1_intnl_SystemInt32Array = null;
            Private___16_intnl_SystemBoolean = null;
            Private___7_intnl_SystemBoolean = null;
            Private___1_intnl_SystemInt64 = null;
            Private___22_intnl_SystemBoolean = null;
            Private___0_intnl_UnityEngineComponentArray = null;
            Private___7_const_intnl_SystemString = null;
            Private___refl_const_intnl_udonTypeID = null;
            Private___4_intnl_SystemBoolean = null;
            Private___1_height_Single = null;
            Private___19_intnl_SystemBoolean = null;
            Private___refl_const_intnl_udonTypeName = null;
            Private_Root = null;
            Private___0_intnl_SystemObject = null;
            Private___1_intnl_SystemBoolean = null;
            Private___4_const_intnl_SystemString = null;
            Private___11_intnl_SystemBoolean = null;
            Private___2_intnl_SystemInt32 = null;
            Private___2_intnl_SystemSingle = null;
            Private___0_mp_headHeight_Single = null;
            Private___5_const_intnl_SystemString = null;
            Private___3_intnl_SystemBoolean = null;
            Private___0_headData_TrackingData = null;
            Private___0_intnl_returnValSymbol_Boolean = null;
            Private___12_intnl_SystemBoolean = null;
            Private_maxHeight = null;
            Private___0_intnl_UnityEngineGameObjectArray = null;
            Private___0_intnl_SystemBoolean = null;
            Private_Head = null;
            Private___1_intnl_PlayerData = null;
            Private___3_intnl_SystemObject = null;
            Private___0_intnl_UnityEngineGameObject = null;
            Private___8_const_intnl_SystemString = null;
            Private___6_intnl_SystemSingle = null;
            Private___0_intnl_UnityEngineQuaternion = null;
            Private_playerData = null;
            Private___0_intnl_SystemInt32 = null;
            Private___0_intnl_returnTarget_UInt32 = null;
            Private___0_height_Single = null;
            Private___0_mp_playerHeight_Single = null;
            Private___0_const_intnl_SystemUInt32 = null;
            Private___9_intnl_SystemBoolean = null;
            Private_leeway = null;
            Private___0_intnl_VRCSDKBaseVRCPlayerApiTrackingData = null;
            Private___0_intnl_SystemSingle = null;
            Private___0_mp_damage_Int32 = null;
            Private___3_intnl_UnityEngineVector3 = null;
            Private___6_intnl_SystemBoolean = null;
            Private___0_player_VRCPlayerApi = null;
            Private___4_intnl_SystemSingle = null;
            Private___1_intnl_VRCSDK3ComponentsVRCObjectPool = null;
            Private___0_intnl_VRCSDKBaseVRCPlayerApi = null;
            Private___14_intnl_SystemBoolean = null;
            Private___0_intnl_SystemInt64 = null;
            Private___3_intnl_SystemInt32 = null;
            Private___8_intnl_SystemBoolean = null;
            Private___20_intnl_SystemBoolean = null;
            Private___2_intnl_UnityEngineVector3 = null;
            Private___1_intnl_SystemObject = null;
            Private___1_intnl_UnityEngineVector3 = null;
            Private___2_const_intnl_SystemInt32 = null;
            Private___3_intnl_SystemSingle = null;
            Private___0_intnl_UnityEngineVector3 = null;
            Private___0_intnl_UnityEngineTransform = null;
            Private___1_const_intnl_SystemBoolean = null;
            Private___0_const_intnl_SystemInt64 = null;
            Private___18_intnl_SystemBoolean = null;
            Private___2_intnl_SystemBoolean = null;
            Private___7_intnl_SystemSingle = null;
            Private_gameManager = null;
            Private___10_intnl_SystemBoolean = null;
            Private___2_const_intnl_SystemString = null;
            Private___0_intnl_returnValSymbol_Single = null;
            Private___1_const_intnl_SystemInt64 = null;
            Private___0_const_intnl_SystemInt32 = null;
            Private___1_intnl_PlayerObjectPool = null;
            Private___17_intnl_SystemBoolean = null;
            Private___0_intnl_UnityEngineComponent = null;
            Private___0_playerId_Int32 = null;
        }

        #region UdonVariables  of HitBox

        private AstroUdonVariable<bool> Private___23_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingDataType> Private___0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_pos_Vector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___3_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Quaternion> Private___1_intnl_UnityEngineQuaternion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_PlayerObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___1_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___2_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___0_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_minHeight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_this_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___5_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_exitJumpLoc_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___15_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___1_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private_poolIndex { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___6_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___21_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___13_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___1_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___5_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_parentObj_GameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int[]> Private___1_intnl_SystemInt32Array { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___16_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___7_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___1_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___22_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Component[]> Private___0_intnl_UnityEngineComponentArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___7_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___refl_const_intnl_udonTypeID { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___4_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___1_height_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___19_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___refl_const_intnl_udonTypeName { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_Root { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___4_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___11_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___2_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_headHeight_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___5_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___3_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingData> Private___0_headData_TrackingData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_returnValSymbol_Boolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___12_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_maxHeight { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject[]> Private___0_intnl_UnityEngineGameObjectArray { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___0_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private_Head { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_PlayerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int[]> Private___3_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.GameObject> Private___0_intnl_UnityEngineGameObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___8_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___6_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Quaternion> Private___0_intnl_UnityEngineQuaternion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_playerData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_intnl_returnTarget_UInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_height_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_mp_playerHeight_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<uint> Private___0_const_intnl_SystemUInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___9_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private_leeway { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi.TrackingData> Private___0_intnl_VRCSDKBaseVRCPlayerApiTrackingData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_mp_damage_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___3_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___6_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_player_VRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___4_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___1_intnl_VRCSDK3ComponentsVRCObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDKBase.VRCPlayerApi> Private___0_intnl_VRCSDKBaseVRCPlayerApi { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___14_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___3_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___8_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___20_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___2_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.SDK3.Components.VRCObjectPool> Private___1_intnl_SystemObject { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___1_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___2_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___3_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Vector3> Private___0_intnl_UnityEngineVector3 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<UnityEngine.Transform> Private___0_intnl_UnityEngineTransform { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___1_const_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___0_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___18_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___2_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___7_intnl_SystemSingle { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private_gameManager { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___10_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<string> Private___2_const_intnl_SystemString { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<float> Private___0_intnl_returnValSymbol_Single { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<long> Private___1_const_intnl_SystemInt64 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_const_intnl_SystemInt32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___1_intnl_PlayerObjectPool { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<bool> Private___17_intnl_SystemBoolean { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<VRC.Udon.UdonBehaviour> Private___0_intnl_UnityEngineComponent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private AstroUdonVariable<int> Private___0_playerId_Int32 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        #endregion UdonVariables  of HitBox

        // Use this for initialization
    }
}