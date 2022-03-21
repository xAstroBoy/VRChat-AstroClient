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
                }
                else
                {
                    ModConsole.Error("Can't Find Player Data behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }

            }
            else
            {
                Destroy(this);
            }
        }


        internal bool? __23_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__23_intnl_SystemBoolean");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __0_const_intnl_VRCSDKBaseVRCPlayerApiTrackingDataType With Type VRC.SDKBase.VRCPlayerApi+TrackingDataType



        internal UnityEngine.Vector3? __0_pos_Vector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Vector3(HitBox, "__0_pos_Vector3");
                return null;
            }
        }


        internal System.String __3_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__3_const_intnl_SystemString");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __0_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(HitBox, "__0_intnl_PlayerData");
                return null;
            }
        }


        internal bool? __0_const_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__0_const_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Quaternion? __1_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Quaternion(HitBox, "__1_intnl_UnityEngineQuaternion");
                return null;
            }
        }


        internal System.Int32? __1_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "__1_const_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __0_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(HitBox, "__0_intnl_PlayerObjectPool");
                return null;
            }
        }


        internal System.Int32? __1_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "__1_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __2_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(HitBox, "__2_intnl_SystemObject");
                return null;
            }
        }


        internal System.String __0_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__0_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __1_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__1_intnl_SystemSingle");
                return null;
            }
        }


        internal float? minHeight
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "minHeight");
                return null;
            }
        }


        internal UnityEngine.Transform __0_this_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Transform(HitBox, "__0_this_intnl_UnityEngineTransform");
                return null;
            }
        }


        internal bool? __5_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__5_intnl_SystemBoolean");
                return null;
            }
        }


        internal uint? __0_const_intnl_exitJumpLoc_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UInt32(HitBox, "__0_const_intnl_exitJumpLoc_UInt32");
                return null;
            }
        }


        internal bool? __15_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__15_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.SDKBase.VRCPlayerApi __1_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(HitBox, "__1_intnl_VRCSDKBaseVRCPlayerApi");
                return null;
            }
        }


        internal System.Int32? poolIndex
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "poolIndex");
                return null;
            }
        }


        internal System.String __6_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__6_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __21_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__21_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __13_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__13_intnl_SystemBoolean");
                return null;
            }
        }


        internal System.String __1_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__1_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __5_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__5_intnl_SystemSingle");
                return null;
            }
        }


        internal UnityEngine.GameObject __0_parentObj_GameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_GameObject(HitBox, "__0_parentObj_GameObject");
                return null;
            }
        }


        internal int[] __1_intnl_SystemInt32Array
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32_Array(HitBox, "__1_intnl_SystemInt32Array");
                return null;
            }
        }


        internal bool? __16_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__16_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __7_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__7_intnl_SystemBoolean");
                return null;
            }
        }


        internal long? __1_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int64(HitBox, "__1_intnl_SystemInt64");
                return null;
            }
        }


        internal bool? __22_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__22_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Component[] __0_intnl_UnityEngineComponentArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Component_Array(HitBox, "__0_intnl_UnityEngineComponentArray");
                return null;
            }
        }


        internal System.String __7_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__7_const_intnl_SystemString");
                return null;
            }
        }


        internal long? __refl_const_intnl_udonTypeID
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int64(HitBox, "__refl_const_intnl_udonTypeID");
                return null;
            }
        }


        internal bool? __4_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__4_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __1_height_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__1_height_Single");
                return null;
            }
        }


        internal bool? __19_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__19_intnl_SystemBoolean");
                return null;
            }
        }


        internal System.String __refl_const_intnl_udonTypeName
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__refl_const_intnl_udonTypeName");
                return null;
            }
        }


        internal UnityEngine.Transform Udon_Root
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Transform(HitBox, "Root");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __0_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(HitBox, "__0_intnl_SystemObject");
                return null;
            }
        }


        internal bool? __1_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__1_intnl_SystemBoolean");
                return null;
            }
        }


        internal System.String __4_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__4_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __11_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__11_intnl_SystemBoolean");
                return null;
            }
        }


        internal System.Int32? __2_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "__2_intnl_SystemInt32");
                return null;
            }
        }


        internal float? __2_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__2_intnl_SystemSingle");
                return null;
            }
        }


        internal float? __0_mp_headHeight_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__0_mp_headHeight_Single");
                return null;
            }
        }


        internal System.String __5_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__5_const_intnl_SystemString");
                return null;
            }
        }


        internal bool? __3_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__3_intnl_SystemBoolean");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __0_headData_TrackingData With Type VRC.SDKBase.VRCPlayerApi+TrackingData



        internal bool? __0_intnl_returnValSymbol_Boolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__0_intnl_returnValSymbol_Boolean");
                return null;
            }
        }


        internal bool? __12_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__12_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? maxHeight
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "maxHeight");
                return null;
            }
        }


        internal UnityEngine.GameObject[] __0_intnl_UnityEngineGameObjectArray
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_GameObject_Array(HitBox, "__0_intnl_UnityEngineGameObjectArray");
                return null;
            }
        }


        internal bool? __0_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__0_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Transform Head
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Transform(HitBox, "Head");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __1_intnl_PlayerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(HitBox, "__1_intnl_PlayerData");
                return null;
            }
        }


        internal int[] __3_intnl_SystemObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32_Array(HitBox, "__3_intnl_SystemObject");
                return null;
            }
        }


        internal UnityEngine.GameObject __0_intnl_UnityEngineGameObject
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_GameObject(HitBox, "__0_intnl_UnityEngineGameObject");
                return null;
            }
        }


        internal System.String __8_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__8_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __6_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__6_intnl_SystemSingle");
                return null;
            }
        }


        internal UnityEngine.Quaternion? __0_intnl_UnityEngineQuaternion
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Quaternion(HitBox, "__0_intnl_UnityEngineQuaternion");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour playerData
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(HitBox, "playerData");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __0_const_intnl_SystemType With Type System.RuntimeType



        internal System.Int32? __0_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "__0_intnl_SystemInt32");
                return null;
            }
        }


        internal uint? __0_intnl_returnTarget_UInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UInt32(HitBox, "__0_intnl_returnTarget_UInt32");
                return null;
            }
        }


        internal float? __0_height_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__0_height_Single");
                return null;
            }
        }


        internal float? __0_mp_playerHeight_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__0_mp_playerHeight_Single");
                return null;
            }
        }


        internal uint? __0_const_intnl_SystemUInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UInt32(HitBox, "__0_const_intnl_SystemUInt32");
                return null;
            }
        }


        internal bool? __9_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__9_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? leeway
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "leeway");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __0_intnl_VRCSDKBaseVRCPlayerApiTrackingData With Type VRC.SDKBase.VRCPlayerApi+TrackingData



        internal float? __0_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__0_intnl_SystemSingle");
                return null;
            }
        }


        internal System.Int32? __0_mp_damage_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "__0_mp_damage_Int32");
                return null;
            }
        }


        internal UnityEngine.Vector3? __3_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Vector3(HitBox, "__3_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal bool? __6_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__6_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.SDKBase.VRCPlayerApi __0_player_VRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(HitBox, "__0_player_VRCPlayerApi");
                return null;
            }
        }


        internal float? __4_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__4_intnl_SystemSingle");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __1_intnl_VRCSDK3ComponentsVRCObjectPool With Type VRC.SDK3.Components.VRCObjectPool



        internal VRC.SDKBase.VRCPlayerApi __0_intnl_VRCSDKBaseVRCPlayerApi
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_VRCPlayerApi(HitBox, "__0_intnl_VRCSDKBaseVRCPlayerApi");
                return null;
            }
        }


        internal bool? __14_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__14_intnl_SystemBoolean");
                return null;
            }
        }


        internal long? __0_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int64(HitBox, "__0_intnl_SystemInt64");
                return null;
            }
        }


        internal System.Int32? __3_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "__3_intnl_SystemInt32");
                return null;
            }
        }


        internal bool? __8_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__8_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __20_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__20_intnl_SystemBoolean");
                return null;
            }
        }


        internal UnityEngine.Vector3? __2_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Vector3(HitBox, "__2_intnl_UnityEngineVector3");
                return null;
            }
        }


        // ERROR : FAILED TO Generate getter for __1_intnl_SystemObject With Type VRC.SDK3.Components.VRCObjectPool



        internal UnityEngine.Vector3? __1_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Vector3(HitBox, "__1_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal System.Int32? __2_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "__2_const_intnl_SystemInt32");
                return null;
            }
        }


        internal float? __3_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__3_intnl_SystemSingle");
                return null;
            }
        }


        internal UnityEngine.Vector3? __0_intnl_UnityEngineVector3
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Vector3(HitBox, "__0_intnl_UnityEngineVector3");
                return null;
            }
        }


        internal UnityEngine.Transform __0_intnl_UnityEngineTransform
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Transform(HitBox, "__0_intnl_UnityEngineTransform");
                return null;
            }
        }


        internal bool? __1_const_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__1_const_intnl_SystemBoolean");
                return null;
            }
        }


        internal long? __0_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int64(HitBox, "__0_const_intnl_SystemInt64");
                return null;
            }
        }


        internal bool? __18_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__18_intnl_SystemBoolean");
                return null;
            }
        }


        internal bool? __2_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__2_intnl_SystemBoolean");
                return null;
            }
        }


        internal float? __7_intnl_SystemSingle
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__7_intnl_SystemSingle");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour gameManager
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(HitBox, "gameManager");
                return null;
            }
        }


        internal bool? __10_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__10_intnl_SystemBoolean");
                return null;
            }
        }


        internal System.String __2_const_intnl_SystemString
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_string(HitBox, "__2_const_intnl_SystemString");
                return null;
            }
        }


        internal float? __0_intnl_returnValSymbol_Single
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_single(HitBox, "__0_intnl_returnValSymbol_Single");
                return null;
            }
        }


        internal long? __1_const_intnl_SystemInt64
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int64(HitBox, "__1_const_intnl_SystemInt64");
                return null;
            }
        }


        internal System.Int32? __0_const_intnl_SystemInt32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "__0_const_intnl_SystemInt32");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __1_intnl_PlayerObjectPool
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(HitBox, "__1_intnl_PlayerObjectPool");
                return null;
            }
        }


        internal bool? __17_intnl_SystemBoolean
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Boolean(HitBox, "__17_intnl_SystemBoolean");
                return null;
            }
        }


        internal VRC.Udon.UdonBehaviour __0_intnl_UnityEngineComponent
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_UdonBehaviour(HitBox, "__0_intnl_UnityEngineComponent");
                return null;
            }
        }


        internal System.Int32? __0_playerId_Int32
        {
            [HideFromIl2Cpp]
            get
            {
                if (HitBox != null) return UdonHeapParser.Udon_Parse_Int32(HitBox, "__0_playerId_Int32");
                return null;
            }
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

        void OnDisable()
        {

        }

        void OnEnable()
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

        // Use this for initialization
    }
}