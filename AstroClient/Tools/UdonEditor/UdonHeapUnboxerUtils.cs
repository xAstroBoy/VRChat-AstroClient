using AstroClient.xAstroBoy.Extensions;
using System.Linq;
using UnityEngine;
using VRC.Udon.Common.Interfaces;

namespace AstroClient.Tools.UdonEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class UdonHeapUnboxerUtils
    {
        internal static List<string> UnsupportedTypes = new List<string>();
        // TODO : make something to get any Type (Convert them back to system types if Il2cppSystem ones, and Convert them to string!)

        internal static string UnboxAsString(RawUdonBehaviour rawitem, string SymbolName)
        {
            if (rawitem != null)
            {
                try
                {
                    var address = rawitem.IUdonSymbolTable.GetAddressFromSymbol(SymbolName);
                    if (address != null)
                    {
                        return UnboxAsString(rawitem.IUdonHeap, address, rawitem.IUdonHeap.GetHeapVariable(address));
                    }
                }
                catch
                {
                }
            }
            return null;
        }

        internal static string UnboxAsString(IUdonHeap heap, uint address, Il2CppSystem.Object obj)
        {
            try
            {
                string FullName = obj.GetIl2CppType().FullName;
                if (obj != null)
                {
                    switch (FullName)
                    {
                        #region System Types

                        case "System.String":
                            {
                                return PrintAsString<string>(heap, address);
                            }
                        case "System.String[]":
                            {
                                return PrintAsString<string[]>(heap, address);
                            }
                        case "System.StringComparison":
                            {
                                return PrintAsString<System.StringComparison>(heap, address);
                            }
                        case "System.StringComparison[]":
                            {
                                return PrintAsString<System.StringComparison[]>(heap, address);
                            }

                        case "System.UInt32":
                            {
                                return PrintAsString<uint>(heap, address);
                            }
                        case "System.UInt32[]":
                            {
                                return PrintAsString<uint[]>(heap, address);
                            }
                        case "System.Int32":
                            {
                                return PrintAsString<int>(heap, address);
                            }
                        case "System.Int32[]":
                            {
                                return PrintAsString<int[]>(heap, address);
                            }
                        case "System.Int64":
                            {
                                return PrintAsString<long>(heap, address);
                            }
                        case "System.Int64[]":
                            {
                                return PrintAsString<long[]>(heap, address);
                            }
                        case "System.Char":
                            {
                                return PrintAsString<char>(heap, address);
                            }
                        case "System.Char[]":
                            {
                                return PrintAsString<char[]>(heap, address);
                            }
                        case "System.Single":
                            {
                                return PrintAsString<float>(heap, address);
                            }
                        case "System.Single[]":
                            {
                                return PrintAsString<float[]>(heap, address);
                            }
                        case "System.Boolean":
                            {
                                return PrintAsString<bool>(heap, address);
                            }
                        case "System.Boolean[]":
                            {
                                return PrintAsString<bool[]>(heap, address);
                            }
                        case "System.Byte":
                            {
                                return PrintAsString<byte>(heap, address);
                            }
                        case "System.Byte[]":
                            {
                                return PrintAsString<byte[]>(heap, address);
                            }
                        case "System.UInt16":
                            {
                                return PrintAsString<ushort>(heap, address);
                            }
                        case "System.UInt16[]":
                            {
                                return PrintAsString<ushort[]>(heap, address);
                            }
                        case "System.Double":
                            {
                                return PrintAsString<double>(heap, address);
                            }
                        case "System.Double[]":
                            {
                                return PrintAsString<double[]>(heap, address);
                            }
                        case "System.TimeSpan":
                            {
                                return PrintAsString<TimeSpan>(heap, address);
                            }
                        case "System.TimeSpan[]":
                            {
                                return PrintAsString<TimeSpan[]>(heap, address);
                            }
                        case "System.Diagnostics.Stopwatch":
                            {
                                return PrintAsString<System.Diagnostics.Stopwatch>(heap, address);
                            }
                        case "System.Diagnostics.Stopwatch[]":
                            {
                                return PrintAsString<System.Diagnostics.Stopwatch[]>(heap, address);
                            }
                        case "System.DateTime":
                            {
                                return PrintAsString<System.DateTime>(heap, address);
                            }
                        case "System.DateTime[]":
                            {
                                return PrintAsString<System.DateTime[]>(heap, address);
                            }
                        case "System.DayOfWeek":
                            {
                                return PrintAsString<System.DayOfWeek>(heap, address);
                            }
                        case "System.DayOfWeek[]":
                            {
                                return PrintAsString<System.DayOfWeek[]>(heap, address);
                            }

                        case "System.Object":
                            {
                                return PrintAsString<System.Object>(heap, address);
                            }
                        case "System.Object[]":
                            {
                                return PrintAsString<System.Object[]>(heap, address);
                            }

                        #endregion System Types

                        #region Unity Engine

                        case "UnityEngine.Color":
                            {
                                return PrintAsString<UnityEngine.Color>(heap, address);
                            }
                        case "UnityEngine.Color[]":
                            {
                                return PrintAsString<UnityEngine.Color[]>(heap, address);
                            }
                        case "UnityEngine.Material":
                            {
                                return PrintAsString<Material>(heap, address);
                            }
                        case "UnityEngine.Material[]":
                            {
                                return PrintAsString<Material[]>(heap, address);
                            }
                        case "UnityEngine.Renderer":
                            {
                                return PrintAsString<UnityEngine.Renderer>(heap, address);
                            }
                        case "UnityEngine.Renderer[]":
                            {
                                return PrintAsString<Renderer[]>(heap, address);
                            }

                        case "UnityEngine.MeshRenderer":
                            {
                                return PrintAsString<MeshRenderer>(heap, address);
                            }
                        case "UnityEngine.MeshRenderer[]":
                            {
                                return PrintAsString<MeshRenderer[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem":
                            {
                                return PrintAsString<ParticleSystem>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem[]":
                            {
                                return PrintAsString<ParticleSystem[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MainModule":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MainModule>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MainModule[]":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MainModule[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MinMaxGradient>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient[]":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MinMaxGradient[]>(heap, address);
                            }

                        case "UnityEngine.Component":
                            {
                                return PrintAsString<Component>(heap, address);
                            }
                        case "UnityEngine.Component[]":
                            {
                                return PrintAsString<Component[]>(heap, address);
                            }
                        case "UnityEngine.Transform":
                            {
                                return PrintAsString<Transform>(heap, address);
                            }
                        case "UnityEngine.Transform[]":
                            {
                                return PrintAsString<Transform[]>(heap, address);
                            }
                        case "UnityEngine.GameObject":
                            {
                                return PrintAsString<GameObject>(heap, address);
                            }
                        case "UnityEngine.GameObject[]":
                            {
                                return PrintAsString<GameObject[]>(heap, address);
                            }
                        case "UnityEngine.AudioClip":
                            {
                                return PrintAsString<AudioClip>(heap, address);
                            }
                        case "UnityEngine.AudioClip[]":
                            {
                                return PrintAsString<AudioClip[]>(heap, address);
                            }
                        case "UnityEngine.Vector2":
                            {
                                return PrintAsString<Vector2>(heap, address);
                            }
                        case "UnityEngine.Vector2[]":
                            {
                                return PrintAsString<Vector2[]>(heap, address);
                            }

                        case "UnityEngine.Vector3":
                            {
                                return PrintAsString<Vector3>(heap, address);
                            }
                        case "UnityEngine.Vector3[]":
                            {
                                return PrintAsString<Vector3[]>(heap, address);
                            }
                        case "UnityEngine.Vector4":
                            {
                                return PrintAsString<Vector4>(heap, address);
                            }
                        case "UnityEngine.Vector4[]":
                            {
                                return PrintAsString<Vector4[]>(heap, address);
                            }

                        case "UnityEngine.Quaternion":
                            {
                                return PrintAsString<Quaternion>(heap, address);
                            }
                        case "UnityEngine.Quaternion[]":
                            {
                                return PrintAsString<Quaternion[]>(heap, address);
                            }
                        case "UnityEngine.AudioSource":
                            {
                                return PrintAsString<AudioSource>(heap, address);
                            }
                        case "UnityEngine.AudioSource[]":
                            {
                                return PrintAsString<AudioSource[]>(heap, address);
                            }
                        case "UnityEngine.HumanBodyBones":
                            {
                                return PrintAsString<HumanBodyBones>(heap, address);
                            }
                        case "UnityEngine.HumanBodyBones[]":
                            {
                                return PrintAsString<HumanBodyBones[]>(heap, address);
                            }
                        case "UnityEngine.BoxCollider":
                            {
                                return PrintAsString<BoxCollider>(heap, address);
                            }
                        case "UnityEngine.BoxCollider[]":
                            {
                                return PrintAsString<BoxCollider[]>(heap, address);
                            }
                        case "UnityEngine.CapsuleCollider":
                            {
                                return PrintAsString<CapsuleCollider>(heap, address);
                            }
                        case "UnityEngine.CapsuleCollider[]":
                            {
                                return PrintAsString<CapsuleCollider[]>(heap, address);
                            }
                        case "UnityEngine.SphereCollider":
                            {
                                return PrintAsString<SphereCollider>(heap, address);
                            }
                        case "UnityEngine.SphereCollider[]":
                            {
                                return PrintAsString<SphereCollider[]>(heap, address);
                            }
                        case "UnityEngine.MeshCollider":
                            {
                                return PrintAsString<MeshCollider>(heap, address);
                            }
                        case "UnityEngine.MeshCollider[]":
                            {
                                return PrintAsString<MeshCollider[]>(heap, address);
                            }
                        case "UnityEngine.Collider":
                            {
                                return PrintAsString<Collider>(heap, address);
                            }
                        case "UnityEngine.Collider[]":
                            {
                                return PrintAsString<Collider[]>(heap, address);
                            }
                        case "UnityEngine.Sprite":
                            {
                                return PrintAsString<Sprite>(heap, address);
                            }
                        case "UnityEngine.Sprite[]":
                            {
                                return PrintAsString<Sprite[]>(heap, address);
                            }
                        case "UnityEngine.TextAsset":
                            {
                                return PrintAsString<TextAsset>(heap, address);
                            }
                        case "UnityEngine.TextAsset[]":
                            {
                                return PrintAsString<TextAsset[]>(heap, address);
                            }
                        case "UnityEngine.Rigidbody":
                            {
                                return PrintAsString<Rigidbody>(heap, address);
                            }
                        case "UnityEngine.Rigidbody[]":
                            {
                                return PrintAsString<Rigidbody[]>(heap, address);
                            }
                        case "UnityEngine.Bounds":
                            {
                                return PrintAsString<Bounds>(heap, address);
                            }
                        case "UnityEngine.Bounds[]":
                            {
                                return PrintAsString<Bounds[]>(heap, address);
                            }
                        case "UnityEngine.Animator":
                            {
                                return PrintAsString<Animator>(heap, address);
                            }
                        case "UnityEngine.Animator[]":
                            {
                                return PrintAsString<Animator[]>(heap, address);
                            }
                        case "UnityEngine.LayerMask":
                            {
                                return PrintAsString<LayerMask>(heap, address);
                            }
                        case "UnityEngine.LayerMask[]":
                            {
                                return PrintAsString<LayerMask[]>(heap, address);
                            }
                        case "UnityEngine.LineRenderer":
                            {
                                return PrintAsString<LineRenderer>(heap, address);
                            }
                        case "UnityEngine.LineRenderer[]":
                            {
                                return PrintAsString<LineRenderer[]>(heap, address);
                            }
                        case "UnityEngine.SpriteRenderer":
                            {
                                return PrintAsString<UnityEngine.SpriteRenderer>(heap, address);
                            }
                        case "UnityEngine.SpriteRenderer[]":
                            {
                                return PrintAsString<UnityEngine.SpriteRenderer[]>(heap, address);
                            }

                        case "UnityEngine.RaycastHit":
                            {
                                return PrintAsString<RaycastHit>(heap, address);
                            }
                        case "UnityEngine.RaycastHit[]":
                            {
                                return PrintAsString<RaycastHit[]>(heap, address);
                            }
                        case "UnityEngine.RectTransform":
                            {
                                return PrintAsString<RectTransform>(heap, address);
                            }
                        case "UnityEngine.RectTransform[]":
                            {
                                return PrintAsString<RectTransform[]>(heap, address);
                            }
                        case "UnityEngine.Camera":
                            {
                                return PrintAsString<Camera>(heap, address);
                            }
                        case "UnityEngine.Camera[]":
                            {
                                return PrintAsString<Camera[]>(heap, address);
                            }
                        case "UnityEngine.ReflectionProbe":
                            {
                                return PrintAsString<ReflectionProbe>(heap, address);
                            }
                        case "UnityEngine.ReflectionProbe[]":
                            {
                                return PrintAsString<ReflectionProbe[]>(heap, address);
                            }
                        case "UnityEngine.KeyCode":
                            {
                                return PrintAsString<KeyCode>(heap, address);
                            }
                        case "UnityEngine.KeyCode[]":
                            {
                                return PrintAsString<KeyCode[]>(heap, address);
                            }
                        case "UnityEngine.Rect":
                            {
                                return PrintAsString<Rect>(heap, address);
                            }
                        case "UnityEngine.Rect[]":
                            {
                                return PrintAsString<Rect[]>(heap, address);
                            }
                        case "UnityEngine.Mesh":
                            {
                                return PrintAsString<Mesh>(heap, address);
                            }
                        case "UnityEngine.Mesh[]":
                            {
                                return PrintAsString<Mesh[]>(heap, address);
                            }
                        case "UnityEngine.Texture":
                            {
                                return PrintAsString<Texture>(heap, address);
                            }
                        case "UnityEngine.Texture[]":
                            {
                                return PrintAsString<Texture[]>(heap, address);
                            }
                        case "UnityEngine.Texture2D":
                            {
                                return PrintAsString<Texture2D>(heap, address);
                            }
                        case "UnityEngine.Texture2D[]":
                            {
                                return PrintAsString<Texture2D[]>(heap, address);
                            }
                        case "UnityEngine.RenderTexture":
                            {
                                return PrintAsString<RenderTexture>(heap, address);
                            }
                        case "UnityEngine.RenderTexture[]":
                            {
                                return PrintAsString<RenderTexture[]>(heap, address);
                            }
                        case "UnityEngine.UI.Text":
                            {
                                return PrintAsString<UnityEngine.UI.Text>(heap, address);
                            }
                        case "UnityEngine.UI.Text[]":
                            {
                                return PrintAsString<UnityEngine.UI.Text[]>(heap, address);
                            }
                        case "UnityEngine.UI.Toggle":
                            {
                                return PrintAsString<UnityEngine.UI.Toggle>(heap, address);
                            }
                        case "UnityEngine.UI.Toggle[]":
                            {
                                return PrintAsString<UnityEngine.UI.Toggle[]>(heap, address);
                            }
                        case "UnityEngine.UI.ScrollRect":
                            {
                                return PrintAsString<UnityEngine.UI.ScrollRect>(heap, address);
                            }
                        case "UnityEngine.UI.ScrollRect[]":
                            {
                                return PrintAsString<UnityEngine.UI.ScrollRect[]>(heap, address);
                            }
                        case "UnityEngine.UI.InputField":
                            {
                                return PrintAsString<UnityEngine.UI.InputField>(heap, address);
                            }
                        case "UnityEngine.UI.InputField[]":
                            {
                                return PrintAsString<UnityEngine.UI.InputField[]>(heap, address);
                            }
                        case "UnityEngine.UI.Image":
                            {
                                return PrintAsString<UnityEngine.UI.Image>(heap, address);
                            }
                        case "UnityEngine.UI.Image[]":
                            {
                                return PrintAsString<UnityEngine.UI.Image[]>(heap, address);
                            }
                        case "UnityEngine.UI.Button":
                            {
                                return PrintAsString<UnityEngine.UI.Button>(heap, address);
                            }
                        case "UnityEngine.UI.Button[]":
                            {
                                return PrintAsString<UnityEngine.UI.Button[]>(heap, address);
                            }
                        case "UnityEngine.UI.Slider":
                            {
                                return PrintAsString<UnityEngine.UI.Slider>(heap, address);
                            }
                        case "UnityEngine.UI.Slider[]":
                            {
                                return PrintAsString<UnityEngine.UI.Slider[]>(heap, address);
                            }
                        case "UnityEngine.UI.RawImage":
                            {
                                return PrintAsString<UnityEngine.UI.RawImage>(heap, address);
                            }
                        case "UnityEngine.UI.RawImage[]":
                            {
                                return PrintAsString<UnityEngine.UI.RawImage[]>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshAgent":
                            {
                                return PrintAsString<UnityEngine.AI.NavMeshAgent>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshAgent[]":
                            {
                                return PrintAsString<UnityEngine.AI.NavMeshAgent[]>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshHit":
                            {
                                return PrintAsString<UnityEngine.AI.NavMeshHit>(heap, address);
                            }
                        case "UnityEngine.AI.NavMeshHit[]":
                            {
                                return PrintAsString<UnityEngine.AI.NavMeshHit[]>(heap, address);
                            }
                        case "UnityEngine.ConstantForce":
                            {
                                return PrintAsString<UnityEngine.ConstantForce>(heap, address);
                            }
                        case "UnityEngine.ConstantForce[]":
                            {
                                return PrintAsString<UnityEngine.ConstantForce[]>(heap, address);
                            }
                        case "UnityEngine.AnimatorStateInfo":
                            {
                                return PrintAsString<UnityEngine.AnimatorStateInfo>(heap, address);
                            }
                        case "UnityEngine.AnimatorStateInfo[]":
                            {
                                return PrintAsString<UnityEngine.AnimatorStateInfo[]>(heap, address);
                            }
                        case "UnityEngine.Light":
                            {
                                return PrintAsString<UnityEngine.Light>(heap, address);
                            }
                        case "UnityEngine.Light[]":
                            {
                                return PrintAsString<UnityEngine.Light[]>(heap, address);
                            }
                        case "UnityEngine.OcclusionPortal":
                            {
                                return PrintAsString<UnityEngine.OcclusionPortal>(heap, address);
                            }
                        case "UnityEngine.OcclusionPortal[]":
                            {
                                return PrintAsString<UnityEngine.OcclusionPortal[]>(heap, address);
                            }
                        case "UnityEngine.Animations.PositionConstraint":
                            {
                                return PrintAsString<UnityEngine.Animations.PositionConstraint>(heap, address);
                            }
                        case "UnityEngine.Animations.PositionConstraint[]":
                            {
                                return PrintAsString<UnityEngine.Animations.PositionConstraint[]>(heap, address);
                            }
                        case "UnityEngine.Space":
                            {
                                return PrintAsString<UnityEngine.Space>(heap, address);
                            }
                        case "UnityEngine.Space[]":
                            {
                                return PrintAsString<UnityEngine.Space[]>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeMode>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode[]":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeMode[]>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeRefreshMode>(heap, address);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode[]":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeRefreshMode[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+EmissionModule":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.EmissionModule>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem_EmissionModule[]":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.EmissionModule[]>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MinMaxCurve>(heap, address);
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve[]":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MinMaxCurve[]>(heap, address);
                            }
                        case "UnityEngine.JointMotor":
                            {
                                return PrintAsString<UnityEngine.JointMotor>(heap, address);
                            }
                        case "UnityEngine.JointMotor[]":
                            {
                                return PrintAsString<UnityEngine.JointMotor[]>(heap, address);
                            }
                        case "UnityEngine.ForceMode":
                            {
                                return PrintAsString<UnityEngine.ForceMode>(heap, address);
                            }
                        case "UnityEngine.ForceMode[]":
                            {
                                return PrintAsString<UnityEngine.ForceMode[]>(heap, address);
                            }
                        case "UnityEngine.HingeJoint":
                            {
                                return PrintAsString<UnityEngine.HingeJoint>(heap, address);
                            }
                        case "UnityEngine.HingeJoint[]":
                            {
                                return PrintAsString<UnityEngine.HingeJoint[]>(heap, address);
                            }
                        case "UnityEngine.CustomRenderTexture":
                            {
                                return PrintAsString<UnityEngine.CustomRenderTexture>(heap, address);
                            }
                        case "UnityEngine.CustomRenderTexture[]":
                            {
                                return PrintAsString<UnityEngine.CustomRenderTexture[]>(heap, address);
                            }
                        case "UnityEngine.TextureFormat":
                            {
                                return PrintAsString<UnityEngine.TextureFormat>(heap, address);
                            }
                        case "UnityEngine.TextureFormat[]":
                            {
                                return PrintAsString<UnityEngine.TextureFormat[]>(heap, address);
                            }
                        case "UnityEngine.Collision":
                            {
                                return PrintAsString<UnityEngine.Collision>(heap, address);
                            }
                        case "UnityEngine.Collision[]":
                            {
                                return PrintAsString<UnityEngine.Collision[]>(heap, address);
                            }
                        case "UnityEngine.Animations.ParentConstraint":
                            {
                                return PrintAsString<UnityEngine.Animations.ParentConstraint>(heap, address);
                            }
                        case "UnityEngine.Animations.ParentConstraint[]":
                            {
                                return PrintAsString<UnityEngine.Animations.ParentConstraint[]>(heap, address);
                            }
                        case "UnityEngine.MaterialPropertyBlock":
                            {
                                return PrintAsString<UnityEngine.MaterialPropertyBlock>(heap, address);
                            }
                        case "UnityEngine.MaterialPropertyBlock[]":
                            {
                                return PrintAsString<UnityEngine.MaterialPropertyBlock[]>(heap, address);
                            }

                        #endregion Unity Engine

                        #region VRChat

                        case "VRC.SDKBase.VRCPlayerApi":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingData>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingData[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingDataType>(heap, address);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingDataType[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand":
                            {
                                return PrintAsString<VRC.SDKBase.VRC_Pickup.PickupHand>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRC_Pickup.PickupHand[]>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation":
                            {
                                return PrintAsString<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation>(heap, address);
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation[]>(heap, address);
                            }

                        case "VRC.SDKBase.VRCUrl":
                            {
                                return PrintAsString<VRC.SDKBase.VRCUrl>(heap, address);
                            }
                        case "VRC.SDKBase.VRCUrl[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRCUrl[]>(heap, address);
                            }
                        case "VRC.Udon.UdonBehaviour":
                            {
                                return PrintAsString<VRC.Udon.UdonBehaviour>(heap, address);
                            }
                        case "VRC.Udon.UdonBehaviour[]":
                            {
                                return PrintAsString<VRC.Udon.UdonBehaviour[]>(heap, address);
                            }
                        case "VRC.Udon.Common.SerializationResult":
                            {
                                return PrintAsString<VRC.Udon.Common.SerializationResult>(heap, address);
                            }
                        case "VRC.Udon.Common.SerializationResult[]":
                            {
                                return PrintAsString<VRC.Udon.Common.SerializationResult[]>(heap, address);
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget":
                            {
                                return PrintAsString<VRC.Udon.Common.Interfaces.NetworkEventTarget>(heap, address);
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget[]":
                            {
                                return PrintAsString<VRC.Udon.Common.Interfaces.NetworkEventTarget[]>(heap, address);
                            }
                        case "VRC.Udon.Common.Enums.EventTiming":
                            {
                                return PrintAsString<VRC.Udon.Common.Enums.EventTiming>(heap, address);
                            }
                        case "VRC.Udon.Common.Enums.EventTiming[]":
                            {
                                return PrintAsString<VRC.Udon.Common.Enums.EventTiming[]>(heap, address);
                            }

                        case "VRC.SDK3.Components.Video.VideoError":
                            {
                                return PrintAsString<VRC.SDK3.Components.Video.VideoError>(heap, address);
                            }
                        case "VRC.SDK3.Components.Video.VideoError[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.Video.VideoError[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCUrlInputField>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCUrlInputField[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCStation":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCStation>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCStation[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCStation[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectSync":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCObjectSync>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectSync[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCObjectSync[]>(heap, address);
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs":
                            {
                                return PrintAsString<VRC.Udon.Common.UdonInputEventArgs>(heap, address);
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs[]":
                            {
                                return PrintAsString<VRC.Udon.Common.UdonInputEventArgs[]>(heap, address);
                            }
                        case "VRC.Udon.Common.HandType":
                            {
                                return PrintAsString<VRC.Udon.Common.HandType>(heap, address);
                            }
                        case "VRC.Udon.Common.HandType[]":
                            {
                                return PrintAsString<VRC.Udon.Common.HandType[]>(heap, address);
                            }

                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer":
                            {
                                return PrintAsString<VRC.SDK3.Video.Components.VRCUnityVideoPlayer>(heap, address);
                            }
                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]":
                            {
                                return PrintAsString<VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]>(heap, address);
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer":
                            {
                                return PrintAsString<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer>(heap, address);
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]":
                            {
                                return PrintAsString<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCPickup":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCPickup>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCPickup[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCPickup[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCAvatarPedestal>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCAvatarPedestal[]>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectPool":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCObjectPool>(heap, address);
                            }
                        case "VRC.SDK3.Components.VRCObjectPool[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCObjectPool[]>(heap, address);
                            }

                        #endregion VRChat

                        #region TMPRo

                        case "TMPro.TextMeshPro":
                            {
                                return PrintAsString<TMPro.TextMeshPro>(heap, address);
                            }
                        case "TMPro.TextMeshPro[]":
                            {
                                return PrintAsString<TMPro.TextMeshPro[]>(heap, address);
                            }
                        case "TMPro.TextMeshProUGUI":
                            {
                                return PrintAsString<TMPro.TextMeshProUGUI>(heap, address);
                            }
                        case "TMPro.TextMeshProUGUI[]":
                            {
                                return PrintAsString<TMPro.TextMeshProUGUI[]>(heap, address);
                            }

                        #endregion TMPRo

                        #region Impossible to Unbox (Unboxables)

                        case "System.RuntimeType": return "Not Unboxable (Protected System Type)";
                        case "System.RuntimeType[]": return "Not Unboxable (Protected System Type)";

                        #endregion Impossible to Unbox (Unboxables)

                        default:
                            {
                                if (!UnsupportedTypes.Contains(FullName))
                                {
                                    UnsupportedTypes.Add(FullName);
                                }
                                return $"Not Supported Yet {FullName}"; // Make it Dump into a different list because we can port these as well
                            }
                    }
                }

                return "Null";
            }
            catch (Exception e)
            {
                Log.Exception(e);
                return $"Error Unboxing {obj.GetIl2CppType().FullName}";
            }
        }

        /// <summary>
        /// This System Tries to support generic T Types of udonbehaviour
        /// This will use a default system to print Various components names and contents using (ToString)
        /// unless you want to edit the switch cases to support a different content such as textmeshpro and other components.
        /// IMPORTANT : DONT FORGET TO EDIT BOTH SWITCH CASES IF YOU ADD A DIFFERENT APPROACH (ARRAY & NORMAL)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="heap"></param>
        /// <param name="address"></param>
        /// <returns></returns>

        internal static string PrintAsString<T>(IUdonHeap heap, uint address)
        {
            // Detect if is a array .
            var FullName = typeof(T).FullName;
            if (FullName != null && FullName.EndsWith("[]"))
            {
                var ArrayString = new StringBuilder();
                switch (FullName)
                {
                    // Special types (get something else instead of default .ToString())

                    #region Returns Types Fullname

                    case "System.Object[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<System.Object[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var type = content[i].GetType();
                                            if (type != null)
                                            {
                                                var fullname = type.FullName;
                                                if (fullname.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(fullname + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Component[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Component[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var type = content[i].GetType();
                                            if (type != null)
                                            {
                                                var fullname = type.FullName;
                                                if (fullname.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(fullname + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Types Fullname

                    #region Returns Text Content

                    case "TMPro.TextMeshPro[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<TMPro.TextMeshPro[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.text;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "TMPro.TextMeshProUGUI[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<TMPro.TextMeshProUGUI[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.text;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Text[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.UI.Text[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.text;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.TextAsset[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.TextAsset[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.text;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Text Content

                    #region Returns Displayname

                    case "VRC.SDKBase.VRCPlayerApi[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<VRC.SDKBase.VRCPlayerApi[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var player = content[i];
                                            if (player != null)
                                            {
                                                var fullname = player.displayName;
                                                if (fullname.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(fullname + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Displayname

                    #region Returns Object Names

                    case "UnityEngine.GameObject[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.GameObject[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    case "VRC.SDK3.Components.VRCPickup[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<VRC.SDK3.Components.VRCPickup[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "VRC.Udon.UdonBehaviour[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<VRC.Udon.UdonBehaviour[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.RawImage[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.UI.RawImage[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Slider[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.UI.Slider[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Button[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.UI.Button[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Image[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.UI.Image[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.InputField[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.UI.InputField[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.ScrollRect[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.UI.ScrollRect[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Toggle[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.UI.Toggle[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.RenderTexture[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.RenderTexture[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Texture2D[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Texture2D[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Texture[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Texture[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Mesh[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Mesh[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.ReflectionProbe[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.ReflectionProbe[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Camera[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Camera[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.RectTransform[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.RectTransform[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.LineRenderer[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.LineRenderer[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.gameObject.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Animator[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Animator[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Rigidbody[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Rigidbody[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.BoxCollider[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.BoxCollider[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.CapsuleCollider[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.CapsuleCollider[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.SphereCollider[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.SphereCollider[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.MeshCollider[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.MeshCollider[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Collider[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Collider[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Sprite[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Sprite[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = item.name;
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Object Names

                    #region Returns Vectors to Strings

                    case "UnityEngine.Vector3[]":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Vector3[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null && listcontent.Count != 0)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            var item = content[i];
                                            if (item != null)
                                            {
                                                var value = $"new Vector3({item.x}, {item.y}, {item.z})";
                                                if (value.IsNotNullOrEmptyOrWhiteSpace())
                                                {
                                                    ArrayString.AppendLine(value + " ,");
                                                }
                                            }
                                        }
                                        return ArrayString.ToString();
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Vectors to Strings

                    default: // Fallback to .ToString() extraction
                        {
                            try
                            {
                                #region Default Extraction (using .ToString())

                                var content = heap.GetHeapVariable<T[]>(address);
                                if (content != null)
                                {
                                    var listcontent = content.ToList();
                                    if (listcontent != null)
                                    {
                                        ArrayString.AppendLine();
                                        for (int i = 0; i < content.Length; i++)
                                        {
                                            ArrayString.AppendLine(content[i].ToString() + " ,");
                                        }
                                    }
                                    return ArrayString.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }

                                #endregion Default Extraction (using .ToString())
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                }
            }
            else // else is a normal type.
            {
                switch (FullName)
                {
                    // Special types (get something else instead of default .ToString())

                    #region Returns Types Fullname

                    case "System.Object":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<System.Object>(address);
                                if (content != null)
                                {
                                    var type = content.GetType();
                                    if (type != null)
                                    {
                                        var resultfullname = type.FullName;
                                        if (resultfullname.IsNotNullOrEmptyOrWhiteSpace())
                                        {
                                            return resultfullname;
                                        }
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Component":
                        {
                            try
                            {
                                var content = heap.GetHeapVariable<UnityEngine.Component>(address);
                                if (content != null)
                                {
                                    var type = content.GetType();
                                    if (type != null)
                                    {
                                        var resultfullname = type.FullName;
                                        if (resultfullname.IsNotNullOrEmptyOrWhiteSpace())
                                        {
                                            return resultfullname;
                                        }
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Types Fullname

                    #region Returns Text Content

                    case "TMPro.TextMeshPro":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<TMPro.TextMeshPro>(address);
                                if (item != null)
                                {
                                    var result = item.text;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "TMPro.TextMeshProUGUI":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<TMPro.TextMeshProUGUI>(address);
                                if (item != null)
                                {
                                    var result = item.text;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Text":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.UI.Text>(address);
                                if (item != null)
                                {
                                    var result = item.text;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.TextAsset":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.TextAsset>(address);
                                if (item != null)
                                {
                                    var result = item.text;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Text Content

                    #region Returns Displayname

                    case "VRC.SDKBase.VRCPlayerApi":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<VRC.SDKBase.VRCPlayerApi>(address);
                                if (item != null)
                                {
                                    return item.displayName.ToString();
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Displayname

                    #region Returns Object Name

                    case "VRC.SDK3.Components.VRCPickup":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<VRC.SDK3.Components.VRCPickup>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.GameObject":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.GameObject>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    case "VRC.Udon.UdonBehaviour":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<VRC.Udon.UdonBehaviour>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.RawImage":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.UI.RawImage>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Slider":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.UI.Slider>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Button":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.UI.Button>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Image":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.UI.Image>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.InputField":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.UI.InputField>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.ScrollRect":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.UI.ScrollRect>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.UI.Toggle":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.UI.Toggle>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.RenderTexture":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.RenderTexture>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Texture2D":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.Texture2D>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Texture":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.Texture>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Mesh":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.Mesh>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.ReflectionProbe":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.ReflectionProbe>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Camera":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.Camera>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.RectTransform":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.RectTransform>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.LineRenderer":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.LineRenderer>(address);
                                if (item != null)
                                {
                                    var result = item.gameObject.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Animator":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.Animator>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Rigidbody":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.Rigidbody>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.BoxCollider":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.BoxCollider>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.CapsuleCollider":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.CapsuleCollider>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.SphereCollider":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.SphereCollider>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.MeshCollider":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.MeshCollider>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Collider":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.Collider>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }
                    case "UnityEngine.Sprite":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.Sprite>(address);
                                if (item != null)
                                {
                                    var result = item.name;
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Object Name

                    #region Returns Vectors to Strings

                    case "UnityEngine.Vector3":
                        {
                            try
                            {
                                var item = heap.GetHeapVariable<UnityEngine.Vector3>(address);
                                if (item != null)
                                {
                                    var result = $"new Vector3({item.x}, {item.y}, {item.z})";
                                    if (result.IsNotNullOrEmptyOrWhiteSpace())
                                    {
                                        return result;
                                    }
                                }
                                return $"empty {FullName}";
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                    #endregion Returns Vectors to Strings

                    default: // Fallback to .ToString() extraction
                        {
                            try
                            {
                                #region Default Extraction (using .ToString())

                                var content = heap.GetHeapVariable<T>(address);
                                if (content != null)
                                {
                                    return content.ToString();
                                }
                                else
                                {
                                    return $"empty {FullName}";
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Exception(e);
                                return $"Error Unboxing {FullName}";
                            }
                        }

                        #endregion Default Extraction (using .ToString())
                }
            }

            return null;
        }
    }
}