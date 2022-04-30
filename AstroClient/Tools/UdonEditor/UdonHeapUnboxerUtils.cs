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
                                return PrintAsString<string>(heap, address, FullName);
                            }
                        case "System.String[]":
                            {
                                return PrintAsString<string>(heap, address, FullName);
                            }
                        case "System.StringComparison":
                            {
                                return PrintAsString<System.StringComparison>(heap, address, FullName);
                            }
                        case "System.StringComparison[]":
                            {
                                return PrintAsString<string>(heap, address, FullName);
                            }

                        case "System.UInt32":
                            {
                                return PrintAsString<uint>(heap, address, FullName);
                            }
                        case "System.UInt32[]":
                            {
                                return PrintAsString<uint>(heap, address, FullName);
                            }
                        case "System.Int32":
                            {
                                return PrintAsString<int>(heap, address, FullName);
                            }
                        case "System.Int32[]":
                            {
                                return PrintAsString<int>(heap, address, FullName);
                            }
                        case "System.Int64":
                            {
                                return PrintAsString<long>(heap, address, FullName);
                            }
                        case "System.Int64[]":
                            {
                                return PrintAsString<long>(heap, address, FullName);
                            }
                        case "System.Char":
                            {
                                return PrintAsString<char>(heap, address, FullName);
                            }
                        case "System.Char[]":
                            {
                                return PrintAsString<char>(heap, address, FullName);
                            }
                        case "System.Single":
                            {
                                return PrintAsString<float>(heap, address, FullName);
                            }
                        case "System.Single[]":
                            {
                                return PrintAsString<float>(heap, address, FullName);
                            }
                        case "System.Boolean":
                            {
                                return PrintAsString<bool>(heap, address, FullName);
                            }
                        case "System.Boolean[]":
                            {
                                return PrintAsString<bool>(heap, address, FullName);
                            }
                        case "System.Byte":
                            {
                                return PrintAsString<byte>(heap, address, FullName);
                            }
                        case "System.Byte[]":
                            {
                                return PrintAsString<byte>(heap, address, FullName);
                            }
                        case "System.UInt16":
                            {
                                return PrintAsString<ushort>(heap, address, FullName);
                            }
                        case "System.UInt16[]":
                            {
                                return PrintAsString<ushort>(heap, address, FullName);
                            }
                        case "System.Double":
                            {
                                return PrintAsString<double>(heap, address, FullName);
                            }
                        case "System.Double[]":
                            {
                                return PrintAsString<double>(heap, address, FullName);
                            }
                        case "System.TimeSpan":
                            {
                                return PrintAsString<TimeSpan>(heap, address, FullName);
                            }
                        case "System.TimeSpan[]":
                            {
                                return PrintAsString<TimeSpan>(heap, address, FullName);
                            }
                        case "System.Diagnostics.Stopwatch":
                            {
                                return PrintAsString<System.Diagnostics.Stopwatch>(heap, address, FullName);
                            }
                        case "System.Diagnostics.Stopwatch[]":
                            {
                                return PrintAsString<System.Diagnostics.Stopwatch>(heap, address, FullName);
                            }
                        case "System.DateTime":
                            {
                                return PrintAsString<System.DateTime>(heap, address, FullName);
                            }
                        case "System.DateTime[]":
                            {
                                return PrintAsString<System.DateTime>(heap, address, FullName);
                            }
                        case "System.DayOfWeek":
                            {
                                return PrintAsString<System.DayOfWeek>(heap, address, FullName);
                            }
                        case "System.DayOfWeek[]":
                            {
                                return PrintAsString<System.DayOfWeek>(heap, address, FullName);
                            }

                        case "System.Object":
                            {
                                return PrintAsString<object>(heap, address, FullName);
                            }
                        case "System.Object[]":
                            {
                                return PrintAsString<System.Object>(heap, address, FullName);
                            }

                        #endregion System Types

                        #region Unity Engine

                        case "UnityEngine.Color":
                            {
                                return PrintAsString<UnityEngine.Color>(heap, address, FullName);
                            }
                        case "UnityEngine.Color[]":
                            {
                                return PrintAsString<UnityEngine.Color>(heap, address, FullName);
                            }
                        case "UnityEngine.Material":
                            {
                                return PrintAsString<Material>(heap, address, FullName);
                            }
                        case "UnityEngine.Material[]":
                            {
                                return PrintAsString<Material>(heap, address, FullName);
                            }
                        case "UnityEngine.Renderer":
                            {
                                return PrintAsString<UnityEngine.Renderer>(heap, address, FullName);
                            }
                        case "UnityEngine.Renderer[]":
                            {
                                return PrintAsString<Renderer>(heap, address, FullName);
                            }

                        case "UnityEngine.MeshRenderer":
                            {
                                return PrintAsString<MeshRenderer>(heap, address, FullName);
                            }
                        case "UnityEngine.MeshRenderer[]":
                            {
                                return PrintAsString<MeshRenderer>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem":
                            {
                                return PrintAsString<ParticleSystem>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem[]":
                            {
                                return PrintAsString<ParticleSystem>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem.MainModule":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MainModule>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem.MainModule[]":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MainModule[]>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MinMaxGradient>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem.MinMaxGradient[]":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MinMaxGradient[]>(heap, address, FullName);
                            }

                        case "UnityEngine.Component":
                            {
                                return PrintAsString<Component>(heap, address, FullName);
                            }
                        case "UnityEngine.Component[]":
                            {
                                return PrintAsString<Component[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Transform":
                            {
                                return PrintAsString<Transform>(heap, address, FullName);
                            }
                        case "UnityEngine.Transform[]":
                            {
                                return PrintAsString<Transform[]>(heap, address, FullName);
                            }
                        case "UnityEngine.GameObject":
                            {
                                return PrintAsString<GameObject>(heap, address, FullName);
                            }
                        case "UnityEngine.GameObject[]":
                            {
                                return PrintAsString<GameObject[]>(heap, address, FullName);
                            }
                        case "UnityEngine.AudioClip":
                            {
                                return PrintAsString<AudioClip>(heap, address, FullName);
                            }
                        case "UnityEngine.AudioClip[]":
                            {
                                return PrintAsString<AudioClip[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Vector2":
                            {
                                return PrintAsString<Vector2>(heap, address, FullName);
                            }
                        case "UnityEngine.Vector2[]":
                            {
                                return PrintAsString<Vector2[]>(heap, address, FullName);
                            }

                        case "UnityEngine.Vector3":
                            {
                                return PrintAsString<Vector3>(heap, address, FullName);
                            }
                        case "UnityEngine.Vector3[]":
                            {
                                return PrintAsString<Vector3[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Vector4":
                            {
                                return PrintAsString<Vector4>(heap, address, FullName);
                            }
                        case "UnityEngine.Vector4[]":
                            {
                                return PrintAsString<Vector4[]>(heap, address, FullName);
                            }

                        case "UnityEngine.Quaternion":
                            {
                                return PrintAsString<Quaternion>(heap, address, FullName);
                            }
                        case "UnityEngine.Quaternion[]":
                            {
                                return PrintAsString<Quaternion[]>(heap, address, FullName);
                            }
                        case "UnityEngine.AudioSource":
                            {
                                return PrintAsString<AudioSource>(heap, address, FullName);
                            }
                        case "UnityEngine.AudioSource[]":
                            {
                                return PrintAsString<AudioSource[]>(heap, address, FullName);
                            }
                        case "UnityEngine.HumanBodyBones":
                            {
                                return PrintAsString<HumanBodyBones>(heap, address, FullName);
                            }
                        case "UnityEngine.HumanBodyBones[]":
                            {
                                return PrintAsString<HumanBodyBones[]>(heap, address, FullName);
                            }
                        case "UnityEngine.BoxCollider":
                            {
                                return PrintAsString<BoxCollider>(heap, address, FullName);
                            }
                        case "UnityEngine.BoxCollider[]":
                            {
                                return PrintAsString<BoxCollider[]>(heap, address, FullName);
                            }
                        case "UnityEngine.CapsuleCollider":
                            {
                                return PrintAsString<CapsuleCollider>(heap, address, FullName);
                            }
                        case "UnityEngine.CapsuleCollider[]":
                            {
                                return PrintAsString<CapsuleCollider[]>(heap, address, FullName);
                            }
                        case "UnityEngine.SphereCollider":
                            {
                                return PrintAsString<SphereCollider>(heap, address, FullName);
                            }
                        case "UnityEngine.SphereCollider[]":
                            {
                                return PrintAsString<SphereCollider[]>(heap, address, FullName);
                            }
                        case "UnityEngine.MeshCollider":
                            {
                                return PrintAsString<MeshCollider>(heap, address, FullName);
                            }
                        case "UnityEngine.MeshCollider[]":
                            {
                                return PrintAsString<MeshCollider[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Collider":
                            {
                                return PrintAsString<Collider>(heap, address, FullName);
                            }
                        case "UnityEngine.Collider[]":
                            {
                                return PrintAsString<Collider[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Sprite":
                            {
                                return PrintAsString<Sprite>(heap, address, FullName);
                            }
                        case "UnityEngine.Sprite[]":
                            {
                                return PrintAsString<Sprite[]>(heap, address, FullName);
                            }
                        case "UnityEngine.TextAsset":
                            {
                                return PrintAsString<TextAsset>(heap, address, FullName);
                            }
                        case "UnityEngine.TextAsset[]":
                            {
                                return PrintAsString<TextAsset[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Rigidbody":
                            {
                                return PrintAsString<Rigidbody>(heap, address, FullName);
                            }
                        case "UnityEngine.Rigidbody[]":
                            {
                                return PrintAsString<Rigidbody[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Bounds":
                            {
                                return PrintAsString<Bounds>(heap, address, FullName);
                            }
                        case "UnityEngine.Bounds[]":
                            {
                                return PrintAsString<Bounds[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Animator":
                            {
                                return PrintAsString<Animator>(heap, address, FullName);
                            }
                        case "UnityEngine.Animator[]":
                            {
                                return PrintAsString<Animator[]>(heap, address, FullName);
                            }
                        case "UnityEngine.LayerMask":
                            {
                                return PrintAsString<LayerMask>(heap, address, FullName);
                            }
                        case "UnityEngine.LayerMask[]":
                            {
                                return PrintAsString<LayerMask[]>(heap, address, FullName);
                            }
                        case "UnityEngine.LineRenderer":
                            {
                                return PrintAsString<LineRenderer>(heap, address, FullName);
                            }
                        case "UnityEngine.LineRenderer[]":
                            {
                                return PrintAsString<LineRenderer[]>(heap, address, FullName);
                            }
                        case "UnityEngine.SpriteRenderer":
                            {
                                return PrintAsString<UnityEngine.SpriteRenderer>(heap, address, FullName);
                            }
                        case "UnityEngine.SpriteRenderer[]":
                            {
                                return PrintAsString<UnityEngine.SpriteRenderer[]>(heap, address, FullName);
                            }

                        case "UnityEngine.RaycastHit":
                            {
                                return PrintAsString<RaycastHit>(heap, address, FullName);
                            }
                        case "UnityEngine.RaycastHit[]":
                            {
                                return PrintAsString<RaycastHit[]>(heap, address, FullName);
                            }
                        case "UnityEngine.RectTransform":
                            {
                                return PrintAsString<RectTransform>(heap, address, FullName);
                            }
                        case "UnityEngine.RectTransform[]":
                            {
                                return PrintAsString<RectTransform[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Camera":
                            {
                                return PrintAsString<Camera>(heap, address, FullName);
                            }
                        case "UnityEngine.Camera[]":
                            {
                                return PrintAsString<Camera[]>(heap, address, FullName);
                            }
                        case "UnityEngine.ReflectionProbe":
                            {
                                return PrintAsString<ReflectionProbe>(heap, address, FullName);
                            }
                        case "UnityEngine.ReflectionProbe[]":
                            {
                                return PrintAsString<ReflectionProbe[]>(heap, address, FullName);
                            }
                        case "UnityEngine.KeyCode":
                            {
                                return PrintAsString<KeyCode>(heap, address, FullName);
                            }
                        case "UnityEngine.KeyCode[]":
                            {
                                return PrintAsString<KeyCode[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Rect":
                            {
                                return PrintAsString<Rect>(heap, address, FullName);
                            }
                        case "UnityEngine.Rect[]":
                            {
                                return PrintAsString<Rect[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Mesh":
                            {
                                return PrintAsString<Mesh>(heap, address, FullName);
                            }
                        case "UnityEngine.Mesh[]":
                            {
                                return PrintAsString<Mesh[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Texture":
                            {
                                return PrintAsString<Texture>(heap, address, FullName);
                            }
                        case "UnityEngine.Texture[]":
                            {
                                return PrintAsString<Texture[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Texture2D":
                            {
                                return PrintAsString<Texture2D>(heap, address, FullName);
                            }
                        case "UnityEngine.Texture2D[]":
                            {
                                return PrintAsString<Texture2D[]>(heap, address, FullName);
                            }
                        case "UnityEngine.RenderTexture":
                            {
                                return PrintAsString<RenderTexture>(heap, address, FullName);
                            }
                        case "UnityEngine.RenderTexture[]":
                            {
                                return PrintAsString<RenderTexture[]>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Text":
                            {
                                return PrintAsString<UnityEngine.UI.Text>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Text[]":
                            {
                                return PrintAsString<UnityEngine.UI.Text[]>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Toggle":
                            {
                                return PrintAsString<UnityEngine.UI.Toggle>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Toggle[]":
                            {
                                return PrintAsString<UnityEngine.UI.Toggle[]>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.ScrollRect":
                            {
                                return PrintAsString<UnityEngine.UI.ScrollRect>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.ScrollRect[]":
                            {
                                return PrintAsString<UnityEngine.UI.ScrollRect[]>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.InputField":
                            {
                                return PrintAsString<UnityEngine.UI.InputField>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.InputField[]":
                            {
                                return PrintAsString<UnityEngine.UI.InputField[]>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Image":
                            {
                                return PrintAsString<UnityEngine.UI.Image>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Image[]":
                            {
                                return PrintAsString<UnityEngine.UI.Image[]>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Button":
                            {
                                return PrintAsString<UnityEngine.UI.Button>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Button[]":
                            {
                                return PrintAsString<UnityEngine.UI.Button[]>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Slider":
                            {
                                return PrintAsString<UnityEngine.UI.Slider>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.Slider[]":
                            {
                                return PrintAsString<UnityEngine.UI.Slider[]>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.RawImage":
                            {
                                return PrintAsString<UnityEngine.UI.RawImage>(heap, address, FullName);
                            }
                        case "UnityEngine.UI.RawImage[]":
                            {
                                return PrintAsString<UnityEngine.UI.RawImage[]>(heap, address, FullName);
                            }
                        case "UnityEngine.AI.NavMeshAgent":
                            {
                                return PrintAsString<UnityEngine.AI.NavMeshAgent>(heap, address, FullName);
                            }
                        case "UnityEngine.AI.NavMeshAgent[]":
                            {
                                return PrintAsString<UnityEngine.AI.NavMeshAgent[]>(heap, address, FullName);
                            }
                        case "UnityEngine.AI.NavMeshHit":
                            {
                                return PrintAsString<UnityEngine.AI.NavMeshHit>(heap, address, FullName);
                            }
                        case "UnityEngine.AI.NavMeshHit[]":
                            {
                                return PrintAsString<UnityEngine.AI.NavMeshHit[]>(heap, address, FullName);
                            }
                        case "UnityEngine.ConstantForce":
                            {
                                return PrintAsString<UnityEngine.ConstantForce>(heap, address, FullName);
                            }
                        case "UnityEngine.ConstantForce[]":
                            {
                                return PrintAsString<UnityEngine.ConstantForce[]>(heap, address, FullName);
                            }
                        case "UnityEngine.AnimatorStateInfo":
                            {
                                return PrintAsString<UnityEngine.AnimatorStateInfo>(heap, address, FullName);
                            }
                        case "UnityEngine.AnimatorStateInfo[]":
                            {
                                return PrintAsString<UnityEngine.AnimatorStateInfo[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Light":
                            {
                                return PrintAsString<UnityEngine.Light>(heap, address, FullName);
                            }
                        case "UnityEngine.Light[]":
                            {
                                return PrintAsString<UnityEngine.Light[]>(heap, address, FullName);
                            }
                        case "UnityEngine.OcclusionPortal":
                            {
                                return PrintAsString<UnityEngine.OcclusionPortal>(heap, address, FullName);
                            }
                        case "UnityEngine.OcclusionPortal[]":
                            {
                                return PrintAsString<UnityEngine.OcclusionPortal[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Animations.PositionConstraint":
                            {
                                return PrintAsString<UnityEngine.Animations.PositionConstraint>(heap, address, FullName);
                            }
                        case "UnityEngine.Animations.PositionConstraint[]":
                            {
                                return PrintAsString<UnityEngine.Animations.PositionConstraint[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Space":
                            {
                                return PrintAsString<UnityEngine.Space>(heap, address, FullName);
                            }
                        case "UnityEngine.Space[]":
                            {
                                return PrintAsString<UnityEngine.Space[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeMode>(heap, address, FullName);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeMode[]":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeMode[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode>(heap, address, FullName);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeTimeSlicingMode[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeRefreshMode>(heap, address, FullName);
                            }
                        case "UnityEngine.Rendering.ReflectionProbeRefreshMode[]":
                            {
                                return PrintAsString<UnityEngine.Rendering.ReflectionProbeRefreshMode[]>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem+EmissionModule":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.EmissionModule>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem_EmissionModule[]":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.EmissionModule[]>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MinMaxCurve>(heap, address, FullName);
                            }
                        case "UnityEngine.ParticleSystem+MinMaxCurve[]":
                            {
                                return PrintAsString<UnityEngine.ParticleSystem.MinMaxCurve[]>(heap, address, FullName);
                            }
                        case "UnityEngine.JointMotor":
                            {
                                return PrintAsString<UnityEngine.JointMotor>(heap, address, FullName);
                            }
                        case "UnityEngine.JointMotor[]":
                            {
                                return PrintAsString<UnityEngine.JointMotor[]>(heap, address, FullName);
                            }
                        case "UnityEngine.ForceMode":
                            {
                                return PrintAsString<UnityEngine.ForceMode>(heap, address, FullName);
                            }
                        case "UnityEngine.ForceMode[]":
                            {
                                return PrintAsString<UnityEngine.ForceMode[]>(heap, address, FullName);
                            }
                        case "UnityEngine.HingeJoint":
                            {
                                return PrintAsString<UnityEngine.HingeJoint>(heap, address, FullName);
                            }
                        case "UnityEngine.HingeJoint[]":
                            {
                                return PrintAsString<UnityEngine.HingeJoint[]>(heap, address, FullName);
                            }
                        case "UnityEngine.CustomRenderTexture":
                            {
                                return PrintAsString<UnityEngine.CustomRenderTexture>(heap, address, FullName);
                            }
                        case "UnityEngine.CustomRenderTexture[]":
                            {
                                return PrintAsString<UnityEngine.CustomRenderTexture[]>(heap, address, FullName);
                            }
                        case "UnityEngine.TextureFormat":
                            {
                                return PrintAsString<UnityEngine.TextureFormat>(heap, address, FullName);
                            }
                        case "UnityEngine.TextureFormat[]":
                            {
                                return PrintAsString<UnityEngine.TextureFormat[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Collision":
                            {
                                return PrintAsString<UnityEngine.Collision>(heap, address, FullName);
                            }
                        case "UnityEngine.Collision[]":
                            {
                                return PrintAsString<UnityEngine.Collision[]>(heap, address, FullName);
                            }
                        case "UnityEngine.Animations.ParentConstraint":
                            {
                                return PrintAsString<UnityEngine.Animations.ParentConstraint>(heap, address, FullName);
                            }
                        case "UnityEngine.Animations.ParentConstraint[]":
                            {
                                return PrintAsString<UnityEngine.Animations.ParentConstraint[]>(heap, address, FullName);
                            }
                        case "UnityEngine.MaterialPropertyBlock":
                            {
                                return PrintAsString<UnityEngine.MaterialPropertyBlock>(heap, address, FullName);
                            }
                        case "UnityEngine.MaterialPropertyBlock[]":
                            {
                                return PrintAsString<UnityEngine.MaterialPropertyBlock[]>(heap, address, FullName);
                            }

                        #endregion Unity Engine

                        #region VRChat

                        case "VRC.SDKBase.VRCPlayerApi":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRCPlayerApi[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi[]>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingData>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingData[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingData[]>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingDataType>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRCPlayerApi+TrackingDataType[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRCPlayerApi.TrackingDataType[]>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand":
                            {
                                return PrintAsString<VRC.SDKBase.VRC_Pickup.PickupHand>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRC_Pickup+PickupHand[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRC_Pickup.PickupHand[]>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation":
                            {
                                return PrintAsString<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRC_SceneDescriptor+SpawnOrientation[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRC_SceneDescriptor.SpawnOrientation[]>(heap, address, FullName);
                            }

                        case "VRC.SDKBase.VRCUrl":
                            {
                                return PrintAsString<VRC.SDKBase.VRCUrl>(heap, address, FullName);
                            }
                        case "VRC.SDKBase.VRCUrl[]":
                            {
                                return PrintAsString<VRC.SDKBase.VRCUrl[]>(heap, address, FullName);
                            }
                        case "VRC.Udon.UdonBehaviour":
                            {
                                return PrintAsString<VRC.Udon.UdonBehaviour>(heap, address, FullName);
                            }
                        case "VRC.Udon.UdonBehaviour[]":
                            {
                                return PrintAsString<VRC.Udon.UdonBehaviour[]>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.SerializationResult":
                            {
                                return PrintAsString<VRC.Udon.Common.SerializationResult>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.SerializationResult[]":
                            {
                                return PrintAsString<VRC.Udon.Common.SerializationResult[]>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget":
                            {
                                return PrintAsString<VRC.Udon.Common.Interfaces.NetworkEventTarget>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.Interfaces.NetworkEventTarget[]":
                            {
                                return PrintAsString<VRC.Udon.Common.Interfaces.NetworkEventTarget[]>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.Enums.EventTiming":
                            {
                                return PrintAsString<VRC.Udon.Common.Enums.EventTiming>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.Enums.EventTiming[]":
                            {
                                return PrintAsString<VRC.Udon.Common.Enums.EventTiming[]>(heap, address, FullName);
                            }

                        case "VRC.SDK3.Components.Video.VideoError":
                            {
                                return PrintAsString<VRC.SDK3.Components.Video.VideoError>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.Video.VideoError[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.Video.VideoError[]>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCUrlInputField>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCUrlInputField[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCUrlInputField[]>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCStation":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCStation>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCStation[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCStation[]>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCObjectSync":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCObjectSync>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCObjectSync[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCObjectSync[]>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs":
                            {
                                return PrintAsString<VRC.Udon.Common.UdonInputEventArgs>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.UdonInputEventArgs[]":
                            {
                                return PrintAsString<VRC.Udon.Common.UdonInputEventArgs[]>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.HandType":
                            {
                                return PrintAsString<VRC.Udon.Common.HandType>(heap, address, FullName);
                            }
                        case "VRC.Udon.Common.HandType[]":
                            {
                                return PrintAsString<VRC.Udon.Common.HandType[]>(heap, address, FullName);
                            }

                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer":
                            {
                                return PrintAsString<VRC.SDK3.Video.Components.VRCUnityVideoPlayer>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]":
                            {
                                return PrintAsString<VRC.SDK3.Video.Components.VRCUnityVideoPlayer[]>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer":
                            {
                                return PrintAsString<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]":
                            {
                                return PrintAsString<VRC.SDK3.Video.Components.AVPro.VRCAVProVideoPlayer[]>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCPickup":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCPickup>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCPickup[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCPickup[]>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCAvatarPedestal>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCAvatarPedestal[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCAvatarPedestal[]>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCObjectPool":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCObjectPool>(heap, address, FullName);
                            }
                        case "VRC.SDK3.Components.VRCObjectPool[]":
                            {
                                return PrintAsString<VRC.SDK3.Components.VRCObjectPool[]>(heap, address, FullName);
                            }

                        #endregion VRChat

                        #region TMPRo

                        case "TMPro.TextMeshPro":
                            {
                                return PrintAsString<TMPro.TextMeshPro>(heap, address, FullName);
                            }
                        case "TMPro.TextMeshPro[]":
                            {
                                return PrintAsString<TMPro.TextMeshPro[]>(heap, address, FullName);
                            }
                        case "TMPro.TextMeshProUGUI":
                            {
                                return PrintAsString<TMPro.TextMeshProUGUI>(heap, address, FullName);
                            }
                        case "TMPro.TextMeshProUGUI[]":
                            {
                                return PrintAsString<TMPro.TextMeshProUGUI[]>(heap, address, FullName);
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
            catch(Exception e)
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
        /// <param name="FullName"></param>
        /// <returns></returns>

        internal static string PrintAsString<T>(IUdonHeap heap, uint address, string FullName)
        {
            // Detect if is a array .
            if (FullName.EndsWith("[]"))
            {
                var ArrayString = new StringBuilder();
                switch (FullName)
                {
                    // Special types (get something else instead of default .ToString())

                    #region Returns Types Fullname

                    case "System.Object[]":
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
                    case "UnityEngine.Component[]":
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

                    #endregion Returns Types Fullname

                    #region Returns Text Content

                    case "TMPro.TextMeshPro[]":
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
                    case "TMPro.TextMeshProUGUI[]":
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
                    case "UnityEngine.UI.Text[]":
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
                    case "UnityEngine.TextAsset[]":
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
                    #endregion Returns Text Content

                    #region Returns Displayname

                    case "VRC.SDKBase.VRCPlayerApi[]":
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

                    #endregion Returns Displayname

                    #region Returns Object Names
                    case "UnityEngine.GameObject[]":
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

                    case "VRC.SDK3.Components.VRCPickup[]":
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
                    case "VRC.Udon.UdonBehaviour[]":
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
                    case "UnityEngine.UI.RawImage[]":
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
                    case "UnityEngine.UI.Slider[]":
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
                    case "UnityEngine.UI.Button[]":
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
                    case "UnityEngine.UI.Image[]":
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
                    case "UnityEngine.UI.InputField[]":
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
                    case "UnityEngine.UI.ScrollRect[]":
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
                    case "UnityEngine.UI.Toggle[]":
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
                    case "UnityEngine.RenderTexture[]":
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
                    case "UnityEngine.Texture2D[]":
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
                    case "UnityEngine.Texture[]":
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
                    case "UnityEngine.Mesh[]":
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
                    case "UnityEngine.ReflectionProbe[]":
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
                    case "UnityEngine.Camera[]":
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
                    case "UnityEngine.RectTransform[]":
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
                    case "UnityEngine.LineRenderer[]":
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
                    case "UnityEngine.Animator[]":
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
                    case "UnityEngine.Rigidbody[]":
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
                    case "UnityEngine.BoxCollider[]":
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
                    case "UnityEngine.CapsuleCollider[]":
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
                    case "UnityEngine.SphereCollider[]":
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
                    case "UnityEngine.MeshCollider[]":
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
                    case "UnityEngine.Collider[]":
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
                    case "UnityEngine.Sprite[]":
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
                    #endregion Returns Object Names

                    #region  Returns Vectors to Strings
                    case "UnityEngine.Vector3[]":
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


                    #endregion


                    default: // Fallback to .ToString() extraction
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
                    case "UnityEngine.Component":
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

                    #endregion Returns Types Fullname

                    #region Returns Text Content


                    case "TMPro.TextMeshPro":
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
                    case "TMPro.TextMeshProUGUI":
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
                    case "UnityEngine.UI.Text":
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
                    case "UnityEngine.TextAsset":
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

                    #endregion Returns Text Content

                    #region Returns Displayname

                    case "VRC.SDKBase.VRCPlayerApi":
                        {
                            var item = heap.GetHeapVariable<VRC.SDKBase.VRCPlayerApi>(address);
                            if (item != null)
                            {
                                return item.displayName.ToString();
                            }
                            return $"empty {FullName}";
                        }

                    #endregion Returns Displayname

                    #region Returns Object Name

                    case "VRC.SDK3.Components.VRCPickup":
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
                    case "UnityEngine.GameObject":
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

                    case "VRC.Udon.UdonBehaviour":
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
                    case "UnityEngine.UI.RawImage":
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
                    case "UnityEngine.UI.Slider":
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
                    case "UnityEngine.UI.Button":
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
                    case "UnityEngine.UI.Image":
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
                    case "UnityEngine.UI.InputField":
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
                    case "UnityEngine.UI.ScrollRect":
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
                    case "UnityEngine.UI.Toggle":
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
                    case "UnityEngine.RenderTexture":
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
                    case "UnityEngine.Texture2D":
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
                    case "UnityEngine.Texture":
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
                    case "UnityEngine.Mesh":
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
                    case "UnityEngine.ReflectionProbe":
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
                    case "UnityEngine.Camera":
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
                    case "UnityEngine.RectTransform":
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
                    case "UnityEngine.LineRenderer":
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
                    case "UnityEngine.Animator":
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
                    case "UnityEngine.Rigidbody":
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
                    case "UnityEngine.BoxCollider":
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
                    case "UnityEngine.CapsuleCollider":
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
                    case "UnityEngine.SphereCollider":
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
                    case "UnityEngine.MeshCollider":
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
                    case "UnityEngine.Collider":
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
                    case "UnityEngine.Sprite":
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

                    #endregion Returns Object Name

                    #region  Returns Vectors to Strings

                    case "UnityEngine.Vector3":
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


                    #endregion
                    default: // Fallback to .ToString() extraction
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

                            #endregion Default Extraction (using .ToString())
                        }
                }
            }
            return null;
        }
    }
}