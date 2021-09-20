﻿namespace AstroClient.Udon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public struct UdonTypes_String 
    {

        // System 
        public const string System_String  = "System.String";
        public const string System_String_Array  = "System.String[]";

        public const string System_Uint32  = "System.UInt32";
        public const string System_Uint32_Array  = "System.UInt32[]";

        public const string System_Int32  = "System.Int32";
        public const string System_Int32_Array  = "System.Int32[]";

        public const string System_Int64  = "System.Int64";
        public const string System_Int64_Array  = "System.Int64[]";


        public const string System_Char  = "System.Char";
        public const string System_Char_Array  = "System.Char[]";


        public const string System_Single  = "System.Single";
        public const string System_Single_Array  = "System.Single[]";


        public const string System_Boolean  = "System.Boolean";
        public const string System_Boolean_Array  = "System.Boolean[]";


        public const string System_Byte = "System.Byte";
        public const string System_Byte_Array = "System.Byte[]";


        public const string System_Object  = "System.Object";
        public const string System_Object_Array  = "System.Object[]";


        // UnityEngine

        public const string UnityEngine_Color  = "UnityEngine.Color";
        public const string UnityEngine_Color_Array  = "UnityEngine.Color[]";


        public const string UnityEngine_Material  = "UnityEngine.Material";
        public const string UnityEngine_Material_Array  = "UnityEngine.Material[]";

        public const string UnityEngine_MeshRenderer  = "UnityEngine.MeshRenderer";
        public const string UnityEngine_MeshRenderer_Array  = "UnityEngine.MeshRenderer[]";


        public const string UnityEngine_ParticleSystem  = "UnityEngine.ParticleSystem";
        public const string UnityEngine_ParticleSystem_Array  = "UnityEngine.ParticleSystem[]";

        public const string UnityEngine_Transform  = "UnityEngine.Transform";
        public const string UnityEngine_Transform_Array  = "UnityEngine.Transform[]";

        public const string UnityEngine_GameObject  = "UnityEngine.GameObject";
        public const string UnityEngine_GameObject_Array  = "UnityEngine.GameObject[]";

        public const string UnityEngine_AudioClip  = "UnityEngine.AudioClip";
        public const string UnityEngine_AudioClip_Array  = "UnityEngine.AudioClip[]";


        public const string UnityEngine_Vector3  = "UnityEngine.Vector3";
        public const string UnityEngine_Vector3_Array  = "UnityEngine.Vector3[]";


        public const string UnityEngine_Quaternion  = "UnityEngine.Quaternion";
        public const string UnityEngine_Quaternion_Array  = "UnityEngine.Quaternion[]";


        public const string UnityEngine_AudioSource  = "UnityEngine.AudioSource";
        public const string UnityEngine_AudioSource_Array  = "UnityEngine.AudioSource[]";

        public const string UnityEngine_HumanBodyBones  = "UnityEngine.HumanBodyBones";
        public const string UnityEngine_HumanBodyBones_Array  = "UnityEngine.HumanBodyBones[]";

        public const string UnityEngine_UI_Text  = "UnityEngine.UI.Text";
        public const string UnityEngine_UI_Text_Array  = "UnityEngine.UI.Text[]";


        // VRChat

        public const string VRC_SDKBase_VRCPlayerApi  = "VRC.SDKBase.VRCPlayerApi";
        public const string VRC_SDKBase_VRCPlayerApi_Array  = "VRC.SDKBase.VRCPlayerApi[]";


        public const string VRC_Udon_UdonBehaviour  = "VRC.Udon.UdonBehaviour";
        public const string VRC_Udon_UdonBehaviour_Array  = "VRC.Udon.UdonBehaviour[]";


        public const string VRC_Udon_Common_Interfaces_NetworkEventTarget  = "VRC.Udon.Common.Interfaces.NetworkEventTarget";
        public const string VRC_Udon_Common_Interfaces_NetworkEventTarget_Array  = "VRC.Udon.Common.Interfaces.NetworkEventTarget[]";


        // TMPRO 
        public const string TMPro_TextMeshPro  = "TMPro.TextMeshPro";
        public const string TMPro_TextMeshPro_Array  = "TMPro.TextMeshPro[]";


        public const string TMPro_TextMeshProUGUI  = "TMPro.TextMeshProUGUI";
        public const string TMPro_TextMeshProUGUI_Array  = "TMPro.TextMeshProUGUI[]";


        // TO Implement...

        public const string UnityEngine_Component = "UnityEngine.Component";
        public const string UnityEngine_Component_Array = "UnityEngine.Component[]";


        public const string UnityEngine_BoxCollider = "UnityEngine.BoxCollider";
        public const string UnityEngine_BoxCollider_Array = "UnityEngine.BoxCollider[]";

        public const string UnityEngine_CapsuleCollider = "UnityEngine.CapsuleCollider";
        public const string UnityEngine_CapsuleCollider_Array = "UnityEngine.CapsuleCollider[]";

        public const string UnityEngine_SphereCollider = "UnityEngine.SphereCollider";
        public const string UnityEngine_SphereCollider_Array = "UnityEngine.SphereCollider[]";

        public const string UnityEngine_MeshCollider = "UnityEngine.MeshCollider";
        public const string UnityEngine_MeshCollider_Array = "UnityEngine.MeshCollider[]";

        public const string UnityEngine_Sprite = "UnityEngine.Sprite";
        public const string UnityEngine_Sprite_Array = "UnityEngine.Sprite[]";

        public const string UnityEngine_Rigidbody = "UnityEngine.Rigidbody";
        public const string UnityEngine_Rigidbody_Array = "UnityEngine.Rigidbody[]";

        public const string UnityEngine_Bounds = "UnityEngine.Bounds";
        public const string UnityEngine_Bounds_Array = "UnityEngine.Bounds[]";

        public const string UnityEngine_Animator = "UnityEngine.Animator";
        public const string UnityEngine_Animator_Array = "UnityEngine.Animator[]";

        public const string UnityEngine_LayerMask = "UnityEngine.LayerMask";
        public const string UnityEngine_LayerMask_Array = "UnityEngine.LayerMask[]";

        public const string UnityEngine_LineRenderer = "UnityEngine.LineRenderer";
        public const string UnityEngine_LineRenderer_Array = "UnityEngine.LineRenderer[]";

        public const string UnityEngine_RaycastHit = "UnityEngine.RaycastHit";
        public const string UnityEngine_RaycastHit_Array = "UnityEngine.RaycastHit[]";

        public const string UnityEngine_RectTransform = "UnityEngine.RectTransform";
        public const string UnityEngine_RectTransform_Array = "UnityEngine.RectTransform[]";

        public const string UnityEngine_Camera = "UnityEngine.Camera";
        public const string UnityEngine_Camera_Array = "UnityEngine.Camera[]";

        public const string UnityEngine_KeyCode = "UnityEngine.KeyCode";
        public const string UnityEngine_KeyCode_Array = "UnityEngine.KeyCode[]";

        public const string UnityEngine_Rect = "UnityEngine.Rect";
        public const string UnityEngine_Rect_Array = "UnityEngine.Rect[]";

        public const string UnityEngine_Texture2D = "UnityEngine.Texture2D";
        public const string UnityEngine_Texture2D_Array = "UnityEngine.Texture2D[]";

        public const string UnityEngine_AI_NavMeshAgent = "UnityEngine.AI.NavMeshAgent";
        public const string UnityEngine_AI_NavMeshAgent_Array = "UnityEngine.AI.NavMeshAgent[]";

        public const string UnityEngine_AI_NavMeshHit = "UnityEngine.AI.NavMeshHit";
        public const string UnityEngine_AI_NavMeshHit_Array = "UnityEngine.AI.NavMeshHit[]";

        public const string UnityEngine_UI_Toggle = "UnityEngine.UI.Toggle";
        public const string UnityEngine_UI_Toggle_Array = "UnityEngine.UI.Toggle[]";


        public const string UnityEngine_UI_Image = "UnityEngine.UI.Image";
        public const string UnityEngine_UI_Image_Array = "UnityEngine.UI.Image[]";


        public const string UnityEngine_UI_Button = "UnityEngine.UI.Button";
        public const string UnityEngine_UI_Button_Array = "UnityEngine.UI.Button[]";


        public const string UnityEngine_UI_RawImage = "UnityEngine.UI.RawImage";
        public const string UnityEngine_UI_RawImage_Array = "UnityEngine.UI.RawImage[]";



        public const string VRC_SDK3_Components_VRCPickup = "VRC.SDK3.Components.VRCPickup";
        public const string VRC_SDK3_Components_VRCPickup_Array = "VRC.SDK3.Components.VRCPickup[]";

        public const string VRC_SDK3_Components_VRCAvatarPedestal = "VRC.SDK3.Components.VRCAvatarPedestal";
        public const string VRC_SDK3_Components_VRCAvatarPedestal_Array = "VRC.SDK3.Components.VRCAvatarPedestal[]";


        // Unable to Unbox YET (Class Type is Protected)....


        public const string System_RuntimeType = "System.RuntimeType";
        public const string System_RuntimeType_Array = "System.RuntimeType[]";


        // Idk How to unbox..
        public const string VRC_SDKBase_VRCPlayerApi_TrackingData = "VRC.SDKBase.VRCPlayerApi+TrackingData";
        public const string VRC_SDKBase_VRCPlayerApi_TrackingData_Array = "VRC.SDKBase.VRCPlayerApi+TrackingData[]";

        public const string VRC_SDKBase_VRCPlayerApi_TrackingDataType = "VRC.SDKBase.VRCPlayerApi+TrackingDataType";
        public const string VRC_SDKBase_VRCPlayerApi_TrackingDataType_Array = "VRC.SDKBase.VRCPlayerApi+TrackingDataType[]";


    }
}
